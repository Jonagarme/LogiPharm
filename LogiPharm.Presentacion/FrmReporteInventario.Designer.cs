namespace LogiPharm.Presentacion
{
    partial class FrmReporteInventario
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
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cboEstadoStock = new System.Windows.Forms.ComboBox();
            this.lblEstadoStock = new System.Windows.Forms.Label();
            this.cboLaboratorio = new System.Windows.Forms.ComboBox();
            this.lblLaboratorio = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.panelKPIs = new System.Windows.Forms.Panel();
            this.panelKpiVentas = new System.Windows.Forms.Panel();
            this.lblKpiVentas = new System.Windows.Forms.Label();
            this.lblKpiVentasTitle = new System.Windows.Forms.Label();
            this.panelKpiCosto = new System.Windows.Forms.Panel();
            this.lblKpiCosto = new System.Windows.Forms.Label();
            this.lblKpiCostoTitle = new System.Windows.Forms.Label();
            this.panelKpiStock = new System.Windows.Forms.Panel();
            this.lblKpiStock = new System.Windows.Forms.Label();
            this.lblKpiStockTitle = new System.Windows.Forms.Label();
            this.panelKpiItems = new System.Windows.Forms.Panel();
            this.lblKpiItems = new System.Windows.Forms.Label();
            this.lblKpiItemsTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLaboratorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelHeader.SuspendLayout();
            this.panelFilters.SuspendLayout();
            this.panelKPIs.SuspendLayout();
            this.panelKpiVentas.SuspendLayout();
            this.panelKpiCosto.SuspendLayout();
            this.panelKpiStock.SuspendLayout();
            this.panelKpiItems.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(12, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(332, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Reporte de Inventario Valorizado";
            // 
            // panelFilters
            // 
            this.panelFilters.BackColor = System.Drawing.Color.White;
            this.panelFilters.Controls.Add(this.btnExportar);
            this.panelFilters.Controls.Add(this.btnBuscar);
            this.panelFilters.Controls.Add(this.cboEstadoStock);
            this.panelFilters.Controls.Add(this.lblEstadoStock);
            this.panelFilters.Controls.Add(this.cboLaboratorio);
            this.panelFilters.Controls.Add(this.lblLaboratorio);
            this.panelFilters.Controls.Add(this.cboCategoria);
            this.panelFilters.Controls.Add(this.lblCategoria);
            this.panelFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilters.Location = new System.Drawing.Point(0, 60);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(1000, 60);
            this.panelFilters.TabIndex = 1;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(888, 15);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(100, 30);
            this.btnExportar.TabIndex = 7;
            this.btnExportar.Text = "Excel Export";
            this.btnExportar.UseVisualStyleBackColor = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(782, 15);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 30);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Consultar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // cboEstadoStock
            // 
            this.cboEstadoStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoStock.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cboEstadoStock.FormattingEnabled = true;
            this.cboEstadoStock.Location = new System.Drawing.Point(595, 17);
            this.cboEstadoStock.Name = "cboEstadoStock";
            this.cboEstadoStock.Size = new System.Drawing.Size(160, 25);
            this.cboEstadoStock.TabIndex = 5;
            // 
            // lblEstadoStock
            // 
            this.lblEstadoStock.AutoSize = true;
            this.lblEstadoStock.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblEstadoStock.Location = new System.Drawing.Point(505, 20);
            this.lblEstadoStock.Name = "lblEstadoStock";
            this.lblEstadoStock.Size = new System.Drawing.Size(89, 17);
            this.lblEstadoStock.TabIndex = 4;
            this.lblEstadoStock.Text = "Estado Stock:";
            // 
            // cboLaboratorio
            // 
            this.cboLaboratorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLaboratorio.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cboLaboratorio.FormattingEnabled = true;
            this.cboLaboratorio.Location = new System.Drawing.Point(325, 17);
            this.cboLaboratorio.Name = "cboLaboratorio";
            this.cboLaboratorio.Size = new System.Drawing.Size(170, 25);
            this.cboLaboratorio.TabIndex = 3;
            // 
            // lblLaboratorio
            // 
            this.lblLaboratorio.AutoSize = true;
            this.lblLaboratorio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblLaboratorio.Location = new System.Drawing.Point(240, 20);
            this.lblLaboratorio.Name = "lblLaboratorio";
            this.lblLaboratorio.Size = new System.Drawing.Size(84, 17);
            this.lblLaboratorio.TabIndex = 2;
            this.lblLaboratorio.Text = "Laboratorio:";
            // 
            // cboCategoria
            // 
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(85, 17);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(145, 25);
            this.cboCategoria.TabIndex = 1;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCategoria.Location = new System.Drawing.Point(12, 20);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(71, 17);
            this.lblCategoria.TabIndex = 0;
            this.lblCategoria.Text = "Categoría:";
            // 
            // panelKPIs
            // 
            this.panelKPIs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelKPIs.Controls.Add(this.panelKpiVentas);
            this.panelKPIs.Controls.Add(this.panelKpiCosto);
            this.panelKPIs.Controls.Add(this.panelKpiStock);
            this.panelKPIs.Controls.Add(this.panelKpiItems);
            this.panelKPIs.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKPIs.Location = new System.Drawing.Point(0, 120);
            this.panelKPIs.Name = "panelKPIs";
            this.panelKPIs.Size = new System.Drawing.Size(1000, 85);
            this.panelKPIs.TabIndex = 2;
            // 
            // panelKpiVentas
            // 
            this.panelKpiVentas.BackColor = System.Drawing.Color.White;
            this.panelKpiVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKpiVentas.Controls.Add(this.lblKpiVentas);
            this.panelKpiVentas.Controls.Add(this.lblKpiVentasTitle);
            this.panelKpiVentas.Location = new System.Drawing.Point(750, 10);
            this.panelKpiVentas.Name = "panelKpiVentas";
            this.panelKpiVentas.Size = new System.Drawing.Size(238, 65);
            this.panelKpiVentas.TabIndex = 3;
            // 
            // lblKpiVentas
            // 
            this.lblKpiVentas.AutoSize = true;
            this.lblKpiVentas.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblKpiVentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblKpiVentas.Location = new System.Drawing.Point(8, 25);
            this.lblKpiVentas.Name = "lblKpiVentas";
            this.lblKpiVentas.Size = new System.Drawing.Size(70, 30);
            this.lblKpiVentas.TabIndex = 1;
            this.lblKpiVentas.Text = "$0.00";
            // 
            // lblKpiVentasTitle
            // 
            this.lblKpiVentasTitle.AutoSize = true;
            this.lblKpiVentasTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblKpiVentasTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblKpiVentasTitle.Location = new System.Drawing.Point(8, 8);
            this.lblKpiVentasTitle.Name = "lblKpiVentasTitle";
            this.lblKpiVentasTitle.Size = new System.Drawing.Size(126, 13);
            this.lblKpiVentasTitle.TabIndex = 0;
            this.lblKpiVentasTitle.Text = "VALOR DE VENTA (PVP)";
            // 
            // panelKpiCosto
            // 
            this.panelKpiCosto.BackColor = System.Drawing.Color.White;
            this.panelKpiCosto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKpiCosto.Controls.Add(this.lblKpiCosto);
            this.panelKpiCosto.Controls.Add(this.lblKpiCostoTitle);
            this.panelKpiCosto.Location = new System.Drawing.Point(505, 10);
            this.panelKpiCosto.Name = "panelKpiCosto";
            this.panelKpiCosto.Size = new System.Drawing.Size(238, 65);
            this.panelKpiCosto.TabIndex = 2;
            // 
            // lblKpiCosto
            // 
            this.lblKpiCosto.AutoSize = true;
            this.lblKpiCosto.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblKpiCosto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.lblKpiCosto.Location = new System.Drawing.Point(8, 25);
            this.lblKpiCosto.Name = "lblKpiCosto";
            this.lblKpiCosto.Size = new System.Drawing.Size(70, 30);
            this.lblKpiCosto.TabIndex = 1;
            this.lblKpiCosto.Text = "$0.00";
            // 
            // lblKpiCostoTitle
            // 
            this.lblKpiCostoTitle.AutoSize = true;
            this.lblKpiCostoTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblKpiCostoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblKpiCostoTitle.Location = new System.Drawing.Point(8, 8);
            this.lblKpiCostoTitle.Name = "lblKpiCostoTitle";
            this.lblKpiCostoTitle.Size = new System.Drawing.Size(127, 13);
            this.lblKpiCostoTitle.TabIndex = 0;
            this.lblKpiCostoTitle.Text = "VALOR DE INVENTARIO";
            // 
            // panelKpiStock
            // 
            this.panelKpiStock.BackColor = System.Drawing.Color.White;
            this.panelKpiStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKpiStock.Controls.Add(this.lblKpiStock);
            this.panelKpiStock.Controls.Add(this.lblKpiStockTitle);
            this.panelKpiStock.Location = new System.Drawing.Point(260, 10);
            this.panelKpiStock.Name = "panelKpiStock";
            this.panelKpiStock.Size = new System.Drawing.Size(238, 65);
            this.panelKpiStock.TabIndex = 1;
            // 
            // lblKpiStock
            // 
            this.lblKpiStock.AutoSize = true;
            this.lblKpiStock.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblKpiStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblKpiStock.Location = new System.Drawing.Point(8, 25);
            this.lblKpiStock.Name = "lblKpiStock";
            this.lblKpiStock.Size = new System.Drawing.Size(25, 30);
            this.lblKpiStock.TabIndex = 1;
            this.lblKpiStock.Text = "0";
            // 
            // lblKpiStockTitle
            // 
            this.lblKpiStockTitle.AutoSize = true;
            this.lblKpiStockTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblKpiStockTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblKpiStockTitle.Location = new System.Drawing.Point(8, 8);
            this.lblKpiStockTitle.Name = "lblKpiStockTitle";
            this.lblKpiStockTitle.Size = new System.Drawing.Size(107, 13);
            this.lblKpiStockTitle.TabIndex = 0;
            this.lblKpiStockTitle.Text = "STOCK DISPONIBLE";
            // 
            // panelKpiItems
            // 
            this.panelKpiItems.BackColor = System.Drawing.Color.White;
            this.panelKpiItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKpiItems.Controls.Add(this.lblKpiItems);
            this.panelKpiItems.Controls.Add(this.lblKpiItemsTitle);
            this.panelKpiItems.Location = new System.Drawing.Point(15, 10);
            this.panelKpiItems.Name = "panelKpiItems";
            this.panelKpiItems.Size = new System.Drawing.Size(238, 65);
            this.panelKpiItems.TabIndex = 0;
            // 
            // lblKpiItems
            // 
            this.lblKpiItems.AutoSize = true;
            this.lblKpiItems.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblKpiItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblKpiItems.Location = new System.Drawing.Point(8, 25);
            this.lblKpiItems.Name = "lblKpiItems";
            this.lblKpiItems.Size = new System.Drawing.Size(25, 30);
            this.lblKpiItems.TabIndex = 1;
            this.lblKpiItems.Text = "0";
            // 
            // lblKpiItemsTitle
            // 
            this.lblKpiItemsTitle.AutoSize = true;
            this.lblKpiItemsTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblKpiItemsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblKpiItemsTitle.Location = new System.Drawing.Point(8, 8);
            this.lblKpiItemsTitle.Name = "lblKpiItemsTitle";
            this.lblKpiItemsTitle.Size = new System.Drawing.Size(107, 13);
            this.lblKpiItemsTitle.TabIndex = 0;
            this.lblKpiItemsTitle.Text = "TOTAL PRODUCTOS";
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.dgvInventario);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 205);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(12);
            this.panelContent.Size = new System.Drawing.Size(1000, 395);
            this.panelContent.TabIndex = 3;
            // 
            // dgvInventario
            // 
            this.dgvInventario.AllowUserToAddRows = false;
            this.dgvInventario.AllowUserToDeleteRows = false;
            this.dgvInventario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventario.BackgroundColor = System.Drawing.Color.White;
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colNombre,
            this.colCategoria,
            this.colLaboratorio,
            this.colStock,
            this.colCosto,
            this.colPrecio,
            this.colCostoTotal,
            this.colValorTotal});
            this.dgvInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventario.Location = new System.Drawing.Point(12, 12);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.ReadOnly = true;
            this.dgvInventario.Size = new System.Drawing.Size(976, 371);
            this.dgvInventario.TabIndex = 0;
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
            this.colNombre.HeaderText = "Producto";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            this.colNombre.Width = 180;
            // 
            // colCategoria
            // 
            this.colCategoria.DataPropertyName = "Categoria";
            this.colCategoria.HeaderText = "Categoría";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.ReadOnly = true;
            this.colCategoria.Width = 110;
            // 
            // colLaboratorio
            // 
            this.colLaboratorio.DataPropertyName = "Laboratorio";
            this.colLaboratorio.HeaderText = "Laboratorio";
            this.colLaboratorio.Name = "colLaboratorio";
            this.colLaboratorio.ReadOnly = true;
            this.colLaboratorio.Width = 110;
            // 
            // colStock
            // 
            this.colStock.DataPropertyName = "Stock";
            this.colStock.HeaderText = "Stock";
            this.colStock.Name = "colStock";
            this.colStock.ReadOnly = true;
            this.colStock.Width = 60;
            // 
            // colCosto
            // 
            this.colCosto.DataPropertyName = "CostoUnitario";
            this.colCosto.HeaderText = "Costo Unit.";
            this.colCosto.Name = "colCosto";
            this.colCosto.ReadOnly = true;
            this.colCosto.Width = 80;
            // 
            // colPrecio
            // 
            this.colPrecio.DataPropertyName = "PrecioVenta";
            this.colPrecio.HeaderText = "PVP Unit.";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            this.colPrecio.Width = 80;
            // 
            // colCostoTotal
            // 
            this.colCostoTotal.DataPropertyName = "CostoTotal";
            this.colCostoTotal.HeaderText = "Total Costo";
            this.colCostoTotal.Name = "colCostoTotal";
            this.colCostoTotal.ReadOnly = true;
            this.colCostoTotal.Width = 100;
            // 
            // colValorTotal
            // 
            this.colValorTotal.DataPropertyName = "ValorTotal";
            this.colValorTotal.HeaderText = "Total PVP";
            this.colValorTotal.Name = "colValorTotal";
            this.colValorTotal.ReadOnly = true;
            this.colValorTotal.Width = 100;
            // 
            // FrmReporteInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelKPIs);
            this.Controls.Add(this.panelFilters);
            this.Controls.Add(this.panelHeader);
            this.Name = "FrmReporteInventario";
            this.Text = "Reporte de Inventario Valorizado";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.panelKPIs.ResumeLayout(false);
            this.panelKpiVentas.ResumeLayout(false);
            this.panelKpiVentas.PerformLayout();
            this.panelKpiCosto.ResumeLayout(false);
            this.panelKpiCosto.PerformLayout();
            this.panelKpiStock.ResumeLayout(false);
            this.panelKpiStock.PerformLayout();
            this.panelKpiItems.ResumeLayout(false);
            this.panelKpiItems.PerformLayout();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label lblLaboratorio;
        private System.Windows.Forms.ComboBox cboLaboratorio;
        private System.Windows.Forms.Label lblEstadoStock;
        private System.Windows.Forms.ComboBox cboEstadoStock;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Panel panelKPIs;
        private System.Windows.Forms.Panel panelKpiItems;
        private System.Windows.Forms.Label lblKpiItemsTitle;
        private System.Windows.Forms.Label lblKpiItems;
        private System.Windows.Forms.Panel panelKpiStock;
        private System.Windows.Forms.Label lblKpiStock;
        private System.Windows.Forms.Label lblKpiStockTitle;
        private System.Windows.Forms.Panel panelKpiCosto;
        private System.Windows.Forms.Label lblKpiCosto;
        private System.Windows.Forms.Label lblKpiCostoTitle;
        private System.Windows.Forms.Panel panelKpiVentas;
        private System.Windows.Forms.Label lblKpiVentas;
        private System.Windows.Forms.Label lblKpiVentasTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLaboratorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorTotal;
    }
}
