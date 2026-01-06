namespace LogiPharm.Presentacion
{
    partial class FrmFacturacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelFiltros = new Guna.UI2.WinForms.Guna2Panel();
            this.btnBuscar = new Guna.UI2.WinForms.Guna2Button();
            this.dtpFechaFin = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCliente = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumero = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboCajero = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboEstadoSRI = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboEstado = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTipoDocumento = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCaja = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblCaja = new System.Windows.Forms.Label();
            this.panelLista = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvListaFacturas = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClaveAcceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAutorizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotalDocumentos = new System.Windows.Forms.Label();
            this.panelDetalle = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvDetalleFactura = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblAutorizacion = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblCajaDetalle = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblCajeroDetalle = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblAmbiente = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblCedula = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblEstadoSRI = new System.Windows.Forms.Label();
            this.lblFechaAutorizacion = new System.Windows.Forms.Label();
            this.lblNoInterno = new System.Windows.Forms.Label();
            this.lblNumeroFactura = new System.Windows.Forms.Label();
            this.btnReenviarSRI = new Guna.UI2.WinForms.Guna2Button();
            this.panelFiltros.SuspendLayout();
            this.panelLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaFacturas)).BeginInit();
            this.panelDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.White;
            this.panelFiltros.BorderColor = System.Drawing.Color.LightGray;
            this.panelFiltros.BorderThickness = 1;
            this.panelFiltros.Controls.Add(this.btnBuscar);
            this.panelFiltros.Controls.Add(this.dtpFechaFin);
            this.panelFiltros.Controls.Add(this.label8);
            this.panelFiltros.Controls.Add(this.dtpFechaInicio);
            this.panelFiltros.Controls.Add(this.label7);
            this.panelFiltros.Controls.Add(this.txtCliente);
            this.panelFiltros.Controls.Add(this.label6);
            this.panelFiltros.Controls.Add(this.txtNumero);
            this.panelFiltros.Controls.Add(this.label5);
            this.panelFiltros.Controls.Add(this.cboCajero);
            this.panelFiltros.Controls.Add(this.label4);
            this.panelFiltros.Controls.Add(this.cboEstadoSRI);
            this.panelFiltros.Controls.Add(this.label3);
            this.panelFiltros.Controls.Add(this.cboEstado);
            this.panelFiltros.Controls.Add(this.label2);
            this.panelFiltros.Controls.Add(this.cboTipoDocumento);
            this.panelFiltros.Controls.Add(this.label1);
            this.panelFiltros.Controls.Add(this.cboCaja);
            this.panelFiltros.Controls.Add(this.lblCaja);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Location = new System.Drawing.Point(0, 0);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(1270, 80);
            this.panelFiltros.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BorderRadius = 6;
            this.btnBuscar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBuscar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBuscar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBuscar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(1166, 41);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(107, 28);
            this.btnBuscar.TabIndex = 17;
            this.btnBuscar.Text = "F3 - Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.BorderRadius = 4;
            this.dtpFechaFin.Checked = true;
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(1050, 41);
            this.dtpFechaFin.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFechaFin.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(110, 28);
            this.dtpFechaFin.TabIndex = 16;
            this.dtpFechaFin.Value = new System.DateTime(2025, 4, 25, 0, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1047, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Fecha Fin:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.BorderRadius = 4;
            this.dtpFechaInicio.Checked = true;
            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(934, 41);
            this.dtpFechaInicio.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFechaInicio.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(110, 28);
            this.dtpFechaInicio.TabIndex = 14;
            this.dtpFechaInicio.Value = new System.DateTime(2025, 4, 25, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(931, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Fecha Inicio:";
            // 
            // txtCliente
            // 
            this.txtCliente.BorderRadius = 4;
            this.txtCliente.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCliente.DefaultText = "";
            this.txtCliente.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCliente.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCliente.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCliente.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCliente.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCliente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCliente.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCliente.Location = new System.Drawing.Point(808, 41);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.PlaceholderText = "";
            this.txtCliente.SelectedText = "";
            this.txtCliente.Size = new System.Drawing.Size(120, 28);
            this.txtCliente.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(805, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Cliente:";
            // 
            // txtNumero
            // 
            this.txtNumero.BorderRadius = 4;
            this.txtNumero.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNumero.DefaultText = "";
            this.txtNumero.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNumero.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNumero.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNumero.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNumero.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNumero.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNumero.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNumero.Location = new System.Drawing.Point(672, 41);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.PlaceholderText = "";
            this.txtNumero.SelectedText = "";
            this.txtNumero.Size = new System.Drawing.Size(130, 28);
            this.txtNumero.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(669, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Número:";
            // 
            // cboCajero
            // 
            this.cboCajero.BackColor = System.Drawing.Color.Transparent;
            this.cboCajero.BorderRadius = 4;
            this.cboCajero.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCajero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCajero.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboCajero.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboCajero.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCajero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboCajero.ItemHeight = 22;
            this.cboCajero.Items.AddRange(new object[] {
            "TODOS"});
            this.cboCajero.Location = new System.Drawing.Point(546, 41);
            this.cboCajero.Name = "cboCajero";
            this.cboCajero.Size = new System.Drawing.Size(120, 28);
            this.cboCajero.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(543, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cajero:";
            // 
            // cboEstadoSRI
            // 
            this.cboEstadoSRI.BackColor = System.Drawing.Color.Transparent;
            this.cboEstadoSRI.BorderRadius = 4;
            this.cboEstadoSRI.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboEstadoSRI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoSRI.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboEstadoSRI.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboEstadoSRI.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboEstadoSRI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboEstadoSRI.ItemHeight = 22;
            this.cboEstadoSRI.Items.AddRange(new object[] {
            "Todos"});
            this.cboEstadoSRI.Location = new System.Drawing.Point(400, 41);
            this.cboEstadoSRI.Name = "cboEstadoSRI";
            this.cboEstadoSRI.Size = new System.Drawing.Size(140, 28);
            this.cboEstadoSRI.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(397, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Estado SRI:";
            // 
            // cboEstado
            // 
            this.cboEstado.BackColor = System.Drawing.Color.Transparent;
            this.cboEstado.BorderRadius = 4;
            this.cboEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboEstado.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboEstado.ItemHeight = 22;
            this.cboEstado.Items.AddRange(new object[] {
            "Todas"});
            this.cboEstado.Location = new System.Drawing.Point(294, 41);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(100, 28);
            this.cboEstado.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Estado:";
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.BackColor = System.Drawing.Color.Transparent;
            this.cboTipoDocumento.BorderRadius = 4;
            this.cboTipoDocumento.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDocumento.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTipoDocumento.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTipoDocumento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTipoDocumento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboTipoDocumento.ItemHeight = 22;
            this.cboTipoDocumento.Items.AddRange(new object[] {
            "FACTURA"});
            this.cboTipoDocumento.Location = new System.Drawing.Point(138, 41);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Size = new System.Drawing.Size(150, 28);
            this.cboTipoDocumento.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo Documento:";
            // 
            // cboCaja
            // 
            this.cboCaja.BackColor = System.Drawing.Color.Transparent;
            this.cboCaja.BorderRadius = 4;
            this.cboCaja.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCaja.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboCaja.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboCaja.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCaja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboCaja.ItemHeight = 22;
            this.cboCaja.Items.AddRange(new object[] {
            "CAJA 001"});
            this.cboCaja.Location = new System.Drawing.Point(12, 41);
            this.cboCaja.Name = "cboCaja";
            this.cboCaja.Size = new System.Drawing.Size(120, 28);
            this.cboCaja.TabIndex = 0;
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.Location = new System.Drawing.Point(9, 25);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(31, 13);
            this.lblCaja.TabIndex = 0;
            this.lblCaja.Text = "Caja:";
            // 
            // panelLista
            // 
            this.panelLista.Controls.Add(this.dgvListaFacturas);
            this.panelLista.Controls.Add(this.lblTotalDocumentos);
            this.panelLista.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLista.Location = new System.Drawing.Point(0, 80);
            this.panelLista.Name = "panelLista";
            this.panelLista.Padding = new System.Windows.Forms.Padding(10, 0, 5, 10);
            this.panelLista.Size = new System.Drawing.Size(362, 541);
            this.panelLista.TabIndex = 1;
            // 
            // dgvListaFacturas
            // 
            this.dgvListaFacturas.AllowUserToAddRows = false;
            this.dgvListaFacturas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvListaFacturas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListaFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaFacturas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListaFacturas.ColumnHeadersHeight = 22;
            this.dgvListaFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvListaFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.colFactura,
            this.colCliente,
            this.colTotal,
            this.ClaveAcceso,
            this.colAutorizacion});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListaFacturas.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListaFacturas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListaFacturas.Location = new System.Drawing.Point(10, 26);
            this.dgvListaFacturas.Name = "dgvListaFacturas";
            this.dgvListaFacturas.ReadOnly = true;
            this.dgvListaFacturas.RowHeadersVisible = false;
            this.dgvListaFacturas.Size = new System.Drawing.Size(347, 505);
            this.dgvListaFacturas.TabIndex = 1;
            this.dgvListaFacturas.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListaFacturas.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvListaFacturas.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvListaFacturas.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvListaFacturas.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvListaFacturas.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvListaFacturas.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListaFacturas.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvListaFacturas.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvListaFacturas.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListaFacturas.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvListaFacturas.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvListaFacturas.ThemeStyle.HeaderStyle.Height = 22;
            this.dgvListaFacturas.ThemeStyle.ReadOnly = true;
            this.dgvListaFacturas.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListaFacturas.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvListaFacturas.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListaFacturas.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvListaFacturas.ThemeStyle.RowsStyle.Height = 22;
            this.dgvListaFacturas.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListaFacturas.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvListaFacturas.SelectionChanged += new System.EventHandler(this.dgvListaFacturas_SelectionChanged);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // colFactura
            // 
            this.colFactura.HeaderText = "Factura";
            this.colFactura.Name = "colFactura";
            this.colFactura.ReadOnly = true;
            // 
            // colCliente
            // 
            this.colCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.ReadOnly = true;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // ClaveAcceso
            // 
            this.ClaveAcceso.HeaderText = "ClaveAcceso";
            this.ClaveAcceso.Name = "ClaveAcceso";
            this.ClaveAcceso.ReadOnly = true;
            this.ClaveAcceso.Visible = false;
            // 
            // colAutorizacion
            // 
            this.colAutorizacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAutorizacion.HeaderText = "Autorización";
            this.colAutorizacion.Name = "colAutorizacion";
            this.colAutorizacion.ReadOnly = true;
            // 
            // lblTotalDocumentos
            // 
            this.lblTotalDocumentos.AutoSize = true;
            this.lblTotalDocumentos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDocumentos.Location = new System.Drawing.Point(12, 8);
            this.lblTotalDocumentos.Name = "lblTotalDocumentos";
            this.lblTotalDocumentos.Size = new System.Drawing.Size(138, 15);
            this.lblTotalDocumentos.TabIndex = 0;
            this.lblTotalDocumentos.Text = "Total de Documentos: 0";
            // 
            // panelDetalle
            // 
            this.panelDetalle.Controls.Add(this.dgvDetalleFactura);
            this.panelDetalle.Controls.Add(this.guna2GroupBox1);
            this.panelDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetalle.Location = new System.Drawing.Point(362, 80);
            this.panelDetalle.Name = "panelDetalle";
            this.panelDetalle.Padding = new System.Windows.Forms.Padding(5, 0, 10, 10);
            this.panelDetalle.Size = new System.Drawing.Size(908, 541);
            this.panelDetalle.TabIndex = 2;
            // 
            // dgvDetalleFactura
            // 
            this.dgvDetalleFactura.AllowUserToAddRows = false;
            this.dgvDetalleFactura.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvDetalleFactura.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetalleFactura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleFactura.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDetalleFactura.ColumnHeadersHeight = 22;
            this.dgvDetalleFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalleFactura.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDetalleFactura.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetalleFactura.Location = new System.Drawing.Point(5, 230);
            this.dgvDetalleFactura.Name = "dgvDetalleFactura";
            this.dgvDetalleFactura.ReadOnly = true;
            this.dgvDetalleFactura.RowHeadersVisible = false;
            this.dgvDetalleFactura.Size = new System.Drawing.Size(890, 301);
            this.dgvDetalleFactura.TabIndex = 1;
            this.dgvDetalleFactura.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetalleFactura.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDetalleFactura.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDetalleFactura.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDetalleFactura.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDetalleFactura.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetalleFactura.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetalleFactura.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvDetalleFactura.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDetalleFactura.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetalleFactura.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDetalleFactura.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDetalleFactura.ThemeStyle.HeaderStyle.Height = 22;
            this.dgvDetalleFactura.ThemeStyle.ReadOnly = true;
            this.dgvDetalleFactura.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetalleFactura.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDetalleFactura.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetalleFactura.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDetalleFactura.ThemeStyle.RowsStyle.Height = 22;
            this.dgvDetalleFactura.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetalleFactura.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.LightGray;
            this.guna2GroupBox1.BorderRadius = 6;
            this.guna2GroupBox1.Controls.Add(this.btnReenviarSRI);
            this.guna2GroupBox1.Controls.Add(this.lblAutorizacion);
            this.guna2GroupBox1.Controls.Add(this.label22);
            this.guna2GroupBox1.Controls.Add(this.lblCajaDetalle);
            this.guna2GroupBox1.Controls.Add(this.label20);
            this.guna2GroupBox1.Controls.Add(this.lblCajeroDetalle);
            this.guna2GroupBox1.Controls.Add(this.label18);
            this.guna2GroupBox1.Controls.Add(this.lblTipoDoc);
            this.guna2GroupBox1.Controls.Add(this.label16);
            this.guna2GroupBox1.Controls.Add(this.lblAmbiente);
            this.guna2GroupBox1.Controls.Add(this.label14);
            this.guna2GroupBox1.Controls.Add(this.lblFecha);
            this.guna2GroupBox1.Controls.Add(this.label11);
            this.guna2GroupBox1.Controls.Add(this.lblDireccion);
            this.guna2GroupBox1.Controls.Add(this.label13);
            this.guna2GroupBox1.Controls.Add(this.lblTelefono);
            this.guna2GroupBox1.Controls.Add(this.label17);
            this.guna2GroupBox1.Controls.Add(this.lblCliente);
            this.guna2GroupBox1.Controls.Add(this.label21);
            this.guna2GroupBox1.Controls.Add(this.lblCedula);
            this.guna2GroupBox1.Controls.Add(this.label23);
            this.guna2GroupBox1.Controls.Add(this.lblEstadoSRI);
            this.guna2GroupBox1.Controls.Add(this.lblFechaAutorizacion);
            this.guna2GroupBox1.Controls.Add(this.lblNoInterno);
            this.guna2GroupBox1.Controls.Add(this.lblNumeroFactura);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(5, 8);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(890, 216);
            this.guna2GroupBox1.TabIndex = 0;
            this.guna2GroupBox1.Text = "FACTURA ELECTRÓNICA";
            // 
            // lblAutorizacion
            // 
            this.lblAutorizacion.AutoSize = true;
            this.lblAutorizacion.BackColor = System.Drawing.Color.White;
            this.lblAutorizacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAutorizacion.Location = new System.Drawing.Point(92, 188);
            this.lblAutorizacion.Name = "lblAutorizacion";
            this.lblAutorizacion.Size = new System.Drawing.Size(16, 15);
            this.lblAutorizacion.TabIndex = 23;
            this.lblAutorizacion.Text = "...";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.White;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label22.Location = new System.Drawing.Point(14, 188);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(80, 15);
            this.label22.TabIndex = 22;
            this.label22.Text = "Autorización:";
            // 
            // lblCajaDetalle
            // 
            this.lblCajaDetalle.AutoSize = true;
            this.lblCajaDetalle.BackColor = System.Drawing.Color.White;
            this.lblCajaDetalle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCajaDetalle.Location = new System.Drawing.Point(825, 126);
            this.lblCajaDetalle.Name = "lblCajaDetalle";
            this.lblCajaDetalle.Size = new System.Drawing.Size(16, 15);
            this.lblCajaDetalle.TabIndex = 21;
            this.lblCajaDetalle.Text = "...";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.White;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label20.Location = new System.Drawing.Point(792, 126);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 15);
            this.label20.TabIndex = 20;
            this.label20.Text = "Caja:";
            // 
            // lblCajeroDetalle
            // 
            this.lblCajeroDetalle.AutoSize = true;
            this.lblCajeroDetalle.BackColor = System.Drawing.Color.White;
            this.lblCajeroDetalle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCajeroDetalle.Location = new System.Drawing.Point(623, 126);
            this.lblCajeroDetalle.Name = "lblCajeroDetalle";
            this.lblCajeroDetalle.Size = new System.Drawing.Size(16, 15);
            this.lblCajeroDetalle.TabIndex = 19;
            this.lblCajeroDetalle.Text = "...";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.White;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label18.Location = new System.Drawing.Point(577, 126);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(45, 15);
            this.label18.TabIndex = 18;
            this.label18.Text = "Cajero:";
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.BackColor = System.Drawing.Color.White;
            this.lblTipoDoc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTipoDoc.Location = new System.Drawing.Point(623, 157);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(16, 15);
            this.lblTipoDoc.TabIndex = 17;
            this.lblTipoDoc.Text = "...";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.White;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(577, 157);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 15);
            this.label16.TabIndex = 16;
            this.label16.Text = "Doc:";
            // 
            // lblAmbiente
            // 
            this.lblAmbiente.AutoSize = true;
            this.lblAmbiente.BackColor = System.Drawing.Color.White;
            this.lblAmbiente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAmbiente.Location = new System.Drawing.Point(359, 157);
            this.lblAmbiente.Name = "lblAmbiente";
            this.lblAmbiente.Size = new System.Drawing.Size(16, 15);
            this.lblAmbiente.TabIndex = 15;
            this.lblAmbiente.Text = "...";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(298, 157);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 15);
            this.label14.TabIndex = 14;
            this.label14.Text = "Ambiente:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.White;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFecha.Location = new System.Drawing.Point(92, 157);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(16, 15);
            this.lblFecha.TabIndex = 13;
            this.lblFecha.Text = "...";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(14, 157);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 15);
            this.label11.TabIndex = 12;
            this.label11.Text = "Fecha:";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.BackColor = System.Drawing.Color.White;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDireccion.Location = new System.Drawing.Point(92, 126);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(16, 15);
            this.lblDireccion.TabIndex = 11;
            this.lblDireccion.Text = "...";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(14, 126);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 15);
            this.label13.TabIndex = 10;
            this.label13.Text = "Dirección:";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.BackColor = System.Drawing.Color.White;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTelefono.Location = new System.Drawing.Point(825, 95);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(16, 15);
            this.lblTelefono.TabIndex = 9;
            this.lblTelefono.Text = "...";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.White;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label17.Location = new System.Drawing.Point(767, 95);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 15);
            this.label17.TabIndex = 8;
            this.label17.Text = "Teléfono:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.BackColor = System.Drawing.Color.White;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCliente.Location = new System.Drawing.Point(359, 95);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(16, 15);
            this.lblCliente.TabIndex = 7;
            this.lblCliente.Text = "...";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.White;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label21.Location = new System.Drawing.Point(298, 95);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(49, 15);
            this.label21.TabIndex = 6;
            this.label21.Text = "Cliente:";
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.BackColor = System.Drawing.Color.White;
            this.lblCedula.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCedula.Location = new System.Drawing.Point(92, 95);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(16, 15);
            this.lblCedula.TabIndex = 5;
            this.lblCedula.Text = "...";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.White;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label23.Location = new System.Drawing.Point(14, 95);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(47, 15);
            this.label23.TabIndex = 4;
            this.label23.Text = "Cédula:";
            // 
            // lblEstadoSRI
            // 
            this.lblEstadoSRI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEstadoSRI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(247)))), ((int)(((byte)(200)))));
            this.lblEstadoSRI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEstadoSRI.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoSRI.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblEstadoSRI.Location = new System.Drawing.Point(748, 49);
            this.lblEstadoSRI.Name = "lblEstadoSRI";
            this.lblEstadoSRI.Size = new System.Drawing.Size(128, 23);
            this.lblEstadoSRI.TabIndex = 3;
            this.lblEstadoSRI.Text = "AUTORIZADO";
            this.lblEstadoSRI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFechaAutorizacion
            // 
            this.lblFechaAutorizacion.AutoSize = true;
            this.lblFechaAutorizacion.BackColor = System.Drawing.Color.White;
            this.lblFechaAutorizacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaAutorizacion.Location = new System.Drawing.Point(495, 54);
            this.lblFechaAutorizacion.Name = "lblFechaAutorizacion";
            this.lblFechaAutorizacion.Size = new System.Drawing.Size(16, 15);
            this.lblFechaAutorizacion.TabIndex = 2;
            this.lblFechaAutorizacion.Text = "...";
            // 
            // lblNoInterno
            // 
            this.lblNoInterno.AutoSize = true;
            this.lblNoInterno.BackColor = System.Drawing.Color.White;
            this.lblNoInterno.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNoInterno.Location = new System.Drawing.Point(315, 54);
            this.lblNoInterno.Name = "lblNoInterno";
            this.lblNoInterno.Size = new System.Drawing.Size(16, 15);
            this.lblNoInterno.TabIndex = 1;
            this.lblNoInterno.Text = "...";
            // 
            // lblNumeroFactura
            // 
            this.lblNumeroFactura.AutoSize = true;
            this.lblNumeroFactura.BackColor = System.Drawing.Color.White;
            this.lblNumeroFactura.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNumeroFactura.Location = new System.Drawing.Point(13, 50);
            this.lblNumeroFactura.Name = "lblNumeroFactura";
            this.lblNumeroFactura.Size = new System.Drawing.Size(22, 21);
            this.lblNumeroFactura.TabIndex = 0;
            this.lblNumeroFactura.Text = "...";
            // 
            // btnReenviarSRI
            // 
            this.btnReenviarSRI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReenviarSRI.BorderRadius = 6;
            this.btnReenviarSRI.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReenviarSRI.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReenviarSRI.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReenviarSRI.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReenviarSRI.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnReenviarSRI.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReenviarSRI.ForeColor = System.Drawing.Color.White;
            this.btnReenviarSRI.Location = new System.Drawing.Point(595, 49);
            this.btnReenviarSRI.Name = "btnReenviarSRI";
            this.btnReenviarSRI.Size = new System.Drawing.Size(140, 28);
            this.btnReenviarSRI.TabIndex = 24;
            this.btnReenviarSRI.Text = "Reenviar al SRI";
            this.btnReenviarSRI.Click += new System.EventHandler(this.btnReenviarSRI_Click);
            // 
            // FrmFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 621);
            this.Controls.Add(this.panelDetalle);
            this.Controls.Add(this.panelLista);
            this.Controls.Add(this.panelFiltros);
            this.Name = "FrmFacturacion";
            this.Text = "Documento Electrónico Autorizado en el SRI";
            this.Load += new System.EventHandler(this.FrmFacturacion_Load);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.panelLista.ResumeLayout(false);
            this.panelLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaFacturas)).EndInit();
            this.panelDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelFiltros;
        private Guna.UI2.WinForms.Guna2Panel panelLista;
        private Guna.UI2.WinForms.Guna2Panel panelDetalle;
        private Guna.UI2.WinForms.Guna2ComboBox cboCaja;
        private System.Windows.Forms.Label lblCaja;
        private Guna.UI2.WinForms.Guna2ComboBox cboTipoDocumento;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cboEstado;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cboEstadoSRI;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox cboCajero;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtNumero;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtCliente;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2Button btnBuscar;
        private System.Windows.Forms.Label lblTotalDocumentos;
        private Guna.UI2.WinForms.Guna2DataGridView dgvListaFacturas;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDetalleFactura;
        private System.Windows.Forms.Label lblNumeroFactura;
        private System.Windows.Forms.Label lblNoInterno;
        private System.Windows.Forms.Label lblFechaAutorizacion;
        private System.Windows.Forms.Label lblEstadoSRI;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblAmbiente;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblCajeroDetalle;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblCajaDetalle;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblAutorizacion;
        private System.Windows.Forms.Label label22;

        // ✨ Declaraciones de columnas
       // private System.Windows.Forms.DataGridViewTextBoxColumn colNoDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAutorizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClaveAcceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClaveAcceso;
        private Guna.UI2.WinForms.Guna2Button btnReenviarSRI;
    }
}
