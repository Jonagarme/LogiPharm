using System;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmFichaCliente : Form
    {
        // Propiedad pública para que el formulario de ventas pueda recuperar el cliente guardado
        public ECliente ClienteGuardado { get; private set; }

        // Constructor que recibe la identificación desde el POS
        public FrmFichaCliente(string identificacionInicial = "")
        {
            InitializeComponent();
            txtIdentificacion.Text = identificacionInicial;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // --- 1. Validaciones básicas ---
            if (string.IsNullOrWhiteSpace(txtIdentificacion.Text))
            {
                MessageBox.Show("El campo 'R.U.C / C.I' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdentificacion.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                MessageBox.Show("El campo 'Nombres' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombres.Focus();
                return;
            }
            if (cboTipoPersona.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un 'Tipo de Persona'.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipoPersona.Focus();
                return;
            }

            // --- 2. Crear el objeto Cliente con los datos del formulario ---
            var cliente = new ECliente
            {
                Identificacion = txtIdentificacion.Text.Trim(),
                CedulaRuc = txtIdentificacion.Text.Trim(),
                Nombres = txtNombres.Text.Trim(),
                Apellidos = txtApellidos.Text.Trim(),
                RazonSocial = $"{txtNombres.Text.Trim()} {txtApellidos.Text.Trim()}".Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Telefono = txtCelular.Text.Trim(),
                Celular = txtCelular.Text.Trim(),
                Email = txtCorreo.Text.Trim(),
                TipoCliente = cboTipoPersona.ValueMember,
                TipoIdentificacion = ObtenerTipoIdSeleccionado(),
                CreadoPor = 1 // TODO: Reemplazar con el ID del usuario que ha iniciado sesión
            };

            // --- 3. Guardar en la Base de Datos ---
            try
            {
                DClientes d_Clientes = new DClientes();
                if (d_Clientes.InsertarCliente(cliente))
                {
                    MessageBox.Show("Cliente guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ClienteGuardado = cliente; // Asignamos el cliente guardado a la propiedad pública
                    this.DialogResult = DialogResult.OK; // Indicamos que la operación fue exitosa
                    this.Close(); // Cerramos el formulario
                }
                else
                {
                    MessageBox.Show("Ocurrió un error y no se pudo guardar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtenerTipoIdSeleccionado()
        {
            string seleccion = cboTipoPersona.SelectedItem.ToString();
            if (seleccion.Contains("RUC")) return "RUC";
            if (seleccion.Contains("CÉDULA")) return "CÉDULA"; // Asumiendo que tu ENUM usa CÉDULA
            return "PASAPORTE"; // O un valor por defecto
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            // Establece el resultado como Cancelar y cierra el formulario
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
