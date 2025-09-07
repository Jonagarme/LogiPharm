using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmKardex : Form
    {
        private EProducto _productoSeleccionado;

        public FrmKardex()
        {
            InitializeComponent();
        }

        private void FrmKardex_Load(object sender, EventArgs e)
        {
            cboBodega.SelectedIndex = 0;
            groupInfoProducto.Visible = false;

            // Rango por defecto: desde el 1er día del mes hasta hoy
            dtpFechaInicio.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpFechaFin.Value = DateTime.Today;

            // Importantísimo:
            dgvKardex.AutoGenerateColumns = false;

            // Mapear columnas (hazlo una sola vez)
            dgvKardex.Columns["colFecha"].DataPropertyName = "Fecha";
            dgvKardex.Columns["colTipoMovimiento"].DataPropertyName = "TipoMovimiento";
            dgvKardex.Columns["colDetalle"].DataPropertyName = "Detalle";
            dgvKardex.Columns["colIngresos"].DataPropertyName = "Ingreso";
            dgvKardex.Columns["colEgresos"].DataPropertyName = "Egreso";
            dgvKardex.Columns["colSaldo"].DataPropertyName = "Saldo";

            // Auditoría: VISUALIZAR
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Kardex", "VISUALIZAR", "kardex", null, "Abrir Kardex", null, Environment.MachineName, "UI"); } catch { }
        }

        private void txtProducto_KeyDown(object sender, KeyEventArgs e)
        {
            // Si el usuario presiona Enter, iniciamos la búsqueda
            if (e.KeyCode == Keys.Enter)
            {
                BuscarProducto();
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (_productoSeleccionado == null)
            {
                // Si no hay producto, la consulta es para buscar uno
                BuscarProducto();
            }
            else
            {
                // Si ya hay un producto, la consulta es para cargar su kardex
                CargarKardex();
            }
        }

        private void BuscarProducto()
        {
            string textoBuscado = txtProducto.Text.Trim();
            if (string.IsNullOrEmpty(textoBuscado))
            {
                MessageBox.Show("Por favor, ingrese un código o nombre de producto para buscar.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                DProductos d_Productos = new DProductos();
                List<EProducto> productosEncontrados = d_Productos.BuscarProductosActivos(textoBuscado);

                if (productosEncontrados.Count == 1)
                {
                    _productoSeleccionado = productosEncontrados[0];
                    CargarKardex();
                }
                else if (productosEncontrados.Count > 1)
                {
                    using (var frm = new FrmSeleccionarProducto(productosEncontrados))
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            _productoSeleccionado = frm.ProductoSeleccionado;
                            CargarKardex();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron productos con ese criterio.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _productoSeleccionado = null;
                    LimpiarVista();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarKardex()
        {
            if (_productoSeleccionado == null) return;

            // 1. Mostrar la información del producto seleccionado
            lblCodigoProducto.Text = _productoSeleccionado.CodigoPrincipal;
            lblNombreProducto.Text = _productoSeleccionado.Nombre;
            lblStockActual.Text = _productoSeleccionado.Stock.ToString("N2");
            groupInfoProducto.Visible = true;

            // 2. Cargar los movimientos del Kardex
            try
            {
                DKardex d_Kardex = new DKardex();
                dgvKardex.DataSource = d_Kardex.ObtenerMovimientos((int)_productoSeleccionado.Id, dtpFechaInicio.Value, dtpFechaFin.Value);
                EstilizarGrid();

                // Auditoría: VISUALIZAR kardex de producto
                try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Kardex", "VISUALIZAR", "kardex", _productoSeleccionado.Id, $"Ver kardex de {_productoSeleccionado.Nombre}", null, Environment.MachineName, "UI"); } catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Cargar Kardex", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarVista()
        {
            groupInfoProducto.Visible = false;
            dgvKardex.DataSource = null;
            lblCodigoProducto.Text = "...";
            lblNombreProducto.Text = "...";
            lblStockActual.Text = "0.00";
        }

        private void EstilizarGrid()
        {
            // Anchos / formatos
            dgvKardex.Columns["colFecha"].Width = 120;
            dgvKardex.Columns["colTipoMovimiento"].Width = 150;
            dgvKardex.Columns["colDetalle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            string[] columnasNumericas = { "colIngresos", "colEgresos", "colSaldo" };
            foreach (var colName in columnasNumericas)
            {
                var col = dgvKardex.Columns[colName];
                col.Width = 100;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                col.DefaultCellStyle.Format = "N2";
            }
        }

    }
}
