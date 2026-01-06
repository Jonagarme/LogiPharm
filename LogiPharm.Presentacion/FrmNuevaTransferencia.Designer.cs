namespace LogiPharm.Presentacion
{
    partial class FrmNuevaTransferencia
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.panelProductosHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalUnidades = new System.Windows.Forms.Label();
            this.lblTotalProductos = new System.Windows.Forms.Label();
            this.btnAgregarProducto = new Guna.UI2.WinForms.Guna2Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpFecha = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtNumero = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNumero = new System.Windows.Forms.Label();
            this.cboDestino = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblDestino = new System.Windows.Forms.Label();
            this.cboOrigen = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblOrigen = new System.Windows.Forms.Label();
            this.cboMotivo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtObservaciones = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.panelFooter = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            this.btnCrear = new Guna.UI2.WinForms.Guna2Button();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.panelProductosHeader.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Controls.Add(this.btnCerrar);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(900, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(287, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Nueva Transferencia de Stock";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCerrar.IconColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(755, 15);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 30);
            this.btnCerrar.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Controls.Add(this.groupBox2);
            this.panelContent.Controls.Add(this.groupBox1);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 60);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(900, 540);
            this.panelContent.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtObservaciones);
            this.groupBox1.Controls.Add(this.lblObservaciones);
            this.groupBox1.Controls.Add(this.cboMotivo);
            this.groupBox1.Controls.Add(this.lblMotivo);
            this.groupBox1.Controls.Add(this.cboDestino);
            this.groupBox1.Controls.Add(this.lblDestino);
            this.groupBox1.Controls.Add(this.cboOrigen);
            this.groupBox1.Controls.Add(this.lblOrigen);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.groupBox1.Location = new System.Drawing.Point(20, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(860, 280);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información General";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDetalles);
            this.groupBox2.Controls.Add(this.panelProductosHeader);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.groupBox2.Location = new System.Drawing.Point(20, 300);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(860, 220);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Productos a Transferir";
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalles.Location = new System.Drawing.Point(3, 80);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.RowHeadersVisible = false;
            this.dgvDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalles.Size = new System.Drawing.Size(854, 137);
            this.dgvDetalles.TabIndex = 1;
            // 
            // panelProductosHeader
            // 
            this.panelProductosHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelProductosHeader.Controls.Add(this.lblTotalUnidades);
            this.panelProductosHeader.Controls.Add(this.lblTotalProductos);
            this.panelProductosHeader.Controls.Add(this.btnAgregarProducto);
            this.panelProductosHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelProductosHeader.Location = new System.Drawing.Point(3, 21);
            this.panelProductosHeader.Name = "panelProductosHeader";
            this.panelProductosHeader.Padding = new System.Windows.Forms.Padding(10);
            this.panelProductosHeader.Size = new System.Drawing.Size(854, 59);
            this.panelProductosHeader.TabIndex = 0;
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.BorderRadius = 6;
            this.btnAgregarProducto.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAgregarProducto.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAgregarProducto.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAgregarProducto.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAgregarProducto.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAgregarProducto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAgregarProducto.ForeColor = System.Drawing.Color.White;
            this.btnAgregarProducto.Location = new System.Drawing.Point(10, 10);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(180, 40);
            this.btnAgregarProducto.TabIndex = 0;
            this.btnAgregarProducto.Text = "+ Agregar Producto";
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // lblTotalProductos
            // 
            this.lblTotalProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalProductos.AutoSize = true;
            this.lblTotalProductos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotalProductos.Location = new System.Drawing.Point(550, 20);
            this.lblTotalProductos.Name = "lblTotalProductos";
            this.lblTotalProductos.Size = new System.Drawing.Size(110, 15);
            this.lblTotalProductos.TabIndex = 1;
            this.lblTotalProductos.Text = "Total productos: 0";
            // 
            // lblTotalUnidades
            // 
            this.lblTotalUnidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalUnidades.AutoSize = true;
            this.lblTotalUnidades.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalUnidades.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotalUnidades.Location = new System.Drawing.Point(720, 20);
            this.lblTotalUnidades.Name = "lblTotalUnidades";
            this.lblTotalUnidades.Size = new System.Drawing.Size(108, 15);
            this.lblTotalUnidades.TabIndex = 2;
            this.lblTotalUnidades.Text = "Total unidades: 0";
            // 
            // dtpFecha
            // 
            this.dtpFecha.BorderRadius = 6;
            this.dtpFecha.Checked = true;
            this.dtpFecha.FillColor = System.Drawing.Color.White;
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(410, 60);
            this.dtpFecha.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFecha.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(320, 36);
            this.dtpFecha.TabIndex = 3;
            this.dtpFecha.Value = System.DateTime.Today;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFecha.Location = new System.Drawing.Point(407, 40);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(132, 15);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "* Fecha de Transferencia";
            // 
            // txtNumero
            // 
            this.txtNumero.BorderRadius = 6;
            this.txtNumero.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNumero.DefaultText = "";
            this.txtNumero.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNumero.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNumero.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNumero.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNumero.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNumero.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtNumero.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNumero.Location = new System.Drawing.Point(30, 60);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.PasswordChar = '\0';
            this.txtNumero.PlaceholderText = "";
            this.txtNumero.ReadOnly = true;
            this.txtNumero.SelectedText = "";
            this.txtNumero.Size = new System.Drawing.Size(350, 36);
            this.txtNumero.TabIndex = 1;
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNumero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNumero.Location = new System.Drawing.Point(27, 40);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(141, 15);
            this.lblNumero.TabIndex = 0;
            this.lblNumero.Text = "N° Transferencia (AUTO)";
            // 
            // cboDestino
            // 
            this.cboDestino.BackColor = System.Drawing.Color.Transparent;
            this.cboDestino.BorderRadius = 6;
            this.cboDestino.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDestino.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboDestino.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboDestino.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboDestino.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboDestino.ItemHeight = 30;
            this.cboDestino.Location = new System.Drawing.Point(410, 75);
            this.cboDestino.Name = "cboDestino";
            this.cboDestino.Size = new System.Drawing.Size(320, 36);
            this.cboDestino.TabIndex = 7;
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDestino.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDestino.Location = new System.Drawing.Point(407, 55);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(113, 15);
            this.lblDestino.TabIndex = 6;
            this.lblDestino.Text = "* Ubicación Destino";
            // 
            // cboOrigen
            // 
            this.cboOrigen.BackColor = System.Drawing.Color.Transparent;
            this.cboOrigen.BorderRadius = 6;
            this.cboOrigen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrigen.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboOrigen.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboOrigen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboOrigen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboOrigen.ItemHeight = 30;
            this.cboOrigen.Location = new System.Drawing.Point(30, 75);
            this.cboOrigen.Name = "cboOrigen";
            this.cboOrigen.Size = new System.Drawing.Size(350, 36);
            this.cboOrigen.TabIndex = 5;
            // 
            // lblOrigen
            // 
            this.lblOrigen.AutoSize = true;
            this.lblOrigen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOrigen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblOrigen.Location = new System.Drawing.Point(27, 55);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Size = new System.Drawing.Size(107, 15);
            this.lblOrigen.TabIndex = 4;
            this.lblOrigen.Text = "* Ubicación Origen";
            // 
            // cboMotivo
            // 
            this.cboMotivo.BackColor = System.Drawing.Color.Transparent;
            this.cboMotivo.BorderRadius = 6;
            this.cboMotivo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotivo.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboMotivo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboMotivo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboMotivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboMotivo.ItemHeight = 30;
            this.cboMotivo.Location = new System.Drawing.Point(30, 145);
            this.cboMotivo.Name = "cboMotivo";
            this.cboMotivo.Size = new System.Drawing.Size(700, 36);
            this.cboMotivo.TabIndex = 9;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMotivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMotivo.Location = new System.Drawing.Point(27, 125);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(145, 15);
            this.lblMotivo.TabIndex = 8;
            this.lblMotivo.Text = "* Motivo de Transferencia";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.BorderRadius = 6;
            this.txtObservaciones.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtObservaciones.DefaultText = "";
            this.txtObservaciones.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtObservaciones.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtObservaciones.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtObservaciones.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtObservaciones.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtObservaciones.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtObservaciones.Location = new System.Drawing.Point(30, 215);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.PasswordChar = '\0';
            this.txtObservaciones.PlaceholderText = "Ingrese observaciones adicionales...";
            this.txtObservaciones.SelectedText = "";
            this.txtObservaciones.Size = new System.Drawing.Size(700, 50);
            this.txtObservaciones.TabIndex = 11;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblObservaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblObservaciones.Location = new System.Drawing.Point(27, 195);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(84, 15);
            this.lblObservaciones.TabIndex = 10;
            this.lblObservaciones.Text = "Observaciones";
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelFooter.Controls.Add(this.btnCancelar);
            this.panelFooter.Controls.Add(this.btnCrear);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 600);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Padding = new System.Windows.Forms.Padding(20);
            this.panelFooter.Size = new System.Drawing.Size(900, 80);
            this.panelFooter.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BorderRadius = 6;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(640, 20);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 45);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "X Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrear.BorderRadius = 6;
            this.btnCrear.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCrear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCrear.ForeColor = System.Drawing.Color.White;
            this.btnCrear.Location = new System.Drawing.Point(766, 20);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(120, 45);
            this.btnCrear.TabIndex = 0;
            this.btnCrear.Text = "Crear";
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // FrmNuevaTransferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 680);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNuevaTransferencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nueva Transferencia";
            this.Load += new System.EventHandler(this.FrmNuevaTransferencia_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.panelProductosHeader.ResumeLayout(false);
            this.panelProductosHeader.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private Guna.UI2.WinForms.Guna2ControlBox btnCerrar;
        private Guna.UI2.WinForms.Guna2Panel panelContent;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private Guna.UI2.WinForms.Guna2Panel panelProductosHeader;
        private System.Windows.Forms.Label lblTotalUnidades;
        private System.Windows.Forms.Label lblTotalProductos;
        private Guna.UI2.WinForms.Guna2Button btnAgregarProducto;
        private System.Windows.Forms.GroupBox groupBox1;
        private Guna.UI2.WinForms.Guna2TextBox txtNumero;
        private System.Windows.Forms.Label lblNumero;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFecha;
        private Guna.UI2.WinForms.Guna2ComboBox cboOrigen;
        private System.Windows.Forms.Label lblOrigen;
        private Guna.UI2.WinForms.Guna2ComboBox cboDestino;
        private System.Windows.Forms.Label lblDestino;
        private Guna.UI2.WinForms.Guna2ComboBox cboMotivo;
        private System.Windows.Forms.Label lblMotivo;
        private Guna.UI2.WinForms.Guna2TextBox txtObservaciones;
        private System.Windows.Forms.Label lblObservaciones;
        private Guna.UI2.WinForms.Guna2Panel panelFooter;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;
        private Guna.UI2.WinForms.Guna2Button btnCrear;
    }
}
