using Guna.UI2.WinForms;
using LogiPharm.Datos;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LogiPharm.Presentacion
{
    public partial class FrmTransferencias : Form
    {
        private readonly DTransferencias _dTransferencias;

        public FrmTransferencias()
        {
            InitializeComponent();
            _dTransferencias = new DTransferencias();
        }

        private void FrmTransferencias_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CargarTransferencias();
        }

        private void ConfigurarDataGridView()
        {
            dgvTransferencias.AutoGenerateColumns = false;
            dgvTransferencias.Columns.Clear();

            // Columnas
            dgvTransferencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNumero",
                HeaderText = "N° TRANSFERENCIA",
                DataPropertyName = "numeroTransferencia",
                Width = 150,
                ReadOnly = true
            });

            dgvTransferencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFecha",
                HeaderText = "FECHA",
                DataPropertyName = "fechaTransferencia",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                ReadOnly = true
            });

            dgvTransferencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colOrigen",
                HeaderText = "UBICACIÓN ORIGEN",
                DataPropertyName = "ubicacionOrigen",
                Width = 150,
                ReadOnly = true
            });

            dgvTransferencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDestino",
                HeaderText = "UBICACIÓN DESTINO",
                DataPropertyName = "ubicacionDestino",
                Width = 150,
                ReadOnly = true
            });

            dgvTransferencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMotivo",
                HeaderText = "MOTIVO",
                DataPropertyName = "motivoTransferencia",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });

            dgvTransferencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProductos",
                HeaderText = "PRODUCTOS",
                DataPropertyName = "totalProductos",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter },
                ReadOnly = true
            });

            dgvTransferencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colUnidades",
                HeaderText = "UNIDADES",
                DataPropertyName = "totalUnidades",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter },
                ReadOnly = true
            });

            dgvTransferencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEstado",
                HeaderText = "ESTADO",
                DataPropertyName = "estado",
                Width = 120,
                ReadOnly = true
            });

            dgvTransferencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "ID",
                DataPropertyName = "id",
                Visible = false
            });

            // Estilos
            dgvTransferencias.CellFormatting += dgvTransferencias_CellFormatting;
        }

        private void dgvTransferencias_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTransferencias.Columns[e.ColumnIndex].Name == "colEstado")
            {
                string estado = e.Value?.ToString();
                if (!string.IsNullOrEmpty(estado))
                {
                    switch (estado.ToUpper())
                    {
                        case "PENDIENTE":
                            e.CellStyle.BackColor = Color.FromArgb(255, 243, 205);
                            e.CellStyle.ForeColor = Color.FromArgb(153, 102, 0);
                            break;
                        case "EN_TRANSITO":
                            e.CellStyle.BackColor = Color.FromArgb(209, 236, 241);
                            e.CellStyle.ForeColor = Color.FromArgb(1, 87, 155);
                            break;
                        case "RECIBIDA":
                            e.CellStyle.BackColor = Color.FromArgb(200, 230, 201);
                            e.CellStyle.ForeColor = Color.FromArgb(27, 94, 32);
                            break;
                        case "CANCELADA":
                            e.CellStyle.BackColor = Color.FromArgb(255, 205, 210);
                            e.CellStyle.ForeColor = Color.FromArgb(183, 28, 28);
                            break;
                    }
                    e.CellStyle.Font = new Font(dgvTransferencias.Font, FontStyle.Bold);
                }
            }
        }

        private void CargarTransferencias()
        {
            try
            {
                string filtroEstado = "";
                if (cboEstado.SelectedItem != null && cboEstado.SelectedItem.ToString() != "Todos")
                {
                    filtroEstado = cboEstado.SelectedItem.ToString().ToUpper().Replace(" ", "_");
                }

                DataTable dt = _dTransferencias.ListarTransferencias(filtroEstado);
                dgvTransferencias.DataSource = dt;

                lblTotal.Text = $"Total: {dt.Rows.Count} transferencia(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar transferencias: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmNuevaTransferencia())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarTransferencias();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarTransferencias();
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTransferencias();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvTransferencias.DataSource is DataTable dt)
                {
                    string filtro = txtBuscar.Text.Trim();
                    if (string.IsNullOrWhiteSpace(filtro))
                    {
                        dt.DefaultView.RowFilter = "";
                    }
                    else
                    {
                        dt.DefaultView.RowFilter = $"numeroTransferencia LIKE '%{filtro}%' OR " +
                                                   $"ubicacionOrigen LIKE '%{filtro}%' OR " +
                                                   $"ubicacionDestino LIKE '%{filtro}%' OR " +
                                                   $"motivoTransferencia LIKE '%{filtro}%'";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (dgvTransferencias.CurrentRow == null) return;

            long id = Convert.ToInt64(dgvTransferencias.CurrentRow.Cells["colId"].Value);
            // Aquí puedes abrir un formulario de vista detallada
            MessageBox.Show($"Ver transferencia ID: {id}", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
