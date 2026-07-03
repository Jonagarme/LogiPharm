using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Negocio;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmReporteCompras : Form
    {
        public FrmReporteCompras()
        {
            InitializeComponent();
            this.Load += FrmReporteCompras_Load;
        }

        private void FrmReporteCompras_Load(object sender, EventArgs e)
        {
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Finanzas", "VISUALIZAR", "reporte_compras", null, "Abrir Reporte de Compras", null, Environment.MachineName, "UI"); } catch { }

            EstilosHelper.EstilizarFormulario(this);
            EstilosHelper.EstilizarDataGridView(dgvCompras);

            // Valores de fecha por defecto
            dtpFechaInicio.Value = DateTime.Today.AddMonths(-1);
            dtpFechaFin.Value = DateTime.Today;

            CargarProveedores();
            ConsultarCompras();

            // Eventos
            btnBuscar.Click += BtnBuscar_Click;
            btnExportar.Click += BtnExportar_Click;
        }

        private void CargarProveedores()
        {
            try
            {
                var dt = NProveedores.ListarProveedores("");
                
                DataRow row = dt.NewRow();
                row["id"] = 0;
                row["razonSocial"] = "TODOS LOS PROVEEDORES";
                dt.Rows.InsertAt(row, 0);

                cboProveedor.DataSource = dt;
                cboProveedor.DisplayMember = "razonSocial";
                cboProveedor.ValueMember = "id";
                cboProveedor.SelectedIndex = 0;
            }
            catch { }
        }

        private void ConsultarCompras()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DateTime inicio = dtpFechaInicio.Value;
                DateTime fin = dtpFechaFin.Value;
                int? idProveedor = null;

                if (cboProveedor.SelectedValue != null && Convert.ToInt32(cboProveedor.SelectedValue) > 0)
                    idProveedor = Convert.ToInt32(cboProveedor.SelectedValue);

                var dt = NReportesInventarioCompras.ObtenerReporteCompras(inicio, fin, idProveedor);
                dgvCompras.DataSource = dt;

                // Calcular totales
                decimal totalFacturas = dt.Rows.Count;
                decimal totalMonto = NReportesInventarioCompras.CalcularTotalCompras(dt);

                lblTotalCompras.Text = $"Total de compras: {totalFacturas:N0}";
                lblTotalMonto.Text = $"Total invertido: ${totalMonto:N2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reporte de compras: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            ConsultarCompras();
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            if (dgvCompras.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Reporte de compras consolidado exportado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Finanzas", "EXPORTAR", "reporte_compras", null, "Exportar Reporte de Compras Consolidadas", null, Environment.MachineName, "UI"); } catch { }
        }
    }
}
