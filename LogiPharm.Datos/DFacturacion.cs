using CapaDatos;
using LogiPharm.Entidades;
using MySqlConnector;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Generic;

using Formatting = Newtonsoft.Json.Formatting;

namespace LogiPharm.Datos
{
    public class DFacturacion
    {
		private const string LogifactLoginUrl = "https://api.nexusfact.com/?login=1";
		private const string LogifactApiUrl = "https://api.nexusfact.com/";
		private const string LogifactSriUrl = "https://api.nexusfact.com/consulta_sri.php?clave=";
		private const string DefaultUsername = "admin";
		private const string DefaultPassword = "admin123";

		private static int GetAmbienteSRI(string ambienteSRI)
		{
			if (string.IsNullOrWhiteSpace(ambienteSRI)) return 1;
			var v = ambienteSRI.Trim();
			if (v == "2") return 2;
			if (v == "1") return 1;
			if (v.IndexOf("PRUE", StringComparison.OrdinalIgnoreCase) >= 0) return 1;
			if (v.IndexOf("PROD", StringComparison.OrdinalIgnoreCase) >= 0) return 2;
			return 1;
		}

		private static bool ResolverEsProduccion(string ambienteSRI)
		{
			return GetAmbienteSRI(ambienteSRI) == 2;
		}

		private static async Task<HttpClient> GetBypassedClientAsync(CookieContainer cookieContainer)
		{
			var handler = new HttpClientHandler
			{
				CookieContainer = cookieContainer,
				UseCookies = true,
				ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
			};

			var client = new HttpClient(handler);
			client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");
			client.Timeout = TimeSpan.FromSeconds(30);

			try
			{
				var response = await client.GetAsync("https://api.nexusfact.com/");
				var html = await response.Content.ReadAsStringAsync();

				var match = Regex.Match(html, @"document\.cookie\s*=\s*""([^""]+)""");
				if (match.Success)
				{
					string cookieString = match.Groups[1].Value;
					var parts = cookieString.Split(';');
					if (parts.Length > 0)
					{
						var kv = parts[0].Split('=');
						if (kv.Length == 2)
						{
							var cookie = new Cookie(kv[0].Trim(), kv[1].Trim(), "/")
							{
								Domain = "api.nexusfact.com"
							};
							cookieContainer.Add(cookie);
						}
					}
				}

				await Task.Delay(2000);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine("Error al realizar bypass anti-bot: " + ex.Message);
			}

			return client;
		}

		private static async Task<string> LoginLogifactAsync(HttpClient client, string username, string password)
		{
			var payload = new { username = username, password = password };
			var json = JsonConvert.SerializeObject(payload);

			using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
			{
				content.Headers.Add("Referer", "https://api.nexusfact.com/");
				var response = await client.PostAsync(LogifactLoginUrl, content);
				var responseBody = await response.Content.ReadAsStringAsync();

				if (!response.IsSuccessStatusCode)
				{
					return null;
				}

				var data = JsonConvert.DeserializeObject<dynamic>(responseBody);
				if (data != null && (bool)(data.success ?? false) && data.token != null)
				{
					return (string)data.token;
				}
			}
			return null;
		}

		private static string GetStatusFromLogifactResponse(dynamic res)
		{
			if (res == null) return "RECHAZADO";
			string autoEst = ((string)(res.autorizacion?.estado))?.ToUpperInvariant() ?? "";
			string topEst = ((string)(res.estado))?.ToUpperInvariant() ?? "";
			string recEst = ((string)(res.recepcion?.estado))?.ToUpperInvariant() ?? "";

			if (new[] { "AUTORIZADO", "AUTORIZADA", "RECHAZADO", "DEVUELTA", "NO AUTORIZADO" }.Contains(autoEst))
			{
				return autoEst;
			}
			if (!string.IsNullOrEmpty(topEst)) return topEst;
			if (!string.IsNullOrEmpty(recEst)) return recEst;
			return "PENDIENTE";
		}

