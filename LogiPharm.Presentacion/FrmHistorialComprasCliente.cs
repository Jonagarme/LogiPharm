using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySqlConnector;
using LogiPharm.Datos;
using LogiPharm.Negocio;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmHistorialComprasCliente : Form
    {
        public FrmHistorialComprasCliente()
        {
            InitializeComponent();
            this.Load += FrmHistorialComprasCliente_Load;
        }

        private void FrmHistorialComprasCliente_Load(object sender, EventArgs e)
        {
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Clientes", "VISUALIZAR", "historial_compras_cliente", null, "Abrir Historial de Compras de Clientes", null, Environment.MachineName, "UI"); } catch { }

            EstilosHelper.EstilizarFormulario(this);
            EstilosHelper.EstilizarDataGridView(dgvHistorial);

            // Valores por defecto
            dtpFechaInicio.Value = DateTime.Today.AddMonths(-1);
            dtpFechaFin.Value = DateTime.Today;

            CargarHistorial();

            // Eventos
            btnConsultar.Click += BtnConsultar_Click;
            btnLimpiar.Click += BtnLimpiar_Click;
        }

        private void CargarHistorial()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DateTime inicio = dtpFechaInicio.Value;
                DateTime fin = dtpFechaFin.Value;
                string busquedaCliente = txtCliente.Text.Trim();
                string busquedaProducto = txtProducto.Text.Trim();

                // Hacemos una consulta uniendo facturas_venta y clientes en base al texto
                using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
                {
                    cn.Open();
                    string sql = @"
                        SELECT 
                            fv.fechaEmision AS Fecha,
                            fv.numeroFactura AS NumeroFactura,
                            c.razonSocial AS Cliente,
                            c.cedula_ruc AS Identificacion,
                            p.codigoPrincipal AS CodigoProducto,
                            fvd.productoNombre AS Producto,
                            fvd.cantidad AS Cantidad,
                            fvd.precioUnitario AS PrecioUnitario,
                            fvd.total AS Total
                        FROM facturas_venta fv
                        INNER JOIN clientes c ON fv.idCliente = c.id
                        INNER JOIN facturas_venta_detalle fvd ON fv.id = fvd.idFacturaVenta
                        INNER JOIN productos p ON fvd.idProducto = p.id
                        WHERE DATE(fv.fechaEmision) BETWEEN @fechaInicio AND @fechaFin
                          AND fv.anulado = 0
                          AND fv.idEmpresa = @idEmpresa
                          AND (@cliente = '' OR c.razonSocial LIKE @clienteLike OR c.cedula_ruc LIKE @clienteLike)
                          AND (@producto = '' OR p.nombre LIKE @productoLike OR p.codigoPrincipal LIKE @productoLike)
                        ORDER BY fv.fechaEmision DESC, fv.id DESC, p.nombre ASC;";

                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@fechaInicio", inicio.Date);
                        cmd.Parameters.AddWithValue("@fechaFin", fin.Date);
                        cmd.Parameters.AddWithValue("@idEmpresa", CapaDatos.Conexion.IdEmpresa);
                        cmd.Parameters.AddWithValue("@cliente", busquedaCliente);
                        cmd.Parameters.AddWithValue("@clienteLike", $"%{busquedaCliente}%");
                        cmd.Parameters.AddWithValue("@producto", busquedaProducto);
                        cmd.Parameters.AddWithValue("@productoLike", $"%{busquedaProducto}%");

                        DataTable dt = new DataTable();
                        using (var da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        dgvHistorial.DataSource = dt;

                        // Calcular totales
                        var totales = NHistorialComprasCliente.CalcularTotales(dt);
                        lblTotalUnidades.Text = $"Cant. Unidades: {totales.TotalUnidades:N0}";
                        lblTotalMonto.Text = $"Total Facturado: ${totales.TotalVendido:N2}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            txtCliente.Clear();
            txtProducto.Clear();
            dtpFechaInicio.Value = DateTime.Today.AddMonths(-1);
            dtpFechaFin.Value = DateTime.Today;
            CargarHistorial();
        }
    }
}
