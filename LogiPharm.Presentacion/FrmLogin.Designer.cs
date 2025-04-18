using System;
using System.Drawing;
using System.Windows.Forms;


namespace LogiPharm.Presentacion
{
    partial class FrmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.panelLateral = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();

            // 
            // Form settings
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(540, 240);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Login";

            // 
            // panelLateral
            // 
            this.panelLateral.BackColor = System.Drawing.Color.SeaGreen;
            this.panelLateral.Dock = DockStyle.Left;
            this.panelLateral.Width = 200;

            // 
            // pictureBoxLogo
            // 
            //this.pictureBoxLogo.Image = Properties.Resources.LogoCanal; // asegúrate que el recurso esté disponible
            this.pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.Location = new Point(40, 40);
            this.pictureBoxLogo.Size = new Size(120, 120);
            this.panelLateral.Controls.Add(this.pictureBoxLogo);

            // 
            // lblTitulo
            // 
            this.lblTitulo.Text = "INICIAR SESIÓN";
            this.lblTitulo.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.lblTitulo.Location = new Point(220, 20);
            this.lblTitulo.AutoSize = true;

            // 
            // lblUsuario
            // 
            this.lblUsuario.Text = "Usuario:";
            this.lblUsuario.Location = new Point(220, 60);
            this.lblUsuario.Font = new Font("Segoe UI", 9);
            this.lblUsuario.AutoSize = true;

            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new Point(220, 80);
            this.txtUsuario.Size = new Size(280, 23);
            this.txtUsuario.Font = new Font("Segoe UI", 10);

            // 
            // lblClave
            // 
            this.lblClave.Text = "Contraseña:";
            this.lblClave.Location = new Point(220, 115);
            this.lblClave.Font = new Font("Segoe UI", 9);
            this.lblClave.AutoSize = true;

            // 
            // txtClave
            // 
            this.txtClave.Location = new Point(220, 135);
            this.txtClave.Size = new Size(280, 23);
            this.txtClave.Font = new Font("Segoe UI", 10);
            this.txtClave.UseSystemPasswordChar = true;

            // 
            // btnLogin
            // 
            this.btnLogin.Text = "Iniciar Sesión";
            this.btnLogin.BackColor = Color.SeaGreen;
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.Location = new Point(220, 180);
            this.btnLogin.Size = new Size(130, 30);
            this.btnLogin.Click += new EventHandler(this.BtnLogin_Click);

            // 
            // btnCancelar
            // 
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.BackColor = Color.DarkRed;
            this.btnCancelar.ForeColor = Color.White;
            this.btnCancelar.FlatStyle = FlatStyle.Flat;
            this.btnCancelar.Location = new Point(370, 180);
            this.btnCancelar.Size = new Size(130, 30);
            this.btnCancelar.Click += new EventHandler(this.BtnCancelar_Click);

            // 
            // lblMensaje
            // 
            this.lblMensaje.ForeColor = Color.Red;
            this.lblMensaje.TextAlign = ContentAlignment.MiddleCenter;
            this.lblMensaje.Font = new Font("Segoe UI", 9);
            this.lblMensaje.Location = new Point(220, 215);
            this.lblMensaje.Size = new Size(280, 20);

            // 
            // Add controls
            // 
            this.Controls.Add(this.panelLateral);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblClave);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblMensaje);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        #endregion

        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panelLateral;
        private System.Windows.Forms.PictureBox pictureBoxLogo;

    }
}