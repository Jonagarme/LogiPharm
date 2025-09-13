namespace LogiPharm.Presentacion
{
    partial class FrmPacientes
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.grpEdit = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtDoc = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNombre = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTel = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDir = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpNac = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.chkActivo = new Guna.UI2.WinForms.Guna2CheckBox();
            this.flowBtns = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNuevo = new Guna.UI2.WinForms.Guna2Button();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.btnEliminar = new Guna.UI2.WinForms.Guna2Button();
            this.btnCerrar = new Guna.UI2.WinForms.Guna2Button();
            this.grpListado = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgv = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panelMain.SuspendLayout();
            this.table.SuspendLayout();
            this.grpEdit.SuspendLayout();
            this.flowBtns.SuspendLayout();
            this.grpListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // panelMain
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Padding = new System.Windows.Forms.Padding(10);
            this.panelMain.Controls.Add(this.table);
            // table
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.ColumnCount = 1; this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table.RowCount = 3; this.table.RowStyles.Add(new System.Windows.Forms.RowStyle()); this.table.RowStyles.Add(new System.Windows.Forms.RowStyle()); this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table.Controls.Add(this.grpEdit, 0, 0);
            this.table.Controls.Add(this.flowBtns, 0, 1);
            this.table.Controls.Add(this.grpListado, 0, 2);
            // grpEdit
            this.grpEdit.Text = "Datos del Paciente"; this.grpEdit.BorderRadius = 8; this.grpEdit.Dock = System.Windows.Forms.DockStyle.Fill; this.grpEdit.Padding = new System.Windows.Forms.Padding(10);
            this.grpEdit.Controls.Add(this.txtDoc); this.grpEdit.Controls.Add(this.txtNombre); this.grpEdit.Controls.Add(this.txtTel); this.grpEdit.Controls.Add(this.txtEmail); this.grpEdit.Controls.Add(this.txtDir); this.grpEdit.Controls.Add(this.dtpNac); this.grpEdit.Controls.Add(this.chkActivo);
            this.txtDoc.PlaceholderText = "Documento"; this.txtDoc.Location = new System.Drawing.Point(13, 49); this.txtDoc.Size = new System.Drawing.Size(160, 36);
            this.txtNombre.PlaceholderText = "Nombre (*)"; this.txtNombre.Location = new System.Drawing.Point(179, 49); this.txtNombre.Size = new System.Drawing.Size(360, 36);
            this.dtpNac.Location = new System.Drawing.Point(545, 49); this.dtpNac.Size = new System.Drawing.Size(160, 36);
            this.chkActivo.Text = "Activo"; this.chkActivo.Location = new System.Drawing.Point(711, 58); this.chkActivo.Checked = true;
            this.txtTel.PlaceholderText = "Teléfono"; this.txtTel.Location = new System.Drawing.Point(13, 91); this.txtTel.Size = new System.Drawing.Size(160, 36);
            this.txtEmail.PlaceholderText = "Email"; this.txtEmail.Location = new System.Drawing.Point(179, 91); this.txtEmail.Size = new System.Drawing.Size(220, 36);
            this.txtDir.PlaceholderText = "Dirección"; this.txtDir.Location = new System.Drawing.Point(405, 91); this.txtDir.Size = new System.Drawing.Size(300, 36);
            // flowBtns
            this.flowBtns.Dock = System.Windows.Forms.DockStyle.Fill; this.flowBtns.Controls.Add(this.btnNuevo); this.flowBtns.Controls.Add(this.btnGuardar); this.flowBtns.Controls.Add(this.btnEliminar); this.flowBtns.Controls.Add(this.btnCerrar);
            this.btnNuevo.Text = "Nuevo"; this.btnGuardar.Text = "Guardar"; this.btnEliminar.Text = "Eliminar"; this.btnCerrar.Text = "Cerrar";
            // grpListado
            this.grpListado.Text = "Listado"; this.grpListado.BorderRadius = 8; this.grpListado.Dock = System.Windows.Forms.DockStyle.Fill; this.grpListado.Padding = new System.Windows.Forms.Padding(10);
            this.grpListado.Controls.Add(this.dgv); this.grpListado.Controls.Add(this.txtBuscar);
            this.txtBuscar.PlaceholderText = "Buscar por nombre o documento"; this.txtBuscar.Dock = System.Windows.Forms.DockStyle.Top; this.txtBuscar.Margin = new System.Windows.Forms.Padding(10);
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill; this.dgv.Location = new System.Drawing.Point(10, 66);
            // FrmPacientes
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Controls.Add(this.panelMain);
            this.Name = "FrmPacientes";
            this.Text = "Administración de Pacientes";
            this.panelMain.ResumeLayout(false);
            this.table.ResumeLayout(false);
            this.grpEdit.ResumeLayout(false);
            this.flowBtns.ResumeLayout(false);
            this.grpListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private System.Windows.Forms.TableLayoutPanel table;
        private Guna.UI2.WinForms.Guna2GroupBox grpEdit;
        private Guna.UI2.WinForms.Guna2TextBox txtDoc;
        private Guna.UI2.WinForms.Guna2TextBox txtNombre;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNac;
        private Guna.UI2.WinForms.Guna2TextBox txtTel;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtDir;
        private Guna.UI2.WinForms.Guna2CheckBox chkActivo;
        private System.Windows.Forms.FlowLayoutPanel flowBtns;
        private Guna.UI2.WinForms.Guna2Button btnNuevo;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private Guna.UI2.WinForms.Guna2Button btnEliminar;
        private Guna.UI2.WinForms.Guna2Button btnCerrar;
        private Guna.UI2.WinForms.Guna2GroupBox grpListado;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private Guna.UI2.WinForms.Guna2DataGridView dgv;
    }
}
