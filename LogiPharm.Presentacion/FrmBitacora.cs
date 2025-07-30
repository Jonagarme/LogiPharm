using LogiPharm.Datos;
using System;
using System.Windows.Forms;

namespace LogiPharm.Presentacion
{
    public partial class FrmBitacora : Form
    {
        public FrmBitacora()
        {
            InitializeComponent();
        }

        private void FrmBitacora_Load(object sender, EventArgs e)
        {
            // Configurar fechas por defecto (ej. todo el día de hoy)
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            // Cargar los ComboBox de los filtros
            CargarFiltros();

            // Cargar la bitácora con los filtros por defecto
            btnConsultar_Click(sender, e);
        }

        private void CargarFiltros()
        {
            try
            {
                // Cargar usuarios
                DBitacora d_Bitacora = new DBitacora();
                cboUsuarios.DataSource = d_Bitacora.ListarUsuariosParaFiltro();
                cboUsuarios.DisplayMember = "nombreUsuario";
                cboUsuarios.ValueMember = "id";

                // Cargar acciones
                cboAccion.SelectedIndex = 0; // Seleccionar "TODAS"
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar filtros", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                DBitacora d_Bitacora = new DBitacora();

                // Obtener valores de los filtros
                DateTime fechaInicio = dtpFechaInicio.Value;
                DateTime fechaFin = dtpFechaFin.Value;
                string usuario = cboUsuarios.Text;
                string accion = cboAccion.Text;

                // Llamar a la capa de datos para obtener los registros
                dgvBitacora.DataSource = d_Bitacora.ConsultarBitacora(fechaInicio, fechaFin, usuario, accion);

                EstilizarGrid();
                lblTotalRegistros.Text = $"Total de Registros: {dgvBitacora.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al consultar la bitácora", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EstilizarGrid()
        {
            if (dgvBitacora.Columns.Count > 0)
            {
                dgvBitacora.Columns["Fecha"].Width = 150;
                dgvBitacora.Columns["Usuario"].Width = 120;
                dgvBitacora.Columns["Modulo"].Width = 150;
                dgvBitacora.Columns["Accion"].Width = 150;
                dgvBitacora.Columns["Detalle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}
