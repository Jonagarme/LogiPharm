namespace LogiPharm.Presentacion
{
    partial class FrmRecetasMedicas
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.SplitContainer splitContainer1;

        private Guna.UI2.WinForms.Guna2Panel panelToolbar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.FlowLayoutPanel flowToolbarButtons;
        private Guna.UI2.WinForms.Guna2Button btnNuevo;
        private Guna.UI2.WinForms.Guna2Button btnEditar;
        private Guna.UI2.WinForms.Guna2Button btnEliminar;
        private Guna.UI2.WinForms.Guna2Button btnRecargar;
        private Guna.UI2.WinForms.Guna2Button btnExportar;

        private Guna.UI2.WinForms.Guna2Panel panelListado;
        private System.Windows.Forms.Panel panelListadoTop;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private System.Windows.Forms.Label lblTotal;
        private Guna.UI2.WinForms.Guna2DataGridView dgvRecetas;

        private Guna.UI2.WinForms.Guna2Panel panelEditor;
        private System.Windows.Forms.TableLayoutPanel tableEditor;
        private System.Windows.Forms.Label lblEditorTitulo;
        private Guna.UI2.WinForms.Guna2TextBox txtNumeroReceta;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEmision;
        private Guna.UI2.WinForms.Guna2TextBox txtPaciente;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpVencimiento;
        private Guna.UI2.WinForms.Guna2TextBox txtMedico;
        private Guna.UI2.WinForms.Guna2ComboBox cboEstado;
        private Guna.UI2.WinForms.Guna2TextBox txtRegistro;
        private Guna.UI2.WinForms.Guna2TextBox txtEspecialidad;
        private Guna.UI2.WinForms.Guna2TextBox txtObservaciones;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDetalles;
        private Guna.UI2.WinForms.Guna2Panel panelEditorBottom;
        private System.Windows.Forms.FlowLayoutPanel flowDetalleButtons;
        private System.Windows.Forms.FlowLayoutPanel flowEditorActions;
        private Guna.UI2.WinForms.Guna2Button btnAgregarDetalle;
        private Guna.UI2.WinForms.Guna2Button btnQuitarDetalle;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelListado = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvRecetas = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panelListadoTop = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.panelToolbar = new Guna.UI2.WinForms.Guna2Panel();
            this.flowToolbarButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExportar = new Guna.UI2.WinForms.Guna2Button();
            this.btnRecargar = new Guna.UI2.WinForms.Guna2Button();
            this.btnEliminar = new Guna.UI2.WinForms.Guna2Button();
            this.btnEditar = new Guna.UI2.WinForms.Guna2Button();
            this.btnNuevo = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelEditor = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvDetalles = new Guna.UI2.WinForms.Guna2DataGridView();
            this.tableEditor = new System.Windows.Forms.TableLayoutPanel();
            this.lblEditorTitulo = new System.Windows.Forms.Label();
            this.txtNumeroReceta = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpEmision = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtPaciente = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpVencimiento = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtMedico = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboEstado = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtRegistro = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEspecialidad = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtObservaciones = new Guna.UI2.WinForms.Guna2TextBox();
            this.panelEditorBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.flowEditorActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            this.flowDetalleButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAgregarDetalle = new Guna.UI2.WinForms.Guna2Button();
            this.btnQuitarDetalle = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecetas)).BeginInit();
            this.panelListadoTop.SuspendLayout();
            this.panelToolbar.SuspendLayout();
            this.flowToolbarButtons.SuspendLayout();
            this.panelEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.tableEditor.SuspendLayout();
            this.panelEditorBottom.SuspendLayout();
            this.flowEditorActions.SuspendLayout();
            this.flowDetalleButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelListado);
            this.splitContainer1.Panel1.Controls.Add(this.panelToolbar);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelEditor);
            this.splitContainer1.Size = new System.Drawing.Size(1200, 720);
            this.splitContainer1.SplitterDistance = 720;
            this.splitContainer1.TabIndex = 0;
            // 
            // panelListado
            // 
            this.panelListado.Controls.Add(this.dgvRecetas);
            this.panelListado.Controls.Add(this.panelListadoTop);
            this.panelListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelListado.Location = new System.Drawing.Point(0, 74);
            this.panelListado.Name = "panelListado";
            this.panelListado.Padding = new System.Windows.Forms.Padding(12);
            this.panelListado.Size = new System.Drawing.Size(720, 646);
            this.panelListado.TabIndex = 1;
            // 
            // dgvRecetas
            // 
            this.dgvRecetas.AllowUserToAddRows = false;
            this.dgvRecetas.AllowUserToDeleteRows = false;
            this.dgvRecetas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvRecetas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecetas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecetas.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRecetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecetas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRecetas.Location = new System.Drawing.Point(12, 68);
            this.dgvRecetas.MultiSelect = false;
            this.dgvRecetas.Name = "dgvRecetas";
            this.dgvRecetas.ReadOnly = true;
            this.dgvRecetas.RowHeadersVisible = false;
            this.dgvRecetas.RowTemplate.Height = 34;
            this.dgvRecetas.Size = new System.Drawing.Size(696, 566);
            this.dgvRecetas.TabIndex = 1;
            this.dgvRecetas.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRecetas.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvRecetas.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvRecetas.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvRecetas.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvRecetas.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvRecetas.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRecetas.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvRecetas.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRecetas.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRecetas.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvRecetas.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRecetas.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvRecetas.ThemeStyle.ReadOnly = true;
            this.dgvRecetas.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRecetas.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRecetas.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRecetas.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvRecetas.ThemeStyle.RowsStyle.Height = 34;
            this.dgvRecetas.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRecetas.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // panelListadoTop
            // 
            this.panelListadoTop.Controls.Add(this.lblTotal);
            this.panelListadoTop.Controls.Add(this.txtBuscar);
            this.panelListadoTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelListadoTop.Location = new System.Drawing.Point(12, 12);
            this.panelListadoTop.Name = "panelListadoTop";
            this.panelListadoTop.Size = new System.Drawing.Size(696, 56);
            this.panelListadoTop.TabIndex = 0;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTotal.Location = new System.Drawing.Point(0, 38);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.lblTotal.Size = new System.Drawing.Size(45, 18);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Total: 0";
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderRadius = 8;
            this.txtBuscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscar.DefaultText = "";
            this.txtBuscar.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscar.Location = new System.Drawing.Point(0, 0);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PlaceholderText = "Buscar por número, paciente o médico...";
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.Size = new System.Drawing.Size(696, 32);
            this.txtBuscar.TabIndex = 0;
            // 
            // panelToolbar
            // 
            this.panelToolbar.Controls.Add(this.flowToolbarButtons);
            this.panelToolbar.Controls.Add(this.lblTitulo);
            this.panelToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolbar.Location = new System.Drawing.Point(0, 0);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.panelToolbar.Size = new System.Drawing.Size(720, 74);
            this.panelToolbar.TabIndex = 0;
            // 
            // flowToolbarButtons
            // 
            this.flowToolbarButtons.AutoSize = true;
            this.flowToolbarButtons.Controls.Add(this.btnExportar);
            this.flowToolbarButtons.Controls.Add(this.btnRecargar);
            this.flowToolbarButtons.Controls.Add(this.btnEliminar);
            this.flowToolbarButtons.Controls.Add(this.btnEditar);
            this.flowToolbarButtons.Controls.Add(this.btnNuevo);
            this.flowToolbarButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowToolbarButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowToolbarButtons.Location = new System.Drawing.Point(186, 10);
            this.flowToolbarButtons.Name = "flowToolbarButtons";
            this.flowToolbarButtons.Size = new System.Drawing.Size(522, 54);
            this.flowToolbarButtons.TabIndex = 1;
            this.flowToolbarButtons.WrapContents = false;
            // 
            // btnExportar
            // 
            this.btnExportar.BorderRadius = 8;
            this.btnExportar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(132)))), ((int)(((byte)(73)))));
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(412, 3);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(110, 45);
            this.btnExportar.TabIndex = 0;
            this.btnExportar.Text = "Exportar";
            // 
            // btnRecargar
            // 
            this.btnRecargar.BorderRadius = 8;
            this.btnRecargar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRecargar.ForeColor = System.Drawing.Color.White;
            this.btnRecargar.Location = new System.Drawing.Point(302, 3);
            this.btnRecargar.Margin = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.btnRecargar.Name = "btnRecargar";
            this.btnRecargar.Size = new System.Drawing.Size(110, 45);
            this.btnRecargar.TabIndex = 1;
            this.btnRecargar.Text = "Recargar";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BorderRadius = 8;
            this.btnEliminar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(184, 3);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(110, 45);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            // 
            // btnEditar
            // 
            this.btnEditar.BorderRadius = 8;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(66, 3);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(110, 45);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Editar";
            // 
            // btnNuevo
            // 
            this.btnNuevo.BorderRadius = 8;
            this.btnNuevo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(8, 3);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(50, 45);
            this.btnNuevo.TabIndex = 4;
            this.btnNuevo.Text = "+";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitulo.Location = new System.Drawing.Point(12, 21);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(154, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Recetas médicas";
            // 
            // panelEditor
            // 
            this.panelEditor.Controls.Add(this.dgvDetalles);
            this.panelEditor.Controls.Add(this.tableEditor);
            this.panelEditor.Controls.Add(this.panelEditorBottom);
            this.panelEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEditor.Location = new System.Drawing.Point(0, 0);
            this.panelEditor.Name = "panelEditor";
            this.panelEditor.Padding = new System.Windows.Forms.Padding(12);
            this.panelEditor.Size = new System.Drawing.Size(476, 720);
            this.panelEditor.TabIndex = 0;
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvDetalles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalles.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDetalles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetalles.Location = new System.Drawing.Point(12, 276);
            this.dgvDetalles.MultiSelect = false;
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.RowHeadersVisible = false;
            this.dgvDetalles.RowTemplate.Height = 32;
            this.dgvDetalles.Size = new System.Drawing.Size(452, 384);
            this.dgvDetalles.TabIndex = 1;
            this.dgvDetalles.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetalles.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDetalles.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDetalles.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDetalles.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDetalles.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetalles.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetalles.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvDetalles.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDetalles.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetalles.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDetalles.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetalles.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvDetalles.ThemeStyle.ReadOnly = false;
            this.dgvDetalles.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetalles.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDetalles.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetalles.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDetalles.ThemeStyle.RowsStyle.Height = 32;
            this.dgvDetalles.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetalles.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // tableEditor
            // 
            this.tableEditor.ColumnCount = 2;
            this.tableEditor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableEditor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableEditor.Controls.Add(this.lblEditorTitulo, 0, 0);
            this.tableEditor.Controls.Add(this.txtNumeroReceta, 0, 1);
            this.tableEditor.Controls.Add(this.dtpEmision, 1, 1);
            this.tableEditor.Controls.Add(this.txtPaciente, 0, 2);
            this.tableEditor.Controls.Add(this.dtpVencimiento, 1, 2);
            this.tableEditor.Controls.Add(this.txtMedico, 0, 3);
            this.tableEditor.Controls.Add(this.cboEstado, 1, 3);
            this.tableEditor.Controls.Add(this.txtRegistro, 0, 4);
            this.tableEditor.Controls.Add(this.txtEspecialidad, 1, 4);
            this.tableEditor.Controls.Add(this.txtObservaciones, 0, 5);
            this.tableEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableEditor.Location = new System.Drawing.Point(12, 12);
            this.tableEditor.Name = "tableEditor";
            this.tableEditor.RowCount = 6;
            this.tableEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableEditor.Size = new System.Drawing.Size(452, 264);
            this.tableEditor.TabIndex = 0;
            // 
            // lblEditorTitulo
            // 
            this.lblEditorTitulo.AutoSize = true;
            this.tableEditor.SetColumnSpan(this.lblEditorTitulo, 2);
            this.lblEditorTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblEditorTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblEditorTitulo.Location = new System.Drawing.Point(3, 0);
            this.lblEditorTitulo.Name = "lblEditorTitulo";
            this.lblEditorTitulo.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lblEditorTitulo.Size = new System.Drawing.Size(105, 26);
            this.lblEditorTitulo.TabIndex = 0;
            this.lblEditorTitulo.Text = "Detalle receta";
            // 
            // txtNumeroReceta
            // 
            this.txtNumeroReceta.BorderRadius = 8;
            this.txtNumeroReceta.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNumeroReceta.DefaultText = "";
            this.txtNumeroReceta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNumeroReceta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNumeroReceta.Location = new System.Drawing.Point(3, 37);
            this.txtNumeroReceta.Name = "txtNumeroReceta";
            this.txtNumeroReceta.PlaceholderText = "N° Receta";
            this.txtNumeroReceta.SelectedText = "";
            this.txtNumeroReceta.Size = new System.Drawing.Size(220, 34);
            this.txtNumeroReceta.TabIndex = 1;
            // 
            // dtpEmision
            // 
            this.dtpEmision.BorderRadius = 8;
            this.dtpEmision.Checked = true;
            this.dtpEmision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpEmision.FillColor = System.Drawing.Color.White;
            this.dtpEmision.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEmision.Location = new System.Drawing.Point(229, 37);
            this.dtpEmision.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEmision.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEmision.Name = "dtpEmision";
            this.dtpEmision.Size = new System.Drawing.Size(220, 34);
            this.dtpEmision.TabIndex = 2;
            this.dtpEmision.Value = new System.DateTime(2026, 3, 25, 23, 53, 6, 892);
            // 
            // txtPaciente
            // 
            this.txtPaciente.BorderRadius = 8;
            this.txtPaciente.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPaciente.DefaultText = "";
            this.txtPaciente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPaciente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPaciente.Location = new System.Drawing.Point(3, 77);
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.PlaceholderText = "Paciente";
            this.txtPaciente.SelectedText = "";
            this.txtPaciente.Size = new System.Drawing.Size(220, 34);
            this.txtPaciente.TabIndex = 3;
            // 
            // dtpVencimiento
            // 
            this.dtpVencimiento.BorderRadius = 8;
            this.dtpVencimiento.Checked = true;
            this.dtpVencimiento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpVencimiento.FillColor = System.Drawing.Color.White;
            this.dtpVencimiento.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVencimiento.Location = new System.Drawing.Point(229, 77);
            this.dtpVencimiento.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpVencimiento.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpVencimiento.Name = "dtpVencimiento";
            this.dtpVencimiento.Size = new System.Drawing.Size(220, 34);
            this.dtpVencimiento.TabIndex = 4;
            this.dtpVencimiento.Value = new System.DateTime(2026, 3, 25, 23, 53, 6, 927);
            // 
            // txtMedico
            // 
            this.txtMedico.BorderRadius = 8;
            this.txtMedico.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMedico.DefaultText = "";
            this.txtMedico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMedico.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMedico.Location = new System.Drawing.Point(3, 117);
            this.txtMedico.Name = "txtMedico";
            this.txtMedico.PlaceholderText = "Médico";
            this.txtMedico.SelectedText = "";
            this.txtMedico.Size = new System.Drawing.Size(220, 34);
            this.txtMedico.TabIndex = 5;
            // 
            // cboEstado
            // 
            this.cboEstado.BackColor = System.Drawing.Color.Transparent;
            this.cboEstado.BorderRadius = 8;
            this.cboEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FocusedColor = System.Drawing.Color.Empty;
            this.cboEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboEstado.ItemHeight = 30;
            this.cboEstado.Location = new System.Drawing.Point(229, 117);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(220, 36);
            this.cboEstado.TabIndex = 6;
            // 
            // txtRegistro
            // 
            this.txtRegistro.BorderRadius = 8;
            this.txtRegistro.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRegistro.DefaultText = "";
            this.txtRegistro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRegistro.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRegistro.Location = new System.Drawing.Point(3, 157);
            this.txtRegistro.Name = "txtRegistro";
            this.txtRegistro.PlaceholderText = "Registro médico";
            this.txtRegistro.SelectedText = "";
            this.txtRegistro.Size = new System.Drawing.Size(220, 34);
            this.txtRegistro.TabIndex = 7;
            // 
            // txtEspecialidad
            // 
            this.txtEspecialidad.BorderRadius = 8;
            this.txtEspecialidad.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEspecialidad.DefaultText = "";
            this.txtEspecialidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEspecialidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEspecialidad.Location = new System.Drawing.Point(229, 157);
            this.txtEspecialidad.Name = "txtEspecialidad";
            this.txtEspecialidad.PlaceholderText = "Especialidad";
            this.txtEspecialidad.SelectedText = "";
            this.txtEspecialidad.Size = new System.Drawing.Size(220, 34);
            this.txtEspecialidad.TabIndex = 8;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.BorderRadius = 8;
            this.tableEditor.SetColumnSpan(this.txtObservaciones, 2);
            this.txtObservaciones.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtObservaciones.DefaultText = "";
            this.txtObservaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtObservaciones.Location = new System.Drawing.Point(3, 197);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.PlaceholderText = "Observaciones";
            this.txtObservaciones.SelectedText = "";
            this.txtObservaciones.Size = new System.Drawing.Size(446, 64);
            this.txtObservaciones.TabIndex = 9;
            // 
            // panelEditorBottom
            // 
            this.panelEditorBottom.Controls.Add(this.flowEditorActions);
            this.panelEditorBottom.Controls.Add(this.flowDetalleButtons);
            this.panelEditorBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEditorBottom.Location = new System.Drawing.Point(12, 660);
            this.panelEditorBottom.Name = "panelEditorBottom";
            this.panelEditorBottom.Size = new System.Drawing.Size(452, 48);
            this.panelEditorBottom.TabIndex = 2;
            // 
            // flowEditorActions
            // 
            this.flowEditorActions.AutoSize = true;
            this.flowEditorActions.Controls.Add(this.btnGuardar);
            this.flowEditorActions.Controls.Add(this.btnCancelar);
            this.flowEditorActions.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowEditorActions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowEditorActions.Location = new System.Drawing.Point(243, 0);
            this.flowEditorActions.Name = "flowEditorActions";
            this.flowEditorActions.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.flowEditorActions.Size = new System.Drawing.Size(209, 48);
            this.flowEditorActions.TabIndex = 1;
            this.flowEditorActions.WrapContents = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BorderRadius = 8;
            this.btnGuardar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(106, 3);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(0);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(103, 42);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BorderRadius = 8;
            this.btnCancelar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnCancelar.Location = new System.Drawing.Point(6, 3);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 42);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            // 
            // flowDetalleButtons
            // 
            this.flowDetalleButtons.AutoSize = true;
            this.flowDetalleButtons.Controls.Add(this.btnAgregarDetalle);
            this.flowDetalleButtons.Controls.Add(this.btnQuitarDetalle);
            this.flowDetalleButtons.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowDetalleButtons.Location = new System.Drawing.Point(0, 0);
            this.flowDetalleButtons.Name = "flowDetalleButtons";
            this.flowDetalleButtons.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.flowDetalleButtons.Size = new System.Drawing.Size(236, 48);
            this.flowDetalleButtons.TabIndex = 0;
            this.flowDetalleButtons.WrapContents = false;
            // 
            // btnAgregarDetalle
            // 
            this.btnAgregarDetalle.BorderRadius = 8;
            this.btnAgregarDetalle.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnAgregarDetalle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnAgregarDetalle.Location = new System.Drawing.Point(0, 3);
            this.btnAgregarDetalle.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnAgregarDetalle.Name = "btnAgregarDetalle";
            this.btnAgregarDetalle.Size = new System.Drawing.Size(115, 42);
            this.btnAgregarDetalle.TabIndex = 0;
            this.btnAgregarDetalle.Text = "Agregar";
            // 
            // btnQuitarDetalle
            // 
            this.btnQuitarDetalle.BorderRadius = 8;
            this.btnQuitarDetalle.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnQuitarDetalle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnQuitarDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnQuitarDetalle.Location = new System.Drawing.Point(121, 3);
            this.btnQuitarDetalle.Margin = new System.Windows.Forms.Padding(0);
            this.btnQuitarDetalle.Name = "btnQuitarDetalle";
            this.btnQuitarDetalle.Size = new System.Drawing.Size(115, 42);
            this.btnQuitarDetalle.TabIndex = 1;
            this.btnQuitarDetalle.Text = "Quitar";
            // 
            // FrmRecetasMedicas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmRecetasMedicas";
            this.Text = "Recetas médicas";
            this.Load += new System.EventHandler(this.FrmRecetasMedicas_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecetas)).EndInit();
            this.panelListadoTop.ResumeLayout(false);
            this.panelListadoTop.PerformLayout();
            this.panelToolbar.ResumeLayout(false);
            this.panelToolbar.PerformLayout();
            this.flowToolbarButtons.ResumeLayout(false);
            this.panelEditor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.tableEditor.ResumeLayout(false);
            this.tableEditor.PerformLayout();
            this.panelEditorBottom.ResumeLayout(false);
            this.panelEditorBottom.PerformLayout();
            this.flowEditorActions.ResumeLayout(false);
            this.flowDetalleButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
