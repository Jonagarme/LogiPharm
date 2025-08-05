using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmPuntoDeVenta : Form
    {
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
            decimal totalVenta = CalcularTotalVenta(); // método auxiliar
            using (FrmPago frmPago = new FrmPago(totalVenta))
            {
                if (frmPago.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Pago realizado con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // TODO: aquí puedes guardar la venta, limpiar el formulario, imprimir, etc.
                }
            }
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

        //private void dgvDetalleVenta_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    var colName = dgvDetalleVenta.Columns[e.ColumnIndex].Name;

        //    // Búsqueda por código o producto
        //    if (colName == "colCodigo" || colName == "colProducto")
        //    {
        //        string textoBuscado = dgvDetalleVenta.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

        //        if (!string.IsNullOrEmpty(textoBuscado))
        //        {
        //            try
        //            {
        //                DProductos d_Productos = new DProductos();
        //                EProducto productoEncontrado = d_Productos.BuscarProductoPorCodigoONombre(textoBuscado);

        //                if (productoEncontrado != null)
        //                {
        //                    DataGridViewRow filaActual = dgvDetalleVenta.Rows[e.RowIndex];
        //                    filaActual.Cells["colCodigo"].Value = productoEncontrado.CodigoPrincipal;
        //                    filaActual.Cells["colProducto"].Value = productoEncontrado.Nombre;
        //                    filaActual.Cells["colPrecio"].Value = productoEncontrado.PrecioVenta;

        //                    // Si la cantidad es nula, pon 1
        //                    if (filaActual.Cells["colCantidad"].Value == null)
        //                        filaActual.Cells["colCantidad"].Value = 1;

        //                    filaActual.Cells["colPFinal"].Value = productoEncontrado.PrecioVenta;

        //                    // Calcular total inicial (cantidad x precio)
        //                    CalcularTotalFila(filaActual);

        //                    // Mover foco a cantidad
        //                    dgvDetalleVenta.CurrentCell = filaActual.Cells["colCantidad"];
        //                    dgvDetalleVenta.BeginEdit(true);

        //                    // Si es la última fila, añade una vacía
        //                    if (e.RowIndex == dgvDetalleVenta.Rows.Count - 1)
        //                        dgvDetalleVenta.Rows.Add();
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Producto no encontrado.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        //                    dgvDetalleVenta.Rows[e.RowIndex].Cells["colCodigo"].Value = "";
        //                    dgvDetalleVenta.Rows[e.RowIndex].Cells["colProducto"].Value = "";
        //                    dgvDetalleVenta.Rows[e.RowIndex].Cells["colPrecio"].Value = null;
        //                    dgvDetalleVenta.Rows[e.RowIndex].Cells["colCantidad"].Value = null;
        //                    dgvDetalleVenta.Rows[e.RowIndex].Cells["colTotal"].Value = null;
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message, "Error en Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //    }

        //    // Calcular total al editar cantidad o precio
        //    if (colName == "colCantidad" || colName == "colPrecio")
        //    {
        //        DataGridViewRow fila = dgvDetalleVenta.Rows[e.RowIndex];
        //        CalcularTotalFila(fila);
        //    }
        //}

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
