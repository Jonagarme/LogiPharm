using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Guna.Charts.WinForms;
using LogiPharm.Datos; // Asegúrate de que este using sea correcto
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
            // Asociamos el evento Load para cargar los datos cuando el formulario se muestre
            this.Load += FrmDashboard_Load;
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            // Auditoría: VISUALIZAR
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Dashboard", "VISUALIZAR", "dashboard", null, "Abrir Dashboard", null, Environment.MachineName, "UI"); } catch { }

            // Llamamos a los métodos para cargar cada componente del dashboard
            CargarKPIs();
            CargarChartVentas();
            CargarChartTopProductos();
        }

        private void CargarKPIs()
        {
            try
            {
                DDashboard d_Dashboard = new DDashboard();
                DataTable dt = d_Dashboard.ObtenerKPIs();

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lblVentasHoy.Text = Convert.ToDecimal(row["VentasHoy"]).ToString("C2"); // Formato de moneda
                    lblTotalClientes.Text = row["TotalClientes"].ToString();
                    lblProductosStock.Text = Convert.ToDecimal(row["ProductosStock"]).ToString("N2");
                    lblProveedores.Text = row["TotalProveedores"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los indicadores: " + ex.Message);
            }
        }

        private void CargarChartVentas()
        {
            try
            {
                DDashboard d_Dashboard = new DDashboard();
                DataTable dt = d_Dashboard.ObtenerVentasUltimoMes();

                chartVentasMes.Datasets.Clear();
                var dataset = new Guna.Charts.WinForms.GunaLineDataset();
                dataset.Label = "Ventas";
                dataset.FillColor = Color.FromArgb(0, 122, 204);
                dataset.BorderColor = Color.FromArgb(0, 122, 204);

                foreach (DataRow row in dt.Rows)
                {
                    // Usamos el formato de fecha corta para las etiquetas del eje X
                    dataset.DataPoints.Add(Convert.ToDateTime(row["Fecha"]).ToShortDateString(), Convert.ToDouble(row["TotalVentas"]));
                }

                chartVentasMes.Datasets.Add(dataset);
                chartVentasMes.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el gráfico de ventas: " + ex.Message);
            }
        }

        private void CargarChartTopProductos()
        {
            try
            {
                DDashboard d_Dashboard = new DDashboard();
                DataTable dt = d_Dashboard.ObtenerTopProductos();

                chartTopProductos.Datasets.Clear();
                var dataset = new Guna.Charts.WinForms.GunaBarDataset();
                dataset.Label = "Unidades Vendidas";

                // Colores para las barras del gráfico
                var colors = new[]
                {
                    Color.FromArgb(0, 122, 204),
                    Color.FromArgb(23, 162, 184),
                    Color.FromArgb(40, 167, 69),
                    Color.FromArgb(255, 193, 7),
                    Color.FromArgb(220, 53, 69)
                };
                int colorIndex = 0;

                foreach (DataRow row in dt.Rows)
                {
                    dataset.DataPoints.Add(row["Producto"].ToString(), Convert.ToDouble(row["TotalVendido"]));
                    // Asignar un color a cada barra
                    if (colorIndex < colors.Length)
                    {
                        dataset.FillColors.Add(colors[colorIndex]);
                        dataset.BorderColors.Add(colors[colorIndex]);
                        colorIndex++;
                    }
                }

                chartTopProductos.Datasets.Add(dataset);
                chartTopProductos.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el gráfico de productos más vendidos: " + ex.Message);
            }
        }
    }
}
