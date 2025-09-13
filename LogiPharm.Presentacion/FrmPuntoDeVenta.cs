using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace LogiPharm.Presentacion
{
    public partial class FrmPuntoDeVenta : Form
    {
        private ECliente _clienteSeleccionado;
        private List<VentaEnEspera> _ventasEnEspera = new List<VentaEnEspera>();
        private VentaEnEspera _ventaActual;


        private int _hoverRow = -1, _hoverCol = -1;
        private const double PanelDerechoPct = 0.32; // 32% del ancho
        private const int PanelDerechoMin = 320;
        private const int PanelDerechoMax = 520;

        public FrmPuntoDeVenta()
        {
            InitializeComponent();
            this.Resize += Frm_Resize_Adaptativo;

            this.dgvDetalleVenta.CellEndEdit += dgvDetalleVenta_CellEndEdit;
            this.dgvDetalleVenta.CellClick += dgvDetalleVenta_CellAccion;
            this.txtIdentificacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdentificacion_KeyDown);
            this.txtIdentificacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdentificacion_KeyPress);
            dgvDetalleVenta.EditingControlShowing += Dgv_EditingControlShowing;
            this.Shown += FrmPuntoDeVenta_Shown;

            // Pintado custom + hover + tooltips
            this.dgvDetalleVenta.CellPainting += dgvDetalleVenta_CellPainting;
            this.dgvDetalleVenta.CellMouseMove += dgvDetalleVenta_CellMouseMove;
            this.dgvDetalleVenta.CellMouseLeave += dgvDetalleVenta_CellMouseLeave;
            this.dgvDetalleVenta.CellToolTipTextNeeded += dgvDetalleVenta_CellToolTipTextNeeded;

            // Evita el “X” rojo cuando la celda no tiene imagen
            colEliminar.DefaultCellStyle.NullValue = null;
            colInfo.DefaultCellStyle.NullValue = null;

            // Ancho fijo para los botones
            colEliminar.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colEliminar.Width = 80; // un poco más ancho para icono + texto
            colEliminar.Resizable = DataGridViewTriState.False;

            colInfo.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colInfo.Width = 72;
            colInfo.Resizable = DataGridViewTriState.False;

            // Altura uniforme de filas (ya lo tienes)
            dgvDetalleVenta.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvDetalleVenta.AllowUserToResizeRows = false;
            dgvDetalleVenta.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvDetalleVenta.RowTemplate.Height = 38;
            dgvDetalleVenta.DataBindingComplete += (s, e) => AjustarAlturas();
            dgvDetalleVenta.RowsAdded += (s, e) => AjustarAlturas();


        }

        private void Frm_Resize_Adaptativo(object sender, EventArgs e)
        {
            int w = (int)Math.Round(ClientSize.Width * PanelDerechoPct);
            panelDerecho.Width = Math.Max(PanelDerechoMin, Math.Min(PanelDerechoMax, w));
        }


        private void AjustarAlturas()
        {
            int h = dgvDetalleVenta.RowTemplate.Height;
            foreach (DataGridViewRow r in dgvDetalleVenta.Rows)
                if (!r.IsNewRow && r.Height != h) r.Height = h;
        }


        private void FrmPuntoDeVenta_Shown(object sender, EventArgs e)
        {
            // Registro de auditoría al abrir POS
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "POS", "VISUALIZAR", "ventas", null, "Abrir Punto de Venta", null, Environment.MachineName, "UI"); } catch { }

            // Nos aseguramos de que haya al menos una fila (la de 'Nueva Fila')
            if (dgvDetalleVenta.Rows.Count > 0)
            {
                // Ponemos la celda "Código" de la primera fila como la celda activa
                dgvDetalleVenta.CurrentCell = dgvDetalleVenta.Rows[0].Cells["colCodigo"];
                // Iniciamos el modo de edición en esa celda
                dgvDetalleVenta.BeginEdit(true);
            }
        }

        private void FrmPuntoDeVenta_Load(object sender, EventArgs e)
        {
            timer1.Start();
            Frm_Resize_Adaptativo(null, EventArgs.Empty);
            CrearNuevaVenta(esLaPrimera: true);

            lblVendedor.Text = SesionActual.NombreUsuario;
            lblCaja.Text = "CAJA 001";
            lblFechaEmision.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Mostrar último número de factura emitida
            try
            {
                var dFac = new DFacturacion();
                var ultimo = dFac.ObtenerUltimoNumeroFactura();
                if (!string.IsNullOrWhiteSpace(ultimo) && this.lblNumeroFactura != null)
                {
                    this.lblNumeroFactura.Text = ultimo;
                }
            }
            catch { }

            //if (dgvDetalleVenta.Rows.Count == 0)
            //    dgvDetalleVenta.Rows.Add();
            dgvDetalleVenta.Columns["colPrecio"].ReadOnly = true;
            dgvDetalleVenta.Select();
        }

        private void CrearNuevaVenta(bool esLaPrimera = false)
        {
            if (!esLaPrimera)
            {
                GuardarVentaActual();
            }

            var nuevaVenta = new VentaEnEspera($"Venta {_ventasEnEspera.Count + 1}");
            _ventasEnEspera.Add(nuevaVenta);
            CargarVenta(nuevaVenta);
        }

        private void GuardarVentaActual()
        {
            if (_ventaActual == null) return;

            // Guardar cliente
            _ventaActual.Cliente = _clienteSeleccionado;

            // Guardar productos de la tabla
            _ventaActual.Productos.Clear();
            foreach (DataGridViewRow row in dgvDetalleVenta.Rows)
            {
                if (row.IsNewRow || row.Cells["colCodigo"].Value == null) continue;

                // Asumiendo que tienes una clase ProductoVenta como la usas en AbrirVentanaPago
                _ventaActual.Productos.Add(new ProductoVenta
                {
                    CodigoPrincipal = row.Cells["colCodigo"].Value.ToString(),
                    Descripcion = row.Cells["colProducto"].Value.ToString(),
                    Cantidad = Convert.ToDecimal(row.Cells["colCantidad"].Value ?? 0),
                    PrecioUnitario = Convert.ToDecimal(row.Cells["colPrecio"].Value ?? 0),
                    Descuento = Convert.ToDecimal(row.Cells["colDscto"].Value ?? 0),
                    PrecioTotalSinImpuesto = Convert.ToDecimal(row.Cells["colSubtotal"].Value ?? 0)
                });
            }
        }

        // ✅ CÓDIGO CORREGIDO
        private void CargarVenta(VentaEnEspera venta)
        {
            if (venta == null) return;

            _ventaActual = venta;
            _clienteSeleccionado = venta.Cliente;

            // Cargar cliente en la UI
            if (_clienteSeleccionado != null)
            {
                txtIdentificacion.Text = _clienteSeleccionado.Identificacion;
                txtCliente.Text = _clienteSeleccionado.RazonSocial;
                txtEmail.Text = _clienteSeleccionado.Email;
            }
            else
            {
                txtIdentificacion.Clear();
                txtCliente.Text = "CONSUMIDOR FINAL";
                txtEmail.Clear();
            }

            // Cargar productos en la tabla
            dgvDetalleVenta.Rows.Clear();
            foreach (var producto in venta.Productos)
            {
                dgvDetalleVenta.Rows.Add(
                    null, // colEliminar
                    producto.CodigoPrincipal,
                    producto.Descripcion,
                    null, // colInfo
                    producto.Cantidad,
                    producto.PrecioUnitario,
                    producto.PrecioUnitario, // PFinal inicial
                    0, // Porcentaje inicial
                    producto.Descuento // Dscto
                );
            }

            // ✨ CORRECCIÓN CLAVE: Recalculamos TODAS las filas después de añadirlas
            foreach (DataGridViewRow row in dgvDetalleVenta.Rows)
            {
                if (row.IsNewRow) continue;
                CalcularTotalesFila(row);
            }

            // El cálculo de totales generales ya es llamado dentro de CalcularTotalesFila,
            // pero una llamada final asegura consistencia.
            CalcularTotalesGenerales();

            ActualizarPestañasDeVenta();
            this.Text = $"Punto de Venta - {_ventaActual.Nombre}";
        }

        private void ActualizarPestañasDeVenta()
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var venta in _ventasEnEspera)
            {
                bool esVentaActiva = (venta == _ventaActual);

                var boton = new Guna.UI2.WinForms.Guna2Button
                {
                    Text = venta.Nombre + (_ventasEnEspera.Count > 1 ? "   ✕" : ""), // Texto con ícono de cierre
                    Tag = venta,
                    Margin = new Padding(2, 2, 0, 0),

                    // --- ✨ NUEVO DISEÑO ---
                    BorderRadius = 8, // Esquinas redondeadas
                    Font = new Font("Segoe UI", 9F, esVentaActiva ? FontStyle.Bold : FontStyle.Regular),
                    TextAlign = HorizontalAlignment.Left,
                    TextOffset = new Point(10, 0),
                    Size = new Size(130, 32), // Tamaño fijo para un look uniforme

                    // Estilo para la pestaña INACTIVA
                    FillColor = Color.FromArgb(242, 245, 250),
                    ForeColor = Color.FromArgb(108, 117, 125),
                    BorderThickness = 0,

                    // Estilo para la pestaña ACTIVA (cuando está seleccionada)
                    CheckedState =
                    {
                        FillColor = Color.White,
                        ForeColor = Color.FromArgb(0, 123, 255),
                    },

                            // Efecto al pasar el mouse
                            HoverState =
                    {
                        FillColor = esVentaActiva ? Color.White : Color.WhiteSmoke
                    },

                    // Borde inferior para simular una pestaña
                    CustomBorderThickness = new Padding(0, 0, 0, esVentaActiva ? 0 : 1), // Sin borde inferior si está activa
                    CustomBorderColor = Color.Gainsboro
                };

                // Hacemos que funcione como un RadioButton para que solo uno esté activo
                boton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                boton.Checked = esVentaActiva;

                boton.Click += (s, e) => {
                    var btnPresionado = s as Guna.UI2.WinForms.Guna2Button;
                    var ventaSeleccionada = btnPresionado.Tag as VentaEnEspera;

                    var mouseArgs = e as MouseEventArgs;
                    int clicX = mouseArgs.Location.X;

                    // Lógica de cierre mejorada: detecta el clic en el 25% final del botón
                    if (_ventasEnEspera.Count > 1 && clicX > btnPresionado.Width * 0.75)
                    {
                        EliminarVenta(ventaSeleccionada);
                    }
                    else
                    {
                        GuardarVentaActual();
                        CargarVenta(ventaSeleccionada);
                    }
                };

                boton.MouseClick += (s, e) => {
                    if (e.Button == MouseButtons.Right)
                    {
                        var btnPresionado = s as Guna.UI2.WinForms.Guna2Button;
                        var ventaSeleccionada = btnPresionado.Tag as VentaEnEspera;

                        // Llamamos directamente a la función de eliminar
                        EliminarVenta(ventaSeleccionada);
                    }
                };

                flowLayoutPanel1.Controls.Add(boton);
            }
        }

        // ✨ NUEVO MÉTODO
        private void EliminarVenta(VentaEnEspera ventaAEliminar)
        {
            // Pedimos confirmación al usuario
            var confirmacion = MessageBox.Show(
                $"¿Estás seguro de que quieres eliminar la '{ventaAEliminar.Nombre}'? Se perderán todos los productos de esta lista.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.No) return;

            // Si solo queda una venta, no la eliminamos, simplemente la limpiamos.
            if (_ventasEnEspera.Count <= 1)
            {
                // Guardamos el estado actual (por si acaso) y luego limpiamos
                GuardarVentaActual();
                _ventaActual.Productos.Clear();
                _ventaActual.Cliente = null;
                _clienteSeleccionado = null;
                CargarVenta(_ventaActual);
                return;
            }

            int indiceEliminar = _ventasEnEspera.IndexOf(ventaAEliminar);
            _ventasEnEspera.Remove(ventaAEliminar);

            // Decidir qué venta cargar a continuación
            if (ventaAEliminar == _ventaActual)
            {
                // Si eliminamos la venta activa, cargamos la anterior o la primera que quede.
                int indiceACargar = Math.Max(0, indiceEliminar - 1);
                CargarVenta(_ventasEnEspera[indiceACargar]);
            }
            else
            {
                // Si eliminamos una venta inactiva, simplemente refrescamos las pestañas.
                ActualizarPestañasDeVenta();
            }
        }

        // Helper para rectángulo redondeado tipo "píldora"
        private static GraphicsPath MakeRoundRect(Rectangle r, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void dgvDetalleVenta_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            bool esEliminar = dgvDetalleVenta.Columns[e.ColumnIndex].Name == "colEliminar";
            bool esInfo = dgvDetalleVenta.Columns[e.ColumnIndex].Name == "colInfo";
            if (!esEliminar && !esInfo) return;

            e.PaintBackground(e.CellBounds, true);

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Botón circular/ovalado centrado
            int pad = 6; // margen dentro de la celda
            int size = Math.Min(e.CellBounds.Height - pad * 2, e.CellBounds.Width - pad * 2);
            int x = e.CellBounds.X + (e.CellBounds.Width - size) / 2;
            int y = e.CellBounds.Y + (e.CellBounds.Height - size) / 2;
            var pill = new Rectangle(x, y, size, size);   // cuadrado -> círculo con radio = size/2

            // Colores + hover
            bool hover = (e.RowIndex == _hoverRow && e.ColumnIndex == _hoverCol);
            Color baseColor = esEliminar ? Color.FromArgb(231, 76, 60) : Color.FromArgb(52, 152, 219);
            Color fill = hover ? ControlPaint.Light(baseColor, 0.15f) : baseColor;
            Color line = ControlPaint.Dark(fill);

            using (var path = MakeRoundRect(pill, size / 2)) // radio = mitad -> círculo
            using (var sb = new SolidBrush(fill))
            using (var pen = new Pen(line, 1))
            {
                g.FillPath(sb, path);
                g.DrawPath(pen, path);
            }

            // Ícono centrado
            Image icon = esEliminar ? Properties.Resources.ic_delete : Properties.Resources.ic_info;
            int iconSize = Math.Max(14, size - 12); // deja un pequeño margen
            var iconRect = new Rectangle(
                pill.X + (pill.Width - iconSize) / 2,
                pill.Y + (pill.Height - iconSize) / 2,
                iconSize,
                iconSize
            );
            g.DrawImage(icon, iconRect);

            e.Handled = true;
        }



        private void dgvDetalleVenta_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var name = dgvDetalleVenta.Columns[e.ColumnIndex].Name;
            bool esIcono = (name == "colEliminar" || name == "colInfo");

            if (esIcono)
            {
                dgvDetalleVenta.Cursor = Cursors.Hand;
                if (e.RowIndex != _hoverRow || e.ColumnIndex != _hoverCol)
                {
                    int prevR = _hoverRow, prevC = _hoverCol;
                    _hoverRow = e.RowIndex; _hoverCol = e.ColumnIndex;
                    if (prevR >= 0 && prevC >= 0) dgvDetalleVenta.InvalidateCell(prevC, prevR);
                    dgvDetalleVenta.InvalidateCell(e.ColumnIndex, e.RowIndex);
                }
            }
            else
            {
                if (_hoverRow != -1 || _hoverCol != -1)
                {
                    int r = _hoverRow, c = _hoverCol;
                    _hoverRow = _hoverCol = -1;
                    if (r >= 0 && c >= 0) dgvDetalleVenta.InvalidateCell(c, r);
                }
                dgvDetalleVenta.Cursor = Cursors.Default;
            }
        }

        private void dgvDetalleVenta_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (_hoverRow != -1 || _hoverCol != -1)
            {
                int r = _hoverRow, c = _hoverCol;
                _hoverRow = _hoverCol = -1;
                if (r >= 0 && c >= 0 && r < dgvDetalleVenta.RowCount && c < dgvDetalleVenta.ColumnCount)
                    dgvDetalleVenta.InvalidateCell(c, r);
            }
            dgvDetalleVenta.Cursor = Cursors.Default;
        }

        private void dgvDetalleVenta_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var name = dgvDetalleVenta.Columns[e.ColumnIndex].Name;
            if (name == "colEliminar") e.ToolTipText = "Eliminar este ítem";
            else if (name == "colInfo") e.ToolTipText = "Ver detalles del producto";
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            AbrirVentanaFactura();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CrearNuevaVenta();
        }

        private void AbrirVentanaFactura()
        {
            using (FrmFacturacion frm = new FrmFacturacion())
            {
                frm.ShowDialog();
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            AbrirVentanaPago();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F3) { AbrirVentanaFactura(); return true; }
            if (keyData == Keys.F4) { AbrirVentanaPago(); return true; }
            if (keyData == Keys.F8) { AbrirVentanaKardex(); return true; }
            if (keyData == Keys.F2 || keyData == (Keys.Shift | Keys.F2))
            {
                CrearNuevaVenta();
                return true;
            }

            if (keyData == (Keys.Control | Keys.Down))
            {
                var cell = dgvDetalleVenta.CurrentCell;
                if (cell != null)
                {
                    string colName = dgvDetalleVenta.Columns[cell.ColumnIndex].Name;
                    if (colName == "colCodigo" || colName == "colProducto")
                    {
                        // Usa "%" para traer todo si tu DAL hace LIKE
                        BuscarYAsignarProducto("%", cell.RowIndex);
                        return true; // consumimos la tecla
                    }
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void btnKardex_Click(object sender, EventArgs e)
        {
            AbrirVentanaKardex();
        }


        private void AbrirVentanaKardex()
        {
            using (FrmKardex frm = new FrmKardex())
            {
                frm.ShowDialog();
            }
        }


        private void AbrirVentanaPago()
        {
            // Validar que haya productos sin tocar Rows[0] si Count = 0
            bool sinProductos =
                dgvDetalleVenta.Rows.Count == 0 ||
                (dgvDetalleVenta.Rows.Count == 1 && dgvDetalleVenta.Rows[0].IsNewRow);

            if (sinProductos)
            {
                MessageBox.Show("No hay productos en la venta para procesar el pago.", "Venta Vacía",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_clienteSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un cliente válido.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var productos = new List<ProductoVenta>();
            foreach (DataGridViewRow row in dgvDetalleVenta.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["colCodigo"].Value == null) continue;

                productos.Add(new ProductoVenta
                {
                    Id = Convert.ToInt32(row.Tag),
                    CodigoPrincipal = Convert.ToString(row.Cells["colCodigo"].Value),
                    Descripcion = Convert.ToString(row.Cells["colProducto"].Value),
                    Cantidad = Convert.ToDecimal(row.Cells["colCantidad"].Value ?? 0),
                    PrecioUnitario = Convert.ToDecimal(row.Cells["colPrecio"].Value ?? 0),
                    Descuento = Convert.ToDecimal(row.Cells["colDscto"].Value ?? 0),
                    PrecioTotalSinImpuesto = Convert.ToDecimal(row.Cells["colSubtotal"].Value ?? 0)
                });
            }

            if (productos.Count == 0)
            {
                MessageBox.Show("No hay líneas válidas para cobrar.", "Venta Vacía",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal totalVenta = CalcularTotalVenta();

            using (var frmPago = new FrmPago(totalVenta, _clienteSeleccionado, productos))
            {
                if (frmPago.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Venta procesada con éxito.", "Confirmación",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Auditoría: CREAR venta
                    try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Ventas", "CREAR", "ventas", null, $"Venta facturada {frmPago.SecuencialUsado}", null, Environment.MachineName, "UI"); } catch { }

                    if (MessageBox.Show("¿Desea imprimir la factura?", "Imprimir",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ImprimirFactura(
                            _clienteSeleccionado,
                            productos,
                            frmPago.EfectivoRecibido,
                            frmPago.SecuencialUsado,
                            frmPago.ClaveAcceso,
                            frmPago.NumeroAutorizacion
                        );

                        // Auditoría: IMPRIMIR
                        try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Ventas", "IMPRIMIR", "ventas", null, $"Imprimir factura {frmPago.SecuencialUsado}", null, Environment.MachineName, "UI"); } catch { }
                    }

                    // LimpiarFormularioVenta(); // si aplica
                }
            }
        }

        private void ImprimirFactura(
             ECliente cliente,
             List<ProductoVenta> productos,
             decimal efectivoRecibido,
             string numeroFactura,
             string claveAcceso,
             string numeroAutorizacion
        )
        {
            try
            {
                // ✅ 1. OBTENER LOS DATOS DE LA EMPRESA
                DEmpresa d_empresa = new DEmpresa();
                EEmpresa empresa = d_empresa.ObtenerDatosEmpresa();

                if (empresa == null)
                {
                    MessageBox.Show("No se pueden imprimir facturas sin los datos de la empresa configurados.", "Error de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dsFactura ds = new dsFactura();
                DataTable dtInfo = ds.Tables["dtFacturaInfo"];
                DataTable dtDetalle = ds.Tables["dtFacturaDetalle"];

                // --- (La lógica para calcular totales y llenar el detalle no cambia) ---
                decimal subtotal = 0m;
                decimal descuentoTotal = 0m;
                decimal IVA_RATE = ImpuestoProvider.GetIVA();

                foreach (var prod in productos)
                {
                    subtotal += prod.PrecioTotalSinImpuesto;
                    descuentoTotal += prod.Descuento;
                    dtDetalle.Rows.Add(
                        prod.Cantidad,
                        prod.Descripcion,
                        prod.PrecioUnitario,
                        prod.PrecioTotalSinImpuesto
                    );
                }

                decimal iva = Math.Round(subtotal * IVA_RATE, 2);
                decimal total = subtotal + iva;
                decimal cambio = Math.Round(efectivoRecibido - total, 2);

                // ✅ 2. LLENAR EL DATATABLE CON LOS DATOS DE LA EMPRESA
                dtInfo.Rows.Add(
                    empresa.NombreComercial,                          // NombreComercial
                    empresa.Ruc,                                      // RucEmpresa
                    empresa.DireccionMatriz,                          // DireccionEmpresa (usamos la matriz como principal)
                    empresa.Telefono,                                 // TelefonoEmpresa
                    numeroFactura,                                    // NumeroFactura
                    numeroAutorizacion,                               // Autorizacion
                    DateTime.Now.ToString("dd/MM/yyyy HH:mm"),        // FechaHora
                    cliente?.RazonSocial ?? "CONSUMIDOR FINAL",       // ClienteNombre
                    cliente?.CedulaRuc ?? "9999999999999",          // ClienteId
                    cliente?.Direccion ?? "S/D",                      // ClienteDireccion
                    subtotal,                                         // Subtotal
                    descuentoTotal,                                   // Descuento
                    iva,                                              // IVA
                    total,                                            // Total
                    "EFECTIVO",                                       // FormaPago
                    efectivoRecibido,                                 // EfectivoRecibido
                    cambio,                                           // Cambio
                    empresa.DireccionMatriz,                          // DireccionMatriz
                    empresa.Telefono,                                 // TelefonoMatriz
                    empresa.DireccionMatriz,                          // DireccionSucursal (o un campo específico si lo tienes)
                    claveAcceso                                       // ClaveAcceso
                );

                using (var frmVisor = new FrmVisorFactura(dtInfo, dtDetalle))
                {
                    frmVisor.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar la factura para imprimir:\n" + ex.Message,
                                "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private decimal CalcularTotalVenta()
        {
            decimal total = 0;
            foreach (DataGridViewRow fila in dgvDetalleVenta.Rows)
            {
                if (fila.Cells["colTotal"].Value != null &&
                    decimal.TryParse(fila.Cells["colTotal"].Value.ToString(), out decimal valor))
                {
                    total += valor;
                }
            }
            return total;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFechaHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFechaCompleta.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy");
        }


        private void dgvDetalleVenta_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                if (e.RowIndex < 0) return;

                var colName = dgvDetalleVenta.Columns[e.ColumnIndex].Name;
                DataGridViewRow fila = dgvDetalleVenta.Rows[e.RowIndex];

                if (colName == "colCodigo" || colName == "colProducto")
                {
                    string textoBuscado = fila.Cells[e.ColumnIndex].Value?.ToString();
                    if (!string.IsNullOrEmpty(textoBuscado))
                    {
                        BuscarYAsignarProducto(textoBuscado, e.RowIndex);
                    }
                }
                else if (colName == "colCantidad" || colName == "colPFinal" || colName == "colDscto")
                {
                    CalcularTotalesFila(fila);
                }
            }));
        }

        private void BuscarYAsignarProducto(string terminoBusqueda, int rowIndex)
        {
            try
            {
                DProductos d_Productos = new DProductos();
                List<EProducto> productos = d_Productos.BuscarProductosActivos(terminoBusqueda);

                if (productos.Count == 1)
                {
                    AsignarDatosAFila(productos[0], rowIndex);
                }
                else if (productos.Count > 1)
                {
                    using (var frm = new FrmSeleccionarProducto(productos))
                    {
                        if (frm.ShowDialog() == DialogResult.OK && frm.ProductoSeleccionado != null)
                        {
                            AsignarDatosAFila(frm.ProductoSeleccionado, rowIndex);
                        }
                        else
                        {
                            LimpiarFila(rowIndex);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Producto no encontrado.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LimpiarFila(rowIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AsignarDatosAFila(EProducto producto, int rowIndex)
        {
            // Lógica para manejar productos duplicados
            for (int i = 0; i < dgvDetalleVenta.Rows.Count; i++)
            {
                if (i == rowIndex || dgvDetalleVenta.Rows[i].IsNewRow) continue;

                var codigoExistente = dgvDetalleVenta.Rows[i].Cells["colCodigo"].Value?.ToString();
                if (codigoExistente == producto.CodigoPrincipal)
                {
                    var celdaCantidad = dgvDetalleVenta.Rows[i].Cells["colCantidad"];
                    decimal.TryParse(celdaCantidad.Value?.ToString(), out decimal cantidadActual);
                    celdaCantidad.Value = cantidadActual + 1;

                    // ❌ Se elimina la línea 'filaActual.Tag' de aquí porque era incorrecta.

                    CalcularTotalesFila(dgvDetalleVenta.Rows[i]);
                    LimpiarFila(rowIndex);
                    PonerFocoEnNuevaFila();
                    return;
                }
            }

            // Si llegamos aquí, el producto es nuevo en la lista.
            DataGridViewRow filaActual = dgvDetalleVenta.Rows[rowIndex];

            dgvDetalleVenta.CellEndEdit -= dgvDetalleVenta_CellEndEdit;

            // ✅ Se añade la línea aquí, que es el lugar correcto para "marcar" la nueva fila.
            filaActual.Tag = producto.Id;

            filaActual.Cells["colCodigo"].Value = producto.CodigoPrincipal;
            filaActual.Cells["colProducto"].Value = producto.Nombre;
            filaActual.Cells["colPrecio"].Value = producto.PrecioVenta;
            filaActual.Cells["colCantidad"].Value = 1;
            filaActual.Cells["colPFinal"].Value = producto.PrecioVenta;
            filaActual.Cells["colDscto"].Value = 0;

            dgvDetalleVenta.CellEndEdit += dgvDetalleVenta_CellEndEdit;

            CalcularTotalesFila(filaActual);
            PonerFocoEnNuevaFila();
        }

        private void PonerFocoEnNuevaFila()
        {
            // ✅ SOLUCIÓN DEFINITIVA: Solo cambiamos la celda activa, sin forzar la edición.
            // Esto es más estable y evita los problemas de foco.
            if (dgvDetalleVenta.AllowUserToAddRows && dgvDetalleVenta.Rows[dgvDetalleVenta.Rows.Count - 1].IsNewRow)
            {
                int newRowIndex = dgvDetalleVenta.Rows.Count - 1;
                dgvDetalleVenta.CurrentCell = dgvDetalleVenta["colCodigo", newRowIndex];
            }
        }

        private void LimpiarFila(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvDetalleVenta.Rows.Count) return;
            DataGridViewRow filaActual = dgvDetalleVenta.Rows[rowIndex];
            if (filaActual.IsNewRow) return;

            foreach (DataGridViewCell cell in filaActual.Cells)
            {
                if (!cell.ReadOnly)
                {
                    cell.Value = null;
                }
            }
        }

        private void CalcularTotalesFila(DataGridViewRow fila)
        {
            if (fila == null || fila.IsNewRow) return;

            try
            {
                decimal cantidad = Convert.ToDecimal(fila.Cells["colCantidad"].Value ?? 0);
                decimal precioFinal = Convert.ToDecimal(fila.Cells["colPFinal"].Value ?? 0);
                decimal descuentoPorc = Convert.ToDecimal(fila.Cells["colDscto"].Value ?? 0);

                decimal subtotal = cantidad * precioFinal;
                decimal montoDescuento = subtotal * (descuentoPorc / 100);
                decimal subtotalConDescuento = subtotal - montoDescuento;

                decimal ivaRate = ImpuestoProvider.GetIVA();
                decimal iva = subtotalConDescuento * ivaRate;
                decimal total = subtotalConDescuento + iva;

                fila.Cells["colSubtotal"].Value = subtotalConDescuento;
                fila.Cells["colIVA"].Value = iva;
                fila.Cells["colTotal"].Value = total;

                fila.Cells["colPFinal"].Value = string.Format("{0:N2}", precioFinal);
                fila.Cells["colSubtotal"].Value = string.Format("{0:N2}", subtotalConDescuento);
                fila.Cells["colIVA"].Value = string.Format("{0:N2}", iva);
                fila.Cells["colTotal"].Value = string.Format("{0:N2}", total);

                CalcularTotalesGenerales();
            }
            catch (FormatException)
            {
            }
        }

        private void CalcularTotalesGenerales()
        {
            decimal subtotalGeneral = 0;
            decimal ivaGeneral = 0;
            decimal totalDescuento = 0;

            foreach (DataGridViewRow fila in dgvDetalleVenta.Rows)
            {
                if (fila.IsNewRow) continue;

                decimal.TryParse(fila.Cells["colSubtotal"].Value?.ToString(), out decimal sub);
                decimal.TryParse(fila.Cells["colIVA"].Value?.ToString(), out decimal iva);
                decimal.TryParse(fila.Cells["colDscto"].Value?.ToString(), out decimal dctoPorcentaje);
                decimal.TryParse(fila.Cells["colPFinal"].Value?.ToString(), out decimal precioFinal);
                decimal.TryParse(fila.Cells["colCantidad"].Value?.ToString(), out decimal cantidad);

                subtotalGeneral += sub;
                ivaGeneral += iva;

                decimal subtotalSinDescuento = cantidad * precioFinal;
                totalDescuento += subtotalSinDescuento * (dctoPorcentaje / 100);
            }

            // ✅ CORRECCIÓN: Asignación correcta de los totales a las etiquetas.
            // Suponiendo que 'lblPrecio' muestra el subtotal, 'lblIVA' el IVA, y necesitas un total general.
            decimal totalGeneral = subtotalGeneral + ivaGeneral;

            // Paneles de Precios
            this.label13.Text = totalGeneral.ToString("N2"); // PRECIO EFE (Total)

            // Labels de desglose
            this.lblTotalDescuento.Text = totalDescuento.ToString("N2");
            this.label24.Text = subtotalGeneral.ToString("N2"); // TARIFA 0% (Asumiendo que es subtotal)
            this.lblIVA.Text = ivaGeneral.ToString("N2"); // IVA 15%
        }

        private void Dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyDown -= dgvDetalleVenta_KeyDown;
            e.Control.KeyDown += dgvDetalleVenta_KeyDown;
        }

        private void dgvDetalleVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;  // evita que el grid navegue al final
                var cell = dgvDetalleVenta.CurrentCell;
                if (cell == null) return;

                string col = dgvDetalleVenta.Columns[cell.ColumnIndex].Name;
                if (col == "colCodigo" || col == "colProducto")
                    BuscarYAsignarProducto("%", cell.RowIndex); // o "*", o null, según tu DAL
            }
        }


        // Evento para poner el ícono de eliminar en cada nueva fila
        private void dgvDetalleVenta_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // Asigna la imagen al botón de eliminar
            DataGridViewRow row = dgvDetalleVenta.Rows[e.RowIndex];
            //row.Cells["colEliminar"].Value = Properties.Resources.delete_icon; // Asegúrate de tener este recurso de imagen
        }

        private void CalcularTotalFila(DataGridViewRow fila)
        {
            decimal cantidad = 0, precio = 0;
            decimal.TryParse(fila.Cells["colCantidad"].Value?.ToString(), out cantidad);
            decimal.TryParse(fila.Cells["colPrecio"].Value?.ToString(), out precio);

            decimal total = cantidad * precio;
            fila.Cells["colTotal"].Value = total > 0 ? total.ToString("N2") : null;
        }

        private void dgvDetalleVenta_CellAccion(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dgvDetalleVenta.Columns[e.ColumnIndex].Name;

            if (colName == "colEliminar")
            {
                var fila = dgvDetalleVenta.Rows[e.RowIndex];
                if (!fila.IsNewRow)
                {
                    dgvDetalleVenta.Rows.RemoveAt(e.RowIndex);
                    CalcularTotalesGenerales();
                }
            }
            else if (colName == "colInfo")
            {
                // aquí lo que quieras hacer con "Info"
                // p.ej. mostrar detalles del producto seleccionado
            }
        }

        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificamos si la tecla presionada NO es un número Y NO es una tecla de control (como borrar)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número, cancelamos la pulsación de la tecla.
                e.Handled = true;
            }
        }

        private void txtIdentificacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string id = txtIdentificacion.Text.Trim();
                if (string.IsNullOrEmpty(id)) return;

                try
                {
                    DClientes d_Clientes = new DClientes();
                    ECliente cliente = d_Clientes.BuscarClientePorId(id);

                    if (cliente != null)
                    {
                        // Si el cliente existe, llenamos los datos
                        _clienteSeleccionado = cliente;
                        txtCliente.Text = cliente.RazonSocial;
                        txtEmail.Text = cliente.Email;
                    }
                    else
                    {
                        // Si no existe, preguntamos si desea crearlo
                        var resultado = MessageBox.Show("Cliente no encontrado. ¿Desea registrarlo ahora?", "Cliente Nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (resultado == DialogResult.Yes)
                        {
                            using (var frm = new FrmFichaCliente(id))
                            {
                                if (frm.ShowDialog() == DialogResult.OK)
                                {
                                    // Si se guardó, actualizamos los datos en el POS
                                    _clienteSeleccionado = frm.ClienteGuardado;
                                    txtCliente.Text = frm.ClienteGuardado.Nombres;
                                    txtEmail.Text = frm.ClienteGuardado.Email;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
