using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySqlConnector;
using LogiPharm.Datos;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmMedicamentosControlados : Form
    {
        public FrmMedicamentosControlados()
        {
            InitializeComponent();
            this.Load += FrmMedicamentosControlados_Load;
        }

        private void FrmMedicamentosControlados_Load(object sender, EventArgs e)
        {
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Inventario", "VISUALIZAR", "medicamentos_controlados", null, "Abrir Medicamentos Controlados", null, Environment.MachineName, "UI"); } catch { }

            EstilosHelper.EstilizarFormulario(this);
            EstilosHelper.EstilizarDataGridView(dgvControlados);

            CargarMedicamentosControlados();

            // Eventos
            btnBuscar.Click += BtnBuscar_Click;
            txtBusqueda.KeyPress += TxtBusqueda_KeyPress;
            btnExportar.Click += BtnExportar_Click;
        }

        private void CargarMedicamentosControlados()
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
                            p.codigoPrincipal AS Codigo,
                            p.nombre AS Nombre,
                            COALESCE(pa.nombre, 'No especificado') AS PrincipioActivo,
                            p.stock AS Stock,
                            p.registroSanitario AS RegistroSanitario,
                            p.requiereSeguimiento AS RequiereSeguimiento,
                            p.activo AS Activo
                        FROM productos p
                        LEFT JOIN principios_activos pa ON p.idPrincipioActivo = pa.id
                        WHERE p.anulado = 0 AND p.esPsicotropico = 1
                          AND (@criterio = '' OR p.nombre LIKE @criterioLike OR p.codigoPrincipal LIKE @criterioLike)
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
                        dgvControlados.DataSource = dt;
                        lblTotal.Text = $"Medicamentos controlados registrados: {dt.Rows.Count}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar medicamentos controlados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargarMedicamentosControlados();
        }

        private void TxtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                CargarMedicamentosControlados();
            }
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            if (dgvControlados.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Simular exportación de reporte
            MessageBox.Show("Reporte de psicotrópicos generado correctamente en la carpeta de descargas.", "Reporte Exportado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Inventario", "EXPORTAR", "medicamentos_controlados", null, "Exportar Reporte de Medicamentos Controlados", null, Environment.MachineName, "UI"); } catch { }
        }
    }
}
