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
        }

        // Constructor para lista predefinida
        public FrmSeleccionarProducto(List<EProducto> productos)
        {
            InitializeComponent();
            _listaProductos = productos;
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
                txtFechaVencimiento.Text = producto.FechaVencimiento.ToString("dd/MM/yyyy");
                lblStockValor.Text = producto.Stock.ToString("N2"); // Formato con 2 decimales

                // Lógica de colores para el stock
                if (producto.Stock <= producto.StockMinimo)
                {
                    panelStock.FillColor = Color.FromArgb(255, 235, 238); // Rojo claro
                    lblStockValor.ForeColor = Color.FromArgb(192, 0, 0);   // Rojo oscuro
                }
                else
                {
                    panelStock.FillColor = Color.FromArgb(230, 245, 237); // Verde claro
                    lblStockValor.ForeColor = Color.FromArgb(0, 100, 0);   // Verde oscuro
                }
            }
            else
            {
                LimpiarDetalles();
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
            panelStock.FillColor = Color.Gainsboro;
            lblStockValor.ForeColor = Color.Black;
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