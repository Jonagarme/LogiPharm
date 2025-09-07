using System;
using System.Data;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;
using LogiPharm.Negocio;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmUsuarios : Form
    {
        private int _idSeleccionado = 0; // Variable para guardar el ID del usuario seleccionado

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            CargarRoles();
            CargarUsuarios();

            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.dgvUsuarios.SelectionChanged += new System.EventHandler(this.dgvUsuarios_SelectionChanged);
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // Auditoría: VISUALIZAR
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Seguridad", "VISUALIZAR", "usuarios", null, "Abrir Gestión de Usuarios", null, Environment.MachineName, "UI"); } catch { }
        }

        private void CargarUsuarios()
        {
            try
            {
                DUsuario d_Usuarios = new DUsuario();
                dgvUsuarios.DataSource = d_Usuarios.ListarUsuarios(txtBuscar.Text.Trim());
                EstilizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Cargar Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarRoles()
        {
            try
            {
                DRoles d_Roles = new DRoles();
                cboRol.DataSource = d_Roles.ListarRolesActivos();
                cboRol.DisplayMember = "nombre";
                cboRol.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Cargar Roles", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EstilizarGrid()
        {
            if (dgvUsuarios.Columns.Count > 0)
            {
                string[] columnasOcultas = { "id", "idRol", "activo" };
                foreach (var col in columnasOcultas)
                {
                    if (dgvUsuarios.Columns.Contains(col))
                        dgvUsuarios.Columns[col].Visible = false;
                }

                dgvUsuarios.Columns["nombreCompleto"].HeaderText = "Nombre Completo";
                dgvUsuarios.Columns["nombreCompleto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvUsuarios.Columns["nombreUsuario"].HeaderText = "Usuario";
                dgvUsuarios.Columns["email"].HeaderText = "E-mail";
                dgvUsuarios.Columns["rolNombre"].HeaderText = "Rol";
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarUsuarios();
            // Auditoría: VISUALIZAR filtro
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Seguridad", "VISUALIZAR", "usuarios", null, $"Buscar usuarios '{txtBuscar.Text}'", null, Environment.MachineName, "UI"); } catch { }
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
                _idSeleccionado = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["id"].Value);
                txtNombreCompleto.Text = dgvUsuarios.CurrentRow.Cells["nombreCompleto"].Value.ToString();
                txtNombreUsuario.Text = dgvUsuarios.CurrentRow.Cells["nombreUsuario"].Value.ToString();
                txtEmail.Text = dgvUsuarios.CurrentRow.Cells["email"].Value.ToString();
                cboRol.SelectedValue = dgvUsuarios.CurrentRow.Cells["idRol"].Value;
                chkActivo.Checked = Convert.ToBoolean(dgvUsuarios.CurrentRow.Cells["activo"].Value);
                txtContrasena.Clear();

                // Auditoría: VISUALIZAR selección
                try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Seguridad", "VISUALIZAR", "usuarios", _idSeleccionado, "Ver ficha de usuario", null, Environment.MachineName, "UI"); } catch { }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            txtNombreCompleto.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreCompleto.Text) || string.IsNullOrWhiteSpace(txtNombreUsuario.Text) || cboRol.SelectedIndex == -1)
            {
                MessageBox.Show("Los campos Nombre Completo, Nombre de Usuario y Rol son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_idSeleccionado == 0 && string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("La contraseña es obligatoria para un nuevo usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                EUsuario usuario = new EUsuario
                {
                    Id = _idSeleccionado,
                    NombreCompleto = txtNombreCompleto.Text.Trim(),
                    NombreUsuario = txtNombreUsuario.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    ContrasenaHash = txtContrasena.Text,
                    IdRol = Convert.ToInt32(cboRol.SelectedValue),
                    Activo = chkActivo.Checked,
                    CreadoPor = SesionActual.IdUsuario,
                    EditadoPor = SesionActual.IdUsuario
                };

                DUsuario d_Usuarios = new DUsuario();
                bool resultado;
                bool esNuevo = usuario.Id == 0;

                if (esNuevo)
                {
                    resultado = d_Usuarios.InsertarUsuario(usuario);
                }
                else
                {
                    resultado = d_Usuarios.ActualizarUsuario(usuario);
                }

                if (resultado)
                {
                    MessageBox.Show("Usuario guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
                    LimpiarCampos();

                    // Auditoría: CREAR/EDITAR
                    try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Seguridad", esNuevo ? "CREAR" : "EDITAR", "usuarios", _idSeleccionado, $"Guardar usuario '{usuario.NombreUsuario}'", null, Environment.MachineName, "UI"); } catch { }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario de la lista para eliminar.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de que desea eliminar este usuario?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DUsuario d_Usuarios = new DUsuario();
                    int idUsuarioAnulador = SesionActual.IdUsuario;

                    if (d_Usuarios.AnularUsuario(_idSeleccionado, idUsuarioAnulador))
                    {
                        MessageBox.Show("Usuario eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarUsuarios();
                        LimpiarCampos();

                        // Auditoría: ELIMINAR
                        try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Seguridad", "ELIMINAR", "usuarios", _idSeleccionado, "Eliminar usuario", null, Environment.MachineName, "UI"); } catch { }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimpiarCampos()
        {
            _idSeleccionado = 0; // Muy importante: resetear el ID
            txtNombreCompleto.Clear();
            txtNombreUsuario.Clear();
            txtEmail.Clear();
            txtContrasena.Clear();
            cboRol.SelectedIndex = -1;
            chkActivo.Checked = true;
            dgvUsuarios.ClearSelection();
        }
    }
}
