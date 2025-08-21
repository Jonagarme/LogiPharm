namespace LogiPharm.Presentacion
{
    partial class FrmEmpresa
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
            this.guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabPageDatosGenerales = new System.Windows.Forms.TabPage();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTelefono = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDireccion = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNombreComercial = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtRazonSocial = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtRuc = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnCambiarLogo = new Guna.UI2.WinForms.Guna2Button();
            this.picLogo = new Guna.UI2.WinForms.Guna2PictureBox();
            this.tabPageFacturacion = new System.Windows.Forms.TabPage();
            this.dtpFechaExpiracion = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCertificadoPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSeleccionarCertificado = new Guna.UI2.WinForms.Guna2Button();
            this.txtRutaCertificado = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2Panel1.SuspendLayout();
            this.guna2TabControl1.SuspendLayout();
            this.tabPageDatosGenerales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.tabPageFacturacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.guna2TabControl1);
            this.guna2Panel1.Controls.Add(this.btnCancelar);
            this.guna2Panel1.Controls.Add(this.btnGuardar);
            this.guna2Panel1.Controls.Add(this.guna2Separator1);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.guna2ControlBox1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(850, 520);
            this.guna2Panel1.TabIndex = 0;
            // 
            // guna2TabControl1
            // 
            this.guna2TabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.guna2TabControl1.Controls.Add(this.tabPageDatosGenerales);
            this.guna2TabControl1.Controls.Add(this.tabPageFacturacion);
            this.guna2TabControl1.ItemSize = new System.Drawing.Size(180, 40);
            this.guna2TabControl1.Location = new System.Drawing.Point(26, 72);
            this.guna2TabControl1.Name = "guna2TabControl1";
            this.guna2TabControl1.SelectedIndex = 0;
            this.guna2TabControl1.Size = new System.Drawing.Size(794, 394);
            this.guna2TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.guna2TabControl1.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.guna2TabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.guna2TabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2TabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonSelectedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.guna2TabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.guna2TabControl1.TabButtonSize = new System.Drawing.Size(180, 40);
            this.guna2TabControl1.TabIndex = 10;
            this.guna2TabControl1.TabMenuBackColor = System.Drawing.Color.White;
            // 
            // tabPageDatosGenerales
            // 
            this.tabPageDatosGenerales.BackColor = System.Drawing.Color.White;
            this.tabPageDatosGenerales.Controls.Add(this.txtEmail);
            this.tabPageDatosGenerales.Controls.Add(this.txtTelefono);
            this.tabPageDatosGenerales.Controls.Add(this.txtDireccion);
            this.tabPageDatosGenerales.Controls.Add(this.txtNombreComercial);
            this.tabPageDatosGenerales.Controls.Add(this.txtRazonSocial);
            this.tabPageDatosGenerales.Controls.Add(this.txtRuc);
            this.tabPageDatosGenerales.Controls.Add(this.btnCambiarLogo);
            this.tabPageDatosGenerales.Controls.Add(this.picLogo);
            this.tabPageDatosGenerales.Location = new System.Drawing.Point(184, 4);
            this.tabPageDatosGenerales.Name = "tabPageDatosGenerales";
            this.tabPageDatosGenerales.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDatosGenerales.Size = new System.Drawing.Size(606, 386);
            this.tabPageDatosGenerales.TabIndex = 0;
            this.tabPageDatosGenerales.Text = "Datos Generales";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderRadius = 6;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail.Location = new System.Drawing.Point(230, 290);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PlaceholderText = "E-mail de Contacto";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(350, 36);
            this.txtEmail.TabIndex = 13;
            // 
            // txtTelefono
            // 
            this.txtTelefono.BorderRadius = 6;
            this.txtTelefono.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTelefono.DefaultText = "";
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTelefono.Location = new System.Drawing.Point(230, 235);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.PasswordChar = '\0';
            this.txtTelefono.PlaceholderText = "Teléfono de la Empresa";
            this.txtTelefono.SelectedText = "";
            this.txtTelefono.Size = new System.Drawing.Size(350, 36);
            this.txtTelefono.TabIndex = 12;
            // 
            // txtDireccion
            // 
            this.txtDireccion.BorderRadius = 6;
            this.txtDireccion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDireccion.DefaultText = "";
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDireccion.Location = new System.Drawing.Point(230, 180);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.PasswordChar = '\0';
            this.txtDireccion.PlaceholderText = "Dirección Matriz";
            this.txtDireccion.SelectedText = "";
            this.txtDireccion.Size = new System.Drawing.Size(350, 36);
            this.txtDireccion.TabIndex = 11;
            // 
            // txtNombreComercial
            // 
            this.txtNombreComercial.BorderRadius = 6;
            this.txtNombreComercial.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNombreComercial.DefaultText = "";
            this.txtNombreComercial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNombreComercial.Location = new System.Drawing.Point(230, 125);
            this.txtNombreComercial.Name = "txtNombreComercial";
            this.txtNombreComercial.PasswordChar = '\0';
            this.txtNombreComercial.PlaceholderText = "Nombre Comercial (Ej: Farmacia LogiPharm)";
            this.txtNombreComercial.SelectedText = "";
            this.txtNombreComercial.Size = new System.Drawing.Size(350, 36);
            this.txtNombreComercial.TabIndex = 10;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BorderRadius = 6;
            this.txtRazonSocial.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRazonSocial.DefaultText = "";
            this.txtRazonSocial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRazonSocial.Location = new System.Drawing.Point(230, 70);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.PasswordChar = '\0';
            this.txtRazonSocial.PlaceholderText = "Razón Social o Nombre del Propietario";
            this.txtRazonSocial.SelectedText = "";
            this.txtRazonSocial.Size = new System.Drawing.Size(350, 36);
            this.txtRazonSocial.TabIndex = 9;
            // 
            // txtRuc
            // 
            this.txtRuc.BorderRadius = 6;
            this.txtRuc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRuc.DefaultText = "";
            this.txtRuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRuc.Location = new System.Drawing.Point(230, 15);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.PasswordChar = '\0';
            this.txtRuc.PlaceholderText = "RUC";
            this.txtRuc.SelectedText = "";
            this.txtRuc.Size = new System.Drawing.Size(350, 36);
            this.txtRuc.TabIndex = 8;
            // 
            // btnCambiarLogo
            // 
            this.btnCambiarLogo.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnCambiarLogo.BorderRadius = 8;
            this.btnCambiarLogo.BorderThickness = 1;
            this.btnCambiarLogo.FillColor = System.Drawing.Color.White;
            this.btnCambiarLogo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCambiarLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCambiarLogo.Location = new System.Drawing.Point(23, 221);
            this.btnCambiarLogo.Name = "btnCambiarLogo";
            this.btnCambiarLogo.Size = new System.Drawing.Size(170, 45);
            this.btnCambiarLogo.TabIndex = 7;
            this.btnCambiarLogo.Text = "Cambiar Logo";
            // 
            // picLogo
            // 
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLogo.ImageRotate = 0F;
            this.picLogo.Location = new System.Drawing.Point(23, 15);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(170, 170);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 4;
            this.picLogo.TabStop = false;
            // 
            // tabPageFacturacion
            // 
            this.tabPageFacturacion.BackColor = System.Drawing.Color.White;
            this.tabPageFacturacion.Controls.Add(this.dtpFechaExpiracion);
            this.tabPageFacturacion.Controls.Add(this.label4);
            this.tabPageFacturacion.Controls.Add(this.txtCertificadoPass);
            this.tabPageFacturacion.Controls.Add(this.btnSeleccionarCertificado);
            this.tabPageFacturacion.Controls.Add(this.txtRutaCertificado);
            this.tabPageFacturacion.Controls.Add(this.label2);
            this.tabPageFacturacion.Location = new System.Drawing.Point(184, 4);
            this.tabPageFacturacion.Name = "tabPageFacturacion";
            this.tabPageFacturacion.Padding = new System.Windows.Forms.Padding(20);
            this.tabPageFacturacion.Size = new System.Drawing.Size(606, 386);
            this.tabPageFacturacion.TabIndex = 1;
            this.tabPageFacturacion.Text = "Facturación Electrónica";
            // 
            // dtpFechaExpiracion
            // 
            this.dtpFechaExpiracion.BorderRadius = 6;
            this.dtpFechaExpiracion.Checked = true;
            this.dtpFechaExpiracion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaExpiracion.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpFechaExpiracion.Location = new System.Drawing.Point(23, 200);
            this.dtpFechaExpiracion.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFechaExpiracion.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFechaExpiracion.Name = "dtpFechaExpiracion";
            this.dtpFechaExpiracion.Size = new System.Drawing.Size(560, 36);
            this.dtpFechaExpiracion.TabIndex = 5;
            this.dtpFechaExpiracion.Value = new System.DateTime(2025, 8, 20, 20, 8, 30, 95);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(20, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Fecha de Expiración:";
            // 
            // txtCertificadoPass
            // 
            this.txtCertificadoPass.BorderRadius = 6;
            this.txtCertificadoPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCertificadoPass.DefaultText = "";
            this.txtCertificadoPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCertificadoPass.Location = new System.Drawing.Point(23, 128);
            this.txtCertificadoPass.Name = "txtCertificadoPass";
            this.txtCertificadoPass.PasswordChar = '●';
            this.txtCertificadoPass.PlaceholderText = "Contraseña del Certificado";
            this.txtCertificadoPass.SelectedText = "";
            this.txtCertificadoPass.Size = new System.Drawing.Size(560, 36);
            this.txtCertificadoPass.TabIndex = 3;
            this.txtCertificadoPass.UseSystemPasswordChar = true;
            // 
            // btnSeleccionarCertificado
            // 
            this.btnSeleccionarCertificado.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnSeleccionarCertificado.BorderRadius = 6;
            this.btnSeleccionarCertificado.BorderThickness = 1;
            this.btnSeleccionarCertificado.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnSeleccionarCertificado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSeleccionarCertificado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSeleccionarCertificado.Location = new System.Drawing.Point(463, 56);
            this.btnSeleccionarCertificado.Name = "btnSeleccionarCertificado";
            this.btnSeleccionarCertificado.Size = new System.Drawing.Size(120, 36);
            this.btnSeleccionarCertificado.TabIndex = 2;
            this.btnSeleccionarCertificado.Text = "Seleccionar...";
            // 
            // txtRutaCertificado
            // 
            this.txtRutaCertificado.BorderRadius = 6;
            this.txtRutaCertificado.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRutaCertificado.DefaultText = "";
            this.txtRutaCertificado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRutaCertificado.Location = new System.Drawing.Point(23, 56);
            this.txtRutaCertificado.Name = "txtRutaCertificado";
            this.txtRutaCertificado.PasswordChar = '\0';
            this.txtRutaCertificado.PlaceholderText = "Ruta del archivo .p12";
            this.txtRutaCertificado.ReadOnly = true;
            this.txtRutaCertificado.SelectedText = "";
            this.txtRutaCertificado.Size = new System.Drawing.Size(434, 36);
            this.txtRutaCertificado.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(19, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Certificado Digital";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BorderRadius = 8;
            this.btnCancelar.FillColor = System.Drawing.Color.Gainsboro;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancelar.Location = new System.Drawing.Point(571, 477);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 40);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BorderRadius = 8;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(697, 477);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(140, 40);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar Cambios";
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Separator1.Location = new System.Drawing.Point(26, 56);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(794, 10);
            this.guna2Separator1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Administración de la Empresa";
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.White;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Gray;
            this.guna2ControlBox1.Location = new System.Drawing.Point(802, 3);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 9;
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.BorderRadius = 20;
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // FrmEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 520);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmEmpresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración de la Empresa";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2TabControl1.ResumeLayout(false);
            this.tabPageDatosGenerales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.tabPageFacturacion.ResumeLayout(false);
            this.tabPageFacturacion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2PictureBox picLogo;
        private Guna.UI2.WinForms.Guna2Button btnCambiarLogo;
        private Guna.UI2.WinForms.Guna2TextBox txtRuc;
        private Guna.UI2.WinForms.Guna2TextBox txtRazonSocial;
        private Guna.UI2.WinForms.Guna2TextBox txtNombreComercial;
        private Guna.UI2.WinForms.Guna2TextBox txtDireccion;
        private Guna.UI2.WinForms.Guna2TextBox txtTelefono;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2TabControl guna2TabControl1;
        private System.Windows.Forms.TabPage tabPageDatosGenerales;
        private System.Windows.Forms.TabPage tabPageFacturacion;
        private Guna.UI2.WinForms.Guna2TextBox txtRutaCertificado;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnSeleccionarCertificado;
        private Guna.UI2.WinForms.Guna2TextBox txtCertificadoPass;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFechaExpiracion;
        private System.Windows.Forms.Label label4;
    }
}