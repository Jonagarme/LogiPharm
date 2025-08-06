using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmPuntoDeVenta : Form
    {
        private ECliente _clienteSeleccionado;

        public FrmPuntoDeVenta()
        {
            InitializeComponent();
            this.dgvDetalleVenta.CellEndEdit += dgvDetalleVenta_CellEndEdit;
            this.dgvDetalleVenta.CellContentClick += dgvDetalleVenta_CellContentClick;
            this.txtIdentificacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdentificacion_KeyDown);
            this.txtIdentificacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdentificacion_KeyPress);

        }

        private void FrmPuntoDeVenta_Load(object sender, EventArgs e)
        {
            timer1.Start();

            lblVendedor.Text = SesionActual.NombreUsuario;
            lblCaja.Text = "CAJA 001";
            lblFechaEmision.Text = DateTime.Now.ToString("dd/MM/yyyy");

            if (dgvDetalleVenta.Rows.Count == 0)
                dgvDetalleVenta.Rows.Add();
            dgvDetalleVenta.Columns["colPrecio"].ReadOnly = true;
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            AbrirVentanaPago();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F4)
            {
                AbrirVentanaPago();
                return true;
            }
            else if (keyData == Keys.F8)
            {
                AbrirVentanaKardex();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void btnKardex_Click(object sender, EventArgs e)
        {
            AbrirVentanaKardex();
        }


        private void AbrirVentanaKardex()
        {
            using (FrmKardex frm = new FrmKardex())
            {
                frm.ShowDialog();
            }
        }


        private void AbrirVentanaPago()
        {
            // 1. Validar que haya productos en la venta
            if (dgvDetalleVenta.Rows.Count <= 1 && dgvDetalleVenta.Rows[0].IsNewRow)
            {
                MessageBox.Show("No hay productos en la venta para procesar el pago.", "Venta Vacía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_clienteSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un cliente válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Recolectar datos del cliente
            //ECliente cliente = new ECliente
            //{
            //    Identificacion = txtIdentificacion.Text,
            //    RazonSocial = txtCliente.Text,
            //    Email = txtEmail.Text,
            //    Direccion = cliente.Direccion
            //};

            // 3. Recolectar los detalles de los productos
            var productos = new List<ProductoVenta>();
            foreach (DataGridViewRow row in dgvDetalleVenta.Rows)
            {
                if (row.IsNewRow || row.Cells["colCodigo"].Value == null) continue;
                productos.Add(new ProductoVenta
                {
                    CodigoPrincipal = row.Cells["colCodigo"].Value.ToString(),
                    Descripcion = row.Cells["colProducto"].Value.ToString(),
                    Cantidad = Convert.ToDecimal(row.Cells["colCantidad"].Value ?? 0),
                    PrecioUnitario = Convert.ToDecimal(row.Cells["colPrecio"].Value ?? 0),
                    Descuento = Convert.ToDecimal(row.Cells["colDscto"].Value ?? 0),
                    PrecioTotalSinImpuesto = Convert.ToDecimal(row.Cells["colSubtotal"].Value ?? 0)
                });
            }

            // 4. Calcular el total de la venta
            decimal totalVenta = CalcularTotalVenta();

            // 5. Abrir la ventana de pago UNA SOLA VEZ
            using (FrmPago frmPago = new FrmPago(totalVenta, _clienteSeleccionado, productos))
            {
                if (frmPago.ShowDialog() == DialogResult.OK)
                {
                    // Si el pago fue exitoso, continuar con la impresión
                    MessageBox.Show("Venta procesada con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (MessageBox.Show("¿Desea imprimir la factura?", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ImprimirFactura(_clienteSeleccionado, productos, totalVenta);
                    }

                    // TODO: Aquí iría tu lógica para guardar la venta en la base de datos
                    // y luego limpiar el POS para una nueva venta.
                    // LimpiarFormularioVenta();
                }
            }
        }

        private void ImprimirFactura(ECliente cliente, List<ProductoVenta> productos, decimal efectivoRecibido)
        {
            try
            {
                dsFactura ds = new dsFactura();
                DataTable dtInfo = ds.Tables["dtFacturaInfo"];
                DataTable dtDetalle = ds.Tables["dtFacturaDetalle"];

                decimal subtotal = 0m;
                decimal descuento = 0m;
                decimal iva = 0m;
                decimal cambio = 0m;

                foreach (var prod in productos)
                {
                    subtotal += prod.PrecioTotalSinImpuesto;
                    descuento += prod.Descuento;
                    iva += prod.PrecioTotalSinImpuesto; // Si tienes IVA por producto
                    dtDetalle.Rows.Add(prod.Cantidad, prod.Descripcion, prod.PrecioUnitario, prod.PrecioTotalSinImpuesto);
                }
                decimal total = subtotal + iva;

                dtInfo.Rows.Add(
                    "FARMACIAS LOGIPHARM",
                    "0991234567001",
                    "GUAYAQUIL / FEBRES CORDERO / ORIENTE S/N Y 38 AVA",
                    "0981276460",
                    lblNumeroFactura.Text,
                    "12345678901234567890...",
                    DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                    cliente.RazonSocial,
                    cliente.CedulaRuc,
                    cliente.Direccion,
                    subtotal,
                    descuento,
                    iva,
                    total,
                    "EFECTIVO",
                    efectivoRecibido,
                    cambio,
                    "GUAYAQUIL / FEBRES CORDERO / ORIENTE S/N Y 38 AVA",
                    "0981276460",
                    "GUAYAQUIL / FEBRES CORDERO / ORIENTE S/N Y 38 AVA"
                );

                using (FrmVisorFactura frmVisor = new FrmVisorFactura(dtInfo, dtDetalle))
                {
                    frmVisor.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar la factura para imprimir:\n" + ex.Message, "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LimpiarPOS()
        {
            // Limpia todos los controles de cliente, productos y totales
            txtIdentificacion.Clear();
            txtCliente.Clear();
            txtEmail.Clear();
            dgvDetalleVenta.Rows.Clear();
            dgvDetalleVenta.Rows.Add();
            lblPrecio.Text = "0.00";
            lblIVA.Text = "0.00";
            lblTotalDescuento.Text = "0.00";
            _clienteSeleccionado = null;
        }

        private decimal CalcularTotalVenta()
        {
            decimal total = 0;
            foreach (DataGridViewRow fila in dgvDetalleVenta.Rows)
            {
                if (fila.Cells["colTotal"].Value != null &&
                    decimal.TryParse(fila.Cells["colTotal"].Value.ToString(), out decimal valor))
                {
                    total += valor;
                }
            }
            return total;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFechaHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFechaCompleta.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy");
        }

     
        private void dgvDetalleVenta_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var colName = dgvDetalleVenta.Columns[e.ColumnIndex].Name;

            // --- LÓGICA DE BÚSQUEDA DE PRODUCTO ---
            if (colName == "colCodigo" || colName == "colProducto")
            {
                string textoBuscado = dgvDetalleVenta.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                if (!string.IsNullOrEmpty(textoBuscado))
                {
                    BuscarYAsignarProducto(textoBuscado, e.RowIndex);
                }
            }

            // --- LÓGICA DE CÁLCULO DE TOTALES ---
            if (colName == "colCantidad" || colName == "colPrecio" || colName == "colDscto")
            {
                DataGridViewRow fila = dgvDetalleVenta.Rows[e.RowIndex];
                CalcularTotalesFila(fila);
            }
        }

        private void BuscarYAsignarProducto(string terminoBusqueda, int rowIndex)
        {
            try
            {
                DProductos d_Productos = new DProductos();
                List<EProducto> productos = d_Productos.BuscarProductosActivos(terminoBusqueda);

                if (productos.Count == 1)
                {
                    // Solo un producto: asigna directo
                    AsignarDatosAFila(productos[0], rowIndex);
                }
                else if (productos.Count > 1)
                {
                    // Más de uno: abrir el modal de selección
                    using (var frm = new FrmSeleccionarProducto(productos))
                    {
                        if (frm.ShowDialog() == DialogResult.OK && frm.ProductoSeleccionado != null)
                        {
                            AsignarDatosAFila(frm.ProductoSeleccionado, rowIndex);
                        }
                        else
                        {
                            LimpiarFila(rowIndex);
                        }
                    }
                }
                else
                {
                    // Ninguno: muestra mensaje y limpia
                    MessageBox.Show("Producto no encontrado.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LimpiarFila(rowIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AsignarDatosAFila(EProducto producto, int rowIndex)
        {
            DataGridViewRow filaActual = dgvDetalleVenta.Rows[rowIndex];

            // Evitar que el evento se dispare de nuevo al asignar valores
            dgvDetalleVenta.CellEndEdit -= dgvDetalleVenta_CellEndEdit;

            filaActual.Cells["colCodigo"].Value = producto.CodigoPrincipal;
            filaActual.Cells["colProducto"].Value = producto.Nombre;
            filaActual.Cells["colPrecio"].Value = producto.PrecioVenta;
            filaActual.Cells["colCantidad"].Value = 1;
            filaActual.Cells["colPFinal"].Value = producto.PrecioVenta;
            filaActual.Cells["colDscto"].Value = 0; // Descuento inicial

            // Volver a activar el evento
            dgvDetalleVenta.CellEndEdit += dgvDetalleVenta_CellEndEdit;

            CalcularTotalesFila(filaActual);

            // Si es la última fila, añade una nueva para el siguiente producto
            if (rowIndex == dgvDetalleVenta.Rows.Count - 1)
            {
                dgvDetalleVenta.Rows.Add();
            }

            // Mover el foco a la celda de Cantidad para una venta rápida
            dgvDetalleVenta.CurrentCell = filaActual.Cells["colCantidad"];
            dgvDetalleVenta.BeginEdit(true);
        }

        private void LimpiarFila(int rowIndex)
        {
            DataGridViewRow filaActual = dgvDetalleVenta.Rows[rowIndex];
            filaActual.Cells["colCodigo"].Value = string.Empty;
            filaActual.Cells["colProducto"].Value = string.Empty;
            // ... limpiar las demás celdas numéricas
        }

        private void CalcularTotalesFila(DataGridViewRow fila)
        {
            try
            {
                decimal cantidad = Convert.ToDecimal(fila.Cells["colCantidad"].Value ?? 0);
                decimal precioFinal = Convert.ToDecimal(fila.Cells["colPFinal"].Value ?? 0);
                decimal descuentoPorc = Convert.ToDecimal(fila.Cells["colDscto"].Value ?? 0);

                decimal subtotal = cantidad * precioFinal;
                decimal montoDescuento = subtotal * (descuentoPorc / 100);
                decimal subtotalConDescuento = subtotal - montoDescuento;

                // Suponiendo un IVA del 15%
                decimal iva = subtotalConDescuento * 0.15m;
                decimal total = subtotalConDescuento + iva;

                fila.Cells["colSubtotal"].Value = subtotalConDescuento;
                fila.Cells["colIVA"].Value = iva;
                fila.Cells["colTotal"].Value = total;

                // Formatear celdas para mostrar como moneda
                fila.Cells["colPrecio"].Value = string.Format("{0:N2}", fila.Cells["colPrecio"].Value);
                fila.Cells["colPFinal"].Value = string.Format("{0:N2}", precioFinal);
                fila.Cells["colSubtotal"].Value = string.Format("{0:N2}", subtotalConDescuento);
                fila.Cells["colIVA"].Value = string.Format("{0:N2}", iva);
                fila.Cells["colTotal"].Value = string.Format("{0:N2}", total);

                // Actualizar los totales generales del formulario
                CalcularTotalesGenerales();
            }
            catch (Exception ex)
            {
                // Silenciosamente ignorar errores de formato mientras el usuario escribe
            }
        }

        private void CalcularTotalesGenerales()
        {
            decimal totalGeneral = 0;
            decimal subtotalGeneral = 0;
            decimal ivaGeneral = 0;
            decimal totalDescuento = 0;

            foreach (DataGridViewRow fila in dgvDetalleVenta.Rows)
            {
                if (fila.IsNewRow) continue;

                decimal.TryParse(fila.Cells["colSubtotal"].Value?.ToString(), out decimal sub);
                decimal.TryParse(fila.Cells["colIVA"].Value?.ToString(), out decimal iva);
                decimal.TryParse(fila.Cells["colTotal"].Value?.ToString(), out decimal total);
                decimal.TryParse(fila.Cells["colDscto"].Value?.ToString(), out decimal dctoPorcentaje);
                decimal.TryParse(fila.Cells["colPFinal"].Value?.ToString(), out decimal precioFinal);
                decimal.TryParse(fila.Cells["colCantidad"].Value?.ToString(), out decimal cantidad);

                subtotalGeneral += sub;
                ivaGeneral += iva;
                totalGeneral += total;

                // Calcular descuento monetario total
                decimal subtotalSinDescuento = cantidad * precioFinal;
                decimal dcto = subtotalSinDescuento * (dctoPorcentaje / 100);
                totalDescuento += dcto;
            }

            // ✅ Corrección de asignación:
            // Mostramos el TOTAL con IVA en "lblPrecio"
            lblPrecio.Text = totalGeneral.ToString("N2");

            // Mostramos solo el IVA real en "lblIVA"
            lblIVA.Text = ivaGeneral.ToString("N2");

            // Subtotal general sin IVA
            lblPrecio.Text = subtotalGeneral.ToString("N2");

            // Total general con IVA (por si tienes otra label como label7)
            lblIVA.Text = ivaGeneral.ToString("N2");

            // Mostrar total descuento si corresponde
            lblTotalDescuento.Text = totalDescuento.ToString("N2");
        }



        // Evento para poner el ícono de eliminar en cada nueva fila
        private void dgvDetalleVenta_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // Asigna la imagen al botón de eliminar
            DataGridViewRow row = dgvDetalleVenta.Rows[e.RowIndex];
            //row.Cells["colEliminar"].Value = Properties.Resources.delete_icon; // Asegúrate de tener este recurso de imagen
        }

        private void CalcularTotalFila(DataGridViewRow fila)
        {
            decimal cantidad = 0, precio = 0;
            decimal.TryParse(fila.Cells["colCantidad"].Value?.ToString(), out cantidad);
            decimal.TryParse(fila.Cells["colPrecio"].Value?.ToString(), out precio);

            decimal total = cantidad * precio;
            fila.Cells["colTotal"].Value = total > 0 ? total.ToString("N2") : null;
        }

        private void dgvDetalleVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegúrate de que no sea la fila de nueva fila y que sea la columna eliminar
            if (e.RowIndex >= 0 && dgvDetalleVenta.Columns[e.ColumnIndex].Name == "colEliminar")
            {
                dgvDetalleVenta.Rows.RemoveAt(e.RowIndex);

                // Si no hay filas, deja siempre una vacía
                if (dgvDetalleVenta.Rows.Count == 0)
                    dgvDetalleVenta.Rows.Add();
            }
            CalcularTotalesGenerales();
        }

        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificamos si la tecla presionada NO es un número Y NO es una tecla de control (como borrar)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número, cancelamos la pulsación de la tecla.
                e.Handled = true;
            }
        }

        private void txtIdentificacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string id = txtIdentificacion.Text.Trim();
                if (string.IsNullOrEmpty(id)) return;

                try
                {
                    DClientes d_Clientes = new DClientes();
                    ECliente cliente = d_Clientes.BuscarClientePorId(id);

                    if (cliente != null)
                    {
                        // Si el cliente existe, llenamos los datos
                        _clienteSeleccionado = cliente;
                        txtCliente.Text = cliente.RazonSocial;
                        txtEmail.Text = cliente.Email;
                    }
                    else
                    {
                        // Si no existe, preguntamos si desea crearlo
                        var resultado = MessageBox.Show("Cliente no encontrado. ¿Desea registrarlo ahora?", "Cliente Nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (resultado == DialogResult.Yes)
                        {
                            using (var frm = new FrmFichaCliente(id))
                            {
                                if (frm.ShowDialog() == DialogResult.OK)
                                {
                                    // Si se guardó, actualizamos los datos en el POS
                                    _clienteSeleccionado = frm.ClienteGuardado;
                                    txtCliente.Text = frm.ClienteGuardado.Nombres;
                                    txtEmail.Text = frm.ClienteGuardado.Email;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
