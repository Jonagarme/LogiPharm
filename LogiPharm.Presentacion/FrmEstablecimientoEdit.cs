using System;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmEstablecimientoEdit : Form
    {
        private readonly EEstablecimiento _model;

        public FrmEstablecimientoEdit(EEstablecimiento model)
        {
            InitializeComponent();
            _model = model;
            this.Load += FrmEstablecimientoEdit_Load;
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            btnGuardar.Click += BtnGuardar_Click;
        }

        private void FrmEstablecimientoEdit_Load(object sender, EventArgs e)
        {
            cboEstado.Items.Clear();
            cboEstado.Items.AddRange(new object[] { "Activo", "Inactivo" });

            if (_model != null)
            {
                Text = "Editar Establecimiento";
                txtCodigo.Text = _model.Codigo;
                txtNombre.Text = _model.NombreComercial;
                txtDireccion.Text = _model.Direccion;
                cboEstado.SelectedItem = string.IsNullOrWhiteSpace(_model.Estado) ? "Activo" : _model.Estado;
            }
            else
            {
                Text = "Nuevo Establecimiento";
                cboEstado.SelectedItem = "Activo";
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string codigo = (txtCodigo.Text ?? "").Trim();
            string nombre = (txtNombre.Text ?? "").Trim();
            string direccion = string.IsNullOrWhiteSpace(txtDireccion.Text) ? null : txtDireccion.Text.Trim();
            string estado = cboEstado.SelectedItem?.ToString() ?? "Activo";

            if (codigo.Length != 3)
            {
                MessageBox.Show("El código debe tener exactamente 3 dígitos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre comercial es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            try
            {
                var d = new DEstablecimientos();

                if (_model == null)
                {
                    int id = d.Insertar(codigo, nombre, direccion, estado);
                    try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Configuración", "CREAR", "establecimientos", id, $"Crear establecimiento {codigo}", null, Environment.MachineName, "UI"); } catch { }
                }
                else
                {
                    d.Actualizar(_model.Id, codigo, nombre, direccion, estado);
                    try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Configuración", "EDITAR", "establecimientos", _model.Id, $"Editar establecimiento {codigo}", null, Environment.MachineName, "UI"); } catch { }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
