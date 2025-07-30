using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace LogiPharm.Presentacion
{
    public partial class FrmDevoluciones : Form
    {
        public FrmDevoluciones()
        {
            InitializeComponent();
        }

        private void FrmDevoluciones_Load(object sender, EventArgs e)
        {
            // Ocultar el panel de información hasta que se busque una factura
            groupInfoFactura.Visible = false;
        }

        private void btnBuscarFactura_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumeroFactura.Text))
            {
                MessageBox.Show("Por favor, ingrese un número de factura para buscar.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Simulación de carga de datos
            CargarDatosDePrueba();
            groupInfoFactura.Visible = true; // Mostrar la información de la factura
        }

        private void CargarDatosDePrueba()
        {
            // --- 1. Llenar Información de la Factura Original ---
            lblIdentificacion.Text = "0932267339";
            lblCliente.Text = "JONATHAN GERMAN GARCIA MERINO";
            lblFechaEmision.Text = DateTime.Now.AddDays(-5).ToString("dd/MM/yyyy");

            // --- 2. Llenar Tabla de Productos de la Factura Original ---
            DataTable dtProductos = new DataTable();
            dtProductos.Columns.Add("Seleccionar", typeof(bool));
            dtProductos.Columns.Add("Codigo", typeof(string));
            dtProductos.Columns.Add("Producto", typeof(string));
            dtProductos.Columns.Add("CantVendida", typeof(int));
            dtProductos.Columns.Add("CantDevolver", typeof(int));
            dtProductos.Columns.Add("Precio", typeof(decimal));
            dtProductos.Columns.Add("Total", typeof(decimal));

            // Añadir filas de ejemplo
            dtProductos.Rows.Add(false, "7861097200475", "CEMIN 500MG/5ML CJX10 AMPOLLAS IM-IV", 2, 0, 1.50m, 3.00m);
            dtProductos.Rows.Add(false, "8904159404011", "PARACETAMOL 500MG CJX100 TAB - ECUAQ", 1, 0, 5.00m, 5.00m);
            dtProductos.Rows.Add(false, "7702057074272", "METFORMINA 850 MG CJ X30 - MK", 3, 0, 8.20m, 24.60m);

            dgvProductosDevolver.DataSource = dtProductos;
            EstilizarGrid();
        }

        private void EstilizarGrid()
        {
            if (dgvProductosDevolver.Columns.Count > 0)
            {
                dgvProductosDevolver.Columns["colSeleccionar"].Width = 40;
                dgvProductosDevolver.Columns["colCodigo"].ReadOnly = true;
                dgvProductosDevolver.Columns["colProducto"].ReadOnly = true;
                dgvProductosDevolver.Columns["colProducto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvProductosDevolver.Columns["colCantidadVendida"].ReadOnly = true;
                dgvProductosDevolver.Columns["colPrecio"].ReadOnly = true;
                dgvProductosDevolver.Columns["colTotal"].ReadOnly = true;

                string[] columnasNumericas = { "colCantidadVendida", "colCantidadDevolver" };
                foreach (string colName in columnasNumericas)
                {
                    var col = dgvProductosDevolver.Columns[colName];
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                string[] columnasMoneda = { "colPrecio", "colTotal" };
                foreach (string colName in columnasMoneda)
                {
                    var col = dgvProductosDevolver.Columns[colName];
                    col.DefaultCellStyle.Format = "N2";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private void dgvProductosDevolver_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Si el cambio ocurrió en la columna de CheckBox o en la cantidad a devolver, recalculamos
            if (e.RowIndex >= 0 && (dgvProductosDevolver.Columns[e.ColumnIndex].Name == "colSeleccionar" || dgvProductosDevolver.Columns[e.ColumnIndex].Name == "colCantidadDevolver"))
            {
                CalcularTotalesDevolucion();
            }
        }

        private void dgvProductosDevolver_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // Este truco es para que el evento CellValueChanged se dispare inmediatamente al hacer clic en el CheckBox
            if (dgvProductosDevolver.IsCurrentCellDirty)
            {
                dgvProductosDevolver.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void CalcularTotalesDevolucion()
        {
            decimal subtotal = 0;
            foreach (DataGridViewRow row in dgvProductosDevolver.Rows)
            {
                // Verificamos si la fila está seleccionada para la devolución
                bool seleccionado = Convert.ToBoolean(row.Cells["colSeleccionar"].Value ?? false);
                if (seleccionado)
                {
                    int cantDevolver = Convert.ToInt32(row.Cells["colCantidadDevolver"].Value ?? 0);
                    decimal precio = Convert.ToDecimal(row.Cells["colPrecio"].Value ?? 0);
                    subtotal += cantDevolver * precio;
                }
            }

            decimal iva = subtotal * 0.15m; // Asumiendo IVA del 15%
            decimal total = subtotal + iva;

            lblSubtotal.Text = subtotal.ToString("C2");
            lblIVA.Text = iva.ToString("C2");
            lblTotalDevolucion.Text = total.ToString("C2");
        }
    }
}
