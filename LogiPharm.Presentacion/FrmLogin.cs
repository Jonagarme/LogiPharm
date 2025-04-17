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
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Text = "Inicio de Sesión - LogiPharm";
            //CargarControles();
        }

        //TextBox txtUsuario;
        //TextBox txtClave;
        //Label lblMensaje;

        //private void CargarControles()
        //{
        //    Label lblUsuario = new Label() { Text = "Usuario:", Left = 30, Top = 30, Width = 80 };
        //    txtUsuario = new TextBox() { Left = 120, Top = 30, Width = 180 };

        //    Label lblClave = new Label() { Text = "Contraseña:", Left = 30, Top = 70, Width = 80 };
        //    txtClave = new TextBox() { Left = 120, Top = 70, Width = 180, UseSystemPasswordChar = true };

        //    Button btnLogin = new Button() { Text = "Iniciar Sesión", Left = 120, Top = 110, Width = 180 };
        //    btnLogin.Click += BtnLogin_Click;

        //    lblMensaje = new Label() { Left = 30, Top = 150, Width = 300, ForeColor = Color.Red };

        //    this.Controls.Add(lblUsuario);
        //    this.Controls.Add(txtUsuario);
        //    this.Controls.Add(lblClave);
        //    this.Controls.Add(txtClave);
        //    this.Controls.Add(btnLogin);
        //    this.Controls.Add(lblMensaje);

        //    this.ClientSize = new Size(350, 200);
        //}

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
    }
}
