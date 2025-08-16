using FontAwesome.Sharp;

namespace LogiPharm.Presentacion
{
    partial class FrmPuntoDeVenta
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
            this.panelTop = new Guna.UI2.WinForms.Guna2Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCliente = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtIdentificacion = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvDetalleVenta = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colEliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInfo = new System.Windows.Forms.DataGridViewImageColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPorcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDscto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelDerecho = new Guna.UI2.WinForms.Guna2Panel();
            this.panelToolbar = new Guna.UI2.WinForms.Guna2Panel();
            this.btnIncrementar = new Guna.UI2.WinForms.Guna2Button();
            this.btnDocumento = new Guna.UI2.WinForms.Guna2Button();
            this.btnRecargas = new Guna.UI2.WinForms.Guna2Button();
            this.btnMedico = new Guna.UI2.WinForms.Guna2Button();
            this.btnKardex = new Guna.UI2.WinForms.Guna2Button();
            this.btnDescuento = new Guna.UI2.WinForms.Guna2Button();
            this.btnFacturas = new Guna.UI2.WinForms.Guna2Button();
            this.btnNuevo = new Guna.UI2.WinForms.Guna2Button();
            this.btnPagar = new Guna.UI2.WinForms.Guna2Button();
            this.panelPrecios = new Guna.UI2.WinForms.Guna2Panel();
            this.lblIVA = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblTotalDescuento = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblFechaEmision = new System.Windows.Forms.Label();
            this.lblCaja = new System.Windows.Forms.Label();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.lblNumeroFactura = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblFechaCompleta = new System.Windows.Forms.Label();
            this.lblFechaHora = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelTop.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).BeginInit();
            this.panelDerecho.SuspendLayout();
            this.panelToolbar.SuspendLayout();
            this.panelPrecios.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            //this.panelTop.Controls.Add(this.flowLayoutPanel1);
            this.panelTop.Controls.Add(this.label3);
            this.panelTop.Controls.Add(this.txtEmail);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.txtCliente);
            this.panelTop.Controls.Add(this.txtIdentificacion);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panelTop.Size = new System.Drawing.Size(1200, 45);
            this.panelTop.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(688, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "E-mail:";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderThickness = 0;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Location = new System.Drawing.Point(736, 12);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(262, 21);
            this.txtEmail.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datos del Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.BorderThickness = 0;
            this.txtCliente.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCliente.DefaultText = "CONSUMIDOR FINAL";
            this.txtCliente.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCliente.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCliente.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCliente.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCliente.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline);
            this.txtCliente.ForeColor = System.Drawing.Color.Blue;
            this.txtCliente.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCliente.Location = new System.Drawing.Point(380, 12);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.PlaceholderText = "";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.SelectedText = "";
            this.txtCliente.Size = new System.Drawing.Size(288, 21);
            this.txtCliente.TabIndex = 3;
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.BorderRadius = 4;
            this.txtIdentificacion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIdentificacion.DefaultText = "9999999999999";
            this.txtIdentificacion.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtIdentificacion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtIdentificacion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIdentificacion.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIdentificacion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtIdentificacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtIdentificacion.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtIdentificacion.Location = new System.Drawing.Point(118, 12);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.PlaceholderText = "";
            this.txtIdentificacion.SelectedText = "";
            this.txtIdentificacion.Size = new System.Drawing.Size(155, 21);
            this.txtIdentificacion.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(328, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cliente:";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.dgvDetalleVenta);
            this.panelMain.Controls.Add(this.panelDerecho);
            this.panelMain.Controls.Add(this.flowLayoutPanel1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 45);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(10);
            this.panelMain.Size = new System.Drawing.Size(1200, 521);
            this.panelMain.TabIndex = 1;
            // 
            // dgvDetalleVenta
            // 
            this.dgvDetalleVenta.AllowUserToDeleteRows = false;
            this.dgvDetalleVenta.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDetalleVenta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalleVenta.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleVenta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetalleVenta.ColumnHeadersHeight = 40;
            this.dgvDetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDetalleVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEliminar,
            this.colCodigo,
            this.colProducto,
            this.colInfo,
            this.colCantidad,
            this.colPrecio,
            this.colPFinal,
            this.colPorcentaje,
            this.colDscto,
            this.colIVA,
            this.colSubtotal,
            this.colTotal});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalleVenta.DefaultCellStyle = dataGridViewCellStyle3;
            //.dgvDetalleVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalleVenta.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            //this.dgvDetalleVenta.Location = new System.Drawing.Point(10, 55);
            this.dgvDetalleVenta.Name = "dgvDetalleVenta";
            this.dgvDetalleVenta.RowHeadersVisible = false;
            this.dgvDetalleVenta.RowTemplate.Height = 35;
            // this.dgvDetalleVenta.Size = new System.Drawing.Size(790, 456);
            this.dgvDetalleVenta.Dock = System.Windows.Forms.DockStyle.Fill;

            this.dgvDetalleVenta.TabIndex = 0;
            this.dgvDetalleVenta.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetalleVenta.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetalleVenta.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvDetalleVenta.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetalleVenta.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDetalleVenta.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetalleVenta.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetalleVenta.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvDetalleVenta.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetalleVenta.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetalleVenta.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDetalleVenta.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDetalleVenta.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvDetalleVenta.ThemeStyle.ReadOnly = false;
            this.dgvDetalleVenta.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetalleVenta.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDetalleVenta.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetalleVenta.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDetalleVenta.ThemeStyle.RowsStyle.Height = 35;
            this.dgvDetalleVenta.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetalleVenta.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // colEliminar
            // 
            this.colEliminar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colEliminar.HeaderText = "";
            this.colEliminar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colEliminar.Name = "colEliminar";
            this.colEliminar.Width = 40;
            // 
            // colCodigo
            // 
            this.colCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.Width = 120;
            // 
            // colProducto
            // 
            this.colProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProducto.HeaderText = "Producto/Item";
            this.colProducto.Name = "colProducto";
            // 
            // colInfo
            // 
            this.colInfo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colInfo.HeaderText = "Info";
            this.colInfo.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colInfo.Name = "colInfo";
            this.colInfo.Width = 40;
            // 
            // colCantidad
            // 
            this.colCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colCantidad.HeaderText = "Cant.";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Width = 60;
            // 
            // colPrecio
            // 
            this.colPrecio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colPrecio.HeaderText = "P. Unitario";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.Width = 80;
            // 
            // colPFinal
            // 
            this.colPFinal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colPFinal.HeaderText = "P.Final";
            this.colPFinal.Name = "colPFinal";
            this.colPFinal.Visible = false;
            this.colPFinal.Width = 80;
            // 
            // colPorcentaje
            // 
            this.colPorcentaje.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colPorcentaje.HeaderText = "%";
            this.colPorcentaje.Name = "colPorcentaje";
            this.colPorcentaje.Visible = false;
            this.colPorcentaje.Width = 40;
            // 
            // colDscto
            // 
            this.colDscto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDscto.HeaderText = "Dsct.%";
            this.colDscto.Name = "colDscto";
            this.colDscto.Visible = false;
            this.colDscto.Width = 60;
            // 
            // colIVA
            // 
            this.colIVA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colIVA.HeaderText = "I.V.A";
            this.colIVA.Name = "colIVA";
            this.colIVA.Width = 60;
            // 
            // colSubtotal
            // 
            this.colSubtotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colSubtotal.HeaderText = "Subtotal";
            this.colSubtotal.Name = "colSubtotal";
            this.colSubtotal.Width = 90;
            // 
            // colTotal
            // 
            this.colTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.Width = 90;
            // 
            // panelDerecho
            // 
            this.panelDerecho.Controls.Add(this.panelToolbar);
            this.panelDerecho.Controls.Add(this.panelPrecios);
            this.panelDerecho.Controls.Add(this.guna2GroupBox1);
            this.panelDerecho.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDerecho.Location = new System.Drawing.Point(800, 10);
            this.panelDerecho.Name = "panelDerecho";
            this.panelDerecho.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panelDerecho.Size = new System.Drawing.Size(390, 501);
            this.panelDerecho.TabIndex = 1;
            // 
            // panelToolbar
            // 
            this.panelToolbar.Controls.Add(this.btnIncrementar);
            this.panelToolbar.Controls.Add(this.btnDocumento);
            this.panelToolbar.Controls.Add(this.btnRecargas);
            this.panelToolbar.Controls.Add(this.btnMedico);
            this.panelToolbar.Controls.Add(this.btnKardex);
            this.panelToolbar.Controls.Add(this.btnDescuento);
            this.panelToolbar.Controls.Add(this.btnFacturas);
            this.panelToolbar.Controls.Add(this.btnNuevo);
            this.panelToolbar.Controls.Add(this.btnPagar);
            this.panelToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelToolbar.Location = new System.Drawing.Point(10, 317);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(380, 184);
            this.panelToolbar.TabIndex = 5;
            // 
            // btnIncrementar
            // 
            this.btnIncrementar.BorderRadius = 8;
            this.btnIncrementar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnIncrementar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnIncrementar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnIncrementar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnIncrementar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnIncrementar.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnIncrementar.ForeColor = System.Drawing.Color.White;
            this.btnIncrementar.ImageSize = new System.Drawing.Size(24, 24);
            this.btnIncrementar.Location = new System.Drawing.Point(253, 63);
            this.btnIncrementar.Name = "btnIncrementar";
            this.btnIncrementar.Size = new System.Drawing.Size(115, 54);
            this.btnIncrementar.TabIndex = 8;
            this.btnIncrementar.Text = "F12 INCREMEN";
            // 
            // btnDocumento
            // 
            this.btnDocumento.BorderRadius = 8;
            this.btnDocumento.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDocumento.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDocumento.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDocumento.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDocumento.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnDocumento.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnDocumento.ForeColor = System.Drawing.Color.White;
            this.btnDocumento.ImageSize = new System.Drawing.Size(24, 24);
            this.btnDocumento.Location = new System.Drawing.Point(132, 63);
            this.btnDocumento.Name = "btnDocumento";
            this.btnDocumento.Size = new System.Drawing.Size(115, 54);
            this.btnDocumento.TabIndex = 7;
            this.btnDocumento.Text = "F11 DOCUMENT";
            // 
            // btnRecargas
            // 
            this.btnRecargas.BorderRadius = 8;
            this.btnRecargas.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRecargas.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRecargas.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRecargas.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRecargas.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnRecargas.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnRecargas.ForeColor = System.Drawing.Color.White;
            this.btnRecargas.ImageSize = new System.Drawing.Size(24, 24);
            this.btnRecargas.Location = new System.Drawing.Point(11, 63);
            this.btnRecargas.Name = "btnRecargas";
            this.btnRecargas.Size = new System.Drawing.Size(115, 54);
            this.btnRecargas.TabIndex = 6;
            this.btnRecargas.Text = "F10 RECARGAS";
            // 
            // btnMedico
            // 
            this.btnMedico.BorderRadius = 8;
            this.btnMedico.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMedico.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMedico.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMedico.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMedico.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnMedico.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnMedico.ForeColor = System.Drawing.Color.White;
            this.btnMedico.ImageSize = new System.Drawing.Size(24, 24);
            this.btnMedico.Location = new System.Drawing.Point(253, 3);
            this.btnMedico.Name = "btnMedico";
            this.btnMedico.Size = new System.Drawing.Size(115, 54);
            this.btnMedico.TabIndex = 5;
            this.btnMedico.Text = "F9 MEDICO";
            // 
            // btnKardex
            // 
            this.btnKardex.BorderRadius = 8;
            this.btnKardex.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnKardex.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnKardex.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKardex.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnKardex.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnKardex.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnKardex.ForeColor = System.Drawing.Color.White;
            this.btnKardex.ImageSize = new System.Drawing.Size(24, 24);
            this.btnKardex.Location = new System.Drawing.Point(132, 3);
            this.btnKardex.Name = "btnKardex";
            this.btnKardex.Size = new System.Drawing.Size(115, 54);
            this.btnKardex.TabIndex = 4;
            this.btnKardex.Text = "F8 KARDEX";
            this.btnKardex.Click += new System.EventHandler(this.btnKardex_Click);
            // 
            // btnDescuento
            // 
            this.btnDescuento.BorderRadius = 8;
            this.btnDescuento.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDescuento.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDescuento.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDescuento.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDescuento.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnDescuento.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnDescuento.ForeColor = System.Drawing.Color.Black;
            this.btnDescuento.ImageSize = new System.Drawing.Size(24, 24);
            this.btnDescuento.Location = new System.Drawing.Point(11, 3);
            this.btnDescuento.Name = "btnDescuento";
            this.btnDescuento.Size = new System.Drawing.Size(115, 54);
            this.btnDescuento.TabIndex = 3;
            this.btnDescuento.Text = "F7 DESCUENTO";
            // 
            // btnFacturas
            // 
            this.btnFacturas.BorderRadius = 8;
            this.btnFacturas.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFacturas.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFacturas.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFacturas.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFacturas.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnFacturas.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnFacturas.ForeColor = System.Drawing.Color.White;
            this.btnFacturas.ImageSize = new System.Drawing.Size(24, 24);
            this.btnFacturas.Location = new System.Drawing.Point(132, 123);
            this.btnFacturas.Name = "btnFacturas";
            this.btnFacturas.Size = new System.Drawing.Size(115, 54);
            this.btnFacturas.TabIndex = 1;
            this.btnFacturas.Text = "F3 FACTURAS";
            this.btnFacturas.Click += new System.EventHandler(this.btnFacturas_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BorderRadius = 8;
            this.btnNuevo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNuevo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNuevo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNuevo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNuevo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.ImageSize = new System.Drawing.Size(24, 24);
            this.btnNuevo.Location = new System.Drawing.Point(11, 123);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(115, 54);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "SHIFT F2 NUEVO";
            // 
            // btnPagar
            // 
            this.btnPagar.BorderRadius = 8;
            this.btnPagar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPagar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPagar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPagar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPagar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnPagar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPagar.ForeColor = System.Drawing.Color.White;
            this.btnPagar.ImageSize = new System.Drawing.Size(32, 32);
            this.btnPagar.Location = new System.Drawing.Point(253, 123);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(115, 54);
            this.btnPagar.TabIndex = 2;
            this.btnPagar.Text = "F4 PAGAR";
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // panelPrecios
            // 
            this.panelPrecios.Controls.Add(this.lblIVA);
            this.panelPrecios.Controls.Add(this.label24);
            this.panelPrecios.Controls.Add(this.label23);
            this.panelPrecios.Controls.Add(this.label22);
            this.panelPrecios.Controls.Add(this.label21);
            this.panelPrecios.Controls.Add(this.lblTotalDescuento);
            this.panelPrecios.Controls.Add(this.label19);
            this.panelPrecios.Controls.Add(this.guna2Panel4);
            this.panelPrecios.Controls.Add(this.guna2Panel3);
            this.panelPrecios.Controls.Add(this.guna2Panel2);
            this.panelPrecios.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPrecios.Location = new System.Drawing.Point(10, 192);
            this.panelPrecios.Name = "panelPrecios";
            this.panelPrecios.Size = new System.Drawing.Size(380, 125);
            this.panelPrecios.TabIndex = 4;
            // 
            // lblIVA
            // 
            this.lblIVA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIVA.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIVA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblIVA.Location = new System.Drawing.Point(293, 98);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(74, 17);
            this.lblIVA.TabIndex = 9;
            this.lblIVA.Text = "0.00";
            this.lblIVA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label24.Location = new System.Drawing.Point(293, 76);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(74, 17);
            this.label24.TabIndex = 8;
            this.label24.Text = "0.00";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(139, 98);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(47, 13);
            this.label23.TabIndex = 7;
            this.label23.Text = "IVA 15%";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(139, 78);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(68, 13);
            this.label22.TabIndex = 6;
            this.label22.Text = "TARIFA 15%";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(11, 78);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(62, 13);
            this.label21.TabIndex = 5;
            this.label21.Text = "TARIFA 0%";
            // 
            // lblTotalDescuento
            // 
            this.lblTotalDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalDescuento.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDescuento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotalDescuento.Location = new System.Drawing.Point(250, 56);
            this.lblTotalDescuento.Name = "lblTotalDescuento";
            this.lblTotalDescuento.Size = new System.Drawing.Size(117, 17);
            this.lblTotalDescuento.TabIndex = 4;
            this.lblTotalDescuento.Text = "0.00";
            this.lblTotalDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label19.Location = new System.Drawing.Point(11, 56);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(117, 17);
            this.label19.TabIndex = 3;
            this.label19.Text = "Total descuento $";
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BackColor = System.Drawing.Color.White;
            this.guna2Panel4.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2Panel4.BorderRadius = 6;
            this.guna2Panel4.BorderThickness = 1;
            this.guna2Panel4.Controls.Add(this.label15);
            this.guna2Panel4.Controls.Add(this.label16);
            this.guna2Panel4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(101)))), ((int)(((byte)(115)))));
            this.guna2Panel4.Location = new System.Drawing.Point(253, 3);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(115, 50);
            this.guna2Panel4.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(3, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(109, 21);
            this.label15.TabIndex = 1;
            this.label15.Text = "0.00";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(3, 5);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(109, 15);
            this.label16.TabIndex = 0;
            this.label16.Text = "PRECIO TAR";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.White;
            this.guna2Panel3.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2Panel3.BorderRadius = 6;
            this.guna2Panel3.BorderThickness = 1;
            this.guna2Panel3.Controls.Add(this.label13);
            this.guna2Panel3.Controls.Add(this.label14);
            this.guna2Panel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.guna2Panel3.Location = new System.Drawing.Point(132, 3);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(115, 50);
            this.guna2Panel3.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(3, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 21);
            this.label13.TabIndex = 1;
            this.label13.Text = "0.00";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(3, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 15);
            this.label14.TabIndex = 0;
            this.label14.Text = "PRECIO EFE";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.White;
            this.guna2Panel2.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2Panel2.BorderRadius = 6;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.lblPrecio);
            this.guna2Panel2.Controls.Add(this.label18);
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.guna2Panel2.Location = new System.Drawing.Point(11, 3);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(115, 50);
            this.guna2Panel2.TabIndex = 0;
            // 
            // lblPrecio
            // 
            this.lblPrecio.BackColor = System.Drawing.Color.Transparent;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPrecio.ForeColor = System.Drawing.Color.White;
            this.lblPrecio.Location = new System.Drawing.Point(3, 23);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(109, 21);
            this.lblPrecio.TabIndex = 1;
            this.lblPrecio.Text = "0.00";
            this.lblPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(3, 5);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(109, 15);
            this.label18.TabIndex = 0;
            this.label18.Text = "PRECIO";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2GroupBox1.BorderRadius = 8;
            this.guna2GroupBox1.Controls.Add(this.lblFechaEmision);
            this.guna2GroupBox1.Controls.Add(this.lblCaja);
            this.guna2GroupBox1.Controls.Add(this.lblVendedor);
            this.guna2GroupBox1.Controls.Add(this.lblNumeroFactura);
            this.guna2GroupBox1.Controls.Add(this.label10);
            this.guna2GroupBox1.Controls.Add(this.label6);
            this.guna2GroupBox1.Controls.Add(this.label5);
            this.guna2GroupBox1.Controls.Add(this.label4);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.guna2GroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(10, 0);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.ShadowDecoration.BorderRadius = 12;
            this.guna2GroupBox1.ShadowDecoration.Color = System.Drawing.Color.LightGray;
            this.guna2GroupBox1.ShadowDecoration.Depth = 5;
            this.guna2GroupBox1.ShadowDecoration.Enabled = true;
            this.guna2GroupBox1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.guna2GroupBox1.Size = new System.Drawing.Size(380, 192);
            this.guna2GroupBox1.TabIndex = 3;
            this.guna2GroupBox1.Text = "FACTURACIÓN ELECTRÓNICA";
            // 
            // lblFechaEmision
            // 
            this.lblFechaEmision.AutoSize = true;
            this.lblFechaEmision.BackColor = System.Drawing.Color.White;
            this.lblFechaEmision.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaEmision.Location = new System.Drawing.Point(120, 143);
            this.lblFechaEmision.Name = "lblFechaEmision";
            this.lblFechaEmision.Size = new System.Drawing.Size(65, 15);
            this.lblFechaEmision.TabIndex = 7;
            this.lblFechaEmision.Text = "25/04/2025";
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.BackColor = System.Drawing.Color.White;
            this.lblCaja.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCaja.Location = new System.Drawing.Point(245, 118);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(57, 15);
            this.lblCaja.TabIndex = 6;
            this.lblCaja.Text = "CAJA 001";
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.BackColor = System.Drawing.Color.White;
            this.lblVendedor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVendedor.Location = new System.Drawing.Point(120, 118);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(35, 15);
            this.lblVendedor.TabIndex = 5;
            this.lblVendedor.Text = "dloor";
            // 
            // lblNumeroFactura
            // 
            this.lblNumeroFactura.AutoSize = true;
            this.lblNumeroFactura.BackColor = System.Drawing.Color.White;
            this.lblNumeroFactura.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNumeroFactura.Location = new System.Drawing.Point(14, 88);
            this.lblNumeroFactura.Name = "lblNumeroFactura";
            this.lblNumeroFactura.Size = new System.Drawing.Size(159, 21);
            this.lblNumeroFactura.TabIndex = 4;
            this.lblNumeroFactura.Text = "002011 - 000000488";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(15, 143);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 15);
            this.label10.TabIndex = 3;
            this.label10.Text = "Fecha de emisión:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(208, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Caja:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(15, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Vendedor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.Location = new System.Drawing.Point(15, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(271, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "CONTRIBUYENTE NEGOCIO POPULAR - RÉGIMEN";
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.guna2Panel1);
            this.panelBottom.Controls.Add(this.lblFechaCompleta);
            this.panelBottom.Controls.Add(this.lblFechaHora);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 566);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1200, 55);
            this.panelBottom.TabIndex = 3;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.label12);
            this.guna2Panel1.Controls.Add(this.label8);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1200, 25);
            this.guna2Panel1.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(13, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 15);
            this.label12.TabIndex = 1;
            this.label12.Text = "KPI";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(234, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(172, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "AMBIENTE SRI: PRODUCCIÓN";
            // 
            // lblFechaCompleta
            // 
            this.lblFechaCompleta.AutoSize = true;
            this.lblFechaCompleta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCompleta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFechaCompleta.Location = new System.Drawing.Point(155, 28);
            this.lblFechaCompleta.Name = "lblFechaCompleta";
            this.lblFechaCompleta.Size = new System.Drawing.Size(0, 21);
            this.lblFechaCompleta.TabIndex = 2;
            // 
            // lblFechaHora
            // 
            this.lblFechaHora.AutoSize = true;
            this.lblFechaHora.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFechaHora.Location = new System.Drawing.Point(12, 25);
            this.lblFechaHora.Name = "lblFechaHora";
            this.lblFechaHora.Size = new System.Drawing.Size(88, 25);
            this.lblFechaHora.TabIndex = 0;
            this.lblFechaHora.Text = "17:54:22";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top; // Lo ancla arriba del panel principal
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(780, 40); // Le damos una altura fija
            this.flowLayoutPanel1.TabIndex = 2;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // FrmPuntoDeVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1200, 621);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Name = "FrmPuntoDeVenta";
            this.Text = "Punto de Venta";
            this.Load += new System.EventHandler(this.FrmPuntoDeVenta_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).EndInit();
            this.panelDerecho.ResumeLayout(false);
            this.panelToolbar.ResumeLayout(false);
            this.panelPrecios.ResumeLayout(false);
            this.panelPrecios.PerformLayout();
            this.guna2Panel4.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel panelDerecho;
        private Guna.UI2.WinForms.Guna2Button btnIncrementar;
        private Guna.UI2.WinForms.Guna2Button btnDocumento;
        private Guna.UI2.WinForms.Guna2Button btnRecargas;
        private Guna.UI2.WinForms.Guna2Button btnMedico;
        private Guna.UI2.WinForms.Guna2Button btnKardex;
        private Guna.UI2.WinForms.Guna2Button btnDescuento;
        private Guna.UI2.WinForms.Guna2Button btnPagar;
        private Guna.UI2.WinForms.Guna2Button btnFacturas;
        private Guna.UI2.WinForms.Guna2Button btnNuevo;
        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private Guna.UI2.WinForms.Guna2Panel panelBottom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtCliente;
        private Guna.UI2.WinForms.Guna2TextBox txtIdentificacion;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDetalleVenta;
        private System.Windows.Forms.Label lblFechaHora;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.Label lblFechaEmision;
        private System.Windows.Forms.Label lblCaja;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.Label lblNumeroFactura;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Panel panelPrecios;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2Panel panelToolbar;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblTotalDescuento;
        private System.Windows.Forms.Label label19;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridViewImageColumn colEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewImageColumn colInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPorcentaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDscto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.Label lblFechaCompleta;
        private System.Windows.Forms.Label lblIVA;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
