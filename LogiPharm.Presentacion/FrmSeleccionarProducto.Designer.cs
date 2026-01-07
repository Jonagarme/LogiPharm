namespace LogiPharm.Presentacion
{
    partial class FrmSeleccionarProducto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.panelTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCerrar = new FontAwesome.Sharp.IconButton();
            this.dgvProductos = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUbicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCategoriaTitulo = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblLaboratorioTitulo = new System.Windows.Forms.Label();
            this.lblLaboratorio = new System.Windows.Forms.Label();
            this.lblUbicacionTitulo = new System.Windows.Forms.Label();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.lblCostoTitulo = new System.Windows.Forms.Label();
            this.lblCosto = new System.Windows.Forms.Label();
            this.lblMargenTitulo = new System.Windows.Forms.Label();
            this.lblMargen = new System.Windows.Forms.Label();
            this.panelVencimiento = new Guna.UI2.WinForms.Guna2Panel();
            this.btnAceptar = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            this.txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.gbDetalles = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblStaticDesc = new System.Windows.Forms.Label();
            this.lblStaticVenc = new System.Windows.Forms.Label();
            this.txtFechaVencimiento = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDescripcion = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panelStock = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStockTexto = new System.Windows.Forms.Label();
            this.lblStockValor = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.gbDetalles.SuspendLayout();
            this.panelStock.SuspendLayout();
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
            this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
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
            this.panelTop.Size = new System.Drawing.Size(950, 40);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(172, 21);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Seleccionar Producto";
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
            this.btnCerrar.Location = new System.Drawing.Point(910, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(32, 32);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvProductos.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProductos.ColumnHeadersHeight = 30;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colNombre,
            this.colStock,
            this.colCategoria,
            this.colUbicacion,
            this.colPrecio});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProductos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvProductos.Location = new System.Drawing.Point(16, 98);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowTemplate.Height = 28;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(543, 335);
            this.dgvProductos.TabIndex = 1;
            this.dgvProductos.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvProductos.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvProductos.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvProductos.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvProductos.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvProductos.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProductos.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvProductos.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvProductos.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvProductos.ThemeStyle.ReadOnly = true;
            this.dgvProductos.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvProductos.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProductos.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProductos.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvProductos.ThemeStyle.RowsStyle.Height = 28;
            this.dgvProductos.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.dgvProductos.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellDoubleClick);
            this.dgvProductos.SelectionChanged += new System.EventHandler(this.dgvProductos_SelectionChanged);
            // 
            // colCodigo
            // 
            this.colCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCodigo.DataPropertyName = "CodigoPrincipal";
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Width = 75;
            // 
            // colNombre
            // 
            this.colNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNombre.DataPropertyName = "Nombre";
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            // 
            // colStock
            // 
            this.colStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colStock.DataPropertyName = "Stock";
            this.colStock.HeaderText = "Stock";
            this.colStock.Name = "colStock";
            this.colStock.ReadOnly = true;
            this.colStock.Width = 65;
            // 
            // colCategoria
            // 
            this.colCategoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCategoria.DataPropertyName = "NombreCategoria";
            this.colCategoria.HeaderText = "Categoría";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.ReadOnly = true;
            this.colCategoria.Width = 89;
            // 
            // colUbicacion
            // 
            this.colUbicacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colUbicacion.DataPropertyName = "Ubicacion";
            this.colUbicacion.HeaderText = "Ubicación";
            this.colUbicacion.Name = "colUbicacion";
            this.colUbicacion.ReadOnly = true;
            this.colUbicacion.Width = 87;
            // 
            // colPrecio
            // 
            this.colPrecio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPrecio.DataPropertyName = "PrecioVenta";
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            this.colPrecio.Width = 70;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.BorderRadius = 8;
            this.btnAceptar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAceptar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAceptar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAceptar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAceptar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(826, 452);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(112, 36);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BorderRadius = 8;
            this.btnCancelar.BorderColor = System.Drawing.Color.Gray;
            this.btnCancelar.BorderThickness = 1;
            this.btnCancelar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancelar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancelar.FillColor = System.Drawing.Color.White;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancelar.Location = new System.Drawing.Point(708, 452);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(112, 36);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderRadius = 8;
            this.txtBuscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscar.DefaultText = "";
            this.txtBuscar.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBuscar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBuscar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscar.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscar.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscar.Location = new System.Drawing.Point(16, 56);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PasswordChar = '\0';
            this.txtBuscar.PlaceholderText = "Buscar por código o nombre...";
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.Size = new System.Drawing.Size(543, 36);
            this.txtBuscar.TabIndex = 4;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // gbDetalles
            // 
            this.gbDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDetalles.BorderColor = System.Drawing.Color.Gainsboro;
            this.gbDetalles.BorderRadius = 8;
            this.gbDetalles.Controls.Add(this.lblMargen);
            this.gbDetalles.Controls.Add(this.lblMargenTitulo);
            this.gbDetalles.Controls.Add(this.lblCosto);
            this.gbDetalles.Controls.Add(this.lblCostoTitulo);
            this.gbDetalles.Controls.Add(this.lblUbicacion);
            this.gbDetalles.Controls.Add(this.lblUbicacionTitulo);
            this.gbDetalles.Controls.Add(this.lblLaboratorio);
            this.gbDetalles.Controls.Add(this.lblLaboratorioTitulo);
            this.gbDetalles.Controls.Add(this.lblCategoria);
            this.gbDetalles.Controls.Add(this.lblCategoriaTitulo);
            this.gbDetalles.Controls.Add(this.panelVencimiento);
            this.gbDetalles.Controls.Add(this.lblStaticDesc);
            this.gbDetalles.Controls.Add(this.lblStaticVenc);
            this.gbDetalles.Controls.Add(this.txtFechaVencimiento);
            this.gbDetalles.Controls.Add(this.lblDescripcion);
            this.gbDetalles.Controls.Add(this.panelStock);
            this.gbDetalles.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.gbDetalles.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDetalles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbDetalles.Location = new System.Drawing.Point(574, 56);
            this.gbDetalles.Name = "gbDetalles";
            this.gbDetalles.Size = new System.Drawing.Size(364, 377);
            this.gbDetalles.TabIndex = 5;
            this.gbDetalles.Text = "Detalles del Producto";
            // 
            // lblStaticDesc
            // 
            this.lblStaticDesc.AutoSize = true;
            this.lblStaticDesc.BackColor = System.Drawing.Color.Transparent;
            this.lblStaticDesc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaticDesc.Location = new System.Drawing.Point(14, 154);
            this.lblStaticDesc.Name = "lblStaticDesc";
            this.lblStaticDesc.Size = new System.Drawing.Size(75, 15);
            this.lblStaticDesc.TabIndex = 4;
            this.lblStaticDesc.Text = "Descripción:";
            // 
            // lblStaticVenc
            // 
            this.lblStaticVenc.AutoSize = true;
            this.lblStaticVenc.BackColor = System.Drawing.Color.Transparent;
            this.lblStaticVenc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaticVenc.Location = new System.Drawing.Point(14, 258);
            this.lblStaticVenc.Name = "lblStaticVenc";
            this.lblStaticVenc.Size = new System.Drawing.Size(129, 15);
            this.lblStaticVenc.TabIndex = 3;
            this.lblStaticVenc.Text = "Fecha de Vencimiento:";
            // 
            // txtFechaVencimiento
            // 
            this.txtFechaVencimiento.BackColor = System.Drawing.Color.Transparent;
            this.txtFechaVencimiento.BorderRadius = 6;
            this.txtFechaVencimiento.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFechaVencimiento.DefaultText = "";
            this.txtFechaVencimiento.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFechaVencimiento.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFechaVencimiento.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFechaVencimiento.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFechaVencimiento.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFechaVencimiento.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtFechaVencimiento.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFechaVencimiento.Location = new System.Drawing.Point(17, 276);
            this.txtFechaVencimiento.Name = "txtFechaVencimiento";
            this.txtFechaVencimiento.PasswordChar = '\0';
            this.txtFechaVencimiento.PlaceholderText = "";
            this.txtFechaVencimiento.ReadOnly = true;
            this.txtFechaVencimiento.SelectedText = "";
            this.txtFechaVencimiento.Size = new System.Drawing.Size(161, 36);
            this.txtFechaVencimiento.TabIndex = 2;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(17, 175);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(147, 17);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripción del producto...";
            // 
            // panelStock
            // 
            this.panelStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStock.BackColor = System.Drawing.Color.Transparent;
            this.panelStock.BorderRadius = 8;
            this.panelStock.Controls.Add(this.lblStockTexto);
            this.panelStock.Controls.Add(this.lblStockValor);
            this.panelStock.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.panelStock.Location = new System.Drawing.Point(17, 49);
            this.panelStock.Name = "panelStock";
            this.panelStock.Size = new System.Drawing.Size(331, 93);
            this.panelStock.TabIndex = 0;
            // 
            // lblStockTexto
            // 
            this.lblStockTexto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStockTexto.AutoSize = true;
            this.lblStockTexto.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockTexto.Location = new System.Drawing.Point(135, 53);
            this.lblStockTexto.Name = "lblStockTexto";
            this.lblStockTexto.Size = new System.Drawing.Size(61, 20);
            this.lblStockTexto.TabIndex = 1;
            this.lblStockTexto.Text = "en Stock";
            // 
            // lblStockValor
            // 
            this.lblStockValor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStockValor.AutoSize = true;
            this.lblStockValor.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
            this.lblStockValor.Location = new System.Drawing.Point(130, 9);
            this.lblStockValor.Name = "lblStockValor";
            this.lblStockValor.Size = new System.Drawing.Size(73, 50);
            this.lblStockValor.TabIndex = 0;
            this.lblStockValor.Text = "99";
            this.lblStockValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCategoriaTitulo
            // 
            this.lblCategoriaTitulo.AutoSize = true;
            this.lblCategoriaTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblCategoriaTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCategoriaTitulo.Location = new System.Drawing.Point(14, 320);
            this.lblCategoriaTitulo.Name = "lblCategoriaTitulo";
            this.lblCategoriaTitulo.Size = new System.Drawing.Size(63, 15);
            this.lblCategoriaTitulo.TabIndex = 5;
            this.lblCategoriaTitulo.Text = "Categoría:";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.BackColor = System.Drawing.Color.Transparent;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCategoria.Location = new System.Drawing.Point(85, 320);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(16, 15);
            this.lblCategoria.TabIndex = 6;
            this.lblCategoria.Text = "...";
            // 
            // lblLaboratorioTitulo
            // 
            this.lblLaboratorioTitulo.AutoSize = true;
            this.lblLaboratorioTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblLaboratorioTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLaboratorioTitulo.Location = new System.Drawing.Point(195, 320);
            this.lblLaboratorioTitulo.Name = "lblLaboratorioTitulo";
            this.lblLaboratorioTitulo.Size = new System.Drawing.Size(75, 15);
            this.lblLaboratorioTitulo.TabIndex = 7;
            this.lblLaboratorioTitulo.Text = "Laboratorio:";
            // 
            // lblLaboratorio
            // 
            this.lblLaboratorio.BackColor = System.Drawing.Color.Transparent;
            this.lblLaboratorio.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblLaboratorio.Location = new System.Drawing.Point(195, 337);
            this.lblLaboratorio.Name = "lblLaboratorio";
            this.lblLaboratorio.Size = new System.Drawing.Size(153, 30);
            this.lblLaboratorio.TabIndex = 8;
            this.lblLaboratorio.Text = "...";
            this.lblLaboratorio.AutoSize = false;
            // 
            // lblUbicacionTitulo
            // 
            this.lblUbicacionTitulo.AutoSize = true;
            this.lblUbicacionTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblUbicacionTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUbicacionTitulo.Location = new System.Drawing.Point(195, 276);
            this.lblUbicacionTitulo.Name = "lblUbicacionTitulo";
            this.lblUbicacionTitulo.Size = new System.Drawing.Size(64, 15);
            this.lblUbicacionTitulo.TabIndex = 9;
            this.lblUbicacionTitulo.Text = "Ubicación:";
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.BackColor = System.Drawing.Color.Transparent;
            this.lblUbicacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUbicacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblUbicacion.Location = new System.Drawing.Point(195, 295);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(65, 15);
            this.lblUbicacion.TabIndex = 10;
            this.lblUbicacion.Text = "PERCHA-A";
            // 
            // lblCostoTitulo
            // 
            this.lblCostoTitulo.AutoSize = true;
            this.lblCostoTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblCostoTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCostoTitulo.Location = new System.Drawing.Point(14, 345);
            this.lblCostoTitulo.Name = "lblCostoTitulo";
            this.lblCostoTitulo.Size = new System.Drawing.Size(42, 15);
            this.lblCostoTitulo.TabIndex = 11;
            this.lblCostoTitulo.Text = "Costo:";
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.BackColor = System.Drawing.Color.Transparent;
            this.lblCosto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCosto.Location = new System.Drawing.Point(85, 345);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(40, 15);
            this.lblCosto.TabIndex = 12;
            this.lblCosto.Text = "$0.00";
            // 
            // lblMargenTitulo
            // 
            this.lblMargenTitulo.AutoSize = true;
            this.lblMargenTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblMargenTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMargenTitulo.Location = new System.Drawing.Point(195, 345);
            this.lblMargenTitulo.Name = "lblMargenTitulo";
            this.lblMargenTitulo.Size = new System.Drawing.Size(52, 15);
            this.lblMargenTitulo.TabIndex = 13;
            this.lblMargenTitulo.Text = "Margen:";
            // 
            // lblMargen
            // 
            this.lblMargen.AutoSize = true;
            this.lblMargen.BackColor = System.Drawing.Color.Transparent;
            this.lblMargen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMargen.ForeColor = System.Drawing.Color.Green;
            this.lblMargen.Location = new System.Drawing.Point(253, 345);
            this.lblMargen.Name = "lblMargen";
            this.lblMargen.Size = new System.Drawing.Size(80, 15);
            this.lblMargen.TabIndex = 14;
            this.lblMargen.Text = "50% (+$2.50)";
            // 
            // panelVencimiento
            // 
            this.panelVencimiento.BackColor = System.Drawing.Color.Transparent;
            this.panelVencimiento.BorderRadius = 6;
            this.panelVencimiento.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(204)))));
            this.panelVencimiento.Location = new System.Drawing.Point(17, 223);
            this.panelVencimiento.Name = "panelVencimiento";
            this.panelVencimiento.Size = new System.Drawing.Size(161, 24);
            this.panelVencimiento.TabIndex = 15;
            this.panelVencimiento.Visible = false;
            // 
            // FrmSeleccionarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 500);
            this.Controls.Add(this.gbDetalles);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSeleccionarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Seleccionar Producto";
            this.Load += new System.EventHandler(this.FrmSeleccionarProducto_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.gbDetalles.ResumeLayout(false);
            this.gbDetalles.PerformLayout();
            this.panelStock.ResumeLayout(false);
            this.panelStock.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private System.Windows.Forms.Label lblTitulo;
        private Guna.UI2.WinForms.Guna2DataGridView dgvProductos;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;
        private Guna.UI2.WinForms.Guna2Button btnAceptar;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private Guna.UI2.WinForms.Guna2GroupBox gbDetalles;
        private Guna.UI2.WinForms.Guna2Panel panelStock;
        private System.Windows.Forms.Label lblStockValor;
        private System.Windows.Forms.Label lblStockTexto;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDescripcion;
        private Guna.UI2.WinForms.Guna2TextBox txtFechaVencimiento;
        private System.Windows.Forms.Label lblStaticDesc;
        private System.Windows.Forms.Label lblStaticVenc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUbicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.Label lblCategoriaTitulo;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblLaboratorioTitulo;
        private System.Windows.Forms.Label lblLaboratorio;
        private System.Windows.Forms.Label lblUbicacionTitulo;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.Label lblCostoTitulo;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.Label lblMargenTitulo;
        private System.Windows.Forms.Label lblMargen;
        private Guna.UI2.WinForms.Guna2Panel panelVencimiento;
    }
}