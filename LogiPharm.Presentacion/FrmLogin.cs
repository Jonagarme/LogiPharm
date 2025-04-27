using System;
using System.Drawing;
using System.Windows.Forms;
using LogiPharm.Negocio;
using LogiPharm.Entidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //this.MaximizeBox = false;
            this.Text = "Inicio de Sesión - LogiPharm";
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text.Trim();

            EUsuario datos = NUsuario.Login(usuario, clave);

            if (datos != null)
            {
                FrmPrincipal principal = new FrmPrincipal();
                principal.Show();
                this.Hide();
            }
            else
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos.";
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // o Application.Exit();
        }

    }
}
