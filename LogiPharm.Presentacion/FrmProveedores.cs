using System;
using System.Data;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmProveedores : Form
    {
        private int _idSeleccionado = 0; // Variable para guardar el ID del proveedor seleccionado

        public FrmProveedores()
        {
            InitializeComponent();
        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            CargarProveedores();
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.dgvProveedores.SelectionChanged += new System.EventHandler(this.dgvProveedores_SelectionChanged);
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // Auditoría: VISUALIZAR
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Compras", "VISUALIZAR", "proveedores", null, "Abrir Gestión de Proveedores", null, Environment.MachineName, "UI"); } catch { }
        }

        private void CargarProveedores()
        {
            try
            {
                DProveedores d_Proveedores = new DProveedores();
                dgvProveedores.DataSource = d_Proveedores.ListarProveedores(txtBuscar.Text.Trim());
                EstilizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Cargar Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EstilizarGrid()
        {
            if (dgvProveedores.Columns.Count > 0)
            {
                string[] columnasOcultas = { "id", "direccion", "telefono", "email" };
                foreach (var col in columnasOcultas)
                {
                    if (dgvProveedores.Columns.Contains(col))
                        dgvProveedores.Columns[col].Visible = false;
                }

                dgvProveedores.Columns["ruc"].HeaderText = "RUC";
                dgvProveedores.Columns["ruc"].Width = 120;
                dgvProveedores.Columns["razonSocial"].HeaderText = "Razón Social";
                dgvProveedores.Columns["razonSocial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvProveedores.Columns["nombreComercial"].HeaderText = "Nombre Comercial";
                dgvProveedores.Columns["nombreComercial"].Width = 200;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarProveedores();
            // Auditoría: VISUALIZAR filtro
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Compras", "VISUALIZAR", "proveedores", null, $"Buscar proveedores '{txtBuscar.Text}'", null, Environment.MachineName, "UI"); } catch { }
        }

        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow != null)
            {
                _idSeleccionado = Convert.ToInt32(dgvProveedores.CurrentRow.Cells["id"].Value);
                txtRUC.Text = dgvProveedores.CurrentRow.Cells["ruc"].Value.ToString();
                txtRazonSocial.Text = dgvProveedores.CurrentRow.Cells["razonSocial"].Value.ToString();
                txtNombreComercial.Text = dgvProveedores.CurrentRow.Cells["nombreComercial"].Value.ToString();
                txtDireccion.Text = dgvProveedores.CurrentRow.Cells["direccion"].Value.ToString();
                txtTelefono.Text = dgvProveedores.CurrentRow.Cells["telefono"].Value.ToString();
                txtEmail.Text = dgvProveedores.CurrentRow.Cells["email"].Value.ToString();

                // Auditoría: VISUALIZAR selección
                try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Compras", "VISUALIZAR", "proveedores", _idSeleccionado, "Ver ficha de proveedor", null, Environment.MachineName, "UI"); } catch { }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            txtRUC.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRUC.Text) || string.IsNullOrWhiteSpace(txtRazonSocial.Text))
            {
                MessageBox.Show("El RUC y la Razón Social son campos obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                EProveedor proveedor = new EProveedor
                {
                    Id = _idSeleccionado,
                    Ruc = txtRUC.Text.Trim(),
                    RazonSocial = txtRazonSocial.Text.Trim(),
                    NombreComercial = txtNombreComercial.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    CreadoPor = SesionActual.IdUsuario
                };

                DProveedores d_Proveedores = new DProveedores();
                bool resultado;

                bool esNuevo = proveedor.Id == 0;
                if (esNuevo)
                {
                    resultado = d_Proveedores.InsertarProveedor(proveedor);
                }
                else
                {
                    resultado = d_Proveedores.ActualizarProveedor(proveedor);
                }

                if (resultado)
                {
                    MessageBox.Show("Proveedor guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarProveedores();
                    LimpiarCampos();

                    // Auditoría: CREAR/EDITAR
                    try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Compras", esNuevo ? "CREAR" : "EDITAR", "proveedores", _idSeleccionado, $"Guardar proveedor '{proveedor.RazonSocial}'", null, Environment.MachineName, "UI"); } catch { }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            _idSeleccionado = 0; // Muy importante: resetear el ID
            txtRUC.Clear();
            txtRazonSocial.Clear();
            txtNombreComercial.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            dgvProveedores.ClearSelection();
        }
    }
}
