using System;
using System.Data;
using System.Windows.Forms;
using LogiPharm.Datos;
using System.Xml.Linq;
using System.Linq;
using LogiPharm.Entidades;
using System.Globalization;
using System.Drawing;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmFacturacion : Form
    {
        private bool _cargandoDetalle = false;
        private bool mantenerEstado = false;

        public FrmFacturacion()
        {
            InitializeComponent();
            this.Load += FrmFacturacion_Load;
            this.btnBuscar.Click += btnBuscar_Click;
            this.dgvListaFacturas.SelectionChanged += dgvListaFacturas_SelectionChanged;
            this.btnReenviarSRI.Click += btnReenviarSRI_Click;
        }

        private void FrmFacturacion_Load(object sender, EventArgs e)
        {
            // Auditoría: VISUALIZAR
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Facturación", "VISUALIZAR", "facturas", null, "Abrir pantalla de facturación", null, Environment.MachineName, "UI"); } catch { }

            // Configura las columnas del grid principal antes de cargar datos
            ConfigurarGridPrincipal();
            ConfigurarGridDetalle();

            // Cargar los filtros con datos reales
            CargarFiltros();

            // Establece las fechas por defecto y realiza la primera búsqueda
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;
            btnBuscar_Click(sender, e);
        }

        private void CargarFiltros()
        {
            try
            {
                var d = new DFacturacion();

                // Cargar Cajas
                var dtCajas = d.ObtenerCajas();
                cboCaja.DataSource = dtCajas;
                cboCaja.DisplayMember = "nombre";
                cboCaja.ValueMember = "id";
                cboCaja.SelectedIndex = 0; // Seleccionar "TODAS"

                // Cargar Tipos de Documento
                cboTipoDocumento.Items.Clear();
                cboTipoDocumento.Items.AddRange(new object[] { 
                    "TODOS",
                    "FACTURA", 
                    "NOTA DE VENTA",
                    "NOTA DE CRÉDITO"
                });
                cboTipoDocumento.SelectedIndex = 0; // "TODOS"

                // Cargar Estados de Factura
                cboEstado.Items.Clear();
                cboEstado.Items.AddRange(new object[] { 
                    "TODOS",
                    "ACTIVO", 
                    "ANULADO"
                });
                cboEstado.SelectedIndex = 0; // "TODOS"

                // Cargar Estados SRI
                cboEstadoSRI.Items.Clear();
                cboEstadoSRI.Items.AddRange(new object[] { 
                    "TODOS",
                    "AUTORIZADO", 
                    "SIN AUTORIZAR",
                    "ERROR",
                    "RECHAZADO"
                });
                cboEstadoSRI.SelectedIndex = 0; // "TODOS"

                // Cargar Cajeros
                var dtCajeros = d.ObtenerCajeros();
                cboCajero.DataSource = dtCajeros;
                cboCajero.DisplayMember = "nombreUsuario";
                cboCajero.ValueMember = "id";
                cboCajero.SelectedIndex = 0; // Seleccionar "TODOS"
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar filtros: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGridPrincipal()
        {
            // Muy importante para usar SOLO las columnas del diseñador
            dgvListaFacturas.AutoGenerateColumns = false;

            // Ocultar columnas internas
            if (dgvListaFacturas.Columns["Id"] != null)
                dgvListaFacturas.Columns["Id"].Visible = false;
            if (dgvListaFacturas.Columns["ClaveAcceso"] != null)
                dgvListaFacturas.Columns["ClaveAcceso"].Visible = false;

            SetDP("Id", "Id");
            SetDP("colFactura", "Factura"); 
            SetDP("colCliente", "Cliente");
            SetDP("colTotal", "Total");
            SetDP("colEstado", "Estado");
            SetDP("colAutorizacion", "Autorizacion");

            // Aplicar formato de moneda a la columna Total
            if (dgvListaFacturas.Columns["colTotal"] != null)
            {
                dgvListaFacturas.Columns["colTotal"].DefaultCellStyle.Format = "C2";
                dgvListaFacturas.Columns["colTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Mejorar apariencia visual del grid
            dgvListaFacturas.EnableHeadersVisualStyles = false;
            dgvListaFacturas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgvListaFacturas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvListaFacturas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvListaFacturas.RowTemplate.Height = 28;
            dgvListaFacturas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 250);
            dgvListaFacturas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dgvListaFacturas.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void SetDP(string columnName, string propertyName)
        {
            var col = dgvListaFacturas.Columns[columnName];
            if (col != null) col.DataPropertyName = propertyName;
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var d = new DFacturacion();
                dgvListaFacturas.AutoGenerateColumns = false;

                // Obtener valores de los filtros
                int? idCaja = cboCaja.SelectedValue != null && Convert.ToInt32(cboCaja.SelectedValue) > 0 
                    ? Convert.ToInt32(cboCaja.SelectedValue) 
                    : (int?)null;

                string tipoDocumento = cboTipoDocumento.SelectedItem?.ToString();
                string estado = cboEstado.SelectedItem?.ToString();
                string estadoSRI = cboEstadoSRI.SelectedItem?.ToString();

                int? idCajero = cboCajero.SelectedValue != null && Convert.ToInt32(cboCajero.SelectedValue) > 0 
                    ? Convert.ToInt32(cboCajero.SelectedValue) 
                    : (int?)null;

                // Realizar la búsqueda con todos los filtros
                dgvListaFacturas.DataSource = d.ListarFacturas(
                    dtpFechaInicio.Value, 
                    dtpFechaFin.Value, 
                    txtCliente.Text,
                    idCaja,
                    tipoDocumento,
                    estado,
                    estadoSRI,
                    idCajero
                );

                lblTotalDocumentos.Text = $"Total de Documentos: {dgvListaFacturas.RowCount}";

                // Auditoría: VISUALIZAR (consulta)
                try { 
                    new DBitacora().Registrar(
                        SesionActual.IdUsuario, 
                        SesionActual.NombreUsuario, 
                        "Facturación", 
                        "VISUALIZAR", 
                        "facturas", 
                        null, 
                        $"Consultar facturas {dtpFechaInicio.Value:yyyy-MM-dd} a {dtpFechaFin.Value:yyyy-MM-dd} - Filtros: Caja={cboCaja.Text}, Estado={estado}, EstadoSRI={estadoSRI}, Cajero={cboCajero.Text}, Cliente='{txtCliente.Text}'", 
                        null, 
                        Environment.MachineName, 
                        "UI"
                    ); 
                } catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void dgvListaFacturas_SelectionChanged(object sender, EventArgs e)
        {
            if (_cargandoDetalle) return;
            if (dgvListaFacturas.CurrentRow == null)
            {
                LimpiarDetalle();
                btnReenviarSRI.Enabled = false;
                return;
            }

            var drv = dgvListaFacturas.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null)
            {
                LimpiarDetalle();
                btnReenviarSRI.Enabled = false;
                return;
            }

            // Tomamos el Id oculto del listado
            int idFactura = Convert.ToInt32(drv["Id"]);

            try
            {
                _cargandoDetalle = true;
                this.Cursor = Cursors.WaitCursor;

                var d = new DFacturacion();
                var res = d.ObtenerFacturaDesdeDb(idFactura);

                if (res.Encabezado == null)
                {
                    LimpiarDetalle();
                    MostrarEstadoError("ERROR");
                    btnReenviarSRI.Enabled = false;
                    return;
                }

                // ===== Encabezado =====
                lblNumeroFactura.Text = Convert.ToString(res.Encabezado["NumeroDocumento"] ?? "...");
                lblFecha.Text = res.Encabezado["FechaEmision"] is DateTime fe
                                            ? fe.ToString("dd/MM/yyyy")
                                            : Convert.ToString(res.Encabezado["FechaEmision"] ?? "...");
                lblCliente.Text = Convert.ToString(res.Encabezado["RazonSocial"] ?? "...");
                lblCedula.Text = Convert.ToString(res.Encabezado["Identificacion"] ?? "...");
                lblDireccion.Text = Convert.ToString(res.Encabezado["Direccion"] ?? "...");
                lblTelefono.Text = Convert.ToString(res.Encabezado["Telefono"] ?? "...");
                lblAutorizacion.Text = Convert.ToString(res.Encabezado["Autorizacion"] ?? "...");

                // Estado SRI según si tiene o no autorización
                var autorizacion = Convert.ToString(res.Encabezado["Autorizacion"]);
                if (string.IsNullOrWhiteSpace(autorizacion))
                {
                    MostrarEstadoError("SIN AUTORIZAR");
                    btnReenviarSRI.Enabled = true;
                    btnReenviarSRI.Text = "Enviar al SRI";
                }
                else
                {
                    MostrarEstadoAutorizado();
                    btnReenviarSRI.Enabled = false;
                    btnReenviarSRI.Text = "Ya Autorizado";
                }

                // (opcional) otros labels:
                // lblTipoDoc.Text = "FACTURA"; lblAmbiente.Text = "..."; etc.

                // ===== Detalle =====
                // Tus columnas ya están configuradas con estos DataPropertyName:
                // Codigo, Descripcion, Cantidad, PrecioUnitario, Descuento, Iva, Subtotal
                dgvDetalleFactura.AutoGenerateColumns = false;
                dgvDetalleFactura.DataSource = null;
                dgvDetalleFactura.Rows.Clear();
                dgvDetalleFactura.DataSource = res.Detalle;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar detalle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MostrarEstadoError("ERROR");
                btnReenviarSRI.Enabled = false;
                LimpiarDetalle(mantenerEstado: true);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                _cargandoDetalle = false;
            }
        }



        private async void dgvListaFacturas_SelectionChanged1(object sender, EventArgs e)
        {
            if (_cargandoDetalle) return;
            if (dgvListaFacturas.CurrentRow == null)
            {
                LimpiarDetalle();
                return;
            }

            var drv = dgvListaFacturas.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null)
            {
                LimpiarDetalle();
                return;
            }

            // Leemos la CLAVE DE ACCESO desde el resultado del listado
            string claveAcceso = drv.Row.Table.Columns.Contains("ClaveAcceso")
                ? Convert.ToString(drv["ClaveAcceso"])
                : null;

            // Si NO hay claveAcceso -> mostrar ERROR en rojo y salir
            if (string.IsNullOrWhiteSpace(claveAcceso))
            {
                MostrarEstadoError("ERROR");
                dgvDetalleFactura.Rows.Clear();
                return;
            }

            try
            {
                _cargandoDetalle = true;
                this.Cursor = Cursors.WaitCursor;

                var d_Facturacion = new DFacturacion();
                var detalleFactura = await d_Facturacion.ObtenerDetalleDesdeApi(claveAcceso);

                if (detalleFactura != null)
                {
                    // Encabezado
                    lblNumeroFactura.Text = detalleFactura.Resumen?.Emisor?.NumeroDocumento ?? "...";
                    lblFechaAutorizacion.Text = detalleFactura.FechaAutorizacion != null
                                                ? Convert.ToDateTime(detalleFactura.FechaAutorizacion).ToString("g")
                                                : "...";
                    lblCedula.Text = detalleFactura.Resumen?.Comprador?.Identificacion ?? "...";
                    lblCliente.Text = detalleFactura.Resumen?.Comprador?.RazonSocial ?? "...";
                    lblFecha.Text = detalleFactura.Resumen?.FechaEmision ?? "...";
                    lblAutorizacion.Text = detalleFactura.NumeroAutorizacion ?? "...";

                    // Estado SRI de la respuesta
                    var estado = (detalleFactura.Estado ?? "").Trim().ToUpperInvariant();
                    if (estado == "AUTORIZADO")
                        MostrarEstadoAutorizado();
                    else if (string.IsNullOrWhiteSpace(estado) || estado == "ERROR" || estado == "RECHAZADO" || estado == "NO AUTORIZADO" || estado == "DEVUELTA")
                        MostrarEstadoError(string.IsNullOrWhiteSpace(estado) ? "ERROR" : estado);
                    else
                        MostrarEstadoPendiente(estado); // cualquier otro estado

                    // Detalle
                    LlenarDetalleDesdeXML(detalleFactura.ComprobanteXml);
                }
                else
                {
                    LimpiarDetalle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Cargar Detalle desde API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MostrarEstadoError("ERROR");
                LimpiarDetalle(mantenerEstado: true); // ver sobrecarga abajo si quieres
            }
            finally
            {
                this.Cursor = Cursors.Default;
                _cargandoDetalle = false;
            }
        }


        private void ConfigurarGridDetalle()
        {
            dgvDetalleFactura.AutoGenerateColumns = false;
            dgvDetalleFactura.DataSource = null; // nos aseguramos de que no esté enlazado
            dgvDetalleFactura.Columns.Clear();

            dgvDetalleFactura.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Codigo",
                HeaderText = "Código",
                Width = 110,
                DataPropertyName = "Codigo"
            });
            dgvDetalleFactura.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Descripcion",
                HeaderText = "Descripción",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "Descripcion"
            });
            dgvDetalleFactura.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Cantidad",
                HeaderText = "Cant.",
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight },
                DataPropertyName = "Cantidad"
            });
            dgvDetalleFactura.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PrecioUnitario",
                HeaderText = "P. Unit.",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N6", Alignment = DataGridViewContentAlignment.MiddleRight },
                DataPropertyName = "PrecioUnitario"
            });
            dgvDetalleFactura.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Descuento",
                HeaderText = "Desc.",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight },
                DataPropertyName = "Descuento"
            });
            dgvDetalleFactura.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Iva",
                HeaderText = "IVA",
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight },
                DataPropertyName = "Iva"
            });
            dgvDetalleFactura.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Subtotal",
                HeaderText = "Subtotal",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight },
                DataPropertyName = "Subtotal"
            });
        }


        private void LlenarDetalleDesdeXML(string xmlString)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(xmlString))
                    throw new Exception("El comprobante viene vacío.");

                // Asegura que existan columnas
                if (dgvDetalleFactura.Columns.Count == 0)
                    ConfigurarGridDetalle();

                dgvDetalleFactura.DataSource = null; // trabajaremos con Rows.Add
                dgvDetalleFactura.Rows.Clear();

                var doc = XDocument.Parse(xmlString);

                var detalles = doc.Root?
                    .Element("detalles")?
                    .Elements("detalle") ?? Enumerable.Empty<XElement>();

                var ci = CultureInfo.InvariantCulture;

                foreach (var d in detalles)
                {
                    string codigo = d.Element("codigoPrincipal")?.Value ?? "";
                    string desc = d.Element("descripcion")?.Value ?? "";

                    decimal cantidad = ParseDec(d.Element("cantidad")?.Value, ci);
                    decimal precioUnitario = ParseDec(d.Element("precioUnitario")?.Value, ci);
                    decimal descuento = ParseDec(d.Element("descuento")?.Value, ci);
                    decimal subtotalSinImp = ParseDec(d.Element("precioTotalSinImpuesto")?.Value, ci);

                    // IVA: tomamos el primer <impuestos>/<impuesto>/<valor>
                    decimal iva = ParseDec(
                        d.Element("impuestos")?
                         .Elements("impuesto")
                         .FirstOrDefault()?
                         .Element("valor")?.Value, ci);

                    dgvDetalleFactura.Rows.Add(
                        codigo,
                        desc,
                        cantidad,
                        precioUnitario,
                        descuento,
                        iva,
                        subtotalSinImp
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el detalle del XML: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static decimal ParseDec(string s, CultureInfo ci)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0m;
            if (decimal.TryParse(s, NumberStyles.Any, ci, out var n)) return n;
            return 0m;
        }


        private void LimpiarDetalle(bool mantenerEstado = false)
        {
            lblNumeroFactura.Text = "...";
            lblFechaAutorizacion.Text = "...";
            if (!mantenerEstado) MostrarEstadoNeutro(); // si quieres dejar el estado como estaba, pasa true
            lblCedula.Text = "...";
            lblCliente.Text = "...";
            lblFecha.Text = "...";
            lblAutorizacion.Text = "...";
            lblDireccion.Text = "...";
            lblTelefono.Text = "...";
            lblAmbiente.Text = "...";
            lblTipoDoc.Text = "...";
            lblCajeroDetalle.Text = "...";
            lblCajaDetalle.Text = "...";
            dgvDetalleFactura.Rows.Clear();
        }


        // ---- Helpers de estilo del estado SRI ----
        private void SetEstadoSRI(string texto, Color back, Color fore)
        {
            lblEstadoSRI.Text = texto;
            lblEstadoSRI.BackColor = back;
            lblEstadoSRI.ForeColor = fore;
        }

        private void MostrarEstadoAutorizado()
        {
            // mismo estilo que tienes en el diseñador
            SetEstadoSRI("AUTORIZADO",
                Color.FromArgb(200, 247, 200),
                Color.DarkGreen);
        }

        private void MostrarEstadoError(string texto = "ERROR")
        {
            SetEstadoSRI(texto,
                Color.FromArgb(255, 224, 224),   // rojo suave de fondo
                Color.DarkRed);                  // texto rojo
        }

        private void MostrarEstadoPendiente(string texto = "PENDIENTE")
        {
            SetEstadoSRI(texto,
                Color.FromArgb(255, 245, 204),   // amarillo suave
                Color.FromArgb(160, 98, 0));
        }

        private void MostrarEstadoNeutro()
        {
            // cuando limpias o no hay selección
            SetEstadoSRI("...", Color.White, Color.FromArgb(64, 64, 64));
        }

        private async void btnReenviarSRI_Click(object sender, EventArgs e)
        {
            // Validar que haya una fila seleccionada
            if (dgvListaFacturas.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione una factura para reenviar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var drv = dgvListaFacturas.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) return;

            // Verificar si ya está autorizada
            string autorizacionExistente = drv.Row.Table.Columns.Contains("Autorizacion")
                ? Convert.ToString(drv["Autorizacion"])
                : null;

            if (!string.IsNullOrWhiteSpace(autorizacionExistente))
            {
                MessageBox.Show("Esta factura ya está autorizada por el SRI.\n\nNúmero de Autorización: " + autorizacionExistente, 
                    "Factura Ya Autorizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Obtener la clave de acceso (número de autorización)
            string claveAcceso = drv.Row.Table.Columns.Contains("ClaveAcceso")
                ? Convert.ToString(drv["ClaveAcceso"])
                : null;

            if (string.IsNullOrWhiteSpace(claveAcceso))
            {
                MessageBox.Show("Esta factura no tiene clave de acceso. No se puede reenviar al SRI.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmar la acción
            var resultado = MessageBox.Show(
                $"¿Está seguro que desea reenviar esta factura al SRI?\n\nClave de Acceso: {claveAcceso}",
                "Confirmar Reenvío",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes) return;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                btnReenviarSRI.Enabled = false;

                var d = new DFacturacion();
                var respuesta = await d.ReenviarFacturaAlSri(claveAcceso);

                if (respuesta != null)
                {
                    string mensaje = $"Factura reenviada exitosamente al SRI.\n\n";
                    mensaje += $"Estado: {respuesta.Estado ?? "N/A"}\n";
                    mensaje += $"Número de Autorización: {respuesta.NumeroAutorizacion ?? "N/A"}\n";
                    mensaje += $"Fecha de Autorización: {respuesta.FechaAutorizacion ?? "N/A"}";

                    MessageBox.Show(mensaje, "Reenvío Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Actualizar el estado del label si la autorización es exitosa
                    if (!string.IsNullOrWhiteSpace(respuesta.Estado))
                    {
                        var estado = respuesta.Estado.Trim().ToUpperInvariant();
                        if (estado == "AUTORIZADO")
                        {
                            MostrarEstadoAutorizado();
                            btnReenviarSRI.Enabled = false;
                            btnReenviarSRI.Text = "Ya Autorizado";
                            lblAutorizacion.Text = respuesta.NumeroAutorizacion ?? "...";
                        }
                        else if (estado == "ERROR" || estado == "RECHAZADO" || estado == "NO AUTORIZADO")
                        {
                            MostrarEstadoError(estado);
                            btnReenviarSRI.Enabled = true;
                            btnReenviarSRI.Text = "Reintentar Envío";
                        }
                        else
                        {
                            MostrarEstadoPendiente(estado);
                            btnReenviarSRI.Enabled = true;
                            btnReenviarSRI.Text = "Reintentar Envío";
                        }
                    }

                    // Auditoría
                    try
                    {
                        new DBitacora().Registrar(
                            SesionActual.IdUsuario,
                            SesionActual.NombreUsuario,
                            "Facturación",
                            "REENVIAR",
                            "facturas",
                            null,
                            $"Reenvío factura al SRI: {claveAcceso}",
                            null,
                            Environment.MachineName,
                            "UI");
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("No se recibió respuesta del servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al reenviar la factura al SRI:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Auditoría de error
                try
                {
                    new DBitacora().Registrar(
                        SesionActual.IdUsuario,
                        SesionActual.NombreUsuario,
                        "Facturación",
                        "ERROR_REENVIAR",
                        "facturas",
                        null,
                        $"Error al reenviar factura al SRI: {claveAcceso} - {ex.Message}",
                        null,
                        Environment.MachineName,
                        "UI");
                }
                catch { }
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnReenviarSRI.Enabled = true;
            }
        }

    }
}