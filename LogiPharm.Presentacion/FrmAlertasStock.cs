using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Negocio;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmAlertasStock : Form
    {
        public FrmAlertasStock()
        {
            InitializeComponent();
            this.Load += FrmAlertasStock_Load;
        }

        private void FrmAlertasStock_Load(object sender, EventArgs e)
        {
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Inventario", "VISUALIZAR", "alertas_stock", null, "Abrir Alertas de Stock Mínimo", null, Environment.MachineName, "UI"); } catch { }

            EstilosHelper.EstilizarFormulario(this);
            EstilosHelper.EstilizarDataGridView(dgvAlertas);

            // Cargar datos
            CargarCategorias();
            CargarLaboratorios();
            CargarAlertas();

            // Eventos
            btnBuscar.Click += BtnBuscar_Click;
            txtBusqueda.KeyPress += TxtBusqueda_KeyPress;
            btnLimpiar.Click += BtnLimpiar_Click;
        }

        private void CargarCategorias()
        {
            try
            {
                var dt = NProductos.ListarCategorias();
                DataRow row = dt.NewRow();
                row["id"] = 0;
                row["nombre"] = "TODAS LAS CATEGORÍAS";
                dt.Rows.InsertAt(row, 0);

                cboCategoria.DataSource = dt;
                cboCategoria.DisplayMember = "nombre";
                cboCategoria.ValueMember = "id";
                cboCategoria.SelectedIndex = 0;
            }
            catch { }
        }

        private void CargarLaboratorios()
        {
            try
            {
                var dt = NLaboratorios.Listar();
                DataRow row = dt.NewRow();
                row["id"] = 0;
                row["nombre"] = "TODOS LOS LABORATORIOS";
                dt.Rows.InsertAt(row, 0);

                cboLaboratorio.DataSource = dt;
                cboLaboratorio.DisplayMember = "nombre";
                cboLaboratorio.ValueMember = "id";
                cboLaboratorio.SelectedIndex = 0;
            }
            catch { }
        }

        private void CargarAlertas()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string busqueda = txtBusqueda.Text.Trim();
                int? idCategoria = null;
                int? idLaboratorio = null;

                if (cboCategoria.SelectedValue != null && Convert.ToInt32(cboCategoria.SelectedValue) > 0)
                    idCategoria = Convert.ToInt32(cboCategoria.SelectedValue);

                if (cboLaboratorio.SelectedValue != null && Convert.ToInt32(cboLaboratorio.SelectedValue) > 0)
                    idLaboratorio = Convert.ToInt32(cboLaboratorio.SelectedValue);

                // Reutilizamos el reporte de inventario filtrando únicamente por stock BAJO
                var dt = NReportesInventarioCompras.ObtenerReporteInventario(idCategoria, idLaboratorio, "BAJO");
                
                // Si hay criterio de búsqueda, filtramos en memoria
                if (!string.IsNullOrEmpty(busqueda))
                {
                    DataTable dtFiltrado = dt.Clone();
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["Nombre"].ToString().IndexOf(busqueda, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            row["Codigo"].ToString().IndexOf(busqueda, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            dtFiltrado.ImportRow(row);
                        }
                    }
                    dgvAlertas.DataSource = dtFiltrado;
                    lblTotal.Text = $"Productos con stock bajo: {dtFiltrado.Rows.Count}";
                }
                else
                {
                    dgvAlertas.DataSource = dt;
                    lblTotal.Text = $"Productos con stock bajo: {dt.Rows.Count}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar alertas de stock: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargarAlertas();
        }

        private void TxtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                CargarAlertas();
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Clear();
            cboCategoria.SelectedIndex = 0;
            cboLaboratorio.SelectedIndex = 0;
            CargarAlertas();
        }
    }
}
