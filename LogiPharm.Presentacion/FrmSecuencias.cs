using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LogiPharm.Datos;

namespace LogiPharm.Presentacion
{
    public partial class FrmSecuencias : Form
    {
        public FrmSecuencias()
        {
            InitializeComponent();

            dgvSecuencias.AutoGenerateColumns = false;
            dgvSecuencias.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvSecuencias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            CargarSecuencias();
        }

        private void CargarSecuencias()
        {
            try
            {
                var d = new DSecuencias();
                var tabla = d.ListarSecuencias();
                dgvSecuencias.DataSource = tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvSecuencias.EndEdit();
                var d = new DSecuencias();
                foreach (DataGridViewRow row in dgvSecuencias.Rows)
                {
                    if (row.IsNewRow) continue;
                    string nombre = Convert.ToString(row.Cells["colNombre"].Value)?.Trim();
                    if (string.IsNullOrEmpty(nombre)) continue;
                    int valor = 0;
                    int.TryParse(Convert.ToString(row.Cells["colValor"].Value), out valor);
                    string prefijo = Convert.ToString(row.Cells["colPrefijo"].Value);
                    int longitud = 0;
                    int.TryParse(Convert.ToString(row.Cells["colLongitud"].Value), out longitud);
                    if (longitud <= 0) longitud = 6;
                    bool activo = Convert.ToBoolean(row.Cells["colActivo"].Value ?? true);

                    d.GuardarSecuencia(nombre, valor, prefijo, longitud, activo);
                }

                MessageBox.Show("Secuencias guardadas.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarSecuencias();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var idx = dgvSecuencias.Rows.Add();
            dgvSecuencias.Rows[idx].Cells["colActivo"].Value = true;
            dgvSecuencias.CurrentCell = dgvSecuencias.Rows[idx].Cells["colNombre"];
            dgvSecuencias.BeginEdit(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvSecuencias.CurrentRow != null && !dgvSecuencias.CurrentRow.IsNewRow)
            {
                var nombre = Convert.ToString(dgvSecuencias.CurrentRow.Cells["colNombre"].Value);
                if (string.IsNullOrEmpty(nombre))
                {
                    dgvSecuencias.Rows.Remove(dgvSecuencias.CurrentRow);
                    return;
                }
                var r = MessageBox.Show($"¿Eliminar secuencia '{nombre}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    try
                    {
                        var d = new DSecuencias();
                        d.EliminarSecuencia(nombre);
                        dgvSecuencias.Rows.Remove(dgvSecuencias.CurrentRow);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
