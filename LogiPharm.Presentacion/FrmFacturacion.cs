using System;
using System.Data;
using System.Windows.Forms;
using LogiPharm.Datos;

namespace LogiPharm.Presentacion
{
    public partial class FrmFacturacion : Form
    {
        public FrmFacturacion()
        {
            InitializeComponent();
        }

        private void FrmFacturacion_Load(object sender, EventArgs e)
        {
            // Cargar datos iniciales al abrir el formulario
            btnBuscar_Click(sender, e);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DFacturacion d_Facturacion = new DFacturacion();
                dgvListaFacturas.DataSource = d_Facturacion.ListarFacturas(dtpFechaInicio.Value, dtpFechaFin.Value);
                lblTotalDocumentos.Text = $"Total de Documentos: {dgvListaFacturas.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Cargar Facturas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvListaFacturas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvListaFacturas.CurrentRow != null)
            {
                try
                {
                    // Obtener el ID del documento seleccionado (asumiendo que está en la primera columna)
                    int idDoc = Convert.ToInt32(dgvListaFacturas.CurrentRow.Cells[0].Value);

                    DFacturacion d_Facturacion = new DFacturacion();
                    DataSet dsDetalle = d_Facturacion.ObtenerDetalleFactura(idDoc);

                    // Llenar los datos del encabezado de la factura
                    if (dsDetalle.Tables["FacturaInfo"].Rows.Count > 0)
                    {
                        DataRow info = dsDetalle.Tables["FacturaInfo"].Rows[0];
                        lblNumeroFactura.Text = info["NumeroFactura"].ToString();
                        lblNoInterno.Text = info["NoInterno"].ToString();
                        lblFechaAutorizacion.Text = info["FechaAutorizacion"].ToString();
                        lblEstadoSRI.Text = info["SriEstado"].ToString();
                        lblCedula.Text = info["Cedula"].ToString();
                        lblCliente.Text = info["Cliente"].ToString();
                        lblTelefono.Text = info["Telefono"].ToString();
                        lblDireccion.Text = info["Direccion"].ToString();
                        lblFecha.Text = info["Fecha"].ToString();
                        lblAmbiente.Text = info["Ambiente"].ToString();
                        lblTipoDoc.Text = info["TipoDocumento"].ToString();
                        //lblCajero.Text = info["Cajero"].ToString();
                        lblCaja.Text = info["Caja"].ToString();
                        lblAutorizacion.Text = info["Autorizacion"].ToString();
                    }

                    // Llenar la grilla de detalle de productos
                    dgvDetalleFactura.DataSource = dsDetalle.Tables["FacturaDetalle"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al Cargar Detalle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
