namespace LogiPharm.Presentacion
{
    partial class FrmConfigProductoTransferencia
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
            this.panelHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCerrar = new Guna.UI2.WinForms.Guna2ControlBox();
            this.panelContent = new Guna.UI2.WinForms.Guna2Panel();
            this.groupProducto = new System.Windows.Forms.GroupBox();
            this.lblProductoCodigo = new System.Windows.Forms.Label();
            this.lblProductoNombre = new System.Windows.Forms.Label();
            this.panelStockTotal = new Guna.UI2.WinForms.Guna2Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStockTotal = new System.Windows.Forms.Label();
            this.panelBusqueda = new Guna.UI2.WinForms.Guna2Panel();
            this.btnBuscarProducto = new Guna.UI2.WinForms.Guna2Button();
            this.txtBuscarProducto = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupLotes = new System.Windows.Forms.GroupBox();
            this.lblPasoActual = new System.Windows.Forms.Label();
            this.dgvLotes = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.numCantidad = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.panelFooter = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            this.btnAgregarTransferencia = new Guna.UI2.WinForms.Guna2Button();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.groupProducto.SuspendLayout();
            this.panelStockTotal.SuspendLayout();
            this.panelBusqueda.SuspendLayout();
            this.groupLotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Controls.Add(this.btnCerrar);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(800, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(15, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(339, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Configurar Producto para Transferencia";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnCerrar.IconColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(755, 15);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 30);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Controls.Add(this.groupLotes);
            this.panelContent.Controls.Add(this.groupProducto);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 60);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(15);
            this.panelContent.Size = new System.Drawing.Size(800, 500);
            this.panelContent.TabIndex = 1;
            // 
            // groupProducto
            // 
            this.groupProducto.Controls.Add(this.panelStockTotal);
            this.groupProducto.Controls.Add(this.lblProductoCodigo);
            this.groupProducto.Controls.Add(this.lblProductoNombre);
            this.groupProducto.Controls.Add(this.panelBusqueda);
            this.groupProducto.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupProducto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.groupProducto.Location = new System.Drawing.Point(15, 15);
            this.groupProducto.Name = "groupProducto";
            this.groupProducto.Size = new System.Drawing.Size(770, 160);
            this.groupProducto.TabIndex = 0;
            this.groupProducto.TabStop = false;
            this.groupProducto.Text = "Producto";
            // 
            // lblProductoCodigo
            // 
            this.lblProductoCodigo.AutoSize = true;
            this.lblProductoCodigo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProductoCodigo.ForeColor = System.Drawing.Color.Gray;
            this.lblProductoCodigo.Location = new System.Drawing.Point(15, 120);
            this.lblProductoCodigo.Name = "lblProductoCodigo";
            this.lblProductoCodigo.Size = new System.Drawing.Size(52, 15);
            this.lblProductoCodigo.TabIndex = 3;
            this.lblProductoCodigo.Text = "Código: -";
            // 
            // lblProductoNombre
            // 
            this.lblProductoNombre.AutoSize = true;
            this.lblProductoNombre.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblProductoNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblProductoNombre.Location = new System.Drawing.Point(14, 95);
            this.lblProductoNombre.Name = "lblProductoNombre";
            this.lblProductoNombre.Size = new System.Drawing.Size(304, 20);
            this.lblProductoNombre.TabIndex = 2;
            this.lblProductoNombre.Text = "Seleccione un producto para comenzar";
            // 
            // panelStockTotal
            // 
            this.panelStockTotal.BackColor = System.Drawing.Color.Transparent;
            this.panelStockTotal.BorderColor = System.Drawing.Color.Gainsboro;
            this.panelStockTotal.BorderRadius = 8;
            this.panelStockTotal.BorderThickness = 1;
            this.panelStockTotal.Controls.Add(this.label3);
            this.panelStockTotal.Controls.Add(this.lblStockTotal);
            this.panelStockTotal.FillColor = System.Drawing.Color.WhiteSmoke;
            this.panelStockTotal.Location = new System.Drawing.Point(560, 85);
            this.panelStockTotal.Name = "panelStockTotal";
            this.panelStockTotal.Size = new System.Drawing.Size(190, 60);
            this.panelStockTotal.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(10, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Stock Total Disponible";
            // 
            // lblStockTotal
            // 
            this.lblStockTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblStockTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblStockTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStockTotal.Location = new System.Drawing.Point(10, 28);
            this.lblStockTotal.Name = "lblStockTotal";
            this.lblStockTotal.Size = new System.Drawing.Size(170, 25);
            this.lblStockTotal.TabIndex = 1;
            this.lblStockTotal.Text = "0 unid.";
            // 
            // panelBusqueda
            // 
            this.panelBusqueda.Controls.Add(this.btnBuscarProducto);
            this.panelBusqueda.Controls.Add(this.txtBuscarProducto);
            this.panelBusqueda.Controls.Add(this.label2);
            this.panelBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBusqueda.Location = new System.Drawing.Point(3, 21);
            this.panelBusqueda.Name = "panelBusqueda";
            this.panelBusqueda.Size = new System.Drawing.Size(764, 60);
            this.panelBusqueda.TabIndex = 1;
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.BorderRadius = 6;
            this.btnBuscarProducto.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBuscarProducto.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBuscarProducto.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBuscarProducto.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBuscarProducto.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnBuscarProducto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnBuscarProducto.ForeColor = System.Drawing.Color.White;
            this.btnBuscarProducto.Location = new System.Drawing.Point(635, 20);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(115, 36);
            this.btnBuscarProducto.TabIndex = 2;
            this.btnBuscarProducto.Text = "Buscar";
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.BorderRadius = 6;
            this.txtBuscarProducto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscarProducto.DefaultText = "";
            this.txtBuscarProducto.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBuscarProducto.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBuscarProducto.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscarProducto.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscarProducto.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscarProducto.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtBuscarProducto.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscarProducto.Location = new System.Drawing.Point(153, 20);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.PasswordChar = '\0';
            this.txtBuscarProducto.PlaceholderText = "Ingrese código o nombre del producto...";
            this.txtBuscarProducto.SelectedText = "";
            this.txtBuscarProducto.Size = new System.Drawing.Size(476, 36);
            this.txtBuscarProducto.TabIndex = 1;
            this.txtBuscarProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscarProducto_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 13F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(10, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Buscar Lotes Disponibles";
            // 
            // groupLotes
            // 
            this.groupLotes.Controls.Add(this.numCantidad);
            this.groupLotes.Controls.Add(this.label4);
            this.groupLotes.Controls.Add(this.dgvLotes);
            this.groupLotes.Controls.Add(this.lblPasoActual);
            this.groupLotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupLotes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupLotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.groupLotes.Location = new System.Drawing.Point(15, 175);
            this.groupLotes.Name = "groupLotes";
            this.groupLotes.Size = new System.Drawing.Size(770, 310);
            this.groupLotes.TabIndex = 1;
            this.groupLotes.TabStop = false;
            this.groupLotes.Text = "Lotes y Caducidad";
            // 
            // lblPasoActual
            // 
            this.lblPasoActual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.lblPasoActual.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPasoActual.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPasoActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lblPasoActual.Location = new System.Drawing.Point(3, 21);
            this.lblPasoActual.Name = "lblPasoActual";
            this.lblPasoActual.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.lblPasoActual.Size = new System.Drawing.Size(764, 35);
            this.lblPasoActual.TabIndex = 0;
            this.lblPasoActual.Text = "PASO 1: Seleccionar Lote y Caducidad";
            // 
            // dgvLotes
            // 
            this.dgvLotes.AllowUserToAddRows = false;
            this.dgvLotes.AllowUserToDeleteRows = false;
            this.dgvLotes.BackgroundColor = System.Drawing.Color.White;
            this.dgvLotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLotes.Location = new System.Drawing.Point(15, 64);
            this.dgvLotes.Name = "dgvLotes";
            this.dgvLotes.RowHeadersVisible = false;
            this.dgvLotes.RowTemplate.Height = 28;
            this.dgvLotes.Size = new System.Drawing.Size(740, 180);
            this.dgvLotes.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(15, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Cantidad a transferir:";
            // 
            // numCantidad
            // 
            this.numCantidad.BackColor = System.Drawing.Color.Transparent;
            this.numCantidad.BorderRadius = 6;
            this.numCantidad.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numCantidad.DecimalPlaces = 2;
            this.numCantidad.Enabled = false;
            this.numCantidad.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.numCantidad.Location = new System.Drawing.Point(130, 250);
            this.numCantidad.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(180, 36);
            this.numCantidad.TabIndex = 3;
            this.numCantidad.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelFooter.Controls.Add(this.btnCancelar);
            this.panelFooter.Controls.Add(this.btnAgregarTransferencia);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 560);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Padding = new System.Windows.Forms.Padding(20);
            this.panelFooter.Size = new System.Drawing.Size(800, 80);
            this.panelFooter.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BorderRadius = 6;
            this.btnCancelar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancelar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancelar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(520, 20);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 45);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAgregarTransferencia
            // 
            this.btnAgregarTransferencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarTransferencia.BorderRadius = 6;
            this.btnAgregarTransferencia.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAgregarTransferencia.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAgregarTransferencia.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAgregarTransferencia.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAgregarTransferencia.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnAgregarTransferencia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAgregarTransferencia.ForeColor = System.Drawing.Color.White;
            this.btnAgregarTransferencia.Location = new System.Drawing.Point(646, 20);
            this.btnAgregarTransferencia.Name = "btnAgregarTransferencia";
            this.btnAgregarTransferencia.Size = new System.Drawing.Size(140, 45);
            this.btnAgregarTransferencia.TabIndex = 0;
            this.btnAgregarTransferencia.Text = "Agregar a Transferencia";
            this.btnAgregarTransferencia.Click += new System.EventHandler(this.btnAgregarTransferencia_Click);
            // 
            // FrmConfigProductoTransferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 640);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmConfigProductoTransferencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configurar Producto para Transferencia";
            this.Load += new System.EventHandler(this.FrmConfigProductoTransferencia_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.groupProducto.ResumeLayout(false);
            this.groupProducto.PerformLayout();
            this.panelStockTotal.ResumeLayout(false);
            this.panelStockTotal.PerformLayout();
            this.panelBusqueda.ResumeLayout(false);
            this.panelBusqueda.PerformLayout();
            this.groupLotes.ResumeLayout(false);
            this.groupLotes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private Guna.UI2.WinForms.Guna2ControlBox btnCerrar;
        private Guna.UI2.WinForms.Guna2Panel panelContent;
        private System.Windows.Forms.GroupBox groupProducto;
        private System.Windows.Forms.GroupBox groupLotes;
        private Guna.UI2.WinForms.Guna2Panel panelBusqueda;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscarProducto;
        private Guna.UI2.WinForms.Guna2Button btnBuscarProducto;
        private System.Windows.Forms.Label lblProductoNombre;
        private System.Windows.Forms.Label lblProductoCodigo;
        private Guna.UI2.WinForms.Guna2Panel panelStockTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStockTotal;
        private System.Windows.Forms.Label lblPasoActual;
        private System.Windows.Forms.DataGridView dgvLotes;
        private Guna.UI2.WinForms.Guna2NumericUpDown numCantidad;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Panel panelFooter;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;
        private Guna.UI2.WinForms.Guna2Button btnAgregarTransferencia;
    }
}
