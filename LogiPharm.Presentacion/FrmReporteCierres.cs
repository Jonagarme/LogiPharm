using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmReporteCierres : Form
    {
        private string _tipoReporteActual = "DIARIO"; // DIARIO, MENSUAL, ANUAL

        public FrmReporteCierres()
        {
            InitializeComponent();
        }

        private void FrmReporteCierres_Load(object sender, EventArgs e)
        {
            // Auditoría
            try
            {
                new DBitacora().Registrar(
                    SesionActual.IdUsuario,
                    SesionActual.NombreUsuario,
                    "Caja",
                    "VISUALIZAR",
                    "cierres_caja",
                    null,
                    "Abrir Reporte de Cierres",
                    null,
                    Environment.MachineName,
                    "UI"
                );
            }
            catch { }

            ConfigurarControles();
            CargarReporteDiario();
        }

        private void ConfigurarControles()
        {
            // Configurar DateTimePickers
            dtpFechaInicio.Value = DateTime.Today.AddDays(-30);
            dtpFechaFin.Value = DateTime.Today;

            // Configurar ComboBox de tipo de reporte
            cboTipoReporte.Items.AddRange(new object[] { "Diario", "Mensual", "Anual" });
            cboTipoReporte.SelectedIndex = 0;

            // Configurar años disponibles
            int añoActual = DateTime.Now.Year;
            for (int i = añoActual; i >= añoActual - 5; i--)
            {
                cboAño.Items.Add(i);
            }
            cboAño.SelectedItem = añoActual;

            // Configurar meses
            cboMes.Items.AddRange(new object[] {
                "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
            });
            cboMes.SelectedIndex = DateTime.Now.Month - 1;

            // Configurar DataGridView
            ConfigurarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            dgvCierres.AutoGenerateColumns = true;
            dgvCierres.AllowUserToAddRows = false;
            dgvCierres.AllowUserToDeleteRows = false;
            dgvCierres.ReadOnly = true;
            dgvCierres.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCierres.MultiSelect = false;
        }

        private void cboTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboTipoReporte.SelectedIndex)
            {
                case 0: // Diario
                    _tipoReporteActual = "DIARIO";
                    pnlFechas.Visible = true;
                    pnlMesAño.Visible = false;
                    pnlAño.Visible = false;
                    break;
                case 1: // Mensual
                    _tipoReporteActual = "MENSUAL";
                    pnlFechas.Visible = false;
                    pnlMesAño.Visible = true;
                    pnlAño.Visible = false;
                    break;
                case 2: // Anual
                    _tipoReporteActual = "ANUAL";
                    pnlFechas.Visible = false;
                    pnlMesAño.Visible = false;
                    pnlAño.Visible = true;
                    break;
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                switch (_tipoReporteActual)
                {
                    case "DIARIO":
                        CargarReporteDiario();
                        break;
                    case "MENSUAL":
                        CargarReporteMensual();
                        break;
                    case "ANUAL":
                        CargarReporteAnual();
                        break;
                }

                // Auditoría
                try
                {
                    new DBitacora().Registrar(
                        SesionActual.IdUsuario,
                        SesionActual.NombreUsuario,
                        "Caja",
                        "CONSULTAR",
                        "cierres_caja",
                        null,
                        $"Generó reporte {_tipoReporteActual}",
                        null,
                        Environment.MachineName,
                        "UI"
                    );
                }
                catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al generar el reporte: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void CargarReporteDiario()
        {
            DCierreCaja d_Cierre = new DCierreCaja();
            var cierres = d_Cierre.ObtenerCierresPorRango(
                dtpFechaInicio.Value.Date,
                dtpFechaFin.Value.Date.AddDays(1).AddSeconds(-1)
            );

            dgvCierres.DataSource = null;
            dgvCierres.DataSource = cierres;

            PersonalizarColumnas();
            CalcularTotales(cierres);
            ActualizarEstadisticas();
        }

        private void CargarReporteMensual()
        {
            DCierreCaja d_Cierre = new DCierreCaja();
            int año = Convert.ToInt32(cboAño.SelectedItem);
            int mes = cboMes.SelectedIndex + 1;

            DataTable tabla = d_Cierre.ObtenerResumenCierresMes(año, mes);
            dgvCierres.DataSource = tabla;

            PersonalizarColumnasMensual();
            CalcularTotalesMensual(tabla);
            ActualizarEstadisticas();
        }

        private void CargarReporteAnual()
        {
            DCierreCaja d_Cierre = new DCierreCaja();
            int año = Convert.ToInt32(cboAño.SelectedItem);

            DataTable tabla = d_Cierre.ObtenerResumenCierresAño(año);
            dgvCierres.DataSource = tabla;

            PersonalizarColumnasAnual();
            CalcularTotalesAnual(tabla);
            ActualizarEstadisticas();
        }

        private void PersonalizarColumnas()
        {
            if (dgvCierres.Columns.Count == 0) return;

            // Ocultar columnas que no necesitamos mostrar
            var columnasOcultar = new[] {
                "IdCaja", "IdUsuarioApertura", "IdUsuarioCierre",
                "CreadoPor", "CreadoDate", "EditadoPor", "EditadoDate",
                "Anulado", "IdUbicacion", "EstadoColor"
            };

            foreach (var col in columnasOcultar)
            {
                if (dgvCierres.Columns.Contains(col))
                    dgvCierres.Columns[col].Visible = false;
            }

            // Configurar formato de columnas
            ConfigurarFormatoColumna("SaldoInicial", "C2");
            ConfigurarFormatoColumna("TotalIngresosSistema", "C2");
            ConfigurarFormatoColumna("TotalEgresosSistema", "C2");
            ConfigurarFormatoColumna("SaldoTeoricoSistema", "C2");
            ConfigurarFormatoColumna("TotalContadoFisico", "C2");
            ConfigurarFormatoColumna("Diferencia", "C2");

            // Configurar encabezados
            ConfigurarEncabezado("FechaApertura", "Apertura");
            ConfigurarEncabezado("FechaCierre", "Cierre");
            ConfigurarEncabezado("SaldoInicial", "Saldo Inicial");
            ConfigurarEncabezado("TotalIngresosSistema", "Ingresos");
            ConfigurarEncabezado("TotalEgresosSistema", "Egresos");
            ConfigurarEncabezado("SaldoTeoricoSistema", "Saldo Teórico");
            ConfigurarEncabezado("TotalContadoFisico", "Contado");
            ConfigurarEncabezado("NombreUsuarioApertura", "Usuario Apertura");
            ConfigurarEncabezado("NombreUsuarioCierre", "Usuario Cierre");
        }

        private void PersonalizarColumnasMensual()
        {
            if (dgvCierres.Columns.Count == 0) return;

            ConfigurarFormatoColumna("TotalSaldoInicial", "C2");
            ConfigurarFormatoColumna("TotalIngresos", "C2");
            ConfigurarFormatoColumna("TotalEgresos", "C2");
            ConfigurarFormatoColumna("TotalSaldoTeorico", "C2");
            ConfigurarFormatoColumna("TotalContado", "C2");
            ConfigurarFormatoColumna("TotalDiferencia", "C2");
        }

        private void PersonalizarColumnasAnual()
        {
            if (dgvCierres.Columns.Count == 0) return;

            ConfigurarFormatoColumna("TotalSaldoInicial", "C2");
            ConfigurarFormatoColumna("TotalIngresos", "C2");
            ConfigurarFormatoColumna("TotalEgresos", "C2");
            ConfigurarFormatoColumna("TotalSaldoTeorico", "C2");
            ConfigurarFormatoColumna("TotalContado", "C2");
            ConfigurarFormatoColumna("TotalDiferencia", "C2");
            ConfigurarFormatoColumna("PromedioDiferencia", "C2");
        }

        private void ConfigurarFormatoColumna(string nombreColumna, string formato)
        {
            if (dgvCierres.Columns.Contains(nombreColumna))
            {
                dgvCierres.Columns[nombreColumna].DefaultCellStyle.Format = formato;
                dgvCierres.Columns[nombreColumna].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void ConfigurarEncabezado(string nombreColumna, string titulo)
        {
            if (dgvCierres.Columns.Contains(nombreColumna))
            {
                dgvCierres.Columns[nombreColumna].HeaderText = titulo;
            }
        }

        private void CalcularTotales(System.Collections.Generic.List<LogiPharm.Entidades.ECierreCaja> cierres)
        {
            decimal totalIngresos = 0;
            decimal totalEgresos = 0;
            decimal totalDiferencia = 0;

            foreach (var cierre in cierres)
            {
                totalIngresos += cierre.TotalIngresosSistema;
                totalEgresos += cierre.TotalEgresosSistema;
                totalDiferencia += cierre.Diferencia;
            }

            lblTotalIngresos.Text = totalIngresos.ToString("C2");
            lblTotalEgresos.Text = totalEgresos.ToString("C2");
            lblTotalDiferencia.Text = totalDiferencia.ToString("C2");

            // Color según diferencia
            lblTotalDiferencia.ForeColor = totalDiferencia >= 0 ? Color.Green : Color.Red;
        }

        private void CalcularTotalesMensual(DataTable tabla)
        {
            if (tabla.Rows.Count == 0) return;

            decimal totalIngresos = 0;
            decimal totalEgresos = 0;
            decimal totalDiferencia = 0;

            foreach (DataRow row in tabla.Rows)
            {
                totalIngresos += row["TotalIngresos"] != DBNull.Value ? Convert.ToDecimal(row["TotalIngresos"]) : 0;
                totalEgresos += row["TotalEgresos"] != DBNull.Value ? Convert.ToDecimal(row["TotalEgresos"]) : 0;
                totalDiferencia += row["TotalDiferencia"] != DBNull.Value ? Convert.ToDecimal(row["TotalDiferencia"]) : 0;
            }

            lblTotalIngresos.Text = totalIngresos.ToString("C2");
            lblTotalEgresos.Text = totalEgresos.ToString("C2");
            lblTotalDiferencia.Text = totalDiferencia.ToString("C2");
            lblTotalDiferencia.ForeColor = totalDiferencia >= 0 ? Color.Green : Color.Red;
        }

        private void CalcularTotalesAnual(DataTable tabla)
        {
            CalcularTotalesMensual(tabla); // Mismo cálculo
        }

        private void ActualizarEstadisticas()
        {
            try
            {
                DCierreCaja d_Cierre = new DCierreCaja();
                DateTime? fechaInicio = _tipoReporteActual == "DIARIO" ? (DateTime?)dtpFechaInicio.Value : null;
                DateTime? fechaFin = _tipoReporteActual == "DIARIO" ? (DateTime?)dtpFechaFin.Value : null;

                var stats = d_Cierre.ObtenerEstadisticasCaja(null, fechaInicio, fechaFin);

                lblTotalCierres.Text = stats.ContainsKey("TotalCierres") ? stats["TotalCierres"].ToString("N0") : "0";
                lblPromedioDiferencia.Text = stats.ContainsKey("DiferenciaPromedio") ? stats["DiferenciaPromedio"].ToString("C2") : "$0.00";
            }
            catch
            {
                // Si falla, no mostramos error
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Archivos Excel (*.xlsx)|*.xlsx|Archivos CSV (*.csv)|*.csv",
                    Title = "Exportar Reporte de Cierres",
                    FileName = $"Reporte_Cierres_{_tipoReporteActual}_{DateTime.Now:yyyyMMdd}.xlsx"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // Aquí implementarías la exportación según el tipo de archivo
                    MessageBox.Show(
                        "Funcionalidad de exportación pendiente de implementar",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al exportar: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCierres_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Colorear la diferencia
            if (dgvCierres.Columns[e.ColumnIndex].Name == "Diferencia" ||
                dgvCierres.Columns[e.ColumnIndex].Name == "TotalDiferencia")
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal diferencia))
                {
                    e.CellStyle.ForeColor = diferencia >= 0 ? Color.Green : Color.Red;
                    e.CellStyle.Font = new Font(dgvCierres.Font, FontStyle.Bold);
                }
            }

            // Colorear el estado
            if (dgvCierres.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value != null && e.Value.ToString() == "ABIERTA")
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.ForeColor = Color.DarkGreen;
                    e.CellStyle.Font = new Font(dgvCierres.Font, FontStyle.Bold);
                }
            }
        }

        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
