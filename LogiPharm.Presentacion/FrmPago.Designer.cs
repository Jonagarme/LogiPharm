namespace LogiPharm.Presentacion
{
    partial class FrmPago
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
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.panelTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCerrar = new FontAwesome.Sharp.IconButton();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblVuelto = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEfectivoRecibido = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalPagar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCobrarImprimir = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnOtros = new Guna.UI2.WinForms.Guna2Button();
            this.btnTransferencia = new Guna.UI2.WinForms.Guna2Button();
            this.btnTarjeta = new Guna.UI2.WinForms.Guna2Button();
            this.btnEfectivo = new Guna.UI2.WinForms.Guna2Button();
            this.panelTop.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            this.guna2GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 12;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.BorderRadius = 12;
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Controls.Add(this.btnCerrar);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(650, 40);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(138, 21);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Forma de Cobro";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnCerrar.IconColor = System.Drawing.Color.White;
            this.btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrar.IconSize = 24;
            this.btnCerrar.Location = new System.Drawing.Point(610, 5);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(32, 32);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.LightGray;
            this.guna2GroupBox1.BorderRadius = 8;
            this.guna2GroupBox1.Controls.Add(this.lblVuelto);
            this.guna2GroupBox1.Controls.Add(this.label5);
            this.guna2GroupBox1.Controls.Add(this.txtEfectivoRecibido);
            this.guna2GroupBox1.Controls.Add(this.label3);
            this.guna2GroupBox1.Controls.Add(this.lblTotalPagar);
            this.guna2GroupBox1.Controls.Add(this.label1);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(16, 55);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(350, 250);
            this.guna2GroupBox1.TabIndex = 1;
            // 
            // lblVuelto
            // 
            this.lblVuelto.BackColor = System.Drawing.Color.Transparent;
            this.lblVuelto.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVuelto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVuelto.Location = new System.Drawing.Point(15, 190);
            this.lblVuelto.Name = "lblVuelto";
            this.lblVuelto.Size = new System.Drawing.Size(320, 37);
            this.lblVuelto.TabIndex = 5;
            this.lblVuelto.Text = "$0.00";
            this.lblVuelto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(15, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "SU VUELTO:";
            // 
            // txtEfectivoRecibido
            // 
            this.txtEfectivoRecibido.BorderRadius = 6;
            this.txtEfectivoRecibido.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEfectivoRecibido.DefaultText = "";
            this.txtEfectivoRecibido.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEfectivoRecibido.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEfectivoRecibido.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEfectivoRecibido.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEfectivoRecibido.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEfectivoRecibido.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtEfectivoRecibido.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEfectivoRecibido.Location = new System.Drawing.Point(19, 120);
            this.txtEfectivoRecibido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEfectivoRecibido.Name = "txtEfectivoRecibido";
            this.txtEfectivoRecibido.PasswordChar = '\0';
            this.txtEfectivoRecibido.PlaceholderText = "0.00";
            this.txtEfectivoRecibido.SelectedText = "";
            this.txtEfectivoRecibido.Size = new System.Drawing.Size(316, 36);
            this.txtEfectivoRecibido.TabIndex = 3;
            this.txtEfectivoRecibido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(16, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Efectivo Recibido:";
            // 
            // lblTotalPagar
            // 
            this.lblTotalPagar.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalPagar.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblTotalPagar.Location = new System.Drawing.Point(15, 45);
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.Size = new System.Drawing.Size(320, 45);
            this.lblTotalPagar.TabIndex = 1;
            this.lblTotalPagar.Text = "$0.00";
            this.lblTotalPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "TOTAL A PAGAR:";
            // 
            // btnCobrarImprimir
            // 
            this.btnCobrarImprimir.BorderRadius = 8;
            this.btnCobrarImprimir.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCobrarImprimir.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCobrarImprimir.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCobrarImprimir.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCobrarImprimir.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnCobrarImprimir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCobrarImprimir.ForeColor = System.Drawing.Color.White;
            this.btnCobrarImprimir.Location = new System.Drawing.Point(16, 311);
            this.btnCobrarImprimir.Name = "btnCobrarImprimir";
            this.btnCobrarImprimir.Size = new System.Drawing.Size(480, 45);
            this.btnCobrarImprimir.TabIndex = 2;
            this.btnCobrarImprimir.Text = "F12 - COBRAR E IMPRIMIR";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BorderRadius = 8;
            this.btnCancelar.BorderColor = System.Drawing.Color.Gray;
            this.btnCancelar.BorderThickness = 1;
            this.btnCancelar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancelar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancelar.FillColor = System.Drawing.Color.White;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancelar.Location = new System.Drawing.Point(502, 311);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(132, 45);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.BorderColor = System.Drawing.Color.LightGray;
            this.guna2GroupBox2.BorderRadius = 8;
            this.guna2GroupBox2.Controls.Add(this.btnOtros);
            this.guna2GroupBox2.Controls.Add(this.btnTransferencia);
            this.guna2GroupBox2.Controls.Add(this.btnTarjeta);
            this.guna2GroupBox2.Controls.Add(this.btnEfectivo);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox2.Location = new System.Drawing.Point(372, 55);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.Size = new System.Drawing.Size(262, 250);
            this.guna2GroupBox2.TabIndex = 6;
            // 
            // btnOtros
            // 
            this.btnOtros.BorderRadius = 6;
            this.btnOtros.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOtros.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOtros.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOtros.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOtros.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnOtros.ForeColor = System.Drawing.Color.White;
            this.btnOtros.Location = new System.Drawing.Point(15, 190);
            this.btnOtros.Name = "btnOtros";
            this.btnOtros.Size = new System.Drawing.Size(230, 45);
            this.btnOtros.TabIndex = 3;
            this.btnOtros.Text = "F8 - Otros";
            // 
            // btnTransferencia
            // 
            this.btnTransferencia.BorderRadius = 6;
            this.btnTransferencia.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTransferencia.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTransferencia.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTransferencia.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTransferencia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnTransferencia.ForeColor = System.Drawing.Color.White;
            this.btnTransferencia.Location = new System.Drawing.Point(15, 139);
            this.btnTransferencia.Name = "btnTransferencia";
            this.btnTransferencia.Size = new System.Drawing.Size(230, 45);
            this.btnTransferencia.TabIndex = 2;
            this.btnTransferencia.Text = "F7 - Transferencia / Depósito";
            // 
            // btnTarjeta
            // 
            this.btnTarjeta.BorderRadius = 6;
            this.btnTarjeta.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTarjeta.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTarjeta.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTarjeta.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTarjeta.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnTarjeta.ForeColor = System.Drawing.Color.White;
            this.btnTarjeta.Location = new System.Drawing.Point(15, 88);
            this.btnTarjeta.Name = "btnTarjeta";
            this.btnTarjeta.Size = new System.Drawing.Size(230, 45);
            this.btnTarjeta.TabIndex = 1;
            this.btnTarjeta.Text = "F6 - Tarjeta Crédito / Débito";
            // 
            // btnEfectivo
            // 
            this.btnEfectivo.BorderRadius = 6;
            this.btnEfectivo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEfectivo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEfectivo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEfectivo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEfectivo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnEfectivo.ForeColor = System.Drawing.Color.White;
            this.btnEfectivo.Location = new System.Drawing.Point(15, 37);
            this.btnEfectivo.Name = "btnEfectivo";
            this.btnEfectivo.Size = new System.Drawing.Size(230, 45);
            this.btnEfectivo.TabIndex = 0;
            this.btnEfectivo.Text = "F5 - Efectivo";
            // 
            // FrmPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(650, 370);
            this.Controls.Add(this.guna2GroupBox2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCobrarImprimir);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmPago_Load);
            this.Text = "Forma de Cobro";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.guna2GroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalPagar;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtEfectivoRecibido;
        private System.Windows.Forms.Label lblVuelto;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;
        private Guna.UI2.WinForms.Guna2Button btnCobrarImprimir;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private Guna.UI2.WinForms.Guna2Button btnOtros;
        private Guna.UI2.WinForms.Guna2Button btnTransferencia;
        private Guna.UI2.WinForms.Guna2Button btnTarjeta;
        private Guna.UI2.WinForms.Guna2Button btnEfectivo;
    }
}
