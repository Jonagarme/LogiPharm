namespace LogiPharm.Presentacion
{
    partial class FrmLoteDetalle
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

        private void InitializeComponent()
        {
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.cboUbicacion = new System.Windows.Forms.ComboBox();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.txtNumeroLote = new System.Windows.Forms.TextBox();
            this.lblNumeroLote = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.lblFechaIngreso = new System.Windows.Forms.Label();
            this.dtpFechaFabricacion = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFabricacion = new System.Windows.Forms.Label();
            this.dtpFechaCaducidad = new System.Windows.Forms.DateTimePicker();
            this.lblFechaCaducidad = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numCantidadInicial = new System.Windows.Forms.NumericUpDown();
            this.lblCantidadInicial = new System.Windows.Forms.Label();
            this.numCostoUnitario = new System.Windows.Forms.NumericUpDown();
            this.lblCostoUnitario = new System.Windows.Forms.Label();
            this.txtNumeroFactura = new System.Windows.Forms.TextBox();
            this.lblNumeroFactura = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlTitulo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidadInicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCostoUnitario)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.BackColor = System.Drawing.ColorTranslator.FromHtml("#2C3E50");
            this.pnlTitulo.Controls.Add(this.lblTitulo);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(700, 50);
            this.pnlTitulo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblTitulo.Size = new System.Drawing.Size(700, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Detalle de Lote";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNumeroLote);
            this.groupBox1.Controls.Add(this.txtNumeroLote);
            this.groupBox1.Controls.Add(this.lblUbicacion);
            this.groupBox1.Controls.Add(this.cboUbicacion);
            this.groupBox1.Controls.Add(this.lblProducto);
            this.groupBox1.Controls.Add(this.txtProducto);
            this.groupBox1.Controls.Add(this.btnBuscarProducto);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(20, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 120);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información General";
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.BackColor = System.Drawing.ColorTranslator.FromHtml("#3498DB");
            this.btnBuscarProducto.FlatAppearance.BorderSize = 0;
            this.btnBuscarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarProducto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBuscarProducto.ForeColor = System.Drawing.Color.White;
            this.btnBuscarProducto.Location = new System.Drawing.Point(605, 40);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(40, 24);
            this.btnBuscarProducto.TabIndex = 1;
            this.btnBuscarProducto.Text = "...";
            this.btnBuscarProducto.UseVisualStyleBackColor = false;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // txtProducto
            // 
            this.txtProducto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtProducto.Location = new System.Drawing.Point(110, 41);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.ReadOnly = true;
            this.txtProducto.Size = new System.Drawing.Size(489, 23);
            this.txtProducto.TabIndex = 0;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProducto.Location = new System.Drawing.Point(15, 44);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(65, 15);
            this.lblProducto.TabIndex = 2;
            this.lblProducto.Text = "Producto:*";
            // 
            // cboUbicacion
            // 
            this.cboUbicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUbicacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboUbicacion.FormattingEnabled = true;
            this.cboUbicacion.Location = new System.Drawing.Point(110, 79);
            this.cboUbicacion.Name = "cboUbicacion";
            this.cboUbicacion.Size = new System.Drawing.Size(200, 23);
            this.cboUbicacion.TabIndex = 2;
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUbicacion.Location = new System.Drawing.Point(15, 82);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(68, 15);
            this.lblUbicacion.TabIndex = 4;
            this.lblUbicacion.Text = "Ubicación:*";
            // 
            // txtNumeroLote
            // 
            this.txtNumeroLote.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNumeroLote.Location = new System.Drawing.Point(445, 79);
            this.txtNumeroLote.Name = "txtNumeroLote";
            this.txtNumeroLote.Size = new System.Drawing.Size(200, 23);
            this.txtNumeroLote.TabIndex = 3;
            // 
            // lblNumeroLote
            // 
            this.lblNumeroLote.AutoSize = true;
            this.lblNumeroLote.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNumeroLote.Location = new System.Drawing.Point(340, 82);
            this.lblNumeroLote.Name = "lblNumeroLote";
            this.lblNumeroLote.Size = new System.Drawing.Size(79, 15);
            this.lblNumeroLote.TabIndex = 6;
            this.lblNumeroLote.Text = "Número Lote:*";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblFechaCaducidad);
            this.groupBox2.Controls.Add(this.dtpFechaCaducidad);
            this.groupBox2.Controls.Add(this.lblFechaFabricacion);
            this.groupBox2.Controls.Add(this.dtpFechaFabricacion);
            this.groupBox2.Controls.Add(this.lblFechaIngreso);
            this.groupBox2.Controls.Add(this.dtpFechaIngreso);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(20, 205);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(660, 90);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fechas";
            // 
            // dtpFechaIngreso
            // 
            this.dtpFechaIngreso.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIngreso.Location = new System.Drawing.Point(110, 40);
            this.dtpFechaIngreso.Name = "dtpFechaIngreso";
            this.dtpFechaIngreso.Size = new System.Drawing.Size(150, 23);
            this.dtpFechaIngreso.TabIndex = 0;
            // 
            // lblFechaIngreso
            // 
            this.lblFechaIngreso.AutoSize = true;
            this.lblFechaIngreso.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaIngreso.Location = new System.Drawing.Point(15, 44);
            this.lblFechaIngreso.Name = "lblFechaIngreso";
            this.lblFechaIngreso.Size = new System.Drawing.Size(82, 15);
            this.lblFechaIngreso.TabIndex = 1;
            this.lblFechaIngreso.Text = "Fecha Ingreso:*";
            // 
            // dtpFechaFabricacion
            // 
            this.dtpFechaFabricacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaFabricacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFabricacion.Location = new System.Drawing.Point(380, 40);
            this.dtpFechaFabricacion.Name = "dtpFechaFabricacion";
            this.dtpFechaFabricacion.Size = new System.Drawing.Size(150, 23);
            this.dtpFechaFabricacion.TabIndex = 1;
            // 
            // lblFechaFabricacion
            // 
            this.lblFechaFabricacion.AutoSize = true;
            this.lblFechaFabricacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaFabricacion.Location = new System.Drawing.Point(280, 44);
            this.lblFechaFabricacion.Name = "lblFechaFabricacion";
            this.lblFechaFabricacion.Size = new System.Drawing.Size(91, 15);
            this.lblFechaFabricacion.TabIndex = 3;
            this.lblFechaFabricacion.Text = "Fecha Fabricación:";
            // 
            // dtpFechaCaducidad
            // 
            this.dtpFechaCaducidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaCaducidad.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCaducidad.Location = new System.Drawing.Point(110, 68);
            this.dtpFechaCaducidad.Name = "dtpFechaCaducidad";
            this.dtpFechaCaducidad.Size = new System.Drawing.Size(150, 23);
            this.dtpFechaCaducidad.TabIndex = 2;
            this.dtpFechaCaducidad.Value = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
            // 
            // lblFechaCaducidad
            // 
            this.lblFechaCaducidad.AutoSize = true;
            this.lblFechaCaducidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaCaducidad.Location = new System.Drawing.Point(15, 72);
            this.lblFechaCaducidad.Name = "lblFechaCaducidad";
            this.lblFechaCaducidad.Size = new System.Drawing.Size(93, 15);
            this.lblFechaCaducidad.TabIndex = 5;
            this.lblFechaCaducidad.Text = "Fecha Caducidad:*";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblNumeroFactura);
            this.groupBox3.Controls.Add(this.txtNumeroFactura);
            this.groupBox3.Controls.Add(this.lblCostoUnitario);
            this.groupBox3.Controls.Add(this.numCostoUnitario);
            this.groupBox3.Controls.Add(this.lblCantidadInicial);
            this.groupBox3.Controls.Add(this.numCantidadInicial);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(20, 310);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(660, 90);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cantidades y Costos";
            // 
            // numCantidadInicial
            // 
            this.numCantidadInicial.DecimalPlaces = 2;
            this.numCantidadInicial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numCantidadInicial.Location = new System.Drawing.Point(110, 40);
            this.numCantidadInicial.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numCantidadInicial.Name = "numCantidadInicial";
            this.numCantidadInicial.Size = new System.Drawing.Size(150, 23);
            this.numCantidadInicial.TabIndex = 0;
            // 
            // lblCantidadInicial
            // 
            this.lblCantidadInicial.AutoSize = true;
            this.lblCantidadInicial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCantidadInicial.Location = new System.Drawing.Point(15, 42);
            this.lblCantidadInicial.Name = "lblCantidadInicial";
            this.lblCantidadInicial.Size = new System.Drawing.Size(89, 15);
            this.lblCantidadInicial.TabIndex = 1;
            this.lblCantidadInicial.Text = "Cantidad Inicial:*";
            // 
            // numCostoUnitario
            // 
            this.numCostoUnitario.DecimalPlaces = 4;
            this.numCostoUnitario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numCostoUnitario.Location = new System.Drawing.Point(380, 40);
            this.numCostoUnitario.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numCostoUnitario.Name = "numCostoUnitario";
            this.numCostoUnitario.Size = new System.Drawing.Size(150, 23);
            this.numCostoUnitario.TabIndex = 1;
            // 
            // lblCostoUnitario
            // 
            this.lblCostoUnitario.AutoSize = true;
            this.lblCostoUnitario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCostoUnitario.Location = new System.Drawing.Point(280, 42);
            this.lblCostoUnitario.Name = "lblCostoUnitario";
            this.lblCostoUnitario.Size = new System.Drawing.Size(81, 15);
            this.lblCostoUnitario.TabIndex = 3;
            this.lblCostoUnitario.Text = "Costo Unitario:";
            // 
            // txtNumeroFactura
            // 
            this.txtNumeroFactura.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNumeroFactura.Location = new System.Drawing.Point(110, 68);
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.Size = new System.Drawing.Size(200, 23);
            this.txtNumeroFactura.TabIndex = 2;
            // 
            // lblNumeroFactura
            // 
            this.lblNumeroFactura.AutoSize = true;
            this.lblNumeroFactura.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNumeroFactura.Location = new System.Drawing.Point(15, 71);
            this.lblNumeroFactura.Name = "lblNumeroFactura";
            this.lblNumeroFactura.Size = new System.Drawing.Size(89, 15);
            this.lblNumeroFactura.TabIndex = 5;
            this.lblNumeroFactura.Text = "Número Factura:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkActivo);
            this.groupBox4.Controls.Add(this.txtObservaciones);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(20, 415);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(660, 110);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtObservaciones.Location = new System.Drawing.Point(15, 30);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(630, 45);
            this.txtObservaciones.TabIndex = 0;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkActivo.Location = new System.Drawing.Point(15, 80);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(60, 19);
            this.chkActivo.TabIndex = 1;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.Color.White;
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.btnGuardar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 540);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(700, 60);
            this.pnlBotones.TabIndex = 5;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.ColorTranslator.FromHtml("#27AE60");
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(470, 13);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 35);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.ColorTranslator.FromHtml("#E74C3C");
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(580, 13);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmLoteDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(700, 600);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLoteDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalle de Lote";
            this.Load += new System.EventHandler(this.FrmLoteDetalle_Load);
            this.pnlTitulo.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidadInicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCostoUnitario)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.ComboBox cboUbicacion;
        private System.Windows.Forms.Label lblNumeroLote;
        private System.Windows.Forms.TextBox txtNumeroLote;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblFechaIngreso;
        private System.Windows.Forms.DateTimePicker dtpFechaIngreso;
        private System.Windows.Forms.Label lblFechaFabricacion;
        private System.Windows.Forms.DateTimePicker dtpFechaFabricacion;
        private System.Windows.Forms.Label lblFechaCaducidad;
        private System.Windows.Forms.DateTimePicker dtpFechaCaducidad;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblCantidadInicial;
        private System.Windows.Forms.NumericUpDown numCantidadInicial;
        private System.Windows.Forms.Label lblCostoUnitario;
        private System.Windows.Forms.NumericUpDown numCostoUnitario;
        private System.Windows.Forms.Label lblNumeroFactura;
        private System.Windows.Forms.TextBox txtNumeroFactura;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
