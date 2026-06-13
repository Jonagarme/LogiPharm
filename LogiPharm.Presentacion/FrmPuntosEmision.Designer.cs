namespace LogiPharm.Presentacion
{
    partial class FrmPuntosEmision
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.SplitContainer splitContainer1;

        private Guna.UI2.WinForms.Guna2Panel panelLeftTop;
        private System.Windows.Forms.Label lblEstablecimientos;
        private System.Windows.Forms.FlowLayoutPanel flpEstButtons;
        private Guna.UI2.WinForms.Guna2Button btnNuevoEstab;
        private Guna.UI2.WinForms.Guna2Button btnEditarEstab;
        private Guna.UI2.WinForms.Guna2Button btnEliminarEstab;
        private Guna.UI2.WinForms.Guna2DataGridView dgvEstablecimientos;

        private Guna.UI2.WinForms.Guna2Panel panelRightTop;
        private System.Windows.Forms.Label lblPuntos;
        private System.Windows.Forms.FlowLayoutPanel flpPuntoButtons;
        private Guna.UI2.WinForms.Guna2Button btnNuevoPunto;
        private Guna.UI2.WinForms.Guna2Button btnEditarPunto;
        private Guna.UI2.WinForms.Guna2Button btnEliminarPunto;
        private Guna.UI2.WinForms.Guna2DataGridView dgvPuntos;

        private System.Windows.Forms.DataGridViewTextBoxColumn colEstId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstEstado;

        private System.Windows.Forms.DataGridViewTextBoxColumn colPtoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPtoCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPtoDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPtoUsuario;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colPtoActivo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelLeftTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblEstablecimientos = new System.Windows.Forms.Label();
            this.flpEstButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNuevoEstab = new Guna.UI2.WinForms.Guna2Button();
            this.btnEditarEstab = new Guna.UI2.WinForms.Guna2Button();
            this.btnEliminarEstab = new Guna.UI2.WinForms.Guna2Button();
            this.dgvEstablecimientos = new Guna.UI2.WinForms.Guna2DataGridView();

            this.panelRightTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPuntos = new System.Windows.Forms.Label();
            this.flpPuntoButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNuevoPunto = new Guna.UI2.WinForms.Guna2Button();
            this.btnEditarPunto = new Guna.UI2.WinForms.Guna2Button();
            this.btnEliminarPunto = new Guna.UI2.WinForms.Guna2Button();
            this.dgvPuntos = new Guna.UI2.WinForms.Guna2DataGridView();

            this.colEstId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.colPtoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPtoCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPtoDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPtoUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPtoActivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();

            this.panelLeftTop.SuspendLayout();
            this.flpEstButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstablecimientos)).BeginInit();

            this.panelRightTop.SuspendLayout();
            this.flpPuntoButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPuntos)).BeginInit();

            this.SuspendLayout();

            // 
            // FrmPuntosEmision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Name = "FrmPuntosEmision";
            this.Text = "Configuración de Puntos de Emisión";

            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.splitContainer1.SplitterDistance = 380;

            // 
            // Panel1 (Establecimientos)
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvEstablecimientos);
            this.splitContainer1.Panel1.Controls.Add(this.panelLeftTop);

            // 
            // panelLeftTop
            // 
            this.panelLeftTop.BackColor = System.Drawing.Color.White;
            this.panelLeftTop.FillColor = System.Drawing.Color.White;
            this.panelLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLeftTop.Height = 80;
            this.panelLeftTop.Controls.Add(this.flpEstButtons);
            this.panelLeftTop.Controls.Add(this.lblEstablecimientos);

            // lblEstablecimientos
            this.lblEstablecimientos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEstablecimientos.Height = 35;
            this.lblEstablecimientos.Text = "Establecimientos";
            this.lblEstablecimientos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblEstablecimientos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEstablecimientos.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);

            // flpEstButtons
            this.flpEstButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpEstButtons.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flpEstButtons.Padding = new System.Windows.Forms.Padding(10, 8, 0, 0);
            this.flpEstButtons.Controls.Add(this.btnNuevoEstab);
            this.flpEstButtons.Controls.Add(this.btnEditarEstab);
            this.flpEstButtons.Controls.Add(this.btnEliminarEstab);

            // btnNuevoEstab
            this.btnNuevoEstab.Text = "Nuevo";
            this.btnNuevoEstab.Width = 90;
            this.btnNuevoEstab.Height = 30;
            this.btnNuevoEstab.BorderRadius = 6;
            this.btnNuevoEstab.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnNuevoEstab.ForeColor = System.Drawing.Color.White;

            // btnEditarEstab
            this.btnEditarEstab.Text = "Editar";
            this.btnEditarEstab.Width = 90;
            this.btnEditarEstab.Height = 30;
            this.btnEditarEstab.BorderRadius = 6;
            this.btnEditarEstab.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.btnEditarEstab.ForeColor = System.Drawing.Color.White;

            // btnEliminarEstab
            this.btnEliminarEstab.Text = "Eliminar";
            this.btnEliminarEstab.Width = 90;
            this.btnEliminarEstab.Height = 30;
            this.btnEliminarEstab.BorderRadius = 6;
            this.btnEliminarEstab.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnEliminarEstab.ForeColor = System.Drawing.Color.White;

            // dgvEstablecimientos
            this.dgvEstablecimientos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEstablecimientos.AllowUserToAddRows = false;
            this.dgvEstablecimientos.AllowUserToDeleteRows = false;
            this.dgvEstablecimientos.AllowUserToResizeRows = false;
            this.dgvEstablecimientos.RowHeadersVisible = false;
            this.dgvEstablecimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstablecimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEstablecimientos.BackgroundColor = System.Drawing.Color.White;
            this.dgvEstablecimientos.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvEstablecimientos.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.dgvEstablecimientos.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.dgvEstablecimientos.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.dgvEstablecimientos.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.dgvEstablecimientos.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvEstablecimientos.ThemeStyle.HeaderStyle.Height = 32;
            this.dgvEstablecimientos.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvEstablecimientos.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.dgvEstablecimientos.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(228)))), ((int)(((byte)(255)))));
            this.dgvEstablecimientos.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.dgvEstablecimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colEstId, this.colEstCodigo, this.colEstNombre, this.colEstEstado
            });

            this.colEstId.DataPropertyName = "id";
            this.colEstId.HeaderText = "Id";
            this.colEstId.Visible = false;

            this.colEstCodigo.DataPropertyName = "codigo";
            this.colEstCodigo.HeaderText = "Código";
            this.colEstCodigo.FillWeight = 20F;

            this.colEstNombre.DataPropertyName = "nombre_comercial";
            this.colEstNombre.HeaderText = "Nombre comercial";
            this.colEstNombre.FillWeight = 60F;

            this.colEstEstado.DataPropertyName = "estado";
            this.colEstEstado.HeaderText = "Estado";
            this.colEstEstado.FillWeight = 20F;

            // 
            // Panel2 (Puntos)
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvPuntos);
            this.splitContainer1.Panel2.Controls.Add(this.panelRightTop);

            // panelRightTop
            this.panelRightTop.BackColor = System.Drawing.Color.White;
            this.panelRightTop.FillColor = System.Drawing.Color.White;
            this.panelRightTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRightTop.Height = 80;
            this.panelRightTop.Controls.Add(this.flpPuntoButtons);
            this.panelRightTop.Controls.Add(this.lblPuntos);

            // lblPuntos
            this.lblPuntos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPuntos.Height = 35;
            this.lblPuntos.Text = "Puntos de emisión";
            this.lblPuntos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPuntos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPuntos.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);

            // flpPuntoButtons
            this.flpPuntoButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpPuntoButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpPuntoButtons.Padding = new System.Windows.Forms.Padding(0, 8, 10, 0);
            this.flpPuntoButtons.Controls.Add(this.btnNuevoPunto);
            this.flpPuntoButtons.Controls.Add(this.btnEditarPunto);
            this.flpPuntoButtons.Controls.Add(this.btnEliminarPunto);

            // btnNuevoPunto
            this.btnNuevoPunto.Text = "Nuevo Punto";
            this.btnNuevoPunto.Width = 105;
            this.btnNuevoPunto.Height = 30;
            this.btnNuevoPunto.BorderRadius = 6;
            this.btnNuevoPunto.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnNuevoPunto.ForeColor = System.Drawing.Color.White;

            // btnEditarPunto
            this.btnEditarPunto.Text = "Editar";
            this.btnEditarPunto.Width = 90;
            this.btnEditarPunto.Height = 30;
            this.btnEditarPunto.BorderRadius = 6;
            this.btnEditarPunto.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.btnEditarPunto.ForeColor = System.Drawing.Color.White;

            // btnEliminarPunto
            this.btnEliminarPunto.Text = "Eliminar";
            this.btnEliminarPunto.Width = 90;
            this.btnEliminarPunto.Height = 30;
            this.btnEliminarPunto.BorderRadius = 6;
            this.btnEliminarPunto.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnEliminarPunto.ForeColor = System.Drawing.Color.White;

            // dgvPuntos
            this.dgvPuntos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPuntos.AllowUserToAddRows = false;
            this.dgvPuntos.AllowUserToDeleteRows = false;
            this.dgvPuntos.AllowUserToResizeRows = false;
            this.dgvPuntos.RowHeadersVisible = false;
            this.dgvPuntos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPuntos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPuntos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPuntos.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvPuntos.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.dgvPuntos.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.dgvPuntos.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.dgvPuntos.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.dgvPuntos.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvPuntos.ThemeStyle.HeaderStyle.Height = 32;
            this.dgvPuntos.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPuntos.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.dgvPuntos.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(228)))), ((int)(((byte)(255)))));
            this.dgvPuntos.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.dgvPuntos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colPtoId, this.colPtoCodigo, this.colPtoDescripcion, this.colPtoUsuario, this.colPtoActivo
            });

            this.colPtoId.DataPropertyName = "id";
            this.colPtoId.HeaderText = "Id";
            this.colPtoId.Visible = false;

            this.colPtoCodigo.DataPropertyName = "codigo";
            this.colPtoCodigo.HeaderText = "Código";
            this.colPtoCodigo.FillWeight = 15F;

            this.colPtoDescripcion.DataPropertyName = "descripcion";
            this.colPtoDescripcion.HeaderText = "Descripción";
            this.colPtoDescripcion.FillWeight = 45F;

            this.colPtoUsuario.DataPropertyName = "usuario_responsable";
            this.colPtoUsuario.HeaderText = "Responsable";
            this.colPtoUsuario.FillWeight = 25F;

            this.colPtoActivo.DataPropertyName = "activo";
            this.colPtoActivo.HeaderText = "Activo";
            this.colPtoActivo.FillWeight = 15F;

            // 
            // finalize
            // 
            this.Controls.Add(this.splitContainer1);

            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);

            this.panelLeftTop.ResumeLayout(false);
            this.flpEstButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstablecimientos)).EndInit();

            this.panelRightTop.ResumeLayout(false);
            this.flpPuntoButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPuntos)).EndInit();

            this.ResumeLayout(false);
        }
    }
}
