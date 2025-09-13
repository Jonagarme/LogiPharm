using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmEmitirResultado : Form
    {
        private readonly int _procesoId;
        private DataTable _dtParametros;
        private DataTable _dtPacientes;

        public FrmEmitirResultado(int procesoId)
        {
            _procesoId = procesoId;
            InitializeComponent();
            this.Load += FrmEmitirResultado_Load;
            this.btnCerrar.Click += (s, e) => this.Close();
            this.btnGuardar.Click += BtnGuardar_Click;
            this.btnImprimir.Click += BtnImprimir_Click;
            this.dgvResultados.CellFormatting += DgvResultados_CellFormatting;
            this.cboPaciente.KeyUp += CboPaciente_KeyUp;
            this.btnPacAdmin.Click += BtnPacAdmin_Click;
            this.btnPacBuscar.Click += BtnPacBuscar_Click;
        }

        private void FrmEmitirResultado_Load(object sender, EventArgs e)
        {
            CargarPacientes();
            CargarPlantilla();
        }

        private void CargarPacientes(string filtro = null)
        {
            try
            {
                _dtPacientes = new DPacientes().Listar(filtro);
                cboPaciente.DataSource = _dtPacientes;
                cboPaciente.DisplayMember = "nombre";
                cboPaciente.ValueMember = "id";
                cboPaciente.SelectedIndex = -1;

                // sincronizar documento
                cboPaciente.SelectedIndexChanged += (s, e) =>
                {
                    var drv = cboPaciente.SelectedItem as DataRowView;
                    txtPacienteId.Text = drv != null ? Convert.ToString(drv["documento"]) : string.Empty;
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar pacientes: " + ex.Message);
            }
        }

        private void CboPaciente_KeyUp(object sender, KeyEventArgs e)
        {
            // búsqueda incremental simple
            if (e.KeyCode == Keys.Enter) return;
            var text = cboPaciente.Text;
            CargarPacientes(text);
            cboPaciente.DroppedDown = true;
            cboPaciente.SelectionStart = cboPaciente.Text.Length;
        }

        private void BtnPacAdmin_Click(object sender, EventArgs e)
        {
            using (var f = new FrmPacientes())
            {
                var res = f.ShowDialog(this);
                if (res == DialogResult.OK || res == DialogResult.Cancel)
                {
                    // refrescar combo tras cerrar
                    CargarPacientes();
                }
            }
        }

        private void BtnPacBuscar_Click(object sender, EventArgs e)
        {
            using (var sel = new FrmSeleccionPacientes())
            {
                if (sel.ShowDialog(this) == DialogResult.OK)
                {
                    // Cargar en combo la selección
                    CargarPacientes(sel.FiltroAplicado);
                    // Buscar el paciente por Id y seleccionarlo
                    if (sel.PacienteSeleccionadoId.HasValue)
                    {
                        cboPaciente.SelectedValue = sel.PacienteSeleccionadoId.Value;
                    }
                }
            }
        }

        private void CargarPlantilla()
        {
            try
            {
                _dtParametros = new DLabParametros().Listar(_procesoId);
                
                DataTable dtResultados = new DataTable();
                dtResultados.Columns.Add("Parametro", typeof(string));
                dtResultados.Columns.Add("Valor", typeof(string));
                dtResultados.Columns.Add("Unidad", typeof(string));
                dtResultados.Columns.Add("RefMin", typeof(string));
                dtResultados.Columns.Add("RefMax", typeof(string));

                foreach (DataRow row in _dtParametros.Rows)
                {
                    dtResultados.Rows.Add(
                        row["nombre"]?.ToString(),
                        string.Empty,
                        row["unidad"]?.ToString(),
                        row["ref_min"]?.ToString(),
                        row["ref_max"]?.ToString());
                }

                dgvResultados.DataSource = dtResultados;
                ConfigurarGridResultados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la plantilla de resultados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGridResultados()
        {
            dgvResultados.AutoGenerateColumns = false;
            dgvResultados.Columns.Clear();

            dgvResultados.Columns.Add(new DataGridViewTextBoxColumn { Name = "Parametro", HeaderText = "Parámetro", DataPropertyName = "Parametro", ReadOnly = true, FillWeight = 35 });
            dgvResultados.Columns.Add(new DataGridViewTextBoxColumn { Name = "Valor", HeaderText = "Valor", DataPropertyName = "Valor", ReadOnly = false, FillWeight = 20 });
            dgvResultados.Columns.Add(new DataGridViewTextBoxColumn { Name = "Unidad", HeaderText = "Unidad", DataPropertyName = "Unidad", ReadOnly = true, FillWeight = 10 });
            dgvResultados.Columns.Add(new DataGridViewTextBoxColumn { Name = "RefMin", HeaderText = "Ref. Min", DataPropertyName = "RefMin", ReadOnly = true, FillWeight = 10 });
            dgvResultados.Columns.Add(new DataGridViewTextBoxColumn { Name = "RefMax", HeaderText = "Ref. Max", DataPropertyName = "RefMax", ReadOnly = true, FillWeight = 10 });
            dgvResultados.Columns.Add(new DataGridViewTextBoxColumn { Name = "RangoReferencia", HeaderText = "Rango de Referencia", ReadOnly = true, FillWeight = 15 });

            foreach (DataGridViewRow row in dgvResultados.Rows)
            {
                string min = row.Cells["RefMin"].Value?.ToString();
                string max = row.Cells["RefMax"].Value?.ToString();
                row.Cells["RangoReferencia"].Value = string.IsNullOrWhiteSpace(min) && string.IsNullOrWhiteSpace(max) ? string.Empty : $"{min} - {max}";
            }
        }

        private void DgvResultados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvResultados.Columns[e.ColumnIndex].Name != "Valor" || e.RowIndex < 0) return;
            var row = dgvResultados.Rows[e.RowIndex];
            var valorTxt = row.Cells["Valor"].Value?.ToString();
            var minTxt = row.Cells["RefMin"].Value?.ToString();
            var maxTxt = row.Cells["RefMax"].Value?.ToString();

            bool fuera = EstaFueraDeRango(valorTxt, minTxt, maxTxt);
            row.Cells["Valor"].Style.ForeColor = fuera ? Color.Red : SystemColors.ControlText;
        }

        private bool EstaFueraDeRango(string valor, string min, string max)
        {
            // Permitir , o . como separador decimal
            double? v = ParseNullableDouble(valor);
            double? vmin = ParseNullableDouble(min);
            double? vmax = ParseNullableDouble(max);

            if (!v.HasValue || (!vmin.HasValue && !vmax.HasValue)) return false; // sin datos para comparar
            if (vmin.HasValue && v.Value < vmin.Value) return true;
            if (vmax.HasValue && v.Value > vmax.Value) return true;
            return false;
        }

        private double? ParseNullableDouble(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return null;
            s = s.Replace(',', '.');
            if (double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var d)) return d;
            return null;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (cboPaciente.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un paciente.");
                cboPaciente.Focus();
                return;
            }

            try
            {
                var drv = cboPaciente.SelectedItem as DataRowView;
                string nombrePac = Convert.ToString(drv["nombre"]);
                string docPac = Convert.ToString(drv["documento"]);

                var cab = new ELabResultado
                {
                    ProcesoId = _procesoId,
                    FechaEmision = DateTime.Now,
                    PacienteNombre = nombrePac,
                    PacienteId = docPac,
                    MedicoSolicitante = txtMedico.Text.Trim(),
                    Observaciones = string.Empty
                };
                var dCab = new DLabResultados();
                int idResultado = dCab.Insertar(cab);

                var dDet = new DLabResultadoDetalles();
                foreach (DataGridViewRow row in dgvResultados.Rows)
                {
                    if (row.IsNewRow) continue;
                    var det = new ELabResultadoDetalle
                    {
                        ResultadoId = idResultado,
                        ParametroNombre = row.Cells["Parametro"].Value?.ToString(),
                        Valor = row.Cells["Valor"].Value?.ToString(),
                        Unidad = row.Cells["Unidad"].Value?.ToString(),
                        RangoReferencia = row.Cells["RangoReferencia"].Value?.ToString(),
                        FueraDeRango = EstaFueraDeRango(
                            row.Cells["Valor"].Value?.ToString(),
                            row.Cells["RefMin"].Value?.ToString(),
                            row.Cells["RefMax"].Value?.ToString())
                    };
                    dDet.Insertar(det);
                }

                MessageBox.Show("Resultado guardado correctamente.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función de impresión en desarrollo.");
        }
    }
}
