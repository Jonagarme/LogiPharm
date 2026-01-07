namespace LogiPharm.Presentacion
{
    partial class FrmReporteCierres
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panelTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCerrar = new Guna.UI2.WinForms.Guna2Button();
            this.gbFiltros = new Guna.UI2.WinForms.Guna2GroupBox();
            this.pnlAño = new Guna.UI2.WinForms.Guna2Panel();
            this.cboAño = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlMesAño = new Guna.UI2.WinForms.Guna2Panel();
            this.cboMes = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlFechas = new Guna.UI2.WinForms.Guna2Panel();
            this.dtpFechaFin = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpFechaInicio = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerar = new Guna.UI2.WinForms.Guna2Button();
            this.cboTipoReporte = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCierres = new Guna.UI2.WinForms.Guna2DataGridView();
            this.gbResumen = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblPromedioDiferencia = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTotalCierres = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTotalDiferencia = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalEgresos = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotalIngresos = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnExportar = new Guna.UI2.WinForms.Guna2Button();
            this.panelTop.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.pnlAño.SuspendLayout();
            this.pnlMesAño.SuspendLayout();
            this.pnlFechas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCierres)).BeginInit();
            this.gbResumen.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 12;
            this.guna2Elipse1.TargetControl = this;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Controls.Add(this.btnCerrar);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1200, 50);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(12, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(212, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "📊 Reportes de Cierres";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BorderRadius = 8;
            this.btnCerrar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCerrar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCerrar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCerrar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCerrar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1140, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(50, 30);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "✕";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // gbFiltros
            // 
            this.gbFiltros.BackColor = System.Drawing.Color.Transparent;
            this.gbFiltros.BorderRadius = 8;
            this.gbFiltros.Controls.Add(this.pnlAño);
            this.gbFiltros.Controls.Add(this.pnlMesAño);
            this.gbFiltros.Controls.Add(this.pnlFechas);
            this.gbFiltros.Controls.Add(this.btnGenerar);
            this.gbFiltros.Controls.Add(this.cboTipoReporte);
            this.gbFiltros.Controls.Add(this.label1);
            this.gbFiltros.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.gbFiltros.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbFiltros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbFiltros.Location = new System.Drawing.Point(12, 62);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(1176, 168);
            this.gbFiltros.TabIndex = 1;
            this.gbFiltros.Text = "Filtros de Búsqueda";
            // 
            // pnlAño
            // 
            this.pnlAño.Controls.Add(this.cboAño);
            this.pnlAño.Controls.Add(this.label5);
            this.pnlAño.Location = new System.Drawing.Point(17, 107);
            this.pnlAño.Name = "pnlAño";
            this.pnlAño.Size = new System.Drawing.Size(150, 58);
            this.pnlAño.TabIndex = 5;
            this.pnlAño.Visible = false;
            // 
            // cboAño
            // 
            this.cboAño.BackColor = System.Drawing.Color.Transparent;
            this.cboAño.BorderRadius = 8;
            this.cboAño.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboAño.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboAño.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboAño.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboAño.ItemHeight = 30;
            this.cboAño.Location = new System.Drawing.Point(6, 18);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(140, 36);
            this.cboAño.TabIndex = 1;
            this.cboAño.SelectedIndexChanged += new System.EventHandler(this.cboAño_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Año";
            // 
            // pnlMesAño
            // 
            this.pnlMesAño.Controls.Add(this.cboMes);
            this.pnlMesAño.Controls.Add(this.label4);
            this.pnlMesAño.Location = new System.Drawing.Point(194, 107);
            this.pnlMesAño.Name = "pnlMesAño";
            this.pnlMesAño.Size = new System.Drawing.Size(150, 58);
            this.pnlMesAño.TabIndex = 4;
            this.pnlMesAño.Visible = false;
            // 
            // cboMes
            // 
            this.cboMes.BackColor = System.Drawing.Color.Transparent;
            this.cboMes.BorderRadius = 8;
            this.cboMes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboMes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboMes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboMes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboMes.ItemHeight = 30;
            this.cboMes.Location = new System.Drawing.Point(3, 18);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(140, 36);
            this.cboMes.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mes";
            // 
            // pnlFechas
            // 
            this.pnlFechas.Controls.Add(this.dtpFechaFin);
            this.pnlFechas.Controls.Add(this.dtpFechaInicio);
            this.pnlFechas.Controls.Add(this.label3);
            this.pnlFechas.Controls.Add(this.label2);
            this.pnlFechas.Location = new System.Drawing.Point(350, 45);
            this.pnlFechas.Name = "pnlFechas";
            this.pnlFechas.Size = new System.Drawing.Size(450, 95);
            this.pnlFechas.TabIndex = 3;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.BorderRadius = 8;
            this.dtpFechaFin.Checked = true;
            this.dtpFechaFin.FillColor = System.Drawing.Color.White;
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(240, 25);
            this.dtpFechaFin.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFechaFin.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(200, 36);
            this.dtpFechaFin.TabIndex = 3;
            this.dtpFechaFin.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.BorderRadius = 8;
            this.dtpFechaInicio.Checked = true;
            this.dtpFechaInicio.FillColor = System.Drawing.Color.White;
            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(10, 25);
            this.dtpFechaInicio.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFechaInicio.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(200, 36);
            this.dtpFechaInicio.TabIndex = 2;
            this.dtpFechaInicio.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(240, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Fecha Fin:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(10, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fecha Inicio:";
            // 
            // btnGenerar
            // 
            this.btnGenerar.BorderRadius = 8;
            this.btnGenerar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGenerar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGenerar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGenerar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGenerar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnGenerar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Location = new System.Drawing.Point(830, 70);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(180, 45);
            this.btnGenerar.TabIndex = 2;
            this.btnGenerar.Text = "🔍 Generar Reporte";
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // cboTipoReporte
            // 
            this.cboTipoReporte.BackColor = System.Drawing.Color.Transparent;
            this.cboTipoReporte.BorderRadius = 8;
            this.cboTipoReporte.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoReporte.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTipoReporte.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTipoReporte.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTipoReporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboTipoReporte.ItemHeight = 30;
            this.cboTipoReporte.Location = new System.Drawing.Point(14, 65);
            this.cboTipoReporte.Name = "cboTipoReporte";
            this.cboTipoReporte.Size = new System.Drawing.Size(200, 36);
            this.cboTipoReporte.TabIndex = 1;
            this.cboTipoReporte.SelectedIndexChanged += new System.EventHandler(this.cboTipoReporte_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(14, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de Reporte:";
            // 
            // dgvCierres
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvCierres.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCierres.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCierres.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCierres.ColumnHeadersHeight = 30;
            this.dgvCierres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCierres.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCierres.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCierres.Location = new System.Drawing.Point(12, 236);
            this.dgvCierres.Name = "dgvCierres";
            this.dgvCierres.ReadOnly = true;
            this.dgvCierres.RowHeadersVisible = false;
            this.dgvCierres.RowTemplate.Height = 28;
            this.dgvCierres.Size = new System.Drawing.Size(1176, 332);
            this.dgvCierres.TabIndex = 2;
            this.dgvCierres.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCierres.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCierres.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCierres.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCierres.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCierres.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCierres.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCierres.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvCierres.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCierres.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCierres.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCierres.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvCierres.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvCierres.ThemeStyle.ReadOnly = true;
            this.dgvCierres.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCierres.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCierres.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCierres.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCierres.ThemeStyle.RowsStyle.Height = 28;
            this.dgvCierres.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCierres.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCierres.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCierres_CellFormatting);
            // 
            // gbResumen
            // 
            this.gbResumen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResumen.BackColor = System.Drawing.Color.Transparent;
            this.gbResumen.BorderRadius = 8;
            this.gbResumen.Controls.Add(this.lblPromedioDiferencia);
            this.gbResumen.Controls.Add(this.label11);
            this.gbResumen.Controls.Add(this.lblTotalCierres);
            this.gbResumen.Controls.Add(this.label10);
            this.gbResumen.Controls.Add(this.lblTotalDiferencia);
            this.gbResumen.Controls.Add(this.label9);
            this.gbResumen.Controls.Add(this.lblTotalEgresos);
            this.gbResumen.Controls.Add(this.label8);
            this.gbResumen.Controls.Add(this.lblTotalIngresos);
            this.gbResumen.Controls.Add(this.label6);
            this.gbResumen.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.gbResumen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbResumen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbResumen.Location = new System.Drawing.Point(12, 580);
            this.gbResumen.Name = "gbResumen";
            this.gbResumen.Size = new System.Drawing.Size(998, 90);
            this.gbResumen.TabIndex = 3;
            this.gbResumen.Text = "Resumen";
            // 
            // lblPromedioDiferencia
            // 
            this.lblPromedioDiferencia.AutoSize = true;
            this.lblPromedioDiferencia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPromedioDiferencia.Location = new System.Drawing.Point(800, 55);
            this.lblPromedioDiferencia.Name = "lblPromedioDiferencia";
            this.lblPromedioDiferencia.Size = new System.Drawing.Size(50, 21);
            this.lblPromedioDiferencia.TabIndex = 9;
            this.lblPromedioDiferencia.Text = "$0.00";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label11.Location = new System.Drawing.Point(800, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 15);
            this.label11.TabIndex = 8;
            this.label11.Text = "Promedio Diferencia:";
            // 
            // lblTotalCierres
            // 
            this.lblTotalCierres.AutoSize = true;
            this.lblTotalCierres.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalCierres.Location = new System.Drawing.Point(20, 55);
            this.lblTotalCierres.Name = "lblTotalCierres";
            this.lblTotalCierres.Size = new System.Drawing.Size(19, 21);
            this.lblTotalCierres.TabIndex = 7;
            this.lblTotalCierres.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label10.Location = new System.Drawing.Point(20, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 15);
            this.label10.TabIndex = 6;
            this.label10.Text = "Total Cierres:";
            // 
            // lblTotalDiferencia
            // 
            this.lblTotalDiferencia.AutoSize = true;
            this.lblTotalDiferencia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalDiferencia.ForeColor = System.Drawing.Color.Green;
            this.lblTotalDiferencia.Location = new System.Drawing.Point(620, 55);
            this.lblTotalDiferencia.Name = "lblTotalDiferencia";
            this.lblTotalDiferencia.Size = new System.Drawing.Size(50, 21);
            this.lblTotalDiferencia.TabIndex = 5;
            this.lblTotalDiferencia.Text = "$0.00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.Location = new System.Drawing.Point(620, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 15);
            this.label9.TabIndex = 4;
            this.label9.Text = "Total Diferencia:";
            // 
            // lblTotalEgresos
            // 
            this.lblTotalEgresos.AutoSize = true;
            this.lblTotalEgresos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalEgresos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTotalEgresos.Location = new System.Drawing.Point(420, 55);
            this.lblTotalEgresos.Name = "lblTotalEgresos";
            this.lblTotalEgresos.Size = new System.Drawing.Size(50, 21);
            this.lblTotalEgresos.TabIndex = 3;
            this.lblTotalEgresos.Text = "$0.00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.Location = new System.Drawing.Point(420, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "Total Egresos:";
            // 
            // lblTotalIngresos
            // 
            this.lblTotalIngresos.AutoSize = true;
            this.lblTotalIngresos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalIngresos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblTotalIngresos.Location = new System.Drawing.Point(220, 55);
            this.lblTotalIngresos.Name = "lblTotalIngresos";
            this.lblTotalIngresos.Size = new System.Drawing.Size(50, 21);
            this.lblTotalIngresos.TabIndex = 1;
            this.lblTotalIngresos.Text = "$0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.Location = new System.Drawing.Point(220, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Total Ingresos:";
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BorderRadius = 8;
            this.btnExportar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExportar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExportar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExportar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExportar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(1016, 605);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(172, 45);
            this.btnExportar.TabIndex = 4;
            this.btnExportar.Text = "📥 Exportar a Excel";
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // FrmReporteCierres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 682);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.gbResumen);
            this.Controls.Add(this.dgvCierres);
            this.Controls.Add(this.gbFiltros);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmReporteCierres";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes de Cierres";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmReporteCierres_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.pnlAño.ResumeLayout(false);
            this.pnlAño.PerformLayout();
            this.pnlMesAño.ResumeLayout(false);
            this.pnlMesAño.PerformLayout();
            this.pnlFechas.ResumeLayout(false);
            this.pnlFechas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCierres)).EndInit();
            this.gbResumen.ResumeLayout(false);
            this.gbResumen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;
        private Guna.UI2.WinForms.Guna2Button btnCerrar;
        private Guna.UI2.WinForms.Guna2GroupBox gbFiltros;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cboTipoReporte;
        private Guna.UI2.WinForms.Guna2Button btnGenerar;
        private Guna.UI2.WinForms.Guna2Panel pnlFechas;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFechaFin;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCierres;
        private Guna.UI2.WinForms.Guna2GroupBox gbResumen;
        private System.Windows.Forms.Label lblTotalIngresos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalEgresos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalDiferencia;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2Button btnExportar;
        private System.Windows.Forms.Label lblTotalCierres;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblPromedioDiferencia;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2Panel pnlMesAño;
        private Guna.UI2.WinForms.Guna2ComboBox cboMes;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Panel pnlAño;
        private Guna.UI2.WinForms.Guna2ComboBox cboAño;
        private System.Windows.Forms.Label label5;
    }
}