		public async Task<RespuestaFacturaApi> ProcesarFacturaApiAsync(ProcesarFacturaRequest request)
		{
			if (request == null) throw new ArgumentNullException(nameof(request));

			EEmpresa empresa = new DEmpresa().ObtenerDatosEmpresa();
			if (empresa == null) throw new Exception("No se pudo obtener la configuración de la empresa.");

			string rucEmisor = (empresa.Ruc ?? "").Trim();
			string certPath = (empresa.CertificadoP12Path ?? "").Trim();
			string certPass = (empresa.CertificadoPassword ?? "").Trim();
			int ambienteSRI = GetAmbienteSRI(empresa.AmbienteSRI);

			var logifactData = new
			{
				ambiente = ambienteSRI,
				tipoEmision = "1",
				identificacionEmisor = rucEmisor,
				identificador = rucEmisor,
				razonSocialEmisor = (empresa.RazonSocial ?? "").Trim(),
				certificado_p12_path = certPath,
				certificado_password = certPass,
				codDoc = "01",
				establecimiento = request.data.establecimiento,
				puntoEmision = request.data.puntoEmision,
				secuencial = request.data.secuencial,
				fechaEmision = request.data.fechaEmision,
				dirEstablecimiento = (empresa.DireccionMatriz ?? "Av. Principal").Trim(),
				obligadoContabilidad = empresa.ObligadoContabilidad ? "SI" : "NO",
				tipoIdentificacionComprador = (request.data.identificacionComprador == "9999999999999" || request.data.identificacionComprador == "9999999999")
					? "07"
					: (request.data.identificacionComprador.Length == 13 ? "04" : (request.data.identificacionComprador.Length == 10 ? "05" : "06")),
				razonSocialComprador = request.data.razonSocialComprador,
				identificacionComprador = request.data.identificacionComprador,
				totalSinImpuestos = request.data.totalSinImpuestos,
				totalDescuento = request.data.totalDescuento,
				importeTotal = request.data.importeTotal,
				moneda = "DOLAR",
				impuestos = request.data.impuestos.Select(imp => new
				{
					codigo = imp.codigo,
					codigoPorcentaje = imp.codigoPorcentaje,
					baseImponible = imp.baseImponible,
					valor = imp.valor
				}).ToList(),
				pagos = request.data.pagos.Select(pag => new
				{
					formaPago = (pag.formaPago == "EFECTIVO" || pag.formaPago == "01" || string.IsNullOrEmpty(pag.formaPago)) ? "01" : pag.formaPago,
					total = pag.total
				}).ToList(),
				detalles = request.data.detalles.Select(det => new
				{
					codigoPrincipal = det.codigoPrincipal,
					description = det.descripcion,
					cantidad = det.cantidad,
					precioUnitario = det.precioUnitario,
					descuento = det.descuento,
					precioTotalSinImpuesto = det.precioTotalSinImpuesto,
					impuestos = det.impuestos.Select(imp => new
					{
						codigo = imp.codigo,
						codigoPorcentaje = imp.codigoPorcentaje,
						tarifa = imp.tarifa,
						baseImponible = imp.baseImponible,
						valor = imp.valor
					}).ToList()
				}).ToList()
			};

			var logifactPayload = new
			{
				tipo = "factura",
				identificador = rucEmisor,
				ruc = rucEmisor,
				data = logifactData
			};

			var cookieContainer = new CookieContainer();
			using (var client = await GetBypassedClientAsync(cookieContainer))
			{
				string token = await LoginLogifactAsync(client, DefaultUsername, DefaultPassword);
				if (string.IsNullOrEmpty(token))
				{
					throw new Exception("No se pudo autenticar con la API de Logifact (Nexusfact)");
				}

				string jsonPayload = JsonConvert.SerializeObject(logifactPayload);
				using (var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json"))
				{
					client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
					client.DefaultRequestHeaders.Add("X-Identificador", rucEmisor);
					client.DefaultRequestHeaders.Add("Identificador", rucEmisor);

					string postUrl = LogifactApiUrl + "?identificador=" + Uri.EscapeDataString(rucEmisor);
					var response = await client.PostAsync(postUrl, content);
					string responseBody = await response.Content.ReadAsStringAsync();

					if (!response.IsSuccessStatusCode)
					{
						throw new Exception($"Error en servidor Logifact HTTP {(int)response.StatusCode}: {responseBody}");
					}

					var resJson = JsonConvert.DeserializeObject<dynamic>(responseBody);
					if (resJson == null) throw new Exception("Respuesta vacía o inválida de la API Logifact.");

					string sriEstado = GetStatusFromLogifactResponse(resJson);
					bool isAuthorized = (sriEstado == "AUTORIZADO" || sriEstado == "AUTORIZADA");

					string auth = (string)(resJson.numeroAutorizacion ?? resJson.autorizacion?.numeroAutorizacion ?? resJson.autorizacion?.autorizacion);
					string claveRes = (string)(resJson.claveAcceso ?? resJson.autorizacion?.claveAcceso ?? resJson.recepcion?.claveAcceso);

					string errorMsg = (string)(resJson.error ?? resJson.mensaje ?? resJson.message);

					if (!isAuthorized && sriEstado != "PROCESANDO" && sriEstado != "RECIBIDA")
					{
						if (string.IsNullOrEmpty(errorMsg) && resJson.mensajes != null)
						{
							errorMsg = JsonConvert.SerializeObject(resJson.mensajes);
						}
						throw new Exception($"El SRI rechazó o devolvió el documento. Estado: {sriEstado}. Detalle: {errorMsg ?? "Sin error especificado"}");
					}

					return new RespuestaFacturaApi
					{
						claveAcceso = claveRes ?? auth,
						numeroAutorizacion = auth ?? claveRes,
						estadoFinal = sriEstado,
						fechaAutorizacion = (string)(resJson.autorizacion?.fechaAutorizacion ?? resJson.fechaAutorizacion ?? DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")),
						comprobanteXml = (string)(resJson.comprobanteXml ?? resJson.comprobante ?? resJson.xmlAutorizado ?? resJson.xml),
						mensajes = resJson.mensajes
					};
				}
			}
		}

		public async Task<RespuestaFacturaApi> AnularFacturaApiAsync(AnularFacturaRequest request)
		{
			if (request == null) throw new ArgumentNullException(nameof(request));

			EEmpresa empresa = new DEmpresa().ObtenerDatosEmpresa();
			if (empresa == null) throw new Exception("No se pudo obtener la configuración de la empresa.");

			string rucEmisor = (empresa.Ruc ?? "").Trim();
			string certPath = (empresa.CertificadoP12Path ?? "").Trim();
			string certPass = (empresa.CertificadoPassword ?? "").Trim();
			int ambienteSRI = GetAmbienteSRI(empresa.AmbienteSRI);

			var logifactData = new
			{
				fechaEmision = DateTime.Now.ToString("dd/MM/yyyy"),
				dirEstablecimiento = (empresa.DireccionMatriz ?? "Av. Principal").Trim(),
				tipoIdentificacionComprador = (request.data.identificacionComprador == "9999999999999" || request.data.identificacionComprador == "9999999999")
					? "07"
					: (request.data.identificacionComprador.Length == 13 ? "04" : (request.data.identificacionComprador.Length == 10 ? "05" : "06")),
				razonSocialComprador = request.data.razonSocialComprador,
				identificacionComprador = request.data.identificacionComprador,
				codDocModificado = "01",
				numDocModificado = request.data.numDocModificado,
				fechaEmisionDocSustento = DateTime.Now.ToString("dd/MM/yyyy"),
				totalSinImpuestos = request.data.totalSinImpuestos,
				valorModificacion = request.data.valorModificacion,
				motivo = request.data.motivo,
				moneda = "DOLAR",
				impuestos = request.data.impuestos.Select(imp => new
				{
					codigo = imp.codigo,
					codigoPorcentaje = imp.codigoPorcentaje,
					baseImponible = imp.baseImponible,
					valor = imp.valor
				}).ToList(),
				detalles = request.data.detalles.Select(det => new
				{
					codigoInterno = det.codigoPrincipal,
					descripcion = det.descripcion,
					cantidad = det.cantidad,
					precioUnitario = det.precioUnitario,
					descuento = det.descuento,
					precioTotalSinImpuesto = det.precioTotalSinImpuesto,
					impuestos = det.impuestos.Select(imp => new
					{
						codigo = imp.codigo,
						codigoPorcentaje = imp.codigoPorcentaje,
						tarifa = imp.tarifa,
						baseImponible = imp.baseImponible,
						valor = imp.valor
					}).ToList()
				}).ToList(),
				infoAdicional = new
				{
					email = "facturacion@nexusfact.com"
				}
			};

			var logifactPayload = new
			{
				tipo = "notaCredito",
				empresa_id = empresa.Id,
				ruc = rucEmisor,
				data = logifactData
			};

			var cookieContainer = new CookieContainer();
			using (var client = await GetBypassedClientAsync(cookieContainer))
			{
				string token = await LoginLogifactAsync(client, DefaultUsername, DefaultPassword);
				if (string.IsNullOrEmpty(token))
				{
					throw new Exception("No se pudo autenticar con la API de Logifact (Nexusfact)");
				}

				string jsonPayload = JsonConvert.SerializeObject(logifactPayload);
				using (var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json"))
				{
					client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
					client.DefaultRequestHeaders.Add("X-Identificador", rucEmisor);
					client.DefaultRequestHeaders.Add("Identificador", rucEmisor);

					string postUrl = LogifactApiUrl + "?identificador=" + Uri.EscapeDataString(rucEmisor);
					var response = await client.PostAsync(postUrl, content);
					string responseBody = await response.Content.ReadAsStringAsync();

					if (!response.IsSuccessStatusCode)
					{
						throw new Exception($"Error en servidor Logifact HTTP {(int)response.StatusCode}: {responseBody}");
					}

					var resJson = JsonConvert.DeserializeObject<dynamic>(responseBody);
					if (resJson == null) throw new Exception("Respuesta vacía o inválida de la API Logifact.");

					string sriEstado = GetStatusFromLogifactResponse(resJson);
					bool isAuthorized = (sriEstado == "AUTORIZADO" || sriEstado == "AUTORIZADA");

					string auth = (string)(resJson.numeroAutorizacion ?? resJson.autorizacion?.numeroAutorizacion ?? resJson.autorizacion?.autorizacion);
					string claveRes = (string)(resJson.claveAcceso ?? resJson.autorizacion?.claveAcceso ?? resJson.recepcion?.claveAcceso);

					string errorMsg = (string)(resJson.error ?? resJson.mensaje ?? resJson.message);

					if (!isAuthorized && sriEstado != "PROCESANDO" && sriEstado != "RECIBIDA")
					{
						if (string.IsNullOrEmpty(errorMsg) && resJson.mensajes != null)
						{
							errorMsg = JsonConvert.SerializeObject(resJson.mensajes);
						}
						throw new Exception($"El SRI rechazó o devolvió el documento de Nota de Crédito. Estado: {sriEstado}. Detalle: {errorMsg ?? "Sin error especificado"}");
					}

					return new RespuestaFacturaApi
					{
						claveAcceso = claveRes ?? auth,
						numeroAutorizacion = auth ?? claveRes,
						estadoFinal = sriEstado,
						fechaAutorizacion = (string)(resJson.autorizacion?.fechaAutorizacion ?? resJson.fechaAutorizacion ?? DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")),
						comprobanteXml = (string)(resJson.comprobanteXml ?? resJson.comprobante ?? resJson.xmlAutorizado ?? resJson.xml),
						mensajes = resJson.mensajes
					};
				}
			}
		}

		public async Task<RespuestaConsultaApi> ConsultarSriApiAsync(string claveAcceso, bool esProduccion)
		{
			if (string.IsNullOrWhiteSpace(claveAcceso))
				throw new ArgumentException("La clave de acceso no puede estar vacía.");

			string queryUrl = LogifactSriUrl + Uri.EscapeDataString(claveAcceso.Trim());

			var cookieContainer = new CookieContainer();
			using (var client = await GetBypassedClientAsync(cookieContainer))
			{
				client.DefaultRequestHeaders.Add("Accept", "application/json, text/javascript, */*; q=0.01");

				var response = await client.GetAsync(queryUrl);
				string responseBody = await response.Content.ReadAsStringAsync();

				bool needsAuth = false;
				if (!response.IsSuccessStatusCode)
				{
					if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
					{
						needsAuth = true;
					}
					else
					{
						throw new Exception($"Error al consultar SRI (HTTP {(int)response.StatusCode}): {responseBody}");
					}
				}

				if (responseBody.IndexOf("<script", StringComparison.OrdinalIgnoreCase) >= 0 && responseBody.IndexOf("slowAES", StringComparison.OrdinalIgnoreCase) >= 0)
				{
					needsAuth = true;
				}

				if (!needsAuth)
				{
					try
					{
						var decoded = JsonConvert.DeserializeObject<dynamic>(responseBody);
						if (decoded != null && decoded.error != null && ((string)decoded.error).IndexOf("token", StringComparison.OrdinalIgnoreCase) >= 0)
						{
							needsAuth = true;
						}
					}
					catch { }
				}

				if (needsAuth)
				{
					string token = await LoginLogifactAsync(client, DefaultUsername, DefaultPassword);
					if (!string.IsNullOrEmpty(token))
					{
						client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

						var authResponse = await client.GetAsync(queryUrl);
						responseBody = await authResponse.Content.ReadAsStringAsync();

						if (!authResponse.IsSuccessStatusCode)
						{
							throw new Exception($"Error al consultar SRI con token (HTTP {(int)authResponse.StatusCode}): {responseBody}");
						}
					}
					else
					{
						throw new Exception("Se requiere autenticación para consultar al SRI pero no se pudo obtener un token.");
					}
				}

				var resJson = JsonConvert.DeserializeObject<dynamic>(responseBody);
				if (resJson == null) throw new Exception("Respuesta de consulta SRI vacía o inválida.");

				string xml = (string)(resJson.comprobanteXml ?? resJson.comprobante ?? resJson.xmlAutorizado ?? resJson.xml);
				string estado = (string)resJson.estado;
				string authNum = (string)(resJson.numeroAutorizacion ?? resJson.autorizacion);
				string fechaAuth = (string)resJson.fechaAutorizacion;

				return new RespuestaConsultaApi
				{
					ClaveAcceso = (string)(resJson.claveAcceso) ?? claveAcceso,
					Estado = estado ?? "INCOMPLETO",
					NumeroAutorizacion = authNum ?? ((estado == "AUTORIZADO" || estado == "AUTORIZADA") ? claveAcceso : ""),
					FechaAutorizacion = fechaAuth ?? DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
					XmlAutorizado = xml,
					ComprobanteXml = xml,
					Mensajes = resJson.mensajes ?? resJson.error
				};
			}
		}

        // Método para listar las facturas desde tu base de datos
        public DataTable ListarFacturas(DateTime fechaInicio, DateTime fechaFin, string textoBusqueda, 
            int? idCaja = null, string tipoDocumento = null, string estado = null, 
            string estadoSRI = null, int? idCajero = null)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                string sql = @"
                SELECT 
                    fv.id AS Id,
                    fv.numeroFactura AS Factura,
                    fv.numeroAutorizacion AS Autorizacion,
                    COALESCE(NULLIF(c.razonSocial,''), TRIM(CONCAT(IFNULL(c.nombres,''),' ',IFNULL(c.apellidos,'')))) AS Cliente,
                    fv.total AS Total,
                    fv.estado AS Estado,
                    fv.numeroAutorizacion AS ClaveAcceso
                FROM facturas_venta fv
                JOIN clientes c ON fv.idCliente = c.id
                LEFT JOIN cierres_caja cc ON fv.idCierreCaja = cc.id
                WHERE 
                    DATE(fv.fechaEmision) BETWEEN @fechaInicio AND @fechaFin
                    AND (COALESCE(c.razonSocial, CONCAT(c.nombres, ' ', c.apellidos)) LIKE @busqueda 
                         OR fv.numeroFactura LIKE @busqueda 
                         OR fv.numeroAutorizacion LIKE @busqueda)";

                // Filtro por Caja
                if (idCaja.HasValue && idCaja.Value > 0)
                    sql += " AND cc.idCaja = @idCaja";

                // Filtro por Estado
                if (!string.IsNullOrWhiteSpace(estado) && estado != "TODOS")
                    sql += " AND fv.estado = @estado";

                // Filtro por Estado SRI
                if (!string.IsNullOrWhiteSpace(estadoSRI) && estadoSRI != "TODOS")
                {
                    if (estadoSRI == "AUTORIZADO")
                        sql += " AND fv.numeroAutorizacion IS NOT NULL AND fv.numeroAutorizacion != ''";
                    else if (estadoSRI == "SIN AUTORIZAR")
                        sql += " AND (fv.numeroAutorizacion IS NULL OR fv.numeroAutorizacion = '')";
                }

                // Filtro por Cajero
                if (idCajero.HasValue && idCajero.Value > 0)
                    sql += " AND fv.idUsuario = @idCajero";

                sql += " ORDER BY fv.fechaEmision DESC;";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio.Date);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin.Date);
                    cmd.Parameters.AddWithValue("@busqueda", $"%{textoBusqueda}%");

                    if (idCaja.HasValue && idCaja.Value > 0)
                        cmd.Parameters.AddWithValue("@idCaja", idCaja.Value);

                    if (!string.IsNullOrWhiteSpace(estado) && estado != "TODOS")
                        cmd.Parameters.AddWithValue("@estado", estado);

                    if (idCajero.HasValue && idCajero.Value > 0)
                        cmd.Parameters.AddWithValue("@idCajero", idCajero.Value);

                    var dt = new DataTable();
                    new MySqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }

        public (DataRow Encabezado, DataTable Detalle) ObtenerFacturaDesdeDb(int idFactura)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                cn.Open();

                // ===== ENCABEZADO =====
                var sqlHeader = @"
                SELECT 
                    fv.id,
                    fv.numeroFactura                  AS NumeroDocumento,
                    fv.fechaEmision                  AS FechaEmision,
                    fv.estado                        AS EstadoVenta,
                    fv.numeroAutorizacion            AS Autorizacion,      -- si es NULL => sin autorización SRI
                    fv.subtotal                      AS SubtotalFactura,
                    fv.descuento                     AS DescuentoFactura,
                    fv.iva                            AS IvaFactura,
                    fv.total                          AS TotalFactura,

                    c.cedula_ruc                     AS Identificacion,
                    COALESCE(NULLIF(c.razonSocial,''), TRIM(CONCAT(IFNULL(c.nombres,''),' ',IFNULL(c.apellidos,'')))) AS RazonSocial,
                    c.direccion                      AS Direccion,
                    COALESCE(NULLIF(c.telefono,''), c.celular)              AS Telefono
                FROM facturas_venta fv
                JOIN clientes c ON c.id = fv.idCliente
                WHERE fv.id = @id;";

                var dtHeader = new DataTable();
                using (var da = new MySqlDataAdapter(sqlHeader, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@id", idFactura);
                    da.Fill(dtHeader);
                }

                // ===== DETALLE =====
                var sqlDetalle = @"
                SELECT 
                    p.codigoPrincipal  AS Codigo,
                    p.nombre           AS Descripcion,
                    d.cantidad         AS Cantidad,
                    d.precioUnitario   AS PrecioUnitario,
                    d.descuentoValor   AS Descuento,
                    d.ivaValor         AS Iva,
                    (d.total - d.ivaValor) AS Subtotal   -- subtotal sin IVA
                FROM facturas_venta_detalle d
                JOIN productos p ON p.id = d.idProducto
                WHERE d.idFacturaVenta = @id;";

                var dtDet = new DataTable();
                using (var da2 = new MySqlDataAdapter(sqlDetalle, cn))
                {
                    da2.SelectCommand.Parameters.AddWithValue("@id", idFactura);
                    da2.Fill(dtDet);
                }

                return (dtHeader.Rows.Count > 0 ? dtHeader.Rows[0] : null, dtDet);
            }
        }

