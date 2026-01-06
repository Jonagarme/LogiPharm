using LogiPharm.Datos;
using LogiPharm.Entidades; // <-- importa tu entidad
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LogiPharm.Presentacion
{
    public partial class FrmEditarProducto : Form
    {
        private readonly int _idProducto;
        private readonly bool _esNuevo; // true = modo creación, false = modo edición

        // guardo el producto para usar sus valores luego de construir la UI
        private EProducto _producto;

        // === PRECIOS (campos que usaremos en validación/guardado) ===
        private TextBox _txtCostoCaja;
        private TextBox _txtPvp;
        private Label _lblCostoUnidad;         // solo lectura (muestra)
        private Label _lblCostoPonderadoUni;   // solo lectura (muestra)
        private Label _lblPvpUnidad;           // solo lectura (muestra)

        private const int DECIMALES = 4;
        private const decimal PRECIO_MIN = 0m;
        private const decimal COSTO_MIN = 0m;
        private const decimal MARGEN_MINIMO = 0.00m; // 0 => solo que PVP >= costo

        // Constructor para EDITAR producto existente
        public FrmEditarProducto(int idProducto)
        {
            InitializeComponent();
            _idProducto = idProducto;
            _esNuevo = false;
            InicializarEventos();
        }

        // Constructor para CREAR nuevo producto
        public FrmEditarProducto()
        {
            InitializeComponent();
            _idProducto = 0;
            _esNuevo = true;
            InicializarEventos();
        }

        private void InicializarEventos()
        {
            this.Load += FrmEditarProducto_Load;
            btnAgregarLote.Click += btnAgregarLote_Click;
            btnFiltrarCaducidad.Click += btnFiltrarCaducidad_Click;
            numStockMinimo.ValueChanged += numStockMinimo_ValueChanged;
            numStockMaximo.ValueChanged += numStockMaximo_ValueChanged;
            
            // Eventos para el grid de caducidades
            dgvCaducidades.CellMouseDown += dgvCaducidades_CellMouseDown;
            dgvCaducidades.KeyDown += dgvCaducidades_KeyDown;
        }

        private void FrmEditarProducto_Load(object sender, EventArgs e)
        {
            ConfigurarTablas();

            // Cambiar título según modo
            this.Text = _esNuevo ? "Crear Nuevo Producto" : "Editar Producto";
            btnModificar.Text = _esNuevo ? "Guardar" : "Modificar";

            // 1) cargo datos generales (solo si es edición)
            if (!_esNuevo)
            {
                CargarDatosProducto(_idProducto);
            }
            else
            {
                // Modo creación: inicializar producto vacío
                _producto = new EProducto
                {
                    Stock = 0,
                    StockMinimo = 10,
                    StockMaximo = 100,
                    CostoUnidad = 0,
                    CostoCaja = 0,
                    PvpUnidad = 0,
                    PrecioVenta = 0,
                    Activo = true
                };

                numStockMinimo.Value = _producto.StockMinimo;
                numStockMaximo.Value = _producto.StockMaximo;
            }

            // 2) preparo layout de la pestaña PRECIOS
            dgvPrecios.Visible = false;             // oculto grid para que no tape el TLP
            dgvPrecios.Dock = DockStyle.Fill;

            tableLayoutPanel1.Visible = true;
            tableLayoutPanel1.Dock = DockStyle.Top; // importante: top para que no tape
            tableLayoutPanel1.Height = 30 + 28 + 32 + 2;

            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            tableLayoutPanel1.BackColor = Color.White;
            tableLayoutPanel1.Padding = new Padding(5);
            tableLayoutPanel1.Margin = new Padding(0, 15, 0, 0);
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();

            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.ColumnCount = 7;
            for (int i = 0; i < 7; i++)
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 7));

            // ----- fila 1: headers agrupados
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            var h1 = Header("UNIDAD NEGOCIO"); tableLayoutPanel1.Controls.Add(h1, 0, 0);
            var h2 = Header("ÚLTIMO COSTO COMPRA"); tableLayoutPanel1.Controls.Add(h2, 1, 0); tableLayoutPanel1.SetColumnSpan(h2, 2);
            var h3 = Header("COSTO PONDERADO"); tableLayoutPanel1.Controls.Add(h3, 3, 0); tableLayoutPanel1.SetColumnSpan(h3, 2);
            var h4 = Header("PRECIO DE VENTA"); tableLayoutPanel1.Controls.Add(h4, 5, 0); tableLayoutPanel1.SetColumnSpan(h4, 2);

            // ----- fila 2: subheaders
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tableLayoutPanel1.Controls.Add(Sub("UNIDAD DE NEGOCIO"), 0, 1);
            tableLayoutPanel1.Controls.Add(Sub("COSTO UNIDAD"), 1, 1);
            tableLayoutPanel1.Controls.Add(Sub("COSTO CAJA"), 2, 1);
            tableLayoutPanel1.Controls.Add(Sub("COSTO UNIDAD"), 3, 1);
            tableLayoutPanel1.Controls.Add(Sub("COSTO CAJA"), 4, 1);
            tableLayoutPanel1.Controls.Add(Sub("PVP UNIDAD"), 5, 1);
            tableLayoutPanel1.Controls.Add(Sub("PVP"), 6, 1);

            // ----- fila 3: valores (labels + 2 textbox editables)
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));

            var lblUnidadNegocioValor = CellLabel("MATRIZ"); // si luego tienes la U.N., cámbialo
            _lblCostoUnidad = CellLabel("0.0000");
            _txtCostoCaja = CellTextBox("0.0000");        // EDITABLE
            _lblCostoPonderadoUni = CellLabel("0.0000");  // si no hay ponderado, mostramos costo unidad
            var txtCostoPondCaja = CellTextBox("0.0000"); // solo lectura
            txtCostoPondCaja.ReadOnly = true;
            _lblPvpUnidad = CellLabel("0.0000");
            _txtPvp = CellTextBox("0.0000");              // EDITABLE

            tableLayoutPanel1.Controls.Add(lblUnidadNegocioValor, 0, 2);
            tableLayoutPanel1.Controls.Add(_lblCostoUnidad, 1, 2);
            tableLayoutPanel1.Controls.Add(_txtCostoCaja, 2, 2);
            tableLayoutPanel1.Controls.Add(_lblCostoPonderadoUni, 3, 2);
            tableLayoutPanel1.Controls.Add(txtCostoPondCaja, 4, 2);
            tableLayoutPanel1.Controls.Add(_lblPvpUnidad, 5, 2);
            tableLayoutPanel1.Controls.Add(_txtPvp, 6, 2);

            // 3) pongo los valores REALES del producto
            if (_producto != null)
            {
                _lblCostoUnidad.Text = _producto.CostoUnidad.ToString($"F{DECIMALES}");
                _txtCostoCaja.Text = _producto.CostoCaja.ToString($"F{DECIMALES}");
                _lblPvpUnidad.Text = _producto.PvpUnidad.ToString($"F{DECIMALES}");
                _txtPvp.Text = _producto.PrecioVenta.ToString($"F{DECIMALES}");

                // si no manejas costo ponderado, muéstralo igual que costo unidad
                _lblCostoPonderadoUni.Text = _producto.CostoUnidad.ToString($"F{DECIMALES}");
                txtCostoPondCaja.Text = _producto.CostoCaja.ToString($"F{DECIMALES}");
            }

            // 4) validaciones y formato
            _txtCostoCaja.KeyPress += SoloDecimal_KeyPress;
            _txtPvp.KeyPress += SoloDecimal_KeyPress;
            _txtCostoCaja.Leave += FormatearDecimales_Leave;
            _txtPvp.Leave += FormatearDecimales_Leave;
            _txtPvp.TextChanged += _txtPvp_TextChanged;

            tableLayoutPanel1.ResumeLayout(true);

            ActualizarStockCards();
            CargarMovimientosStock();
        }

        private void CargarDatosProducto(int id)
        {
            var dProductos = new DProductos();
            var producto = dProductos.ObtenerPorId(id);
            _producto = producto; // <-- lo guardo para la pestaña de precios

            if (producto == null)
            {
                MessageBox.Show("No se encontró el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // datos generales
            cboTipo.SelectedValue = producto.IdTipoProducto;
            txtNombre.Text = producto.Nombre;
            cboClase.SelectedValue = producto.IdClaseProducto;
            cboCategoria.SelectedValue = producto.IdCategoria;
            cboSubcategoria.SelectedValue = producto.IdSubcategoria;
            cboSubnivel.SelectedValue = producto.IdSubnivel ?? -1;
            cboLaboratorio.SelectedValue = producto.IdLaboratorio ?? -1;
            cboMarca.SelectedValue = producto.IdMarca;
            txtCodigoPrincipal.Text = producto.CodigoPrincipal;
            txtCodigoAuxiliar.Text = producto.CodigoAuxiliar ?? "";
            txtRegistroSanitario.Text = producto.RegistroSanitario ?? "";
            txtObservaciones.Text = producto.Observaciones ?? "";

            numStockMinimo.Value = producto.StockMinimo;
            numStockMaximo.Value = producto.StockMaximo;
            cboClasificacionABC.SelectedValue = producto.ClasificacionABC ?? "";

            chkDivisible.Checked = producto.EsDivisible;
            chkPsicotropico.Checked = producto.EsPsicotropico;
            chkCalculoABC.Checked = producto.CalculoABCManual;
            chkCadenaFrio.Checked = producto.RequiereCadenaFrio;
            chkSeguimiento.Checked = producto.RequiereSeguimiento;

            // impuestos demo
            CargarImpuestosDelProducto(id);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // 1) Validación básica de datos generales
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del producto es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCodigoPrincipal.Text))
            {
                MessageBox.Show("El código principal es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigoPrincipal.Focus();
                return;
            }

            // 2) Validación de PVP
            if (!TryGetDecimal(_txtPvp?.Text, out decimal pvp))
            {
                MessageBox.Show("PVP inválido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _txtPvp?.Focus();
                return;
            }
            if (pvp < PRECIO_MIN)
            {
                MessageBox.Show("El PVP no puede ser negativo.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _txtPvp?.Focus();
                return;
            }

            try
            {
                var dProd = new DProductos();

                if (_esNuevo)
                {
                    // MODO CREACIÓN
                    var nuevoProducto = new EProducto
                    {
                        Nombre = txtNombre.Text.Trim(),
                        CodigoPrincipal = txtCodigoPrincipal.Text.Trim(),
                        CodigoAuxiliar = txtCodigoAuxiliar.Text.Trim(),
                        RegistroSanitario = txtRegistroSanitario.Text.Trim(),
                        Observaciones = txtObservaciones.Text.Trim(),
                        
                        IdTipoProducto = cboTipo.SelectedValue != null ? Convert.ToInt32(cboTipo.SelectedValue) : 1,
                        IdClaseProducto = cboClase.SelectedValue != null ? Convert.ToInt32(cboClase.SelectedValue) : 1,
                        IdCategoria = cboCategoria.SelectedValue != null ? Convert.ToInt32(cboCategoria.SelectedValue) : 1,
                        IdSubcategoria = cboSubcategoria.SelectedValue != null ? Convert.ToInt32(cboSubcategoria.SelectedValue) : 1,
                        IdMarca = cboMarca.SelectedValue != null ? Convert.ToInt32(cboMarca.SelectedValue) : 1,
                        IdSubnivel = cboSubnivel.SelectedValue != null ? (int?)Convert.ToInt32(cboSubnivel.SelectedValue) : null,
                        IdLaboratorio = cboLaboratorio.SelectedValue != null ? (int?)Convert.ToInt32(cboLaboratorio.SelectedValue) : null,
                        ClasificacionABC = cboClasificacionABC.SelectedItem?.ToString(),
                        
                        StockMinimo = numStockMinimo.Value,
                        StockMaximo = numStockMaximo.Value,
                        Stock = 0, // Stock inicial en 0
                        
                        PrecioVenta = pvp,
                        PvpUnidad = pvp,
                        CostoUnidad = Math.Round(pvp * 0.7m, DECIMALES),
                        CostoCaja = 0,
                        
                        EsDivisible = chkDivisible.Checked,
                        EsPsicotropico = chkPsicotropico.Checked,
                        RequiereCadenaFrio = chkCadenaFrio.Checked,
                        RequiereSeguimiento = chkSeguimiento.Checked,
                        CalculoABCManual = chkCalculoABC.Checked,
                        Activo = true,
                        
                        CreadoPor = Utilidades.SesionActual.IdUsuario
                    };

                    bool ok = dProd.InsertarProducto(nuevoProducto);
                    
                    if (!ok)
                    {
                        MessageBox.Show("No se pudo crear el producto.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    MessageBox.Show("Producto creado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // MODO EDICIÓN
                    bool okPrecios = dProd.ActualizarPreciosAutoPorId(_idProducto, pvp);

                    if (!okPrecios)
                    {
                        MessageBox.Show("No se pudo actualizar los precios del producto.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    MessageBox.Show("Producto modificado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CargarImpuestosDelProducto(int idProducto)
        {
            dgvImpuestos.Rows.Clear();

            int rowIndex = dgvImpuestos.Rows.Add();
            DataGridViewRow nuevaFila = dgvImpuestos.Rows[rowIndex];

            DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)nuevaFila.Cells["colImpuesto"];
            comboCell.Items.Add("IVA 0");
            comboCell.Items.Add("IVA 12%");
            comboCell.Value = "IVA 0";

            nuevaFila.Cells["colAplicaCompra"].Value = true;
            nuevaFila.Cells["colAplicaVenta"].Value = true;
        }

        private void ConfigurarTablas()
        {
            if (dgvStockMovimientos != null)
            {
                dgvStockMovimientos.AutoGenerateColumns = false;
                if (colStockFecha != null) colStockFecha.DataPropertyName = "Fecha";
                if (colStockTipo != null) colStockTipo.DataPropertyName = "TipoMovimiento";
                if (colStockCantidad != null) colStockCantidad.DataPropertyName = "Cantidad";
                if (colStockSaldo != null) colStockSaldo.DataPropertyName = "Saldo";
            }

            if (dgvCaducidades != null)
            {
                dgvCaducidades.AutoGenerateColumns = false;
                if (colCaducidadFecha != null)
                {
                    colCaducidadFecha.DefaultCellStyle.Format = "dd/MM/yyyy";
                }
                
                // Permitir selección múltiple para eliminar varios lotes
                dgvCaducidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvCaducidades.MultiSelect = true;
            }
        }

        private void ActualizarStockCards()
        {
            decimal stockActual = _producto?.Stock ?? 0m;
            lblStockActualValue.Text = stockActual.ToString("N2");
            lblStockMinValue.Text = numStockMinimo.Value.ToString("N0");
            lblStockMaxValue.Text = numStockMaximo.Value.ToString("N0");
        }

        private void numStockMinimo_ValueChanged(object sender, EventArgs e)
        {
            if (_producto != null)
            {
                _producto.StockMinimo = numStockMinimo.Value;
            }
            ActualizarStockCards();
        }

        private void numStockMaximo_ValueChanged(object sender, EventArgs e)
        {
            if (_producto != null)
            {
                _producto.StockMaximo = numStockMaximo.Value;
            }
            ActualizarStockCards();
        }

        private void CargarMovimientosStock()
        {
            dgvStockMovimientos.DataSource = null;

            if (_producto == null || _producto.Id <= 0)
            {
                dgvStockMovimientos.Rows.Clear();
                return;
            }

            try
            {
                var kardex = new DKardex();
                var desde = DateTime.Today.AddMonths(-3);
                var movimientos = kardex.ObtenerMovimientos((int)_producto.Id, desde, DateTime.Today);

                if (movimientos != null && movimientos.Rows.Count > 0)
                {
                    var tabla = new DataTable();
                    tabla.Columns.Add("Fecha", typeof(DateTime));
                    tabla.Columns.Add("TipoMovimiento", typeof(string));
                    tabla.Columns.Add("Cantidad", typeof(decimal));
                    tabla.Columns.Add("Saldo", typeof(decimal));

                    foreach (DataRow row in movimientos.Rows)
                    {
                        decimal ingreso = row.Table.Columns.Contains("Ingreso") && row["Ingreso"] != DBNull.Value
                            ? Convert.ToDecimal(row["Ingreso"])
                            : 0m;
                        decimal egreso = row.Table.Columns.Contains("Egreso") && row["Egreso"] != DBNull.Value
                            ? Convert.ToDecimal(row["Egreso"])
                            : 0m;
                        decimal cantidad = ingreso != 0m ? ingreso : (egreso != 0m ? -egreso : 0m);

                        tabla.Rows.Add(
                            row["Fecha"],
                            row["TipoMovimiento"],
                            cantidad,
                            row["Saldo"]);
                    }

                    dgvStockMovimientos.DataSource = tabla;
                }
                else
                {
                    dgvStockMovimientos.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                dgvStockMovimientos.Rows.Clear();
                System.Diagnostics.Debug.WriteLine($"No se pudo cargar el kardex: {ex.Message}");
            }
        }

        private void btnAgregarLote_Click(object sender, EventArgs e)
        {
            if (!TryCapturarNuevoLote(out var info))
            {
                return;
            }

            foreach (DataGridViewRow row in dgvCaducidades.Rows)
            {
                if (row.IsNewRow) continue;
                var existente = Convert.ToString(row.Cells["colCaducidadLote"].Value);
                if (!string.IsNullOrWhiteSpace(existente) && existente.Equals(info.Lote, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(this, "Ya existe un lote con el mismo identificador.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            int index = dgvCaducidades.Rows.Add(
                info.Lote,
                info.FechaCaducidad,
                info.Cantidad,
                info.Estado);

            if (index >= 0)
            {
                dgvCaducidades.ClearSelection();
                dgvCaducidades.Rows[index].Selected = true;
            }
        }

        private void btnFiltrarCaducidad_Click(object sender, EventArgs e)
        {
            DateTime desde = dtpCaducidadDesde.Value.Date;
            DateTime hasta = dtpCaducidadHasta.Value.Date;

            if (hasta < desde)
            {
                MessageBox.Show(this, "La fecha final debe ser mayor o igual a la fecha inicial.", "Rango inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in dgvCaducidades.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                var valor = row.Cells["colCaducidadFecha"].Value;
                DateTime fecha;

                if (valor is DateTime fechaValida)
                {
                    fecha = fechaValida.Date;
                }
                else if (!DateTime.TryParse(Convert.ToString(valor), out fecha))
                {
                    row.Visible = true;
                    continue;
                }

                row.Visible = fecha >= desde && fecha <= hasta;
            }
        }

        private bool TryCapturarNuevoLote(out CaducidadLoteInfo info)
        {
            CaducidadLoteInfo tempInfo = null;

            using (var dialog = new Form())
            {
                dialog.Text = "Registrar lote";
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.MaximizeBox = false;
                dialog.MinimizeBox = false;
                dialog.ShowInTaskbar = false;
                dialog.ClientSize = new Size(360, 230);

                var lblLote = new Label { Text = "* Lote", Left = 20, Top = 15, Width = 150 };
                var txtLote = new TextBox { Left = 20, Top = 35, Width = 300 };

                var lblFecha = new Label { Text = "* Fecha de caducidad", Left = 20, Top = 70, Width = 160 };
                var dtpFecha = new DateTimePicker
                {
                    Left = 20,
                    Top = 90,
                    Width = 150,
                    Format = DateTimePickerFormat.Short,
                    MinDate = DateTime.Today
                };

                var lblCantidad = new Label { Text = "* Cantidad", Left = 190, Top = 70, Width = 120 };
                var numCantidad = new NumericUpDown
                {
                    Left = 190,
                    Top = 90,
                    Width = 130,
                    Minimum = 1,
                    Maximum = 100000,
                    Value = 1,
                    TextAlign = HorizontalAlignment.Right
                };

                var lblEstado = new Label { Text = "Estado", Left = 20, Top = 125, Width = 120 };
                var cboEstado = new ComboBox
                {
                    Left = 20,
                    Top = 145,
                    Width = 300,
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                cboEstado.Items.AddRange(new[] { "Disponible", "Comprometido", "Agotado" });
                cboEstado.SelectedIndex = 0;

                var btnAceptar = new Button { Text = "Agregar", Left = 140, Width = 90, Top = 180, DialogResult = DialogResult.None };
                var btnCancelar = new Button { Text = "Cancelar", Left = 230, Width = 90, Top = 180, DialogResult = DialogResult.Cancel };

                btnAceptar.Click += (s, e) =>
                {
                    if (string.IsNullOrWhiteSpace(txtLote.Text))
                    {
                        MessageBox.Show(dialog, "Ingrese el código del lote.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtLote.Focus();
                        return;
                    }

                    tempInfo = new CaducidadLoteInfo
                    {
                        Lote = txtLote.Text.Trim(),
                        FechaCaducidad = dtpFecha.Value.Date,
                        Cantidad = (int)numCantidad.Value,
                        Estado = cboEstado.SelectedItem?.ToString() ?? "Disponible"
                    };

                    dialog.DialogResult = DialogResult.OK;
                    dialog.Close();
                };

                dialog.Controls.AddRange(new Control[]
                {
                    lblLote, txtLote,
                    lblFecha, dtpFecha,
                    lblCantidad, numCantidad,
                    lblEstado, cboEstado,
                    btnAceptar, btnCancelar
                });

                dialog.AcceptButton = btnAceptar;
                dialog.CancelButton = btnCancelar;

                if (dialog.ShowDialog(this) == DialogResult.OK && tempInfo != null)
                {
                    info = tempInfo;
                    return true;
                }
            }

            info = null;
            return false;
        }

        private sealed class CaducidadLoteInfo
        {
            public string Lote { get; set; }
            public DateTime FechaCaducidad { get; set; }
            public int Cantidad { get; set; }
            public string Estado { get; set; }
        }

        // =======================
        // Edición y eliminación de lotes
        // =======================
        private void dgvCaducidades_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvCaducidades.ClearSelection();
                dgvCaducidades.Rows[e.RowIndex].Selected = true;
                
                var menuContexto = new ContextMenuStrip();
                
                var menuEditar = new ToolStripMenuItem("✏️ Editar lote", null, (s, ev) => EditarLoteSeleccionado());
                menuEditar.ShortcutKeyDisplayString = "F2";
                
                var menuEliminar = new ToolStripMenuItem("🗑️ Eliminar lote(s)", null, (s, ev) => EliminarLotesSeleccionados());
                menuEliminar.ShortcutKeyDisplayString = "Del";
                
                menuContexto.Items.Add(menuEditar);
                menuContexto.Items.Add(menuEliminar);
                menuContexto.Items.Add(new ToolStripSeparator());
                menuContexto.Items.Add("📋 Copiar información", null, (s, ev) => CopiarInfoLote());
                
                menuContexto.Show(dgvCaducidades, dgvCaducidades.PointToClient(Cursor.Position));
            }
        }

        private void dgvCaducidades_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                EditarLoteSeleccionado();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                EliminarLotesSeleccionados();
                e.Handled = true;
            }
        }

        private void EditarLoteSeleccionado()
        {
            if (dgvCaducidades.SelectedRows.Count != 1)
            {
                MessageBox.Show(this, "Seleccione un solo lote para editar.", "Editar lote", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvCaducidades.SelectedRows[0];
            if (row.IsNewRow) return;

            var loteActual = Convert.ToString(row.Cells["colCaducidadLote"].Value);
            var fechaActual = row.Cells["colCaducidadFecha"].Value is DateTime dt 
                ? dt 
                : DateTime.TryParse(Convert.ToString(row.Cells["colCaducidadFecha"].Value), out var parsed) 
                    ? parsed 
                    : DateTime.Today;
            var cantidadActual = Convert.ToInt32(row.Cells["colCaducidadCantidad"].Value ?? 0);
            var estadoActual = Convert.ToString(row.Cells["colCaducidadEstado"].Value ?? "Disponible");

            if (TryEditarLote(loteActual, fechaActual, cantidadActual, estadoActual, out var infoEditada))
            {
                // Validar que no exista otro lote con el mismo código (excepto el actual)
                foreach (DataGridViewRow r in dgvCaducidades.Rows)
                {
                    if (r.IsNewRow || r.Index == row.Index) continue;
                    var existente = Convert.ToString(r.Cells["colCaducidadLote"].Value);
                    if (!string.IsNullOrWhiteSpace(existente) && 
                        existente.Equals(infoEditada.Lote, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show(this, "Ya existe otro lote con ese identificador.", 
                            "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                row.Cells["colCaducidadLote"].Value = infoEditada.Lote;
                row.Cells["colCaducidadFecha"].Value = infoEditada.FechaCaducidad;
                row.Cells["colCaducidadCantidad"].Value = infoEditada.Cantidad;
                row.Cells["colCaducidadEstado"].Value = infoEditada.Estado;
                
                MessageBox.Show(this, "Lote actualizado correctamente.", "Editar lote", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EliminarLotesSeleccionados()
        {
            if (dgvCaducidades.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "Seleccione al menos un lote para eliminar.", "Eliminar lote(s)", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int count = dgvCaducidades.SelectedRows.Count;
            string mensaje = count == 1 
                ? "¿Está seguro de eliminar este lote?" 
                : $"¿Está seguro de eliminar {count} lotes seleccionados?";

            var confirmacion = MessageBox.Show(this, mensaje, "Confirmar eliminación", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                // Eliminar en orden inverso para evitar problemas de índices
                var rowsToDelete = dgvCaducidades.SelectedRows.Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow)
                    .OrderByDescending(r => r.Index)
                    .ToList();

                foreach (var row in rowsToDelete)
                {
                    dgvCaducidades.Rows.Remove(row);
                }

                MessageBox.Show(this, $"{count} lote(s) eliminado(s) correctamente.", "Eliminar lote(s)", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CopiarInfoLote()
        {
            if (dgvCaducidades.SelectedRows.Count != 1) return;
            
            var row = dgvCaducidades.SelectedRows[0];
            if (row.IsNewRow) return;

            var lote = Convert.ToString(row.Cells["colCaducidadLote"].Value);
            var fecha = row.Cells["colCaducidadFecha"].Value is DateTime dt 
                ? dt.ToString("dd/MM/yyyy") 
                : Convert.ToString(row.Cells["colCaducidadFecha"].Value);
            var cantidad = Convert.ToString(row.Cells["colCaducidadCantidad"].Value);
            var estado = Convert.ToString(row.Cells["colCaducidadEstado"].Value);

            string info = $"Lote: {lote}\nFecha: {fecha}\nCantidad: {cantidad}\nEstado: {estado}";
            Clipboard.SetText(info);
            
            MessageBox.Show(this, "Información copiada al portapapeles.", "Copiar", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool TryEditarLote(string loteActual, DateTime fechaActual, int cantidadActual, 
            string estadoActual, out CaducidadLoteInfo info)
        {
            CaducidadLoteInfo tempInfo = null;

            using (var dialog = new Form())
            {
                dialog.Text = "Editar lote";
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.MaximizeBox = false;
                dialog.MinimizeBox = false;
                dialog.ShowInTaskbar = false;
                dialog.ClientSize = new Size(360, 230);

                var lblLote = new Label { Text = "* Lote", Left = 20, Top = 15, Width = 150 };
                var txtLote = new TextBox { Left = 20, Top = 35, Width = 300, Text = loteActual };

                var lblFecha = new Label { Text = "* Fecha de caducidad", Left = 20, Top = 70, Width = 160 };
                var dtpFecha = new DateTimePicker
                {
                    Left = 20,
                    Top = 90,
                    Width = 150,
                    Format = DateTimePickerFormat.Short,
                    MinDate = DateTime.Today,
                    Value = fechaActual >= DateTime.Today ? fechaActual : DateTime.Today
                };

                var lblCantidad = new Label { Text = "* Cantidad", Left = 190, Top = 70, Width = 120 };
                var numCantidad = new NumericUpDown
                {
                    Left = 190,
                    Top = 90,
                    Width = 130,
                    Minimum = 1,
                    Maximum = 100000,
                    Value = cantidadActual > 0 ? cantidadActual : 1,
                    TextAlign = HorizontalAlignment.Right
                };

                var lblEstado = new Label { Text = "Estado", Left = 20, Top = 125, Width = 120 };
                var cboEstado = new ComboBox
                {
                    Left = 20,
                    Top = 145,
                    Width = 300,
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                cboEstado.Items.AddRange(new[] { "Disponible", "Comprometido", "Agotado" });
                
                int selectedIndex = cboEstado.Items.IndexOf(estadoActual);
                cboEstado.SelectedIndex = selectedIndex >= 0 ? selectedIndex : 0;

                var btnAceptar = new Button { Text = "Guardar", Left = 140, Width = 90, Top = 180, DialogResult = DialogResult.None };
                var btnCancelar = new Button { Text = "Cancelar", Left = 230, Width = 90, Top = 180, DialogResult = DialogResult.Cancel };

                btnAceptar.Click += (s, e) =>
                {
                    if (string.IsNullOrWhiteSpace(txtLote.Text))
                    {
                        MessageBox.Show(dialog, "Ingrese el código del lote.", "Validación", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtLote.Focus();
                        return;
                    }

                    tempInfo = new CaducidadLoteInfo
                    {
                        Lote = txtLote.Text.Trim(),
                        FechaCaducidad = dtpFecha.Value.Date,
                        Cantidad = (int)numCantidad.Value,
                        Estado = cboEstado.SelectedItem?.ToString() ?? "Disponible"
                    };

                    dialog.DialogResult = DialogResult.OK;
                    dialog.Close();
                };

                dialog.Controls.AddRange(new Control[]
                {
                    lblLote, txtLote,
                    lblFecha, dtpFecha,
                    lblCantidad, numCantidad,
                    lblEstado, cboEstado,
                    btnAceptar, btnCancelar
                });

                dialog.AcceptButton = btnAceptar;
                dialog.CancelButton = btnCancelar;

                if (dialog.ShowDialog(this) == DialogResult.OK && tempInfo != null)
                {
                    info = tempInfo;
                    return true;
                }
            }

            info = null;
            return false;
        }

        // =======================
        // Helpers de UI (precios)
        // =======================
        private Label Header(string t) => new Label
        {
            Text = t,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            ForeColor = Color.White,
            BackColor = Color.FromArgb(0, 122, 204),
            Margin = new Padding(2),
            Padding = new Padding(0, 4, 0, 4)
        };
        private Label Sub(string t) => new Label
        {
            Text = t,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
            ForeColor = Color.FromArgb(57, 72, 93),
            BackColor = Color.FromArgb(240, 244, 249),
            Margin = new Padding(2),
            Padding = new Padding(0, 4, 0, 4)
        };
        private Label CellLabel(string t) => new Label
        {
            Text = t,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 9F, FontStyle.Bold),
            ForeColor = Color.FromArgb(33, 37, 41),
            BackColor = Color.White,
            Margin = new Padding(4),
            Padding = new Padding(0, 6, 0, 6)
        };
        private TextBox CellTextBox(string t) => new TextBox
        {
            Text = t,
            Dock = DockStyle.Fill,
            TextAlign = HorizontalAlignment.Right,
            Font = new Font("Segoe UI", 9F, FontStyle.Bold),
            BackColor = Color.FromArgb(248, 250, 252),
            BorderStyle = BorderStyle.FixedSingle,
            Margin = new Padding(6, 4, 6, 4)
        };

        // =======================
        // Validaciones numéricas
        // =======================
        private void SoloDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
                return;
            }

            var tb = sender as TextBox;
            char sep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            if ((e.KeyChar == '.' || e.KeyChar == ','))
            {
                e.KeyChar = sep;
                if (tb.Text.Contains(sep.ToString()))
                    e.Handled = true;
            }
        }

        private void FormatearDecimales_Leave(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            if (decimal.TryParse(tb.Text, out var v))
                tb.Text = Math.Max(0, v).ToString($"F{DECIMALES}");
            else
                tb.Text = 0m.ToString($"F{DECIMALES}");
        }

        private bool TryGetDecimal(string s, out decimal v) => decimal.TryParse(s, out v);

        private void _txtPvp_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(_txtPvp.Text, out var pvp) || pvp < 0) return;

            var costoUnidad = Math.Round(pvp * 0.7m, DECIMALES);
            _lblCostoUnidad.Text = costoUnidad.ToString($"F{DECIMALES}");
            _lblCostoPonderadoUni.Text = _lblCostoUnidad.Text; // si no manejas uno real

            decimal stock = _producto?.Stock ?? 0m; // usa el stock del producto cargado
            var costoCaja = Math.Round(stock * costoUnidad, DECIMALES);
            _txtCostoCaja.Text = costoCaja.ToString($"F{DECIMALES}");

            _lblPvpUnidad.Text = pvp.ToString($"F{DECIMALES}");
        }

    }
}
