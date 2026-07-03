namespace LogiPharm.Presentacion
{
    partial class FrmMedicamentosControlados
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
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.dgvControlados = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrincipio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeguimiento = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelFilters.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvControlados)).BeginInit();
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
            this.lblTitulo.Size = new System.Drawing.Size(462, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Medicamentos Controlados / Psicotrópicos";
            // 
            // panelFilters
            // 
            this.panelFilters.BackColor = System.Drawing.Color.White;
            this.panelFilters.Controls.Add(this.btnExportar);
            this.panelFilters.Controls.Add(this.btnBuscar);
            this.panelFilters.Controls.Add(this.txtBusqueda);
            this.panelFilters.Controls.Add(this.lblBuscar);
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
            this.btnExportar.Location = new System.Drawing.Point(860, 15);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(128, 30);
            this.btnExportar.TabIndex = 3;
            this.btnExportar.Text = "Exportar Reporte";
            this.btnExportar.UseVisualStyleBackColor = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(340, 15);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 30);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtBusqueda.Location = new System.Drawing.Point(70, 18);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(260, 25);
            this.txtBusqueda.TabIndex = 1;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblBuscar.Location = new System.Drawing.Point(12, 21);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(52, 17);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar:";
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.dgvControlados);
            this.panelContent.Controls.Add(this.lblTotal);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 120);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(12);
            this.panelContent.Size = new System.Drawing.Size(1000, 480);
            this.panelContent.TabIndex = 2;
            // 
            // dgvControlados
            // 
            this.dgvControlados.AllowUserToAddRows = false;
            this.dgvControlados.AllowUserToDeleteRows = false;
            this.dgvControlados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvControlados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvControlados.BackgroundColor = System.Drawing.Color.White;
            this.dgvControlados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvControlados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colNombre,
            this.colPrincipio,
            this.colStock,
            this.colRegistro,
            this.colSeguimiento});
            this.dgvControlados.Location = new System.Drawing.Point(12, 12);
            this.dgvControlados.Name = "dgvControlados";
            this.dgvControlados.ReadOnly = true;
            this.dgvControlados.Size = new System.Drawing.Size(976, 422);
            this.dgvControlados.TabIndex = 0;
            // 
            // colCodigo
            // 
            this.colCodigo.DataPropertyName = "Codigo";
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Width = 120;
            // 
            // colNombre
            // 
            this.colNombre.DataPropertyName = "Nombre";
            this.colNombre.HeaderText = "Medicamento";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            this.colNombre.Width = 250;
            // 
            // colPrincipio
            // 
            this.colPrincipio.DataPropertyName = "PrincipioActivo";
            this.colPrincipio.HeaderText = "Principio Activo";
            this.colPrincipio.Name = "colPrincipio";
            this.colPrincipio.ReadOnly = true;
            this.colPrincipio.Width = 200;
            // 
            // colStock
            // 
            this.colStock.DataPropertyName = "Stock";
            this.colStock.HeaderText = "Stock";
            this.colStock.Name = "colStock";
            this.colStock.ReadOnly = true;
            this.colStock.Width = 90;
            // 
            // colRegistro
            // 
            this.colRegistro.DataPropertyName = "RegistroSanitario";
            this.colRegistro.HeaderText = "Reg. Sanitario";
            this.colRegistro.Name = "colRegistro";
            this.colRegistro.ReadOnly = true;
            this.colRegistro.Width = 140;
            // 
            // colSeguimiento
            // 
            this.colSeguimiento.DataPropertyName = "RequiereSeguimiento";
            this.colSeguimiento.HeaderText = "Req. Receta";
            this.colSeguimiento.Name = "colSeguimiento";
            this.colSeguimiento.ReadOnly = true;
            this.colSeguimiento.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSeguimiento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSeguimiento.Width = 100;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(12, 447);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(288, 19);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Medicamentos controlados registrados: 0";
            // 
            // FrmMedicamentosControlados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelFilters);
            this.Controls.Add(this.panelHeader);
            this.Name = "FrmMedicamentosControlados";
            this.Text = "Medicamentos Controlados / Psicotrópicos";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvControlados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.DataGridView dgvControlados;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrincipio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegistro;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSeguimiento;
    }
}
