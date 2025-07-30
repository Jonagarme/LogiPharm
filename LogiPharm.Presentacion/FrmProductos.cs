using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades; // Asegúrate de que esta referencia sea correcta

namespace LogiPharm.Presentacion
{
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();

            // Asignar los métodos a los eventos del menú dinámicamente
            // Esto es necesario porque el designer que te pasé no lo hace automáticamente.
            AsignarEventosMenu();
        }

        private void AsignarEventosMenu()
        {
            // Creamos los items del menú y les asignamos su respectivo evento Click
            contextMenuOpciones.Items.Clear(); // Limpiamos por si acaso
            contextMenuOpciones.Items.AddRange(new ToolStripItem[] {
                new ToolStripMenuItem("➕ Nueva Categoría", null, new EventHandler(menuNuevaCategoria_Click)),
                new ToolStripMenuItem("➕ Nueva Subcategoría", null, new EventHandler(menuNuevaSubcategoria_Click)),
                new ToolStripMenuItem("➕ Nuevo Subnivel", null, new EventHandler(menuNuevoSubnivel_Click)),
                new ToolStripMenuItem("➕ Nueva Marca", null, new EventHandler(menuNuevaMarca_Click)),
                new ToolStripMenuItem("➕ Nueva Publicidad", null, new EventHandler(menuNuevaPublicidad_Click)),
                new ToolStripMenuItem("➕ Nuevo Laboratorio", null, new EventHandler(menuNuevoLaboratorio_Click)),
                new ToolStripSeparator(), // Una línea separadora
                new ToolStripMenuItem("➕ Nuevo Producto", null, new EventHandler(menuNuevoProducto_Click))
            });
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            // Al cargar el formulario, ocultamos el panel de detalles.
            CerrarPanelEdicion();
            // Aquí también deberías cargar la lista inicial de productos en DgvListado.

            CargarProductos();
        }

        // --- MÉTODOS PARA CONTROLAR EL PANEL DE EDICIÓN ---

        private void AbrirPanelEdicion()
        {
            // Muestra el panel de detalles (el de la derecha).
            splitContainer1.Panel2Collapsed = false;
        }

        private void CerrarPanelEdicion()
        {
            // Oculta el panel de detalles.
            splitContainer1.Panel2Collapsed = true;
        }

        // --- EVENTOS DE LOS MENÚS Y BOTONES ---

        private void iconButtonOpciones_Click(object sender, EventArgs e)
        {
            // Muestra el menú contextual debajo del botón de opciones.
            contextMenuOpciones.Show(iconButtonOpciones, new Point(0, iconButtonOpciones.Height));
        }

        private void menuNuevoProducto_Click(object sender, EventArgs e)
        {
            // TODO: Limpiar los controles del panel de datos antes de mostrarlo
            // ej: txtID.Clear(); txtNombre.Clear(); cboCategoria.SelectedIndex = -1;

            // Abre el panel para ingresar los datos de un nuevo producto.
            AbrirPanelEdicion();
        }

        private void menuNuevaCategoria_Click(object sender, EventArgs e)
        {
            // Abre el formulario modal para gestionar categorías.
            using (var frm = new FrmGestionCategoria())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // TODO: Llama a un método que recargue los ComboBox de categorías.
                    // CargarCategorias(); 
                    MessageBox.Show("¡Lista de categorías actualizada!");
                }
            }
        }

        // --- MÉTODOS PENDIENTES (PARA TUS PRÓXIMAS TAREAS) ---

        private void menuNuevaSubcategoria_Click(object sender, EventArgs e)
        {
            // TODO: Crear FrmGestionSubcategoria y llamarlo aquí de forma modal.
            MessageBox.Show("Nueva Subcategoría");
        }

        private void menuNuevoSubnivel_Click(object sender, EventArgs e)
        {
            // TODO: Crear FrmGestionSubnivel y llamarlo aquí de forma modal.
            MessageBox.Show("Nuevo Subnivel");
        }

        private void menuNuevaMarca_Click(object sender, EventArgs e)
        {
            // TODO: Crear FrmGestionMarca y llamarlo aquí de forma modal.
            MessageBox.Show("Nueva Marca");
        }

        private void menuNuevaPublicidad_Click(object sender, EventArgs e)
        {
            // TODO: Crear FrmGestionPublicidad y llamarlo aquí de forma modal.
            MessageBox.Show("Nueva Publicidad");
        }

        private void menuNuevoLaboratorio_Click(object sender, EventArgs e)
        {
            // TODO: Crear FrmGestionLaboratorio y llamarlo aquí de forma modal.
            MessageBox.Show("Nuevo Laboratorio");
        }

        // --- EVENTO PARA EL DATAGRIDVIEW ---

        private void DgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegúrate de que el clic no fue en el encabezado de la columna.
            if (e.RowIndex < 0) return;

            // TODO: Reemplaza "btnEditar" con el nombre real de tu columna de botón de edición.
            if (this.DgvListado.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                // 1. Obtén los datos de la fila seleccionada.
                // string idProducto = DgvListado.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                // string nombre = DgvListado.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();

                // 2. Carga esos datos en los controles de panelDatos.
                // txtID.Text = idProducto;
                // ... etc ...

                // 3. Muestra el panel de edición con los datos cargados.
                AbrirPanelEdicion();
            }
        }

        private async void iconButton4_Click(object sender, EventArgs e)
        {
            FrmLoading loadingForm = new FrmLoading();
            try
            {
                loadingForm.Show(this); // Muestra el formulario de carga

                // Espera un momento para que el formulario de carga se muestre bien
                await Task.Delay(50);

                DProductos d_Productos = new DProductos();
                DataTable dt = await Task.Run(() => d_Productos.ListarProductos()); // Ejecuta la consulta en otro hilo

                // Actualiza la interfaz de usuario en el hilo principal
                DgvListado.DataSource = dt;
                DgvListado.RowHeadersVisible = false;

                if (DgvListado.Columns["ID"] != null)
                {
                    DgvListado.Columns["ID"].Visible = false;
                }

                lblTotal.Text = "Total de Registros: " + DgvListado.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                loadingForm.Close(); // Cierra el formulario de carga al finalizar
            }
        }

        private void DgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Solo si la fila es válida
            if (e.RowIndex >= 0)
            {
                AbrirFormularioEditarProducto();
            }
        }


        private void iconButton2_Click(object sender, EventArgs e)
        {
            AbrirFormularioEditarProducto();
        }

        private void AbrirFormularioEditarProducto()
        {
            // 1. Verificar si hay una fila seleccionada
            if (DgvListado.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un producto de la lista para editar.",
                                "Selección requerida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Obtener el ID del producto de la fila seleccionada
                int idProductoSeleccionado = Convert.ToInt32(DgvListado.CurrentRow.Cells["ID"].Value);

                // 3. Abrir el formulario de edición, pasándole el ID
                using (var frm = new FrmEditarProducto(idProductoSeleccionado))
                {
                    DialogResult resultado = frm.ShowDialog();

                    // 4. Si el usuario guardó cambios, refrescar la lista
                    if (resultado == DialogResult.OK)
                    {
                        CargarProductos(); // O el método que refresque tu grid
                        MessageBox.Show("Producto actualizado. Refrescando lista...");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar abrir la ventana de edición: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        // Creamos un nuevo método para cargar y mostrar los productos
        private void CargarProductos()
        {
            try
            {
                DProductos d_Productos = new DProductos();

                // Asignamos los datos al DataGridView que se llama 'DgvListado'
                DgvListado.DataSource = d_Productos.ListarProductos();

                // --- AQUÍ ESTÁN LOS CAMBIOS ---

                // 1. Ocultar la primera columna gris (encabezados de fila)
                DgvListado.RowHeadersVisible = false;

                if (DgvListado.Columns["Column1"] != null)
                {
                    DgvListado.Columns["Column1"].Visible = false;
                }

                // 2. Opcional: Ocultamos la columna ID que no necesita ver el usuario
                if (DgvListado.Columns["ID"] != null)
                {
                    DgvListado.Columns["ID"].Visible = false;
                }

                // 3. Actualizar el Label con el total de registros
                // Tu label se llama 'lblTotal' según tu designer.
                lblTotal.Text = "Total de Registros: " + DgvListado.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string criterio = txtBuscar.Text.Trim();

            if (string.IsNullOrWhiteSpace(criterio))
            {
                // Si el campo está vacío, vuelve a cargar todos los productos.
                CargarProductos();
                return;
            }

            try
            {
                DProductos d_Productos = new DProductos();
                DataTable dt = d_Productos.BuscarProductos(criterio);

                DgvListado.DataSource = dt;
                DgvListado.RowHeadersVisible = false;

                if (DgvListado.Columns["ID"] != null)
                {
                    DgvListado.Columns["ID"].Visible = false;
                }

                lblTotal.Text = "Total de Registros: " + DgvListado.Rows.Count.ToString();

                if (DgvListado.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron productos para el criterio ingresado.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }


    }
}