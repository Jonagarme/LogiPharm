namespace LogiPharm.Presentacion
{
    partial class FrmConfiguracionProductoXML
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
            this.panelPrincipal = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.groupInfo = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoPrincipal = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescripcion = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblProductoEncontrado = new System.Windows.Forms.Label();
            this.groupPrecios = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numCostoPorUnidad = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numCostoPorCaja = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numPVPUnidad = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.panelFraccionamiento = new Guna.UI2.WinForms.Guna2Panel();
            this.chkEsFraccionable = new Guna.UI2.WinForms.Guna2CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numDivision = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.lblNotaFraccionamiento = new System.Windows.Forms.Label();
            this.groupResumen = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMargen = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblGanancia = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblValorInventario = new System.Windows.Forms.Label();
            this.lblEstadoProducto = new System.Windows.Forms.Label();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            this.panelPrincipal.SuspendLayout();
            this.groupInfo.SuspendLayout();
            this.groupPrecios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCostoPorUnidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCostoPorCaja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPVPUnidad)).BeginInit();
            this.panelFraccionamiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDivision)).BeginInit();
            this.groupResumen.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.Color.White;
            this.panelPrincipal.Controls.Add(this.btnCancelar);
            this.panelPrincipal.Controls.Add(this.btnGuardar);
            this.panelPrincipal.Controls.Add(this.groupResumen);
            this.panelPrincipal.Controls.Add(this.panelFraccionamiento);
            this.panelPrincipal.Controls.Add(this.groupPrecios);
            this.panelPrincipal.Controls.Add(this.groupInfo);
            this.panelPrincipal.Controls.Add(this.lblTitulo);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(600, 700);
            this.panelPrincipal.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(350, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Configuración de Precios y Costos";
            // 
            // groupInfo
            // 
            this.groupInfo.BorderRadius = 8;
            this.groupInfo.Controls.Add(this.lblProductoEncontrado);
            this.groupInfo.Controls.Add(this.txtDescripcion);
            this.groupInfo.Controls.Add(this.label2);
            this.groupInfo.Controls.Add(this.txtCodigoPrincipal);
            this.groupInfo.Controls.Add(this.label1);
            this.groupInfo.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.groupInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupInfo.ForeColor = System.Drawing.Color.White;
            this.groupInfo.Location = new System.Drawing.Point(20, 70);
            this.groupInfo.Name = "groupInfo";
            this.groupInfo.Size = new System.Drawing.Size(560, 140);
            this.groupInfo.TabIndex = 1;
            this.groupInfo.Text = "Información del Producto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(15, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // txtCodigoPrincipal
            // 
            this.txtCodigoPrincipal.BorderRadius = 6;
            this.txtCodigoPrincipal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCodigoPrincipal.DefaultText = "";
            this.txtCodigoPrincipal.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCodigoPrincipal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCodigoPrincipal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCodigoPrincipal.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCodigoPrincipal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCodigoPrincipal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCodigoPrincipal.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCodigoPrincipal.Location = new System.Drawing.Point(120, 47);
            this.txtCodigoPrincipal.Name = "txtCodigoPrincipal";
            this.txtCodigoPrincipal.PasswordChar = '\0';
            this.txtCodigoPrincipal.PlaceholderText = "";
            this.txtCodigoPrincipal.ReadOnly = true;
            this.txtCodigoPrincipal.SelectedText = "";
            this.txtCodigoPrincipal.Size = new System.Drawing.Size(180, 30);
            this.txtCodigoPrincipal.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(15, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderRadius = 6;
            this.txtDescripcion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescripcion.DefaultText = "";
            this.txtDescripcion.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDescripcion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDescripcion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescripcion.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescripcion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescripcion.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescripcion.Location = new System.Drawing.Point(120, 87);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.PasswordChar = '\0';
            this.txtDescripcion.PlaceholderText = "";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.SelectedText = "";
            this.txtDescripcion.Size = new System.Drawing.Size(420, 30);
            this.txtDescripcion.TabIndex = 3;
            // 
            // lblProductoEncontrado
            // 
            this.lblProductoEncontrado.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblProductoEncontrado.ForeColor = System.Drawing.Color.Gray;
            this.lblProductoEncontrado.Location = new System.Drawing.Point(320, 50);
            this.lblProductoEncontrado.Name = "lblProductoEncontrado";
            this.lblProductoEncontrado.Size = new System.Drawing.Size(220, 30);
            this.lblProductoEncontrado.TabIndex = 4;
            this.lblProductoEncontrado.Text = "";
            this.lblProductoEncontrado.Visible = false;
            // 
            // groupPrecios
            // 
            this.groupPrecios.BorderRadius = 8;
            this.groupPrecios.Controls.Add(this.numPVPUnidad);
            this.groupPrecios.Controls.Add(this.label5);
            this.groupPrecios.Controls.Add(this.numCostoPorCaja);
            this.groupPrecios.Controls.Add(this.label4);
            this.groupPrecios.Controls.Add(this.numCostoPorUnidad);
            this.groupPrecios.Controls.Add(this.label3);
            this.groupPrecios.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupPrecios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupPrecios.ForeColor = System.Drawing.Color.White;
            this.groupPrecios.Location = new System.Drawing.Point(20, 230);
            this.groupPrecios.Name = "groupPrecios";
            this.groupPrecios.Size = new System.Drawing.Size(560, 160);
            this.groupPrecios.TabIndex = 2;
            this.groupPrecios.Text = "Configuración de Precios";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(15, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Costo por Unidad *";
            // 
            // numCostoPorUnidad
            // 
            this.numCostoPorUnidad.BackColor = System.Drawing.Color.Transparent;
            this.numCostoPorUnidad.BorderRadius = 6;
            this.numCostoPorUnidad.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numCostoPorUnidad.DecimalPlaces = 2;
            this.numCostoPorUnidad.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.numCostoPorUnidad.ForeColor = System.Drawing.Color.Black;
            this.numCostoPorUnidad.Location = new System.Drawing.Point(180, 50);
            this.numCostoPorUnidad.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numCostoPorUnidad.Name = "numCostoPorUnidad";
            this.numCostoPorUnidad.Size = new System.Drawing.Size(120, 36);
            this.numCostoPorUnidad.TabIndex = 1;
            this.numCostoPorUnidad.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.numCostoPorUnidad.ValueChanged += new System.EventHandler(this.numCostoPorUnidad_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(330, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Costo por Caja";
            // 
            // numCostoPorCaja
            // 
            this.numCostoPorCaja.BackColor = System.Drawing.Color.Transparent;
            this.numCostoPorCaja.BorderRadius = 6;
            this.numCostoPorCaja.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numCostoPorCaja.DecimalPlaces = 2;
            this.numCostoPorCaja.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numCostoPorCaja.ForeColor = System.Drawing.Color.Black;
            this.numCostoPorCaja.Location = new System.Drawing.Point(430, 56);
            this.numCostoPorCaja.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numCostoPorCaja.Name = "numCostoPorCaja";
            this.numCostoPorCaja.Enabled = false;
            this.numCostoPorCaja.Size = new System.Drawing.Size(110, 30);
            this.numCostoPorCaja.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(15, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "PVP Unidad *";
            // 
            // numPVPUnidad
            // 
            this.numPVPUnidad.BackColor = System.Drawing.Color.Transparent;
            this.numPVPUnidad.BorderRadius = 6;
            this.numPVPUnidad.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numPVPUnidad.DecimalPlaces = 2;
            this.numPVPUnidad.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.numPVPUnidad.ForeColor = System.Drawing.Color.Black;
            this.numPVPUnidad.Location = new System.Drawing.Point(180, 103);
            this.numPVPUnidad.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numPVPUnidad.Name = "numPVPUnidad";
            this.numPVPUnidad.Size = new System.Drawing.Size(120, 36);
            this.numPVPUnidad.TabIndex = 5;
            this.numPVPUnidad.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.numPVPUnidad.ValueChanged += new System.EventHandler(this.numPVPUnidad_ValueChanged);
            // 
            // panelFraccionamiento
            // 
            this.panelFraccionamiento.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.panelFraccionamiento.BorderRadius = 8;
            this.panelFraccionamiento.BorderThickness = 1;
            this.panelFraccionamiento.Controls.Add(this.lblNotaFraccionamiento);
            this.panelFraccionamiento.Controls.Add(this.numDivision);
            this.panelFraccionamiento.Controls.Add(this.label6);
            this.panelFraccionamiento.Controls.Add(this.chkEsFraccionable);
            this.panelFraccionamiento.Location = new System.Drawing.Point(20, 410);
            this.panelFraccionamiento.Name = "panelFraccionamiento";
            this.panelFraccionamiento.Size = new System.Drawing.Size(560, 110);
            this.panelFraccionamiento.TabIndex = 3;
            // 
            // chkEsFraccionable
            // 
            this.chkEsFraccionable.AutoSize = true;
            this.chkEsFraccionable.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkEsFraccionable.CheckedState.BorderRadius = 0;
            this.chkEsFraccionable.CheckedState.BorderThickness = 0;
            this.chkEsFraccionable.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkEsFraccionable.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkEsFraccionable.Location = new System.Drawing.Point(20, 20);
            this.chkEsFraccionable.Name = "chkEsFraccionable";
            this.chkEsFraccionable.Size = new System.Drawing.Size(250, 21);
            this.chkEsFraccionable.TabIndex = 0;
            this.chkEsFraccionable.Text = "Producto NO Fraccionable";
            this.chkEsFraccionable.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkEsFraccionable.UncheckedState.BorderRadius = 0;
            this.chkEsFraccionable.UncheckedState.BorderThickness = 0;
            this.chkEsFraccionable.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkEsFraccionable.CheckedChanged += new System.EventHandler(this.chkEsFraccionable_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(20, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Fraccionamiento";
            // 
            // numDivision
            // 
            this.numDivision.BackColor = System.Drawing.Color.Transparent;
            this.numDivision.BorderRadius = 6;
            this.numDivision.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numDivision.DecimalPlaces = 0;
            this.numDivision.Enabled = false;
            this.numDivision.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numDivision.Location = new System.Drawing.Point(130, 56);
            this.numDivision.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDivision.Name = "numDivision";
            this.numDivision.Size = new System.Drawing.Size(80, 30);
            this.numDivision.TabIndex = 2;
            this.numDivision.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblNotaFraccionamiento
            // 
            this.lblNotaFraccionamiento.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblNotaFraccionamiento.ForeColor = System.Drawing.Color.Crimson;
            this.lblNotaFraccionamiento.Location = new System.Drawing.Point(230, 56);
            this.lblNotaFraccionamiento.Name = "lblNotaFraccionamiento";
            this.lblNotaFraccionamiento.Size = new System.Drawing.Size(310, 35);
            this.lblNotaFraccionamiento.TabIndex = 3;
            this.lblNotaFraccionamiento.Text = "Solo se puede vender por unidad completa (gotas oftálmicas, inyectables, etc.)";
            // 
            // groupResumen
            // 
            this.groupResumen.BorderRadius = 8;
            this.groupResumen.Controls.Add(this.lblEstadoProducto);
            this.groupResumen.Controls.Add(this.lblValorInventario);
            this.groupResumen.Controls.Add(this.label9);
            this.groupResumen.Controls.Add(this.lblGanancia);
            this.groupResumen.Controls.Add(this.label8);
            this.groupResumen.Controls.Add(this.lblMargen);
            this.groupResumen.Controls.Add(this.label7);
            this.groupResumen.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.groupResumen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupResumen.ForeColor = System.Drawing.Color.White;
            this.groupResumen.Location = new System.Drawing.Point(20, 540);
            this.groupResumen.Name = "groupResumen";
            this.groupResumen.Size = new System.Drawing.Size(560, 90);
            this.groupResumen.TabIndex = 4;
            this.groupResumen.Text = "Resumen";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(15, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Margen:";
            // 
            // lblMargen
            // 
            this.lblMargen.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMargen.ForeColor = System.Drawing.Color.Green;
            this.lblMargen.Location = new System.Drawing.Point(90, 52);
            this.lblMargen.Name = "lblMargen";
            this.lblMargen.Size = new System.Drawing.Size(80, 20);
            this.lblMargen.TabIndex = 1;
            this.lblMargen.Text = "30.02%";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(200, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "Ganancia/Unidad:";
            // 
            // lblGanancia
            // 
            this.lblGanancia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGanancia.ForeColor = System.Drawing.Color.Black;
            this.lblGanancia.Location = new System.Drawing.Point(320, 53);
            this.lblGanancia.Name = "lblGanancia";
            this.lblGanancia.Size = new System.Drawing.Size(80, 20);
            this.lblGanancia.TabIndex = 3;
            this.lblGanancia.Text = "$1.54";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(410, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 15);
            this.label9.TabIndex = 4;
            this.label9.Text = "Valor Inventario:";
            // 
            // lblValorInventario
            // 
            this.lblValorInventario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblValorInventario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblValorInventario.Location = new System.Drawing.Point(440, 53);
            this.lblValorInventario.Name = "lblValorInventario";
            this.lblValorInventario.Size = new System.Drawing.Size(100, 20);
            this.lblValorInventario.TabIndex = 5;
            this.lblValorInventario.Text = "$10.26";
            this.lblValorInventario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEstadoProducto
            // 
            this.lblEstadoProducto.BackColor = System.Drawing.Color.LightGreen;
            this.lblEstadoProducto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstadoProducto.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblEstadoProducto.Location = new System.Drawing.Point(440, 50);
            this.lblEstadoProducto.Name = "lblEstadoProducto";
            this.lblEstadoProducto.Size = new System.Drawing.Size(100, 25);
            this.lblEstadoProducto.TabIndex = 6;
            this.lblEstadoProducto.Text = "Bueno";
            this.lblEstadoProducto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BorderRadius = 8;
            this.btnGuardar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGuardar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGuardar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGuardar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGuardar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(330, 650);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 40);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BorderRadius = 8;
            this.btnCancelar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancelar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancelar.FillColor = System.Drawing.Color.Gray;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(460, 650);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 40);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmConfiguracionProductoXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 700);
            this.Controls.Add(this.panelPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfiguracionProductoXML";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuración de Producto";
            this.panelPrincipal.ResumeLayout(false);
            this.panelPrincipal.PerformLayout();
            this.groupInfo.ResumeLayout(false);
            this.groupInfo.PerformLayout();
            this.groupPrecios.ResumeLayout(false);
            this.groupPrecios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCostoPorUnidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCostoPorCaja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPVPUnidad)).EndInit();
            this.panelFraccionamiento.ResumeLayout(false);
            this.panelFraccionamiento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDivision)).EndInit();
            this.groupResumen.ResumeLayout(false);
            this.groupResumen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelPrincipal;
        private System.Windows.Forms.Label lblTitulo;
        private Guna.UI2.WinForms.Guna2GroupBox groupInfo;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtCodigoPrincipal;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtDescripcion;
        private System.Windows.Forms.Label lblProductoEncontrado;
        private Guna.UI2.WinForms.Guna2GroupBox groupPrecios;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2NumericUpDown numCostoPorUnidad;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2NumericUpDown numCostoPorCaja;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2NumericUpDown numPVPUnidad;
        private Guna.UI2.WinForms.Guna2Panel panelFraccionamiento;
        private Guna.UI2.WinForms.Guna2CheckBox chkEsFraccionable;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2NumericUpDown numDivision;
        private System.Windows.Forms.Label lblNotaFraccionamiento;
        private Guna.UI2.WinForms.Guna2GroupBox groupResumen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMargen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblGanancia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblValorInventario;
        private System.Windows.Forms.Label lblEstadoProducto;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;
    }
}
