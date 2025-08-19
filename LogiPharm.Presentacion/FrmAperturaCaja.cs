using System;
using System.Windows.Forms;
using LogiPharm.Datos; // ✨ Asegúrate de tener este using
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmAperturaCaja : Form
    {
        public decimal MontoInicial { get; private set; }

        public FrmAperturaCaja()
        {
            InitializeComponent();
            this.Load += FrmAperturaCaja_Load;
            this.btnAbrirCaja.Click += btnAbrirCaja_Click;
            this.txtMontoInicial.KeyPress += txtMontoInicial_KeyPress;
        }

        private void FrmAperturaCaja_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy");
            lblCajero.Text = SesionActual.NombreUsuario;
            lblCaja.Text = "CAJA 001"; // Esto debería venir de una configuración o de la sesión
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtMontoInicial.Text, out decimal monto) && monto >= 0)
            {
                try
                {
                    // ✨ 1. Preparamos los datos para guardar
                    this.MontoInicial = monto;
                    int idUsuarioActual = SesionActual.IdUsuario; // Debes tener el ID del usuario en tu sesión
                    int idCajaActual = 1; // Asumiendo que CAJA 001 es el ID 1. Deberías obtenerlo de forma dinámica.

                    // ✨ 2. Llamamos a la capa de datos para registrar la apertura
                    DCierreCaja d_Cierre = new DCierreCaja();
                    d_Cierre.RegistrarApertura(this.MontoInicial, idUsuarioActual, idCajaActual);

                    // ✨ 3. Si todo sale bien, confirmamos y cerramos
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar la apertura de caja: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un monto inicial válido y positivo.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontoInicial.Focus();
                txtMontoInicial.SelectAll();
            }
        }

        private void txtMontoInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, un solo punto decimal y teclas de control (como borrar)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}