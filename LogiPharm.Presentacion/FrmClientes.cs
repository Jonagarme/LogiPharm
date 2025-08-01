using System;
using System.Data;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmClientes : Form
    {
        private int _idClienteSeleccionado = 0; // Variable para guardar el ID del cliente seleccionado

        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
            // Asignar eventos a los controles
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.dgvClientes.SelectionChanged += new System.EventHandler(this.dgvClientes_SelectionChanged);
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
        }

        private void CargarClientes()
        {
            try
            {
                DClientes d_Clientes = new DClientes();
                dgvClientes.DataSource = d_Clientes.ListarClientes(txtBuscar.Text.Trim());
                EstilizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Cargar Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EstilizarGrid()
        {
            if (dgvClientes.Columns.Count > 0)
            {
                string[] columnasOcultas = { "id", "direccion", "telefono", "email", "tipoIdentificacion" };
                foreach (var col in columnasOcultas)
                {
                    if (dgvClientes.Columns.Contains(col))
                        dgvClientes.Columns[col].Visible = false;
                }

                dgvClientes.Columns["identificacion"].HeaderText = "Identificación";
                dgvClientes.Columns["identificacion"].Width = 120;
                dgvClientes.Columns["razonSocial"].HeaderText = "Nombre / Razón Social";
                dgvClientes.Columns["razonSocial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Filtra la lista cada vez que el usuario escribe
            CargarClientes();
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            // Cuando se selecciona una fila, muestra los detalles en los campos de la derecha
            if (dgvClientes.CurrentRow != null)
            {
                _idClienteSeleccionado = Convert.ToInt32(dgvClientes.CurrentRow.Cells["id"].Value);
                cboTipoIdentificacion.SelectedItem = dgvClientes.CurrentRow.Cells["tipoIdentificacion"].Value.ToString();
                txtIdentificacion.Text = dgvClientes.CurrentRow.Cells["identificacion"].Value.ToString();
                txtRazonSocial.Text = dgvClientes.CurrentRow.Cells["razonSocial"].Value.ToString();
                txtDireccion.Text = dgvClientes.CurrentRow.Cells["direccion"].Value.ToString();
                txtTelefono.Text = dgvClientes.CurrentRow.Cells["telefono"].Value.ToString();
                txtEmail.Text = dgvClientes.CurrentRow.Cells["email"].Value.ToString();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Limpia todos los campos para permitir el ingreso de un nuevo cliente
            LimpiarCampos();
            cboTipoIdentificacion.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdentificacion.Text) || string.IsNullOrWhiteSpace(txtRazonSocial.Text) || cboTipoIdentificacion.SelectedIndex == -1)
            {
                MessageBox.Show("El Tipo, la Identificación y la Razón Social son campos obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ECliente cliente = new ECliente
                {
                    Id = _idClienteSeleccionado,
                    TipoIdentificacion = cboTipoIdentificacion.SelectedItem.ToString(),
                    Identificacion = txtIdentificacion.Text.Trim(),
                    RazonSocial = txtRazonSocial.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    CreadoPor = 1, // TODO: Reemplazar con el ID del usuario de la sesión actual
                    EditadoPor = 1 // TODO: Reemplazar con el ID del usuario de la sesión actual
                };

                DClientes d_Clientes = new DClientes();
                bool resultado;

                if (cliente.Id == 0) // Si el ID es 0, es un cliente nuevo
                {
                    resultado = d_Clientes.InsertarCliente(cliente);
                }
                else // Si el ID es diferente de 0, es una actualización
                {
                    resultado = d_Clientes.ActualizarCliente(cliente);
                }

                if (resultado)
                {
                    MessageBox.Show("Cliente guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarClientes();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            _idClienteSeleccionado = 0; // Muy importante: resetear el ID
            cboTipoIdentificacion.SelectedIndex = -1;
            txtIdentificacion.Clear();
            txtRazonSocial.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            dgvClientes.ClearSelection();
        }
    }
}
