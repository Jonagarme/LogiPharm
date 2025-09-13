using System;
using System.Data;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmPacientes : Form
    {
        private int? _id;
        public FrmPacientes()
        {
            InitializeComponent();
            this.Load += FrmPacientes_Load;
            this.btnCerrar.Click += (s,e)=> this.Close();
            this.btnNuevo.Click += BtnNuevo_Click;
            this.btnGuardar.Click += BtnGuardar_Click;
            this.btnEliminar.Click += BtnEliminar_Click;
            this.txtBuscar.TextChanged += (s,e)=> CargarListado(txtBuscar.Text);
            this.dgv.SelectionChanged += Dgv_SelectionChanged;
            this.dgv.AutoGenerateColumns = true;
        }

        private void FrmPacientes_Load(object sender, EventArgs e)
        {
            CargarListado();
        }

        private void CargarListado(string filtro=null)
        {
            try
            {
                var dt = new DPacientes().Listar(filtro);
                dgv.DataSource = dt;
                if (dt.Rows.Count>0)
                {
                    dgv.ClearSelection();
                    dgv.Rows[0].Selected = true;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar: "+ex.Message); }
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) { _id = null; return; }
            var drv = dgv.CurrentRow.DataBoundItem as DataRowView;
            if (drv==null) { _id=null; return; }
            _id = Convert.ToInt32(drv["id"]);
            txtDoc.Text = Convert.ToString(drv["documento"]);
            txtNombre.Text = Convert.ToString(drv["nombre"]);
            if (drv.Row.Table.Columns.Contains("fecha_nacimiento") && drv["fecha_nacimiento"]!=DBNull.Value)
                dtpNac.Value = Convert.ToDateTime(drv["fecha_nacimiento"]);
            txtTel.Text = Convert.ToString(drv["telefono"]);
            txtEmail.Text = Convert.ToString(drv["email"]);
            txtDir.Text = Convert.ToString(drv["direccion"]);
            if (drv.Row.Table.Columns.Contains("activo"))
                chkActivo.Checked = Convert.ToInt32(drv["activo"])!=0;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            _id=null; txtDoc.Clear(); txtNombre.Clear(); txtTel.Clear(); txtEmail.Clear(); txtDir.Clear(); chkActivo.Checked = true; txtNombre.Focus();
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) { MessageBox.Show("Nombre requerido"); return; }
            var p = new EPaciente
            {
                Id = _id ?? 0,
                Documento = txtDoc.Text?.Trim(),
                Nombre = txtNombre.Text?.Trim(),
                FechaNacimiento = dtpNac.Value,
                Telefono = txtTel.Text?.Trim(),
                Email = txtEmail.Text?.Trim(),
                Direccion = txtDir.Text?.Trim(),
                Activo = chkActivo.Checked
            };
            try
            {
                var d = new DPacientes();
                // Validación de documento duplicado
                if (d.ExisteDocumento(p.Documento, _id))
                {
                    MessageBox.Show("El documento ya existe para otro paciente.");
                    txtDoc.Focus();
                    return;
                }

                if (_id.HasValue) d.Actualizar(p); else _id = d.Insertar(p);
                MessageBox.Show("Guardado");
                CargarListado(txtBuscar.Text);
            }
            catch (Exception ex) { MessageBox.Show("Error: "+ex.Message); }
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (!_id.HasValue) { MessageBox.Show("Seleccione un registro"); return; }
            if (MessageBox.Show("¿Eliminar?", "Confirmar", MessageBoxButtons.YesNo)!=DialogResult.Yes) return;
            try{ new DPacientes().Eliminar(_id.Value); CargarListado(txtBuscar.Text);} catch (Exception ex){ MessageBox.Show("Error: "+ex.Message);}            
        }
    }
}
