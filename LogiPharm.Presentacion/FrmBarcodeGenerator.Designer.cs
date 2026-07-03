namespace LogiPharm.Presentacion
{
    partial class FrmBarcodeGenerator
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.groupProducto = new System.Windows.Forms.GroupBox();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.groupGenerator = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pbBarcode = new System.Windows.Forms.PictureBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.groupProducto.SuspendLayout();
            this.groupGenerator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBarcode)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(784, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(12, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(326, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Generador de Códigos de Barras";
            // 
            // groupProducto
            // 
            this.groupProducto.Controls.Add(this.btnBuscarProducto);
            this.groupProducto.Controls.Add(this.txtProducto);
            this.groupProducto.Controls.Add(this.lblProducto);
            this.groupProducto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupProducto.Location = new System.Drawing.Point(17, 80);
            this.groupProducto.Name = "groupProducto";
            this.groupProducto.Size = new System.Drawing.Size(750, 90);
            this.groupProducto.TabIndex = 1;
            this.groupProducto.TabStop = false;
            this.groupProducto.Text = "Seleccionar Producto";
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.btnBuscarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarProducto.ForeColor = System.Drawing.Color.White;
            this.btnBuscarProducto.Location = new System.Drawing.Point(630, 35);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(100, 30);
            this.btnBuscarProducto.TabIndex = 2;
            this.btnBuscarProducto.Text = "Buscar...";
            this.btnBuscarProducto.UseVisualStyleBackColor = false;
            // 
            // txtProducto
            // 
            this.txtProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtProducto.Location = new System.Drawing.Point(100, 38);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.ReadOnly = true;
            this.txtProducto.Size = new System.Drawing.Size(510, 25);
            this.txtProducto.TabIndex = 1;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(15, 41);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(74, 19);
            this.lblProducto.TabIndex = 0;
            this.lblProducto.Text = "Producto:";
            // 
            // groupGenerator
            // 
            this.groupGenerator.Controls.Add(this.btnPrint);
            this.groupGenerator.Controls.Add(this.pbBarcode);
            this.groupGenerator.Controls.Add(this.btnGenerar);
            this.groupGenerator.Controls.Add(this.txtCodigo);
            this.groupGenerator.Controls.Add(this.lblCodigo);
            this.groupGenerator.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupGenerator.Location = new System.Drawing.Point(17, 190);
            this.groupGenerator.Name = "groupGenerator";
            this.groupGenerator.Size = new System.Drawing.Size(750, 340);
            this.groupGenerator.TabIndex = 2;
            this.groupGenerator.TabStop = false;
            this.groupGenerator.Text = "Código y Vista Previa";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnPrint.Enabled = false;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(400, 34);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(150, 30);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Imprimir Etiqueta";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // pbBarcode
            // 
            this.pbBarcode.BackColor = System.Drawing.Color.White;
            this.pbBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbBarcode.Location = new System.Drawing.Point(100, 90);
            this.pbBarcode.Name = "pbBarcode";
            this.pbBarcode.Size = new System.Drawing.Size(550, 220);
            this.pbBarcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbBarcode.TabIndex = 3;
            this.pbBarcode.TabStop = false;
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Location = new System.Drawing.Point(280, 34);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(110, 30);
            this.btnGenerar.TabIndex = 2;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = false;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCodigo.Location = new System.Drawing.Point(100, 37);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(170, 25);
            this.txtCodigo.TabIndex = 1;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(15, 40);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(61, 19);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            // 
            // FrmBarcodeGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupGenerator);
            this.Controls.Add(this.groupProducto);
            this.Controls.Add(this.panelHeader);
            this.Name = "FrmBarcodeGenerator";
            this.Text = "Generador de Códigos de Barras";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.groupProducto.ResumeLayout(false);
            this.groupProducto.PerformLayout();
            this.groupGenerator.ResumeLayout(false);
            this.groupGenerator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBarcode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox groupProducto;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.GroupBox groupGenerator;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.PictureBox pbBarcode;
        private System.Windows.Forms.Button btnPrint;
    }
}
