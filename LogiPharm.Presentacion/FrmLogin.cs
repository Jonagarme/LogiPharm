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
            
            // Configurar Enter para iniciar sesión
            this.AcceptButton = btnLogin;
            
            // Agregar manejadores de tecla Enter para cada textbox
            txtCompanyId.KeyDown += Txt_KeyDown;
            txtUsuario.KeyDown += Txt_KeyDown;
            txtClave.KeyDown += Txt_KeyDown;
        }

        private void Txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                BtnLogin_Click(sender, e);
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string companyId = txtCompanyId.Text.Trim();
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text.Trim();

            if (string.IsNullOrEmpty(companyId) || string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(clave))
            {
                lblMensaje.Text = "Por favor, complete todos los campos.";
                return;
            }

            try
            {
                EUsuario datos = NUsuario.Login(companyId, usuario, clave);

                if (datos != null)
                {
                    // Guardar sesión en memoria
                    SesionActual.IdUsuario = datos.IdUsuario;
                    SesionActual.NombreUsuario = datos.Usuario;
                    SesionActual.NombreCompleto = datos.NombreCompleto;
                    SesionActual.Rol = datos.Rol;
                    SesionActual.IdEmpresa = datos.IdEmpresa;
                    SesionActual.IdUbicacion = datos.IdUbicacion;

                    // Configurar la conexión con la empresa seleccionada
                    CapaDatos.Conexion.IdEmpresa = datos.IdEmpresa;

                    // ✅ DETECTAR AUTOMÁTICAMENTE LA CAJA ABIERTA
                    SesionActual.ConfigurarCaja();

                    // Auditoría: LOGIN
                    NBitacora.Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Login", "LOGIN", "usuarios", SesionActual.IdUsuario, "Inicio de sesión exitoso", null, Environment.MachineName, "UI");

                    // Abrir principal y ocultar login (NO se cierra para poder reusarlo al cerrar sesión)
                    var principal = new FrmPrincipal(datos.Rol);
                    principal.Show();
                    this.Hide();
                }
                else
                {
                    lblMensaje.Text = "Usuario o contraseña incorrectos.";
                    txtClave.Clear();
                    txtClave.Focus();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                txtClave.Clear();
            }
        }

        // (Opcional) Método para limpiar los campos cuando se vuelve a mostrar el login
        public void LimpiarCampos()
        {
            txtCompanyId.Clear();
            txtUsuario.Clear();
            txtClave.Clear();
            lblMensaje.Text = string.Empty;
            txtCompanyId.Focus();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
