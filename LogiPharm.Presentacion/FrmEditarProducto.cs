using LogiPharm.Datos;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LogiPharm.Presentacion
{
    public partial class FrmEditarProducto : Form
    {
        private readonly int _idProducto; // Usamos readonly para asegurar que el ID no cambie

        public FrmEditarProducto(int idProducto)
        {
            InitializeComponent();
            _idProducto = idProducto; // Guardamos el ID que recibimos
        }

        private void FrmEditarProducto_Load(object sender, EventArgs e)
        {
            CargarDatosProducto(_idProducto);
            // Limpiar controles previos
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.ColumnCount = 7;

            // Definir estilos de columnas (puedes ajustarlos)
            for (int i = 0; i < 7; i++)
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 7));

            // --- FILA 1: Headers Agrupados ---
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            Label lblHeaderUnidadNegocio = new Label()
            {
                Text = "UNIDAD NEGOCIO",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            Label lblHeaderUltimoCosto = new Label()
            {
                Text = "ÚLTIMO COSTO COMPRA",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            Label lblHeaderCostoPond = new Label()
            {
                Text = "COSTO PONDERADO",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            Label lblHeaderPrecioVenta = new Label()
            {
                Text = "PRECIO DE VENTA",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            // Add (header, col, row)
            tableLayoutPanel1.Controls.Add(lblHeaderUnidadNegocio, 0, 0);
            tableLayoutPanel1.SetColumnSpan(lblHeaderUnidadNegocio, 1);

            tableLayoutPanel1.Controls.Add(lblHeaderUltimoCosto, 1, 0);
            tableLayoutPanel1.SetColumnSpan(lblHeaderUltimoCosto, 2);

            tableLayoutPanel1.Controls.Add(lblHeaderCostoPond, 3, 0);
            tableLayoutPanel1.SetColumnSpan(lblHeaderCostoPond, 2);

            tableLayoutPanel1.Controls.Add(lblHeaderPrecioVenta, 5, 0);
            tableLayoutPanel1.SetColumnSpan(lblHeaderPrecioVenta, 2);

            // --- FILA 2: Subheaders ---
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            Label lblSubUnidadNegocio = new Label()
            {
                Text = "UNIDAD DE NEGOCIO",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F)
            };
            Label lblSubCostoUnidad = new Label()
            {
                Text = "COSTO UNIDAD",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F)
            };
            Label lblSubCostoCaja = new Label()
            {
                Text = "COSTO CAJA",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F)
            };
            Label lblSubCostoPondUnidad = new Label()
            {
                Text = "COSTO UNIDAD",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F)
            };
            Label lblSubCostoPondCaja = new Label()
            {
                Text = "COSTO CAJA",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F)
            };
            Label lblSubPvpUnidad = new Label()
            {
                Text = "PVP UNIDAD",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F)
            };
            Label lblSubPvp = new Label()
            {
                Text = "PVP",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F)
            };

            tableLayoutPanel1.Controls.Add(lblSubUnidadNegocio, 0, 1);
            tableLayoutPanel1.Controls.Add(lblSubCostoUnidad, 1, 1);
            tableLayoutPanel1.Controls.Add(lblSubCostoCaja, 2, 1);
            tableLayoutPanel1.Controls.Add(lblSubCostoPondUnidad, 3, 1);
            tableLayoutPanel1.Controls.Add(lblSubCostoPondCaja, 4, 1);
            tableLayoutPanel1.Controls.Add(lblSubPvpUnidad, 5, 1);
            tableLayoutPanel1.Controls.Add(lblSubPvp, 6, 1);

            // --- FILA 3: VALORES (con TextBox donde corresponda) ---
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));

            Label lblUnidadNegocioValor = new Label()
            {
                Text = "MATRIZ",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F)
            };
            Label lblCostoUnidadValor = new Label()
            {
                Text = "2.1501",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F)
            };
            TextBox txtCostoCaja = new TextBox()
            {
                Name = "txtCostoCaja",
                Text = "2.1501",
                TextAlign = HorizontalAlignment.Right,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F)
            };
            Label lblCostoPondUnidadValor = new Label()
            {
                Text = "2.1501",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F)
            };
            TextBox txtCostoPondCaja = new TextBox()
            {
                Name = "txtCostoPonderadoCaja",
                Text = "2.1501",
                TextAlign = HorizontalAlignment.Right,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F)
            };
            Label lblPvpUnidadValor = new Label()
            {
                Text = "3.0000",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F)
            };
            TextBox txtPvp = new TextBox()
            {
                Name = "txtPvp",
                Text = "3.0000",
                TextAlign = HorizontalAlignment.Right,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F)
            };

            tableLayoutPanel1.Controls.Add(lblUnidadNegocioValor, 0, 2);
            tableLayoutPanel1.Controls.Add(lblCostoUnidadValor, 1, 2);
            tableLayoutPanel1.Controls.Add(txtCostoCaja, 2, 2);
            tableLayoutPanel1.Controls.Add(lblCostoPondUnidadValor, 3, 2);
            tableLayoutPanel1.Controls.Add(txtCostoPondCaja, 4, 2);
            tableLayoutPanel1.Controls.Add(lblPvpUnidadValor, 5, 2);
            tableLayoutPanel1.Controls.Add(txtPvp, 6, 2);

        }



        private void CargarDatosProducto(int id)
        {
            // Instancia de la clase de datos
            var dProductos = new DProductos();
            var producto = dProductos.ObtenerPorId(id);

            if (producto == null)
            {
                MessageBox.Show("No se encontró el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Asigna los valores a los controles (ajusta nombres según tu designer)
            cboTipo.SelectedValue = producto.IdTipoProducto;
            txtNombre.Text = producto.Nombre;
            cboClase.SelectedValue = producto.IdClaseProducto;
            cboCategoria.SelectedValue = producto.IdCategoria;
            cboSubcategoria.SelectedValue = producto.IdSubcategoria;
            cboSubnivel.SelectedValue = producto.IdSubnivel ?? -1; // Si permite nulos
            cboLaboratorio.SelectedValue = producto.IdLaboratorio ?? -1; // Si permite nulos
            cboMarca.SelectedValue = producto.IdMarca;
            txtCodigoPrincipal.Text = producto.CodigoPrincipal;
            txtCodigoAuxiliar.Text = producto.CodigoAuxiliar ?? "";
            txtRegistroSanitario.Text = producto.RegistroSanitario ?? "";
            txtObservaciones.Text = producto.Observaciones ?? "";

            // NumericUpDown
            numStockMinimo.Value = producto.StockMinimo;
            numStockMaximo.Value = producto.StockMaximo;

            // ComboBox para ENUM/ABC
            cboClasificacionABC.SelectedValue = producto.ClasificacionABC ?? "";

            // CheckBoxes
            chkDivisible.Checked = producto.EsDivisible;
            chkPsicotropico.Checked = producto.EsPsicotropico;
            chkCalculoABC.Checked = producto.CalculoABCManual;
            chkCadenaFrio.Checked = producto.RequiereCadenaFrio;
            chkSeguimiento.Checked = producto.RequiereSeguimiento;

            // Precio de venta (si tienes un control específico)
            // txtPrecioVenta.Text = producto.PrecioVenta.ToString("N2");

            // Cargar otras pestañas si las tienes...
            CargarImpuestosDelProducto(id);
        }



        private void btnModificar_Click(object sender, EventArgs e)
        {
            // --- TAREA PENDIENTE (TODO) ---
            // 1. Validar que los campos obligatorios (*) no estén vacíos.
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del producto es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Recolectar todos los datos de los controles.
            // var datosActualizados = new {
            //     Nombre = txtNombre.Text,
            //     IdCategoria = cboCategoria.SelectedValue,
            //     // etc.
            // };

            // 3. Llamar a tu capa de negocio para guardar los cambios en la base de datos.
            // bool exito = ProductoNegocio.Actualizar(_idProducto, datosActualizados);

            // 4. Si la actualización fue exitosa:
            MessageBox.Show("Producto modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK; // Informa al formulario anterior que se guardaron cambios
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Informa que no se guardó nada
            this.Close();
        }

        private void CargarImpuestosDelProducto(int idProducto)
        {
            // Limpiamos cualquier fila que ya exista
            dgvImpuestos.Rows.Clear();

            // TODO: Más adelante, aquí deberías leer los impuestos del producto desde tu base de datos.
            // Por ahora, vamos a añadir una fila de ejemplo para que veas cómo funciona.

            // 1. Añade una nueva fila en blanco al DataGridView
            int rowIndex = dgvImpuestos.Rows.Add();

            // 2. Obtiene una referencia a la fila que acabamos de crear
            DataGridViewRow nuevaFila = dgvImpuestos.Rows[rowIndex];

            // 3. Configura la celda del ComboBox
            DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)nuevaFila.Cells["colImpuesto"];
            comboCell.Items.Add("IVA 0");
            comboCell.Items.Add("IVA 12%"); // Puedes añadir más opciones
            comboCell.Value = "IVA 0"; // Establece el valor que se verá seleccionado

            // 4. Configura las celdas de CheckBox
            nuevaFila.Cells["colAplicaCompra"].Value = true; // El valor 'true' marca la casilla
            nuevaFila.Cells["colAplicaVenta"].Value = true;  // El valor 'true' marca la casilla
        }
    }
}