namespace LogiPharm.Presentacion
{
    partial class FrmGestionCajas
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
            this.panelTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCerrar = new Guna.UI2.WinForms.Guna2Button();
            this.gbListado = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblTotalCajas = new System.Windows.Forms.Label();
            this.labelBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.chkMostrarAnuladas = new Guna.UI2.WinForms.Guna2CheckBox();
            this.dgvCajas = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActiva = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colAnulado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gbFormulario = new Guna.UI2.WinForms.Guna2GroupBox();
            this.chkActiva = new Guna.UI2.WinForms.Guna2CheckBox();
            this.labelDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.txtNombre = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            this.gbAcciones = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnNuevo = new Guna.UI2.WinForms.Guna2Button();
            this.btnEditar = new Guna.UI2.WinForms.Guna2Button();
            this.btnActivarDesactivar = new Guna.UI2.WinForms.Guna2Button();
            this.btnAnular = new Guna.UI2.WinForms.Guna2Button();
            this.btnVerEstado = new Guna.UI2.WinForms.Guna2Button();
            this.gbDetalle = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblEstadoDetalle = new System.Windows.Forms.Label();
            this.lblDescripcionDetalle = new System.Windows.Forms.Label();
            this.lblNombreDetalle = new System.Windows.Forms.Label();
            this.lblCodigoDetalle = new System.Windows.Forms.Label();
            this.lblEstadoLabel = new System.Windows.Forms.Label();
            this.lblDescripcionLabel = new System.Windows.Forms.Label();
            this.lblNombreLabel = new System.Windows.Forms.Label();
            this.lblCodigoLabel = new System.Windows.Forms.Label();
            this.pnlAperturaActiva = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSaldoActual = new System.Windows.Forms.Label();
            this.lblUsuarioApertura = new System.Windows.Forms.Label();
            this.lblFechaApertura = new System.Windows.Forms.Label();
            this.labelSaldo = new System.Windows.Forms.Label();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.gbStats = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblDiferenciaPromedioStats = new System.Windows.Forms.Label();
            this.lblTotalEgresosStats = new System.Windows.Forms.Label();
            this.lblTotalIngresosStats = new System.Windows.Forms.Label();
            this.lblTotalCierresStats = new System.Windows.Forms.Label();
            this.labelDifProm = new System.Windows.Forms.Label();
            this.labelEgresos = new System.Windows.Forms.Label();
            this.labelIngresos = new System.Windows.Forms.Label();
            this.labelCierres = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.gbListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajas)).BeginInit();
            this.gbFormulario.SuspendLayout();
            this.gbAcciones.SuspendLayout();
            this.gbDetalle.SuspendLayout();
            this.pnlAperturaActiva.SuspendLayout();
            this.gbStats.SuspendLayout();
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
            this.lblTitulo.Size = new System.Drawing.Size(192, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestión de Cajas";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BorderRadius = 8;
            this.btnCerrar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1140, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(50, 30);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "?";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // gbListado
            // 
            this.gbListado.BackColor = System.Drawing.Color.Transparent;
            this.gbListado.BorderRadius = 8;
            this.gbListado.Controls.Add(this.lblTotalCajas);
            this.gbListado.Controls.Add(this.labelBuscar);
            this.gbListado.Controls.Add(this.txtBuscar);
            this.gbListado.Controls.Add(this.chkMostrarAnuladas);
            this.gbListado.Controls.Add(this.dgvCajas);
            this.gbListado.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.gbListado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbListado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbListado.Location = new System.Drawing.Point(12, 62);
            this.gbListado.Name = "gbListado";
            this.gbListado.Size = new System.Drawing.Size(700, 610);
            this.gbListado.TabIndex = 1;
            this.gbListado.Text = "Listado de Cajas";
            // 
            // lblTotalCajas
            // 
            this.lblTotalCajas.AutoSize = true;
            this.lblTotalCajas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalCajas.Location = new System.Drawing.Point(16, 78);
            this.lblTotalCajas.Name = "lblTotalCajas";
            this.lblTotalCajas.Size = new System.Drawing.Size(92, 15);
            this.lblTotalCajas.TabIndex = 4;
            this.lblTotalCajas.Text = "Total: 0 cajas";
            // 
            // labelBuscar
            // 
            this.labelBuscar.AutoSize = true;
            this.labelBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelBuscar.Location = new System.Drawing.Point(16, 40);
            this.labelBuscar.Name = "labelBuscar";
            this.labelBuscar.Size = new System.Drawing.Size(45, 15);
            this.labelBuscar.TabIndex = 1;
            this.labelBuscar.Text = "Buscar";
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderRadius = 8;
            this.txtBuscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscar.DefaultText = "";
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuscar.Location = new System.Drawing.Point(70, 35);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PlaceholderText = "Código o nombre...";
            this.txtBuscar.Size = new System.Drawing.Size(320, 36);
            this.txtBuscar.TabIndex = 2;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // chkMostrarAnuladas
            // 
            this.chkMostrarAnuladas.AutoSize = true;
            this.chkMostrarAnuladas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkMostrarAnuladas.Location = new System.Drawing.Point(410, 45);
            this.chkMostrarAnuladas.Name = "chkMostrarAnuladas";
            this.chkMostrarAnuladas.Size = new System.Drawing.Size(122, 19);
            this.chkMostrarAnuladas.TabIndex = 3;
            this.chkMostrarAnuladas.Text = "Mostrar anuladas";
            this.chkMostrarAnuladas.CheckedChanged += new System.EventHandler(this.chkMostrarAnuladas_CheckedChanged);
            // 
            // dgvCajas
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvCajas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCajas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCajas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCajas.ColumnHeadersHeight = 30;
            this.dgvCajas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvCajas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colCodigo,
            this.colNombre,
            this.colDescripcion,
            this.colEstado,
            this.colActiva,
            this.colAnulado});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCajas.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCajas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCajas.Location = new System.Drawing.Point(16, 100);
            this.dgvCajas.Name = "dgvCajas";
            this.dgvCajas.ReadOnly = true;
            this.dgvCajas.RowHeadersVisible = false;
            this.dgvCajas.RowTemplate.Height = 28;
            this.dgvCajas.Size = new System.Drawing.Size(668, 490);
            this.dgvCajas.TabIndex = 0;
            this.dgvCajas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCajas_CellFormatting);
            this.dgvCajas.SelectionChanged += new System.EventHandler(this.dgvCajas_SelectionChanged);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "ID";
            this.colId.HeaderText = "ID";
            this.colId.Name = "ID";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colCodigo
            // 
            this.colCodigo.DataPropertyName = "Código";
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "Código";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Width = 110;
            // 
            // colNombre
            // 
            this.colNombre.DataPropertyName = "Nombre";
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "Nombre";
            this.colNombre.ReadOnly = true;
            this.colNombre.Width = 200;
            // 
            // colDescripcion
            // 
            this.colDescripcion.DataPropertyName = "Descripción";
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.Name = "Descripción";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.Width = 240;
            // 
            // colEstado
            // 
            this.colEstado.DataPropertyName = "Estado";
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "Estado";
            this.colEstado.ReadOnly = true;
            this.colEstado.Width = 110;
            // 
            // colActiva
            // 
            this.colActiva.DataPropertyName = "Activa";
            this.colActiva.HeaderText = "Activa";
            this.colActiva.Name = "Activa";
            this.colActiva.ReadOnly = true;
            this.colActiva.Visible = false;
            // 
            // colAnulado
            // 
            this.colAnulado.DataPropertyName = "Anulado";
            this.colAnulado.HeaderText = "Anulado";
            this.colAnulado.Name = "Anulado";
            this.colAnulado.ReadOnly = true;
            this.colAnulado.Visible = false;
            // 
            // gbFormulario
            // 
            this.gbFormulario.BackColor = System.Drawing.Color.Transparent;
            this.gbFormulario.BorderRadius = 8;
            this.gbFormulario.Controls.Add(this.chkActiva);
            this.gbFormulario.Controls.Add(this.labelDescripcion);
            this.gbFormulario.Controls.Add(this.txtDescripcion);
            this.gbFormulario.Controls.Add(this.labelNombre);
            this.gbFormulario.Controls.Add(this.txtNombre);
            this.gbFormulario.Controls.Add(this.labelCodigo);
            this.gbFormulario.Controls.Add(this.txtCodigo);
            this.gbFormulario.Controls.Add(this.btnGuardar);
            this.gbFormulario.Controls.Add(this.btnCancelar);
            this.gbFormulario.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.gbFormulario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbFormulario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbFormulario.Location = new System.Drawing.Point(718, 62);
            this.gbFormulario.Name = "gbFormulario";
            this.gbFormulario.Size = new System.Drawing.Size(470, 250);
            this.gbFormulario.TabIndex = 2;
            this.gbFormulario.Text = "Formulario";
            // 
            // chkActiva
            // 
            this.chkActiva.AutoSize = true;
            this.chkActiva.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkActiva.Location = new System.Drawing.Point(18, 196);
            this.chkActiva.Name = "chkActiva";
            this.chkActiva.Size = new System.Drawing.Size(58, 19);
            this.chkActiva.TabIndex = 6;
            this.chkActiva.Text = "Activa";
            // 
            // labelDescripcion
            // 
            this.labelDescripcion.AutoSize = true;
            this.labelDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelDescripcion.Location = new System.Drawing.Point(14, 122);
            this.labelDescripcion.Name = "labelDescripcion";
            this.labelDescripcion.Size = new System.Drawing.Size(69, 15);
            this.labelDescripcion.TabIndex = 4;
            this.labelDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderRadius = 8;
            this.txtDescripcion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescripcion.DefaultText = "";
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescripcion.Location = new System.Drawing.Point(110, 112);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.PlaceholderText = "Opcional";
            this.txtDescripcion.Size = new System.Drawing.Size(340, 36);
            this.txtDescripcion.TabIndex = 5;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelNombre.Location = new System.Drawing.Point(14, 82);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(50, 15);
            this.labelNombre.TabIndex = 2;
            this.labelNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.BorderRadius = 8;
            this.txtNombre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNombre.DefaultText = "";
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.Location = new System.Drawing.Point(110, 72);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PlaceholderText = "Nombre de caja";
            this.txtNombre.Size = new System.Drawing.Size(340, 36);
            this.txtNombre.TabIndex = 3;
            // 
            // labelCodigo
            // 
            this.labelCodigo.AutoSize = true;
            this.labelCodigo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelCodigo.Location = new System.Drawing.Point(14, 42);
            this.labelCodigo.Name = "labelCodigo";
            this.labelCodigo.Size = new System.Drawing.Size(43, 15);
            this.labelCodigo.TabIndex = 0;
            this.labelCodigo.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BorderRadius = 8;
            this.txtCodigo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCodigo.DefaultText = "";
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCodigo.Location = new System.Drawing.Point(110, 32);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.PlaceholderText = "Ej: CAJA01";
            this.txtCodigo.Size = new System.Drawing.Size(170, 36);
            this.txtCodigo.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BorderRadius = 8;
            this.btnGuardar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(110, 188);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(160, 40);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BorderRadius = 8;
            this.btnCancelar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(290, 188);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(160, 40);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // gbAcciones
            // 
            this.gbAcciones.BackColor = System.Drawing.Color.Transparent;
            this.gbAcciones.BorderRadius = 8;
            this.gbAcciones.Controls.Add(this.btnNuevo);
            this.gbAcciones.Controls.Add(this.btnEditar);
            this.gbAcciones.Controls.Add(this.btnActivarDesactivar);
            this.gbAcciones.Controls.Add(this.btnAnular);
            this.gbAcciones.Controls.Add(this.btnVerEstado);
            this.gbAcciones.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.gbAcciones.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbAcciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbAcciones.Location = new System.Drawing.Point(718, 318);
            this.gbAcciones.Name = "gbAcciones";
            this.gbAcciones.Size = new System.Drawing.Size(470, 120);
            this.gbAcciones.TabIndex = 3;
            this.gbAcciones.Text = "Acciones";
            // 
            // btnNuevo
            // 
            this.btnNuevo.BorderRadius = 8;
            this.btnNuevo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(14, 45);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(85, 50);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BorderRadius = 8;
            this.btnEditar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(106, 45);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(85, 50);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnActivarDesactivar
            // 
            this.btnActivarDesactivar.BorderRadius = 8;
            this.btnActivarDesactivar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnActivarDesactivar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnActivarDesactivar.ForeColor = System.Drawing.Color.White;
            this.btnActivarDesactivar.Location = new System.Drawing.Point(198, 45);
            this.btnActivarDesactivar.Name = "btnActivarDesactivar";
            this.btnActivarDesactivar.Size = new System.Drawing.Size(110, 50);
            this.btnActivarDesactivar.TabIndex = 2;
            this.btnActivarDesactivar.Text = "Activar";
            this.btnActivarDesactivar.Click += new System.EventHandler(this.btnActivarDesactivar_Click);
            // 
            // btnAnular
            // 
            this.btnAnular.BorderRadius = 8;
            this.btnAnular.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnAnular.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAnular.ForeColor = System.Drawing.Color.White;
            this.btnAnular.Location = new System.Drawing.Point(315, 45);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(70, 50);
            this.btnAnular.TabIndex = 3;
            this.btnAnular.Text = "Anular";
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btnVerEstado
            // 
            this.btnVerEstado.BorderRadius = 8;
            this.btnVerEstado.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnVerEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnVerEstado.ForeColor = System.Drawing.Color.White;
            this.btnVerEstado.Location = new System.Drawing.Point(392, 45);
            this.btnVerEstado.Name = "btnVerEstado";
            this.btnVerEstado.Size = new System.Drawing.Size(70, 50);
            this.btnVerEstado.TabIndex = 4;
            this.btnVerEstado.Text = "Ver estado";
            this.btnVerEstado.Click += new System.EventHandler(this.btnVerEstado_Click);
            // 
            // gbDetalle
            // 
            this.gbDetalle.BackColor = System.Drawing.Color.Transparent;
            this.gbDetalle.BorderRadius = 8;
            this.gbDetalle.Controls.Add(this.pnlAperturaActiva);
            this.gbDetalle.Controls.Add(this.lblEstadoDetalle);
            this.gbDetalle.Controls.Add(this.lblDescripcionDetalle);
            this.gbDetalle.Controls.Add(this.lblNombreDetalle);
            this.gbDetalle.Controls.Add(this.lblCodigoDetalle);
            this.gbDetalle.Controls.Add(this.lblEstadoLabel);
            this.gbDetalle.Controls.Add(this.lblDescripcionLabel);
            this.gbDetalle.Controls.Add(this.lblNombreLabel);
            this.gbDetalle.Controls.Add(this.lblCodigoLabel);
            this.gbDetalle.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.gbDetalle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbDetalle.Location = new System.Drawing.Point(718, 444);
            this.gbDetalle.Name = "gbDetalle";
            this.gbDetalle.Size = new System.Drawing.Size(470, 170);
            this.gbDetalle.TabIndex = 4;
            this.gbDetalle.Text = "Detalles";
            // 
            // lblEstadoDetalle
            // 
            this.lblEstadoDetalle.AutoSize = true;
            this.lblEstadoDetalle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEstadoDetalle.Location = new System.Drawing.Point(110, 122);
            this.lblEstadoDetalle.Name = "lblEstadoDetalle";
            this.lblEstadoDetalle.Size = new System.Drawing.Size(58, 19);
            this.lblEstadoDetalle.TabIndex = 7;
            this.lblEstadoDetalle.Text = "-";
            // 
            // lblDescripcionDetalle
            // 
            this.lblDescripcionDetalle.AutoSize = true;
            this.lblDescripcionDetalle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescripcionDetalle.Location = new System.Drawing.Point(110, 94);
            this.lblDescripcionDetalle.MaximumSize = new System.Drawing.Size(340, 0);
            this.lblDescripcionDetalle.Name = "lblDescripcionDetalle";
            this.lblDescripcionDetalle.Size = new System.Drawing.Size(12, 15);
            this.lblDescripcionDetalle.TabIndex = 6;
            this.lblDescripcionDetalle.Text = "-";
            // 
            // lblNombreDetalle
            // 
            this.lblNombreDetalle.AutoSize = true;
            this.lblNombreDetalle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombreDetalle.Location = new System.Drawing.Point(110, 66);
            this.lblNombreDetalle.Name = "lblNombreDetalle";
            this.lblNombreDetalle.Size = new System.Drawing.Size(12, 15);
            this.lblNombreDetalle.TabIndex = 5;
            this.lblNombreDetalle.Text = "-";
            // 
            // lblCodigoDetalle
            // 
            this.lblCodigoDetalle.AutoSize = true;
            this.lblCodigoDetalle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCodigoDetalle.Location = new System.Drawing.Point(110, 38);
            this.lblCodigoDetalle.Name = "lblCodigoDetalle";
            this.lblCodigoDetalle.Size = new System.Drawing.Size(12, 15);
            this.lblCodigoDetalle.TabIndex = 4;
            this.lblCodigoDetalle.Text = "-";
            // 
            // lblEstadoLabel
            // 
            this.lblEstadoLabel.AutoSize = true;
            this.lblEstadoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstadoLabel.Location = new System.Drawing.Point(14, 122);
            this.lblEstadoLabel.Name = "lblEstadoLabel";
            this.lblEstadoLabel.Size = new System.Drawing.Size(42, 15);
            this.lblEstadoLabel.TabIndex = 3;
            this.lblEstadoLabel.Text = "Estado";
            // 
            // lblDescripcionLabel
            // 
            this.lblDescripcionLabel.AutoSize = true;
            this.lblDescripcionLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescripcionLabel.Location = new System.Drawing.Point(14, 94);
            this.lblDescripcionLabel.Name = "lblDescripcionLabel";
            this.lblDescripcionLabel.Size = new System.Drawing.Size(69, 15);
            this.lblDescripcionLabel.TabIndex = 2;
            this.lblDescripcionLabel.Text = "Descripción";
            // 
            // lblNombreLabel
            // 
            this.lblNombreLabel.AutoSize = true;
            this.lblNombreLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombreLabel.Location = new System.Drawing.Point(14, 66);
            this.lblNombreLabel.Name = "lblNombreLabel";
            this.lblNombreLabel.Size = new System.Drawing.Size(50, 15);
            this.lblNombreLabel.TabIndex = 1;
            this.lblNombreLabel.Text = "Nombre";
            // 
            // lblCodigoLabel
            // 
            this.lblCodigoLabel.AutoSize = true;
            this.lblCodigoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCodigoLabel.Location = new System.Drawing.Point(14, 38);
            this.lblCodigoLabel.Name = "lblCodigoLabel";
            this.lblCodigoLabel.Size = new System.Drawing.Size(43, 15);
            this.lblCodigoLabel.TabIndex = 0;
            this.lblCodigoLabel.Text = "Código";
            // 
            // pnlAperturaActiva
            // 
            this.pnlAperturaActiva.BorderRadius = 8;
            this.pnlAperturaActiva.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.pnlAperturaActiva.Controls.Add(this.lblSaldoActual);
            this.pnlAperturaActiva.Controls.Add(this.lblUsuarioApertura);
            this.pnlAperturaActiva.Controls.Add(this.lblFechaApertura);
            this.pnlAperturaActiva.Controls.Add(this.labelSaldo);
            this.pnlAperturaActiva.Controls.Add(this.labelUsuario);
            this.pnlAperturaActiva.Controls.Add(this.labelFecha);
            this.pnlAperturaActiva.Location = new System.Drawing.Point(470, 10);
            this.pnlAperturaActiva.Name = "pnlAperturaActiva";
            this.pnlAperturaActiva.Size = new System.Drawing.Size(10, 10);
            this.pnlAperturaActiva.TabIndex = 8;
            this.pnlAperturaActiva.Visible = false;
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelFecha.Location = new System.Drawing.Point(8, 10);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(83, 13);
            this.labelFecha.TabIndex = 0;
            this.labelFecha.Text = "Fecha apertura:";
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelUsuario.Location = new System.Drawing.Point(8, 32);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(47, 13);
            this.labelUsuario.TabIndex = 1;
            this.labelUsuario.Text = "Usuario:";
            // 
            // labelSaldo
            // 
            this.labelSaldo.AutoSize = true;
            this.labelSaldo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelSaldo.Location = new System.Drawing.Point(8, 54);
            this.labelSaldo.Name = "labelSaldo";
            this.labelSaldo.Size = new System.Drawing.Size(36, 13);
            this.labelSaldo.TabIndex = 2;
            this.labelSaldo.Text = "Saldo:";
            // 
            // lblFechaApertura
            // 
            this.lblFechaApertura.AutoSize = true;
            this.lblFechaApertura.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblFechaApertura.Location = new System.Drawing.Point(98, 10);
            this.lblFechaApertura.Name = "lblFechaApertura";
            this.lblFechaApertura.Size = new System.Drawing.Size(12, 13);
            this.lblFechaApertura.TabIndex = 3;
            this.lblFechaApertura.Text = "-";
            // 
            // lblUsuarioApertura
            // 
            this.lblUsuarioApertura.AutoSize = true;
            this.lblUsuarioApertura.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblUsuarioApertura.Location = new System.Drawing.Point(98, 32);
            this.lblUsuarioApertura.Name = "lblUsuarioApertura";
            this.lblUsuarioApertura.Size = new System.Drawing.Size(12, 13);
            this.lblUsuarioApertura.TabIndex = 4;
            this.lblUsuarioApertura.Text = "-";
            // 
            // lblSaldoActual
            // 
            this.lblSaldoActual.AutoSize = true;
            this.lblSaldoActual.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblSaldoActual.Location = new System.Drawing.Point(98, 54);
            this.lblSaldoActual.Name = "lblSaldoActual";
            this.lblSaldoActual.Size = new System.Drawing.Size(12, 13);
            this.lblSaldoActual.TabIndex = 5;
            this.lblSaldoActual.Text = "-";
            // 
            // gbStats
            // 
            this.gbStats.BackColor = System.Drawing.Color.Transparent;
            this.gbStats.BorderRadius = 8;
            this.gbStats.Controls.Add(this.lblDiferenciaPromedioStats);
            this.gbStats.Controls.Add(this.lblTotalEgresosStats);
            this.gbStats.Controls.Add(this.lblTotalIngresosStats);
            this.gbStats.Controls.Add(this.lblTotalCierresStats);
            this.gbStats.Controls.Add(this.labelDifProm);
            this.gbStats.Controls.Add(this.labelEgresos);
            this.gbStats.Controls.Add(this.labelIngresos);
            this.gbStats.Controls.Add(this.labelCierres);
            this.gbStats.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.gbStats.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbStats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbStats.Location = new System.Drawing.Point(718, 620);
            this.gbStats.Name = "gbStats";
            this.gbStats.Size = new System.Drawing.Size(470, 52);
            this.gbStats.TabIndex = 5;
            this.gbStats.Text = "Estadísticas";
            // 
            // labelCierres
            // 
            this.labelCierres.AutoSize = true;
            this.labelCierres.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelCierres.Location = new System.Drawing.Point(12, 28);
            this.labelCierres.Name = "labelCierres";
            this.labelCierres.Size = new System.Drawing.Size(41, 13);
            this.labelCierres.TabIndex = 0;
            this.labelCierres.Text = "Cierres:";
            // 
            // labelIngresos
            // 
            this.labelIngresos.AutoSize = true;
            this.labelIngresos.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelIngresos.Location = new System.Drawing.Point(120, 28);
            this.labelIngresos.Name = "labelIngresos";
            this.labelIngresos.Size = new System.Drawing.Size(48, 13);
            this.labelIngresos.TabIndex = 2;
            this.labelIngresos.Text = "Ingresos:";
            // 
            // labelEgresos
            // 
            this.labelEgresos.AutoSize = true;
            this.labelEgresos.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelEgresos.Location = new System.Drawing.Point(250, 28);
            this.labelEgresos.Name = "labelEgresos";
            this.labelEgresos.Size = new System.Drawing.Size(45, 13);
            this.labelEgresos.TabIndex = 4;
            this.labelEgresos.Text = "Egresos:";
            // 
            // labelDifProm
            // 
            this.labelDifProm.AutoSize = true;
            this.labelDifProm.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelDifProm.Location = new System.Drawing.Point(360, 28);
            this.labelDifProm.Name = "labelDifProm";
            this.labelDifProm.Size = new System.Drawing.Size(60, 13);
            this.labelDifProm.TabIndex = 6;
            this.labelDifProm.Text = "Dif. prom.:";
            // 
            // lblTotalCierresStats
            // 
            this.lblTotalCierresStats.AutoSize = true;
            this.lblTotalCierresStats.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTotalCierresStats.Location = new System.Drawing.Point(58, 28);
            this.lblTotalCierresStats.Name = "lblTotalCierresStats";
            this.lblTotalCierresStats.Size = new System.Drawing.Size(12, 13);
            this.lblTotalCierresStats.TabIndex = 1;
            this.lblTotalCierresStats.Text = "0";
            // 
            // lblTotalIngresosStats
            // 
            this.lblTotalIngresosStats.AutoSize = true;
            this.lblTotalIngresosStats.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTotalIngresosStats.Location = new System.Drawing.Point(174, 28);
            this.lblTotalIngresosStats.Name = "lblTotalIngresosStats";
            this.lblTotalIngresosStats.Size = new System.Drawing.Size(35, 13);
            this.lblTotalIngresosStats.TabIndex = 3;
            this.lblTotalIngresosStats.Text = "$0.00";
            // 
            // lblTotalEgresosStats
            // 
            this.lblTotalEgresosStats.AutoSize = true;
            this.lblTotalEgresosStats.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTotalEgresosStats.Location = new System.Drawing.Point(302, 28);
            this.lblTotalEgresosStats.Name = "lblTotalEgresosStats";
            this.lblTotalEgresosStats.Size = new System.Drawing.Size(35, 13);
            this.lblTotalEgresosStats.TabIndex = 5;
            this.lblTotalEgresosStats.Text = "$0.00";
            // 
            // lblDiferenciaPromedioStats
            // 
            this.lblDiferenciaPromedioStats.AutoSize = true;
            this.lblDiferenciaPromedioStats.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblDiferenciaPromedioStats.Location = new System.Drawing.Point(426, 28);
            this.lblDiferenciaPromedioStats.Name = "lblDiferenciaPromedioStats";
            this.lblDiferenciaPromedioStats.Size = new System.Drawing.Size(35, 13);
            this.lblDiferenciaPromedioStats.TabIndex = 7;
            this.lblDiferenciaPromedioStats.Text = "$0.00";
            // 
            // FrmGestionCajas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 682);
            this.Controls.Add(this.gbStats);
            this.Controls.Add(this.gbDetalle);
            this.Controls.Add(this.gbAcciones);
            this.Controls.Add(this.gbFormulario);
            this.Controls.Add(this.gbListado);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmGestionCajas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Cajas";
            this.Load += new System.EventHandler(this.FrmGestionCajas_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.gbListado.ResumeLayout(false);
            this.gbListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajas)).EndInit();
            this.gbFormulario.ResumeLayout(false);
            this.gbFormulario.PerformLayout();
            this.gbAcciones.ResumeLayout(false);
            this.gbDetalle.ResumeLayout(false);
            this.gbDetalle.PerformLayout();
            this.pnlAperturaActiva.ResumeLayout(false);
            this.pnlAperturaActiva.PerformLayout();
            this.gbStats.ResumeLayout(false);
            this.gbStats.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;
        private Guna.UI2.WinForms.Guna2Button btnCerrar;
        private Guna.UI2.WinForms.Guna2GroupBox gbListado;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCajas;
        private System.Windows.Forms.Label labelBuscar;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private Guna.UI2.WinForms.Guna2CheckBox chkMostrarAnuladas;
        private System.Windows.Forms.Label lblTotalCajas;
        private Guna.UI2.WinForms.Guna2GroupBox gbFormulario;
        private System.Windows.Forms.Label labelCodigo;
        private Guna.UI2.WinForms.Guna2TextBox txtCodigo;
        private System.Windows.Forms.Label labelNombre;
        private Guna.UI2.WinForms.Guna2TextBox txtNombre;
        private System.Windows.Forms.Label labelDescripcion;
        private Guna.UI2.WinForms.Guna2TextBox txtDescripcion;
        private Guna.UI2.WinForms.Guna2CheckBox chkActiva;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;
        private Guna.UI2.WinForms.Guna2GroupBox gbAcciones;
        private Guna.UI2.WinForms.Guna2Button btnNuevo;
        private Guna.UI2.WinForms.Guna2Button btnEditar;
        private Guna.UI2.WinForms.Guna2Button btnActivarDesactivar;
        private Guna.UI2.WinForms.Guna2Button btnAnular;
        private Guna.UI2.WinForms.Guna2Button btnVerEstado;
        private Guna.UI2.WinForms.Guna2GroupBox gbDetalle;
        private System.Windows.Forms.Label lblCodigoLabel;
        private System.Windows.Forms.Label lblNombreLabel;
        private System.Windows.Forms.Label lblDescripcionLabel;
        private System.Windows.Forms.Label lblEstadoLabel;
        private System.Windows.Forms.Label lblCodigoDetalle;
        private System.Windows.Forms.Label lblNombreDetalle;
        private System.Windows.Forms.Label lblDescripcionDetalle;
        private System.Windows.Forms.Label lblEstadoDetalle;
        private Guna.UI2.WinForms.Guna2Panel pnlAperturaActiva;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Label labelSaldo;
        private System.Windows.Forms.Label lblFechaApertura;
        private System.Windows.Forms.Label lblUsuarioApertura;
        private System.Windows.Forms.Label lblSaldoActual;
        private Guna.UI2.WinForms.Guna2GroupBox gbStats;
        private System.Windows.Forms.Label labelCierres;
        private System.Windows.Forms.Label lblTotalCierresStats;
        private System.Windows.Forms.Label labelIngresos;
        private System.Windows.Forms.Label lblTotalIngresosStats;
        private System.Windows.Forms.Label labelEgresos;
        private System.Windows.Forms.Label lblTotalEgresosStats;
        private System.Windows.Forms.Label labelDifProm;
        private System.Windows.Forms.Label lblDiferenciaPromedioStats;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colActiva;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAnulado;
    }
}
