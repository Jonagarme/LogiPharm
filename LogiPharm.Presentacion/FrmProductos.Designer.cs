namespace LogiPharm.Presentacion
{
    partial class FrmProductos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelToolbar = new Guna.UI2.WinForms.Guna2Panel();
            this.btnOpciones = new Guna.UI2.WinForms.Guna2Button();
            this.btnExportar = new Guna.UI2.WinForms.Guna2Button();
            this.btnRecargar = new Guna.UI2.WinForms.Guna2Button();
            this.btnEditar = new Guna.UI2.WinForms.Guna2Button();
            this.btnNuevo = new Guna.UI2.WinForms.Guna2Button();
            this.panelListado = new Guna.UI2.WinForms.Guna2Panel();
            this.DgvListado = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colStatus = new System.Windows.Forms.DataGridViewImageColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colEliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.panelDatos = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.tabProducto = new System.Windows.Forms.TabControl();
            this.tabPrincipal = new System.Windows.Forms.TabPage();
            this.txtNombre = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCodigoPrincipal = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCodigoAuxiliar = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtRegistroSanitario = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDescripcion = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtObservaciones = new Guna.UI2.WinForms.Guna2TextBox();
            this.tabClasificacion = new System.Windows.Forms.TabPage();
            this.cboTipoProducto = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboClaseProducto = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboCategoria = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboSubcategoria = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboSubnivel = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboMarca = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboLaboratorio = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboClasificacionABC = new Guna.UI2.WinForms.Guna2ComboBox();
            this.tabInventarioPrecios = new System.Windows.Forms.TabPage();
            this.numStock = new System.Windows.Forms.NumericUpDown();
            this.numStockMinimo = new System.Windows.Forms.NumericUpDown();
            this.numStockMaximo = new System.Windows.Forms.NumericUpDown();
            this.numPrecioVenta = new System.Windows.Forms.NumericUpDown();
            this.tabAtributos = new System.Windows.Forms.TabPage();
            this.chkEsDivisible = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkEsPsicotropico = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkRequiereCadenaFrio = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkRequiereSeguimiento = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkCalculoABCManual = new Guna.UI2.WinForms.Guna2CheckBox();
            this.contextMenuOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelToolbar.SuspendLayout();
            this.panelListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListado)).BeginInit();
            this.panelDatos.SuspendLayout();
            this.tabProducto.SuspendLayout();
            this.tabPrincipal.SuspendLayout();
            this.tabClasificacion.SuspendLayout();
            this.tabInventarioPrecios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStockMinimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStockMaximo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioVenta)).BeginInit();
            this.tabAtributos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelToolbar
            // 
            this.panelToolbar.Controls.Add(this.btnOpciones);
            this.panelToolbar.Controls.Add(this.btnExportar);
            this.panelToolbar.Controls.Add(this.btnRecargar);
            this.panelToolbar.Controls.Add(this.btnEditar);
            this.panelToolbar.Controls.Add(this.btnNuevo);
            this.panelToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolbar.Location = new System.Drawing.Point(0, 0);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(1022, 68);
            this.panelToolbar.TabIndex = 15;
            // 
            // btnOpciones
            // 
            this.btnOpciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpciones.BorderRadius = 8;
            this.btnOpciones.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOpciones.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOpciones.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOpciones.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOpciones.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnOpciones.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnOpciones.ForeColor = System.Drawing.Color.White;
            this.btnOpciones.Location = new System.Drawing.Point(857, 12);
            this.btnOpciones.Name = "btnOpciones";
            this.btnOpciones.Size = new System.Drawing.Size(153, 45);
            this.btnOpciones.TabIndex = 4;
            this.btnOpciones.Text = "Otras Opciones";
            // 
            // btnExportar
            // 
            this.btnExportar.BorderRadius = 8;
            this.btnExportar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExportar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExportar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExportar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExportar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(132)))), ((int)(((byte)(73)))));
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(408, 12);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(110, 45);
            this.btnExportar.TabIndex = 3;
            this.btnExportar.Text = "Exportar";
            // 
            // btnRecargar
            // 
            this.btnRecargar.BorderRadius = 8;
            this.btnRecargar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRecargar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRecargar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRecargar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRecargar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRecargar.ForeColor = System.Drawing.Color.White;
            this.btnRecargar.Location = new System.Drawing.Point(292, 12);
            this.btnRecargar.Name = "btnRecargar";
            this.btnRecargar.Size = new System.Drawing.Size(110, 45);
            this.btnRecargar.TabIndex = 2;
            this.btnRecargar.Text = "Recargar";
            this.btnRecargar.Click += new System.EventHandler(this.iconButton4_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BorderRadius = 8;
            this.btnEditar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEditar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEditar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEditar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(176, 12);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(110, 45);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BorderRadius = 8;
            this.btnNuevo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNuevo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNuevo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNuevo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(12, 12);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(158, 45);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Nuevo Producto";
            this.btnNuevo.Click += new System.EventHandler(this.menuNuevoProducto_Click);
            // 
            // panelListado
            // 
            this.panelListado.Controls.Add(this.DgvListado);
            this.panelListado.Controls.Add(this.lblTotal);
            this.panelListado.Controls.Add(this.txtBuscar);
            this.panelListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelListado.Location = new System.Drawing.Point(0, 0);
            this.panelListado.Name = "panelListado";
            this.panelListado.Padding = new System.Windows.Forms.Padding(10);
            this.panelListado.Size = new System.Drawing.Size(608, 599);
            this.panelListado.TabIndex = 16;
            // 
            // DgvListado
            // 
            this.DgvListado.AllowUserToAddRows = false;
            this.DgvListado.AllowUserToDeleteRows = false;
            this.DgvListado.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DgvListado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvListado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvListado.ColumnHeadersHeight = 35;
            this.DgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStatus,
            this.colEditar,
            this.colEliminar});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvListado.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvListado.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.DgvListado.Location = new System.Drawing.Point(13, 58);
            this.DgvListado.Name = "DgvListado";
            this.DgvListado.ReadOnly = true;
            this.DgvListado.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DgvListado.RowHeadersVisible = false;
            this.DgvListado.RowTemplate.Height = 34;
            this.DgvListado.Size = new System.Drawing.Size(582, 501);
            this.DgvListado.TabIndex = 63;
            this.DgvListado.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DgvListado.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DgvListado.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DgvListado.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DgvListado.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DgvListado.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DgvListado.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.DgvListado.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DgvListado.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DgvListado.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvListado.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DgvListado.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DgvListado.ThemeStyle.HeaderStyle.Height = 35;
            this.DgvListado.ThemeStyle.ReadOnly = true;
            this.DgvListado.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DgvListado.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DgvListado.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvListado.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DgvListado.ThemeStyle.RowsStyle.Height = 34;
            this.DgvListado.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DgvListado.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DgvListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListado_CellContentClick);
            this.DgvListado.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvListado_CellFormatting);
            this.DgvListado.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DgvListado_CellPainting);
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colStatus.HeaderText = "";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 5;
            // 
            // colEditar
            // 
            this.colEditar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colEditar.HeaderText = "";
            this.colEditar.Name = "colEditar";
            this.colEditar.ReadOnly = true;
            this.colEditar.Width = 5;
            // 
            // colEliminar
            // 
            this.colEliminar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colEliminar.HeaderText = "";
            this.colEliminar.Name = "colEliminar";
            this.colEliminar.ReadOnly = true;
            this.colEliminar.Width = 5;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTotal.Location = new System.Drawing.Point(10, 575);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(93, 15);
            this.lblTotal.TabIndex = 65;
            this.lblTotal.Text = "Total registros: 0";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BackColor = System.Drawing.Color.Transparent;
            this.txtBuscar.BorderRadius = 8;
            this.txtBuscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscar.DefaultText = "";
            this.txtBuscar.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBuscar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBuscar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscar.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtBuscar.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscar.Location = new System.Drawing.Point(13, 13);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PlaceholderText = "Buscar por código, nombre o descripción...";
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.Size = new System.Drawing.Size(582, 39);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            // 
            // panelDatos
            // 
            this.panelDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelDatos.Controls.Add(this.btnCancelar);
            this.panelDatos.Controls.Add(this.btnGuardar);
            this.panelDatos.Controls.Add(this.tabProducto);
            this.panelDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDatos.Location = new System.Drawing.Point(0, 0);
            this.panelDatos.Name = "panelDatos";
            this.panelDatos.Padding = new System.Windows.Forms.Padding(15);
            this.panelDatos.Size = new System.Drawing.Size(410, 599);
            this.panelDatos.TabIndex = 17;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnCancelar.BorderRadius = 8;
            this.btnCancelar.BorderThickness = 1;
            this.btnCancelar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancelar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancelar.FillColor = System.Drawing.Color.White;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancelar.Location = new System.Drawing.Point(196, 545);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(95, 36);
            this.btnCancelar.TabIndex = 62;
            this.btnCancelar.Text = "Cancelar";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BorderRadius = 8;
            this.btnGuardar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGuardar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGuardar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGuardar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(297, 545);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(95, 36);
            this.btnGuardar.TabIndex = 61;
            this.btnGuardar.Text = "Guardar";
            // 
            // tabProducto
            // 
            this.tabProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabProducto.Controls.Add(this.tabPrincipal);
            this.tabProducto.Controls.Add(this.tabClasificacion);
            this.tabProducto.Controls.Add(this.tabInventarioPrecios);
            this.tabProducto.Controls.Add(this.tabAtributos);
            this.tabProducto.Location = new System.Drawing.Point(15, 15);
            this.tabProducto.Name = "tabProducto";
            this.tabProducto.SelectedIndex = 0;
            this.tabProducto.Size = new System.Drawing.Size(380, 510);
            this.tabProducto.TabIndex = 78;
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.txtNombre);
            this.tabPrincipal.Controls.Add(this.txtCodigoPrincipal);
            this.tabPrincipal.Controls.Add(this.txtCodigoAuxiliar);
            this.tabPrincipal.Controls.Add(this.txtRegistroSanitario);
            this.tabPrincipal.Controls.Add(this.txtDescripcion);
            this.tabPrincipal.Controls.Add(this.txtObservaciones);
            this.tabPrincipal.Location = new System.Drawing.Point(4, 22);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.Padding = new System.Windows.Forms.Padding(10);
            this.tabPrincipal.Size = new System.Drawing.Size(372, 484);
            this.tabPrincipal.TabIndex = 0;
            this.tabPrincipal.Text = "Principal";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNombre.DefaultText = "";
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNombre.Location = new System.Drawing.Point(20, 20);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PlaceholderText = "Nombre del producto";
            this.txtNombre.SelectedText = "";
            this.txtNombre.Size = new System.Drawing.Size(331, 36);
            this.txtNombre.TabIndex = 0;
            // 
            // txtCodigoPrincipal
            // 
            this.txtCodigoPrincipal.Anchor = this.txtNombre.Anchor;
            this.txtCodigoPrincipal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCodigoPrincipal.DefaultText = "";
            this.txtCodigoPrincipal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCodigoPrincipal.Location = new System.Drawing.Point(20, 70);
            this.txtCodigoPrincipal.Name = "txtCodigoPrincipal";
            this.txtCodigoPrincipal.PlaceholderText = "Código principal";
            this.txtCodigoPrincipal.SelectedText = "";
            this.txtCodigoPrincipal.Size = new System.Drawing.Size(331, 36);
            this.txtCodigoPrincipal.TabIndex = 1;
            // 
            // txtCodigoAuxiliar
            // 
            this.txtCodigoAuxiliar.Anchor = this.txtNombre.Anchor;
            this.txtCodigoAuxiliar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCodigoAuxiliar.DefaultText = "";
            this.txtCodigoAuxiliar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCodigoAuxiliar.Location = new System.Drawing.Point(20, 120);
            this.txtCodigoAuxiliar.Name = "txtCodigoAuxiliar";
            this.txtCodigoAuxiliar.PlaceholderText = "Código auxiliar";
            this.txtCodigoAuxiliar.SelectedText = "";
            this.txtCodigoAuxiliar.Size = new System.Drawing.Size(331, 36);
            this.txtCodigoAuxiliar.TabIndex = 2;
            // 
            // txtRegistroSanitario
            // 
            this.txtRegistroSanitario.Anchor = this.txtNombre.Anchor;
            this.txtRegistroSanitario.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRegistroSanitario.DefaultText = "";
            this.txtRegistroSanitario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRegistroSanitario.Location = new System.Drawing.Point(20, 170);
            this.txtRegistroSanitario.Name = "txtRegistroSanitario";
            this.txtRegistroSanitario.PlaceholderText = "Registro sanitario";
            this.txtRegistroSanitario.SelectedText = "";
            this.txtRegistroSanitario.Size = new System.Drawing.Size(331, 36);
            this.txtRegistroSanitario.TabIndex = 3;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = this.txtNombre.Anchor;
            this.txtDescripcion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescripcion.DefaultText = "";
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescripcion.Location = new System.Drawing.Point(20, 220);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.PlaceholderText = "Descripción";
            this.txtDescripcion.SelectedText = "";
            this.txtDescripcion.Size = new System.Drawing.Size(331, 80);
            this.txtDescripcion.TabIndex = 4;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Anchor = this.txtNombre.Anchor;
            this.txtObservaciones.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtObservaciones.DefaultText = "";
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtObservaciones.Location = new System.Drawing.Point(20, 310);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.PlaceholderText = "Observaciones";
            this.txtObservaciones.SelectedText = "";
            this.txtObservaciones.Size = new System.Drawing.Size(331, 80);
            this.txtObservaciones.TabIndex = 5;
            // 
            // tabClasificacion
            // 
            this.tabClasificacion.Controls.Add(this.cboTipoProducto);
            this.tabClasificacion.Controls.Add(this.cboClaseProducto);
            this.tabClasificacion.Controls.Add(this.cboCategoria);
            this.tabClasificacion.Controls.Add(this.cboSubcategoria);
            this.tabClasificacion.Controls.Add(this.cboSubnivel);
            this.tabClasificacion.Controls.Add(this.cboMarca);
            this.tabClasificacion.Controls.Add(this.cboLaboratorio);
            this.tabClasificacion.Controls.Add(this.cboClasificacionABC);
            this.tabClasificacion.Location = new System.Drawing.Point(4, 22);
            this.tabClasificacion.Name = "tabClasificacion";
            this.tabClasificacion.Padding = new System.Windows.Forms.Padding(10);
            this.tabClasificacion.Size = new System.Drawing.Size(371, 484);
            this.tabClasificacion.TabIndex = 1;
            this.tabClasificacion.Text = "Clasificación";
            // 
            // cboTipoProducto
            // 
            this.cboTipoProducto.BackColor = System.Drawing.Color.Transparent;
            this.cboTipoProducto.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoProducto.FocusedColor = System.Drawing.Color.Empty;
            this.cboTipoProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTipoProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboTipoProducto.ItemHeight = 30;
            this.cboTipoProducto.Location = new System.Drawing.Point(20, 20);
            this.cboTipoProducto.Name = "cboTipoProducto";
            this.cboTipoProducto.Size = new System.Drawing.Size(330, 36);
            this.cboTipoProducto.TabIndex = 0;
            // 
            // cboClaseProducto
            // 
            this.cboClaseProducto.BackColor = System.Drawing.Color.Transparent;
            this.cboClaseProducto.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboClaseProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClaseProducto.FocusedColor = System.Drawing.Color.Empty;
            this.cboClaseProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboClaseProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboClaseProducto.ItemHeight = 30;
            this.cboClaseProducto.Location = new System.Drawing.Point(20, 70);
            this.cboClaseProducto.Name = "cboClaseProducto";
            this.cboClaseProducto.Size = new System.Drawing.Size(330, 36);
            this.cboClaseProducto.TabIndex = 1;
            // 
            // cboCategoria
            // 
            this.cboCategoria.BackColor = System.Drawing.Color.Transparent;
            this.cboCategoria.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.FocusedColor = System.Drawing.Color.Empty;
            this.cboCategoria.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboCategoria.ItemHeight = 30;
            this.cboCategoria.Location = new System.Drawing.Point(20, 120);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(330, 36);
            this.cboCategoria.TabIndex = 2;
            // 
            // cboSubcategoria
            // 
            this.cboSubcategoria.BackColor = System.Drawing.Color.Transparent;
            this.cboSubcategoria.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSubcategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubcategoria.FocusedColor = System.Drawing.Color.Empty;
            this.cboSubcategoria.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSubcategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboSubcategoria.ItemHeight = 30;
            this.cboSubcategoria.Location = new System.Drawing.Point(20, 170);
            this.cboSubcategoria.Name = "cboSubcategoria";
            this.cboSubcategoria.Size = new System.Drawing.Size(330, 36);
            this.cboSubcategoria.TabIndex = 3;
            // 
            // cboSubnivel
            // 
            this.cboSubnivel.BackColor = System.Drawing.Color.Transparent;
            this.cboSubnivel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSubnivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubnivel.FocusedColor = System.Drawing.Color.Empty;
            this.cboSubnivel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSubnivel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboSubnivel.ItemHeight = 30;
            this.cboSubnivel.Location = new System.Drawing.Point(20, 220);
            this.cboSubnivel.Name = "cboSubnivel";
            this.cboSubnivel.Size = new System.Drawing.Size(330, 36);
            this.cboSubnivel.TabIndex = 4;
            // 
            // cboMarca
            // 
            this.cboMarca.BackColor = System.Drawing.Color.Transparent;
            this.cboMarca.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMarca.FocusedColor = System.Drawing.Color.Empty;
            this.cboMarca.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboMarca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboMarca.ItemHeight = 30;
            this.cboMarca.Location = new System.Drawing.Point(20, 270);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(330, 36);
            this.cboMarca.TabIndex = 5;
            // 
            // cboLaboratorio
            // 
            this.cboLaboratorio.BackColor = System.Drawing.Color.Transparent;
            this.cboLaboratorio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLaboratorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLaboratorio.FocusedColor = System.Drawing.Color.Empty;
            this.cboLaboratorio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLaboratorio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboLaboratorio.ItemHeight = 30;
            this.cboLaboratorio.Location = new System.Drawing.Point(20, 320);
            this.cboLaboratorio.Name = "cboLaboratorio";
            this.cboLaboratorio.Size = new System.Drawing.Size(330, 36);
            this.cboLaboratorio.TabIndex = 6;
            // 
            // cboClasificacionABC
            // 
            this.cboClasificacionABC.BackColor = System.Drawing.Color.Transparent;
            this.cboClasificacionABC.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboClasificacionABC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClasificacionABC.FocusedColor = System.Drawing.Color.Empty;
            this.cboClasificacionABC.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboClasificacionABC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboClasificacionABC.ItemHeight = 30;
            this.cboClasificacionABC.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.cboClasificacionABC.Location = new System.Drawing.Point(20, 370);
            this.cboClasificacionABC.Name = "cboClasificacionABC";
            this.cboClasificacionABC.Size = new System.Drawing.Size(330, 36);
            this.cboClasificacionABC.TabIndex = 7;
            // 
            // tabInventarioPrecios
            // 
            this.tabInventarioPrecios.Controls.Add(this.numStock);
            this.tabInventarioPrecios.Controls.Add(this.numStockMinimo);
            this.tabInventarioPrecios.Controls.Add(this.numStockMaximo);
            this.tabInventarioPrecios.Controls.Add(this.numPrecioVenta);
            this.tabInventarioPrecios.Location = new System.Drawing.Point(4, 22);
            this.tabInventarioPrecios.Name = "tabInventarioPrecios";
            this.tabInventarioPrecios.Padding = new System.Windows.Forms.Padding(10);
            this.tabInventarioPrecios.Size = new System.Drawing.Size(371, 484);
            this.tabInventarioPrecios.TabIndex = 2;
            this.tabInventarioPrecios.Text = "Inventario y Precios";
            // 
            // numStock
            // 
            this.numStock.Location = new System.Drawing.Point(20, 20);
            this.numStock.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numStock.Name = "numStock";
            this.numStock.Size = new System.Drawing.Size(120, 20);
            this.numStock.TabIndex = 0;
            // 
            // numStockMinimo
            // 
            this.numStockMinimo.Location = new System.Drawing.Point(20, 60);
            this.numStockMinimo.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numStockMinimo.Name = "numStockMinimo";
            this.numStockMinimo.Size = new System.Drawing.Size(120, 20);
            this.numStockMinimo.TabIndex = 1;
            // 
            // numStockMaximo
            // 
            this.numStockMaximo.Location = new System.Drawing.Point(20, 100);
            this.numStockMaximo.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numStockMaximo.Name = "numStockMaximo";
            this.numStockMaximo.Size = new System.Drawing.Size(120, 20);
            this.numStockMaximo.TabIndex = 2;
            // 
            // numPrecioVenta
            // 
            this.numPrecioVenta.DecimalPlaces = 2;
            this.numPrecioVenta.Location = new System.Drawing.Point(20, 140);
            this.numPrecioVenta.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numPrecioVenta.Name = "numPrecioVenta";
            this.numPrecioVenta.Size = new System.Drawing.Size(120, 20);
            this.numPrecioVenta.TabIndex = 3;
            // 
            // tabAtributos
            // 
            this.tabAtributos.Controls.Add(this.chkEsDivisible);
            this.tabAtributos.Controls.Add(this.chkEsPsicotropico);
            this.tabAtributos.Controls.Add(this.chkRequiereCadenaFrio);
            this.tabAtributos.Controls.Add(this.chkRequiereSeguimiento);
            this.tabAtributos.Controls.Add(this.chkCalculoABCManual);
            this.tabAtributos.Location = new System.Drawing.Point(4, 22);
            this.tabAtributos.Name = "tabAtributos";
            this.tabAtributos.Padding = new System.Windows.Forms.Padding(10);
            this.tabAtributos.Size = new System.Drawing.Size(371, 484);
            this.tabAtributos.TabIndex = 3;
            this.tabAtributos.Text = "Atributos";
            // 
            // chkEsDivisible
            // 
            this.chkEsDivisible.CheckedState.BorderRadius = 0;
            this.chkEsDivisible.CheckedState.BorderThickness = 0;
            this.chkEsDivisible.Location = new System.Drawing.Point(20, 20);
            this.chkEsDivisible.Name = "chkEsDivisible";
            this.chkEsDivisible.Size = new System.Drawing.Size(104, 24);
            this.chkEsDivisible.TabIndex = 0;
            this.chkEsDivisible.Text = "Es divisible";
            this.chkEsDivisible.UncheckedState.BorderRadius = 0;
            this.chkEsDivisible.UncheckedState.BorderThickness = 0;
            // 
            // chkEsPsicotropico
            // 
            this.chkEsPsicotropico.CheckedState.BorderRadius = 0;
            this.chkEsPsicotropico.CheckedState.BorderThickness = 0;
            this.chkEsPsicotropico.Location = new System.Drawing.Point(20, 50);
            this.chkEsPsicotropico.Name = "chkEsPsicotropico";
            this.chkEsPsicotropico.Size = new System.Drawing.Size(104, 24);
            this.chkEsPsicotropico.TabIndex = 1;
            this.chkEsPsicotropico.Text = "Psicotrópico";
            this.chkEsPsicotropico.UncheckedState.BorderRadius = 0;
            this.chkEsPsicotropico.UncheckedState.BorderThickness = 0;
            // 
            // chkRequiereCadenaFrio
            // 
            this.chkRequiereCadenaFrio.CheckedState.BorderRadius = 0;
            this.chkRequiereCadenaFrio.CheckedState.BorderThickness = 0;
            this.chkRequiereCadenaFrio.Location = new System.Drawing.Point(20, 80);
            this.chkRequiereCadenaFrio.Name = "chkRequiereCadenaFrio";
            this.chkRequiereCadenaFrio.Size = new System.Drawing.Size(104, 24);
            this.chkRequiereCadenaFrio.TabIndex = 2;
            this.chkRequiereCadenaFrio.Text = "Requiere cadena de frío";
            this.chkRequiereCadenaFrio.UncheckedState.BorderRadius = 0;
            this.chkRequiereCadenaFrio.UncheckedState.BorderThickness = 0;
            // 
            // chkRequiereSeguimiento
            // 
            this.chkRequiereSeguimiento.CheckedState.BorderRadius = 0;
            this.chkRequiereSeguimiento.CheckedState.BorderThickness = 0;
            this.chkRequiereSeguimiento.Location = new System.Drawing.Point(20, 110);
            this.chkRequiereSeguimiento.Name = "chkRequiereSeguimiento";
            this.chkRequiereSeguimiento.Size = new System.Drawing.Size(104, 24);
            this.chkRequiereSeguimiento.TabIndex = 3;
            this.chkRequiereSeguimiento.Text = "Requiere seguimiento";
            this.chkRequiereSeguimiento.UncheckedState.BorderRadius = 0;
            this.chkRequiereSeguimiento.UncheckedState.BorderThickness = 0;
            // 
            // chkCalculoABCManual
            // 
            this.chkCalculoABCManual.CheckedState.BorderRadius = 0;
            this.chkCalculoABCManual.CheckedState.BorderThickness = 0;
            this.chkCalculoABCManual.Location = new System.Drawing.Point(20, 140);
            this.chkCalculoABCManual.Name = "chkCalculoABCManual";
            this.chkCalculoABCManual.Size = new System.Drawing.Size(104, 24);
            this.chkCalculoABCManual.TabIndex = 4;
            this.chkCalculoABCManual.Text = "Cálculo ABC manual";
            this.chkCalculoABCManual.UncheckedState.BorderRadius = 0;
            this.chkCalculoABCManual.UncheckedState.BorderThickness = 0;
            // 
            // contextMenuOpciones
            // 
            this.contextMenuOpciones.Name = "contextMenuOpciones";
            this.contextMenuOpciones.Size = new System.Drawing.Size(61, 4);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 68);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelListado);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelDatos);
            this.splitContainer1.Size = new System.Drawing.Size(1022, 599);
            this.splitContainer1.SplitterDistance = 608;
            this.splitContainer1.TabIndex = 19;
            // 
            // FrmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1022, 667);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelToolbar);
            this.Name = "FrmProductos";
            this.Text = "Módulo de Productos";
            this.Load += new System.EventHandler(this.FrmProductos_Load);
            this.panelToolbar.ResumeLayout(false);
            this.panelListado.ResumeLayout(false);
            this.panelListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListado)).EndInit();
            this.panelDatos.ResumeLayout(false);
            this.tabProducto.ResumeLayout(false);
            this.tabPrincipal.ResumeLayout(false);
            this.tabClasificacion.ResumeLayout(false);
            this.tabInventarioPrecios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStockMinimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStockMaximo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioVenta)).EndInit();
            this.tabAtributos.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // --- Controles Rediseñados y Nuevos ---
        private Guna.UI2.WinForms.Guna2Panel panelToolbar;
        private Guna.UI2.WinForms.Guna2Button btnNuevo;
        private Guna.UI2.WinForms.Guna2Button btnEditar;
        private Guna.UI2.WinForms.Guna2Button btnRecargar;
        private Guna.UI2.WinForms.Guna2Button btnExportar;
        private Guna.UI2.WinForms.Guna2Button btnOpciones;
        private Guna.UI2.WinForms.Guna2Panel panelListado;
        private System.Windows.Forms.Label lblTotal;
        private Guna.UI2.WinForms.Guna2DataGridView DgvListado;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private Guna.UI2.WinForms.Guna2Panel panelDatos;
        private System.Windows.Forms.ContextMenuStrip contextMenuOpciones;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;

        // --- NUEVAS COLUMNAS PARA EL DATAGRIDVIEW ---
        private System.Windows.Forms.DataGridViewImageColumn colStatus;
        private System.Windows.Forms.DataGridViewImageColumn colEditar;
        private System.Windows.Forms.DataGridViewImageColumn colEliminar;

        // Tabs
        private System.Windows.Forms.TabControl tabProducto;
        private System.Windows.Forms.TabPage tabPrincipal;
        private System.Windows.Forms.TabPage tabClasificacion;
        private System.Windows.Forms.TabPage tabInventarioPrecios;
        private System.Windows.Forms.TabPage tabAtributos;

        // Textos
        private Guna.UI2.WinForms.Guna2TextBox txtNombre;
        private Guna.UI2.WinForms.Guna2TextBox txtCodigoPrincipal;
        private Guna.UI2.WinForms.Guna2TextBox txtCodigoAuxiliar;
        private Guna.UI2.WinForms.Guna2TextBox txtDescripcion;
        private Guna.UI2.WinForms.Guna2TextBox txtObservaciones;
        private Guna.UI2.WinForms.Guna2TextBox txtRegistroSanitario;

        // Clasificación
        private Guna.UI2.WinForms.Guna2ComboBox cboTipoProducto;
        private Guna.UI2.WinForms.Guna2ComboBox cboClaseProducto;
        private Guna.UI2.WinForms.Guna2ComboBox cboCategoria;
        private Guna.UI2.WinForms.Guna2ComboBox cboSubcategoria;
        private Guna.UI2.WinForms.Guna2ComboBox cboSubnivel;
        private Guna.UI2.WinForms.Guna2ComboBox cboMarca;
        private Guna.UI2.WinForms.Guna2ComboBox cboLaboratorio;
        private Guna.UI2.WinForms.Guna2ComboBox cboClasificacionABC;

        // Inventario/Precios
        private System.Windows.Forms.NumericUpDown numStock;
        private System.Windows.Forms.NumericUpDown numStockMinimo;
        private System.Windows.Forms.NumericUpDown numStockMaximo;
        private System.Windows.Forms.NumericUpDown numPrecioVenta;

        // Atributos
        private Guna.UI2.WinForms.Guna2CheckBox chkEsDivisible;
        private Guna.UI2.WinForms.Guna2CheckBox chkEsPsicotropico;
        private Guna.UI2.WinForms.Guna2CheckBox chkRequiereCadenaFrio;
        private Guna.UI2.WinForms.Guna2CheckBox chkRequiereSeguimiento;
        private Guna.UI2.WinForms.Guna2CheckBox chkCalculoABCManual;
    }
}
