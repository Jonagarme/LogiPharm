using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmMovimientosCaja : Form
    {
        private DCierreCaja _dCierreCaja;

        public FrmMovimientosCaja()
        {
            InitializeComponent();
            _dCierreCaja = new DCierreCaja();
        }

        private void FrmMovimientosCaja_Load(object sender, EventArgs e)
        {
            // Auditoría
            try
            {
                new DBitacora().Registrar(
                    SesionActual.IdUsuario,
                    SesionActual.NombreUsuario,
                    "Caja",
                    "VISUALIZAR",
                    "movimientos_caja",
                    null,
                    "Ver Movimientos de Caja",
                    null,
                    Environment.MachineName,
                    "UI"
                );
            }
            catch { }

            ConfigurarDataGridView();
            CargarCajas();
            
            // Configurar fechas por defecto (último mes)
            dtpFechaInicio.Value = DateTime.Now.AddMonths(-1);
            dtpFechaFin.Value = DateTime.Now;
            
            CargarMovimientos();
        }

        private void ConfigurarDataGridView()
        {
            dgvMovimientos.AutoGenerateColumns = false;
            dgvMovimientos.AllowUserToAddRows = false;
            dgvMovimientos.AllowUserToDeleteRows = false;
            dgvMovimientos.ReadOnly = true;
            dgvMovimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovimientos.MultiSelect = false;
            dgvMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Configurar columnas
            dgvMovimientos.Columns.Clear();
            
            dgvMovimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFecha",
                HeaderText = "Fecha",
                DataPropertyName = "FechaApertura",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" },
                FillWeight = 80
            });

            dgvMovimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCaja",
                HeaderText = "Caja",
                DataPropertyName = "NombreCaja",
                FillWeight = 60
            });

            dgvMovimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTipoMovimiento",
                HeaderText = "Tipo",
                DataPropertyName = "TipoMovimiento",
                FillWeight = 60
            });

            dgvMovimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colUsuario",
                HeaderText = "Usuario",
                DataPropertyName = "NombreUsuario",
                FillWeight = 80
            });

            dgvMovimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSaldoInicial",
                HeaderText = "Saldo Inicial",
                DataPropertyName = "SaldoInicial",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight },
                FillWeight = 70
            });

            dgvMovimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colIngresos",
                HeaderText = "Ingresos",
                DataPropertyName = "TotalIngresos",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight, ForeColor = Color.Green },
                FillWeight = 70
            });

            dgvMovimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEgresos",
                HeaderText = "Egresos",
                DataPropertyName = "TotalEgresos",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight, ForeColor = Color.Red },
                FillWeight = 70
            });

            dgvMovimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSaldoFinal",
                HeaderText = "Saldo Final",
                DataPropertyName = "SaldoFinal",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight, Font = new Font("Segoe UI", 9F, FontStyle.Bold) },
                FillWeight = 70
            });

            dgvMovimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEstado",
                HeaderText = "Estado",
                DataPropertyName = "Estado",
                FillWeight = 60
            });
        }

        private void CargarCajas()
        {
            try
            {
                var dCaja = new DCaja();
                var cajas = dCaja.ObtenerActivas();
                
                cboCaja.Items.Clear();
                cboCaja.Items.Add(new { Id = 0, Texto = "TODAS LAS CAJAS" });
                
                foreach (var caja in cajas)
                {
                    cboCaja.Items.Add(new { Id = caja.Id, Texto = $"{caja.Codigo} - {caja.Nombre}" });
                }
                
                cboCaja.DisplayMember = "Texto";
                cboCaja.ValueMember = "Id";
                cboCaja.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cajas: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarMovimientos()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                
                DateTime fechaInicio = dtpFechaInicio.Value.Date;
                DateTime fechaFin = dtpFechaFin.Value.Date.AddDays(1).AddSeconds(-1);
                
                int? idCaja = null;
                if (cboCaja.SelectedIndex > 0)
                {
                    dynamic item = cboCaja.SelectedItem;
                    idCaja = item.Id;
                }

                // Obtener datos de cierres de caja
                var cierres = _dCierreCaja.ObtenerCierresPorRango(fechaInicio, fechaFin, idCaja);
                
                // Crear DataTable para el grid
                var dt = new DataTable();
                dt.Columns.Add("FechaApertura", typeof(DateTime));
                dt.Columns.Add("NombreCaja", typeof(string));
                dt.Columns.Add("TipoMovimiento", typeof(string));
                dt.Columns.Add("NombreUsuario", typeof(string));
                dt.Columns.Add("SaldoInicial", typeof(decimal));
                dt.Columns.Add("TotalIngresos", typeof(decimal));
                dt.Columns.Add("TotalEgresos", typeof(decimal));
                dt.Columns.Add("SaldoFinal", typeof(decimal));
                dt.Columns.Add("Estado", typeof(string));

                decimal totalIngresos = 0;
                decimal totalEgresos = 0;
                decimal saldoNeto = 0;

                foreach (var cierre in cierres)
                {
                    decimal saldoFinal = cierre.SaldoInicial + cierre.TotalIngresosSistema - cierre.TotalEgresosSistema;
                    
                    string tipoMovimiento = cierre.Estado == "ABIERTA" ? "APERTURA" : "CIERRE";
                    string nombreCaja = $"CAJA {cierre.IdCaja:000}";
                    
                    dt.Rows.Add(
                        cierre.FechaApertura,
                        nombreCaja,
                        tipoMovimiento,
                        cierre.NombreUsuarioApertura,
                        cierre.SaldoInicial,
                        cierre.TotalIngresosSistema,
                        cierre.TotalEgresosSistema,
                        saldoFinal,
                        cierre.Estado
                    );

                    totalIngresos += cierre.TotalIngresosSistema;
                    totalEgresos += cierre.TotalEgresosSistema;
                }

                saldoNeto = totalIngresos - totalEgresos;

                dgvMovimientos.DataSource = dt;
                
                // Actualizar totales
                lblTotalIngresos.Text = totalIngresos.ToString("C2");
                lblTotalEgresos.Text = totalEgresos.ToString("C2");
                lblSaldoNeto.Text = saldoNeto.ToString("C2");
                lblSaldoNeto.ForeColor = saldoNeto >= 0 ? Color.Green : Color.Red;
                lblTotalRegistros.Text = $"Total: {dt.Rows.Count} movimientos";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar movimientos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value > dtpFechaFin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha fin.", 
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            CargarMovimientos();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMovimientos.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Información", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx|CSV Files|*.csv|All Files|*.*",
                    DefaultExt = "xlsx",
                    FileName = $"MovimientosCaja_{DateTime.Now:yyyyMMdd_HHmmss}"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // TODO: Implementar exportación a Excel/CSV
                    MessageBox.Show("Exportación en desarrollo.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvMovimientos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMovimientos.Columns[e.ColumnIndex].Name == "colEstado")
            {
                if (e.Value != null)
                {
                    string estado = e.Value.ToString();
                    switch (estado)
                    {
                        case "ABIERTA":
                            e.CellStyle.BackColor = Color.LightGreen;
                            e.CellStyle.ForeColor = Color.DarkGreen;
                            e.CellStyle.Font = new Font(dgvMovimientos.Font, FontStyle.Bold);
                            break;
                        case "CERRADA":
                            e.CellStyle.BackColor = Color.LightBlue;
                            e.CellStyle.ForeColor = Color.DarkBlue;
                            break;
                    }
                }
            }
            else if (dgvMovimientos.Columns[e.ColumnIndex].Name == "colTipoMovimiento")
            {
                if (e.Value != null)
                {
                    string tipo = e.Value.ToString();
                    if (tipo == "APERTURA")
                    {
                        e.CellStyle.ForeColor = Color.Green;
                        e.CellStyle.Font = new Font(dgvMovimientos.Font, FontStyle.Bold);
                    }
                    else if (tipo == "CIERRE")
                    {
                        e.CellStyle.ForeColor = Color.Blue;
                    }
                }
            }
        }
    }
}
