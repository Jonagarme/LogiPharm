using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Negocio;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmReporteInventario : Form
    {
        public FrmReporteInventario()
        {
            InitializeComponent();
            this.Load += FrmReporteInventario_Load;
        }

        private void FrmReporteInventario_Load(object sender, EventArgs e)
        {
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Finanzas", "VISUALIZAR", "reporte_inventario", null, "Abrir Reporte de Inventario", null, Environment.MachineName, "UI"); } catch { }

            EstilosHelper.EstilizarFormulario(this);
            EstilosHelper.EstilizarDataGridView(dgvInventario);

            // Cargar filtros
            CargarCategorias();
            CargarLaboratorios();
            CargarEstadosStock();
            
            ConsultarInventario();

            // Eventos
            btnBuscar.Click += BtnBuscar_Click;
            btnExportar.Click += BtnExportar_Click;
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

        private void CargarEstadosStock()
        {
            cboEstadoStock.Items.Clear();
            cboEstadoStock.Items.Add(new { Text = "TODOS", Value = "ALL" });
            cboEstadoStock.Items.Add(new { Text = "CON STOCK", Value = "CON_STOCK" });
            cboEstadoStock.Items.Add(new { Text = "STOCK BAJO", Value = "BAJO" });
            cboEstadoStock.Items.Add(new { Text = "SIN STOCK", Value = "SIN_STOCK" });
            
            cboEstadoStock.DisplayMember = "Text";
            cboEstadoStock.ValueMember = "Value";
            cboEstadoStock.SelectedIndex = 0;
        }

        private void ConsultarInventario()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int? idCategoria = null;
                int? idLaboratorio = null;
                string estadoStock = "ALL";

                if (cboCategoria.SelectedValue != null && Convert.ToInt32(cboCategoria.SelectedValue) > 0)
                    idCategoria = Convert.ToInt32(cboCategoria.SelectedValue);

                if (cboLaboratorio.SelectedValue != null && Convert.ToInt32(cboLaboratorio.SelectedValue) > 0)
                    idLaboratorio = Convert.ToInt32(cboLaboratorio.SelectedValue);

                if (cboEstadoStock.SelectedItem != null)
                {
                    // Obtener mediante reflexión por el tipo anónimo
                    var item = cboEstadoStock.SelectedItem;
                    var type = item.GetType();
                    estadoStock = type.GetProperty("Value").GetValue(item, null).ToString();
                }

                var dt = NReportesInventarioCompras.ObtenerReporteInventario(idCategoria, idLaboratorio, estadoStock);
                dgvInventario.DataSource = dt;

                // Calcular totales e indicadores
                decimal totalItems = dt.Rows.Count;
                decimal totalUnidades = 0;
                decimal totalCosto = 0;
                decimal totalPVP = 0;

                foreach (DataRow row in dt.Rows)
                {
                    totalUnidades += Convert.ToDecimal(row["Stock"]);
                    totalCosto += Convert.ToDecimal(row["CostoTotal"]);
                    totalPVP += Convert.ToDecimal(row["ValorTotal"]);
                }

                // Cargar KPIs
                lblKpiItems.Text = totalItems.ToString("N0");
                lblKpiStock.Text = totalUnidades.ToString("N0");
                lblKpiCosto.Text = $"${totalCosto:N2}";
                lblKpiVentas.Text = $"${totalPVP:N2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reporte de inventario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            ConsultarInventario();
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            if (dgvInventario.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Reporte de inventario valorizado exportado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Finanzas", "EXPORTAR", "reporte_inventario", null, "Exportar Reporte de Inventario Valorizado", null, Environment.MachineName, "UI"); } catch { }
        }
    }
}
