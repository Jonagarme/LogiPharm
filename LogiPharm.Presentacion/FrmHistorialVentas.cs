using System;
using System.Data;
using System.Windows.Forms;
using LogiPharm.Datos;

namespace LogiPharm.Presentacion
{
    public partial class FrmHistorialVentas : Form
    {
        public FrmHistorialVentas()
        {
            InitializeComponent();
            this.Load += FrmHistorialVentas_Load;
        }

        private void FrmHistorialVentas_Load(object sender, EventArgs e)
        {
            CargarClientes();
            // Opcional: Cargar el historial inicial
            // btnConsultar_Click(sender, e); 
        }

        private void CargarClientes()
        {
            try
            {
                DClientes d_Clientes = new DClientes();
                DataTable dt = d_Clientes.ListarClientesActivos();

                // Añadir fila de 'Todos'
                DataRow dr = dt.NewRow();
                dr["id"] = 0;
                dr["nombres"] = "[TODOS LOS CLIENTES]";
                dt.Rows.InsertAt(dr, 0);

                // MUY IMPORTANTE: Limpiar primero
                cboCliente.DataSource = null;
                cboCliente.Items.Clear();

                cboCliente.DisplayMember = "nombres";
                cboCliente.ValueMember = "id";
                cboCliente.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnConsultar_Click(object sender, EventArgs e)
        {
            // Ahora, al consultar, puedes obtener el ID del cliente seleccionado
            int idClienteSeleccionado = Convert.ToInt32(cboCliente.SelectedValue);

            // TODO: Usar 'idClienteSeleccionado' en tu método de búsqueda de historial.
            // Si es 0, buscas para todos los clientes.
        }
    }
}
