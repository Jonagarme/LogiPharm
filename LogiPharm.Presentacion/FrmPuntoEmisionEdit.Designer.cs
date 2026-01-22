namespace LogiPharm.Presentacion
{
    partial class FrmPuntoEmisionEdit
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblUsuario;
        private Guna.UI2.WinForms.Guna2CheckBox chkActivo;

        private Guna.UI2.WinForms.Guna2TextBox txtCodigo;
        private Guna.UI2.WinForms.Guna2TextBox txtDescripcion;
        private Guna.UI2.WinForms.Guna2ComboBox cboUsuarioResponsable;

        private System.Windows.Forms.GroupBox grpSecuenciales;
        private System.Windows.Forms.Label lblFactura;
        private System.Windows.Forms.Label lblNotaCredito;
        private System.Windows.Forms.Label lblNotaDebito;
        private System.Windows.Forms.Label lblGuia;
        private System.Windows.Forms.Label lblRetencion;

        private Guna.UI2.WinForms.Guna2NumericUpDown numFactura;
        private Guna.UI2.WinForms.Guna2NumericUpDown numNotaCredito;
        private Guna.UI2.WinForms.Guna2NumericUpDown numNotaDebito;
        private Guna.UI2.WinForms.Guna2NumericUpDown numGuiaRemision;
        private Guna.UI2.WinForms.Guna2NumericUpDown numRetencion;

        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.chkActivo = new Guna.UI2.WinForms.Guna2CheckBox();

            this.txtCodigo = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDescripcion = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboUsuarioResponsable = new Guna.UI2.WinForms.Guna2ComboBox();

            this.grpSecuenciales = new System.Windows.Forms.GroupBox();
            this.lblFactura = new System.Windows.Forms.Label();
            this.lblNotaCredito = new System.Windows.Forms.Label();
            this.lblNotaDebito = new System.Windows.Forms.Label();
            this.lblGuia = new System.Windows.Forms.Label();
            this.lblRetencion = new System.Windows.Forms.Label();

            this.numFactura = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.numNotaCredito = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.numNotaDebito = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.numGuiaRemision = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.numRetencion = new Guna.UI2.WinForms.Guna2NumericUpDown();

            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancelar = new Guna.UI2.WinForms.Guna2Button();

            this.grpSecuenciales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNotaCredito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNotaDebito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGuiaRemision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRetencion)).BeginInit();
            this.SuspendLayout();

            // 
            // FrmPuntoEmisionEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(620, 430);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "FrmPuntoEmisionEdit";
            this.Text = "Punto de Emisión";

            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(24, 25);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(96, 13);
            this.lblCodigo.Text = "Código (3 dígitos):";

            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(150, 22);
            this.txtCodigo.MaxLength = 3;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(120, 28);
            this.txtCodigo.BorderRadius = 6;

            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(24, 60);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.Text = "Descripción:";

            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(150, 57);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(440, 28);
            this.txtDescripcion.BorderRadius = 6;

            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(24, 95);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(98, 13);
            this.lblUsuario.Text = "Usuario responsable:";

            // 
            // cboUsuarioResponsable
            // 
            this.cboUsuarioResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsuarioResponsable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboUsuarioResponsable.ItemHeight = 30;
            this.cboUsuarioResponsable.BorderRadius = 6;
            this.cboUsuarioResponsable.Location = new System.Drawing.Point(150, 92);
            this.cboUsuarioResponsable.Name = "cboUsuarioResponsable";
            this.cboUsuarioResponsable.Size = new System.Drawing.Size(240, 36);

            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Location = new System.Drawing.Point(150, 125);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(82, 17);
            this.chkActivo.Text = "Punto activo";
            this.chkActivo.UseVisualStyleBackColor = true;

            // 
            // grpSecuenciales
            // 
            this.grpSecuenciales.BackColor = System.Drawing.Color.White;
            this.grpSecuenciales.Controls.Add(this.lblFactura);
            this.grpSecuenciales.Controls.Add(this.lblNotaCredito);
            this.grpSecuenciales.Controls.Add(this.lblNotaDebito);
            this.grpSecuenciales.Controls.Add(this.lblGuia);
            this.grpSecuenciales.Controls.Add(this.lblRetencion);
            this.grpSecuenciales.Controls.Add(this.numFactura);
            this.grpSecuenciales.Controls.Add(this.numNotaCredito);
            this.grpSecuenciales.Controls.Add(this.numNotaDebito);
            this.grpSecuenciales.Controls.Add(this.numGuiaRemision);
            this.grpSecuenciales.Controls.Add(this.numRetencion);
            this.grpSecuenciales.Location = new System.Drawing.Point(27, 160);
            this.grpSecuenciales.Name = "grpSecuenciales";
            this.grpSecuenciales.Size = new System.Drawing.Size(563, 195);
            this.grpSecuenciales.TabStop = false;
            this.grpSecuenciales.Text = "Secuenciales (inicio / actual)";

            // 
            // labels secuenciales
            // 
            this.lblFactura.AutoSize = true;
            this.lblFactura.Location = new System.Drawing.Point(20, 35);
            this.lblFactura.Text = "Factura:";

            this.lblNotaCredito.AutoSize = true;
            this.lblNotaCredito.Location = new System.Drawing.Point(20, 70);
            this.lblNotaCredito.Text = "Nota de Crédito:";

            this.lblNotaDebito.AutoSize = true;
            this.lblNotaDebito.Location = new System.Drawing.Point(20, 105);
            this.lblNotaDebito.Text = "Nota de Débito:";

            this.lblGuia.AutoSize = true;
            this.lblGuia.Location = new System.Drawing.Point(300, 35);
            this.lblGuia.Text = "Guía Remisión:";

            this.lblRetencion.AutoSize = true;
            this.lblRetencion.Location = new System.Drawing.Point(300, 70);
            this.lblRetencion.Text = "Retención:";

            // 
            // NumericUpDowns
            // 
            this.numFactura.Location = new System.Drawing.Point(125, 33);
            this.numFactura.Minimum = 1;
            this.numFactura.Maximum = 999999999;
            this.numFactura.Name = "numFactura";
            this.numFactura.Size = new System.Drawing.Size(120, 28);
            this.numFactura.BorderRadius = 6;
            this.numFactura.Value = 1;

            this.numNotaCredito.Location = new System.Drawing.Point(125, 68);
            this.numNotaCredito.Minimum = 1;
            this.numNotaCredito.Maximum = 999999999;
            this.numNotaCredito.Name = "numNotaCredito";
            this.numNotaCredito.Size = new System.Drawing.Size(120, 28);
            this.numNotaCredito.BorderRadius = 6;
            this.numNotaCredito.Value = 1;

            this.numNotaDebito.Location = new System.Drawing.Point(125, 103);
            this.numNotaDebito.Minimum = 1;
            this.numNotaDebito.Maximum = 999999999;
            this.numNotaDebito.Name = "numNotaDebito";
            this.numNotaDebito.Size = new System.Drawing.Size(120, 28);
            this.numNotaDebito.BorderRadius = 6;
            this.numNotaDebito.Value = 1;

            this.numGuiaRemision.Location = new System.Drawing.Point(410, 33);
            this.numGuiaRemision.Minimum = 1;
            this.numGuiaRemision.Maximum = 999999999;
            this.numGuiaRemision.Name = "numGuiaRemision";
            this.numGuiaRemision.Size = new System.Drawing.Size(120, 28);
            this.numGuiaRemision.BorderRadius = 6;
            this.numGuiaRemision.Value = 1;

            this.numRetencion.Location = new System.Drawing.Point(410, 68);
            this.numRetencion.Minimum = 1;
            this.numRetencion.Maximum = 999999999;
            this.numRetencion.Name = "numRetencion";
            this.numRetencion.Size = new System.Drawing.Size(120, 28);
            this.numRetencion.BorderRadius = 6;
            this.numRetencion.Value = 1;

            // 
            // btnGuardar
            // 
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(480, 375);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 30);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.BorderRadius = 6;
            this.btnGuardar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));

            // 
            // btnCancelar
            // 
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(364, 375);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 30);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.BorderRadius = 6;
            this.btnCancelar.FillColor = System.Drawing.Color.Gainsboro;

            // 
            // Controls
            // 
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.cboUsuarioResponsable);
            this.Controls.Add(this.chkActivo);
            this.Controls.Add(this.grpSecuenciales);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);

            this.grpSecuenciales.ResumeLayout(false);
            this.grpSecuenciales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNotaCredito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNotaDebito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGuiaRemision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRetencion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
