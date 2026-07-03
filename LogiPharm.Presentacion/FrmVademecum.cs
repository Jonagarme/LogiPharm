using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySqlConnector;
using LogiPharm.Datos;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmVademecum : Form
    {
        public FrmVademecum()
        {
            InitializeComponent();
            this.Load += FrmVademecum_Load;
        }

        private void FrmVademecum_Load(object sender, EventArgs e)
        {
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Inventario", "VISUALIZAR", "vademecum", null, "Abrir Vademécum", null, Environment.MachineName, "UI"); } catch { }

            EstilosHelper.EstilizarFormulario(this);
            EstilosHelper.EstilizarDataGridView(dgvMedicinas);

            BuscarVademecum();

            // Eventos
            btnBuscar.Click += BtnBuscar_Click;
            txtBusqueda.KeyPress += TxtBusqueda_KeyPress;
            dgvMedicinas.SelectionChanged += DgvMedicinas_SelectionChanged;
        }

        private void BuscarVademecum()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string busqueda = txtBusqueda.Text.Trim();

                using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
                {
                    cn.Open();
                    string sql = @"
                        SELECT 
                            p.id AS Id,
                            p.codigoPrincipal AS Codigo,
                            p.nombre AS Nombre,
                            COALESCE(pa.nombre, 'No especificado') AS PrincipioActivo,
                            COALESCE(pr.nombre, 'No especificado') AS Presentacion,
                            COALESCE(l.nombre, 'Sin Laboratorio') AS Laboratorio,
                            p.stock AS Stock,
                            p.precioVenta AS PVP,
                            p.registroSanitario AS RegistroSanitario,
                            p.descripcion AS Descripcion,
                            p.observaciones AS Observaciones
                        FROM productos p
                        LEFT JOIN principios_activos pa ON p.idPrincipioActivo = pa.id
                        LEFT JOIN presentaciones pr ON p.idPresentacion = pr.id
                        LEFT JOIN laboratorios l ON p.idLaboratorio = l.id
                        WHERE p.anulado = 0 AND p.activo = 1
                          AND (@criterio = '' 
                               OR p.nombre LIKE @criterioLike 
                               OR p.codigoPrincipal LIKE @criterioLike 
                               OR pa.nombre LIKE @criterioLike 
                               OR p.descripcion LIKE @criterioLike)
                        ORDER BY p.nombre ASC;";

                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@criterio", busqueda);
                        cmd.Parameters.AddWithValue("@criterioLike", $"%{busqueda}%");

                        DataTable dt = new DataTable();
                        using (var da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        dgvMedicinas.DataSource = dt;
                        lblTotal.Text = $"Medicinas encontradas: {dt.Rows.Count}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar en el vademécum: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void DgvMedicinas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMedicinas.CurrentRow != null)
            {
                var row = dgvMedicinas.CurrentRow;

                lblInfoNombre.Text = row.Cells["colNombre"].Value.ToString();
                lblInfoPrincipio.Text = row.Cells["colPrincipio"].Value.ToString();
                lblInfoPresentacion.Text = row.Cells["colPresentacion"].Value.ToString();
                lblInfoLaboratorio.Text = row.Cells["colLaboratorio"].Value.ToString();
                lblInfoRegistro.Text = row.Cells["colRegistro"].Value?.ToString() ?? "N/A";
                
                decimal stockVal = Convert.ToDecimal(row.Cells["colStock"].Value);
                lblInfoStock.Text = $"{stockVal:N0} unidades";
                lblInfoStock.ForeColor = stockVal <= 0 ? Color.Red : Color.Green;

                decimal pvpVal = Convert.ToDecimal(row.Cells["colPVP"].Value);
                lblInfoPVP.Text = $"${pvpVal:N2}";

                txtInfoDescripcion.Text = row.Cells["colDescripcion"].Value?.ToString() ?? "Sin descripción.";
                txtInfoObservaciones.Text = row.Cells["colObservaciones"].Value?.ToString() ?? "Sin indicaciones / observaciones.";
            }
            else
            {
                LimpiarInfoSheet();
            }
        }

        private void LimpiarInfoSheet()
        {
            lblInfoNombre.Text = "...";
            lblInfoPrincipio.Text = "...";
            lblInfoPresentacion.Text = "...";
            lblInfoLaboratorio.Text = "...";
            lblInfoRegistro.Text = "...";
            lblInfoStock.Text = "...";
            lblInfoStock.ForeColor = Color.Black;
            lblInfoPVP.Text = "...";
            txtInfoDescripcion.Clear();
            txtInfoObservaciones.Clear();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            BuscarVademecum();
        }

        private void TxtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                BuscarVademecum();
            }
        }
    }
}
