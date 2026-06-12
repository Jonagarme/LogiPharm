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

        private DataTable _dtPuntosEmision;
        private int _idPuntoEmisionActual;
        private Dictionary<long, bool> _productosAplicaIva = new Dictionary<long, bool>();
        private bool _esEntrega = false;
        private decimal _totalGeneral = 0m;
        private FlowLayoutPanel flowPanelDerecho;
        private Guna.UI2.WinForms.Guna2GroupBox grpClienteInfo;
        private Guna.UI2.WinForms.Guna2Button btnNuevoCliente;
        private Guna.UI2.WinForms.Guna2Button btnPagarSidebar;

        private Guna.UI2.WinForms.Guna2CheckBox chkExentoIva;
        private List<Guna.UI2.WinForms.Guna2Button> btnDescuentosList = new List<Guna.UI2.WinForms.Guna2Button>();
        private Guna.UI2.WinForms.Guna2TextBox txtCustomDscto;
        private int _hoverRow = -1, _hoverCol = -1;
		private int _hoverRowFull = -1;
        private const double PanelDerechoPct = 0.32; // 32% del ancho
        private const int PanelDerechoMin = 320;
        private const int PanelDerechoMax = 520;

		private readonly ToolTip _toolTip = new ToolTip();

        public FrmPuntoDeVenta()
        {
            InitializeComponent();

			ConfigurarGridHibrido();
			ConfigurarTooltips();
            
            this.Resize += Frm_Resize_Adaptativo;

            if (this.btnDocumento != null)
                this.btnDocumento.Click += (s, e) => ToggleDocumentType();

            this.dgvDetalleVenta.CellEndEdit += dgvDetalleVenta_CellEndEdit;
            this.dgvDetalleVenta.CellClick += dgvDetalleVenta_CellAccion;
            this.txtIdentificacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdentificacion_KeyDown);
            this.txtIdentificacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdentificacion_KeyPress);
            dgvDetalleVenta.EditingControlShowing += Dgv_EditingControlShowing;
            this.Shown += FrmPuntoDeVenta_Shown;

            if (this.cboPuntoEmision != null)
                this.cboPuntoEmision.SelectedIndexChanged += cboPuntoEmision_SelectedIndexChanged;

            // Pintado custom + hover + tooltips
            this.dgvDetalleVenta.CellPainting += dgvDetalleVenta_CellPainting;
            this.dgvDetalleVenta.CellMouseMove += dgvDetalleVenta_CellMouseMove;
            this.dgvDetalleVenta.CellMouseLeave += dgvDetalleVenta_CellMouseLeave;
            this.dgvDetalleVenta.CellToolTipTextNeeded += dgvDetalleVenta_CellToolTipTextNeeded;
			this.dgvDetalleVenta.RowPrePaint += dgvDetalleVenta_RowPrePaint;

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

            // Altura uniforme de filas (ajustada para el padding)
            dgvDetalleVenta.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvDetalleVenta.AllowUserToResizeRows = false;
            dgvDetalleVenta.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvDetalleVenta.RowTemplate.Height = 40; // Aumentado a 40 para coincidir con el Designer
            dgvDetalleVenta.DataBindingComplete += (s, e) => AjustarAlturas();
            dgvDetalleVenta.RowsAdded += (s, e) => AjustarAlturas();

			this.dgvDetalleVenta.CellFormatting += dgvDetalleVenta_CellFormatting;


        }

		private void ConfigurarTooltips()
		{
			_toolTip.AutoPopDelay = 8000;
			_toolTip.InitialDelay = 400;
			_toolTip.ReshowDelay = 200;
			_toolTip.ShowAlways = true;

			if (btnNuevo != null) _toolTip.SetToolTip(btnNuevo, "Nueva venta (Shift+F2)");
			if (btnFacturas != null) _toolTip.SetToolTip(btnFacturas, "Ver facturas (F3)");
			if (btnPagar != null) _toolTip.SetToolTip(btnPagar, "Cobrar / Pagar (F4)");
			if (btnKardex != null) _toolTip.SetToolTip(btnKardex, "Calculadora (F8)");
			if (btnDescuento != null) _toolTip.SetToolTip(btnDescuento, "Descuento (F7)");
			if (btnRecargas != null) _toolTip.SetToolTip(btnRecargas, "Recargas (F10)");
			if (btnDocumento != null) _toolTip.SetToolTip(btnDocumento, "Documento (F11)");
			//if (btnIncrementar != null) _toolTip.SetToolTip(btnIncrementar, "Incrementar (F12)");
		}

		private void ConfigurarGridHibrido()
		{
			if (dgvDetalleVenta == null) return;

			dgvDetalleVenta.MultiSelect = false;
			dgvDetalleVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvDetalleVenta.ShowCellToolTips = true;
			dgvDetalleVenta.AllowUserToResizeColumns = true;
			dgvDetalleVenta.AllowUserToOrderColumns = false;
			dgvDetalleVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			dgvDetalleVenta.ScrollBars = ScrollBars.Both;
			dgvDetalleVenta.StandardTab = true;
			dgvDetalleVenta.EditMode = DataGridViewEditMode.EditOnEnter;

			// Alineación / formato tipo ERP
			AplicarFormatoColumna("colCantidad", "N2", DataGridViewContentAlignment.MiddleRight);
			AplicarFormatoColumna("colPrecio", "N2", DataGridViewContentAlignment.MiddleRight);
			AplicarFormatoColumna("colPFinal", "N2", DataGridViewContentAlignment.MiddleRight);
			AplicarFormatoColumna("colPorcentaje", "N2", DataGridViewContentAlignment.MiddleRight);
			AplicarFormatoColumna("colDscto", "N2", DataGridViewContentAlignment.MiddleRight);
			AplicarFormatoColumna("colIVA", "N2", DataGridViewContentAlignment.MiddleRight);
			AplicarFormatoColumna("colSubtotal", "N2", DataGridViewContentAlignment.MiddleRight);
			AplicarFormatoColumna("colTotal", "N2", DataGridViewContentAlignment.MiddleRight);

			// Mantener legibilidad - colProducto NO se congela para poder usar Fill
			if (dgvDetalleVenta.Columns["colProducto"] != null)
			{
				dgvDetalleVenta.Columns["colProducto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				dgvDetalleVenta.Columns["colProducto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			}
			if (dgvDetalleVenta.Columns["colCodigo"] != null)
			{
				dgvDetalleVenta.Columns["colCodigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			}

			// Congelar solo columnas con ancho fijo
			try
			{
				if (dgvDetalleVenta.Columns["colEliminar"] != null) dgvDetalleVenta.Columns["colEliminar"].Frozen = true;
				if (dgvDetalleVenta.Columns["colCodigo"] != null) dgvDetalleVenta.Columns["colCodigo"].Frozen = true;
			}
			catch { }

			// Evitar edición accidental (solo cantidad y descuento si están visibles)
			SetReadOnly("colCodigo", false);   // se ingresa código
			SetReadOnly("colProducto", false); // se permite buscar/editar texto
			SetReadOnly("colCantidad", false);
			SetReadOnly("colDscto", false);
			SetReadOnly("colPrecio", true);
			SetReadOnly("colIVA", true);
			SetReadOnly("colSubtotal", true);
			SetReadOnly("colTotal", true);
		}

		private void AplicarFormatoColumna(string colName, string format, DataGridViewContentAlignment align)
		{
			var col = dgvDetalleVenta.Columns[colName];
			if (col == null) return;
			col.DefaultCellStyle.Format = format;
			col.DefaultCellStyle.Alignment = align;
		}

		private void SetReadOnly(string colName, bool readOnly)
		{
			var col = dgvDetalleVenta.Columns[colName];
			if (col == null) return;
			col.ReadOnly = readOnly;
		}

        // ========================================
        // CONFIGURACIÓN DE ESTILOS PROFESIONALES
        // ========================================
        private void ConfigurarEstilosProfesionales()
        {
            // === COLORES AZULES TIPO IMAGEN ===
            Color azulPrincipal = Color.FromArgb(0, 123, 195);  // Azul profesional
            Color azulOscuro = Color.FromArgb(0, 86, 137);      // Azul más oscuro
            Color verdeAccion = Color.FromArgb(76, 175, 80);    // Verde para acciones
            
            // === BOTONES CON COLORES AZULES ===
            btnPagar.FillColor = verdeAccion;
            btnPagar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            
            btnNuevo.FillColor = azulPrincipal;
            btnFacturas.FillColor = azulPrincipal;
            if (btnKardex != null) btnKardex.FillColor = Color.FromArgb(0, 172, 193); // Color calculadora
            //btnMedico.FillColor = azulOscuro;
            btnDescuento.FillColor = Color.FromArgb(255, 152, 0); // Naranja para destacar
            btnRecargas.FillColor = azulOscuro;
            btnDocumento.FillColor = azulOscuro;
           // btnIncrementar.FillColor = azulOscuro;

            AplicarEstadoBoton(btnPagar);
            AplicarEstadoBoton(btnNuevo);
            AplicarEstadoBoton(btnFacturas);
            AplicarEstadoBoton(btnDescuento);
            AplicarEstadoBoton(btnKardex);
            //AplicarEstadoBoton(btnMedico);
            AplicarEstadoBoton(btnRecargas);
            AplicarEstadoBoton(btnDocumento);
            //AplicarEstadoBoton(btnIncrementar);

            // === PANELES DE TOTALES - AZUL PROFESIONAL ===
            guna2Panel2.FillColor = azulPrincipal;
            guna2Panel3.FillColor = azulPrincipal;
            guna2Panel4.FillColor = azulOscuro;

            // === LABELS DE TOTALES (colores secundarios) ===
            if (label19 != null) label19.ForeColor = Color.FromArgb(66, 66, 66);
            if (label21 != null) label21.ForeColor = Color.FromArgb(66, 66, 66);
            if (label22 != null) label22.ForeColor = Color.FromArgb(66, 66, 66);
            if (label23 != null) label23.ForeColor = Color.FromArgb(66, 66, 66);

            // === LABELS SUPERIORES ===
            if (label1 != null) label1.ForeColor = Color.FromArgb(66, 66, 66);
            if (label2 != null) label2.ForeColor = Color.FromArgb(66, 66, 66);
            if (label3 != null) label3.ForeColor = Color.FromArgb(66, 66, 66);
            
            // === PANEL SUPERIOR AZUL ===
            panelTop.BackColor = Color.FromArgb(240, 245, 250);
        }

		private void AplicarEstadoBoton(Guna.UI2.WinForms.Guna2Button btn)
		{
			if (btn == null) return;

			btn.Font = btn.Font ?? new Font("Segoe UI", 9F, FontStyle.Bold);
			btn.HoverState.FillColor = ControlPaint.Light(btn.FillColor, 0.10f);
			btn.PressedColor = ControlPaint.Dark(btn.FillColor, 0.15f);
			btn.Animated = true;
			btn.DisabledState.FillColor = Color.FromArgb(220, 220, 220);
			btn.DisabledState.ForeColor = Color.FromArgb(140, 140, 140);
			btn.DisabledState.BorderColor = Color.FromArgb(200, 200, 200);
			btn.DisabledState.CustomBorderColor = Color.FromArgb(200, 200, 200);
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
            // ✨ APLICAR ESTILOS PROFESIONALES (después del diseñador)
            ConfigurarEstilosProfesionales();

            dgvDetalleVenta.ReadOnly = false;
            dgvDetalleVenta.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvDetalleVenta.Columns["colCodigo"].ReadOnly = false;
            dgvDetalleVenta.Columns["colProducto"].ReadOnly = false;
            dgvDetalleVenta.Columns["colCantidad"].ReadOnly = false;
            dgvDetalleVenta.Columns["colDscto"].ReadOnly = false;


            // ✨ Forzar configuración visual del grid (lo que el Designer no puede hacer)
            dgvDetalleVenta.EnableHeadersVisualStyles = false;
            dgvDetalleVenta.BorderStyle = BorderStyle.FixedSingle;
            dgvDetalleVenta.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDetalleVenta.BackgroundColor = Color.White;

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
            
            // Asegurar que las columnas editables estén configuradas correctamente
            dgvDetalleVenta.Columns["colCodigo"].ReadOnly = false;
            dgvDetalleVenta.Columns["colProducto"].ReadOnly = false;
            dgvDetalleVenta.Columns["colCantidad"].ReadOnly = false;
            dgvDetalleVenta.Columns["colDscto"].ReadOnly = false;
            dgvDetalleVenta.Columns["colPrecio"].ReadOnly = true;
            dgvDetalleVenta.Columns["colIVA"].ReadOnly = true;
            dgvDetalleVenta.Columns["colSubtotal"].ReadOnly = true;
            dgvDetalleVenta.Columns["colTotal"].ReadOnly = true;
            
            dgvDetalleVenta.Select();

            CargarPuntosEmision();
            CargarAmbienteSRI();
            InicializarControlesAdicionales();
            InicializarSidebarDerecha();
        }

        private void InicializarControlesAdicionales()
        {
            if (grpDescuentosFijo == null) return;

            grpDescuentosFijo.Controls.Clear();
            grpDescuentosFijo.Text = "DESCUENTOS Y ALÍCUOTAS";

            // FlowLayoutPanel for horizontal alignment
            FlowLayoutPanel flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(8, 2, 8, 2),
                BackColor = Color.Transparent
            };

            // Add static label "Fijos:"
            Label lblFijos = new Label
            {
                Text = "Fijos:",
                AutoSize = true,
                Margin = new Padding(0, 8, 2, 0),
                Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
                ForeColor = Color.FromArgb(64, 64, 64)
            };
            flow.Controls.Add(lblFijos);

            // Discount buttons: 0%, 20%, 30%, 40%
            string[] pctes = { "0%", "20%", "30%", "40%" };
            btnDescuentosList.Clear();
            foreach (var p in pctes)
            {
                var btn = new Guna.UI2.WinForms.Guna2Button
                {
                    Text = p,
                    Size = new Size(50, 26),
                    BorderRadius = 4,
                    FillColor = Color.FromArgb(242, 245, 250),
                    ForeColor = Color.FromArgb(108, 117, 125),
                    Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
                    Margin = new Padding(2, 4, 2, 0)
                };

                btn.Click += (s, e) => {
                    decimal val = decimal.Parse(p.Replace("%", ""));
                    if (_ventaActual != null)
                    {
                        _ventaActual.Descuento = val;
                        if (txtCustomDscto != null)
                        {
                            txtCustomDscto.TextChanged -= txtCustomDscto_TextChanged;
                            txtCustomDscto.Text = "";
                            txtCustomDscto.TextChanged += txtCustomDscto_TextChanged;
                        }
                        RecalcularTodaLaVenta();
                        ActualizarBotonesDescuento();
                    }
                };

                btnDescuentosList.Add(btn);
                flow.Controls.Add(btn);
            }

            // Custom label
            Label lblOtro = new Label
            {
                Text = "Otro:",
                AutoSize = true,
                Margin = new Padding(12, 8, 2, 0),
                Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
                ForeColor = Color.FromArgb(64, 64, 64)
            };
            flow.Controls.Add(lblOtro);

            // Custom textbox
            txtCustomDscto = new Guna.UI2.WinForms.Guna2TextBox
            {
                Size = new Size(65, 26),
                BorderRadius = 4,
                Font = new Font("Segoe UI", 8.25F),
                PlaceholderText = "0%",
                Margin = new Padding(2, 4, 2, 0)
            };
            txtCustomDscto.TextChanged += txtCustomDscto_TextChanged;
            flow.Controls.Add(txtCustomDscto);

            // Exento de IVA checkbox
            chkExentoIva = new Guna.UI2.WinForms.Guna2CheckBox
            {
                Text = "EXENTO DE IVA",
                ForeColor = Color.FromArgb(220, 53, 69),
                Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
                CheckedState = { FillColor = Color.FromArgb(220, 53, 69) },
                Margin = new Padding(30, 8, 0, 0),
                AutoSize = true
            };
            chkExentoIva.CheckedChanged += chkExentoIva_CheckedChanged;
            flow.Controls.Add(chkExentoIva);

            grpDescuentosFijo.Controls.Add(flow);

            // Set up Click listeners for Price Panels (guna2Panel2, guna2Panel3, guna2Panel4)
            ConfigurarClickPanelesPrecios();
        }

        private void InicializarSidebarDerecha()
        {
            if (panelDerecho == null) return;

            // Clear any existing controls in panelDerecho
            panelDerecho.Controls.Clear();

            // Create a vertical FlowLayoutPanel to stack controls
            flowPanelDerecho = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                BackColor = Color.FromArgb(242, 245, 250), // Premium Light Gray/Indigo hue background
                Padding = new Padding(10, 10, 10, 10)
            };
            panelDerecho.Controls.Add(flowPanelDerecho);

            // 1. CLIENTE INFO GROUPBOX
            grpClienteInfo = new Guna.UI2.WinForms.Guna2GroupBox
            {
                Text = "DATOS DEL CLIENTE",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(64, 64, 64),
                CustomBorderColor = Color.FromArgb(230, 235, 240),
                BorderColor = Color.Gainsboro,
                BorderRadius = 8,
                Height = 175,
                Margin = new Padding(0, 0, 0, 10)
            };

            // Create Quick Register Client button dynamically
            btnNuevoCliente = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "+",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                FillColor = Color.FromArgb(13, 110, 253), // Premium blue
                ForeColor = Color.White,
                BorderRadius = 4,
                Cursor = Cursors.Hand,
                Size = new Size(30, 28)
            };
            btnNuevoCliente.Click += (s, e) => {
                string id = txtIdentificacion.Text.Trim();
                using (var frm = new FrmFichaCliente(id))
                {
                    if (frm.ShowDialog() == DialogResult.OK && frm.ClienteGuardado != null)
                    {
                        _clienteSeleccionado = frm.ClienteGuardado;
                        txtIdentificacion.Text = frm.ClienteGuardado.Identificacion ?? frm.ClienteGuardado.CedulaRuc;
                        txtCliente.Text = frm.ClienteGuardado.RazonSocial ?? frm.ClienteGuardado.Nombres;
                        txtEmail.Text = frm.ClienteGuardado.Email;
                    }
                }
            };

            // Move customer controls from panelTop to grpClienteInfo
            grpClienteInfo.Controls.Add(label2);
            grpClienteInfo.Controls.Add(txtIdentificacion);
            grpClienteInfo.Controls.Add(btnNuevoCliente);
            grpClienteInfo.Controls.Add(label1);
            grpClienteInfo.Controls.Add(txtCliente);
            grpClienteInfo.Controls.Add(label3);
            grpClienteInfo.Controls.Add(txtEmail);

            // Reposition them inside grpClienteInfo
            label2.Location = new Point(10, 48);
            txtIdentificacion.Location = new Point(10, 65);
            txtIdentificacion.Size = new Size(100, 28);

            btnNuevoCliente.Location = new Point(115, 65);

            label1.Location = new Point(150, 48);
            txtCliente.Location = new Point(150, 65);
            txtCliente.Size = new Size(200, 28);

            label3.Location = new Point(10, 105);
            txtEmail.Location = new Point(10, 122);
            txtEmail.Size = new Size(340, 28);

            flowPanelDerecho.Controls.Add(grpClienteInfo);

            // 2. MODOS DE PRECIOS PANEL
            panelPrecios.Parent = null; // Detach from tblHeaderResumen
            panelPrecios.Dock = DockStyle.None;
            panelPrecios.Height = 230;
            panelPrecios.Width = 360;
            panelPrecios.BackColor = Color.Transparent;
            panelPrecios.Margin = new Padding(0, 0, 0, 10);
            
            // Rearrange tblResumenImpuestos inside panelPrecios to stack vertically
            tblResumenImpuestos.Dock = DockStyle.None;
            tblResumenImpuestos.Location = new Point(8, 65);
            tblResumenImpuestos.Width = 345;
            tblResumenImpuestos.Height = 150;
            
            tblResumenImpuestos.ColumnCount = 1;
            tblResumenImpuestos.RowCount = 3;
            tblResumenImpuestos.ColumnStyles.Clear();
            tblResumenImpuestos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblResumenImpuestos.RowStyles.Clear();
            tblResumenImpuestos.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            tblResumenImpuestos.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tblResumenImpuestos.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            
            tblResumenImpuestos.Controls.Clear();
            tblResumenImpuestos.Controls.Add(tblImpuesto15, 0, 0);
            tblResumenImpuestos.Controls.Add(tblImpuesto0, 0, 1);
            tblResumenImpuestos.Controls.Add(tblDescuentoResumen, 0, 2);
            
            tblImpuesto15.Dock = DockStyle.Fill;
            tblImpuesto0.Dock = DockStyle.Fill;
            tblDescuentoResumen.Dock = DockStyle.Fill;

            flowPanelDerecho.Controls.Add(panelPrecios);

            // 3. DESCUENTOS Y ALÍCUOTAS GROUPBOX
            grpDescuentosFijo.Parent = null;
            grpDescuentosFijo.Dock = DockStyle.None;
            grpDescuentosFijo.Height = 110;
            grpDescuentosFijo.Width = 360;
            grpDescuentosFijo.Margin = new Padding(0, 0, 0, 10);
            flowPanelDerecho.Controls.Add(grpDescuentosFijo);

            // 4. FACTURACIÓN ELECTRÓNICA GROUPBOX
            guna2GroupBox1.Parent = null;
            guna2GroupBox1.Dock = DockStyle.None;
            guna2GroupBox1.Height = 260; // Increased height to prevent overlapping
            guna2GroupBox1.Width = 360;
            guna2GroupBox1.Margin = new Padding(0, 0, 0, 10);
            
            // Move cboPuntoEmision and sequential label inside guna2GroupBox1
            cboPuntoEmision.Parent = guna2GroupBox1;
            lblPuntoEmision.Parent = guna2GroupBox1;
            lblSiguienteSecuencial.Parent = guna2GroupBox1;

            // Reposition original and moved controls to prevent overlapping
            label4.Location = new Point(15, 45);
            lblNumeroFactura.Location = new Point(15, 75);
            
            label5.Location = new Point(15, 115);
            lblVendedor.Location = new Point(75, 115);
            
            label6.Location = new Point(180, 115);
            lblCaja.Location = new Point(215, 115);
            
            label10.Location = new Point(15, 140);
            lblFechaEmision.Location = new Point(120, 140);

            lblPuntoEmision.Location = new Point(15, 165);
            cboPuntoEmision.Location = new Point(15, 182);
            cboPuntoEmision.Size = new Size(330, 30);
            
            lblSiguienteSecuencial.Location = new Point(15, 222);
            lblSiguienteSecuencial.Size = new Size(330, 20);

            flowPanelDerecho.Controls.Add(guna2GroupBox1);

            // 5. PROCESAR VENTA SIDEBAR BUTTON (Matching PHP pos.php)
            btnPagarSidebar = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "PROCESAR VENTA (F4)",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                FillColor = Color.FromArgb(40, 167, 69), // Success green color
                ForeColor = Color.White,
                BorderRadius = 8,
                Height = 45,
                Margin = new Padding(0, 10, 0, 10),
                Cursor = Cursors.Hand,
                Animated = true
            };
            btnPagarSidebar.Click += btnPagar_Click;
            flowPanelDerecho.Controls.Add(btnPagarSidebar);

            // Hide panelTop and panelHeaderResumen as they are no longer needed
            if (panelTop != null) panelTop.Visible = false;
            if (panelHeaderResumen != null) panelHeaderResumen.Visible = false;

            // Handle Resize
            panelDerecho.Resize += (s, ev) => AjustarAnchoSidebar();
            AjustarAnchoSidebar();
        }

        private void AjustarAnchoSidebar()
        {
            if (flowPanelDerecho == null) return;
            
            int w = panelDerecho.Width;
            int childWidth = w - 25; // Subtract for scrollbar and padding

            if (childWidth < 280) childWidth = 280;

            if (grpClienteInfo != null)
            {
                grpClienteInfo.Width = childWidth;
                
                label2.Location = new Point(10, 48);
                txtIdentificacion.Location = new Point(10, 65);
                txtIdentificacion.Width = 100;
                
                if (btnNuevoCliente != null)
                {
                    btnNuevoCliente.Location = new Point(115, 65);
                    btnNuevoCliente.Width = 30;
                    btnNuevoCliente.Height = 28;
                }
                
                label1.Location = new Point(150, 48);
                txtCliente.Location = new Point(150, 65);
                txtCliente.Width = childWidth - 150 - 15;
                
                label3.Location = new Point(10, 105);
                txtEmail.Location = new Point(10, 122);
                txtEmail.Width = childWidth - 25;
            }

            if (panelPrecios != null)
            {
                panelPrecios.Width = childWidth;
                tblResumenImpuestos.Width = childWidth - 15;
                
                if (childWidth >= 350)
                {
                    guna2Panel2.Location = new Point(8, 6);
                    guna2Panel3.Location = new Point(123, 6);
                    guna2Panel4.Location = new Point(238, 6);
                    guna2Panel2.Width = 107;
                    guna2Panel3.Width = 107;
                    guna2Panel4.Width = 107;
                }
                else
                {
                    int eachWidth = (childWidth - 25) / 3;
                    guna2Panel2.Location = new Point(8, 6);
                    guna2Panel2.Width = eachWidth;
                    
                    guna2Panel3.Location = new Point(guna2Panel2.Right + 5, 6);
                    guna2Panel3.Width = eachWidth;
                    
                    guna2Panel4.Location = new Point(guna2Panel3.Right + 5, 6);
                    guna2Panel4.Width = eachWidth;
                }
            }

            if (grpDescuentosFijo != null)
            {
                grpDescuentosFijo.Width = childWidth;
            }

            if (guna2GroupBox1 != null)
            {
                guna2GroupBox1.Width = childWidth;
                
                label4.Width = childWidth - 30;
                lblNumeroFactura.Width = childWidth - 30;
                
                if (childWidth < 320)
                {
                    label6.Location = new Point(15, 135);
                    lblCaja.Location = new Point(50, 135);
                    
                    label10.Location = new Point(15, 155);
                    lblFechaEmision.Location = new Point(120, 155);
                    
                    lblPuntoEmision.Location = new Point(15, 180);
                    cboPuntoEmision.Location = new Point(15, 197);
                    cboPuntoEmision.Width = childWidth - 30;
                    
                    lblSiguienteSecuencial.Location = new Point(15, 232);
                    lblSiguienteSecuencial.Width = childWidth - 30;
                    
                    guna2GroupBox1.Height = 270;
                }
                else
                {
                    label6.Location = new Point(180, 115);
                    lblCaja.Location = new Point(215, 115);
                    
                    label10.Location = new Point(15, 140);
                    lblFechaEmision.Location = new Point(120, 140);
                    
                    lblPuntoEmision.Location = new Point(15, 165);
                    cboPuntoEmision.Location = new Point(15, 182);
                    cboPuntoEmision.Width = childWidth - 30;
                    
                    lblSiguienteSecuencial.Location = new Point(15, 222);
                    lblSiguienteSecuencial.Width = childWidth - 30;
                    
                    guna2GroupBox1.Height = 260;
                }
            }

            if (btnPagarSidebar != null)
            {
                btnPagarSidebar.Width = childWidth;
            }
        }

        private void txtCustomDscto_TextChanged(object sender, EventArgs e)
        {
            if (_ventaActual == null) return;
            string text = txtCustomDscto.Text.Replace("%", "").Trim();
            if (decimal.TryParse(text, out decimal val))
            {
                _ventaActual.Descuento = val;
            }
            else
            {
                _ventaActual.Descuento = 0m;
            }
            RecalcularTodaLaVenta();
            ActualizarBotonesDescuento();
        }

        private void chkExentoIva_CheckedChanged(object sender, EventArgs e)
        {
            if (_ventaActual == null) return;
            _ventaActual.DesactivarIva = chkExentoIva.Checked;
            
            // Re-calculate row taxes and totals
            RecalcularTodaLaVenta();
        }

        private void ConfigurarClickPanelesPrecios()
        {
            guna2Panel2.Cursor = Cursors.Hand;
            guna2Panel3.Cursor = Cursors.Hand;
            guna2Panel4.Cursor = Cursors.Hand;

            guna2Panel2.Click += (s, e) => CambiarModoPrecio("NORMAL");
            lblPrecio.Click += (s, e) => CambiarModoPrecio("NORMAL");
            label18.Click += (s, e) => CambiarModoPrecio("NORMAL");

            guna2Panel3.Click += (s, e) => CambiarModoPrecio("EFECTIVO");
            lblPrecioEfe.Click += (s, e) => CambiarModoPrecio("EFECTIVO");
            label14.Click += (s, e) => CambiarModoPrecio("EFECTIVO");

            guna2Panel4.Click += (s, e) => CambiarModoPrecio("TARJETA");
            lblPrecioTar.Click += (s, e) => CambiarModoPrecio("TARJETA");
            label16.Click += (s, e) => CambiarModoPrecio("TARJETA");
        }

        private void CambiarModoPrecio(string nuevoModo)
        {
            if (_ventaActual == null) return;
            _ventaActual.PriceMode = nuevoModo;

            // Recalculate toda la venta using the new pricing modifiers
            RecalcularTodaLaVenta();

            // Highlight the selected panel
            ActualizarEstiloPrecios();
        }

        private void ActualizarEstiloPrecios()
        {
            if (_ventaActual == null) return;

            // Colors for selected vs. default border styling
            Color colorSeleccionado = Color.FromArgb(255, 193, 7); // Gold/Yellow border
            Color colorDefecto = Color.Gainsboro;

            guna2Panel2.BorderColor = (_ventaActual.PriceMode == "NORMAL") ? colorSeleccionado : colorDefecto;
            guna2Panel2.BorderThickness = (_ventaActual.PriceMode == "NORMAL") ? 3 : 1;

            guna2Panel3.BorderColor = (_ventaActual.PriceMode == "EFECTIVO") ? colorSeleccionado : colorDefecto;
            guna2Panel3.BorderThickness = (_ventaActual.PriceMode == "EFECTIVO") ? 3 : 1;

            guna2Panel4.BorderColor = (_ventaActual.PriceMode == "TARJETA") ? colorSeleccionado : colorDefecto;
            guna2Panel4.BorderThickness = (_ventaActual.PriceMode == "TARJETA") ? 3 : 1;
        }

        private void ActualizarBotonesDescuento()
        {
            if (_ventaActual == null) return;

            decimal dcto = _ventaActual.Descuento;

            if (txtCustomDscto != null)
            {
                txtCustomDscto.TextChanged -= txtCustomDscto_TextChanged;
                if (dcto != 0m && dcto != 20m && dcto != 30m && dcto != 40m)
                {
                    txtCustomDscto.Text = dcto.ToString("N2");
                }
                else
                {
                    txtCustomDscto.Text = "";
                }
                txtCustomDscto.TextChanged += txtCustomDscto_TextChanged;
            }

            for (int i = 0; i < btnDescuentosList.Count; i++)
            {
                var btn = btnDescuentosList[i];
                decimal valBtn = decimal.Parse(btn.Text.Replace("%", ""));

                if (dcto == valBtn)
                {
                    btn.FillColor = Color.FromArgb(13, 110, 253); // Blue selected
                    btn.ForeColor = Color.White;
                }
                else
                {
                    btn.FillColor = Color.FromArgb(242, 245, 250); // Gray unselected
                    btn.ForeColor = Color.FromArgb(108, 117, 125);
                }
            }
        }

        private void SyncUIConVentaActual()
        {
            if (_ventaActual == null) return;

            // Sync document type (Nota de Entrega / Factura)
            _esEntrega = _ventaActual.EsEntrega;
            ActualizarVisualizacionDocumento();

            // Sync Price Mode visual indicator
            ActualizarEstiloPrecios();

            // Sync Exento IVA checkbox
            if (chkExentoIva != null)
            {
                chkExentoIva.CheckedChanged -= chkExentoIva_CheckedChanged;
                chkExentoIva.Checked = _ventaActual.DesactivarIva;
                chkExentoIva.CheckedChanged += chkExentoIva_CheckedChanged;
            }

            // Sync Descuento buttons and custom textbox
            ActualizarBotonesDescuento();
        }

        private void ActualizarVisualizacionDocumento()
        {
            if (btnDocumento == null) return;

            if (_esEntrega)
            {
                btnDocumento.Text = "F11 NOTA ENTREGA";
                btnDocumento.FillColor = Color.FromArgb(220, 53, 69);
            }
            else
            {
                btnDocumento.Text = "F11 FACTURA";
                btnDocumento.FillColor = Color.FromArgb(0, 123, 195);
            }
        }

        private void ToggleDocumentType()
        {
            if (_ventaActual == null) return;
            _ventaActual.EsEntrega = !_ventaActual.EsEntrega;
            _esEntrega = _ventaActual.EsEntrega;
            ActualizarVisualizacionDocumento();
        }

        private void RecalcularTodaLaVenta()
        {
            foreach (DataGridViewRow row in dgvDetalleVenta.Rows)
            {
                if (row.IsNewRow) continue;
                CalcularTotalesFila(row);
            }
            CalcularTotalesGenerales();
        }

        private void CargarPuntosEmision()
        {
            if (cboPuntoEmision == null || lblSiguienteSecuencial == null) return;

            try
            {
                var dt = new DPuntosEmision().ListarActivosConEstablecimiento();
                _dtPuntosEmision = dt;

                cboPuntoEmision.BeginUpdate();
                cboPuntoEmision.DataSource = null;
                cboPuntoEmision.Items.Clear();

                cboPuntoEmision.DisplayMember = "display";
                cboPuntoEmision.ValueMember = "id";

                // armamos una tabla con columna calculada para el DisplayMember
                if (!dt.Columns.Contains("display"))
                    dt.Columns.Add("display", typeof(string));

                foreach (DataRow r in dt.Rows)
                {
                    string codEst = Convert.ToString(r["cod_est"]);
                    string codPto = Convert.ToString(r["codigo"]);
                    string desc = Convert.ToString(r["descripcion"]);
                    r["display"] = $"{codEst}-{codPto} ({desc})";
                }

                cboPuntoEmision.DataSource = dt;
                cboPuntoEmision.EndUpdate();

                if (dt.Rows.Count > 0)
                {
                    // por ahora: primer punto activo
                    cboPuntoEmision.SelectedIndex = 0;
                }
                else
                {
                    _idPuntoEmisionActual = 0;
                    lblSiguienteSecuencial.Text = "Siguiente: ---";
                }
            }
            catch
            {
                _idPuntoEmisionActual = 0;
                lblSiguienteSecuencial.Text = "Siguiente: ---";
            }
        }

        private void CargarAmbienteSRI()
        {
            try
            {
                DEmpresa d_empresa = new DEmpresa();
                EEmpresa empresa = d_empresa.ObtenerDatosEmpresa();

                label8.Text = "AMBIENTE SRI: " + ResolverAmbienteSri(empresa?.AmbienteSRI);
            }
            catch
            {
                // En caso de error, mostrar valor por defecto
                label8.Text = "AMBIENTE SRI: PRUEBAS";
            }
        }

		private static string ResolverAmbienteSri(string valor)
		{
			if (string.IsNullOrWhiteSpace(valor)) return "PRUEBAS";
			valor = valor.Trim();

			// Soporta configuración guardada como 1/2 o como texto
			if (valor == "1") return "PRUEBAS";
			if (valor == "2") return "PRODUCCIÓN";

			string up = valor.ToUpperInvariant();
			if (up.Contains("PROD")) return "PRODUCCIÓN";
			if (up.Contains("PRUE")) return "PRUEBAS";

			return up;
		}

		private void dgvDetalleVenta_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex < 0) return;
			if (dgvDetalleVenta.Rows[e.RowIndex].IsNewRow) return;

			string colName = dgvDetalleVenta.Columns[e.ColumnIndex].Name;
			if (colName == "colTotal")
			{
				// resaltar total de línea
				e.CellStyle.Font = new Font(dgvDetalleVenta.Font, FontStyle.Bold);
			}
		}

        private void cboPuntoEmision_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarSiguienteSecuencial();
        }

        private void ActualizarSiguienteSecuencial()
        {
            if (cboPuntoEmision == null || lblSiguienteSecuencial == null) return;
            if (cboPuntoEmision.SelectedValue == null)
            {
                lblSiguienteSecuencial.Text = "Siguiente: ---";
                return;
            }

            int id;
            try { id = Convert.ToInt32(cboPuntoEmision.SelectedValue); }
            catch { id = 0; }

            if (id <= 0)
            {
                _idPuntoEmisionActual = 0;
                lblSiguienteSecuencial.Text = "Siguiente: ---";
                return;
            }

            _idPuntoEmisionActual = id;

            try
            {
                // buscamos datos del punto seleccionado en la tabla cargada
                DataRow row = null;
                if (_dtPuntosEmision != null)
                {
                    row = _dtPuntosEmision.AsEnumerable()
                        .FirstOrDefault(r => Convert.ToInt32(r["id"]) == _idPuntoEmisionActual);
                }

                if (row == null)
                {
                    lblSiguienteSecuencial.Text = "Siguiente: ---";
                    return;
                }

                string codEst = Convert.ToString(row["cod_est"]);
                string codPto = Convert.ToString(row["codigo"]);

                // según tu JS: muestra el secuencial_factura como el que toca emitir.
                int sec = row["secuencial_factura"] == DBNull.Value ? 0 : Convert.ToInt32(row["secuencial_factura"]);
                string sec9 = sec.ToString().PadLeft(9, '0');

                lblSiguienteSecuencial.Text = $"Siguiente: {codEst}-{codPto}-{sec9}";
            }
            catch
            {
                lblSiguienteSecuencial.Text = "Siguiente: ---";
            }
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
            _ventaActual.EsEntrega = _esEntrega;

            // Guardar productos de la tabla
            _ventaActual.Productos.Clear();
            foreach (DataGridViewRow row in dgvDetalleVenta.Rows)
            {
                if (row.IsNewRow || row.Cells["colCodigo"].Value == null) continue;

                // Asumiendo que tienes una clase ProductoVenta como la usas en AbrirVentanaPago
                _ventaActual.Productos.Add(new ProductoVenta
                {
                    Id = Convert.ToInt32(row.Tag),
                    CodigoPrincipal = row.Cells["colCodigo"].Value.ToString(),
                    Descripcion = row.Cells["colProducto"].Value.ToString(),
                    Cantidad = Convert.ToDecimal(row.Cells["colCantidad"].Value ?? 0),
                    PrecioUnitario = Convert.ToDecimal(row.Cells["colPrecio"].Value ?? 0),
                    Descuento = Convert.ToDecimal(row.Cells["colDscto"].Value ?? 0),
                    PrecioTotalSinImpuesto = Convert.ToDecimal(row.Cells["colSubtotal"].Value ?? 0),
                    AplicaIva = _productosAplicaIva.ContainsKey(Convert.ToInt64(row.Tag)) ? _productosAplicaIva[Convert.ToInt64(row.Tag)] : true
                });
            }
        }

        // ? CÓDIGO CORREGIDO
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
                int rowIndex = dgvDetalleVenta.Rows.Add(
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
                DataGridViewRow row = dgvDetalleVenta.Rows[rowIndex];
                row.Tag = producto.Id;
                _productosAplicaIva[producto.Id] = producto.AplicaIva;
            }

            // Sync all UI controls with active tab properties
            SyncUIConVentaActual();

            // ? CORRECCIÓN CLAVE: Recalculamos TODAS las filas después de añadirlas
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
                    Text = venta.Nombre + (_ventasEnEspera.Count > 1 ? "   ?" : ""), // Texto con ícono de cierre
                    Tag = venta,
                    Margin = new Padding(2, 2, 0, 0),

                    // --- ? NUEVO DISEÑO ---
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

        // ? NUEVO MÉTODO
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

			// Hover de fila completa
			if (e.RowIndex != _hoverRowFull)
			{
				int prev = _hoverRowFull;
				_hoverRowFull = e.RowIndex;
				if (prev >= 0 && prev < dgvDetalleVenta.RowCount)
					dgvDetalleVenta.InvalidateRow(prev);
				dgvDetalleVenta.InvalidateRow(_hoverRowFull);
			}

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
			if (_hoverRowFull != -1)
			{
				int prev = _hoverRowFull;
				_hoverRowFull = -1;
				if (prev >= 0 && prev < dgvDetalleVenta.RowCount)
					dgvDetalleVenta.InvalidateRow(prev);
			}

            if (_hoverRow != -1 || _hoverCol != -1)
            {
                int r = _hoverRow, c = _hoverCol;
                _hoverRow = _hoverCol = -1;
                if (r >= 0 && c >= 0 && r < dgvDetalleVenta.RowCount && c < dgvDetalleVenta.ColumnCount)
                    dgvDetalleVenta.InvalidateCell(c, r);
            }
            dgvDetalleVenta.Cursor = Cursors.Default;
        }

		private void dgvDetalleVenta_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
		{
			if (e.RowIndex < 0) return;
			if (dgvDetalleVenta.Rows[e.RowIndex].IsNewRow) return;
			if (e.RowIndex != _hoverRowFull) return;
			if (dgvDetalleVenta.Rows[e.RowIndex].Selected) return;

			// Color sutil de hover para toda la fila
			using (var b = new SolidBrush(Color.FromArgb(245, 248, 255)))
			{
				e.Graphics.FillRectangle(b, e.RowBounds);
			}

			e.PaintCells(e.ClipBounds, DataGridViewPaintParts.All);
			e.Handled = true;
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
            if (keyData == Keys.F8) { AbrirCalculadora(); return true; }
            if (keyData == Keys.F11) { ToggleDocumentType(); return true; }
            if (keyData == Keys.F2 || keyData == (Keys.Shift | Keys.F2))
            {
                CrearNuevaVenta();
                return true;
            }

			// Navegación tipo POS: Enter avanza en celdas relevantes
			if (keyData == Keys.Enter && dgvDetalleVenta != null && dgvDetalleVenta.Focused)
			{
				var cell = dgvDetalleVenta.CurrentCell;
				if (cell != null)
				{
					string colName = dgvDetalleVenta.Columns[cell.ColumnIndex].Name;
					int rowIndex = cell.RowIndex;
					return AvanzarConEnter(colName, rowIndex);
				}
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

		private bool AvanzarConEnter(string colName, int rowIndex)
		{
			try
			{
				// Si está en código o producto, Enter inicia búsqueda/edición normal
				if (colName == "colCodigo" || colName == "colProducto")
				{
					dgvDetalleVenta.BeginEdit(true);
					return true;
				}

				// Si está en cantidad, pasa a siguiente fila (código)
				if (colName == "colCantidad")
				{
					PonerFocoEnNuevaFila();
					return true;
				}

				// Fallback: Tab behavior
				SendKeys.Send("{TAB}");
				return true;
			}
			catch
			{
				return false;
			}
		}


        private void btnAccesosSoporteTecnico_Click(object sender, EventArgs e)
        {
            AbrirCalculadora();
        }

        private void btnKardex_Click(object sender, EventArgs e)
        {
            AbrirCalculadora();
        }

        private void AbrirCalculadora()
        {
            try
            {
                System.Diagnostics.Process.Start("calc.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo abrir la calculadora: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            decimal totalVenta = _totalGeneral;

            using (var frmPago = new FrmPago(totalVenta, _clienteSeleccionado, productos, _esEntrega))
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
                // ? 1. OBTENER LOS DATOS DE LA EMPRESA
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

                // ? 2. LLENAR EL DATATABLE CON LOS DATOS DE LA EMPRESA
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
                // ✅ AGREGAR colDscto AQUÍ
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
            // Validar que el producto tenga datos válidos
            if (producto == null || string.IsNullOrEmpty(producto.CodigoPrincipal))
            {
                MessageBox.Show("El producto no tiene datos válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

                    CalcularTotalesFila(dgvDetalleVenta.Rows[i]);
                    LimpiarFila(rowIndex);
                    PonerFocoEnNuevaFila();
                    return;
                }
            }

            // Si llegamos aquí, el producto es nuevo en la lista.
            dgvDetalleVenta.CellEndEdit -= dgvDetalleVenta_CellEndEdit;

            // Determinar si estamos en una fila nueva o necesitamos usar la actual
            DataGridViewRow filaActual;
            
            // Si la fila es la nueva fila automática, la usamos directamente
            if (rowIndex >= 0 && rowIndex < dgvDetalleVenta.Rows.Count)
            {
                filaActual = dgvDetalleVenta.Rows[rowIndex];
            }
            else
            {
                // Si no hay fila válida, buscamos la última fila nueva
                filaActual = dgvDetalleVenta.Rows[dgvDetalleVenta.Rows.Count - 1];
            }

            // Marcar la fila con el ID del producto
            filaActual.Tag = producto.Id;

            // Asignar valores
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
            // ? SOLUCIÓN DEFINITIVA: Solo cambiamos la celda activa, sin forzar la edición.
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
                if (cantidad < 0)
                {
                    fila.Cells["colCantidad"].Style.BackColor = Color.FromArgb(255, 224, 224);
                    fila.Cells["colCantidad"].Style.ForeColor = Color.DarkRed;
                    return;
                }
                fila.Cells["colCantidad"].Style.BackColor = Color.White;
                fila.Cells["colCantidad"].Style.ForeColor = dgvDetalleVenta.DefaultCellStyle.ForeColor;

                decimal basePrecio = Convert.ToDecimal(fila.Cells["colPrecio"].Value ?? 0);
                decimal factor = 1.0m;
                if (_ventaActual != null)
                {
                    if (_ventaActual.PriceMode == "EFECTIVO") factor = 0.95m;
                    else if (_ventaActual.PriceMode == "TARJETA") factor = 1.05m;
                }
                decimal precioFinal = Math.Round(basePrecio * factor, 4);

                decimal descuentoPorc = Convert.ToDecimal(fila.Cells["colDscto"].Value ?? 0);

                // ✅ CÁLCULO DEL DESCUENTO
                decimal subtotalSinDescuento = cantidad * precioFinal;
                decimal montoDescuento = subtotalSinDescuento * (descuentoPorc / 100);
                decimal subtotalConDescuento = subtotalSinDescuento - montoDescuento;

                bool aplicaIva = true;
                if (_ventaActual != null && _ventaActual.DesactivarIva)
                {
                    aplicaIva = false;
                }
                else if (fila.Tag != null)
                {
                    long prodId = Convert.ToInt64(fila.Tag);
                    if (_productosAplicaIva.ContainsKey(prodId))
                    {
                        aplicaIva = _productosAplicaIva[prodId];
                    }
                }

                decimal ivaRate = ImpuestoProvider.GetIVA();
                decimal iva = aplicaIva ? (subtotalConDescuento * ivaRate) : 0m;
                decimal total = subtotalConDescuento + iva;

                // ✅ ACTUALIZAR VALORES EN LA FILA
                fila.Cells["colSubtotal"].Value = subtotalConDescuento;
                fila.Cells["colIVA"].Value = iva;
                fila.Cells["colTotal"].Value = total;

                // ✅ FORMATEAR VALORES
                fila.Cells["colPFinal"].Value = precioFinal;
                fila.Cells["colSubtotal"].Value = subtotalConDescuento;
                fila.Cells["colIVA"].Value = iva;
                fila.Cells["colTotal"].Value = total;

                // ✅ LLAMAR A CALCULAR TOTALES GENERALES AUTOMÁTICAMENTE
                CalcularTotalesGenerales();
            }
            catch (FormatException)
            {
                // Manejo de errores silencioso
            }
        }

        private void CalcularTotalesGenerales()
        {
            decimal subtotalIva = 0m;
            decimal subtotalExento = 0m;
            decimal rowDiscountTotal = 0m;

            foreach (DataGridViewRow fila in dgvDetalleVenta.Rows)
            {
                if (fila.IsNewRow) continue;

                decimal.TryParse(fila.Cells["colSubtotal"].Value?.ToString(), out decimal rowSubtotal);
                decimal.TryParse(fila.Cells["colDscto"].Value?.ToString(), out decimal rowDsctoPorc);
                decimal.TryParse(fila.Cells["colPFinal"].Value?.ToString(), out decimal precioFinal);
                decimal.TryParse(fila.Cells["colCantidad"].Value?.ToString(), out decimal cantidad);

                bool rowAplicaIva = true;
                if (_ventaActual != null && _ventaActual.DesactivarIva)
                {
                    rowAplicaIva = false;
                }
                else if (fila.Tag != null)
                {
                    long prodId = Convert.ToInt64(fila.Tag);
                    if (_productosAplicaIva.ContainsKey(prodId))
                    {
                        rowAplicaIva = _productosAplicaIva[prodId];
                    }
                }

                if (rowAplicaIva)
                {
                    subtotalIva += rowSubtotal;
                }
                else
                {
                    subtotalExento += rowSubtotal;
                }

                decimal subtotalSinDescuento = cantidad * precioFinal;
                rowDiscountTotal += subtotalSinDescuento * (rowDsctoPorc / 100);
            }

            decimal subtotalGeneral = subtotalIva + subtotalExento;

            decimal generalDsctoPorc = _ventaActual != null ? _ventaActual.Descuento : 0m;
            decimal generalDsctoRatio = generalDsctoPorc / 100m;
            decimal generalDiscountAmount = subtotalGeneral * generalDsctoRatio;

            decimal subtotalIvaWithDiscount = subtotalIva * (1m - generalDsctoRatio);
            decimal subtotalExentoWithDiscount = subtotalExento * (1m - generalDsctoRatio);

            decimal ivaRate = ImpuestoProvider.GetIVA();
            decimal ivaGeneral = subtotalIvaWithDiscount * ivaRate;

            decimal totalGeneral = subtotalIvaWithDiscount + subtotalExentoWithDiscount + ivaGeneral;
            decimal totalDescuento = rowDiscountTotal + generalDiscountAmount;

            _totalGeneral = totalGeneral;

            // Actualizar labels de precios principales
            if (this.lblPrecio != null) this.lblPrecio.Text = totalGeneral.ToString("N2");
            if (this.lblPrecioEfe != null) this.lblPrecioEfe.Text = (totalGeneral * 0.9m).ToString("N2");
            if (this.lblPrecioTar != null) this.lblPrecioTar.Text = (totalGeneral * 1.1m).ToString("N2");

            // Labels de desglose
            if (this.lblTarifa15 != null) this.lblTarifa15.Text = subtotalIvaWithDiscount.ToString("N2");
            if (this.lblTarifa0 != null) this.lblTarifa0.Text = subtotalExentoWithDiscount.ToString("N2");
            if (this.lblTotalDescuento != null) this.lblTotalDescuento.Text = totalDescuento.ToString("N2");
            if (this.lblIVA != null) this.lblIVA.Text = ivaGeneral.ToString("N2");
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

