namespace LogiPharm.Presentacion
{
    partial class FrmEmitirResultado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.groupResultado = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.groupPaciente = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnPacBuscar = new Guna.UI2.WinForms.Guna2Button();
            this.btnPacAdmin = new Guna.UI2.WinForms.Guna2Button();
            this.cboPaciente = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtMedico = new Guna.UI2.WinForms.Guna2TextBox();
            this.flowButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.btnImprimir = new Guna.UI2.WinForms.Guna2Button();
            this.btnCerrar = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            this.groupResultado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.groupPaciente.SuspendLayout();
            this.flowButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.BorderRadius = 20;
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.groupResultado);
            this.guna2Panel1.Controls.Add(this.groupPaciente);
            this.guna2Panel1.Controls.Add(this.flowButtons);
            this.guna2Panel1.Controls.Add(this.lblTitulo);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Padding = new System.Windows.Forms.Padding(15);
            this.guna2Panel1.Size = new System.Drawing.Size(700, 800);
            this.guna2Panel1.TabIndex = 0;
            // 
            // groupResultado
            // 
            this.groupResultado.BorderRadius = 8;
            this.groupResultado.Controls.Add(this.dgvResultados);
            this.groupResultado.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.groupResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupResultado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupResultado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.groupResultado.Location = new System.Drawing.Point(15, 188);
            this.groupResultado.Name = "groupResultado";
            this.groupResultado.Padding = new System.Windows.Forms.Padding(5);
            this.groupResultado.Size = new System.Drawing.Size(670, 545);
            this.groupResultado.TabIndex = 3;
            this.groupResultado.Text = "Resultados";
            // 
            // dgvResultados
            // 
            this.dgvResultados.AllowUserToAddRows = false;
            this.dgvResultados.AllowUserToDeleteRows = false;
            this.dgvResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResultados.BackgroundColor = System.Drawing.Color.White;
            this.dgvResultados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResultados.Location = new System.Drawing.Point(5, 45);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.Size = new System.Drawing.Size(660, 495);
            this.dgvResultados.TabIndex = 0;
            // 
            // groupPaciente
            // 
            this.groupPaciente.BorderRadius = 8;
            this.groupPaciente.Controls.Add(this.btnPacBuscar);
            this.groupPaciente.Controls.Add(this.btnPacAdmin);
            this.groupPaciente.Controls.Add(this.cboPaciente);
            this.groupPaciente.Controls.Add(this.txtMedico);
            this.groupPaciente.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.groupPaciente.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPaciente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupPaciente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.groupPaciente.Location = new System.Drawing.Point(15, 55);
            this.groupPaciente.Name = "groupPaciente";
            this.groupPaciente.Size = new System.Drawing.Size(670, 133);
            this.groupPaciente.TabIndex = 2;
            this.groupPaciente.Text = "Información del Paciente";
            // 
            // btnPacBuscar
            // 
            this.btnPacBuscar.BorderRadius = 6;
            this.btnPacBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPacBuscar.ForeColor = System.Drawing.Color.White;
            this.btnPacBuscar.Location = new System.Drawing.Point(536, 46);
            this.btnPacBuscar.Name = "btnPacBuscar";
            this.btnPacBuscar.Size = new System.Drawing.Size(120, 36);
            this.btnPacBuscar.TabIndex = 12;
            this.btnPacBuscar.Text = "Buscar...";
            // 
            // btnPacAdmin
            // 
            this.btnPacAdmin.BorderRadius = 6;
            this.btnPacAdmin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPacAdmin.ForeColor = System.Drawing.Color.White;
            this.btnPacAdmin.Location = new System.Drawing.Point(410, 46);
            this.btnPacAdmin.Name = "btnPacAdmin";
            this.btnPacAdmin.Size = new System.Drawing.Size(120, 36);
            this.btnPacAdmin.TabIndex = 11;
            this.btnPacAdmin.Text = "Administrar...";
            // 
            // cboPaciente
            // 
            this.cboPaciente.BackColor = System.Drawing.Color.Transparent;
            this.cboPaciente.BorderRadius = 6;
            this.cboPaciente.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaciente.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboPaciente.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboPaciente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboPaciente.ForeColor = System.Drawing.Color.Black;
            this.cboPaciente.ItemHeight = 30;
            this.cboPaciente.Location = new System.Drawing.Point(14, 46);
            this.cboPaciente.Name = "cboPaciente";
            this.cboPaciente.Size = new System.Drawing.Size(390, 36);
            this.cboPaciente.TabIndex = 10;
            // 
            // txtMedico
            // 
            this.txtMedico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMedico.BorderRadius = 6;
            this.txtMedico.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMedico.DefaultText = "";
            this.txtMedico.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMedico.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMedico.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMedico.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMedico.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMedico.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMedico.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMedico.Location = new System.Drawing.Point(14, 88);
            this.txtMedico.Name = "txtMedico";
            this.txtMedico.PlaceholderText = "Médico Solicitante";
            this.txtMedico.SelectedText = "";
            this.txtMedico.Size = new System.Drawing.Size(640, 36);
            this.txtMedico.TabIndex = 2;
            // 
            // flowButtons
            // 
            this.flowButtons.Controls.Add(this.btnGuardar);
            this.flowButtons.Controls.Add(this.btnImprimir);
            this.flowButtons.Controls.Add(this.btnCerrar);
            this.flowButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowButtons.Location = new System.Drawing.Point(15, 733);
            this.flowButtons.Name = "flowButtons";
            this.flowButtons.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.flowButtons.Size = new System.Drawing.Size(670, 52);
            this.flowButtons.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BorderRadius = 6;
            this.btnGuardar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGuardar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGuardar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGuardar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(527, 8);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(140, 36);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BorderRadius = 6;
            this.btnImprimir.BorderThickness = 1;
            this.btnImprimir.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnImprimir.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnImprimir.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnImprimir.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnImprimir.FillColor = System.Drawing.Color.White;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnImprimir.Location = new System.Drawing.Point(406, 8);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(115, 36);
            this.btnImprimir.TabIndex = 0;
            this.btnImprimir.Text = "Imprimir";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BorderRadius = 6;
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCerrar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCerrar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCerrar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCerrar.FillColor = System.Drawing.Color.Gainsboro;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCerrar.Location = new System.Drawing.Point(285, 8);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(115, 36);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(15, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.lblTitulo.Size = new System.Drawing.Size(201, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Emisión de Resultado";
            // 
            // FrmEmitirResultado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(700, 800);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEmitirResultado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Emisión de Resultado";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.groupResultado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.groupPaciente.ResumeLayout(false);
            this.flowButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.FlowLayoutPanel flowButtons;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private Guna.UI2.WinForms.Guna2Button btnImprimir;
        private Guna.UI2.WinForms.Guna2Button btnCerrar;
        private Guna.UI2.WinForms.Guna2GroupBox groupPaciente;
        private Guna.UI2.WinForms.Guna2TextBox txtMedico;
        private Guna.UI2.WinForms.Guna2GroupBox groupResultado;
        private System.Windows.Forms.DataGridView dgvResultados;
        private Guna.UI2.WinForms.Guna2ComboBox cboPaciente;
        private Guna.UI2.WinForms.Guna2Button btnPacAdmin;
        private Guna.UI2.WinForms.Guna2Button btnPacBuscar;
    }
}
