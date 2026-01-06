using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmHistorialCompras : Form
    {
        private DHistorialCompras datosHistorial;

        public FrmHistorialCompras()
        {
            InitializeComponent();
            datosHistorial = new DHistorialCompras();
            this.Load += FrmHistorialCompras_Load;
        }

        private void FrmHistorialCompras_Load(object sender, EventArgs e)
        {
            // Auditoría: VISUALIZAR
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Compras", "VISUALIZAR", "historial_compras", null, "Abrir Historial de Compras", null, Environment.MachineName, "UI"); } catch { }

            // Configurar valores iniciales
            ConfigurarGrid();
            dtpFechaInicio.Value = DateTime.Today.AddMonths(-1);
            dtpFechaFin.Value = DateTime.Today;

            // Conectar eventos
            btnConsultar.Click += BtnConsultar_Click;
            btnExportar.Click += BtnExportar_Click;

            // Cargar datos iniciales
            ConsultarHistorial();
        }

        private void ConfigurarGrid()
        {
            dgvHistorial.AutoGenerateColumns = false;
            dgvHistorial.Columns.Clear();

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Fecha",
                DataPropertyName = "Fecha",
                HeaderText = "Fecha",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NumeroFactura",
                DataPropertyName = "NumeroFactura",
                HeaderText = "No. Factura",
                Width = 120
            });

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Proveedor",
                DataPropertyName = "Proveedor",
                HeaderText = "Proveedor",
                Width = 200
            });

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RUC",
                DataPropertyName = "RUC",
                HeaderText = "RUC",
                Width = 110
            });

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CodigoProducto",
                DataPropertyName = "CodigoProducto",
                HeaderText = "Código",
                Width = 120
            });

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Producto",
                DataPropertyName = "Producto",
                HeaderText = "Producto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Cantidad",
                DataPropertyName = "Cantidad",
                HeaderText = "Cantidad",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Format = "N2"
                }
            });

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CostoUnitario",
                DataPropertyName = "CostoUnitario",
                HeaderText = "Costo Unit.",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "C6"
                }
            });

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Total",
                DataPropertyName = "Total",
                HeaderText = "Total",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "C2"
                }
            });
        }

        private void ConsultarHistorial()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string proveedor = txtProveedor.Text.Trim();
                string producto = txtProducto.Text.Trim();

                var dt = datosHistorial.ConsultarHistorial(
                    dtpFechaInicio.Value,
                    dtpFechaFin.Value,
                    proveedor,
                    producto
                );

                dgvHistorial.DataSource = dt;

                // Calcular y mostrar totales
                var (totalUnidades, totalCosto) = datosHistorial.CalcularTotales(dt);
                lblTotalUnidades.Text = totalUnidades.ToString("N2");
                lblTotalCosto.Text = totalCosto.ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar historial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            ConsultarHistorial();
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            if (dgvHistorial.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Archivos CSV (*.csv)|*.csv",
                    FileName = $"HistorialCompras_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                    Title = "Exportar Historial de Compras"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportarACSV(sfd.FileName);
                    MessageBox.Show("Datos exportados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Auditoría
                    try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Compras", "EXPORTAR", "historial_compras", null, $"Exportar historial a {sfd.FileName}", null, Environment.MachineName, "UI"); } catch { }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarACSV(string rutaArchivo)
        {
            var sb = new StringBuilder();

            // Encabezados
            var columnas = dgvHistorial.Columns.Cast<DataGridViewColumn>()
                .Where(c => c.Visible)
                .Select(c => c.HeaderText);
            sb.AppendLine(string.Join(",", columnas));

            // Filas
            foreach (DataGridViewRow fila in dgvHistorial.Rows)
            {
                var valores = new List<string>();
                foreach (DataGridViewColumn col in dgvHistorial.Columns)
                {
                    if (col.Visible)
                    {
                        var valor = fila.Cells[col.Index].Value?.ToString() ?? "";
                        // Escapar comillas y comas
                        if (valor.Contains(",") || valor.Contains("\""))
                            valor = $"\"{valor.Replace("\"", "\"\"")}\"";
                        valores.Add(valor);
                    }
                }
                sb.AppendLine(string.Join(",", valores));
            }

            System.IO.File.WriteAllText(rutaArchivo, sb.ToString(), Encoding.UTF8);
        }
    }
}
