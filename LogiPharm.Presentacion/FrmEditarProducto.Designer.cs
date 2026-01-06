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
            this.panelPreciosWrapper = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvPrecios = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colUnidadNegocio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostoUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostoCaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostoPonderadoUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostoPonderadoCaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPvpUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPvp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPreciosHint = new System.Windows.Forms.Label();
            this.lblPreciosTitle = new System.Windows.Forms.Label();
            this.btnAgregarPrecio = new Guna.UI2.WinForms.Guna2Button();
            this.tabPerchas = new System.Windows.Forms.TabPage();
            this.tableLayoutPerchas = new System.Windows.Forms.TableLayoutPanel();
            this.panelPerchaCard = new Guna.UI2.WinForms.Guna2Panel();
            this.btnGuardarPercha = new Guna.UI2.WinForms.Guna2Button();
            this.txtPerchaReferencia = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPerchaReferencia = new System.Windows.Forms.Label();
            this.numPerchaNivel = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.lblPerchaNivel = new System.Windows.Forms.Label();
            this.txtPerchaUbicacion = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPerchaUbicacion = new System.Windows.Forms.Label();
            this.lblPerchaHint = new System.Windows.Forms.Label();
            this.lblPerchaTitle = new System.Windows.Forms.Label();
            this.panelBandejaCard = new Guna.UI2.WinForms.Guna2Panel();
            this.btnGuardarBandeja = new Guna.UI2.WinForms.Guna2Button();
            this.numBandejaCapacidad = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.lblBandejaCapacidad = new System.Windows.Forms.Label();
            this.cboBandejaSeccion = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblBandejaSeccion = new System.Windows.Forms.Label();
            this.txtBandejaCodigo = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblBandejaCodigo = new System.Windows.Forms.Label();
            this.lblBandejaHint = new System.Windows.Forms.Label();
            this.lblBandejaTitle = new System.Windows.Forms.Label();
            this.tabStock = new System.Windows.Forms.TabPage();
            this.tableLayoutStock = new System.Windows.Forms.TableLayoutPanel();
            this.flowStockCards = new System.Windows.Forms.FlowLayoutPanel();
            this.cardStockActual = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStockActualValue = new System.Windows.Forms.Label();
            this.lblStockActualTitle = new System.Windows.Forms.Label();
            this.cardStockMin = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStockMinValue = new System.Windows.Forms.Label();
            this.lblStockMinTitle = new System.Windows.Forms.Label();
            this.cardStockMax = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStockMaxValue = new System.Windows.Forms.Label();
            this.lblStockMaxTitle = new System.Windows.Forms.Label();
            this.dgvStockMovimientos = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colStockFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabCaducidad = new System.Windows.Forms.TabPage();
            this.tableLayoutCaducidad = new System.Windows.Forms.TableLayoutPanel();
            this.panelCaducidadFiltro = new Guna.UI2.WinForms.Guna2Panel();
            this.btnAgregarLote = new Guna.UI2.WinForms.Guna2Button();
            this.btnFiltrarCaducidad = new Guna.UI2.WinForms.Guna2Button();
            this.dtpCaducidadHasta = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblCaducidadHasta = new System.Windows.Forms.Label();
            this.dtpCaducidadDesde = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblCaducidadDesde = new System.Windows.Forms.Label();
            this.dgvCaducidades = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colCaducidadLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCaducidadFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCaducidadCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCaducidadEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.tabPerchas.SuspendLayout();
            this.tableLayoutPerchas.SuspendLayout();
            this.panelPerchaCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPerchaNivel)).BeginInit();
            this.panelBandejaCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBandejaCapacidad)).BeginInit();
            this.tabStock.SuspendLayout();
            this.tableLayoutStock.SuspendLayout();
            this.flowStockCards.SuspendLayout();
            this.cardStockActual.SuspendLayout();
            this.cardStockMin.SuspendLayout();
            this.cardStockMax.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockMovimientos)).BeginInit();
            this.tabCaducidad.SuspendLayout();
            this.tableLayoutCaducidad.SuspendLayout();
            this.panelCaducidadFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaducidades)).BeginInit();
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
            this.tabProducto.Controls.Add(this.tabPerchas);
            this.tabProducto.Controls.Add(this.tabStock);
            this.tabProducto.Controls.Add(this.tabCaducidad);
            this.tabProducto.ItemSize = new System.Drawing.Size(120, 40);
            this.tabProducto.Location = new System.Drawing.Point(20, 580);
            this.tabProducto.Name = "tabProducto";
            this.tabProducto.SelectedIndex = 0;
            this.tabProducto.Size = new System.Drawing.Size(998, 220);
            this.tabProducto.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tabProducto.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(180)))));
            this.tabProducto.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabProducto.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tabProducto.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(180)))));
            this.tabProducto.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tabProducto.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.tabProducto.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabProducto.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(129)))), ((int)(((byte)(149)))));
            this.tabProducto.TabButtonIdleState.InnerColor = System.Drawing.Color.Transparent;
            this.tabProducto.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tabProducto.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.tabProducto.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabProducto.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tabProducto.TabButtonSelectedState.InnerColor = System.Drawing.Color.Transparent;
            this.tabProducto.TabButtonSize = new System.Drawing.Size(120, 40);
            this.tabProducto.TabIndex = 21;
            this.tabProducto.TabMenuBackColor = System.Drawing.Color.WhiteSmoke;
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
            this.tabPrecios.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPrecios.Controls.Add(this.panelPreciosWrapper);
            this.tabPrecios.Location = new System.Drawing.Point(4, 44);
            this.tabPrecios.Name = "tabPrecios";
            this.tabPrecios.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrecios.Size = new System.Drawing.Size(990, 172);
            this.tabPrecios.TabIndex = 1;
            this.tabPrecios.Text = "PRECIOS";
            // 
            // panelPreciosWrapper
            // 
            this.panelPreciosWrapper.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelPreciosWrapper.BorderRadius = 8;
            this.panelPreciosWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPreciosWrapper.Location = new System.Drawing.Point(3, 3);
            this.panelPreciosWrapper.Name = "panelPreciosWrapper";
            this.panelPreciosWrapper.Padding = new System.Windows.Forms.Padding(15);
            this.panelPreciosWrapper.ShadowDecoration.Enabled = true;
            this.panelPreciosWrapper.Size = new System.Drawing.Size(984, 166);
            this.panelPreciosWrapper.TabIndex = 0;
            this.panelPreciosWrapper.Controls.Add(this.tableLayoutPanel1);
            this.panelPreciosWrapper.Controls.Add(this.dgvPrecios);
            this.panelPreciosWrapper.Controls.Add(this.lblPreciosHint);
            this.panelPreciosWrapper.Controls.Add(this.lblPreciosTitle);
            this.panelPreciosWrapper.Controls.Add(this.btnAgregarPrecio);
            // 
            // dgvPrecios
            // 
            this.dgvPrecios.AllowUserToAddRows = false;
            this.dgvPrecios.AllowUserToDeleteRows = false;
            this.dgvPrecios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.dgvPrecios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvPrecios.BackgroundColor = System.Drawing.Color.White;
            this.dgvPrecios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPrecios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
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
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPrecios.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvPrecios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrecios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvPrecios.Location = new System.Drawing.Point(15, 115);
            this.dgvPrecios.Name = "dgvPrecios";
            this.dgvPrecios.RowHeadersVisible = false;
            this.dgvPrecios.RowTemplate.Height = 35;
            this.dgvPrecios.Size = new System.Drawing.Size(954, 36);
            this.dgvPrecios.TabIndex = 3;
            this.dgvPrecios.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPrecios.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvPrecios.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvPrecios.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPrecios.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPrecios.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvPrecios.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dgvPrecios.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPrecios.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPrecios.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvPrecios.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.dgvPrecios.ThemeStyle.RowsStyle.Height = 35;
            this.dgvPrecios.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.dgvPrecios.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 70);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(954, 60);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lblPreciosHint
            // 
            this.lblPreciosHint.AutoSize = true;
            this.lblPreciosHint.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPreciosHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(105)))), ((int)(((byte)(117)))));
            this.lblPreciosHint.Location = new System.Drawing.Point(18, 46);
            this.lblPreciosHint.Name = "lblPreciosHint";
            this.lblPreciosHint.Size = new System.Drawing.Size(266, 15);
            this.lblPreciosHint.TabIndex = 1;
            this.lblPreciosHint.Text = "Define los precios base y obtén cálculos automáticos";
            // 
            // lblPreciosTitle
            // 
            this.lblPreciosTitle.AutoSize = true;
            this.lblPreciosTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPreciosTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblPreciosTitle.Location = new System.Drawing.Point(16, 18);
            this.lblPreciosTitle.Name = "lblPreciosTitle";
            this.lblPreciosTitle.Size = new System.Drawing.Size(182, 20);
            this.lblPreciosTitle.TabIndex = 0;
            this.lblPreciosTitle.Text = "Gestión de precios activos";
            // 
            // btnAgregarPrecio
            // 
            this.btnAgregarPrecio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarPrecio.BorderRadius = 6;
            this.btnAgregarPrecio.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAgregarPrecio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarPrecio.ForeColor = System.Drawing.Color.White;
            this.btnAgregarPrecio.Location = new System.Drawing.Point(849, 15);
            this.btnAgregarPrecio.Name = "btnAgregarPrecio";
            this.btnAgregarPrecio.Size = new System.Drawing.Size(120, 32);
            this.btnAgregarPrecio.TabIndex = 4;
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
            // 
            // tabPerchas
            // 
            this.tabPerchas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPerchas.Controls.Add(this.tableLayoutPerchas);
            this.tabPerchas.Location = new System.Drawing.Point(4, 44);
            this.tabPerchas.Name = "tabPerchas";
            this.tabPerchas.Padding = new System.Windows.Forms.Padding(12);
            this.tabPerchas.Size = new System.Drawing.Size(990, 172);
            this.tabPerchas.TabIndex = 2;
            this.tabPerchas.Text = "PERCHAS Y BANDEJAS";
            // 
            // tableLayoutPerchas
            // 
            this.tableLayoutPerchas.ColumnCount = 2;
            this.tableLayoutPerchas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPerchas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPerchas.Controls.Add(this.panelPerchaCard, 0, 0);
            this.tableLayoutPerchas.Controls.Add(this.panelBandejaCard, 1, 0);
            this.tableLayoutPerchas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPerchas.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPerchas.Name = "tableLayoutPerchas";
            this.tableLayoutPerchas.RowCount = 1;
            this.tableLayoutPerchas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPerchas.Size = new System.Drawing.Size(966, 148);
            this.tableLayoutPerchas.TabIndex = 0;
            // 
            // panelPerchaCard
            // 
            this.panelPerchaCard.BackColor = System.Drawing.Color.White;
            this.panelPerchaCard.BorderRadius = 10;
            this.panelPerchaCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPerchaCard.FillColor = System.Drawing.Color.White;
            this.panelPerchaCard.Location = new System.Drawing.Point(3, 3);
            this.panelPerchaCard.Name = "panelPerchaCard";
            this.panelPerchaCard.Padding = new System.Windows.Forms.Padding(18);
            this.panelPerchaCard.ShadowDecoration.Enabled = true;
            this.panelPerchaCard.Size = new System.Drawing.Size(477, 142);
            this.panelPerchaCard.TabIndex = 0;
            this.panelPerchaCard.Controls.Add(this.btnGuardarPercha);
            this.panelPerchaCard.Controls.Add(this.txtPerchaReferencia);
            this.panelPerchaCard.Controls.Add(this.lblPerchaReferencia);
            this.panelPerchaCard.Controls.Add(this.numPerchaNivel);
            this.panelPerchaCard.Controls.Add(this.lblPerchaNivel);
            this.panelPerchaCard.Controls.Add(this.txtPerchaUbicacion);
            this.panelPerchaCard.Controls.Add(this.lblPerchaUbicacion);
            this.panelPerchaCard.Controls.Add(this.lblPerchaHint);
            this.panelPerchaCard.Controls.Add(this.lblPerchaTitle);
            // 
            // btnGuardarPercha
            // 
            this.btnGuardarPercha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardarPercha.BorderRadius = 6;
            this.btnGuardarPercha.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnGuardarPercha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardarPercha.ForeColor = System.Drawing.Color.White;
            this.btnGuardarPercha.Location = new System.Drawing.Point(341, 101);
            this.btnGuardarPercha.Name = "btnGuardarPercha";
            this.btnGuardarPercha.Size = new System.Drawing.Size(120, 32);
            this.btnGuardarPercha.TabIndex = 7;
            this.btnGuardarPercha.Text = "Guardar";
            // 
            // txtPerchaReferencia
            // 
            this.txtPerchaReferencia.BorderRadius = 6;
            this.txtPerchaReferencia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPerchaReferencia.DefaultText = "";
            this.txtPerchaReferencia.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPerchaReferencia.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPerchaReferencia.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPerchaReferencia.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPerchaReferencia.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPerchaReferencia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPerchaReferencia.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPerchaReferencia.Location = new System.Drawing.Point(21, 104);
            this.txtPerchaReferencia.Name = "txtPerchaReferencia";
            this.txtPerchaReferencia.PlaceholderText = "Descripción o referencia visual";
            this.txtPerchaReferencia.SelectedText = "";
            this.txtPerchaReferencia.Size = new System.Drawing.Size(304, 29);
            this.txtPerchaReferencia.TabIndex = 6;
            // 
            // lblPerchaReferencia
            // 
            this.lblPerchaReferencia.AutoSize = true;
            this.lblPerchaReferencia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPerchaReferencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(105)))), ((int)(((byte)(117)))));
            this.lblPerchaReferencia.Location = new System.Drawing.Point(18, 86);
            this.lblPerchaReferencia.Name = "lblPerchaReferencia";
            this.lblPerchaReferencia.Size = new System.Drawing.Size(141, 15);
            this.lblPerchaReferencia.TabIndex = 5;
            this.lblPerchaReferencia.Text = "Referencia o descripción";
            // 
            // numPerchaNivel
            // 
            this.numPerchaNivel.BackColor = System.Drawing.Color.Transparent;
            this.numPerchaNivel.BorderRadius = 6;
            this.numPerchaNivel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numPerchaNivel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numPerchaNivel.Location = new System.Drawing.Point(341, 51);
            this.numPerchaNivel.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPerchaNivel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPerchaNivel.Name = "numPerchaNivel";
            this.numPerchaNivel.Size = new System.Drawing.Size(120, 29);
            this.numPerchaNivel.TabIndex = 4;
            this.numPerchaNivel.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.numPerchaNivel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblPerchaNivel
            // 
            this.lblPerchaNivel.AutoSize = true;
            this.lblPerchaNivel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPerchaNivel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(105)))), ((int)(((byte)(117)))));
            this.lblPerchaNivel.Location = new System.Drawing.Point(338, 33);
            this.lblPerchaNivel.Name = "lblPerchaNivel";
            this.lblPerchaNivel.Size = new System.Drawing.Size(121, 15);
            this.lblPerchaNivel.TabIndex = 3;
            this.lblPerchaNivel.Text = "Nivel o altura asignada";
            // 
            // txtPerchaUbicacion
            // 
            this.txtPerchaUbicacion.BorderRadius = 6;
            this.txtPerchaUbicacion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPerchaUbicacion.DefaultText = "";
            this.txtPerchaUbicacion.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPerchaUbicacion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPerchaUbicacion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPerchaUbicacion.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPerchaUbicacion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPerchaUbicacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPerchaUbicacion.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPerchaUbicacion.Location = new System.Drawing.Point(21, 51);
            this.txtPerchaUbicacion.Name = "txtPerchaUbicacion";
            this.txtPerchaUbicacion.PlaceholderText = "Ej. Zona A / Pasillo 3";
            this.txtPerchaUbicacion.SelectedText = "";
            this.txtPerchaUbicacion.Size = new System.Drawing.Size(304, 29);
            this.txtPerchaUbicacion.TabIndex = 2;
            // 
            // lblPerchaUbicacion
            // 
            this.lblPerchaUbicacion.AutoSize = true;
            this.lblPerchaUbicacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPerchaUbicacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(105)))), ((int)(((byte)(117)))));
            this.lblPerchaUbicacion.Location = new System.Drawing.Point(18, 33);
            this.lblPerchaUbicacion.Name = "lblPerchaUbicacion";
            this.lblPerchaUbicacion.Size = new System.Drawing.Size(129, 15);
            this.lblPerchaUbicacion.TabIndex = 1;
            this.lblPerchaUbicacion.Text = "Ubicación / unidad de negocio";
            // 
            // lblPerchaHint
            // 
            this.lblPerchaHint.AutoSize = true;
            this.lblPerchaHint.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPerchaHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(129)))), ((int)(((byte)(149)))));
            this.lblPerchaHint.Location = new System.Drawing.Point(18, 18);
            this.lblPerchaHint.Name = "lblPerchaHint";
            this.lblPerchaHint.Size = new System.Drawing.Size(224, 15);
            this.lblPerchaHint.TabIndex = 0;
            this.lblPerchaHint.Text = "Organiza las perchas activas del producto";
            // 
            // lblPerchaTitle
            // 
            this.lblPerchaTitle.AutoSize = true;
            this.lblPerchaTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPerchaTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblPerchaTitle.Location = new System.Drawing.Point(17, 0);
            this.lblPerchaTitle.Name = "lblPerchaTitle";
            this.lblPerchaTitle.Size = new System.Drawing.Size(164, 20);
            this.lblPerchaTitle.TabIndex = 0;
            this.lblPerchaTitle.Text = "Asignación de perchas";
            // 
            // panelBandejaCard
            // 
            this.panelBandejaCard.BackColor = System.Drawing.Color.White;
            this.panelBandejaCard.BorderRadius = 10;
            this.panelBandejaCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBandejaCard.FillColor = System.Drawing.Color.White;
            this.panelBandejaCard.Location = new System.Drawing.Point(486, 3);
            this.panelBandejaCard.Name = "panelBandejaCard";
            this.panelBandejaCard.Padding = new System.Windows.Forms.Padding(18);
            this.panelBandejaCard.ShadowDecoration.Enabled = true;
            this.panelBandejaCard.Size = new System.Drawing.Size(477, 142);
            this.panelBandejaCard.TabIndex = 1;
            this.panelBandejaCard.Controls.Add(this.btnGuardarBandeja);
            this.panelBandejaCard.Controls.Add(this.numBandejaCapacidad);
            this.panelBandejaCard.Controls.Add(this.lblBandejaCapacidad);
            this.panelBandejaCard.Controls.Add(this.cboBandejaSeccion);
            this.panelBandejaCard.Controls.Add(this.lblBandejaSeccion);
            this.panelBandejaCard.Controls.Add(this.txtBandejaCodigo);
            this.panelBandejaCard.Controls.Add(this.lblBandejaCodigo);
            this.panelBandejaCard.Controls.Add(this.lblBandejaHint);
            this.panelBandejaCard.Controls.Add(this.lblBandejaTitle);
            // 
            // btnGuardarBandeja
            // 
            this.btnGuardarBandeja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardarBandeja.BorderRadius = 6;
            this.btnGuardarBandeja.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))));
            this.btnGuardarBandeja.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardarBandeja.ForeColor = System.Drawing.Color.White;
            this.btnGuardarBandeja.Location = new System.Drawing.Point(341, 101);
            this.btnGuardarBandeja.Name = "btnGuardarBandeja";
            this.btnGuardarBandeja.Size = new System.Drawing.Size(120, 32);
            this.btnGuardarBandeja.TabIndex = 7;
            this.btnGuardarBandeja.Text = "Guardar";
            // 
            // numBandejaCapacidad
            // 
            this.numBandejaCapacidad.BackColor = System.Drawing.Color.Transparent;
            this.numBandejaCapacidad.BorderRadius = 6;
            this.numBandejaCapacidad.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numBandejaCapacidad.DecimalPlaces = 0;
            this.numBandejaCapacidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numBandejaCapacidad.Location = new System.Drawing.Point(237, 104);
            this.numBandejaCapacidad.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numBandejaCapacidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBandejaCapacidad.Name = "numBandejaCapacidad";
            this.numBandejaCapacidad.Size = new System.Drawing.Size(98, 29);
            this.numBandejaCapacidad.TabIndex = 6;
            this.numBandejaCapacidad.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))));
            this.numBandejaCapacidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblBandejaCapacidad
            // 
            this.lblBandejaCapacidad.AutoSize = true;
            this.lblBandejaCapacidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBandejaCapacidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(105)))), ((int)(((byte)(117)))));
            this.lblBandejaCapacidad.Location = new System.Drawing.Point(234, 86);
            this.lblBandejaCapacidad.Name = "lblBandejaCapacidad";
            this.lblBandejaCapacidad.Size = new System.Drawing.Size(139, 15);
            this.lblBandejaCapacidad.TabIndex = 5;
            this.lblBandejaCapacidad.Text = "Capacidad (unidades)";
            // 
            // cboBandejaSeccion
            // 
            this.cboBandejaSeccion.BackColor = System.Drawing.Color.Transparent;
            this.cboBandejaSeccion.BorderRadius = 6;
            this.cboBandejaSeccion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboBandejaSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBandejaSeccion.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboBandejaSeccion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboBandejaSeccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboBandejaSeccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboBandejaSeccion.ItemHeight = 26;
            this.cboBandejaSeccion.Items.AddRange(new object[] {
            "Almacén",
            "Exhibición",
            "Anaquel"});
            this.cboBandejaSeccion.Location = new System.Drawing.Point(21, 101);
            this.cboBandejaSeccion.Name = "cboBandejaSeccion";
            this.cboBandejaSeccion.Size = new System.Drawing.Size(190, 32);
            this.cboBandejaSeccion.TabIndex = 4;
            // 
            // lblBandejaSeccion
            // 
            this.lblBandejaSeccion.AutoSize = true;
            this.lblBandejaSeccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBandejaSeccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(105)))), ((int)(((byte)(117)))));
            this.lblBandejaSeccion.Location = new System.Drawing.Point(18, 86);
            this.lblBandejaSeccion.Name = "lblBandejaSeccion";
            this.lblBandejaSeccion.Size = new System.Drawing.Size(90, 15);
            this.lblBandejaSeccion.TabIndex = 3;
            this.lblBandejaSeccion.Text = "Sección destino";
            // 
            // txtBandejaCodigo
            // 
            this.txtBandejaCodigo.BorderRadius = 6;
            this.txtBandejaCodigo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBandejaCodigo.DefaultText = "";
            this.txtBandejaCodigo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBandejaCodigo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBandejaCodigo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBandejaCodigo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBandejaCodigo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBandejaCodigo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBandejaCodigo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBandejaCodigo.Location = new System.Drawing.Point(21, 51);
            this.txtBandejaCodigo.Name = "txtBandejaCodigo";
            this.txtBandejaCodigo.PlaceholderText = "Código o identificador";
            this.txtBandejaCodigo.SelectedText = "";
            this.txtBandejaCodigo.Size = new System.Drawing.Size(304, 29);
            this.txtBandejaCodigo.TabIndex = 2;
            // 
            // lblBandejaCodigo
            // 
            this.lblBandejaCodigo.AutoSize = true;
            this.lblBandejaCodigo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBandejaCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(105)))), ((int)(((byte)(117)))));
            this.lblBandejaCodigo.Location = new System.Drawing.Point(18, 33);
            this.lblBandejaCodigo.Name = "lblBandejaCodigo";
            this.lblBandejaCodigo.Size = new System.Drawing.Size(143, 15);
            this.lblBandejaCodigo.TabIndex = 1;
            this.lblBandejaCodigo.Text = "Código de bandeja / lote";
            // 
            // lblBandejaHint
            // 
            this.lblBandejaHint.AutoSize = true;
            this.lblBandejaHint.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBandejaHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(129)))), ((int)(((byte)(149)))));
            this.lblBandejaHint.Location = new System.Drawing.Point(18, 18);
            this.lblBandejaHint.Name = "lblBandejaHint";
            this.lblBandejaHint.Size = new System.Drawing.Size(274, 15);
            this.lblBandejaHint.TabIndex = 0;
            this.lblBandejaHint.Text = "Configura bandejas o bandejas especiales por lote";
            // 
            // lblBandejaTitle
            // 
            this.lblBandejaTitle.AutoSize = true;
            this.lblBandejaTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblBandejaTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblBandejaTitle.Location = new System.Drawing.Point(17, 0);
            this.lblBandejaTitle.Name = "lblBandejaTitle";
            this.lblBandejaTitle.Size = new System.Drawing.Size(169, 20);
            this.lblBandejaTitle.TabIndex = 0;
            this.lblBandejaTitle.Text = "Perchas y bandejas";
            // 
            // tabStock
            // 
            this.tabStock.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabStock.Controls.Add(this.tableLayoutStock);
            this.tabStock.Location = new System.Drawing.Point(4, 44);
            this.tabStock.Name = "tabStock";
            this.tabStock.Padding = new System.Windows.Forms.Padding(12);
            this.tabStock.Size = new System.Drawing.Size(990, 172);
            this.tabStock.TabIndex = 3;
            this.tabStock.Text = "STOCK";
            this.tabStock.UseVisualStyleBackColor = false;
            // 
            // tableLayoutStock
            // 
            this.tableLayoutStock.ColumnCount = 1;
            this.tableLayoutStock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutStock.Controls.Add(this.flowStockCards, 0, 0);
            this.tableLayoutStock.Controls.Add(this.dgvStockMovimientos, 0, 1);
            this.tableLayoutStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutStock.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutStock.Name = "tableLayoutStock";
            this.tableLayoutStock.RowCount = 2;
            this.tableLayoutStock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutStock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutStock.Size = new System.Drawing.Size(966, 148);
            this.tableLayoutStock.TabIndex = 0;
            // 
            // flowStockCards
            // 
            this.flowStockCards.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowStockCards.Controls.Add(this.cardStockActual);
            this.flowStockCards.Controls.Add(this.cardStockMin);
            this.flowStockCards.Controls.Add(this.cardStockMax);
            this.flowStockCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowStockCards.Location = new System.Drawing.Point(3, 3);
            this.flowStockCards.Name = "flowStockCards";
            this.flowStockCards.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.flowStockCards.WrapContents = false;
            this.flowStockCards.Size = new System.Drawing.Size(960, 84);
            this.flowStockCards.TabIndex = 0;
            // 
            // cardStockActual
            // 
            this.cardStockActual.BackColor = System.Drawing.Color.White;
            this.cardStockActual.BorderRadius = 10;
            this.cardStockActual.FillColor = System.Drawing.Color.White;
            this.cardStockActual.Location = new System.Drawing.Point(0, 0);
            this.cardStockActual.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.cardStockActual.Name = "cardStockActual";
            this.cardStockActual.Padding = new System.Windows.Forms.Padding(16);
            this.cardStockActual.ShadowDecoration.Enabled = true;
            this.cardStockActual.Size = new System.Drawing.Size(190, 80);
            this.cardStockActual.TabIndex = 0;
            this.cardStockActual.Controls.Add(this.lblStockActualValue);
            this.cardStockActual.Controls.Add(this.lblStockActualTitle);
            // 
            // lblStockActualValue
            // 
            this.lblStockActualValue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStockActualValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblStockActualValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblStockActualValue.Location = new System.Drawing.Point(16, 32);
            this.lblStockActualValue.Name = "lblStockActualValue";
            this.lblStockActualValue.Size = new System.Drawing.Size(158, 32);
            this.lblStockActualValue.TabIndex = 1;
            this.lblStockActualValue.Text = "0";
            this.lblStockActualValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStockActualTitle
            // 
            this.lblStockActualTitle.AutoSize = true;
            this.lblStockActualTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStockActualTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(105)))), ((int)(((byte)(117)))));
            this.lblStockActualTitle.Location = new System.Drawing.Point(13, 12);
            this.lblStockActualTitle.Name = "lblStockActualTitle";
            this.lblStockActualTitle.Size = new System.Drawing.Size(80, 15);
            this.lblStockActualTitle.TabIndex = 0;
            this.lblStockActualTitle.Text = "STOCK ACTUAL";
            // 
            // cardStockMin
            // 
            this.cardStockMin.BackColor = System.Drawing.Color.White;
            this.cardStockMin.BorderRadius = 10;
            this.cardStockMin.FillColor = System.Drawing.Color.White;
            this.cardStockMin.Location = new System.Drawing.Point(205, 0);
            this.cardStockMin.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.cardStockMin.Name = "cardStockMin";
            this.cardStockMin.Padding = new System.Windows.Forms.Padding(16);
            this.cardStockMin.ShadowDecoration.Enabled = true;
            this.cardStockMin.Size = new System.Drawing.Size(190, 80);
            this.cardStockMin.TabIndex = 1;
            this.cardStockMin.Controls.Add(this.lblStockMinValue);
            this.cardStockMin.Controls.Add(this.lblStockMinTitle);
            // 
            // lblStockMinValue
            // 
            this.lblStockMinValue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStockMinValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblStockMinValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(130)))), ((int)(((byte)(12)))));
            this.lblStockMinValue.Location = new System.Drawing.Point(16, 32);
            this.lblStockMinValue.Name = "lblStockMinValue";
            this.lblStockMinValue.Size = new System.Drawing.Size(158, 32);
            this.lblStockMinValue.TabIndex = 1;
            this.lblStockMinValue.Text = "0";
            this.lblStockMinValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStockMinTitle
            // 
            this.lblStockMinTitle.AutoSize = true;
            this.lblStockMinTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStockMinTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(105)))), ((int)(((byte)(117)))));
            this.lblStockMinTitle.Location = new System.Drawing.Point(13, 12);
            this.lblStockMinTitle.Name = "lblStockMinTitle";
            this.lblStockMinTitle.Size = new System.Drawing.Size(85, 15);
            this.lblStockMinTitle.TabIndex = 0;
            this.lblStockMinTitle.Text = "STOCK MÍNIMO";
            // 
            // cardStockMax
            // 
            this.cardStockMax.BackColor = System.Drawing.Color.White;
            this.cardStockMax.BorderRadius = 10;
            this.cardStockMax.FillColor = System.Drawing.Color.White;
            this.cardStockMax.Location = new System.Drawing.Point(410, 0);
            this.cardStockMax.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.cardStockMax.Name = "cardStockMax";
            this.cardStockMax.Padding = new System.Windows.Forms.Padding(16);
            this.cardStockMax.ShadowDecoration.Enabled = true;
            this.cardStockMax.Size = new System.Drawing.Size(190, 80);
            this.cardStockMax.TabIndex = 2;
            this.cardStockMax.Controls.Add(this.lblStockMaxValue);
            this.cardStockMax.Controls.Add(this.lblStockMaxTitle);
            // 
            // lblStockMaxValue
            // 
            this.lblStockMaxValue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStockMaxValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblStockMaxValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblStockMaxValue.Location = new System.Drawing.Point(16, 32);
            this.lblStockMaxValue.Name = "lblStockMaxValue";
            this.lblStockMaxValue.Size = new System.Drawing.Size(158, 32);
            this.lblStockMaxValue.TabIndex = 1;
            this.lblStockMaxValue.Text = "0";
            this.lblStockMaxValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStockMaxTitle
            // 
            this.lblStockMaxTitle.AutoSize = true;
            this.lblStockMaxTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStockMaxTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(105)))), ((int)(((byte)(117)))));
            this.lblStockMaxTitle.Location = new System.Drawing.Point(13, 12);
            this.lblStockMaxTitle.Name = "lblStockMaxTitle";
            this.lblStockMaxTitle.Size = new System.Drawing.Size(90, 15);
            this.lblStockMaxTitle.TabIndex = 0;
            this.lblStockMaxTitle.Text = "STOCK MÁXIMO";
            // 
            // dgvStockMovimientos
            // 
            this.dgvStockMovimientos.AllowUserToAddRows = false;
            this.dgvStockMovimientos.AllowUserToDeleteRows = false;
            this.dgvStockMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStockMovimientos.BackgroundColor = System.Drawing.Color.White;
            this.dgvStockMovimientos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStockMovimientos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.dgvStockMovimientos.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvStockMovimientos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStockMovimientos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvStockMovimientos.Location = new System.Drawing.Point(3, 93);
            this.dgvStockMovimientos.Name = "dgvStockMovimientos";
            this.dgvStockMovimientos.RowHeadersVisible = false;
            this.dgvStockMovimientos.RowTemplate.Height = 32;
            this.dgvStockMovimientos.Size = new System.Drawing.Size(960, 52);
            this.dgvStockMovimientos.TabIndex = 1;
            this.dgvStockMovimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStockFecha,
            this.colStockTipo,
            this.colStockCantidad,
            this.colStockSaldo});
            this.dgvStockMovimientos.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvStockMovimientos.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvStockMovimientos.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvStockMovimientos.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvStockMovimientos.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvStockMovimientos.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvStockMovimientos.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dgvStockMovimientos.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvStockMovimientos.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvStockMovimientos.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvStockMovimientos.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.dgvStockMovimientos.ThemeStyle.RowsStyle.Height = 32;
            this.dgvStockMovimientos.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.dgvStockMovimientos.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // colStockFecha
            // 
            this.colStockFecha.HeaderText = "FECHA";
            this.colStockFecha.Name = "colStockFecha";
            // 
            // colStockTipo
            // 
            this.colStockTipo.HeaderText = "MOVIMIENTO";
            this.colStockTipo.Name = "colStockTipo";
            // 
            // colStockCantidad
            // 
            this.colStockCantidad.HeaderText = "CANTIDAD";
            this.colStockCantidad.Name = "colStockCantidad";
            // 
            // colStockSaldo
            // 
            this.colStockSaldo.HeaderText = "SALDO";
            this.colStockSaldo.Name = "colStockSaldo";
            // 
            // tabCaducidad
            // 
            this.tabCaducidad.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabCaducidad.Controls.Add(this.tableLayoutCaducidad);
            this.tabCaducidad.Location = new System.Drawing.Point(4, 44);
            this.tabCaducidad.Name = "tabCaducidad";
            this.tabCaducidad.Padding = new System.Windows.Forms.Padding(12);
            this.tabCaducidad.Size = new System.Drawing.Size(990, 172);
            this.tabCaducidad.TabIndex = 4;
            this.tabCaducidad.Text = "CADUCIDAD";
            this.tabCaducidad.UseVisualStyleBackColor = false;
            // 
            // tableLayoutCaducidad
            // 
            this.tableLayoutCaducidad.ColumnCount = 1;
            this.tableLayoutCaducidad.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutCaducidad.Controls.Add(this.panelCaducidadFiltro, 0, 0);
            this.tableLayoutCaducidad.Controls.Add(this.dgvCaducidades, 0, 1);
            this.tableLayoutCaducidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutCaducidad.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutCaducidad.Name = "tableLayoutCaducidad";
            this.tableLayoutCaducidad.RowCount = 2;
            this.tableLayoutCaducidad.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutCaducidad.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutCaducidad.Size = new System.Drawing.Size(966, 148);
            this.tableLayoutCaducidad.TabIndex = 0;
            // 
            // panelCaducidadFiltro
            // 
            this.panelCaducidadFiltro.BorderRadius = 10;
            this.panelCaducidadFiltro.Controls.Add(this.btnAgregarLote);
            this.panelCaducidadFiltro.Controls.Add(this.btnFiltrarCaducidad);
            this.panelCaducidadFiltro.Controls.Add(this.dtpCaducidadHasta);
            this.panelCaducidadFiltro.Controls.Add(this.lblCaducidadHasta);
            this.panelCaducidadFiltro.Controls.Add(this.dtpCaducidadDesde);
            this.panelCaducidadFiltro.Controls.Add(this.lblCaducidadDesde);
            this.panelCaducidadFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCaducidadFiltro.FillColor = System.Drawing.Color.White;
            this.panelCaducidadFiltro.Location = new System.Drawing.Point(3, 3);
            this.panelCaducidadFiltro.Name = "panelCaducidadFiltro";
            this.panelCaducidadFiltro.Padding = new System.Windows.Forms.Padding(18);
            this.panelCaducidadFiltro.ShadowDecoration.Enabled = true;
            this.panelCaducidadFiltro.Size = new System.Drawing.Size(960, 66);
            this.panelCaducidadFiltro.TabIndex = 0;
            // 
            // btnAgregarLote
            // 
            this.btnAgregarLote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarLote.BorderRadius = 6;
            this.btnAgregarLote.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAgregarLote.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarLote.ForeColor = System.Drawing.Color.White;
            this.btnAgregarLote.Location = new System.Drawing.Point(826, 16);
            this.btnAgregarLote.Name = "btnAgregarLote";
            this.btnAgregarLote.Size = new System.Drawing.Size(118, 32);
            this.btnAgregarLote.TabIndex = 5;
            this.btnAgregarLote.Text = "+ Agregar lote";
            // 
            // btnFiltrarCaducidad
            // 
            this.btnFiltrarCaducidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFiltrarCaducidad.BorderRadius = 6;
            this.btnFiltrarCaducidad.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))));
            this.btnFiltrarCaducidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltrarCaducidad.ForeColor = System.Drawing.Color.White;
            this.btnFiltrarCaducidad.Location = new System.Drawing.Point(702, 16);
            this.btnFiltrarCaducidad.Name = "btnFiltrarCaducidad";
            this.btnFiltrarCaducidad.Size = new System.Drawing.Size(118, 32);
            this.btnFiltrarCaducidad.TabIndex = 4;
            this.btnFiltrarCaducidad.Text = "Filtrar";
            // 
            // dtpCaducidadHasta
            // 
            this.dtpCaducidadHasta.BorderRadius = 6;
            this.dtpCaducidadHasta.Checked = true;
            this.dtpCaducidadHasta.FillColor = System.Drawing.Color.White;
            this.dtpCaducidadHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpCaducidadHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCaducidadHasta.Location = new System.Drawing.Point(352, 30);
            this.dtpCaducidadHasta.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpCaducidadHasta.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpCaducidadHasta.Name = "dtpCaducidadHasta";
            this.dtpCaducidadHasta.Size = new System.Drawing.Size(160, 24);
            this.dtpCaducidadHasta.TabIndex = 3;
            this.dtpCaducidadHasta.Value = System.DateTime.Today;
            // 
            // lblCaducidadHasta
            // 
            this.lblCaducidadHasta.AutoSize = true;
            this.lblCaducidadHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCaducidadHasta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(105)))), ((int)(((byte)(117)))));
            this.lblCaducidadHasta.Location = new System.Drawing.Point(349, 12);
            this.lblCaducidadHasta.Name = "lblCaducidadHasta";
            this.lblCaducidadHasta.Size = new System.Drawing.Size(118, 15);
            this.lblCaducidadHasta.TabIndex = 2;
            this.lblCaducidadHasta.Text = "Caducan hasta el día";
            // 
            // dtpCaducidadDesde
            // 
            this.dtpCaducidadDesde.BorderRadius = 6;
            this.dtpCaducidadDesde.Checked = true;
            this.dtpCaducidadDesde.FillColor = System.Drawing.Color.White;
            this.dtpCaducidadDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpCaducidadDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCaducidadDesde.Location = new System.Drawing.Point(21, 30);
            this.dtpCaducidadDesde.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpCaducidadDesde.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpCaducidadDesde.Name = "dtpCaducidadDesde";
            this.dtpCaducidadDesde.Size = new System.Drawing.Size(160, 24);
            this.dtpCaducidadDesde.TabIndex = 1;
            this.dtpCaducidadDesde.Value = System.DateTime.Today;
            // 
            // lblCaducidadDesde
            // 
            this.lblCaducidadDesde.AutoSize = true;
            this.lblCaducidadDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCaducidadDesde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(105)))), ((int)(((byte)(117)))));
            this.lblCaducidadDesde.Location = new System.Drawing.Point(18, 12);
            this.lblCaducidadDesde.Name = "lblCaducidadDesde";
            this.lblCaducidadDesde.Size = new System.Drawing.Size(133, 15);
            this.lblCaducidadDesde.TabIndex = 0;
            this.lblCaducidadDesde.Text = "Caducan a partir del día";
            // 
            // dgvCaducidades
            // 
            this.dgvCaducidades.AllowUserToAddRows = false;
            this.dgvCaducidades.AllowUserToDeleteRows = false;
            this.dgvCaducidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCaducidades.BackgroundColor = System.Drawing.Color.White;
            this.dgvCaducidades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCaducidades.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.dgvCaducidades.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCaducidades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCaducidades.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvCaducidades.Location = new System.Drawing.Point(3, 75);
            this.dgvCaducidades.Name = "dgvCaducidades";
            this.dgvCaducidades.RowHeadersVisible = false;
            this.dgvCaducidades.RowTemplate.Height = 32;
            this.dgvCaducidades.Size = new System.Drawing.Size(960, 70);
            this.dgvCaducidades.TabIndex = 1;
            this.dgvCaducidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCaducidadLote,
            this.colCaducidadFecha,
            this.colCaducidadCantidad,
            this.colCaducidadEstado});
            this.dgvCaducidades.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCaducidades.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCaducidades.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvCaducidades.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCaducidades.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCaducidades.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvCaducidades.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dgvCaducidades.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCaducidades.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCaducidades.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvCaducidades.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.dgvCaducidades.ThemeStyle.RowsStyle.Height = 32;
            this.dgvCaducidades.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.dgvCaducidades.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            // 
            // colCaducidadLote
            // 
            this.colCaducidadLote.HeaderText = "LOTE";
            this.colCaducidadLote.Name = "colCaducidadLote";
            // 
            // colCaducidadFecha
            // 
            this.colCaducidadFecha.HeaderText = "FECHA CADUCIDAD";
            this.colCaducidadFecha.Name = "colCaducidadFecha";
            // 
            // colCaducidadCantidad
            // 
            this.colCaducidadCantidad.HeaderText = "CANTIDAD";
            this.colCaducidadCantidad.Name = "colCaducidadCantidad";
            // 
            // colCaducidadEstado
            // 
            this.colCaducidadEstado.HeaderText = "ESTADO";
            this.colCaducidadEstado.Name = "colCaducidadEstado";
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
            this.tabPerchas.ResumeLayout(false);
            this.tableLayoutPerchas.ResumeLayout(false);
            this.panelPerchaCard.ResumeLayout(false);
            this.panelPerchaCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPerchaNivel)).EndInit();
            this.panelBandejaCard.ResumeLayout(false);
            this.panelBandejaCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBandejaCapacidad)).EndInit();
            this.tabStock.ResumeLayout(false);
            this.tableLayoutStock.ResumeLayout(false);
            this.flowStockCards.ResumeLayout(false);
            this.cardStockActual.ResumeLayout(false);
            this.cardStockActual.PerformLayout();
            this.cardStockMin.ResumeLayout(false);
            this.cardStockMin.PerformLayout();
            this.cardStockMax.ResumeLayout(false);
            this.cardStockMax.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockMovimientos)).EndInit();
            this.tabCaducidad.ResumeLayout(false);
            this.tableLayoutCaducidad.ResumeLayout(false);
            this.panelCaducidadFiltro.ResumeLayout(false);
            this.panelCaducidadFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaducidades)).EndInit();
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
        private System.Windows.Forms.TabPage tabPerchas;
        private System.Windows.Forms.TabPage tabStock;
        private System.Windows.Forms.TabPage tabCaducidad;
        private Guna.UI2.WinForms.Guna2DataGridView dgvImpuestos;
        private System.Windows.Forms.DataGridViewComboBoxColumn colImpuesto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAplicaCompra;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAplicaVenta;
        // --- INICIO: NUEVAS DECLARACIONES PARA PESTAÑA PRECIOS ---
        private Guna.UI2.WinForms.Guna2Panel panelPreciosWrapper;
        private System.Windows.Forms.Label lblPreciosHint;
        private System.Windows.Forms.Label lblPreciosTitle;
        private Guna.UI2.WinForms.Guna2Button btnAgregarPrecio;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvPrecios;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidadNegocio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostoUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostoCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostoPonderadoUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostoPonderadoCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPvpUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPvp;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPerchas;
        private Guna.UI2.WinForms.Guna2Panel panelPerchaCard;
        private System.Windows.Forms.Label lblPerchaTitle;
        private System.Windows.Forms.Label lblPerchaHint;
        private System.Windows.Forms.Label lblPerchaUbicacion;
        private Guna.UI2.WinForms.Guna2TextBox txtPerchaUbicacion;
        private System.Windows.Forms.Label lblPerchaNivel;
        private Guna.UI2.WinForms.Guna2NumericUpDown numPerchaNivel;
        private System.Windows.Forms.Label lblPerchaReferencia;
        private Guna.UI2.WinForms.Guna2TextBox txtPerchaReferencia;
        private Guna.UI2.WinForms.Guna2Button btnGuardarPercha;
        private Guna.UI2.WinForms.Guna2Panel panelBandejaCard;
        private System.Windows.Forms.Label lblBandejaTitle;
        private System.Windows.Forms.Label lblBandejaHint;
        private System.Windows.Forms.Label lblBandejaCodigo;
        private Guna.UI2.WinForms.Guna2TextBox txtBandejaCodigo;
        private System.Windows.Forms.Label lblBandejaSeccion;
        private Guna.UI2.WinForms.Guna2ComboBox cboBandejaSeccion;
        private System.Windows.Forms.Label lblBandejaCapacidad;
        private Guna.UI2.WinForms.Guna2NumericUpDown numBandejaCapacidad;
        private Guna.UI2.WinForms.Guna2Button btnGuardarBandeja;
        private System.Windows.Forms.TableLayoutPanel tableLayoutStock;
        private System.Windows.Forms.FlowLayoutPanel flowStockCards;
        private Guna.UI2.WinForms.Guna2Panel cardStockActual;
        private System.Windows.Forms.Label lblStockActualValue;
        private System.Windows.Forms.Label lblStockActualTitle;
        private Guna.UI2.WinForms.Guna2Panel cardStockMin;
        private System.Windows.Forms.Label lblStockMinValue;
        private System.Windows.Forms.Label lblStockMinTitle;
        private Guna.UI2.WinForms.Guna2Panel cardStockMax;
        private System.Windows.Forms.Label lblStockMaxValue;
        private System.Windows.Forms.Label lblStockMaxTitle;
        private Guna.UI2.WinForms.Guna2DataGridView dgvStockMovimientos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockSaldo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutCaducidad;
        private Guna.UI2.WinForms.Guna2Panel panelCaducidadFiltro;
        private System.Windows.Forms.Label lblCaducidadDesde;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpCaducidadDesde;
        private System.Windows.Forms.Label lblCaducidadHasta;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpCaducidadHasta;
        private Guna.UI2.WinForms.Guna2Button btnFiltrarCaducidad;
        private Guna.UI2.WinForms.Guna2Button btnAgregarLote;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCaducidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCaducidadLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCaducidadFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCaducidadCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCaducidadEstado;
    }
}
