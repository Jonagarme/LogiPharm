namespace LogiPharm.Presentacion
{
    partial class FrmVademecum
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
            this.panelFilters = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dgvMedicinas = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrincipio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPresentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLaboratorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPVP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.panelInfoSheet = new System.Windows.Forms.Panel();
            this.txtInfoObservaciones = new System.Windows.Forms.TextBox();
            this.lblInfoObsTitle = new System.Windows.Forms.Label();
            this.txtInfoDescripcion = new System.Windows.Forms.TextBox();
            this.lblInfoDescTitle = new System.Windows.Forms.Label();
            this.lblInfoPVP = new System.Windows.Forms.Label();
            this.lblInfoPVPTitle = new System.Windows.Forms.Label();
            this.lblInfoStock = new System.Windows.Forms.Label();
            this.lblInfoStockTitle = new System.Windows.Forms.Label();
            this.lblInfoRegistro = new System.Windows.Forms.Label();
            this.lblInfoRegistroTitle = new System.Windows.Forms.Label();
            this.lblInfoLaboratorio = new System.Windows.Forms.Label();
            this.lblInfoLaboratorioTitle = new System.Windows.Forms.Label();
            this.lblInfoPresentacion = new System.Windows.Forms.Label();
            this.lblInfoPresentacionTitle = new System.Windows.Forms.Label();
            this.lblInfoPrincipio = new System.Windows.Forms.Label();
            this.lblInfoPrincipioTitle = new System.Windows.Forms.Label();
            this.lblInfoNombre = new System.Windows.Forms.Label();
            this.lblInfoNombreTitle = new System.Windows.Forms.Label();
            this.lblFichaTitulo = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicinas)).BeginInit();
            this.panelInfoSheet.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1100, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(12, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(251, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Vademécum de Equipos";
            // 
            // panelFilters
            // 
            this.panelFilters.BackColor = System.Drawing.Color.White;
            this.panelFilters.Controls.Add(this.btnBuscar);
            this.panelFilters.Controls.Add(this.txtBusqueda);
            this.panelFilters.Controls.Add(this.lblBuscar);
            this.panelFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilters.Location = new System.Drawing.Point(0, 60);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(1100, 50);
            this.panelFilters.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(400, 10);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 30);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtBusqueda.Location = new System.Drawing.Point(70, 13);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(320, 25);
            this.txtBusqueda.TabIndex = 1;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblBuscar.Location = new System.Drawing.Point(12, 16);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(52, 17);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar:";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 110);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dgvMedicinas);
            this.splitContainer.Panel1.Controls.Add(this.lblTotal);
            this.splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(12);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panelInfoSheet);
            this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(12);
            this.splitContainer.Size = new System.Drawing.Size(1100, 490);
            this.splitContainer.SplitterDistance = 680;
            this.splitContainer.TabIndex = 2;
            // 
            // dgvMedicinas
            // 
            this.dgvMedicinas.AllowUserToAddRows = false;
            this.dgvMedicinas.AllowUserToDeleteRows = false;
            this.dgvMedicinas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMedicinas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedicinas.BackgroundColor = System.Drawing.Color.White;
            this.dgvMedicinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicinas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colCodigo,
            this.colNombre,
            this.colPrincipio,
            this.colPresentacion,
            this.colLaboratorio,
            this.colStock,
            this.colPVP,
            this.colRegistro,
            this.colDescripcion,
            this.colObservaciones});
            this.dgvMedicinas.Location = new System.Drawing.Point(12, 12);
            this.dgvMedicinas.Name = "dgvMedicinas";
            this.dgvMedicinas.ReadOnly = true;
            this.dgvMedicinas.Size = new System.Drawing.Size(656, 432);
            this.dgvMedicinas.TabIndex = 0;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colCodigo
            // 
            this.colCodigo.DataPropertyName = "Codigo";
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Width = 90;
            // 
            // colNombre
            // 
            this.colNombre.DataPropertyName = "Nombre";
            this.colNombre.HeaderText = "Medicina comercial";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            this.colNombre.Width = 160;
            // 
            // colPrincipio
            // 
            this.colPrincipio.DataPropertyName = "PrincipioActivo";
            this.colPrincipio.HeaderText = "Principio Activo";
            this.colPrincipio.Name = "colPrincipio";
            this.colPrincipio.ReadOnly = true;
            this.colPrincipio.Width = 140;
            // 
            // colPresentacion
            // 
            this.colPresentacion.DataPropertyName = "Presentacion";
            this.colPresentacion.HeaderText = "Presentación";
            this.colPresentacion.Name = "colPresentacion";
            this.colPresentacion.ReadOnly = true;
            this.colPresentacion.Width = 100;
            // 
            // colLaboratorio
            // 
            this.colLaboratorio.DataPropertyName = "Laboratorio";
            this.colLaboratorio.HeaderText = "Laboratorio";
            this.colLaboratorio.Name = "colLaboratorio";
            this.colLaboratorio.ReadOnly = true;
            this.colLaboratorio.Visible = false;
            // 
            // colStock
            // 
            this.colStock.DataPropertyName = "Stock";
            this.colStock.HeaderText = "Stock";
            this.colStock.Name = "colStock";
            this.colStock.ReadOnly = true;
            this.colStock.Width = 60;
            // 
            // colPVP
            // 
            this.colPVP.DataPropertyName = "PVP";
            this.colPVP.HeaderText = "PVP";
            this.colPVP.Name = "colPVP";
            this.colPVP.ReadOnly = true;
            this.colPVP.Width = 70;
            // 
            // colRegistro
            // 
            this.colRegistro.DataPropertyName = "RegistroSanitario";
            this.colRegistro.HeaderText = "RegistroSanitario";
            this.colRegistro.Name = "colRegistro";
            this.colRegistro.ReadOnly = true;
            this.colRegistro.Visible = false;
            // 
            // colDescripcion
            // 
            this.colDescripcion.DataPropertyName = "Descripcion";
            this.colDescripcion.HeaderText = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.Visible = false;
            // 
            // colObservaciones
            // 
            this.colObservaciones.DataPropertyName = "Observaciones";
            this.colObservaciones.HeaderText = "Observaciones";
            this.colObservaciones.Name = "colObservaciones";
            this.colObservaciones.ReadOnly = true;
            this.colObservaciones.Visible = false;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(12, 459);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(164, 17);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Medicinas encontradas: 0";
            // 
            // panelInfoSheet
            // 
            this.panelInfoSheet.BackColor = System.Drawing.Color.White;
            this.panelInfoSheet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInfoSheet.Controls.Add(this.txtInfoObservaciones);
            this.panelInfoSheet.Controls.Add(this.lblInfoObsTitle);
            this.panelInfoSheet.Controls.Add(this.txtInfoDescripcion);
            this.panelInfoSheet.Controls.Add(this.lblInfoDescTitle);
            this.panelInfoSheet.Controls.Add(this.lblInfoPVP);
            this.panelInfoSheet.Controls.Add(this.lblInfoPVPTitle);
            this.panelInfoSheet.Controls.Add(this.lblInfoStock);
            this.panelInfoSheet.Controls.Add(this.lblInfoStockTitle);
            this.panelInfoSheet.Controls.Add(this.lblInfoRegistro);
            this.panelInfoSheet.Controls.Add(this.lblInfoRegistroTitle);
            this.panelInfoSheet.Controls.Add(this.lblInfoLaboratorio);
            this.panelInfoSheet.Controls.Add(this.lblInfoLaboratorioTitle);
            this.panelInfoSheet.Controls.Add(this.lblInfoPresentacion);
            this.panelInfoSheet.Controls.Add(this.lblInfoPresentacionTitle);
            this.panelInfoSheet.Controls.Add(this.lblInfoPrincipio);
            this.panelInfoSheet.Controls.Add(this.lblInfoPrincipioTitle);
            this.panelInfoSheet.Controls.Add(this.lblInfoNombre);
            this.panelInfoSheet.Controls.Add(this.lblInfoNombreTitle);
            this.panelInfoSheet.Controls.Add(this.lblFichaTitulo);
            this.panelInfoSheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInfoSheet.Location = new System.Drawing.Point(12, 12);
            this.panelInfoSheet.Name = "panelInfoSheet";
            this.panelInfoSheet.Padding = new System.Windows.Forms.Padding(12);
            this.panelInfoSheet.Size = new System.Drawing.Size(392, 466);
            this.panelInfoSheet.TabIndex = 0;
            // 
            // txtInfoObservaciones
            // 
            this.txtInfoObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfoObservaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtInfoObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInfoObservaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtInfoObservaciones.Location = new System.Drawing.Point(15, 360);
            this.txtInfoObservaciones.Multiline = true;
            this.txtInfoObservaciones.Name = "txtInfoObservaciones";
            this.txtInfoObservaciones.ReadOnly = true;
            this.txtInfoObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfoObservaciones.Size = new System.Drawing.Size(360, 90);
            this.txtInfoObservaciones.TabIndex = 18;
            // 
            // lblInfoObsTitle
            // 
            this.lblInfoObsTitle.AutoSize = true;
            this.lblInfoObsTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblInfoObsTitle.Location = new System.Drawing.Point(12, 342);
            this.lblInfoObsTitle.Name = "lblInfoObsTitle";
            this.lblInfoObsTitle.Size = new System.Drawing.Size(176, 15);
            this.lblInfoObsTitle.TabIndex = 17;
            this.lblInfoObsTitle.Text = "Indicaciones / Observaciones:";
            // 
            // txtInfoDescripcion
            // 
            this.txtInfoDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfoDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtInfoDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInfoDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtInfoDescripcion.Location = new System.Drawing.Point(15, 260);
            this.txtInfoDescripcion.Multiline = true;
            this.txtInfoDescripcion.Name = "txtInfoDescripcion";
            this.txtInfoDescripcion.ReadOnly = true;
            this.txtInfoDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfoDescripcion.Size = new System.Drawing.Size(360, 70);
            this.txtInfoDescripcion.TabIndex = 16;
            // 
            // lblInfoDescTitle
            // 
            this.lblInfoDescTitle.AutoSize = true;
            this.lblInfoDescTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblInfoDescTitle.Location = new System.Drawing.Point(12, 242);
            this.lblInfoDescTitle.Name = "lblInfoDescTitle";
            this.lblInfoDescTitle.Size = new System.Drawing.Size(75, 15);
            this.lblInfoDescTitle.TabIndex = 15;
            this.lblInfoDescTitle.Text = "Descripción:";
            // 
            // lblInfoPVP
            // 
            this.lblInfoPVP.AutoSize = true;
            this.lblInfoPVP.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblInfoPVP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.lblInfoPVP.Location = new System.Drawing.Point(120, 212);
            this.lblInfoPVP.Name = "lblInfoPVP";
            this.lblInfoPVP.Size = new System.Drawing.Size(21, 19);
            this.lblInfoPVP.TabIndex = 14;
            this.lblInfoPVP.Text = "...";
            // 
            // lblInfoPVPTitle
            // 
            this.lblInfoPVPTitle.AutoSize = true;
            this.lblInfoPVPTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblInfoPVPTitle.Location = new System.Drawing.Point(12, 214);
            this.lblInfoPVPTitle.Name = "lblInfoPVPTitle";
            this.lblInfoPVPTitle.Size = new System.Drawing.Size(32, 15);
            this.lblInfoPVPTitle.TabIndex = 13;
            this.lblInfoPVPTitle.Text = "PVP:";
            // 
            // lblInfoStock
            // 
            this.lblInfoStock.AutoSize = true;
            this.lblInfoStock.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInfoStock.Location = new System.Drawing.Point(120, 187);
            this.lblInfoStock.Name = "lblInfoStock";
            this.lblInfoStock.Size = new System.Drawing.Size(17, 15);
            this.lblInfoStock.TabIndex = 12;
            this.lblInfoStock.Text = "...";
            // 
            // lblInfoStockTitle
            // 
            this.lblInfoStockTitle.AutoSize = true;
            this.lblInfoStockTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblInfoStockTitle.Location = new System.Drawing.Point(12, 187);
            this.lblInfoStockTitle.Name = "lblInfoStockTitle";
            this.lblInfoStockTitle.Size = new System.Drawing.Size(42, 15);
            this.lblInfoStockTitle.TabIndex = 11;
            this.lblInfoStockTitle.Text = "Stock:";
            // 
            // lblInfoRegistro
            // 
            this.lblInfoRegistro.AutoSize = true;
            this.lblInfoRegistro.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInfoRegistro.Location = new System.Drawing.Point(120, 160);
            this.lblInfoRegistro.Name = "lblInfoRegistro";
            this.lblInfoRegistro.Size = new System.Drawing.Size(17, 15);
            this.lblInfoRegistro.TabIndex = 10;
            this.lblInfoRegistro.Text = "...";
            // 
            // lblInfoRegistroTitle
            // 
            this.lblInfoRegistroTitle.AutoSize = true;
            this.lblInfoRegistroTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblInfoRegistroTitle.Location = new System.Drawing.Point(12, 160);
            this.lblInfoRegistroTitle.Name = "lblInfoRegistroTitle";
            this.lblInfoRegistroTitle.Size = new System.Drawing.Size(89, 15);
            this.lblInfoRegistroTitle.TabIndex = 9;
            this.lblInfoRegistroTitle.Text = "Reg. Sanitario:";
            // 
            // lblInfoLaboratorio
            // 
            this.lblInfoLaboratorio.AutoSize = true;
            this.lblInfoLaboratorio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInfoLaboratorio.Location = new System.Drawing.Point(120, 133);
            this.lblInfoLaboratorio.Name = "lblInfoLaboratorio";
            this.lblInfoLaboratorio.Size = new System.Drawing.Size(17, 15);
            this.lblInfoLaboratorio.TabIndex = 8;
            this.lblInfoLaboratorio.Text = "...";
            // 
            // lblInfoLaboratorioTitle
            // 
            this.lblInfoLaboratorioTitle.AutoSize = true;
            this.lblInfoLaboratorioTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblInfoLaboratorioTitle.Location = new System.Drawing.Point(12, 133);
            this.lblInfoLaboratorioTitle.Name = "lblInfoLaboratorioTitle";
            this.lblInfoLaboratorioTitle.Size = new System.Drawing.Size(74, 15);
            this.lblInfoLaboratorioTitle.TabIndex = 7;
            this.lblInfoLaboratorioTitle.Text = "Laboratorio:";
            // 
            // lblInfoPresentacion
            // 
            this.lblInfoPresentacion.AutoSize = true;
            this.lblInfoPresentacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInfoPresentacion.Location = new System.Drawing.Point(120, 107);
            this.lblInfoPresentacion.Name = "lblInfoPresentacion";
            this.lblInfoPresentacion.Size = new System.Drawing.Size(17, 15);
            this.lblInfoPresentacion.TabIndex = 6;
            this.lblInfoPresentacion.Text = "...";
            // 
            // lblInfoPresentacionTitle
            // 
            this.lblInfoPresentacionTitle.AutoSize = true;
            this.lblInfoPresentacionTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblInfoPresentacionTitle.Location = new System.Drawing.Point(12, 107);
            this.lblInfoPresentacionTitle.Name = "lblInfoPresentacionTitle";
            this.lblInfoPresentacionTitle.Size = new System.Drawing.Size(81, 15);
            this.lblInfoPresentacionTitle.TabIndex = 5;
            this.lblInfoPresentacionTitle.Text = "Presentación:";
            // 
            // lblInfoPrincipio
            // 
            this.lblInfoPrincipio.AutoSize = true;
            this.lblInfoPrincipio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInfoPrincipio.Location = new System.Drawing.Point(120, 80);
            this.lblInfoPrincipio.Name = "lblInfoPrincipio";
            this.lblInfoPrincipio.Size = new System.Drawing.Size(17, 15);
            this.lblInfoPrincipio.TabIndex = 4;
            this.lblInfoPrincipio.Text = "...";
            // 
            // lblInfoPrincipioTitle
            // 
            this.lblInfoPrincipioTitle.AutoSize = true;
            this.lblInfoPrincipioTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblInfoPrincipioTitle.Location = new System.Drawing.Point(12, 80);
            this.lblInfoPrincipioTitle.Name = "lblInfoPrincipioTitle";
            this.lblInfoPrincipioTitle.Size = new System.Drawing.Size(95, 15);
            this.lblInfoPrincipioTitle.TabIndex = 3;
            this.lblInfoPrincipioTitle.Text = "Principio Activo:";
            // 
            // lblInfoNombre
            // 
            this.lblInfoNombre.AutoSize = true;
            this.lblInfoNombre.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblInfoNombre.Location = new System.Drawing.Point(120, 52);
            this.lblInfoNombre.Name = "lblInfoNombre";
            this.lblInfoNombre.Size = new System.Drawing.Size(21, 19);
            this.lblInfoNombre.TabIndex = 2;
            this.lblInfoNombre.Text = "...";
            // 
            // lblInfoNombreTitle
            // 
            this.lblInfoNombreTitle.AutoSize = true;
            this.lblInfoNombreTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblInfoNombreTitle.Location = new System.Drawing.Point(12, 54);
            this.lblInfoNombreTitle.Name = "lblInfoNombreTitle";
            this.lblInfoNombreTitle.Size = new System.Drawing.Size(56, 15);
            this.lblInfoNombreTitle.TabIndex = 1;
            this.lblInfoNombreTitle.Text = "Nombre:";
            // 
            // lblFichaTitulo
            // 
            this.lblFichaTitulo.AutoSize = true;
            this.lblFichaTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFichaTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.lblFichaTitulo.Location = new System.Drawing.Point(12, 12);
            this.lblFichaTitulo.Name = "lblFichaTitulo";
            this.lblFichaTitulo.Size = new System.Drawing.Size(185, 21);
            this.lblFichaTitulo.TabIndex = 0;
            this.lblFichaTitulo.Text = "Ficha Técnica del Medic";
            // 
            // FrmVademecum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.panelFilters);
            this.Controls.Add(this.panelHeader);
            this.Name = "FrmVademecum";
            this.Text = "Vademécum de Medicamentos";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicinas)).EndInit();
            this.panelInfoSheet.ResumeLayout(false);
            this.panelInfoSheet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dgvMedicinas;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel panelInfoSheet;
        private System.Windows.Forms.Label lblFichaTitulo;
        private System.Windows.Forms.Label lblInfoNombre;
        private System.Windows.Forms.Label lblInfoNombreTitle;
        private System.Windows.Forms.Label lblInfoPrincipio;
        private System.Windows.Forms.Label lblInfoPrincipioTitle;
        private System.Windows.Forms.Label lblInfoPresentacion;
        private System.Windows.Forms.Label lblInfoPresentacionTitle;
        private System.Windows.Forms.Label lblInfoLaboratorio;
        private System.Windows.Forms.Label lblInfoLaboratorioTitle;
        private System.Windows.Forms.Label lblInfoRegistro;
        private System.Windows.Forms.Label lblInfoRegistroTitle;
        private System.Windows.Forms.Label lblInfoStock;
        private System.Windows.Forms.Label lblInfoStockTitle;
        private System.Windows.Forms.Label lblInfoPVP;
        private System.Windows.Forms.Label lblInfoPVPTitle;
        private System.Windows.Forms.Label lblInfoDescTitle;
        private System.Windows.Forms.TextBox txtInfoDescripcion;
        private System.Windows.Forms.Label lblInfoObsTitle;
        private System.Windows.Forms.TextBox txtInfoObservaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrincipio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPresentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLaboratorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPVP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservaciones;
    }
}
