namespace LogiPharm.Presentacion
{
    partial class FrmFirmaElectronica
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblRuta = new System.Windows.Forms.Label();
            this.txtRutaCertificado = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSeleccionarCertificado = new Guna.UI2.WinForms.Guna2Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtCertificadoPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnValidar = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PanelDetalles = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDetalleTitulo = new System.Windows.Forms.Label();
            this.lblPropietario = new System.Windows.Forms.Label();
            this.lblEmisor = new System.Windows.Forms.Label();
            this.lblVigencia = new System.Windows.Forms.Label();
            this.lblExpiracion = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2Panel1.SuspendLayout();
            this.guna2PanelDetalles.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 16;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.btnCancelar);
            this.guna2Panel1.Controls.Add(this.btnGuardar);
            this.guna2Panel1.Controls.Add(this.guna2PanelDetalles);
            this.guna2Panel1.Controls.Add(this.btnValidar);
            this.guna2Panel1.Controls.Add(this.txtCertificadoPass);
            this.guna2Panel1.Controls.Add(this.lblPassword);
            this.guna2Panel1.Controls.Add(this.btnSeleccionarCertificado);
            this.guna2Panel1.Controls.Add(this.txtRutaCertificado);
            this.guna2Panel1.Controls.Add(this.lblRuta);
            this.guna2Panel1.Controls.Add(this.guna2Separator1);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.guna2ControlBox1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(650, 480);
            this.guna2Panel1.TabIndex = 0;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Separator1.Location = new System.Drawing.Point(25, 55);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(600, 10);
            this.guna2Separator1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Configuración Firma Electrónica";
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.White;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Gray;
            this.guna2ControlBox1.Location = new System.Drawing.Point(602, 3);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 9;
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblRuta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRuta.Location = new System.Drawing.Point(22, 75);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(161, 17);
            this.lblRuta.TabIndex = 10;
            this.lblRuta.Text = "Certificado Digital (.p12):";
            // 
            // txtRutaCertificado
            // 
            this.txtRutaCertificado.BorderRadius = 6;
            this.txtRutaCertificado.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRutaCertificado.DefaultText = "";
            this.txtRutaCertificado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRutaCertificado.Location = new System.Drawing.Point(25, 98);
            this.txtRutaCertificado.Name = "txtRutaCertificado";
            this.txtRutaCertificado.PasswordChar = '\0';
            this.txtRutaCertificado.PlaceholderText = "Ruta del archivo de firma electrónica";
            this.txtRutaCertificado.ReadOnly = true;
            this.txtRutaCertificado.SelectedText = "";
            this.txtRutaCertificado.Size = new System.Drawing.Size(470, 36);
            this.txtRutaCertificado.TabIndex = 11;
            // 
            // btnSeleccionarCertificado
            // 
            this.btnSeleccionarCertificado.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnSeleccionarCertificado.BorderRadius = 6;
            this.btnSeleccionarCertificado.BorderThickness = 1;
            this.btnSeleccionarCertificado.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnSeleccionarCertificado.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnSeleccionarCertificado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSeleccionarCertificado.Location = new System.Drawing.Point(505, 98);
            this.btnSeleccionarCertificado.Name = "btnSeleccionarCertificado";
            this.btnSeleccionarCertificado.Size = new System.Drawing.Size(120, 36);
            this.btnSeleccionarCertificado.TabIndex = 12;
            this.btnSeleccionarCertificado.Text = "Buscar...";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPassword.Location = new System.Drawing.Point(22, 145);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(168, 17);
            this.lblPassword.TabIndex = 13;
            this.lblPassword.Text = "Contraseña del Certificado:";
            // 
            // txtCertificadoPass
            // 
            this.txtCertificadoPass.BorderRadius = 6;
            this.txtCertificadoPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCertificadoPass.DefaultText = "";
            this.txtCertificadoPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCertificadoPass.Location = new System.Drawing.Point(25, 168);
            this.txtCertificadoPass.Name = "txtCertificadoPass";
            this.txtCertificadoPass.PasswordChar = '●';
            this.txtCertificadoPass.PlaceholderText = "Ingrese la contraseña";
            this.txtCertificadoPass.SelectedText = "";
            this.txtCertificadoPass.Size = new System.Drawing.Size(470, 36);
            this.txtCertificadoPass.TabIndex = 14;
            this.txtCertificadoPass.UseSystemPasswordChar = true;
            // 
            // btnValidar
            // 
            this.btnValidar.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnValidar.BorderRadius = 6;
            this.btnValidar.BorderThickness = 1;
            this.btnValidar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.btnValidar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnValidar.ForeColor = System.Drawing.Color.White;
            this.btnValidar.Location = new System.Drawing.Point(505, 168);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(120, 36);
            this.btnValidar.TabIndex = 15;
            this.btnValidar.Text = "Validar";
            // 
            // guna2PanelDetalles
            // 
            this.guna2PanelDetalles.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2PanelDetalles.BorderRadius = 8;
            this.guna2PanelDetalles.BorderThickness = 1;
            this.guna2PanelDetalles.Controls.Add(this.lblEstado);
            this.guna2PanelDetalles.Controls.Add(this.lblExpiracion);
            this.guna2PanelDetalles.Controls.Add(this.lblVigencia);
            this.guna2PanelDetalles.Controls.Add(this.lblEmisor);
            this.guna2PanelDetalles.Controls.Add(this.lblPropietario);
            this.guna2PanelDetalles.Controls.Add(this.lblDetalleTitulo);
            this.guna2PanelDetalles.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.guna2PanelDetalles.Location = new System.Drawing.Point(25, 220);
            this.guna2PanelDetalles.Name = "guna2PanelDetalles";
            this.guna2PanelDetalles.Size = new System.Drawing.Size(600, 175);
            this.guna2PanelDetalles.TabIndex = 16;
            this.guna2PanelDetalles.Visible = false;
            // 
            // lblDetalleTitulo
            // 
            this.lblDetalleTitulo.AutoSize = true;
            this.lblDetalleTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblDetalleTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblDetalleTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.lblDetalleTitulo.Location = new System.Drawing.Point(15, 12);
            this.lblDetalleTitulo.Name = "lblDetalleTitulo";
            this.lblDetalleTitulo.Size = new System.Drawing.Size(175, 20);
            this.lblDetalleTitulo.TabIndex = 0;
            this.lblDetalleTitulo.Text = "Detalles del Certificado";
            // 
            // lblPropietario
            // 
            this.lblPropietario.AutoSize = true;
            this.lblPropietario.BackColor = System.Drawing.Color.Transparent;
            this.lblPropietario.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPropietario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPropietario.Location = new System.Drawing.Point(15, 40);
            this.lblPropietario.Name = "lblPropietario";
            this.lblPropietario.Size = new System.Drawing.Size(81, 17);
            this.lblPropietario.TabIndex = 1;
            this.lblPropietario.Text = "Propietario: -";
            // 
            // lblEmisor
            // 
            this.lblEmisor.AutoSize = true;
            this.lblEmisor.BackColor = System.Drawing.Color.Transparent;
            this.lblEmisor.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEmisor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEmisor.Location = new System.Drawing.Point(15, 65);
            this.lblEmisor.Name = "lblEmisor";
            this.lblEmisor.Size = new System.Drawing.Size(56, 17);
            this.lblEmisor.TabIndex = 2;
            this.lblEmisor.Text = "Emisor: -";
            // 
            // lblVigencia
            // 
            this.lblVigencia.AutoSize = true;
            this.lblVigencia.BackColor = System.Drawing.Color.Transparent;
            this.lblVigencia.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblVigencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblVigencia.Location = new System.Drawing.Point(15, 90);
            this.lblVigencia.Name = "lblVigencia";
            this.lblVigencia.Size = new System.Drawing.Size(95, 17);
            this.lblVigencia.TabIndex = 3;
            this.lblVigencia.Text = "Validez Desde: -";
            // 
            // lblExpiracion
            // 
            this.lblExpiracion.AutoSize = true;
            this.lblExpiracion.BackColor = System.Drawing.Color.Transparent;
            this.lblExpiracion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblExpiracion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblExpiracion.Location = new System.Drawing.Point(15, 115);
            this.lblExpiracion.Name = "lblExpiracion";
            this.lblExpiracion.Size = new System.Drawing.Size(91, 17);
            this.lblExpiracion.TabIndex = 4;
            this.lblExpiracion.Text = "Validez Hasta: -";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.BackColor = System.Drawing.Color.Transparent;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEstado.Location = new System.Drawing.Point(15, 140);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(59, 17);
            this.lblEstado.TabIndex = 5;
            this.lblEstado.Text = "Estado: -";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BorderRadius = 8;
            this.btnCancelar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.btnCancelar.Location = new System.Drawing.Point(370, 415);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 40);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BorderRadius = 8;
            this.btnGuardar.Enabled = false;
            this.btnGuardar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(495, 415);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 40);
            this.btnGuardar.TabIndex = 17;
            this.btnGuardar.Text = "Guardar";
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.BorderRadius = 16;
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // FrmFirmaElectronica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 480);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmFirmaElectronica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración de Firma Electrónica";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2PanelDetalles.ResumeLayout(false);
            this.guna2PanelDetalles.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.Label lblRuta;
        private Guna.UI2.WinForms.Guna2TextBox txtRutaCertificado;
        private Guna.UI2.WinForms.Guna2Button btnSeleccionarCertificado;
        private System.Windows.Forms.Label lblPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtCertificadoPass;
        private Guna.UI2.WinForms.Guna2Button btnValidar;
        private Guna.UI2.WinForms.Guna2Panel guna2PanelDetalles;
        private System.Windows.Forms.Label lblDetalleTitulo;
        private System.Windows.Forms.Label lblPropietario;
        private System.Windows.Forms.Label lblEmisor;
        private System.Windows.Forms.Label lblVigencia;
        private System.Windows.Forms.Label lblExpiracion;
        private System.Windows.Forms.Label lblEstado;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
    }
}
