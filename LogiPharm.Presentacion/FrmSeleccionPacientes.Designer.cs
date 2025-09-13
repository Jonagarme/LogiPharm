namespace LogiPharm.Presentacion
{
    partial class FrmSeleccionPacientes
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.panel = new Guna.UI2.WinForms.Guna2Panel();
            this.txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgv = new Guna.UI2.WinForms.Guna2DataGridView();
            this.flow = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAceptar = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.flow.SuspendLayout();
            this.SuspendLayout();
            // panel
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill; this.panel.Padding = new System.Windows.Forms.Padding(10);
            this.panel.Controls.Add(this.dgv); this.panel.Controls.Add(this.txtBuscar); this.panel.Controls.Add(this.flow);
            // txtBuscar
            this.txtBuscar.Dock = System.Windows.Forms.DockStyle.Top; this.txtBuscar.PlaceholderText = "Buscar nombre o documento"; this.txtBuscar.Margin = new System.Windows.Forms.Padding(5);
            // dgv
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill; this.dgv.Margin = new System.Windows.Forms.Padding(5);
            // flow
            this.flow.Dock = System.Windows.Forms.DockStyle.Bottom; this.flow.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft; this.flow.Controls.Add(this.btnAceptar); this.flow.Controls.Add(this.btnCancelar);
            // btnAceptar
            this.btnAceptar.Text = "Aceptar"; this.btnAceptar.BorderRadius = 6; this.btnAceptar.Width = 120;
            // btnCancelar
            this.btnCancelar.Text = "Cancelar"; this.btnCancelar.BorderRadius = 6; this.btnCancelar.Width = 120;
            // FrmSeleccionPacientes
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 500); this.Controls.Add(this.panel); this.Text = "Seleccionar Paciente"; this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.flow.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        private Guna.UI2.WinForms.Guna2Panel panel;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private Guna.UI2.WinForms.Guna2DataGridView dgv;
        private System.Windows.Forms.FlowLayoutPanel flow;
        private Guna.UI2.WinForms.Guna2Button btnAceptar;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;
    }
}
