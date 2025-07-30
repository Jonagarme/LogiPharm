using System;
using System.Data;
using System.Windows.Forms;

namespace LogiPharm.Presentacion
{
    public partial class FrmRecepcionProductos : Form
    {
        public FrmRecepcionProductos()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            using (var loadingForm = new FrmLoading())
            {
                loadingForm.Show(this);
                loadingForm.Update();
                System.Threading.Thread.Sleep(500);
                CargarDatosDePrueba();
                loadingForm.Close();
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Seleccionar Factura en formato PDF";
                openFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    MessageBox.Show("Archivo seleccionado con éxito:\n" + filePath,
                                    "Importación de Factura",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
        }

        private void CargarDatosDePrueba()
        {
            txtProveedor.Text = "DISTRIBUIDORA FARMACEUTICA ECUATORIANA DIFARE S.A.";
            txtRUC.Text = "0990857361001";
            txtDireccion.Text = "KM 19.5 VIA A DAULE";
            txtFechaEmision.Text = "25/04/2025";
            txtFechaAutorizacion.Text = "25/04/2025 17:54:02";
            txtNumeroFactura.Text = "001-100-000123456";
            txtAutorizacion.Text = "2504202501099085736100120011000001234561234567817";

            txtSubtotalSinIVA.Text = "150.75";
            txtSubtotalIVA.Text = "250.25";
            txtDescuento.Text = "15.50";
            txtImpuestoIVA.Text = "37.54";
            txtSubtotal.Text = "385.50";
            txtTotal.Text = "423.04";

            DataTable dtProductos = new DataTable();
            dtProductos.Columns.Add("Codigo", typeof(string));
            dtProductos.Columns.Add("Producto", typeof(string));
            dtProductos.Columns.Add("Cantidad", typeof(int));
            dtProductos.Columns.Add("PrecioUnitario", typeof(decimal));
            dtProductos.Columns.Add("Descuento", typeof(decimal));
            dtProductos.Columns.Add("Total", typeof(decimal));

            dtProductos.Rows.Add("7861097200475", "CEMIN 500MG/5ML CJX10 AMPOLLAS IM-IV", 20, 0.49, 0, 9.80);
            dtProductos.Rows.Add("8904159404011", "PARACETAMOL 500MG CJX100 TAB - ECUAQ", 100, 0.05, 0, 5.00);
            dtProductos.Rows.Add("7862104590336", "COMPLEJO B JARABE FCO X100ML - LABOVIDA", 15, 1.50, 0, 22.50);
            dtProductos.Rows.Add("7702057074272", "METFORMINA 850 MG CJ X30 - MK", 40, 0.20, 0, 8.00);
            dtProductos.Rows.Add("7703763117178", "VITAMINA C NARANJA 500MG SX12 TAB MAST - LASANTE", 5, 0.87, 0, 4.35);

            dgvProductos.DataSource = dtProductos;
            EstilizarGrid();
        }

        private void EstilizarGrid()
        {
            if (dgvProductos.Columns.Count > 0)
            {
                // --- CORRECCIÓN DE ALINEACIÓN ---
                dgvProductos.Columns["Producto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                string[] columnasMoneda = { "PrecioUnitario", "Descuento", "Total" };
                foreach (string colName in columnasMoneda)
                {
                    if (dgvProductos.Columns.Contains(colName))
                    {
                        var col = dgvProductos.Columns[colName];
                        col.DefaultCellStyle.Format = "N2";
                        // Alinear tanto el contenido de la celda como el encabezado a la derecha
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }

                // Alinear la cantidad al centro
                if (dgvProductos.Columns.Contains("Cantidad"))
                {
                    var col = dgvProductos.Columns["Cantidad"];
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }
    }
}
