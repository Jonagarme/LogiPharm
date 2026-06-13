﻿using System;
using System;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmRecetasMedicas : Form
    {
        private readonly BindingSource _bsRecetas = new BindingSource();
        private readonly System.Windows.Forms.Timer _debounceTimer;
        private int? _idEditando;

        public FrmRecetasMedicas()
        {
            InitializeComponent();

            _debounceTimer = new System.Windows.Forms.Timer { Interval = 300 };
            _debounceTimer.Tick += async (s, e) =>
            {
                _debounceTimer.Stop();
                await CargarListadoAsync(txtBuscar.Text.Trim());
            };

            txtBuscar.TextChanged += (s, e) =>
            {
                _debounceTimer.Stop();
                _debounceTimer.Start();
            };

            btnNuevo.Click += (s, e) => Nuevo();
            btnEditar.Click += async (s, e) => await EditarSeleccionadoAsync();
            btnEliminar.Click += async (s, e) => await EliminarSeleccionadoAsync();
            btnRecargar.Click += async (s, e) => await CargarListadoAsync(txtBuscar.Text.Trim());
            btnExportar.Click += (s, e) => ExportarCsv();

            btnGuardar.Click += async (s, e) => await GuardarAsync();
            btnCancelar.Click += (s, e) => CerrarEditor();
            btnAgregarDetalle.Click += (s, e) => AgregarDetalle();
            btnQuitarDetalle.Click += (s, e) => QuitarDetalleSeleccionado();

            dgvRecetas.CellDoubleClick += async (s, e) =>
            {
                if (e.RowIndex < 0) return;
                await EditarSeleccionadoAsync();
            };
        }

        private async void FrmRecetasMedicas_Load(object sender, EventArgs e)
        {
            ConfigurarGrillas();
            ConfigurarEditor();
            CerrarEditor();
            await CargarListadoAsync(null);
        }

        private void ConfigurarGrillas()
        {
            dgvRecetas.AutoGenerateColumns = false;
            dgvRecetas.Columns.Clear();

            dgvRecetas.Columns.Add(new DataGridViewTextBoxColumn { Name = "colId", DataPropertyName = "id", HeaderText = "ID", Visible = false });
            dgvRecetas.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNumero", DataPropertyName = "numero_receta", HeaderText = "N° Receta", Width = 110 });
            dgvRecetas.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPaciente", DataPropertyName = "paciente_nombre", HeaderText = "Paciente", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvRecetas.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMedico", DataPropertyName = "medico_nombre", HeaderText = "Médico", Width = 170 });
            dgvRecetas.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEmision", DataPropertyName = "fecha_emision", HeaderText = "Emisión", Width = 95, DefaultCellStyle = { Format = "d" } });
            dgvRecetas.Columns.Add(new DataGridViewTextBoxColumn { Name = "colVence", DataPropertyName = "fecha_vencimiento", HeaderText = "Vence", Width = 95, DefaultCellStyle = { Format = "d" } });
            dgvRecetas.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEstado", DataPropertyName = "estado", HeaderText = "Estado", Width = 130 });

            dgvRecetas.DataSource = _bsRecetas;

            dgvDetalles.AutoGenerateColumns = false;
            dgvDetalles.Columns.Clear();
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { Name = "colProducto", HeaderText = "Producto", DataPropertyName = "ProductoNombre", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCantidad", HeaderText = "Cantidad", DataPropertyName = "Cantidad", Width = 90, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N2" } });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { Name = "colIndicaciones", HeaderText = "Indicaciones", DataPropertyName = "Indicaciones", Width = 160 });
        }

        private void ConfigurarEditor()
        {
            cboEstado.Items.Clear();
            cboEstado.Items.AddRange(new object[] { "Ingresada", "Surtida parcial", "Surtida total", "Vencida" });
            if (cboEstado.Items.Count > 0) cboEstado.SelectedIndex = 0;

            dtpEmision.Value = DateTime.Today;
            dtpVencimiento.Value = DateTime.Today.AddDays(30);

            dgvDetalles.DataSource = new BindingSource { DataSource = new BindingList<ERecetaDetalle>() };
        }

        private async Task CargarListadoAsync(string criterio)
        {
            try
            {
                var d = new DRecetas();
                DataTable dt = await Task.Run(() => d.Listar(criterio));
                _bsRecetas.DataSource = dt;
                lblTotal.Text = $"Total: {dt.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar recetas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Nuevo()
        {
            _idEditando = null;
            lblEditorTitulo.Text = "Nueva receta";

            txtNumeroReceta.Text = string.Empty;
            txtPaciente.Text = string.Empty;
            txtMedico.Text = string.Empty;
            txtRegistro.Text = string.Empty;
            txtEspecialidad.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            dtpEmision.Value = DateTime.Today;
            dtpVencimiento.Value = DateTime.Today.AddDays(30);
            if (cboEstado.Items.Count > 0) cboEstado.SelectedIndex = 0;

            var bsDet = (BindingSource)dgvDetalles.DataSource;
            bsDet.DataSource = new BindingList<ERecetaDetalle>();
            bsDet.ResetBindings(false);

            AbrirEditor();
            txtNumeroReceta.Focus();
        }

        private async Task EditarSeleccionadoAsync()
        {
            int? id = ObtenerIdSeleccionado();
            if (id == null)
            {
                MessageBox.Show("Seleccione una receta para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var d = new DRecetas();
                var receta = await Task.Run(() => d.ObtenerPorId(id.Value));
                if (receta == null)
                {
                    MessageBox.Show("No se encontró la receta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _idEditando = receta.Id;
                lblEditorTitulo.Text = $"Editar receta #{receta.Id}";

                txtNumeroReceta.Text = receta.NumeroReceta;
                txtPaciente.Text = receta.PacienteNombre;
                txtMedico.Text = receta.MedicoNombre;
                txtRegistro.Text = receta.MedicoRegistro;
                txtEspecialidad.Text = receta.MedicoEspecialidad;
                txtObservaciones.Text = receta.Observaciones;
                dtpEmision.Value = receta.FechaEmision;
                dtpVencimiento.Value = receta.FechaVencimiento ?? receta.FechaEmision;
                SeleccionarEstado(receta.Estado);

                var bsDet = (BindingSource)dgvDetalles.DataSource;
                bsDet.DataSource = new BindingList<ERecetaDetalle>(receta.Detalles ?? new System.Collections.Generic.List<ERecetaDetalle>());
                bsDet.ResetBindings(false);

                AbrirEditor();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir receta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task EliminarSeleccionadoAsync()
        {
            int? id = ObtenerIdSeleccionado();
            if (id == null)
            {
                MessageBox.Show("Seleccione una receta para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Desea eliminar esta receta?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                var d = new DRecetas();
                bool ok = await Task.Run(() => d.Eliminar(id.Value));
                if (ok)
                {
                    await CargarListadoAsync(txtBuscar.Text.Trim());
                    MessageBox.Show("Receta eliminada.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la receta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task GuardarAsync()
        {
            if (string.IsNullOrWhiteSpace(txtPaciente.Text))
            {
                MessageBox.Show("El paciente es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPaciente.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMedico.Text))
            {
                MessageBox.Show("El médico es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMedico.Focus();
                return;
            }

            var receta = new EReceta
            {
                Id = _idEditando ?? 0,
                NumeroReceta = NullIfEmpty(txtNumeroReceta.Text),
                PacienteNombre = txtPaciente.Text.Trim(),
                MedicoNombre = txtMedico.Text.Trim(),
                MedicoRegistro = NullIfEmpty(txtRegistro.Text),
                MedicoEspecialidad = NullIfEmpty(txtEspecialidad.Text),
                FechaEmision = dtpEmision.Value.Date,
                FechaVencimiento = dtpVencimiento.Value.Date,
                Estado = cboEstado.SelectedItem?.ToString() ?? "Ingresada",
                Observaciones = NullIfEmpty(txtObservaciones.Text),
                Activo = true,
                Detalles = ObtenerDetallesDesdeGrid()
            };

            if (receta.Detalles.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos 1 medicamento en el detalle.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var d = new DRecetas();
                bool ok = _idEditando == null
                    ? await Task.Run(() => d.Insertar(receta))
                    : await Task.Run(() => d.Actualizar(receta));

                if (!ok)
                {
                    MessageBox.Show("No se pudo guardar la receta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                CerrarEditor();
                await CargarListadoAsync(txtBuscar.Text.Trim());
                MessageBox.Show("Receta guardada.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private System.Collections.Generic.List<ERecetaDetalle> ObtenerDetallesDesdeGrid()
        {
            var lista = new System.Collections.Generic.List<ERecetaDetalle>();
            dgvDetalles.EndEdit();

            for (int i = 0; i < dgvDetalles.Rows.Count; i++)
            {
                var row = dgvDetalles.Rows[i];
                if (row.IsNewRow) continue;

                string producto = Convert.ToString(row.Cells["colProducto"].Value)?.Trim();
                string cantidadStr = Convert.ToString(row.Cells["colCantidad"].Value);
                string indicaciones = Convert.ToString(row.Cells["colIndicaciones"].Value);

                if (string.IsNullOrWhiteSpace(producto)) continue;

                decimal cantidad = 0;
                if (!decimal.TryParse(cantidadStr, NumberStyles.Any, CultureInfo.CurrentCulture, out cantidad))
                {
                    decimal.TryParse(cantidadStr, NumberStyles.Any, CultureInfo.InvariantCulture, out cantidad);
                }

                if (cantidad <= 0) cantidad = 1;

                lista.Add(new ERecetaDetalle
                {
                    ProductoNombre = producto,
                    Cantidad = cantidad,
                    Indicaciones = string.IsNullOrWhiteSpace(indicaciones) ? null : indicaciones.Trim()
                });
            }

            return lista;
        }

        private void AbrirEditor()
        {
            splitContainer1.Panel2Collapsed = false;
            splitContainer1.SplitterDistance = Math.Max(520, this.Width - 480);
        }

        private void CerrarEditor()
        {
            splitContainer1.Panel2Collapsed = true;
            _idEditando = null;
        }

        private void AgregarDetalle()
        {
            var bs = dgvDetalles.DataSource as BindingSource;
            var lista = bs?.DataSource as BindingList<ERecetaDetalle>;
            if (lista == null) return;

            lista.Add(new ERecetaDetalle { Cantidad = 1 });
            bs.ResetBindings(false);

            dgvDetalles.Focus();
            int idx = dgvDetalles.Rows.Count - 1;
            if (idx >= 0)
            {
                dgvDetalles.CurrentCell = dgvDetalles.Rows[idx].Cells["colProducto"];
                dgvDetalles.BeginEdit(true);
            }
        }

        private void QuitarDetalleSeleccionado()
        {
            if (dgvDetalles.CurrentRow == null || dgvDetalles.CurrentRow.IsNewRow) return;

            var bs = dgvDetalles.DataSource as BindingSource;
            var lista = bs?.DataSource as BindingList<ERecetaDetalle>;
            if (lista == null) return;

            int idx = dgvDetalles.CurrentRow.Index;
            if (idx >= 0 && idx < lista.Count)
            {
                lista.RemoveAt(idx);
                bs.ResetBindings(false);
            }
        }

        private int? ObtenerIdSeleccionado()
        {
            if (dgvRecetas.CurrentRow == null) return null;
            object val = dgvRecetas.CurrentRow.Cells["colId"].Value;
            if (val == null || val == DBNull.Value) return null;
            return Convert.ToInt32(val);
        }

        private void SeleccionarEstado(string estado)
        {
            if (string.IsNullOrWhiteSpace(estado)) return;
            for (int i = 0; i < cboEstado.Items.Count; i++)
            {
                if (string.Equals(cboEstado.Items[i].ToString(), estado, StringComparison.OrdinalIgnoreCase))
                {
                    cboEstado.SelectedIndex = i;
                    return;
                }
            }
        }

        private static string NullIfEmpty(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return null;
            return s.Trim();
        }

        private void ExportarCsv()
        {
            try
            {
                if (dgvRecetas.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV (*.csv)|*.csv";
                    sfd.FileName = $"recetas_{DateTime.Now:yyyyMMdd_HHmm}.csv";
                    if (sfd.ShowDialog(this) != DialogResult.OK) return;

                    using (var sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                    {
                        // Header
                        var headers = new[] { "NumeroReceta", "Paciente", "Medico", "Emision", "Vencimiento", "Estado" };
                        sw.WriteLine(string.Join(";", headers));

                        foreach (DataGridViewRow r in dgvRecetas.Rows)
                        {
                            if (r.IsNewRow) continue;
                            string numero = Convert.ToString(r.Cells["colNumero"].Value);
                            string paciente = Convert.ToString(r.Cells["colPaciente"].Value);
                            string medico = Convert.ToString(r.Cells["colMedico"].Value);
                            string emision = Convert.ToString(r.Cells["colEmision"].Value);
                            string venc = Convert.ToString(r.Cells["colVence"].Value);
                            string estado = Convert.ToString(r.Cells["colEstado"].Value);

                            string line = string.Join(";", new[] { numero, paciente, medico, emision, venc, estado }.Select(EscapeCsv));
                            sw.WriteLine(line);
                        }
                    }
                }

                MessageBox.Show("Exportación completada.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string EscapeCsv(string s)
        {
            if (s == null) return string.Empty;
            s = s.Replace("\r", " ").Replace("\n", " ");
            if (s.Contains(";") || s.Contains("\"") )
            {
                s = s.Replace("\"", "\"\"");
                return "\"" + s + "\"";
            }
            return s;
        }
    }
}
