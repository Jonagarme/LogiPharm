using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmNuevaOrdenCompra : Form
    {
        private long _idOrden = 0;
        private bool _modoConsulta = false;
        private EOrdenCompra _ordenActual = null;
        private DataTable _tablaDetalle;
        private decimal _tasaIVA = 0.15m; // 15%

        public FrmNuevaOrdenCompra(long idOrden = 0, bool modoConsulta = false)
        {
            InitializeComponent();
            _idOrden = idOrden;
            _modoConsulta = modoConsulta;

            _tablaDetalle = new DataTable();
            _tablaDetalle.Columns.Add("IdProducto", typeof(int));
            _tablaDetalle.Columns.Add("Codigo", typeof(string));
            _tablaDetalle.Columns.Add("Producto", typeof(string));
            _tablaDetalle.Columns.Add("Cantidad", typeof(decimal));
            _tablaDetalle.Columns.Add("PrecioUnitario", typeof(decimal));
            _tablaDetalle.Columns.Add("DescuentoPorc", typeof(decimal));
            _tablaDetalle.Columns.Add("Subtotal", typeof(decimal));
            _tablaDetalle.Columns.Add("IVA", typeof(decimal));
            _tablaDetalle.Columns.Add("Total", typeof(decimal));

            dgvDetalle.DataSource = _tablaDetalle;
            dgvDetalle.AutoGenerateColumns = false; // Evitar columnas duplicadas
            ConfigurarColumnas();

            // Obtener el IVA de la base de datos si existe
            try
            {
                _tasaIVA = ImpuestoProvider.GetIVA();
            }
            catch
            {
                _tasaIVA = 0.15m; // valor por defecto
            }
        }

        private async void FrmNuevaOrdenCompra_Load(object sender, EventArgs e)
        {
            await CargarProveedoresAsync();

            if (_idOrden > 0)
            {
                lblTitulo.Text = _modoConsulta ? "Consultar Orden de Compra" : "Editar Orden de Compra";
                this.Text = lblTitulo.Text;
                await CargarOrdenAsync();

                if (_modoConsulta)
                {
                    HabilitarModoConsulta();
                }
            }
            else
            {
                dtpFechaEmision.Value = DateTime.Now;
                dtpFechaEntrega.Value = DateTime.Now.AddDays(7);
            }
        }

        private void HabilitarModoConsulta()
        {
            txtNumero.ReadOnly = true;
            cboProveedor.Enabled = false;
            btnBuscarProveedor.Enabled = false;
            dtpFechaEmision.Enabled = false;
            dtpFechaEntrega.Enabled = false;
            txtObservaciones.ReadOnly = true;
            btnAgregarProducto.Enabled = false;
            dgvDetalle.ReadOnly = true;
            dgvDetalle.Columns["colEliminar"].Visible = false;
            btnGuardar.Visible = false;
            btnCancelar.Text = "Cerrar";
        }

        private async System.Threading.Tasks.Task CargarProveedoresAsync()
        {
            try
            {
                var d = new DProveedores();
                var dt = d.ListarProveedoresActivos();

                cboProveedor.DataSource = dt;
                cboProveedor.DisplayMember = "razonSocial";
                cboProveedor.ValueMember = "id";
                cboProveedor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async System.Threading.Tasks.Task CargarOrdenAsync()
        {
            try
            {
                var d = new DOrdenesCompra();
                _ordenActual = d.ObtenerOrdenCompleta(_idOrden);

                if (_ordenActual == null)
                {
                    MessageBox.Show("No se encontró la orden de compra.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                txtNumero.Text = _ordenActual.Numero.ToString();
                cboProveedor.SelectedValue = _ordenActual.IdProveedor;
                dtpFechaEmision.Value = _ordenActual.FechaEmision;
                if (_ordenActual.FechaEntregaEsperada.HasValue)
                    dtpFechaEntrega.Value = _ordenActual.FechaEntregaEsperada.Value;
                txtObservaciones.Text = _ordenActual.Observaciones;

                _tablaDetalle.Clear();
                foreach (var detalle in _ordenActual.Detalles)
                {
                    _tablaDetalle.Rows.Add(
                        detalle.IdProducto,
                        detalle.Codigo,
                        detalle.ProductoNombre,
                        detalle.CantidadSolicitada,
                        detalle.PrecioUnitario,
                        detalle.DescuentoPorc,
                        detalle.Subtotal,
                        detalle.IVAValor,
                        detalle.Total
                    );
                }

                CalcularTotales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la orden: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnas()
        {
            dgvDetalle.Columns["colCodigo"].DataPropertyName = "Codigo";
            dgvDetalle.Columns["colProducto"].DataPropertyName = "Producto";
            dgvDetalle.Columns["colCantidad"].DataPropertyName = "Cantidad";
            dgvDetalle.Columns["colPrecioUnitario"].DataPropertyName = "PrecioUnitario";
            dgvDetalle.Columns["colDescuentoPorc"].DataPropertyName = "DescuentoPorc";
            dgvDetalle.Columns["colSubtotal"].DataPropertyName = "Subtotal";
            dgvDetalle.Columns["colIVA"].DataPropertyName = "IVA";
            dgvDetalle.Columns["colTotal"].DataPropertyName = "Total";

            dgvDetalle.Columns["colPrecioUnitario"].DefaultCellStyle.Format = "N2";
            dgvDetalle.Columns["colDescuentoPorc"].DefaultCellStyle.Format = "N2";
            dgvDetalle.Columns["colSubtotal"].DefaultCellStyle.Format = "N2";
            dgvDetalle.Columns["colIVA"].DefaultCellStyle.Format = "N2";
            dgvDetalle.Columns["colTotal"].DefaultCellStyle.Format = "N2";

            dgvDetalle.Columns["colCantidad"].ReadOnly = false;
            dgvDetalle.Columns["colPrecioUnitario"].ReadOnly = false;
            dgvDetalle.Columns["colDescuentoPorc"].ReadOnly = false;
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmProveedores())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarProveedoresAsync();
                }
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmSeleccionarProducto())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var producto = frm.ProductoSeleccionado;
                    if (producto != null)
                    {
                        // Verificar si el producto ya existe en el detalle
                        bool existe = false;
                        foreach (DataRow row in _tablaDetalle.Rows)
                        {
                            if (Convert.ToInt32(row["IdProducto"]) == producto.Id)
                            {
                                MessageBox.Show("El producto ya está en el detalle.", "Información",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                existe = true;
                                break;
                            }
                        }

                        if (!existe)
                        {
                            decimal precioUnitario = producto.PrecioVenta; // o costoUnitario si existe
                            decimal cantidad = 1;
                            decimal descuentoPorc = 0;
                            decimal subtotal = cantidad * precioUnitario;
                            decimal descuentoValor = subtotal * (descuentoPorc / 100);
                            subtotal -= descuentoValor;
                            decimal iva = subtotal * _tasaIVA;
                            decimal total = subtotal + iva;

                            _tablaDetalle.Rows.Add(
                                producto.Id,
                                producto.CodigoPrincipal,
                                producto.Nombre,
                                cantidad,
                                precioUnitario,
                                descuentoPorc,
                                subtotal,
                                iva,
                                total
                            );

                            CalcularTotales();
                        }
                    }
                }
            }
        }

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvDetalle.Rows[e.RowIndex];
            string colName = dgvDetalle.Columns[e.ColumnIndex].Name;

            if (colName == "colCantidad" || colName == "colPrecioUnitario" || colName == "colDescuentoPorc")
            {
                try
                {
                    decimal cantidad = Convert.ToDecimal(row.Cells["colCantidad"].Value);
                    decimal precioUnitario = Convert.ToDecimal(row.Cells["colPrecioUnitario"].Value);
                    decimal descuentoPorc = Convert.ToDecimal(row.Cells["colDescuentoPorc"].Value);

                    decimal subtotal = cantidad * precioUnitario;
                    decimal descuentoValor = subtotal * (descuentoPorc / 100);
                    subtotal -= descuentoValor;
                    decimal iva = subtotal * _tasaIVA;
                    decimal total = subtotal + iva;

                    row.Cells["colSubtotal"].Value = subtotal;
                    row.Cells["colIVA"].Value = iva;
                    row.Cells["colTotal"].Value = total;

                    CalcularTotales();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al calcular: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvDetalle_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvDetalle.Columns[e.ColumnIndex].Name == "colEliminar")
            {
                e.Value = Properties.Resources.ic_delete;
                e.FormattingApplied = true;
            }
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvDetalle.Columns[e.ColumnIndex].Name == "colEliminar")
            {
                var result = MessageBox.Show("¿Está seguro de eliminar este producto del detalle?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    dgvDetalle.Rows.RemoveAt(e.RowIndex);
                    CalcularTotales();
                }
            }
        }

        private void CalcularTotales()
        {
            decimal subtotal = 0;
            decimal descuento = 0;
            decimal iva = 0;
            decimal total = 0;

            foreach (DataRow row in _tablaDetalle.Rows)
            {
                decimal cantidad = Convert.ToDecimal(row["Cantidad"]);
                decimal precioUnit = Convert.ToDecimal(row["PrecioUnitario"]);
                decimal descPorc = Convert.ToDecimal(row["DescuentoPorc"]);

                decimal subtotalLinea = cantidad * precioUnit;
                decimal descuentoLinea = subtotalLinea * (descPorc / 100);
                subtotalLinea -= descuentoLinea;

                subtotal += subtotalLinea;
                descuento += descuentoLinea;
                iva += Convert.ToDecimal(row["IVA"]);
                total += Convert.ToDecimal(row["Total"]);
            }

            lblSubtotal.Text = subtotal.ToString("C2");
            lblDescuento.Text = descuento.ToString("C2");
            lblIVA.Text = iva.ToString("C2");
            lblTotal.Text = total.ToString("C2");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            try
            {
                var orden = new EOrdenCompra
                {
                    Id = _idOrden,
                    IdProveedor = Convert.ToInt32(cboProveedor.SelectedValue),
                    FechaEmision = dtpFechaEmision.Value,
                    FechaEntregaEsperada = dtpFechaEntrega.Value,
                    Observaciones = txtObservaciones.Text.Trim(),
                    Subtotal = decimal.Parse(lblSubtotal.Text.Replace("$", "").Replace(",", "")),
                    Descuento = decimal.Parse(lblDescuento.Text.Replace("$", "").Replace(",", "")),
                    IVA = decimal.Parse(lblIVA.Text.Replace("$", "").Replace(",", "")),
                    Total = decimal.Parse(lblTotal.Text.Replace("$", "").Replace(",", "")),
                    CreadoPor = SesionActual.IdUsuario
                };

                foreach (DataRow row in _tablaDetalle.Rows)
                {
                    orden.Detalles.Add(new EOrdenCompraDetalle
                    {
                        IdProducto = Convert.ToInt32(row["IdProducto"]),
                        CantidadSolicitada = Convert.ToDecimal(row["Cantidad"]),
                        CantidadRecibida = 0,
                        PrecioUnitario = Convert.ToDecimal(row["PrecioUnitario"]),
                        DescuentoPorc = Convert.ToDecimal(row["DescuentoPorc"]),
                        DescuentoValor = Convert.ToDecimal(row["Cantidad"]) * Convert.ToDecimal(row["PrecioUnitario"]) * 
                                         (Convert.ToDecimal(row["DescuentoPorc"]) / 100),
                        IVAValor = Convert.ToDecimal(row["IVA"]),
                        Subtotal = Convert.ToDecimal(row["Subtotal"]),
                        Total = Convert.ToDecimal(row["Total"])
                    });
                }

                var d = new DOrdenesCompra();
                bool resultado = false;

                if (_idOrden == 0)
                {
                    long idGenerado = d.GuardarOrdenCompra(orden);
                    resultado = idGenerado > 0;
                }
                else
                {
                    resultado = d.ActualizarOrdenCompra(orden);
                }

                if (resultado)
                {
                    MessageBox.Show("Orden de compra guardada exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la orden de compra.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarFormulario()
        {
            if (cboProveedor.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un proveedor.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboProveedor.Focus();
                return false;
            }

            if (_tablaDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto al detalle.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
