using System;
using System.Collections.Generic;
using System.Drawing; // Necesario para los colores
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmSeleccionarProducto : Form
    {
        public EProducto ProductoSeleccionado { get; private set; }
        private string _terminoBusquedaInicial;
        private List<EProducto> _listaProductos = null;

        // Constructor para búsqueda por texto
        public FrmSeleccionarProducto(string terminoBusqueda = "")
        {
            InitializeComponent();
            _terminoBusquedaInicial = terminoBusqueda;
            
            // Habilitar cierre con tecla ESC
            this.KeyPreview = true;
            this.KeyDown += FrmSeleccionarProducto_KeyDown;
        }

        // Constructor para lista predefinida
        public FrmSeleccionarProducto(List<EProducto> productos)
        {
            InitializeComponent();
            _listaProductos = productos;
            
            // Habilitar cierre con tecla ESC
            this.KeyPreview = true;
            this.KeyDown += FrmSeleccionarProducto_KeyDown;
        }

        private void FrmSeleccionarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter && !txtBuscar.Focused)
            {
                // Permitir Enter para seleccionar el producto (cuando no está en el campo de búsqueda)
                e.Handled = true;
                SeleccionarProducto();
            }
        }

        private void FrmSeleccionarProducto_Load(object sender, EventArgs e)
        {
            // Limpia los detalles al inicio
            LimpiarDetalles();

            if (_listaProductos != null)
            {
                // Carga desde la lista proporcionada
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = _listaProductos;
                txtBuscar.Enabled = false; // Deshabilitar búsqueda si se usa una lista fija
            }
            else
            {
                // Carga y filtra según el texto inicial
                txtBuscar.Text = _terminoBusquedaInicial;
                CargarYFiltrarProductos();
            }

            // Después de cargar, si hay filas, muestra los detalles de la primera
            if (dgvProductos.Rows.Count > 0)
            {
                MostrarDetallesProducto();
            }
        }

        private void CargarYFiltrarProductos()
        {
            try
            {
                DProductos d_Productos = new DProductos();
                // **RECOMENDACIÓN:** Asegúrate de que `BuscarProductosActivos` devuelva List<EProducto>
                // para simplificar el código y evitar conversiones manuales.
                dgvProductos.DataSource = d_Productos.BuscarProductosActivos(txtBuscar.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- MÉTODOS PARA EL NUEVO PANEL DE DETALLES ---

        /// <summary>
        /// Rellena el panel de detalles con la información del producto seleccionado en el grid.
        /// </summary>
        private void MostrarDetallesProducto()
        {
            if (dgvProductos.CurrentRow != null && dgvProductos.CurrentRow.DataBoundItem is EProducto producto)
            {
                gbDetalles.Text = producto.Nombre;
                lblDescripcion.Text = !string.IsNullOrEmpty(producto.Descripcion) ? producto.Descripcion : "No hay descripción disponible.";
                
                // Fecha de vencimiento y alerta
                txtFechaVencimiento.Text = producto.FechaVencimiento.ToString("dd/MM/yyyy");
                MostrarAlertaVencimiento(producto);

                // Stock con colores
                lblStockValor.Text = producto.Stock.ToString("N2");
                MostrarEstadoStock(producto);

                // Categoría y Laboratorio
                lblCategoria.Text = !string.IsNullOrEmpty(producto.NombreCategoria) ? producto.NombreCategoria : "Sin categoría";
                lblLaboratorio.Text = !string.IsNullOrEmpty(producto.NombreLaboratorio) ? producto.NombreLaboratorio : "Sin laboratorio";

                // Ubicación (Percha)
                lblUbicacion.Text = !string.IsNullOrEmpty(producto.Ubicacion) ? $"📍 {producto.Ubicacion}" : "Sin ubicar";

                // Costo y Precio
                lblCosto.Text = $"${producto.CostoUnidad:N2}";

                // Margen de ganancia
                if (producto.CostoUnidad > 0)
                {
                    lblMargen.Text = $"{producto.MargenPorcentaje:N1}% (+${producto.MargenValor:N2})";
                    lblMargen.ForeColor = producto.MargenPorcentaje > 30 ? Color.Green : 
                                         producto.MargenPorcentaje > 15 ? Color.Orange : Color.Red;
                }
                else
                {
                    lblMargen.Text = "N/A";
                    lblMargen.ForeColor = Color.Gray;
                }
            }
            else
            {
                LimpiarDetalles();
            }
        }

        /// <summary>
        /// Muestra alerta visual si el producto está próximo a vencer.
        /// </summary>
        private void MostrarAlertaVencimiento(EProducto producto)
        {
            int diasRestantes = producto.DiasParaVencer;

            if (diasRestantes < 0)
            {
                // Vencido
                panelVencimiento.Visible = true;
                panelVencimiento.FillColor = Color.FromArgb(255, 200, 200);
                txtFechaVencimiento.ForeColor = Color.DarkRed;
                txtFechaVencimiento.Font = new Font(txtFechaVencimiento.Font, FontStyle.Bold);
            }
            else if (diasRestantes <= 30)
            {
                // Crítico (menos de 1 mes)
                panelVencimiento.Visible = true;
                panelVencimiento.FillColor = Color.FromArgb(255, 200, 200);
                txtFechaVencimiento.ForeColor = Color.DarkRed;
                txtFechaVencimiento.Font = new Font(txtFechaVencimiento.Font, FontStyle.Bold);
            }
            else if (diasRestantes <= 90)
            {
                // Advertencia (menos de 3 meses)
                panelVencimiento.Visible = true;
                panelVencimiento.FillColor = Color.FromArgb(255, 245, 200);
                txtFechaVencimiento.ForeColor = Color.FromArgb(160, 98, 0);
                txtFechaVencimiento.Font = new Font(txtFechaVencimiento.Font, FontStyle.Bold);
            }
            else
            {
                // OK
                panelVencimiento.Visible = false;
                txtFechaVencimiento.ForeColor = Color.Black;
                txtFechaVencimiento.Font = new Font(txtFechaVencimiento.Font, FontStyle.Regular);
            }
        }

        /// <summary>
        /// Muestra el estado del stock con colores.
        /// </summary>
        private void MostrarEstadoStock(EProducto producto)
        {
            if (producto.Stock <= 0)
            {
                panelStock.FillColor = Color.FromArgb(255, 200, 200);
                lblStockValor.ForeColor = Color.DarkRed;
                lblStockTexto.Text = "🚨 SIN STOCK";
            }
            else if (producto.Stock <= producto.StockMinimo)
            {
                panelStock.FillColor = Color.FromArgb(255, 235, 238);
                lblStockValor.ForeColor = Color.FromArgb(192, 0, 0);
                lblStockTexto.Text = $"⚠️ BAJO (Min: {producto.StockMinimo})";
            }
            else if (producto.Stock >= producto.StockMaximo)
            {
                panelStock.FillColor = Color.FromArgb(200, 230, 255);
                lblStockValor.ForeColor = Color.FromArgb(0, 100, 200);
                lblStockTexto.Text = $"📦 EXCESO (Max: {producto.StockMaximo})";
            }
            else
            {
                panelStock.FillColor = Color.FromArgb(230, 245, 237);
                lblStockValor.ForeColor = Color.FromArgb(0, 100, 0);
                lblStockTexto.Text = "✓ en Stock";
            }
        }

        /// <summary>
        /// Limpia el panel de detalles cuando no hay ninguna selección.
        /// </summary>
        private void LimpiarDetalles()
        {
            gbDetalles.Text = "Detalles del Producto";
            lblDescripcion.Text = "Seleccione un producto para ver sus detalles.";
            txtFechaVencimiento.Text = "";
            lblStockValor.Text = "-";
            lblStockTexto.Text = "en Stock";
            panelStock.FillColor = Color.Gainsboro;
            lblStockValor.ForeColor = Color.Black;
            
            lblCategoria.Text = "...";
            lblLaboratorio.Text = "...";
            lblUbicacion.Text = "...";
            lblCosto.Text = "$0.00";
            lblMargen.Text = "...";
            lblMargen.ForeColor = Color.Black;
            panelVencimiento.Visible = false;
        }

        // --- EVENTOS DE CONTROLES ---

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (_listaProductos == null)
            {
                CargarYFiltrarProductos();
            }
        }

        private void SeleccionarProducto()
        {
            if (dgvProductos.CurrentRow != null && dgvProductos.CurrentRow.DataBoundItem is EProducto prod)
            {
                ProductoSeleccionado = prod;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto de la lista.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // --- EVENTOS DE BOTONES Y GRID ---

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            SeleccionarProducto();
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SeleccionarProducto();
            }
        }

        /// <summary>
        /// Evento clave: Se dispara cada vez que cambia la fila seleccionada.
        /// </summary>
        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDetallesProducto();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}