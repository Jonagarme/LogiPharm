using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmCotizaciones : Form
    {
        // Estado de formulario
        private ECliente _clienteActual;
        private long? _idCotizacionActual;

        public FrmCotizaciones()
        {
            InitializeComponent();

            // Eventos de DataGridView
            this.dgvDetalleVenta.CellEndEdit += dgvDetalleVenta_CellEndEdit;
            this.dgvDetalleVenta.CellContentClick += dgvDetalleVenta_CellContentClick;

            // Eventos de identificación cliente
            this.txtIdentificacion.KeyDown += txtIdentificacion_KeyDown;
            this.txtIdentificacion.KeyPress += txtIdentificacion_KeyPress;

            // Eventos de toolbar
            this.btnNuevo.Click += btnNuevo_Click;
            this.btnGuardar.Click += btnGuardar_Click;
            this.btnAnular.Click += btnAnular_Click;

            // Acceso rápido para buscar cotización por número (F3)
            this.KeyPreview = true;
            this.KeyDown += FrmCotizaciones_KeyDown;
        }

        private void FrmCotizaciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Ingrese No. Cotización:", "Buscar Cotización", "");
                if (int.TryParse(input, out int numero))
                {
                    CargarCotizacionPorNumero(numero);
                }
            }
            else if (e.KeyCode == Keys.F4)
            {
                // F4: cargar la última
                CargarUltimaCotizacion();
            }
        }

        private void FrmCotizaciones_Load(object sender, EventArgs e)
        {
            // fila vacía al iniciar
            if (dgvDetalleVenta.Rows.Count == 0)
                dgvDetalleVenta.Rows.Add();

            dtpFecha.Value = DateTime.Now;
            LimpiarTotales();
            ActualizarEstadoVisual("VIGENTE", dtpFecha.Value, (int)numValidez.Value);

            // Mostrar el próximo número sin reservarlo
            try
            {
                var d = new DCotizaciones();
                int siguiente = d.ObtenerProximoNumeroPreview();
                txtNumeroCotizacion.Text = siguiente.ToString("D6");
            }
            catch { }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormularioCotizacion();
            // Actualiza con el próximo número
            try
            {
                var d = new DCotizaciones();
                int siguiente = d.ObtenerProximoNumeroPreview();
                txtNumeroCotizacion.Text = siguiente.ToString("D6");
            }
            catch { }
            ActualizarEstadoVisual("VIGENTE", DateTime.Now, (int)numValidez.Value);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarCotizacion();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            AnularCotizacion();
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
                        _clienteActual = cliente;
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
                                    // Reconsultar para obtener el ID asignado en la BD
                                    _clienteActual = d_Clientes.BuscarClientePorId(id);
                                    if (_clienteActual != null)
                                    {
                                        txtCliente.Text = _clienteActual.RazonSocial;
                                        txtEmail.Text = _clienteActual.Email;
                                        txtTelefono.Text = _clienteActual.Telefono;
                                        txtDireccion.Text = _clienteActual.Direccion;
                                    }
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

            // Guardar referencia al producto para recuperar su ID al guardar
            fila.Tag = producto; // contiene Id, Codigo, Nombre, PrecioVenta

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
            fila.Tag = null;
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

        private void LimpiarFormularioCotizacion()
        {
            _idCotizacionActual = null;
            _clienteActual = null;
            txtIdentificacion.Clear();
            txtCliente.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtObservaciones.Clear();
            dtpFecha.Value = DateTime.Now;
            numValidez.Value = 15;

            // Reiniciar grid
            dgvDetalleVenta.Rows.Clear();
            dgvDetalleVenta.Rows.Add();

            // Reiniciar totales
            LimpiarTotales();

            txtNumeroCotizacion.Text = "000000"; // se asigna al guardar
        }

        private void LimpiarTotales()
        {
            lblSubtotal.Text = "$0.00";
            lblDescuento.Text = "$0.00";
            lblIVA.Text = "$0.00";
            lblTotal.Text = "$0.00";
        }

        private void GuardarCotizacion()
        {
            try
            {
                if (_clienteActual == null || _clienteActual.Id <= 0)
                {
                    MessageBox.Show("Debe seleccionar un cliente válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIdentificacion.Focus();
                    return;
                }

                var detalles = new List<ECotizacionDetalle>();
                decimal subtotal = 0m, descuento = 0m, iva = 0m, total = 0m;

                foreach (DataGridViewRow fila in dgvDetalleVenta.Rows)
                {
                    if (fila.IsNewRow) continue;
                    if (fila.Cells["colProducto"].Value == null || string.IsNullOrWhiteSpace(fila.Cells["colProducto"].Value.ToString()))
                        continue;

                    var prod = fila.Tag as EProducto;
                    if (prod == null || prod.Id <= 0)
                    {
                        MessageBox.Show("Hay filas con productos no válidos. Reemplace o elimine esas filas.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    decimal cantidad = ToDecimal(fila.Cells["colCantidad"].Value);
                    decimal precioUnitario = ToDecimal(fila.Cells["colPrecio"].Value);
                    decimal precioFinal = ToDecimal(fila.Cells["colPFinal"].Value);
                    decimal dsctoPorc = ToDecimal(fila.Cells["colDscto"].Value);

                    decimal sub = cantidad * precioFinal;
                    decimal dsctoVal = sub * (dsctoPorc / 100m);
                    decimal subConDscto = sub - dsctoVal;
                    decimal ivaVal = subConDscto * 0.15m;
                    decimal tot = subConDscto + ivaVal;

                    detalles.Add(new ECotizacionDetalle
                    {
                        IdProducto = (int)prod.Id,
                        Codigo = prod.CodigoPrincipal,
                        ProductoNombre = prod.Nombre,
                        Cantidad = cantidad,
                        PrecioUnitario = precioUnitario,
                        PrecioFinal = precioFinal,
                        DescuentoPorc = dsctoPorc,
                        DescuentoValor = dsctoVal,
                        IVAValor = ivaVal,
                        Subtotal = subConDscto,
                        Total = tot
                    });

                    subtotal += sub;
                    descuento += dsctoVal;
                    iva += ivaVal;
                    total += tot;
                }

                if (detalles.Count == 0)
                {
                    MessageBox.Show("Debe ingresar al menos un producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var cot = new ECotizacion
                {
                    Id = _idCotizacionActual ?? 0,
                    Numero = 0, // se asigna en la BD
                    Fecha = dtpFecha.Value.Date,
                    ValidezDias = (int)numValidez.Value,
                    IdCliente = _clienteActual.Id,
                    Observaciones = txtObservaciones.Text?.Trim(),
                    Subtotal = subtotal,
                    Descuento = descuento,
                    IVA = iva,
                    Total = total,
                    Estado = "VIGENTE",
                    CreadoPor = SesionActual.IdUsuario,
                    Detalles = detalles
                };

                DCotizaciones d = new DCotizaciones();
                long idGenerado = d.GuardarCotizacion(cot, SesionActual.IdUsuario);
                _idCotizacionActual = idGenerado;

                // Mostrar número asignado
                int numero = d.ObtenerNumeroPorId(idGenerado);
                if (numero > 0)
                    txtNumeroCotizacion.Text = numero.ToString("D6");

                ActualizarEstadoVisual("VIGENTE", dtpFecha.Value, (int)numValidez.Value);

                // Auditoría: CREAR o EDITAR
                try
                {
                    string accion = (cot.Id == 0) ? "CREAR" : "EDITAR";
                    string desc = $"Cotización No. {txtNumeroCotizacion.Text} guardada";
                    new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Cotizaciones", accion, "cotizaciones", (long)idGenerado, desc, null, Environment.MachineName, "UI");
                }
                catch { }

                MessageBox.Show("Cotización guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AnularCotizacion()
        {
            try
            {
                if (!_idCotizacionActual.HasValue)
                {
                    MessageBox.Show("No hay una cotización guardada para anular.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var resp = MessageBox.Show("¿Confirma anular esta cotización?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp != DialogResult.Yes) return;

                DCotizaciones d = new DCotizaciones();
                d.AnularCotizacion(_idCotizacionActual.Value, SesionActual.IdUsuario);

                ActualizarEstadoVisual("ANULADA", dtpFecha.Value, (int)numValidez.Value);

                // Auditoría: ANULAR
                try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Cotizaciones", "ANULAR", "cotizaciones", (long)_idCotizacionActual.Value, $"Cotización No. {txtNumeroCotizacion.Text} anulada", null, Environment.MachineName, "UI"); } catch { }

                MessageBox.Show("Cotización anulada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al anular", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCotizacionEnFormulario(ECotizacion cot)
        {
            _idCotizacionActual = cot.Id;
            txtNumeroCotizacion.Text = cot.Numero.ToString("D6");
            dtpFecha.Value = cot.Fecha;
            numValidez.Value = cot.ValidezDias;
            txtObservaciones.Text = cot.Observaciones;

            // Estado visual dependiente de fecha y campo estado
            ActualizarEstadoVisual(cot.Estado, cot.Fecha, cot.ValidezDias);

            // Auditoría: VISUALIZAR
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Cotizaciones", "VISUALIZAR", "cotizaciones", cot.Id, $"Ver cotización No. {txtNumeroCotizacion.Text}", null, Environment.MachineName, "UI"); } catch { }

            // Cargar cliente
            try
            {
                var dCli = new DClientes();
                var cli = dCli.ObtenerClientePorId(cot.IdCliente);
                _clienteActual = cli;
                if (cli != null)
                {
                    txtIdentificacion.Text = cli.CedulaRuc;
                    txtCliente.Text = string.IsNullOrEmpty(cli.RazonSocial) ? ($"{cli.Nombres} {cli.Apellidos}").Trim() : cli.RazonSocial;
                    txtDireccion.Text = cli.Direccion;
                    txtTelefono.Text = cli.Telefono;
                    txtEmail.Text = cli.Email;
                }
            }
            catch { }

            // Cargar detalle
            dgvDetalleVenta.Rows.Clear();
            foreach (var det in cot.Detalles)
            {
                int idx = dgvDetalleVenta.Rows.Add();
                var fila = dgvDetalleVenta.Rows[idx];
                fila.Cells["colCodigo"].Value = det.Codigo;
                fila.Cells["colProducto"].Value = det.ProductoNombre;
                fila.Cells["colCantidad"].Value = det.Cantidad;
                fila.Cells["colPrecio"].Value = det.PrecioUnitario;
                fila.Cells["colPFinal"].Value = det.PrecioFinal;
                fila.Cells["colDscto"].Value = det.DescuentoPorc;
                fila.Cells["colSubtotal"].Value = det.Subtotal.ToString("N2");
                fila.Cells["colIVA"].Value = det.IVAValor.ToString("N2");
                fila.Cells["colTotal"].Value = det.Total.ToString("N2");
            }
            if (dgvDetalleVenta.Rows.Count == 0)
                dgvDetalleVenta.Rows.Add();

            lblSubtotal.Text = cot.Subtotal.ToString("C2");
            lblDescuento.Text = cot.Descuento.ToString("C2");
            lblIVA.Text = cot.IVA.ToString("C2");
            lblTotal.Text = cot.Total.ToString("C2");
        }

        private void ActualizarEstadoVisual(string estadoBD, DateTime fechaCotizacion, int validezDias)
        {
            // Si está anulada en BD, prioriza ese estado
            if (string.Equals(estadoBD, "ANULADA", StringComparison.OrdinalIgnoreCase))
            {
                lblEstado.Text = "ANULADA";
                lblEstado.ForeColor = System.Drawing.Color.Maroon;
                return;
            }

            // Si han pasado más días que la validez, se marca como vencida visualmente
            var dias = (DateTime.Now.Date - fechaCotizacion.Date).TotalDays;
            if (dias > validezDias)
            {
                lblEstado.Text = "VENCIDA";
                lblEstado.ForeColor = System.Drawing.Color.DarkOrange;
            }
            else
            {
                lblEstado.Text = "VIGENTE";
                lblEstado.ForeColor = System.Drawing.Color.ForestGreen;
            }
        }

        private decimal ToDecimal(object value)
        {
            if (value == null || value == DBNull.Value) return 0m;
            decimal result;
            if (decimal.TryParse(value.ToString(), out result)) return result;
            return 0m;
        }

        private void CargarUltimaCotizacion()
        {
            try
            {
                var d = new DCotizaciones();
                var cot = d.ObtenerUltimaCotizacion();
                if (cot == null)
                {
                    MessageBox.Show("No existen cotizaciones.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                CargarCotizacionEnFormulario(cot);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCotizacionPorNumero(int numero)
        {
            try
            {
                var d = new DCotizaciones();
                var cot = d.ObtenerCotizacionPorNumero(numero);
                if (cot == null)
                {
                    MessageBox.Show("No se encontró la cotización.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                CargarCotizacionEnFormulario(cot);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
