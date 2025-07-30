using System.Windows.Forms;

namespace LogiPharm.Presentacion
{
    partial class FrmEditarProducto
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
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle(); // <-- AÑADE ESTA LÍNEA
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle_ComboBox = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtNombre = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboClase = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCategoria = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboSubcategoria = new Guna.UI2.WinForms.Guna2ComboBox();
            this.tabProducto = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabImpuestos = new System.Windows.Forms.TabPage();
            this.dgvImpuestos = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colImpuesto = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colAplicaCompra = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colAplicaVenta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabPrecios = new System.Windows.Forms.TabPage();
            this.dgvPrecios = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colUnidadNegocio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostoUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostoCaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostoPonderadoUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostoPonderadoCaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPvpUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPvp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelHeaderPVP = new System.Windows.Forms.Label();
            this.labelHeaderCostoPonderado = new System.Windows.Forms.Label();
            this.labelHeaderUltimoCosto = new System.Windows.Forms.Label();
            this.labelSubPVP = new System.Windows.Forms.Label();
            this.labelSubPvpUnidad = new System.Windows.Forms.Label();
            this.labelSubCostoPonderadoCaja = new System.Windows.Forms.Label();
            this.labelSubCostoPonderadoUnidad = new System.Windows.Forms.Label();
            this.labelSubCostoCaja = new System.Windows.Forms.Label();
            this.labelSubCostoUnidad = new System.Windows.Forms.Label();
            this.labelSubUnidadNegocio = new System.Windows.Forms.Label();
            this.btnAgregarPrecio = new Guna.UI2.WinForms.Guna2Button();
            this.tabPlanesComerciales = new System.Windows.Forms.TabPage();
            this.tabPerchas = new System.Windows.Forms.TabPage();
            this.tabProveedores = new System.Windows.Forms.TabPage();
            this.tabStock = new System.Windows.Forms.TabPage();
            this.tabCaducidad = new System.Windows.Forms.TabPage();
            this.tabCodigos = new System.Windows.Forms.TabPage();
            this.btnSalir = new Guna.UI2.WinForms.Guna2Button();
            this.btnModificar = new Guna.UI2.WinForms.Guna2Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cboSubnivel = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboLaboratorio = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboMarca = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCodigoPrincipal = new Guna.UI2.WinForms.Guna2TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCodigoAuxiliar = new Guna.UI2.WinForms.Guna2TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRegistroSanitario = new Guna.UI2.WinForms.Guna2TextBox();
            this.chkDivisible = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkPsicotropico = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkCalculoABC = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkCadenaFrio = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkSeguimiento = new Guna.UI2.WinForms.Guna2CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.numStockMinimo = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.numStockMaximo = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cboClasificacionABC = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtObservaciones = new Guna.UI2.WinForms.Guna2TextBox();
            this.panelHeader.SuspendLayout();
            this.tabProducto.SuspendLayout();
            this.tabImpuestos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImpuestos)).BeginInit();
            this.tabPrecios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrecios)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStockMinimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStockMaximo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1041, 50);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(12, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(153, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Editar Producto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "* Tipo";
            // 
            // cboTipo
            // 
            this.cboTipo.BackColor = System.Drawing.Color.Transparent;
            this.cboTipo.BorderRadius = 4;
            this.cboTipo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTipo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTipo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboTipo.ItemHeight = 30;
            this.cboTipo.Location = new System.Drawing.Point(20, 89);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(250, 36);
            this.cboTipo.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.BorderRadius = 4;
            this.txtNombre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNombre.DefaultText = "";
            this.txtNombre.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNombre.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNombre.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNombre.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNombre.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNombre.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNombre.Location = new System.Drawing.Point(285, 89);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PlaceholderText = "";
            this.txtNombre.SelectedText = "";
            this.txtNombre.Size = new System.Drawing.Size(526, 36);
            this.txtNombre.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "* Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Clase";
            // 
            // cboClase
            // 
            this.cboClase.BackColor = System.Drawing.Color.Transparent;
            this.cboClase.BorderRadius = 4;
            this.cboClase.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboClase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClase.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboClase.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboClase.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboClase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboClase.ItemHeight = 30;
            this.cboClase.Location = new System.Drawing.Point(20, 159);
            this.cboClase.Name = "cboClase";
            this.cboClase.Size = new System.Drawing.Size(250, 36);
            this.cboClase.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(282, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Categoria";
            // 
            // cboCategoria
            // 
            this.cboCategoria.BackColor = System.Drawing.Color.Transparent;
            this.cboCategoria.BorderRadius = 4;
            this.cboCategoria.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboCategoria.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboCategoria.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboCategoria.ItemHeight = 30;
            this.cboCategoria.Location = new System.Drawing.Point(285, 159);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(250, 36);
            this.cboCategoria.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(558, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Subcategoría";
            // 
            // cboSubcategoria
            // 
            this.cboSubcategoria.BackColor = System.Drawing.Color.Transparent;
            this.cboSubcategoria.BorderRadius = 4;
            this.cboSubcategoria.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSubcategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubcategoria.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSubcategoria.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSubcategoria.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSubcategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboSubcategoria.ItemHeight = 30;
            this.cboSubcategoria.Location = new System.Drawing.Point(561, 159);
            this.cboSubcategoria.Name = "cboSubcategoria";
            this.cboSubcategoria.Size = new System.Drawing.Size(250, 36);
            this.cboSubcategoria.TabIndex = 5;
            // 
            // tabProducto
            // 
            this.tabProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabProducto.Controls.Add(this.tabImpuestos);
            this.tabProducto.Controls.Add(this.tabPrecios);
            this.tabProducto.Controls.Add(this.tabPlanesComerciales);
            this.tabProducto.Controls.Add(this.tabPerchas);
            this.tabProducto.Controls.Add(this.tabProveedores);
            this.tabProducto.Controls.Add(this.tabStock);
            this.tabProducto.Controls.Add(this.tabCaducidad);
            this.tabProducto.Controls.Add(this.tabCodigos);
            this.tabProducto.ItemSize = new System.Drawing.Size(120, 40);
            this.tabProducto.Location = new System.Drawing.Point(20, 580);
            this.tabProducto.Name = "tabProducto";
            this.tabProducto.SelectedIndex = 0;
            this.tabProducto.Size = new System.Drawing.Size(998, 220);
            this.tabProducto.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tabProducto.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tabProducto.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabProducto.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tabProducto.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tabProducto.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tabProducto.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.tabProducto.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabProducto.TabButtonIdleState.ForeColor = System.Drawing.Color.Gray;
            this.tabProducto.TabButtonIdleState.InnerColor = System.Drawing.Color.Transparent;
            this.tabProducto.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tabProducto.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tabProducto.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabProducto.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tabProducto.TabButtonSelectedState.InnerColor = System.Drawing.Color.Transparent;
            this.tabProducto.TabButtonSize = new System.Drawing.Size(120, 40);
            this.tabProducto.TabIndex = 21;
            this.tabProducto.TabMenuBackColor = System.Drawing.Color.White;
            this.tabProducto.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            //
            // tabImpuestos
            //
            this.tabImpuestos.Controls.Add(this.dgvImpuestos);
            this.tabImpuestos.Location = new System.Drawing.Point(4, 44);
            this.tabImpuestos.Name = "tabImpuestos";
            this.tabImpuestos.Padding = new System.Windows.Forms.Padding(3);
            this.tabImpuestos.Size = new System.Drawing.Size(792, 172);
            this.tabImpuestos.TabIndex = 0;
            this.tabImpuestos.Text = "IMPUESTOS";
            this.tabImpuestos.UseVisualStyleBackColor = true;
            // 
            // dgvImpuestos
            // 
            this.dgvImpuestos.AllowUserToAddRows = false;
            this.dgvImpuestos.AllowUserToDeleteRows = false;
            this.dgvImpuestos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvImpuestos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvImpuestos.BackgroundColor = System.Drawing.Color.White;
            this.dgvImpuestos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvImpuestos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvImpuestos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvImpuestos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvImpuestos.ColumnHeadersHeight = 30;
            this.dgvImpuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvImpuestos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImpuesto,
            this.colAplicaCompra,
            this.colAplicaVenta});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvImpuestos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvImpuestos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvImpuestos.EnableHeadersVisualStyles = false;
            this.dgvImpuestos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvImpuestos.Location = new System.Drawing.Point(3, 3);
            this.dgvImpuestos.Name = "dgvImpuestos";
            this.dgvImpuestos.RowHeadersVisible = false;
            this.dgvImpuestos.RowTemplate.Height = 40;
            this.dgvImpuestos.Size = new System.Drawing.Size(786, 166);
            this.dgvImpuestos.TabIndex = 0;
            this.dgvImpuestos.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvImpuestos.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvImpuestos.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvImpuestos.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvImpuestos.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvImpuestos.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvImpuestos.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dgvImpuestos.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvImpuestos.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvImpuestos.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvImpuestos.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvImpuestos.ThemeStyle.RowsStyle.Height = 40;
            this.dgvImpuestos.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.dgvImpuestos.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // colImpuesto
            // 
            this.colImpuesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            // --- INICIO: ESTILO PERSONALIZADO PARA EL COMBOBOX ---
            dataGridViewCellStyle_ComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle_ComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle_ComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            dataGridViewCellStyle_ComboBox.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle_ComboBox.SelectionForeColor = System.Drawing.Color.White;
            this.colImpuesto.DefaultCellStyle = dataGridViewCellStyle_ComboBox;
            // --- FIN: ESTILO PERSONALIZADO ---
            this.colImpuesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colImpuesto.HeaderText = "IMPUESTO";
            this.colImpuesto.Name = "colImpuesto";
            // 
            // colAplicaCompra
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.NullValue = false;
            this.colAplicaCompra.DefaultCellStyle = dataGridViewCellStyle4;
            this.colAplicaCompra.HeaderText = "APLICA COMPRA";
            this.colAplicaCompra.Name = "colAplicaCompra";
            this.colAplicaCompra.Width = 200;
            // 
            // colAplicaVenta
            // 
            this.colAplicaVenta.DefaultCellStyle = dataGridViewCellStyle4; // Reutilizamos el mismo estilo centrado
            this.colAplicaVenta.HeaderText = "APLICA VENTA";
            this.colAplicaVenta.Name = "colAplicaVenta";
            this.colAplicaVenta.Width = 200;
            // 
            // tabPrecios
            // 
            this.tabPrecios.Controls.Add(this.dgvPrecios);
            this.tabPrecios.Controls.Add(this.tableLayoutPanel1);
            this.tabPrecios.Controls.Add(this.btnAgregarPrecio);
            this.tabPrecios.Location = new System.Drawing.Point(4, 44);
            this.tabPrecios.Name = "tabPrecios";
            this.tabPrecios.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrecios.Size = new System.Drawing.Size(1000, 220);
            this.tabPrecios.TabIndex = 1;
            this.tabPrecios.Text = "PRECIOS";
            this.tabPrecios.UseVisualStyleBackColor = true;
            // 
            // dgvPrecios
            // 
            this.dgvPrecios.AllowUserToAddRows = false;
            this.dgvPrecios.AllowUserToDeleteRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.dgvPrecios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPrecios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvPrecios.ColumnHeadersVisible = false;
            this.dgvPrecios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUnidadNegocio,
            this.colCostoUnidad,
            this.colCostoCaja,
            this.colCostoPonderadoUnidad,
            this.colCostoPonderadoCaja,
            this.colPvpUnidad,
            this.colPvp});
            this.dgvPrecios.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPrecios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrecios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPrecios.Location = new System.Drawing.Point(3, 103);
            this.dgvPrecios.Name = "dgvPrecios";
            this.dgvPrecios.RowHeadersVisible = false;
            this.dgvPrecios.RowTemplate.Height = 35;
            this.dgvPrecios.Size = new System.Drawing.Size(990, 60);
            this.dgvPrecios.TabIndex = 2;
            this.dgvPrecios.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPrecios.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvPrecios.ThemeStyle.RowsStyle.Height = 35;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPrecios.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvPrecios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrecios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPrecios.Location = new System.Drawing.Point(3, 103);
            this.dgvPrecios.Name = "dgvPrecios";
            this.dgvPrecios.RowHeadersVisible = false;
            this.dgvPrecios.Size = new System.Drawing.Size(777, 66);
            this.dgvPrecios.TabIndex = 2;
            this.dgvPrecios.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPrecios.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvPrecios.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvPrecios.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvPrecios.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvPrecios.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvPrecios.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPrecios.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvPrecios.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPrecios.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPrecios.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPrecios.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPrecios.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvPrecios.ThemeStyle.ReadOnly = false;
            this.dgvPrecios.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPrecios.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPrecios.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPrecios.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvPrecios.ThemeStyle.RowsStyle.Height = 22;
            this.dgvPrecios.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPrecios.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // tableLayoutPanel1 (El encabezado personalizado)
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Controls.Add(this.labelHeaderPVP, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelHeaderCostoPonderado, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelHeaderUltimoCosto, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelSubPVP, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelSubPvpUnidad, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelSubCostoPonderadoCaja, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelSubCostoPonderadoUnidad, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelSubCostoCaja, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelSubCostoUnidad, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelSubUnidadNegocio, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(777, 60);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnAgregarPrecio
            // 
            this.btnAgregarPrecio.BorderRadius = 4;
            this.btnAgregarPrecio.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(130)))), ((int)(((byte)(12)))));
            this.btnAgregarPrecio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarPrecio.ForeColor = System.Drawing.Color.White;
            this.btnAgregarPrecio.Location = new System.Drawing.Point(6, 6);
            this.btnAgregarPrecio.Name = "btnAgregarPrecio";
            this.btnAgregarPrecio.Size = new System.Drawing.Size(120, 31);
            this.btnAgregarPrecio.TabIndex = 0;
            this.btnAgregarPrecio.Text = "+ Agregar precio";
            // 
            // colUnidadNegocio
            // 
            this.colUnidadNegocio.Name = "colUnidadNegocio";
            // 
            // colCostoUnidad
            // 
            this.colCostoUnidad.Name = "colCostoUnidad";
            // 
            // colCostoCaja
            // 
            this.colCostoCaja.Name = "colCostoCaja";
            // 
            // colCostoPonderadoUnidad
            // 
            this.colCostoPonderadoUnidad.Name = "colCostoPonderadoUnidad";
            // 
            // colCostoPonderadoCaja
            // 
            this.colCostoPonderadoCaja.Name = "colCostoPonderadoCaja";
            // 
            // colPvpUnidad
            // 
            this.colPvpUnidad.Name = "colPvpUnidad";
            // 
            // colPvp
            // 
            this.colPvp.Name = "colPvp";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Controls.Add(this.labelHeaderPVP, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelHeaderCostoPonderado, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelHeaderUltimoCosto, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelSubPVP, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelSubPvpUnidad, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelSubCostoPonderadoCaja, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelSubCostoPonderadoUnidad, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelSubCostoCaja, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelSubCostoUnidad, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelSubUnidadNegocio, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(777, 60);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // labelHeaderPVP
            // 
            this.labelHeaderPVP.Location = new System.Drawing.Point(0, 0);
            this.labelHeaderPVP.Name = "labelHeaderPVP";
            this.labelHeaderPVP.Size = new System.Drawing.Size(100, 23);
            this.labelHeaderPVP.TabIndex = 0;
            // 
            // labelHeaderCostoPonderado
            // 
            this.labelHeaderCostoPonderado.Location = new System.Drawing.Point(0, 0);
            this.labelHeaderCostoPonderado.Name = "labelHeaderCostoPonderado";
            this.labelHeaderCostoPonderado.Size = new System.Drawing.Size(100, 23);
            this.labelHeaderCostoPonderado.TabIndex = 1;
            // 
            // labelHeaderUltimoCosto
            // 
            this.labelHeaderUltimoCosto.Location = new System.Drawing.Point(0, 0);
            this.labelHeaderUltimoCosto.Name = "labelHeaderUltimoCosto";
            this.labelHeaderUltimoCosto.Size = new System.Drawing.Size(100, 23);
            this.labelHeaderUltimoCosto.TabIndex = 2;
            // 
            // labelSubPVP
            // 
            this.labelSubPVP.Location = new System.Drawing.Point(0, 0);
            this.labelSubPVP.Name = "labelSubPVP";
            this.labelSubPVP.Size = new System.Drawing.Size(100, 23);
            this.labelSubPVP.TabIndex = 3;
            // 
            // labelSubPvpUnidad
            // 
            this.labelSubPvpUnidad.Location = new System.Drawing.Point(0, 0);
            this.labelSubPvpUnidad.Name = "labelSubPvpUnidad";
            this.labelSubPvpUnidad.Size = new System.Drawing.Size(100, 23);
            this.labelSubPvpUnidad.TabIndex = 4;
            // 
            // labelSubCostoPonderadoCaja
            // 
            this.labelSubCostoPonderadoCaja.Location = new System.Drawing.Point(0, 0);
            this.labelSubCostoPonderadoCaja.Name = "labelSubCostoPonderadoCaja";
            this.labelSubCostoPonderadoCaja.Size = new System.Drawing.Size(100, 23);
            this.labelSubCostoPonderadoCaja.TabIndex = 5;
            // 
            // labelSubCostoPonderadoUnidad
            // 
            this.labelSubCostoPonderadoUnidad.Location = new System.Drawing.Point(0, 0);
            this.labelSubCostoPonderadoUnidad.Name = "labelSubCostoPonderadoUnidad";
            this.labelSubCostoPonderadoUnidad.Size = new System.Drawing.Size(100, 23);
            this.labelSubCostoPonderadoUnidad.TabIndex = 6;
            // 
            // labelSubCostoCaja
            // 
            this.labelSubCostoCaja.Location = new System.Drawing.Point(0, 0);
            this.labelSubCostoCaja.Name = "labelSubCostoCaja";
            this.labelSubCostoCaja.Size = new System.Drawing.Size(100, 23);
            this.labelSubCostoCaja.TabIndex = 7;
            // 
            // labelSubCostoUnidad
            // 
            this.labelSubCostoUnidad.Location = new System.Drawing.Point(0, 0);
            this.labelSubCostoUnidad.Name = "labelSubCostoUnidad";
            this.labelSubCostoUnidad.Size = new System.Drawing.Size(100, 23);
            this.labelSubCostoUnidad.TabIndex = 8;
            // 
            // labelSubUnidadNegocio
            // 
            this.labelSubUnidadNegocio.Location = new System.Drawing.Point(0, 0);
            this.labelSubUnidadNegocio.Name = "labelSubUnidadNegocio";
            this.labelSubUnidadNegocio.Size = new System.Drawing.Size(100, 23);
            this.labelSubUnidadNegocio.TabIndex = 9;
            // 
            // btnAgregarPrecio
            // 
            this.btnAgregarPrecio.BorderRadius = 4;
            this.btnAgregarPrecio.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(130)))), ((int)(((byte)(12)))));
            this.btnAgregarPrecio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarPrecio.ForeColor = System.Drawing.Color.White;
            this.btnAgregarPrecio.Location = new System.Drawing.Point(6, 6);
            this.btnAgregarPrecio.Name = "btnAgregarPrecio";
            this.btnAgregarPrecio.Size = new System.Drawing.Size(120, 31);
            this.btnAgregarPrecio.TabIndex = 0;
            this.btnAgregarPrecio.Text = "+ Agregar precio";
            // 
            // tabPlanesComerciales
            // 
            this.tabPlanesComerciales.Location = new System.Drawing.Point(4, 84);
            this.tabPlanesComerciales.Name = "tabPlanesComerciales";
            this.tabPlanesComerciales.Size = new System.Drawing.Size(783, 132);
            this.tabPlanesComerciales.TabIndex = 2;
            this.tabPlanesComerciales.Text = "PLANES COMERCIALES";
            this.tabPlanesComerciales.UseVisualStyleBackColor = true;
            // 
            // tabPerchas
            // 
            this.tabPerchas.Location = new System.Drawing.Point(4, 84);
            this.tabPerchas.Name = "tabPerchas";
            this.tabPerchas.Size = new System.Drawing.Size(783, 132);
            this.tabPerchas.TabIndex = 3;
            this.tabPerchas.Text = "PERCHAS Y BANDEJAS";
            this.tabPerchas.UseVisualStyleBackColor = true;
            // 
            // tabProveedores
            // 
            this.tabProveedores.Location = new System.Drawing.Point(4, 84);
            this.tabProveedores.Name = "tabProveedores";
            this.tabProveedores.Size = new System.Drawing.Size(783, 132);
            this.tabProveedores.TabIndex = 4;
            this.tabProveedores.Text = "PROVEEDORES";
            this.tabProveedores.UseVisualStyleBackColor = true;
            // 
            // tabStock
            // 
            this.tabStock.Location = new System.Drawing.Point(4, 84);
            this.tabStock.Name = "tabStock";
            this.tabStock.Size = new System.Drawing.Size(783, 132);
            this.tabStock.TabIndex = 5;
            this.tabStock.Text = "STOCK";
            this.tabStock.UseVisualStyleBackColor = true;
            // 
            // tabCaducidad
            // 
            this.tabCaducidad.Location = new System.Drawing.Point(4, 84);
            this.tabCaducidad.Name = "tabCaducidad";
            this.tabCaducidad.Size = new System.Drawing.Size(783, 132);
            this.tabCaducidad.TabIndex = 6;
            this.tabCaducidad.Text = "CADUCIDAD";
            this.tabCaducidad.UseVisualStyleBackColor = true;
            // 
            // tabCodigos
            // 
            this.tabCodigos.Location = new System.Drawing.Point(4, 84);
            this.tabCodigos.Name = "tabCodigos";
            this.tabCodigos.Size = new System.Drawing.Size(783, 132);
            this.tabCodigos.TabIndex = 7;
            this.tabCodigos.Text = "CÓDIGOS";
            this.tabCodigos.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BorderRadius = 4;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FillColor = System.Drawing.Color.Gray;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(802, 818);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(105, 45);
            this.btnSalir.TabIndex = 22;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificar.BorderRadius = 4;
            this.btnModificar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnModificar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnModificar.ForeColor = System.Drawing.Color.White;
            this.btnModificar.Location = new System.Drawing.Point(913, 818);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(105, 45);
            this.btnModificar.TabIndex = 23;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Subnivel";
            // 
            // cboSubnivel
            // 
            this.cboSubnivel.BackColor = System.Drawing.Color.Transparent;
            this.cboSubnivel.BorderRadius = 4;
            this.cboSubnivel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSubnivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubnivel.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSubnivel.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSubnivel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSubnivel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboSubnivel.ItemHeight = 30;
            this.cboSubnivel.Location = new System.Drawing.Point(20, 229);
            this.cboSubnivel.Name = "cboSubnivel";
            this.cboSubnivel.Size = new System.Drawing.Size(250, 36);
            this.cboSubnivel.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(282, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Laboratorio";
            // 
            // cboLaboratorio
            // 
            this.cboLaboratorio.BackColor = System.Drawing.Color.Transparent;
            this.cboLaboratorio.BorderRadius = 4;
            this.cboLaboratorio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLaboratorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLaboratorio.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLaboratorio.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLaboratorio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLaboratorio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboLaboratorio.ItemHeight = 30;
            this.cboLaboratorio.Location = new System.Drawing.Point(285, 229);
            this.cboLaboratorio.Name = "cboLaboratorio";
            this.cboLaboratorio.Size = new System.Drawing.Size(250, 36);
            this.cboLaboratorio.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(558, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Marca";
            // 
            // cboMarca
            // 
            this.cboMarca.BackColor = System.Drawing.Color.Transparent;
            this.cboMarca.BorderRadius = 4;
            this.cboMarca.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMarca.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboMarca.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboMarca.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboMarca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboMarca.ItemHeight = 30;
            this.cboMarca.Location = new System.Drawing.Point(561, 229);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(250, 36);
            this.cboMarca.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 280);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "* Código Principal";
            // 
            // txtCodigoPrincipal
            // 
            this.txtCodigoPrincipal.BorderRadius = 4;
            this.txtCodigoPrincipal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCodigoPrincipal.DefaultText = "";
            this.txtCodigoPrincipal.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCodigoPrincipal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCodigoPrincipal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCodigoPrincipal.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCodigoPrincipal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCodigoPrincipal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCodigoPrincipal.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCodigoPrincipal.Location = new System.Drawing.Point(20, 299);
            this.txtCodigoPrincipal.Name = "txtCodigoPrincipal";
            this.txtCodigoPrincipal.PlaceholderText = "";
            this.txtCodigoPrincipal.SelectedText = "";
            this.txtCodigoPrincipal.Size = new System.Drawing.Size(250, 36);
            this.txtCodigoPrincipal.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(282, 280);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Código Auxiliar";
            // 
            // txtCodigoAuxiliar
            // 
            this.txtCodigoAuxiliar.BorderRadius = 4;
            this.txtCodigoAuxiliar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCodigoAuxiliar.DefaultText = "";
            this.txtCodigoAuxiliar.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCodigoAuxiliar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCodigoAuxiliar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCodigoAuxiliar.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCodigoAuxiliar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCodigoAuxiliar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCodigoAuxiliar.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCodigoAuxiliar.Location = new System.Drawing.Point(285, 299);
            this.txtCodigoAuxiliar.Name = "txtCodigoAuxiliar";
            this.txtCodigoAuxiliar.PlaceholderText = "";
            this.txtCodigoAuxiliar.SelectedText = "";
            this.txtCodigoAuxiliar.Size = new System.Drawing.Size(250, 36);
            this.txtCodigoAuxiliar.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(558, 280);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Registro Sanitario";
            // 
            // txtRegistroSanitario
            // 
            this.txtRegistroSanitario.BorderRadius = 4;
            this.txtRegistroSanitario.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRegistroSanitario.DefaultText = "";
            this.txtRegistroSanitario.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRegistroSanitario.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRegistroSanitario.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRegistroSanitario.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRegistroSanitario.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRegistroSanitario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRegistroSanitario.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRegistroSanitario.Location = new System.Drawing.Point(561, 299);
            this.txtRegistroSanitario.Name = "txtRegistroSanitario";
            this.txtRegistroSanitario.PlaceholderText = "";
            this.txtRegistroSanitario.SelectedText = "";
            this.txtRegistroSanitario.Size = new System.Drawing.Size(250, 36);
            this.txtRegistroSanitario.TabIndex = 11;
            // 
            // chkDivisible
            // 
            this.chkDivisible.AutoSize = true;
            this.chkDivisible.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkDivisible.CheckedState.BorderRadius = 0;
            this.chkDivisible.CheckedState.BorderThickness = 0;
            this.chkDivisible.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkDivisible.Location = new System.Drawing.Point(20, 350);
            this.chkDivisible.Name = "chkDivisible";
            this.chkDivisible.Size = new System.Drawing.Size(65, 17);
            this.chkDivisible.TabIndex = 12;
            this.chkDivisible.Text = "Divisible";
            this.chkDivisible.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkDivisible.UncheckedState.BorderRadius = 0;
            this.chkDivisible.UncheckedState.BorderThickness = 0;
            this.chkDivisible.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkPsicotropico
            // 
            this.chkPsicotropico.AutoSize = true;
            this.chkPsicotropico.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkPsicotropico.CheckedState.BorderRadius = 0;
            this.chkPsicotropico.CheckedState.BorderThickness = 0;
            this.chkPsicotropico.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkPsicotropico.Location = new System.Drawing.Point(150, 350);
            this.chkPsicotropico.Name = "chkPsicotropico";
            this.chkPsicotropico.Size = new System.Drawing.Size(84, 17);
            this.chkPsicotropico.TabIndex = 13;
            this.chkPsicotropico.Text = "Psicotrópico";
            this.chkPsicotropico.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkPsicotropico.UncheckedState.BorderRadius = 0;
            this.chkPsicotropico.UncheckedState.BorderThickness = 0;
            this.chkPsicotropico.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkCalculoABC
            // 
            this.chkCalculoABC.AutoSize = true;
            this.chkCalculoABC.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkCalculoABC.CheckedState.BorderRadius = 0;
            this.chkCalculoABC.CheckedState.BorderThickness = 0;
            this.chkCalculoABC.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkCalculoABC.Location = new System.Drawing.Point(285, 350);
            this.chkCalculoABC.Name = "chkCalculoABC";
            this.chkCalculoABC.Size = new System.Drawing.Size(123, 17);
            this.chkCalculoABC.TabIndex = 14;
            this.chkCalculoABC.Text = "Cálculo ABC Manual";
            this.chkCalculoABC.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkCalculoABC.UncheckedState.BorderRadius = 0;
            this.chkCalculoABC.UncheckedState.BorderThickness = 0;
            this.chkCalculoABC.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkCadenaFrio
            // 
            this.chkCadenaFrio.AutoSize = true;
            this.chkCadenaFrio.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkCadenaFrio.CheckedState.BorderRadius = 0;
            this.chkCadenaFrio.CheckedState.BorderThickness = 0;
            this.chkCadenaFrio.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkCadenaFrio.Location = new System.Drawing.Point(430, 350);
            this.chkCadenaFrio.Name = "chkCadenaFrio";
            this.chkCadenaFrio.Size = new System.Drawing.Size(80, 17);
            this.chkCadenaFrio.TabIndex = 15;
            this.chkCadenaFrio.Text = "Cadena frio";
            this.chkCadenaFrio.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkCadenaFrio.UncheckedState.BorderRadius = 0;
            this.chkCadenaFrio.UncheckedState.BorderThickness = 0;
            this.chkCadenaFrio.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkSeguimiento
            // 
            this.chkSeguimiento.AutoSize = true;
            this.chkSeguimiento.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkSeguimiento.CheckedState.BorderRadius = 0;
            this.chkSeguimiento.CheckedState.BorderThickness = 0;
            this.chkSeguimiento.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkSeguimiento.Location = new System.Drawing.Point(561, 350);
            this.chkSeguimiento.Name = "chkSeguimiento";
            this.chkSeguimiento.Size = new System.Drawing.Size(84, 17);
            this.chkSeguimiento.TabIndex = 16;
            this.chkSeguimiento.Text = "Seguimiento";
            this.chkSeguimiento.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkSeguimiento.UncheckedState.BorderRadius = 0;
            this.chkSeguimiento.UncheckedState.BorderThickness = 0;
            this.chkSeguimiento.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 390);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "* Stock Mínimo";
            // 
            // numStockMinimo
            // 
            this.numStockMinimo.BackColor = System.Drawing.Color.Transparent;
            this.numStockMinimo.BorderRadius = 4;
            this.numStockMinimo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numStockMinimo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numStockMinimo.Location = new System.Drawing.Point(20, 409);
            this.numStockMinimo.Name = "numStockMinimo";
            this.numStockMinimo.Size = new System.Drawing.Size(250, 36);
            this.numStockMinimo.TabIndex = 17;
            // 
            // numStockMaximo
            // 
            this.numStockMaximo.BackColor = System.Drawing.Color.Transparent;
            this.numStockMaximo.BorderRadius = 4;
            this.numStockMaximo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numStockMaximo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numStockMaximo.Location = new System.Drawing.Point(285, 409);
            this.numStockMaximo.Name = "numStockMaximo";
            this.numStockMaximo.Size = new System.Drawing.Size(250, 36);
            this.numStockMaximo.TabIndex = 18;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(282, 390);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "* Stock Máximo";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(558, 390);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 13);
            this.label14.TabIndex = 22;
            this.label14.Text = "* Clasificación ABC";
            // 
            // cboClasificacionABC
            // 
            this.cboClasificacionABC.BackColor = System.Drawing.Color.Transparent;
            this.cboClasificacionABC.BorderRadius = 4;
            this.cboClasificacionABC.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboClasificacionABC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClasificacionABC.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboClasificacionABC.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboClasificacionABC.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboClasificacionABC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboClasificacionABC.ItemHeight = 30;
            this.cboClasificacionABC.Location = new System.Drawing.Point(561, 409);
            this.cboClasificacionABC.Name = "cboClasificacionABC";
            this.cboClasificacionABC.Size = new System.Drawing.Size(250, 36);
            this.cboClasificacionABC.TabIndex = 19;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 460);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 13);
            this.label15.TabIndex = 23;
            this.label15.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.BorderRadius = 4;
            this.txtObservaciones.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtObservaciones.DefaultText = "";
            this.txtObservaciones.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtObservaciones.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtObservaciones.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtObservaciones.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtObservaciones.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtObservaciones.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtObservaciones.Location = new System.Drawing.Point(20, 479);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.PlaceholderText = "";
            this.txtObservaciones.SelectedText = "";
            this.txtObservaciones.Size = new System.Drawing.Size(791, 80);
            this.txtObservaciones.TabIndex = 20;
            // 
            // FrmEditarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1041, 875);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cboClasificacionABC);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.numStockMaximo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.numStockMinimo);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.chkSeguimiento);
            this.Controls.Add(this.chkCadenaFrio);
            this.Controls.Add(this.chkCalculoABC);
            this.Controls.Add(this.chkPsicotropico);
            this.Controls.Add(this.chkDivisible);
            this.Controls.Add(this.txtRegistroSanitario);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCodigoAuxiliar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtCodigoPrincipal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboMarca);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboLaboratorio);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboSubnivel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.tabProducto);
            this.Controls.Add(this.cboSubcategoria);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboCategoria);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboClase);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar Producto";
            this.Load += new System.EventHandler(this.FrmEditarProducto_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tabProducto.ResumeLayout(false);
            this.tabImpuestos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImpuestos)).EndInit();
            this.tabPrecios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrecios)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numStockMinimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStockMaximo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cboTipo;
        private Guna.UI2.WinForms.Guna2TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox cboClase;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox cboCategoria;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox cboSubcategoria;
        private Guna.UI2.WinForms.Guna2TabControl tabProducto;
        private System.Windows.Forms.TabPage tabImpuestos;
        private System.Windows.Forms.TabPage tabPrecios;
        private Guna.UI2.WinForms.Guna2Button btnSalir;
        private Guna.UI2.WinForms.Guna2Button btnModificar;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox cboSubnivel;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2ComboBox cboLaboratorio;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2ComboBox cboMarca;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox txtCodigoPrincipal;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2TextBox txtCodigoAuxiliar;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2TextBox txtRegistroSanitario;
        private Guna.UI2.WinForms.Guna2CheckBox chkDivisible;
        private Guna.UI2.WinForms.Guna2CheckBox chkPsicotropico;
        private Guna.UI2.WinForms.Guna2CheckBox chkCalculoABC;
        private Guna.UI2.WinForms.Guna2CheckBox chkCadenaFrio;
        private Guna.UI2.WinForms.Guna2CheckBox chkSeguimiento;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2NumericUpDown numStockMinimo;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2NumericUpDown numStockMaximo;
        private System.Windows.Forms.Label label14;
        private Guna.UI2.WinForms.Guna2ComboBox cboClasificacionABC;
        private System.Windows.Forms.Label label15;
        private Guna.UI2.WinForms.Guna2TextBox txtObservaciones;
        private System.Windows.Forms.TabPage tabPlanesComerciales;
        private System.Windows.Forms.TabPage tabPerchas;
        private System.Windows.Forms.TabPage tabProveedores;
        private System.Windows.Forms.TabPage tabStock;
        private System.Windows.Forms.TabPage tabCaducidad;
        private System.Windows.Forms.TabPage tabCodigos;
        private Guna.UI2.WinForms.Guna2DataGridView dgvImpuestos;
        private System.Windows.Forms.DataGridViewComboBoxColumn colImpuesto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAplicaCompra;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAplicaVenta;
        // --- INICIO: NUEVAS DECLARACIONES PARA PESTAÑA PRECIOS ---
        private Guna.UI2.WinForms.Guna2Button btnAgregarPrecio;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelHeaderPVP;
        private System.Windows.Forms.Label labelHeaderCostoPonderado;
        private System.Windows.Forms.Label labelHeaderUltimoCosto;
        private System.Windows.Forms.Label labelSubPVP;
        private System.Windows.Forms.Label labelSubPvpUnidad;
        private System.Windows.Forms.Label labelSubCostoPonderadoCaja;
        private System.Windows.Forms.Label labelSubCostoPonderadoUnidad;
        private System.Windows.Forms.Label labelSubCostoCaja;
        private System.Windows.Forms.Label labelSubCostoUnidad;
        private System.Windows.Forms.Label labelSubUnidadNegocio;
        private Guna.UI2.WinForms.Guna2DataGridView dgvPrecios;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidadNegocio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostoUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostoCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostoPonderadoUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostoPonderadoCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPvpUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPvp;
    }
}
