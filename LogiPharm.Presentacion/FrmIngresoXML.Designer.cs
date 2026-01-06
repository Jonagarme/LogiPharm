namespace LogiPharm.Presentacion
{
    partial class FrmIngresoXML
    {
        private System.ComponentModel.IContainer components = null;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabCargar = new System.Windows.Forms.TabPage();
            this.panelXML = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTituloXML = new System.Windows.Forms.Label();
            this.btnExaminar = new Guna.UI2.WinForms.Guna2Button();
            this.lblArchivoSeleccionado = new System.Windows.Forms.Label();
            this.btnProcesarXML = new Guna.UI2.WinForms.Guna2Button();
            this.panelClave = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTituloClave = new System.Windows.Forms.Label();
            this.txtClaveAcceso = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnConsultarSRI = new Guna.UI2.WinForms.Guna2Button();
            this.tabRevisar = new System.Windows.Forms.TabPage();
            this.groupProveedor = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.lblRUC = new System.Windows.Forms.Label();
            this.groupResumen = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblProductosIngresar = new System.Windows.Forms.Label();
            this.lblNuevos = new System.Windows.Forms.Label();
            this.lblActualizar = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvProductos = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnSeleccionarTodo = new Guna.UI2.WinForms.Guna2Button();
            this.btnDeseleccionarTodo = new Guna.UI2.WinForms.Guna2Button();
            this.btnProcesarIngreso = new Guna.UI2.WinForms.Guna2Button();
            this.tabResultado = new System.Windows.Forms.TabPage();
            this.lblResultado = new System.Windows.Forms.Label();
            this.btnCerrar = new Guna.UI2.WinForms.Guna2Button();
            this.tabControl.SuspendLayout();
            this.tabCargar.SuspendLayout();
            this.panelXML.SuspendLayout();
            this.panelClave.SuspendLayout();
            this.tabRevisar.SuspendLayout();
            this.groupProveedor.SuspendLayout();
            this.groupResumen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.tabResultado.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Top;
            this.tabControl.Controls.Add(this.tabCargar);
            this.tabControl.Controls.Add(this.tabRevisar);
            this.tabControl.Controls.Add(this.tabResultado);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ItemSize = new System.Drawing.Size(180, 40);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1200, 700);
            this.tabControl.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tabControl.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));

            this.tabControl.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControl.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tabControl.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tabControl.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tabControl.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tabControl.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControl.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.tabControl.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tabControl.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tabControl.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.tabControl.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControl.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tabControl.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.tabControl.TabIndex = 0;
            this.tabControl.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            // 
            // tabCargar
            // 
            this.tabCargar.BackColor = System.Drawing.Color.White;
            this.tabCargar.Controls.Add(this.panelClave);
            this.tabCargar.Controls.Add(this.panelXML);
            this.tabCargar.Location = new System.Drawing.Point(4, 44);
            this.tabCargar.Name = "tabCargar";
            this.tabCargar.Padding = new System.Windows.Forms.Padding(3);
            this.tabCargar.Size = new System.Drawing.Size(1192, 652);
            this.tabCargar.TabIndex = 0;
            this.tabCargar.Text = "Cargar Factura";
            // 
            // panelXML
            // 
            this.panelXML.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.panelXML.BorderRadius = 10;
            this.panelXML.BorderThickness = 1;
            this.panelXML.Controls.Add(this.btnProcesarXML);
            this.panelXML.Controls.Add(this.lblArchivoSeleccionado);
            this.panelXML.Controls.Add(this.btnExaminar);
            this.panelXML.Controls.Add(this.lblTituloXML);
            this.panelXML.Location = new System.Drawing.Point(50, 150);
            this.panelXML.Name = "panelXML";
            this.panelXML.Size = new System.Drawing.Size(500, 350);
            this.panelXML.TabIndex = 0;
            // 
            // lblTituloXML
            // 
            this.lblTituloXML.AutoSize = true;
            this.lblTituloXML.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloXML.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lblTituloXML.Location = new System.Drawing.Point(120, 30);
            this.lblTituloXML.Name = "lblTituloXML";
            this.lblTituloXML.Size = new System.Drawing.Size(260, 25);
            this.lblTituloXML.TabIndex = 0;
            this.lblTituloXML.Text = "Importar Archivo XML";
            // 
            // btnExaminar
            // 
            this.btnExaminar.BorderRadius = 8;
            this.btnExaminar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExaminar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExaminar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExaminar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExaminar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnExaminar.ForeColor = System.Drawing.Color.White;
            this.btnExaminar.Location = new System.Drawing.Point(150, 100);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(200, 50);
            this.btnExaminar.TabIndex = 1;
            this.btnExaminar.Text = "\ud83d\udcc2 Examinar";
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // lblArchivoSeleccionado
            // 
            this.lblArchivoSeleccionado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblArchivoSeleccionado.ForeColor = System.Drawing.Color.Gray;
            this.lblArchivoSeleccionado.Location = new System.Drawing.Point(20, 170);
            this.lblArchivoSeleccionado.Name = "lblArchivoSeleccionado";
            this.lblArchivoSeleccionado.Size = new System.Drawing.Size(460, 40);
            this.lblArchivoSeleccionado.TabIndex = 2;
            this.lblArchivoSeleccionado.Text = "Seleccione el archivo XML de la factura electrónica";
            this.lblArchivoSeleccionado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnProcesarXML
            // 
            this.btnProcesarXML.BorderRadius = 8;
            this.btnProcesarXML.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnProcesarXML.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnProcesarXML.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnProcesarXML.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnProcesarXML.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnProcesarXML.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnProcesarXML.ForeColor = System.Drawing.Color.White;
            this.btnProcesarXML.Location = new System.Drawing.Point(150, 240);
            this.btnProcesarXML.Name = "btnProcesarXML";
            this.btnProcesarXML.Size = new System.Drawing.Size(200, 50);
            this.btnProcesarXML.TabIndex = 3;
            this.btnProcesarXML.Text = "? Procesar XML";
            this.btnProcesarXML.Click += new System.EventHandler(this.btnProcesarXML_Click);
            // 
            // panelClave
            // 
            this.panelClave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.panelClave.BorderRadius = 10;
            this.panelClave.BorderThickness = 1;
            this.panelClave.Controls.Add(this.btnConsultarSRI);
            this.panelClave.Controls.Add(this.txtClaveAcceso);
            this.panelClave.Controls.Add(this.lblTituloClave);
            this.panelClave.Location = new System.Drawing.Point(640, 150);
            this.panelClave.Name = "panelClave";
            this.panelClave.Size = new System.Drawing.Size(500, 350);
            this.panelClave.TabIndex = 1;
            // 
            // lblTituloClave
            // 
            this.lblTituloClave.AutoSize = true;
            this.lblTituloClave.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTituloClave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lblTituloClave.Location = new System.Drawing.Point(80, 30);
            this.lblTituloClave.Name = "lblTituloClave";
            this.lblTituloClave.Size = new System.Drawing.Size(340, 25);
            this.lblTituloClave.TabIndex = 0;
            this.lblTituloClave.Text = "Consultar por Clave de Acceso";
            // 
            // txtClaveAcceso
            // 
            this.txtClaveAcceso.BorderRadius = 8;
            this.txtClaveAcceso.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtClaveAcceso.DefaultText = "";
            this.txtClaveAcceso.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtClaveAcceso.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtClaveAcceso.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtClaveAcceso.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtClaveAcceso.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtClaveAcceso.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtClaveAcceso.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtClaveAcceso.Location = new System.Drawing.Point(35, 120);
            this.txtClaveAcceso.MaxLength = 49;
            this.txtClaveAcceso.Name = "txtClaveAcceso";
            this.txtClaveAcceso.PasswordChar = '\0';
            this.txtClaveAcceso.PlaceholderText = "Ingrese la clave de acceso (49 dígitos)";
            this.txtClaveAcceso.SelectedText = "";
            this.txtClaveAcceso.Size = new System.Drawing.Size(430, 40);
            this.txtClaveAcceso.TabIndex = 1;
            // 
            // btnConsultarSRI
            // 
            this.btnConsultarSRI.BorderRadius = 8;
            this.btnConsultarSRI.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnConsultarSRI.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnConsultarSRI.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnConsultarSRI.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnConsultarSRI.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnConsultarSRI.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnConsultarSRI.ForeColor = System.Drawing.Color.White;
            this.btnConsultarSRI.Location = new System.Drawing.Point(150, 200);
            this.btnConsultarSRI.Name = "btnConsultarSRI";
            this.btnConsultarSRI.Size = new System.Drawing.Size(200, 50);
            this.btnConsultarSRI.TabIndex = 2;
            this.btnConsultarSRI.Text = "?? Consultar SRI";
            this.btnConsultarSRI.Click += new System.EventHandler(this.btnConsultarSRI_Click);
            // 
            // tabRevisar
            // 
            this.tabRevisar.BackColor = System.Drawing.Color.White;
            this.tabRevisar.Controls.Add(this.btnProcesarIngreso);
            this.tabRevisar.Controls.Add(this.btnDeseleccionarTodo);
            this.tabRevisar.Controls.Add(this.btnSeleccionarTodo);
            this.tabRevisar.Controls.Add(this.dgvProductos);
            this.tabRevisar.Controls.Add(this.groupResumen);
            this.tabRevisar.Controls.Add(this.groupProveedor);
            this.tabRevisar.Location = new System.Drawing.Point(4, 44);
            this.tabRevisar.Name = "tabRevisar";
            this.tabRevisar.Padding = new System.Windows.Forms.Padding(3);
            this.tabRevisar.Size = new System.Drawing.Size(1192, 652);
            this.tabRevisar.TabIndex = 1;
            this.tabRevisar.Text = "Revisar Productos";
            // 
            // groupProveedor
            // 
            this.groupProveedor.BorderRadius = 8;
            this.groupProveedor.Controls.Add(this.lblRUC);
            this.groupProveedor.Controls.Add(this.lblRazonSocial);
            this.groupProveedor.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.groupProveedor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupProveedor.ForeColor = System.Drawing.Color.White;
            this.groupProveedor.Location = new System.Drawing.Point(20, 20);
            this.groupProveedor.Name = "groupProveedor";
            this.groupProveedor.Size = new System.Drawing.Size(750, 100);
            this.groupProveedor.TabIndex = 0;
            this.groupProveedor.Text = "Información del Proveedor";
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.AutoSize = true;
            this.lblRazonSocial.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRazonSocial.ForeColor = System.Drawing.Color.Black;
            this.lblRazonSocial.Location = new System.Drawing.Point(15, 50);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(100, 19);
            this.lblRazonSocial.TabIndex = 0;
            this.lblRazonSocial.Text = "Proveedor: ---";
            // 
            // lblRUC
            // 
            this.lblRUC.AutoSize = true;
            this.lblRUC.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRUC.ForeColor = System.Drawing.Color.Black;
            this.lblRUC.Location = new System.Drawing.Point(500, 50);
            this.lblRUC.Name = "lblRUC";
            this.lblRUC.Size = new System.Drawing.Size(60, 19);
            this.lblRUC.TabIndex = 1;
            this.lblRUC.Text = "RUC: ---";
            // 
            // groupResumen
            // 
            this.groupResumen.BorderRadius = 8;
            this.groupResumen.Controls.Add(this.lblTotal);
            this.groupResumen.Controls.Add(this.lblActualizar);
            this.groupResumen.Controls.Add(this.lblNuevos);
            this.groupResumen.Controls.Add(this.lblProductosIngresar);
            this.groupResumen.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupResumen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupResumen.ForeColor = System.Drawing.Color.White;
            this.groupResumen.Location = new System.Drawing.Point(790, 20);
            this.groupResumen.Name = "groupResumen";
            this.groupResumen.Size = new System.Drawing.Size(380, 100);
            this.groupResumen.TabIndex = 1;
            this.groupResumen.Text = "Resumen";
            // 
            // lblProductosIngresar
            // 
            this.lblProductosIngresar.AutoSize = true;
            this.lblProductosIngresar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProductosIngresar.ForeColor = System.Drawing.Color.Black;
            this.lblProductosIngresar.Location = new System.Drawing.Point(15, 50);
            this.lblProductosIngresar.Name = "lblProductosIngresar";
            this.lblProductosIngresar.Size = new System.Drawing.Size(140, 15);
            this.lblProductosIngresar.TabIndex = 0;
            this.lblProductosIngresar.Text = "Productos a Ingresar: 0";
            // 
            // lblNuevos
            // 
            this.lblNuevos.AutoSize = true;
            this.lblNuevos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNuevos.ForeColor = System.Drawing.Color.Green;
            this.lblNuevos.Location = new System.Drawing.Point(200, 50);
            this.lblNuevos.Name = "lblNuevos";
            this.lblNuevos.Size = new System.Drawing.Size(63, 15);
            this.lblNuevos.TabIndex = 1;
            this.lblNuevos.Text = "Nuevos: 0";
            // 
            // lblActualizar
            // 
            this.lblActualizar.AutoSize = true;
            this.lblActualizar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblActualizar.ForeColor = System.Drawing.Color.Blue;
            this.lblActualizar.Location = new System.Drawing.Point(15, 70);
            this.lblActualizar.Name = "lblActualizar";
            this.lblActualizar.Size = new System.Drawing.Size(82, 15);
            this.lblActualizar.TabIndex = 2;
            this.lblActualizar.Text = "A Actualizar: 0";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(200, 70);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(78, 19);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Total: $0.00";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AutoGenerateColumns = false;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(20, 140);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.Size = new System.Drawing.Size(1150, 420);
            this.dgvProductos.TabIndex = 2;
            // 
            // btnSeleccionarTodo
            // 
            this.btnSeleccionarTodo.BorderRadius = 6;
            this.btnSeleccionarTodo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSeleccionarTodo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSeleccionarTodo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSeleccionarTodo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSeleccionarTodo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSeleccionarTodo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSeleccionarTodo.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionarTodo.Location = new System.Drawing.Point(20, 580);
            this.btnSeleccionarTodo.Name = "btnSeleccionarTodo";
            this.btnSeleccionarTodo.Size = new System.Drawing.Size(180, 45);
            this.btnSeleccionarTodo.TabIndex = 3;
            this.btnSeleccionarTodo.Text = "? Seleccionar Todo";
            this.btnSeleccionarTodo.Click += new System.EventHandler(this.btnSeleccionarTodo_Click);
            // 
            // btnDeseleccionarTodo
            // 
            this.btnDeseleccionarTodo.BorderRadius = 6;
            this.btnDeseleccionarTodo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDeseleccionarTodo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDeseleccionarTodo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDeseleccionarTodo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDeseleccionarTodo.FillColor = System.Drawing.Color.Gray;
            this.btnDeseleccionarTodo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDeseleccionarTodo.ForeColor = System.Drawing.Color.White;
            this.btnDeseleccionarTodo.Location = new System.Drawing.Point(220, 580);
            this.btnDeseleccionarTodo.Name = "btnDeseleccionarTodo";
            this.btnDeseleccionarTodo.Size = new System.Drawing.Size(200, 45);
            this.btnDeseleccionarTodo.TabIndex = 4;
            this.btnDeseleccionarTodo.Text = "? Deseleccionar Todo";
            this.btnDeseleccionarTodo.Click += new System.EventHandler(this.btnDeseleccionarTodo_Click);
            // 
            // btnProcesarIngreso
            // 
            this.btnProcesarIngreso.BorderRadius = 8;
            this.btnProcesarIngreso.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnProcesarIngreso.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnProcesarIngreso.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnProcesarIngreso.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnProcesarIngreso.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnProcesarIngreso.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnProcesarIngreso.ForeColor = System.Drawing.Color.White;
            this.btnProcesarIngreso.Location = new System.Drawing.Point(940, 580);
            this.btnProcesarIngreso.Name = "btnProcesarIngreso";
            this.btnProcesarIngreso.Size = new System.Drawing.Size(230, 50);
            this.btnProcesarIngreso.TabIndex = 5;
            this.btnProcesarIngreso.Text = "? Procesar Ingreso";
            this.btnProcesarIngreso.Click += new System.EventHandler(this.btnProcesarIngreso_Click);
            // 
            // tabResultado
            // 
            this.tabResultado.BackColor = System.Drawing.Color.White;
            this.tabResultado.Controls.Add(this.btnCerrar);
            this.tabResultado.Controls.Add(this.lblResultado);
            this.tabResultado.Location = new System.Drawing.Point(4, 44);
            this.tabResultado.Name = "tabResultado";
            this.tabResultado.Size = new System.Drawing.Size(1192, 652);
            this.tabResultado.TabIndex = 2;
            this.tabResultado.Text = "Resultado";
            // 
            // lblResultado
            // 
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblResultado.Location = new System.Drawing.Point(100, 100);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(1000, 400);
            this.lblResultado.TabIndex = 0;
            this.lblResultado.Text = "Proceso completado...";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BorderRadius = 8;
            this.btnCerrar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCerrar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCerrar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCerrar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCerrar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(500, 540);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(200, 50);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FrmIngresoXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmIngresoXML";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ingreso de Productos por XML - LogiPharm";
            this.tabControl.ResumeLayout(false);
            this.tabCargar.ResumeLayout(false);
            this.panelXML.ResumeLayout(false);
            this.panelXML.PerformLayout();
            this.panelClave.ResumeLayout(false);
            this.panelClave.PerformLayout();
            this.tabRevisar.ResumeLayout(false);
            this.groupProveedor.ResumeLayout(false);
            this.groupProveedor.PerformLayout();
            this.groupResumen.ResumeLayout(false);
            this.groupResumen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.tabResultado.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2TabControl tabControl;
        private System.Windows.Forms.TabPage tabCargar;
        private System.Windows.Forms.TabPage tabRevisar;
        private System.Windows.Forms.TabPage tabResultado;
        private Guna.UI2.WinForms.Guna2Panel panelXML;
        private System.Windows.Forms.Label lblTituloXML;
        private Guna.UI2.WinForms.Guna2Button btnExaminar;
        private System.Windows.Forms.Label lblArchivoSeleccionado;
        private Guna.UI2.WinForms.Guna2Button btnProcesarXML;
        private Guna.UI2.WinForms.Guna2Panel panelClave;
        private System.Windows.Forms.Label lblTituloClave;
        private Guna.UI2.WinForms.Guna2TextBox txtClaveAcceso;
        private Guna.UI2.WinForms.Guna2Button btnConsultarSRI;
        private Guna.UI2.WinForms.Guna2GroupBox groupProveedor;
        private System.Windows.Forms.Label lblRazonSocial;
        private System.Windows.Forms.Label lblRUC;
        private Guna.UI2.WinForms.Guna2GroupBox groupResumen;
        private System.Windows.Forms.Label lblProductosIngresar;
        private System.Windows.Forms.Label lblNuevos;
        private System.Windows.Forms.Label lblActualizar;
        private System.Windows.Forms.Label lblTotal;
        private Guna.UI2.WinForms.Guna2DataGridView dgvProductos;
        private Guna.UI2.WinForms.Guna2Button btnSeleccionarTodo;
        private Guna.UI2.WinForms.Guna2Button btnDeseleccionarTodo;
        private Guna.UI2.WinForms.Guna2Button btnProcesarIngreso;
        private System.Windows.Forms.Label lblResultado;
        private Guna.UI2.WinForms.Guna2Button btnCerrar;
    }
}
