using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmCotizaciones : Form
    {
        public FrmCotizaciones()
        {
            InitializeComponent();

            // Eventos de DataGridView
            this.dgvDetalleVenta.CellEndEdit += dgvDetalleVenta_CellEndEdit;
            this.dgvDetalleVenta.CellContentClick += dgvDetalleVenta_CellContentClick;

            // Eventos de identificación cliente
            this.txtIdentificacion.KeyDown += txtIdentificacion_KeyDown;
            this.txtIdentificacion.KeyPress += txtIdentificacion_KeyPress;
        }

        private void FrmCotizaciones_Load(object sender, EventArgs e)
        {
            // Si quieres una fila vacía al iniciar
            if (dgvDetalleVenta.Rows.Count == 0)
                dgvDetalleVenta.Rows.Add();
        }

        // Solo números en txtIdentificacion
        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // Buscar cliente al presionar Enter
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
                        // Rellena los campos de tu formulario
                        txtCliente.Text = cliente.RazonSocial;
                        txtEmail.Text = cliente.Email;
                        txtTelefono.Text = cliente.Telefono;
                        txtDireccion.Text = cliente.Direccion;
                    }
                    else
                    {
                        // Cliente no existe
                        var resultado = MessageBox.Show("Cliente no encontrado. ¿Desea registrarlo ahora?", "Cliente Nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (resultado == DialogResult.Yes)
                        {
                            // Llama a tu formulario para registrar cliente
                            using (var frm = new FrmFichaCliente(id))
                            {
                                if (frm.ShowDialog() == DialogResult.OK)
                                {
                                    // Al regresar de guardar, muestra los datos nuevos
                                    txtCliente.Text = frm.ClienteGuardado.RazonSocial;
                                    txtEmail.Text = frm.ClienteGuardado.Email;
                                    txtTelefono.Text = frm.ClienteGuardado.Telefono;
                                    txtDireccion.Text = frm.ClienteGuardado.Direccion;
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


        private void dgvDetalleVenta_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var colName = dgvDetalleVenta.Columns[e.ColumnIndex].Name;

            // Búsqueda de producto por código o nombre
            if (colName == "colCodigo" || colName == "colProducto")
            {
                string textoBuscado = dgvDetalleVenta.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                if (!string.IsNullOrEmpty(textoBuscado))
                    BuscarYAsignarProducto(textoBuscado, e.RowIndex);
            }

            // Calcular totales de fila al editar cantidad, precio o dscto
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
                    AsignarDatosAFila(productos[0], rowIndex);
                }
                else if (productos.Count > 1)
                {
                    using (var frm = new FrmSeleccionarProducto(productos))
                    {
                        if (frm.ShowDialog() == DialogResult.OK && frm.ProductoSeleccionado != null)
                            AsignarDatosAFila(frm.ProductoSeleccionado, rowIndex);
                        else
                            LimpiarFila(rowIndex);
                    }
                }
                else
                {
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
            DataGridViewRow fila = dgvDetalleVenta.Rows[rowIndex];

            // Evitar evento recursivo
            dgvDetalleVenta.CellEndEdit -= dgvDetalleVenta_CellEndEdit;

            fila.Cells["colCodigo"].Value = producto.CodigoPrincipal;
            fila.Cells["colProducto"].Value = producto.Nombre;
            fila.Cells["colPrecio"].Value = producto.PrecioVenta;
            fila.Cells["colCantidad"].Value = 1;
            fila.Cells["colPFinal"].Value = producto.PrecioVenta;
            fila.Cells["colDscto"].Value = 0;

            dgvDetalleVenta.CellEndEdit += dgvDetalleVenta_CellEndEdit;

            CalcularTotalesFila(fila);

            if (rowIndex == dgvDetalleVenta.Rows.Count - 1)
                dgvDetalleVenta.Rows.Add();

            dgvDetalleVenta.CurrentCell = fila.Cells["colCantidad"];
            dgvDetalleVenta.BeginEdit(true);
        }

        private void LimpiarFila(int rowIndex)
        {
            var fila = dgvDetalleVenta.Rows[rowIndex];
            fila.Cells["colCodigo"].Value = string.Empty;
            fila.Cells["colProducto"].Value = string.Empty;
            fila.Cells["colPrecio"].Value = null;
            fila.Cells["colCantidad"].Value = null;
            fila.Cells["colPFinal"].Value = null;
            fila.Cells["colDscto"].Value = null;
            fila.Cells["colSubtotal"].Value = null;
            fila.Cells["colIVA"].Value = null;
            fila.Cells["colTotal"].Value = null;
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

                decimal iva = subtotalConDescuento * 0.15m;
                decimal total = subtotalConDescuento + iva;

                fila.Cells["colSubtotal"].Value = subtotalConDescuento.ToString("N2");
                fila.Cells["colIVA"].Value = iva.ToString("N2");
                fila.Cells["colTotal"].Value = total.ToString("N2");

                // Llama aquí a los totales generales
                CalcularTotalesGenerales();
            }
            catch
            {
                // Ignorar errores de conversión mientras el usuario edita
            }
        }


        private void dgvDetalleVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Eliminar fila con el icono eliminar
            if (e.RowIndex >= 0 && dgvDetalleVenta.Columns[e.ColumnIndex].Name == "colEliminar")
            {
                dgvDetalleVenta.Rows.RemoveAt(e.RowIndex);

                if (dgvDetalleVenta.Rows.Count == 0)
                    dgvDetalleVenta.Rows.Add();
            }
            CalcularTotalesGenerales();
        }

        private void CalcularTotalesGenerales()
        {
            decimal subtotal = 0, descuentoTotal = 0, ivaTotal = 0, total = 0;

            foreach (DataGridViewRow fila in dgvDetalleVenta.Rows)
            {
                if (fila.IsNewRow) continue;

                decimal cantidad = Convert.ToDecimal(fila.Cells["colCantidad"].Value ?? 0);
                decimal precio = Convert.ToDecimal(fila.Cells["colPFinal"].Value ?? 0);
                decimal dsctoPorc = Convert.ToDecimal(fila.Cells["colDscto"].Value ?? 0);

                decimal subfila = cantidad * precio;
                decimal descuento = subfila * (dsctoPorc / 100);
                decimal subConDscto = subfila - descuento;
                decimal iva = subConDscto * 0.15m; // Asumes 15%
                decimal totfila = subConDscto + iva;

                subtotal += subfila;
                descuentoTotal += descuento;
                ivaTotal += iva;
                total += totfila;
            }

            lblSubtotal.Text = subtotal.ToString("C2");
            lblDescuento.Text = descuentoTotal.ToString("C2");
            lblIVA.Text = ivaTotal.ToString("C2");
            lblTotal.Text = total.ToString("C2");
        }


        // Si necesitas agregar totales generales, implementa CalcularTotalesGenerales igual que en el POS
    }

}
