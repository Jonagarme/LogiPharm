using System;
using System.Collections.Generic; // Necesario para List<EProducto>
using System.Data;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmSeleccionarProducto : Form
    {
        // Propiedad pública para devolver el producto que el usuario elija
        public EProducto ProductoSeleccionado { get; private set; }
        private string _terminoBusquedaInicial;

        // NUEVO: Lista local para cuando abres desde una lista de productos (no por texto)
        private List<EProducto> _listaProductos = null;

        // Constructor original por texto
        public FrmSeleccionarProducto(string terminoBusqueda = "")
        {
            InitializeComponent();
            _terminoBusquedaInicial = terminoBusqueda;
        }

        // *** CONSTRUCTOR NUEVO: Recibe una lista de productos ***
        public FrmSeleccionarProducto(List<EProducto> productos)
        {
            InitializeComponent();
            _listaProductos = productos;
        }

        private void FrmSeleccionarProducto_Load(object sender, EventArgs e)
        {
            // Si se recibe una lista, se muestra directamente (no filtra por texto)
            if (_listaProductos != null)
            {
                dgvProductos.DataSource = null; // Limpia primero
                dgvProductos.DataSource = _listaProductos;
                EstilizarGrid();
                //txtBuscar.Enabled = false;
            }
            else
            {
                // Si se pasó un término de búsqueda, lo usamos para filtrar desde el inicio
                txtBuscar.Text = _terminoBusquedaInicial;
                CargarYFiltrarProductos();
                EstilizarGrid();
            }
        }

        private void CargarYFiltrarProductos()
        {
            try
            {
                DProductos d_Productos = new DProductos();
                dgvProductos.DataSource = d_Productos.BuscarProductosActivos(txtBuscar.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EstilizarGrid()
        {
            if (dgvProductos.Columns["id"] != null)
            {
                dgvProductos.Columns["id"].Visible = false;
            }
            if (dgvProductos.Columns["codigoPrincipal"] != null)
            {
                dgvProductos.Columns["codigoPrincipal"].HeaderText = "Código";
                dgvProductos.Columns["codigoPrincipal"].Width = 120;
            }
            if (dgvProductos.Columns["nombre"] != null)
            {
                dgvProductos.Columns["nombre"].HeaderText = "Nombre";
                dgvProductos.Columns["nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (dgvProductos.Columns["stock"] != null)
            {
                dgvProductos.Columns["stock"].HeaderText = "Stock";
                dgvProductos.Columns["stock"].Width = 80;
            }
            if (dgvProductos.Columns["precioVenta"] != null)
            {
                dgvProductos.Columns["precioVenta"].HeaderText = "Precio";
                dgvProductos.Columns["precioVenta"].Width = 90;
                dgvProductos.Columns["precioVenta"].DefaultCellStyle.Format = "N2";
            }
        }



        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (_listaProductos == null) // Solo filtra si no fue abierto con lista
                CargarYFiltrarProductos();
        }

        private void SeleccionarProducto()
        {
            if (dgvProductos.CurrentRow != null)
            {
                // Si el DataSource es una lista de EProducto (caso lista directa)
                if (dgvProductos.CurrentRow.DataBoundItem is EProducto prod)
                {
                    ProductoSeleccionado = prod;
                }
                else
                {
                    // Si el DataSource es un DataTable (caso búsqueda por texto)
                    ProductoSeleccionado = new EProducto
                    {
                        Id = Convert.ToInt64(dgvProductos.CurrentRow.Cells["id"].Value),
                        CodigoPrincipal = dgvProductos.CurrentRow.Cells["codigoPrincipal"].Value.ToString(),
                        Nombre = dgvProductos.CurrentRow.Cells["nombre"].Value.ToString(),
                        Stock = Convert.ToDecimal(dgvProductos.CurrentRow.Cells["stock"].Value),
                        PrecioVenta = Convert.ToDecimal(dgvProductos.CurrentRow.Cells["precioVenta"].Value)
                    };
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto de la lista.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

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
