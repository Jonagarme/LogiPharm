using System;
using System.Windows.Forms;
using LogiPharm.Negocio;
using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Inicio de Sesión - LogiPharm";
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text.Trim();

            EUsuario datos = NUsuario.Login(usuario, clave);

            if (datos != null)
            {
                // Guardar sesión en memoria
                SesionActual.IdUsuario = datos.IdUsuario;
                SesionActual.NombreUsuario = datos.Usuario;
                SesionActual.NombreCompleto = datos.NombreCompleto;
                SesionActual.Rol = datos.Rol;

                // Abrir principal y ocultar login (NO se cierra para poder reusarlo al cerrar sesión)
                var principal = new FrmPrincipal(datos.Rol);
                principal.Show();
                this.Hide();
            }
            else
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos.";
            }
        }

        // (Opcional) Método para limpiar los campos cuando se vuelve a mostrar el login
        public void LimpiarCampos()
        {
            txtUsuario.Clear();
            txtClave.Clear();
            lblMensaje.Text = string.Empty;
            txtUsuario.Focus();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
