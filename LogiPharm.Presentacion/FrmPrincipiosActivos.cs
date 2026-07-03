using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;
using LogiPharm.Negocio;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmPrincipiosActivos : Form
    {
        private bool esNuevo = false;
        private int idSeleccionado = 0;

        public FrmPrincipiosActivos()
        {
            InitializeComponent();
            this.Load += FrmPrincipiosActivos_Load;
        }

        private void FrmPrincipiosActivos_Load(object sender, EventArgs e)
        {
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Inventario", "VISUALIZAR", "principios_activos", null, "Abrir Principios Activos", null, Environment.MachineName, "UI"); } catch { }

            EstilosHelper.EstilizarFormulario(this);
            EstilosHelper.EstilizarDataGridView(dgvDatos);

            CargarDatos();
            HabilitarEdicion(false);

            // Eventos
            btnBuscar.Click += BtnBuscar_Click;
            txtBusqueda.KeyPress += TxtBusqueda_KeyPress;
            btnNuevo.Click += BtnNuevo_Click;
            btnEditar.Click += BtnEditar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += BtnCancelar_Click;
            dgvDatos.SelectionChanged += DgvDatos_SelectionChanged;
        }

        private void CargarDatos()
        {
            try
            {
                string criterio = txtBusqueda.Text.Trim();
                DataTable dt;
                if (string.IsNullOrEmpty(criterio))
                    dt = NPrincipioActivo.Listar();
                else
                    dt = NPrincipioActivo.Buscar(criterio);

                dgvDatos.DataSource = dt;
                lblTotal.Text = $"Registros: {dt.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HabilitarEdicion(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtDescripcion.Enabled = habilitar;
            chkActivo.Enabled = habilitar;

            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;

            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = !habilitar;
            btnEliminar.Enabled = !habilitar;
            txtBusqueda.Enabled = !habilitar;
            btnBuscar.Enabled = !habilitar;
            dgvDatos.Enabled = !habilitar;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            chkActivo.Checked = true;
        }

        private void DgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                var row = dgvDatos.CurrentRow;
                idSeleccionado = Convert.ToInt32(row.Cells["colId"].Value);
                txtNombre.Text = row.Cells["colNombre"].Value.ToString();
                txtDescripcion.Text = row.Cells["colDescripcion"].Value?.ToString();
                chkActivo.Checked = Convert.ToBoolean(row.Cells["colActivo"].Value);
            }
            else
            {
                idSeleccionado = 0;
                LimpiarCampos();
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void TxtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                CargarDatos();
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            LimpiarCampos();
            HabilitarEdicion(true);
            txtNombre.Focus();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione un registro para editar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            esNuevo = false;
            HabilitarEdicion(true);
            txtNombre.Focus();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione un registro para eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dialog = MessageBox.Show("¿Está seguro que desea eliminar este principio activo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    if (NPrincipioActivo.Eliminar(idSeleccionado))
                    {
                        MessageBox.Show("Registro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Inventario", "ELIMINAR", "principios_activos", idSeleccionado, $"Eliminar principio activo {txtNombre.Text}", null, Environment.MachineName, "UI"); } catch { }
                        CargarDatos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            var principio = new EPrincipioActivo
            {
                Id = idSeleccionado,
                Nombre = nombre,
                Descripcion = descripcion,
                Activo = chkActivo.Checked
            };

            try
            {
                bool exito;
                if (esNuevo)
                {
                    exito = NPrincipioActivo.Insertar(principio);
                    if (exito)
                    {
                        MessageBox.Show("Principio activo guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Inventario", "INSERTAR", "principios_activos", null, $"Insertar principio activo {nombre}", null, Environment.MachineName, "UI"); } catch { }
                    }
                }
                else
                {
                    exito = NPrincipioActivo.Actualizar(principio);
                    if (exito)
                    {
                        MessageBox.Show("Principio activo actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Inventario", "ACTUALIZAR", "principios_activos", principio.Id, $"Actualizar principio activo {nombre}", null, Environment.MachineName, "UI"); } catch { }
                    }
                }

                if (exito)
                {
                    HabilitarEdicion(false);
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarEdicion(false);
            DgvDatos_SelectionChanged(null, EventArgs.Empty);
        }
    }
}
