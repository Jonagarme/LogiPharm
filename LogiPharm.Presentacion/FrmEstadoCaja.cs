using System;
using System.Drawing;
using System.Windows.Forms;
using LogiPharm.Datos;

namespace LogiPharm.Presentacion
{
    public partial class FrmEstadoCaja : Form
    {
        private readonly int _idCaja;
        private readonly DCaja _dCaja;

        public FrmEstadoCaja(int idCaja)
        {
            _idCaja = idCaja;
            _dCaja = new DCaja();
            InitializeComponent();
        }

        private void FrmEstadoCaja_Load(object sender, EventArgs e)
        {
            CargarEstado();
        }

        private void CargarEstado()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                var caja = _dCaja.ObtenerPorId(_idCaja);
                if (caja == null)
                {
                    MessageBox.Show("No se encontró la caja.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    return;
                }

                lblCodigo.Text = caja.Codigo;
                lblNombre.Text = caja.Nombre;
                lblEstado.Text = caja.EstadoTexto;
                lblEstado.ForeColor = Color.FromName(caja.EstadoColor);

                lblActiva.Text = caja.Activa ? "Sí" : "No";
                lblAnulada.Text = caja.Anulado ? "Sí" : "No";
                lblAperturaActiva.Text = caja.TieneAperturaActiva ? "Sí" : "No";

                if (caja.TieneAperturaActiva)
                {
                    pnlApertura.Visible = true;
                    lblFechaApertura.Text = caja.FechaAperturaActiva?.ToString("dd/MM/yyyy HH:mm") ?? "-";
                    lblUsuarioApertura.Text = string.IsNullOrEmpty(caja.NombreUsuarioActivo) ? "-" : caja.NombreUsuarioActivo;
                    lblSaldo.Text = caja.SaldoActual?.ToString("C2") ?? "$0.00";
                }
                else
                {
                    pnlApertura.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar estado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarEstado();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
