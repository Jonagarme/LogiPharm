namespace LogiPharm.Presentacion
{
    partial class FrmEstadoCaja
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
            this.panelTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCerrar = new Guna.UI2.WinForms.Guna2Button();
            this.gbInfo = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblAperturaActiva = new System.Windows.Forms.Label();
            this.lblAnulada = new System.Windows.Forms.Label();
            this.lblActiva = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlApertura = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.lblUsuarioApertura = new System.Windows.Forms.Label();
            this.lblFechaApertura = new System.Windows.Forms.Label();
            this.labelSaldo = new System.Windows.Forms.Label();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.btnRefrescar = new Guna.UI2.WinForms.Guna2Button();
            this.panelTop.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.pnlApertura.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Controls.Add(this.btnCerrar);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(520, 48);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(12, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(153, 21);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Estado de Caja";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BorderRadius = 8;
            this.btnCerrar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(460, 9);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(48, 30);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "?";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // gbInfo
            // 
            this.gbInfo.BackColor = System.Drawing.Color.Transparent;
            this.gbInfo.BorderRadius = 8;
            this.gbInfo.Controls.Add(this.lblAperturaActiva);
            this.gbInfo.Controls.Add(this.lblAnulada);
            this.gbInfo.Controls.Add(this.lblActiva);
            this.gbInfo.Controls.Add(this.lblEstado);
            this.gbInfo.Controls.Add(this.lblNombre);
            this.gbInfo.Controls.Add(this.lblCodigo);
            this.gbInfo.Controls.Add(this.label6);
            this.gbInfo.Controls.Add(this.label5);
            this.gbInfo.Controls.Add(this.label4);
            this.gbInfo.Controls.Add(this.label3);
            this.gbInfo.Controls.Add(this.label2);
            this.gbInfo.Controls.Add(this.label1);
            this.gbInfo.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.gbInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbInfo.Location = new System.Drawing.Point(12, 60);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(496, 182);
            this.gbInfo.TabIndex = 1;
            this.gbInfo.Text = "Información";
            // 
            // lblAperturaActiva
            // 
            this.lblAperturaActiva.AutoSize = true;
            this.lblAperturaActiva.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAperturaActiva.Location = new System.Drawing.Point(160, 154);
            this.lblAperturaActiva.Name = "lblAperturaActiva";
            this.lblAperturaActiva.Size = new System.Drawing.Size(12, 15);
            this.lblAperturaActiva.TabIndex = 11;
            this.lblAperturaActiva.Text = "-";
            // 
            // lblAnulada
            // 
            this.lblAnulada.AutoSize = true;
            this.lblAnulada.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAnulada.Location = new System.Drawing.Point(160, 129);
            this.lblAnulada.Name = "lblAnulada";
            this.lblAnulada.Size = new System.Drawing.Size(12, 15);
            this.lblAnulada.TabIndex = 10;
            this.lblAnulada.Text = "-";
            // 
            // lblActiva
            // 
            this.lblActiva.AutoSize = true;
            this.lblActiva.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblActiva.Location = new System.Drawing.Point(160, 104);
            this.lblActiva.Name = "lblActiva";
            this.lblActiva.Size = new System.Drawing.Size(12, 15);
            this.lblActiva.TabIndex = 9;
            this.lblActiva.Text = "-";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstado.Location = new System.Drawing.Point(160, 79);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(12, 15);
            this.lblEstado.TabIndex = 8;
            this.lblEstado.Text = "-";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombre.Location = new System.Drawing.Point(160, 54);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(12, 15);
            this.lblNombre.TabIndex = 7;
            this.lblNombre.Text = "-";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCodigo.Location = new System.Drawing.Point(160, 29);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(12, 15);
            this.lblCodigo.TabIndex = 6;
            this.lblCodigo.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.Location = new System.Drawing.Point(14, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Apertura activa:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.Location = new System.Drawing.Point(14, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Anulada:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.Location = new System.Drawing.Point(14, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Activa:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(14, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Estado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(14, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(14, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // pnlApertura
            // 
            this.pnlApertura.BorderRadius = 8;
            this.pnlApertura.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.pnlApertura.Controls.Add(this.lblSaldo);
            this.pnlApertura.Controls.Add(this.lblUsuarioApertura);
            this.pnlApertura.Controls.Add(this.lblFechaApertura);
            this.pnlApertura.Controls.Add(this.labelSaldo);
            this.pnlApertura.Controls.Add(this.labelUsuario);
            this.pnlApertura.Controls.Add(this.labelFecha);
            this.pnlApertura.Location = new System.Drawing.Point(12, 250);
            this.pnlApertura.Name = "pnlApertura";
            this.pnlApertura.Size = new System.Drawing.Size(496, 92);
            this.pnlApertura.TabIndex = 2;
            this.pnlApertura.Visible = false;
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSaldo.Location = new System.Drawing.Point(160, 63);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(12, 15);
            this.lblSaldo.TabIndex = 5;
            this.lblSaldo.Text = "-";
            // 
            // lblUsuarioApertura
            // 
            this.lblUsuarioApertura.AutoSize = true;
            this.lblUsuarioApertura.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsuarioApertura.Location = new System.Drawing.Point(160, 38);
            this.lblUsuarioApertura.Name = "lblUsuarioApertura";
            this.lblUsuarioApertura.Size = new System.Drawing.Size(12, 15);
            this.lblUsuarioApertura.TabIndex = 4;
            this.lblUsuarioApertura.Text = "-";
            // 
            // lblFechaApertura
            // 
            this.lblFechaApertura.AutoSize = true;
            this.lblFechaApertura.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaApertura.Location = new System.Drawing.Point(160, 13);
            this.lblFechaApertura.Name = "lblFechaApertura";
            this.lblFechaApertura.Size = new System.Drawing.Size(12, 15);
            this.lblFechaApertura.TabIndex = 3;
            this.lblFechaApertura.Text = "-";
            // 
            // labelSaldo
            // 
            this.labelSaldo.AutoSize = true;
            this.labelSaldo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelSaldo.Location = new System.Drawing.Point(14, 63);
            this.labelSaldo.Name = "labelSaldo";
            this.labelSaldo.Size = new System.Drawing.Size(39, 15);
            this.labelSaldo.TabIndex = 2;
            this.labelSaldo.Text = "Saldo:";
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelUsuario.Location = new System.Drawing.Point(14, 38);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(50, 15);
            this.labelUsuario.TabIndex = 1;
            this.labelUsuario.Text = "Usuario:";
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelFecha.Location = new System.Drawing.Point(14, 13);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(91, 15);
            this.labelFecha.TabIndex = 0;
            this.labelFecha.Text = "Fecha apertura:";
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.BorderRadius = 8;
            this.btnRefrescar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(12, 355);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(160, 40);
            this.btnRefrescar.TabIndex = 3;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // FrmEstadoCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(520, 410);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.pnlApertura);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEstadoCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Estado de Caja";
            this.Load += new System.EventHandler(this.FrmEstadoCaja_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.pnlApertura.ResumeLayout(false);
            this.pnlApertura.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;
        private Guna.UI2.WinForms.Guna2Button btnCerrar;
        private Guna.UI2.WinForms.Guna2GroupBox gbInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblActiva;
        private System.Windows.Forms.Label lblAnulada;
        private System.Windows.Forms.Label lblAperturaActiva;
        private Guna.UI2.WinForms.Guna2Panel pnlApertura;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Label labelSaldo;
        private System.Windows.Forms.Label lblFechaApertura;
        private System.Windows.Forms.Label lblUsuarioApertura;
        private System.Windows.Forms.Label lblSaldo;
        private Guna.UI2.WinForms.Guna2Button btnRefrescar;
    }
}
