using System;
using System.Windows.Forms;

namespace LogiPharm.Presentacion
{
    partial class FrmReporteVentas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle(); // <-- AÑADIDO

            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.panelFiltros = new Guna.UI2.WinForms.Guna2Panel();
            this.btnExportar = new Guna.UI2.WinForms.Guna2Button();
            this.btnConsultar = new Guna.UI2.WinForms.Guna2Button();
            this.dtpFechaFin = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProducto = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCliente = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboCliente = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelKPIs = new Guna.UI2.WinForms.Guna2Panel();
            this.cardTicketPromedio = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTicketPromedio = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cardNumFacturas = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNumFacturas = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cardTotalVendido = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalVendido = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelContenido = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvReporte = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCajero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelFiltros.SuspendLayout();
            this.panelKPIs.SuspendLayout();
            this.cardTicketPromedio.SuspendLayout();
            this.cardNumFacturas.SuspendLayout();
            this.cardTotalVendido.SuspendLayout();
            this.panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 12;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.White;
            this.panelFiltros.BorderColor = System.Drawing.Color.LightGray;
            this.panelFiltros.BorderThickness = 1;
            this.panelFiltros.Controls.Add(this.btnExportar);
            this.panelFiltros.Controls.Add(this.btnConsultar);
            this.panelFiltros.Controls.Add(this.dtpFechaFin);
            this.panelFiltros.Controls.Add(this.label4);
            this.panelFiltros.Controls.Add(this.dtpFechaInicio);
            this.panelFiltros.Controls.Add(this.label3);
            this.panelFiltros.Controls.Add(this.txtProducto);
            this.panelFiltros.Controls.Add(this.label2);
            this.panelFiltros.Controls.Add(this.txtCliente);
            this.panelFiltros.Controls.Add(this.cboCliente);
            this.panelFiltros.Controls.Add(this.label1);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Location = new System.Drawing.Point(0, 0);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.panelFiltros.Size = new System.Drawing.Size(1184, 92);
            this.panelFiltros.TabIndex = 0;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BorderRadius = 6;
            this.btnExportar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExportar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExportar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExportar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(1065, 47);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(109, 28);
            this.btnExportar.TabIndex = 10;
            this.btnExportar.Text = "Exportar Excel";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConsultar.BorderRadius = 6;
            this.btnConsultar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnConsultar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnConsultar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnConsultar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnConsultar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnConsultar.ForeColor = System.Drawing.Color.White;
            this.btnConsultar.Location = new System.Drawing.Point(950, 47);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(109, 28);
            this.btnConsultar.TabIndex = 9;
            this.btnConsultar.Text = "Consultar";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.BorderRadius = 4;
            this.dtpFechaFin.Checked = true;
            this.dtpFechaFin.FillColor = System.Drawing.Color.White;
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(814, 47);
            this.dtpFechaFin.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFechaFin.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(120, 28);
            this.dtpFechaFin.TabIndex = 8;
            this.dtpFechaFin.Value = new System.DateTime(2025, 8, 23, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(811, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha fin:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.BorderRadius = 4;
            this.dtpFechaInicio.Checked = true;
            this.dtpFechaInicio.FillColor = System.Drawing.Color.White;
            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(688, 47);
            this.dtpFechaInicio.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFechaInicio.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(120, 28);
            this.dtpFechaInicio.TabIndex = 6;
            this.dtpFechaInicio.Value = new System.DateTime(2025, 8, 23, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(685, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha inicio:";
            // 
            // txtProducto
            // 
            this.txtProducto.BorderRadius = 4;
            this.txtProducto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProducto.DefaultText = "";
            this.txtProducto.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtProducto.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtProducto.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProducto.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProducto.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProducto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtProducto.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProducto.Location = new System.Drawing.Point(384, 47);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.PlaceholderText = "Nombre de producto (opcional)";
            this.txtProducto.SelectedText = "";
            this.txtProducto.Size = new System.Drawing.Size(295, 28);
            this.txtProducto.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Producto:";
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
            this.txtCliente.Location = new System.Drawing.Point(84, 47);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.PlaceholderText = "[TODOS LOS CLIENTES]";
            this.txtCliente.SelectedText = "";
            this.txtCliente.Size = new System.Drawing.Size(287, 28);
            this.txtCliente.TabIndex = 2;
            // 
            // cboCliente
            // 
            this.cboCliente.BackColor = System.Drawing.Color.Transparent;
            this.cboCliente.BorderRadius = 4;
            this.cboCliente.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCliente.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboCliente.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboCliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboCliente.ItemHeight = 22;
            this.cboCliente.Location = new System.Drawing.Point(84, 47);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(287, 28);
            this.cboCliente.TabIndex = 1000;
            this.cboCliente.Visible = false; // lo mantenemos oculto; se usa para el ValueMember
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente:";
            // 
            // panelKPIs
            // 
            this.panelKPIs.BackColor = System.Drawing.Color.White;
            this.panelKPIs.BorderColor = System.Drawing.Color.LightGray;
            this.panelKPIs.BorderThickness = 1;
            this.panelKPIs.Controls.Add(this.cardTicketPromedio);
            this.panelKPIs.Controls.Add(this.cardNumFacturas);
            this.panelKPIs.Controls.Add(this.cardTotalVendido);
            this.panelKPIs.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKPIs.Location = new System.Drawing.Point(0, 92);
            this.panelKPIs.Name = "panelKPIs";
            this.panelKPIs.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.panelKPIs.Size = new System.Drawing.Size(1184, 96);
            this.panelKPIs.TabIndex = 1;
            // 
            // cardTicketPromedio
            // 
            this.cardTicketPromedio.BorderColor = System.Drawing.Color.Gainsboro;
            this.cardTicketPromedio.BorderRadius = 8;
            this.cardTicketPromedio.BorderThickness = 1;
            this.cardTicketPromedio.Controls.Add(this.lblTicketPromedio);
            this.cardTicketPromedio.Controls.Add(this.label11);
            this.cardTicketPromedio.FillColor = System.Drawing.Color.White;
            this.cardTicketPromedio.Location = new System.Drawing.Point(784, 12);
            this.cardTicketPromedio.Name = "cardTicketPromedio";
            this.cardTicketPromedio.Size = new System.Drawing.Size(330, 72);
            this.cardTicketPromedio.TabIndex = 2;
            // 
            // lblTicketPromedio
            // 
            this.lblTicketPromedio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTicketPromedio.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTicketPromedio.ForeColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.lblTicketPromedio.Location = new System.Drawing.Point(11, 34);
            this.lblTicketPromedio.Name = "lblTicketPromedio";
            this.lblTicketPromedio.Size = new System.Drawing.Size(308, 30);
            this.lblTicketPromedio.TabIndex = 1;
            this.lblTicketPromedio.Text = "$0.00";
            this.lblTicketPromedio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(12, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "Ticket promedio";
            // 
            // cardNumFacturas
            // 
            this.cardNumFacturas.BorderColor = System.Drawing.Color.Gainsboro;
            this.cardNumFacturas.BorderRadius = 8;
            this.cardNumFacturas.BorderThickness = 1;
            this.cardNumFacturas.Controls.Add(this.lblNumFacturas);
            this.cardNumFacturas.Controls.Add(this.label9);
            this.cardNumFacturas.FillColor = System.Drawing.Color.White;
            this.cardNumFacturas.Location = new System.Drawing.Point(422, 12);
            this.cardNumFacturas.Name = "cardNumFacturas";
            this.cardNumFacturas.Size = new System.Drawing.Size(330, 72);
            this.cardNumFacturas.TabIndex = 1;
            // 
            // lblNumFacturas
            // 
            this.lblNumFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumFacturas.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblNumFacturas.ForeColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.lblNumFacturas.Location = new System.Drawing.Point(11, 34);
            this.lblNumFacturas.Name = "lblNumFacturas";
            this.lblNumFacturas.Size = new System.Drawing.Size(308, 30);
            this.lblNumFacturas.TabIndex = 1;
            this.lblNumFacturas.Text = "0";
            this.lblNumFacturas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(12, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Número de facturas";
            // 
            // cardTotalVendido
            // 
            this.cardTotalVendido.BorderColor = System.Drawing.Color.Gainsboro;
            this.cardTotalVendido.BorderRadius = 8;
            this.cardTotalVendido.BorderThickness = 1;
            this.cardTotalVendido.Controls.Add(this.lblTotalVendido);
            this.cardTotalVendido.Controls.Add(this.label5);
            this.cardTotalVendido.FillColor = System.Drawing.Color.White;
            this.cardTotalVendido.Location = new System.Drawing.Point(60, 12);
            this.cardTotalVendido.Name = "cardTotalVendido";
            this.cardTotalVendido.Size = new System.Drawing.Size(330, 72);
            this.cardTotalVendido.TabIndex = 0;
            // 
            // lblTotalVendido
            // 
            this.lblTotalVendido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalVendido.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalVendido.ForeColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.lblTotalVendido.Location = new System.Drawing.Point(11, 34);
            this.lblTotalVendido.Name = "lblTotalVendido";
            this.lblTotalVendido.Size = new System.Drawing.Size(308, 30);
            this.lblTotalVendido.TabIndex = 1;
            this.lblTotalVendido.Text = "$0.00";
            this.lblTotalVendido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(12, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Total vendido";
            // 
            // panelContenido
            // 
            this.panelContenido.BackColor = System.Drawing.Color.White;
            this.panelContenido.BorderColor = System.Drawing.Color.LightGray;
            this.panelContenido.BorderThickness = 1;
            this.panelContenido.Controls.Add(this.dgvReporte);
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(0, 188);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Padding = new System.Windows.Forms.Padding(10, 8, 10, 10);
            this.panelContenido.Size = new System.Drawing.Size(1184, 473);
            this.panelContenido.TabIndex = 2;
            // 
            // dgvReporte
            // 
            this.dgvReporte.AllowUserToAddRows = false;
            this.dgvReporte.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvReporte.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReporte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReporte.ColumnHeadersHeight = 22;
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvReporte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colFecha,
            this.colFactura,
            this.colCliente,
            this.colCajero,
            this.colTotal,
            this.colEstado});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReporte.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReporte.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvReporte.Location = new System.Drawing.Point(10, 11);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.ReadOnly = true;
            this.dgvReporte.RowHeadersVisible = false;
            this.dgvReporte.Size = new System.Drawing.Size(1164, 451);
            this.dgvReporte.TabIndex = 0;
            this.dgvReporte.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvReporte.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvReporte.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvReporte.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvReporte.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvReporte.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvReporte.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvReporte.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvReporte.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvReporte.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dgvReporte.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReporte.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvReporte.ThemeStyle.HeaderStyle.Height = 22;
            this.dgvReporte.ThemeStyle.ReadOnly = true;
            this.dgvReporte.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvReporte.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReporte.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dgvReporte.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvReporte.ThemeStyle.RowsStyle.Height = 22;
            this.dgvReporte.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvReporte.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colFecha
            // 
            this.colFecha.DataPropertyName = "Fecha";
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Width = 95;
            // 
            // colFactura
            // 
            this.colFactura.DataPropertyName = "Factura";
            this.colFactura.HeaderText = "Factura";
            this.colFactura.Name = "colFactura";
            this.colFactura.ReadOnly = true;
            this.colFactura.Width = 120;
            // 
            // colCliente
            // 
            this.colCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCliente.DataPropertyName = "Cliente";
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.ReadOnly = true;
            // 
            // colCajero
            // 
            this.colCajero.DataPropertyName = "Cajero";
            this.colCajero.HeaderText = "Cajero";
            this.colCajero.Name = "colCajero";
            this.colCajero.ReadOnly = true;
            this.colCajero.Width = 120;
            // colTotal
            this.colTotal.DataPropertyName = "Total";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle4;
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 110;

            // 
            // colEstado
            // 
            this.colEstado.DataPropertyName = "Estado";
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            this.colEstado.Width = 110;
            // 
            // FrmReporteVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelKPIs);
            this.Controls.Add(this.panelFiltros);
            this.Name = "FrmReporteVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Text = "Reporte de Ventas";
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.panelKPIs.ResumeLayout(false);
            this.cardTicketPromedio.ResumeLayout(false);
            this.cardTicketPromedio.PerformLayout();
            this.cardNumFacturas.ResumeLayout(false);
            this.cardNumFacturas.PerformLayout();
            this.cardTotalVendido.ResumeLayout(false);
            this.cardTotalVendido.PerformLayout();
            this.panelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2Panel panelFiltros;
        private Guna.UI2.WinForms.Guna2Button btnExportar;
        private Guna.UI2.WinForms.Guna2Button btnConsultar;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtProducto;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtCliente;   // 👈 para autocompletar
        private Guna.UI2.WinForms.Guna2ComboBox cboCliente;  // 👈 oculto, usado para ValueMember
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel panelKPIs;
        private Guna.UI2.WinForms.Guna2Panel cardTotalVendido;
        private System.Windows.Forms.Label lblTotalVendido;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Panel cardTicketPromedio;
        private System.Windows.Forms.Label lblTicketPromedio;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2Panel cardNumFacturas;
        private System.Windows.Forms.Label lblNumFacturas;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2Panel panelContenido;
        private Guna.UI2.WinForms.Guna2DataGridView dgvReporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCajero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
    }
}
