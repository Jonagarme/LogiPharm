using LogiPharm.Datos;
using LogiPharm.Entidades; // <-- importa tu entidad
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LogiPharm.Presentacion
{
    public partial class FrmEditarProducto : Form
    {
        private readonly int _idProducto;

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

        public FrmEditarProducto(int idProducto)
        {
            InitializeComponent();
            _idProducto = idProducto;
            this.Load += FrmEditarProducto_Load;
        }

        private void FrmEditarProducto_Load(object sender, EventArgs e)
        {
            // 1) cargo datos generales + dejo el objeto guardado
            CargarDatosProducto(_idProducto);

            // 2) preparo layout de la pestaña PRECIOS
            dgvPrecios.Visible = false;             // oculto grid para que no tape el TLP
            dgvPrecios.Dock = DockStyle.Fill;

            tableLayoutPanel1.Visible = true;
            tableLayoutPanel1.Dock = DockStyle.Top; // importante: top para que no tape
            tableLayoutPanel1.Height = 30 + 28 + 32 + 2;

            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
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

            tableLayoutPanel1.ResumeLayout(true);
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

            // 2) Validación de PVP (el costoCaja se calculará en BD)
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

            // 3) Chequeo de margen opcional
            //    Si usas la regla costoUnidad = PVP * 0.7, podemos advertir si el PVP
            //    cae por debajo del mínimo deseado (MARGEN_MINIMO sobre costoUnidad).
            //    costoBase: costoUnidad calculado con el nuevo PVP
            decimal costoBase = Math.Round(pvp * 0.7m, DECIMALES); // ajusta 0.7 si cambia tu política
            if (costoBase > 0)
            {
                var pvpMinimo = Math.Round(costoBase * (1 + MARGEN_MINIMO), DECIMALES);
                if (pvp < pvpMinimo)
                {
                    var msg = MARGEN_MINIMO > 0
                        ? $"El PVP mínimo permitido con margen {MARGEN_MINIMO:P0} es {pvpMinimo:F4}. ¿Deseas continuar?"
                        : $"El PVP ({pvp:F4}) es menor al costo base ({costoBase:F4}). ¿Deseas continuar?";

                    if (MessageBox.Show(msg, "PVP por debajo del costo",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    {
                        _txtPvp?.Focus();
                        return;
                    }
                }
            }

            // 4) Guardar (se calculan y actualizan todos los campos en la BD)
            try
            {
                var dProd = new DProductos();

                // Este método debe existir en tu DProductos (te lo pasé antes):
                // Actualiza: precioVenta, pvpUnidad, costoUnidad, costoCaja
                bool okPrecios = dProd.ActualizarPreciosAutoPorId(_idProducto, pvp);

                if (!okPrecios)
                {
                    MessageBox.Show("No se pudo actualizar los precios del producto.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("Producto modificado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar",
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

        // =======================
        // Helpers de UI (precios)
        // =======================
        private Label Header(string t) => new Label
        {
            Text = t,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold)
        };
        private Label Sub(string t) => new Label
        {
            Text = t,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 9F)
        };
        private Label CellLabel(string t) => new Label
        {
            Text = t,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 9F)
        };
        private TextBox CellTextBox(string t) => new TextBox
        {
            Text = t,
            Dock = DockStyle.Fill,
            TextAlign = HorizontalAlignment.Right,
            Font = new Font("Segoe UI", 9F)
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
