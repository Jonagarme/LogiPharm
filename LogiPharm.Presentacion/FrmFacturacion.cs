using System;
using System.Data;
using System.Windows.Forms;
using LogiPharm.Datos;
using System.Xml.Linq;
using System.Linq;
using LogiPharm.Entidades;
using System.Globalization;
using System.Drawing;

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
        }

        private void FrmFacturacion_Load(object sender, EventArgs e)
        {
            // Configura las columnas del grid principal antes de cargar datos
            ConfigurarGridPrincipal();
            ConfigurarGridDetalle();

            // Establece las fechas por defecto y realiza la primera búsqueda
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;
            btnBuscar_Click(sender, e);
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
                dgvListaFacturas.DataSource = d.ListarFacturas(dtpFechaInicio.Value, dtpFechaFin.Value, txtCliente.Text);
                lblTotalDocumentos.Text = $"Total de Documentos: {dgvListaFacturas.RowCount}";
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
                return;
            }

            var drv = dgvListaFacturas.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null)
            {
                LimpiarDetalle();
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
                    MostrarEstadoError("ERROR");   // opcional
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
                    MostrarEstadoError("ERROR");           // rojo
                else
                    MostrarEstadoAutorizado();             // verde

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

    }
}