namespace LogiPharm.Presentacion
{
    partial class FrmAsignarProductoPercha
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
            this.panelContenido = new Guna.UI2.WinForms.Guna2Panel();
            this.groupUbicacion = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtObservaciones = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblProductoSeleccionado = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numColumna = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numFila = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBusqueda = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dgvProductos = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txtBusqueda = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupInfo = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblCapacidad = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPercha = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelBotones = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            this.btnAsignar = new Guna.UI2.WinForms.Guna2Button();
            this.panelContenido.SuspendLayout();
            this.groupUbicacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numColumna)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFila)).BeginInit();
            this.groupBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.groupInfo.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContenido
            // 
            this.panelContenido.BackColor = System.Drawing.Color.White;
            this.panelContenido.Controls.Add(this.groupUbicacion);
            this.panelContenido.Controls.Add(this.groupBusqueda);
            this.panelContenido.Controls.Add(this.groupInfo);
            this.panelContenido.Controls.Add(this.lblTitulo);
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(0, 0);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Padding = new System.Windows.Forms.Padding(20);
            this.panelContenido.Size = new System.Drawing.Size(700, 650);
            this.panelContenido.TabIndex = 0;
            // 
            // groupUbicacion
            // 
            this.groupUbicacion.BorderColor = System.Drawing.Color.LightGray;
            this.groupUbicacion.BorderRadius = 8;
            this.groupUbicacion.Controls.Add(this.txtObservaciones);
            this.groupUbicacion.Controls.Add(this.label7);
            this.groupUbicacion.Controls.Add(this.lblProductoSeleccionado);
            this.groupUbicacion.Controls.Add(this.label6);
            this.groupUbicacion.Controls.Add(this.numColumna);
            this.groupUbicacion.Controls.Add(this.label5);
            this.groupUbicacion.Controls.Add(this.numFila);
            this.groupUbicacion.Controls.Add(this.label4);
            this.groupUbicacion.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.groupUbicacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupUbicacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupUbicacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupUbicacion.Location = new System.Drawing.Point(20, 395);
            this.groupUbicacion.Name = "groupUbicacion";
            this.groupUbicacion.Size = new System.Drawing.Size(660, 235);
            this.groupUbicacion.TabIndex = 3;
            this.groupUbicacion.Text = "Ubicación en la Percha";
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
            this.txtObservaciones.Location = new System.Drawing.Point(345, 115);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.PlaceholderText = "";
            this.txtObservaciones.SelectedText = "";
            this.txtObservaciones.Size = new System.Drawing.Size(295, 55);
            this.txtObservaciones.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.Location = new System.Drawing.Point(345, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Observaciones:";
            // 
            // lblProductoSeleccionado
            // 
            this.lblProductoSeleccionado.BackColor = System.Drawing.Color.Transparent;
            this.lblProductoSeleccionado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProductoSeleccionado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lblProductoSeleccionado.Location = new System.Drawing.Point(20, 65);
            this.lblProductoSeleccionado.Name = "lblProductoSeleccionado";
            this.lblProductoSeleccionado.Size = new System.Drawing.Size(620, 17);
            this.lblProductoSeleccionado.TabIndex = 5;
            this.lblProductoSeleccionado.Text = "Seleccione un producto de la lista";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.Location = new System.Drawing.Point(20, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Producto seleccionado:";
            // 
            // numColumna
            // 
            this.numColumna.BackColor = System.Drawing.Color.Transparent;
            this.numColumna.BorderRadius = 6;
            this.numColumna.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numColumna.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numColumna.Location = new System.Drawing.Point(162, 134);
            this.numColumna.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numColumna.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numColumna.Name = "numColumna";
            this.numColumna.Size = new System.Drawing.Size(160, 36);
            this.numColumna.TabIndex = 3;
            this.numColumna.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.Location = new System.Drawing.Point(20, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Columna:";
            // 
            // numFila
            // 
            this.numFila.BackColor = System.Drawing.Color.Transparent;
            this.numFila.BorderRadius = 6;
            this.numFila.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numFila.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numFila.Location = new System.Drawing.Point(162, 92);
            this.numFila.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numFila.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFila.Name = "numFila";
            this.numFila.Size = new System.Drawing.Size(160, 36);
            this.numFila.TabIndex = 1;
            this.numFila.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.Location = new System.Drawing.Point(20, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Fila:";
            // 
            // groupBusqueda
            // 
            this.groupBusqueda.BorderColor = System.Drawing.Color.LightGray;
            this.groupBusqueda.BorderRadius = 8;
            this.groupBusqueda.Controls.Add(this.dgvProductos);
            this.groupBusqueda.Controls.Add(this.txtBusqueda);
            this.groupBusqueda.Controls.Add(this.label3);
            this.groupBusqueda.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.groupBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBusqueda.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBusqueda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBusqueda.Location = new System.Drawing.Point(20, 135);
            this.groupBusqueda.Name = "groupBusqueda";
            this.groupBusqueda.Size = new System.Drawing.Size(660, 260);
            this.groupBusqueda.TabIndex = 2;
            this.groupBusqueda.Text = "Buscar Producto";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvProductos.ColumnHeadersHeight = 22;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductos.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvProductos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvProductos.Location = new System.Drawing.Point(20, 95);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.Size = new System.Drawing.Size(620, 150);
            this.dgvProductos.TabIndex = 2;
            this.dgvProductos.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvProductos.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvProductos.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvProductos.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvProductos.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvProductos.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvProductos.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvProductos.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvProductos.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvProductos.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProductos.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvProductos.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProductos.ThemeStyle.HeaderStyle.Height = 22;
            this.dgvProductos.ThemeStyle.ReadOnly = true;
            this.dgvProductos.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvProductos.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProductos.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProductos.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvProductos.ThemeStyle.RowsStyle.Height = 22;
            this.dgvProductos.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvProductos.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.BorderRadius = 6;
            this.txtBusqueda.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBusqueda.DefaultText = "";
            this.txtBusqueda.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBusqueda.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBusqueda.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBusqueda.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBusqueda.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBusqueda.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBusqueda.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBusqueda.Location = new System.Drawing.Point(162, 47);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.PlaceholderText = "Buscar por código o nombre...";
            this.txtBusqueda.SelectedText = "";
            this.txtBusqueda.Size = new System.Drawing.Size(478, 36);
            this.txtBusqueda.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(20, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Buscar producto (F3)";
            // 
            // groupInfo
            // 
            this.groupInfo.BorderColor = System.Drawing.Color.LightGray;
            this.groupInfo.BorderRadius = 8;
            this.groupInfo.Controls.Add(this.lblCapacidad);
            this.groupInfo.Controls.Add(this.label8);
            this.groupInfo.Controls.Add(this.lblPercha);
            this.groupInfo.Controls.Add(this.label2);
            this.groupInfo.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.groupInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupInfo.Location = new System.Drawing.Point(20, 50);
            this.groupInfo.Name = "groupInfo";
            this.groupInfo.Size = new System.Drawing.Size(660, 85);
            this.groupInfo.TabIndex = 1;
            this.groupInfo.Text = "Información de la Percha";
            // 
            // lblCapacidad
            // 
            this.lblCapacidad.BackColor = System.Drawing.Color.Transparent;
            this.lblCapacidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCapacidad.Location = new System.Drawing.Point(430, 55);
            this.lblCapacidad.Name = "lblCapacidad";
            this.lblCapacidad.Size = new System.Drawing.Size(200, 17);
            this.lblCapacidad.TabIndex = 3;
            this.lblCapacidad.Text = "...";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(430, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "Capacidad:";
            // 
            // lblPercha
            // 
            this.lblPercha.BackColor = System.Drawing.Color.Transparent;
            this.lblPercha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPercha.Location = new System.Drawing.Point(20, 55);
            this.lblPercha.Name = "lblPercha";
            this.lblPercha.Size = new System.Drawing.Size(400, 17);
            this.lblPercha.TabIndex = 1;
            this.lblPercha.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(20, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Percha:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(660, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Asignar Producto a Percha";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBotones
            // 
            this.panelBotones.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelBotones.Controls.Add(this.btnCancelar);
            this.panelBotones.Controls.Add(this.btnAsignar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(0, 590);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Padding = new System.Windows.Forms.Padding(15);
            this.panelBotones.Size = new System.Drawing.Size(700, 60);
            this.panelBotones.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BorderRadius = 6;
            this.btnCancelar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancelar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancelar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(431, 12);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 36);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            // 
            // btnAsignar
            // 
            this.btnAsignar.BorderRadius = 6;
            this.btnAsignar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAsignar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAsignar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAsignar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAsignar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAsignar.ForeColor = System.Drawing.Color.White;
            this.btnAsignar.Location = new System.Drawing.Point(557, 12);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(120, 36);
            this.btnAsignar.TabIndex = 0;
            this.btnAsignar.Text = "Asignar";
            // 
            // FrmAsignarProductoPercha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 650);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelContenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAsignarProductoPercha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Asignar Producto a Percha";
            this.panelContenido.ResumeLayout(false);
            this.groupUbicacion.ResumeLayout(false);
            this.groupUbicacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numColumna)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFila)).EndInit();
            this.groupBusqueda.ResumeLayout(false);
            this.groupBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.groupInfo.ResumeLayout(false);
            this.groupInfo.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Panel panelContenido;
        private System.Windows.Forms.Label lblTitulo;
        private Guna.UI2.WinForms.Guna2GroupBox groupInfo;
        private System.Windows.Forms.Label lblPercha;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2GroupBox groupBusqueda;
        private Guna.UI2.WinForms.Guna2TextBox txtBusqueda;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2DataGridView dgvProductos;
        private Guna.UI2.WinForms.Guna2GroupBox groupUbicacion;
        private Guna.UI2.WinForms.Guna2NumericUpDown numFila;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2NumericUpDown numColumna;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblProductoSeleccionado;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txtObservaciones;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2Panel panelBotones;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;
        private Guna.UI2.WinForms.Guna2Button btnAsignar;
        private System.Windows.Forms.Label lblCapacidad;
        private System.Windows.Forms.Label label8;
    }
}