        public DataTable BuscarFacturasPorNumero(string termino)
        {
            if (termino == null) termino = string.Empty;
            var like = $"%{termino}%";
            var soloDigitos = new string(termino.Where(char.IsDigit).ToArray());
            var likeDigits = $"%{soloDigitos}%";

            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                string sql = @"
                SELECT 
                    fv.id AS Id,
                    fv.numeroFactura AS Factura,
                    fv.numeroAutorizacion AS Autorizacion,
                    c.nombres AS Cliente,
                    fv.total AS Total,
                    fv.estado AS Estado,
                    fv.numeroAutorizacion AS ClaveAcceso
                FROM facturas_venta fv
                JOIN clientes c ON fv.idCliente = c.id
                WHERE 
                    -- Coincidencia directa o por fragmento
                    fv.numeroFactura LIKE @like
                    OR fv.numeroAutorizacion LIKE @like
                    -- Coincidencia por últimos dígitos ignorando guiones
                    OR REPLACE(fv.numeroFactura, '-', '') LIKE @likeDigits
                ORDER BY fv.fechaEmision DESC;";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@like", like);
                    cmd.Parameters.AddWithValue("@likeDigits", likeDigits);

                    var dt = new DataTable();
                    new MySqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }

        // Obtiene encabezado y detalle por número de factura (o sus últimos dígitos)
        public (DataRow Encabezado, DataTable Detalle) ObtenerFacturaPorNumero(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
            {
                return (null, new DataTable());
            }

            var like = $"%{termino}%";
            var soloDigitos = new string(termino.Where(char.IsDigit).ToArray());
            var likeDigits = $"%{soloDigitos}%";

            int? idFactura = null;

            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                cn.Open();

                string sqlId = @"
                SELECT fv.id
                FROM facturas_venta fv
                WHERE 
                    fv.numeroFactura = @exact
                    OR REPLACE(fv.numeroFactura, '-', '') = REPLACE(@exact, '-', '')
                    OR fv.numeroFactura LIKE @like
                    OR REPLACE(fv.numeroFactura, '-', '') LIKE @likeDigits
                ORDER BY fv.fechaEmision DESC
                LIMIT 1;";

                using (var cmd = new MySqlCommand(sqlId, cn))
                {
                    cmd.Parameters.AddWithValue("@exact", termino);
                    cmd.Parameters.AddWithValue("@like", like);
                    cmd.Parameters.AddWithValue("@likeDigits", likeDigits);

                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        idFactura = Convert.ToInt32(result);
                    }
                }
            }

            if (idFactura.HasValue)
            {
                return ObtenerFacturaDesdeDb(idFactura.Value);
            }

            return (null, new DataTable());
        }

        // ✨ NUEVO MÉTODO: Llama a tu API para obtener el detalle de una factura
        public async Task<RespuestaConsultaApi> ObtenerDetalleDesdeApi(string claveAcceso)
        {
            if (string.IsNullOrEmpty(claveAcceso))
            {
                throw new ArgumentException("La clave de acceso no puede estar vacía.");
            }

			bool esProd = false;
			try
			{
				var empresa = new DEmpresa().ObtenerDatosEmpresa();
				esProd = ResolverEsProduccion(empresa?.AmbienteSRI);
			}
			catch { }

			return await ConsultarSriApiAsync(claveAcceso, esProd);
        }

        // Devuelve el último número de factura (más reciente por fechaEmision)
        public string ObtenerUltimoNumeroFactura()
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                cn.Open();
                const string sql = @"SELECT numeroFactura FROM facturas_venta ORDER BY fechaEmision DESC LIMIT 1;";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    var obj = cmd.ExecuteScalar();
                    return obj == null || obj == DBNull.Value ? null : Convert.ToString(obj);
                }
            }
        }

        // Obtener lista de cajas para el filtro
        public DataTable ObtenerCajas()
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                string sql = @"
                    SELECT id, nombre, codigo 
                    FROM cajas 
                    WHERE activa = 1 
                    ORDER BY nombre;";
                
                var dt = new DataTable();
                using (var da = new MySqlDataAdapter(sql, cn))
                {
                    da.Fill(dt);
                }
                
                // Agregar opción "TODAS"
                var row = dt.NewRow();
                row["id"] = 0;
                row["nombre"] = "TODAS";
                row["codigo"] = "";
                dt.Rows.InsertAt(row, 0);
                
                return dt;
            }
        }

        // Obtener lista de cajeros (usuarios) para el filtro
        public DataTable ObtenerCajeros()
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                string sql = @"
                    SELECT DISTINCT u.id, u.nombreUsuario 
                    FROM usuarios u
                    INNER JOIN facturas_venta fv ON fv.idUsuario = u.id
                    WHERE u.anulado = 0
                    ORDER BY u.nombreUsuario;";
                
                var dt = new DataTable();
                using (var da = new MySqlDataAdapter(sql, cn))
                {
                    da.Fill(dt);
                }
                
                // Agregar opción "TODOS"
                var row = dt.NewRow();
                row["id"] = 0;
                row["nombreUsuario"] = "TODOS";
                dt.Rows.InsertAt(row, 0);
                
                return dt;
            }
        }

		public async Task<RespuestaReenvioApi> ReenviarFacturaAlSri(string claveAcceso)
		{
			if (string.IsNullOrEmpty(claveAcceso))
			{
				throw new ArgumentException("La clave de acceso no puede estar vacía.");
			}

			try
			{
				EEmpresa empresa = new DEmpresa().ObtenerDatosEmpresa();
				bool esProd = empresa != null && (empresa.AmbienteSRI == "2" || empresa.AmbienteSRI == "Producción");

				var consulta = await ConsultarSriApiAsync(claveAcceso, esProd);

				return new RespuestaReenvioApi
				{
					Estado = consulta.Estado,
					NumeroAutorizacion = consulta.NumeroAutorizacion,
					FechaAutorizacion = consulta.FechaAutorizacion,
					ClaveAcceso = consulta.ClaveAcceso,
					Mensajes = consulta.Mensajes,
					Mensaje = consulta.Estado == "AUTORIZADO" || consulta.Estado == "AUTORIZADA" ? "Sincronizado con éxito" : "Consultado con éxito"
				};
			}
			catch (Exception ex)
			{
				throw new Exception($"Error al sincronizar/reenviar factura con el SRI: {ex.Message}");
			}
		}

		public async Task<RespuestaFacturaApi> EnviarNotaCreditoApiAsync(NotaCreditoPayload payload)
		{
			if (payload == null) throw new ArgumentNullException(nameof(payload));

			EEmpresa empresa = new DEmpresa().ObtenerDatosEmpresa();
			if (empresa == null) throw new Exception("No se pudo obtener la configuración de la empresa.");

			string rucEmisor = (empresa.Ruc ?? "").Trim();
			string certPath = (empresa.CertificadoP12Path ?? "").Trim();
			string certPass = (empresa.CertificadoPassword ?? "").Trim();
			int ambienteSRI = GetAmbienteSRI(empresa.AmbienteSRI);

			var logifactData = new
			{
				fechaEmision = payload.infoNotaCredito.fechaEmision,
				dirEstablecimiento = (empresa.DireccionMatriz ?? "Av. Principal").Trim(),
				tipoIdentificacionComprador = payload.infoNotaCredito.tipoIdentificacionComprador,
				razonSocialComprador = payload.infoNotaCredito.razonSocialComprador,
				identificacionComprador = payload.infoNotaCredito.identificacionComprador,
				codDocModificado = payload.infoNotaCredito.codDocModificado,
				numDocModificado = payload.infoNotaCredito.numDocModificado,
				fechaEmisionDocSustento = payload.infoNotaCredito.fechaEmisionDocSustento,
				totalSinImpuestos = payload.infoNotaCredito.totalSinImpuestos,
				valorModificacion = payload.infoNotaCredito.valorModificacion,
				motivo = payload.infoNotaCredito.motivo,
				moneda = "DOLAR",
				impuestos = payload.infoNotaCredito.totalConImpuestos.Select(imp => new
				{
					codigo = imp.codigo,
					codigoPorcentaje = imp.codigoPorcentaje,
					baseImponible = imp.baseImponible,
					valor = imp.valor
				}).ToList(),
				detalles = payload.detalles.Select(det => new
				{
					codigoInterno = det.codigoInterno,
					descripcion = det.descripcion,
					cantidad = det.cantidad,
					precioUnitario = det.precioUnitario,
					descuento = det.descuento,
					precioTotalSinImpuesto = det.precioTotalSinImpuesto,
					impuestos = det.impuestos.Select(imp => new
					{
						codigo = imp.codigo,
						codigoPorcentaje = imp.codigoPorcentaje,
						tarifa = imp.tarifa,
						baseImponible = imp.baseImponible,
						valor = imp.valor
					}).ToList()
				}).ToList(),
				infoAdicional = new
				{
					email = "facturacion@nexusfact.com"
				}
			};

			var logifactPayload = new
			{
				tipo = "notaCredito",
				empresa_id = empresa.Id,
				ruc = rucEmisor,
				data = logifactData
			};

			var cookieContainer = new CookieContainer();
			using (var client = await GetBypassedClientAsync(cookieContainer))
			{
				string token = await LoginLogifactAsync(client, DefaultUsername, DefaultPassword);
				if (string.IsNullOrEmpty(token))
				{
					throw new Exception("No se pudo autenticar con la API de Logifact (Nexusfact)");
				}

				string jsonPayload = JsonConvert.SerializeObject(logifactPayload);
				using (var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json"))
				{
					client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
					client.DefaultRequestHeaders.Add("X-Identificador", rucEmisor);
					client.DefaultRequestHeaders.Add("Identificador", rucEmisor);

					string postUrl = LogifactApiUrl + "?identificador=" + Uri.EscapeDataString(rucEmisor);
					var response = await client.PostAsync(postUrl, content);
					string responseBody = await response.Content.ReadAsStringAsync();

					if (!response.IsSuccessStatusCode)
					{
						throw new Exception($"Error en servidor Logifact HTTP {(int)response.StatusCode}: {responseBody}");
					}

					var resJson = JsonConvert.DeserializeObject<dynamic>(responseBody);
					if (resJson == null) throw new Exception("Respuesta vacía o inválida de la API Logifact.");

					string sriEstado = GetStatusFromLogifactResponse(resJson);
					bool isAuthorized = (sriEstado == "AUTORIZADO" || sriEstado == "AUTORIZADA");

					string auth = (string)(resJson.numeroAutorizacion ?? resJson.autorizacion?.numeroAutorizacion ?? resJson.autorizacion?.autorizacion);
					string claveRes = (string)(resJson.claveAcceso ?? resJson.autorizacion?.claveAcceso ?? resJson.recepcion?.claveAcceso);

					string errorMsg = (string)(resJson.error ?? resJson.mensaje ?? resJson.message);

					if (!isAuthorized && sriEstado != "PROCESANDO" && sriEstado != "RECIBIDA")
					{
						if (string.IsNullOrEmpty(errorMsg) && resJson.mensajes != null)
						{
							errorMsg = JsonConvert.SerializeObject(resJson.mensajes);
						}
						throw new Exception($"El SRI rechazó o devolvió el documento de Nota de Crédito. Estado: {sriEstado}. Detalle: {errorMsg ?? "Sin error especificado"}");
					}

					return new RespuestaFacturaApi
					{
						claveAcceso = claveRes ?? auth,
						numeroAutorizacion = auth ?? claveRes,
						estadoFinal = sriEstado,
						fechaAutorizacion = (string)(resJson.autorizacion?.fechaAutorizacion ?? resJson.fechaAutorizacion ?? DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")),
						comprobanteXml = (string)(resJson.comprobanteXml ?? resJson.comprobante ?? resJson.xmlAutorizado ?? resJson.xml),
						mensajes = resJson.mensajes
					};
				}
			}
		}
	}
}