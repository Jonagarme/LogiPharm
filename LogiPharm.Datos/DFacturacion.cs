using CapaDatos;
using LogiPharm.Entidades;
using MySqlConnector;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LogiPharm.Datos
{
    public class DFacturacion
    {
        // Método para listar las facturas desde tu base de datos
        public DataTable ListarFacturas(DateTime fechaInicio, DateTime fechaFin, string textoBusqueda)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                string sql = @"
                SELECT 
                    fv.id AS Id,
                    fv.numeroFactura AS Factura,         -- << AÑADIDO
                    fv.numeroAutorizacion AS Autorizacion,
                    c.nombres AS Cliente,
                    fv.total AS Total,
                    fv.estado AS Estado,
                    fv.numeroAutorizacion AS ClaveAcceso
                FROM facturas_venta fv
                JOIN clientes c ON fv.idCliente = c.id
                WHERE 
                    DATE(fv.fechaEmision) BETWEEN @fechaInicio AND @fechaFin
                    AND (c.nombres LIKE @busqueda 
                         OR fv.numeroFactura LIKE @busqueda 
                         OR fv.numeroAutorizacion LIKE @busqueda)
                ORDER BY fv.fechaEmision DESC;";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio.Date);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin.Date);
                    cmd.Parameters.AddWithValue("@busqueda", $"%{textoBusqueda}%");

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

            string apiUrl = $"http://127.0.0.1:5001/api/consulta_sri/{claveAcceso}";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(apiUrl);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al consultar la API: {response.ReasonPhrase}\n{jsonResponse}");
                }

                return JsonConvert.DeserializeObject<RespuestaConsultaApi>(jsonResponse);
            }
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
    }
}