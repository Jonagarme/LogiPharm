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

            this.btnGuardar.Click += btnGuardar_Click;
            this.DgvListado.CellDoubleClick += DgvListado_CellDoubleClick;
            AsignarEventosMenu();
            this.btnCancelar.Click += BtnCancelar_Click;
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

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            CerrarPanelEdicion();
        }


        private void FrmProductos_Load(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = true;
            CerrarPanelEdicion();
            CargarProductos();
        }


        // --- MÉTODOS PARA CONTROLAR EL PANEL DE EDICIÓN ---

        private void AbrirPanelEdicion()
        {
            splitContainer1.Panel2Collapsed = false;
            // deja ~400 px a la derecha
            int panel2Width = 420;
            int minLeft = 400; // para que el listado no quede mínimo
            int distancia = Math.Max(minLeft, this.Width - panel2Width);
            splitContainer1.SplitterDistance = Math.Min(distancia, this.Width - panel2Width);
            panelDatos.BringToFront();
        }


        private void CerrarPanelEdicion()
        {
            // Oculta el panel de detalles.
            splitContainer1.Panel2Collapsed = true;
        }

        // --- EVENTOS DE LOS MENÚS Y BOTONES ---

        //private void iconButtonOpciones_Click(object sender, EventArgs e)
        //{
        //    // Muestra el menú contextual debajo del botón de opciones.
        //    contextMenuOpciones.Show(iconButtonOpciones, new Point(0, iconButtonOpciones.Height));
        //}

        private void menuNuevoProducto_Click(object sender, EventArgs e)
        {
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
            if (e.RowIndex < 0) return; // Ignorar clics en el encabezado

            string nombreColumna = DgvListado.Columns[e.ColumnIndex].Name;

            if (nombreColumna == "colEditar")
            {
                // Llama a tu método existente para editar
                AbrirFormularioEditarProducto();
            }
            else if (nombreColumna == "colEliminar")
            {
                // Lógica para eliminar el producto
                if (MessageBox.Show("¿Está seguro de que desea eliminar este producto?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        int idProducto = Convert.ToInt32(DgvListado.Rows[e.RowIndex].Cells["ID"].Value);
                        // TODO: Llama a tu método de la capa de datos para eliminar/desactivar el producto
                        // DProductos d_prod = new DProductos();
                        // bool exito = d_prod.Eliminar(idProducto);
                        // if(exito) { CargarProductos(); }

                        MessageBox.Show($"Producto con ID {idProducto} eliminado (simulación).");
                        CargarProductos(); // Recarga la lista para ver el cambio
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // En el constructor FrmProductos() o en el evento FrmProductos_Load,
        // añade esta línea para suscribirte al evento:
        // this.DgvListado.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DgvListado_CellPainting);
        // (Ya lo hice por ti en el designer, así que no es necesario añadirla manualmente)

        private void DgvListado_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Solo actuamos en la columna 'colStatus' y no en el encabezado
            if (e.ColumnIndex == DgvListado.Columns["colStatus"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // Obtenemos el valor de la columna 'Activo' para esta fila
                // Asegúrate de que tu consulta SQL devuelva una columna llamada 'Activo' de tipo bool/bit
                bool esActivo = Convert.ToBoolean(DgvListado.Rows[e.RowIndex].Cells["Activo"].Value);

                // Elige el color del círculo
                Color statusColor = esActivo ? Color.MediumSeaGreen : Color.Crimson;

                // Dibuja el círculo en el centro de la celda
                int circleSize = 12;
                int x = e.CellBounds.Left + (e.CellBounds.Width - circleSize) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - circleSize) / 2;

                using (SolidBrush brush = new SolidBrush(statusColor))
                {
                    e.Graphics.FillEllipse(brush, new Rectangle(x, y, circleSize, circleSize));
                }

                e.Handled = true;
            }
        }

        // Añade esta línea en el constructor o en el Load si no lo hiciste en el designer:
        // this.DgvListado.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvListado_CellFormatting);
        // (Ya lo hice por ti en el designer)

        private void DgvListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (DgvListado.Columns.Contains("Stock") && DgvListado.Columns.Contains("StockMinimo"))
            {
                var stockObj = DgvListado.Rows[e.RowIndex].Cells["Stock"].Value;
                var miniObj = DgvListado.Rows[e.RowIndex].Cells["StockMinimo"].Value;

                if (stockObj != null && miniObj != null &&
                    decimal.TryParse(stockObj.ToString(), out var stock) &&
                    decimal.TryParse(miniObj.ToString(), out var stockMinimo))
                {
                    if (stock == 0)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(255, 235, 238);
                        e.CellStyle.SelectionBackColor = Color.FromArgb(255, 190, 200);
                    }
                    else if (stock <= stockMinimo)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(255, 250, 230);
                        e.CellStyle.SelectionBackColor = Color.FromArgb(255, 230, 180);
                    }
                }
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // --- VALIDACIONES ---
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del producto es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabProducto.SelectedTab = tabPrincipal;
                txtNombre.Focus();
                return;
            }
            if (cboTipoProducto.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un Tipo de Producto.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabProducto.SelectedTab = tabClasificacion;
                cboTipoProducto.Focus();
                return;
            }
            if (cboClaseProducto.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una Clase de Producto.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabProducto.SelectedTab = tabClasificacion;
                cboClaseProducto.Focus();
                return;
            }
            if (cboCategoria.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una Categoría.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabProducto.SelectedTab = tabClasificacion;
                cboCategoria.Focus();
                return;
            }
            if (cboSubcategoria.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una Subcategoría.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabProducto.SelectedTab = tabClasificacion;
                cboSubcategoria.Focus();
                return;
            }
            if (cboMarca.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una Marca.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabProducto.SelectedTab = tabClasificacion;
                cboMarca.Focus();
                return;
            }

            // --- ARMAR ENTIDAD ---
            var nuevo = new EProducto();
            try
            {
                // Principal
                nuevo.Nombre = txtNombre.Text.Trim();
                nuevo.CodigoPrincipal = txtCodigoPrincipal.Text.Trim();
                nuevo.CodigoAuxiliar = txtCodigoAuxiliar.Text.Trim();
                nuevo.Descripcion = txtDescripcion.Text.Trim();
                nuevo.Observaciones = txtObservaciones.Text.Trim();
                nuevo.RegistroSanitario = txtRegistroSanitario.Text.Trim();

                // Clasificación (obligatorios ya validados)
                nuevo.IdTipoProducto = Convert.ToInt32(cboTipoProducto.SelectedValue);
                nuevo.IdClaseProducto = Convert.ToInt32(cboClaseProducto.SelectedValue);
                nuevo.IdCategoria = Convert.ToInt32(cboCategoria.SelectedValue);
                nuevo.IdSubcategoria = Convert.ToInt32(cboSubcategoria.SelectedValue);
                nuevo.IdMarca = Convert.ToInt32(cboMarca.SelectedValue);

                // Opcionales
                nuevo.IdSubnivel = cboSubnivel.SelectedValue != null ? (int?)Convert.ToInt32(cboSubnivel.SelectedValue) : null;
                nuevo.IdLaboratorio = cboLaboratorio.SelectedValue != null ? (int?)Convert.ToInt32(cboLaboratorio.SelectedValue) : null;
                nuevo.ClasificacionABC = cboClasificacionABC.SelectedItem?.ToString();

                // Inventario / Precios
                nuevo.Stock = numStock.Value;
                nuevo.StockMinimo = numStockMinimo.Value;
                nuevo.StockMaximo = numStockMaximo.Value;
                nuevo.PrecioVenta = numPrecioVenta.Value;

                // Atributos
                nuevo.EsDivisible = chkEsDivisible.Checked;
                nuevo.EsPsicotropico = chkEsPsicotropico.Checked;
                nuevo.RequiereCadenaFrio = chkRequiereCadenaFrio.Checked;
                nuevo.RequiereSeguimiento = chkRequiereSeguimiento.Checked;
                nuevo.CalculoABCManual = chkCalculoABCManual.Checked;

                // Auditoría (ajusta según tu sesión/usuario actual)
                nuevo.CreadoPor = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al preparar los datos: " + ex.Message, "Datos inválidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- PERSISTENCIA ---
            try
            {
                var d = new DProductos();
                bool ok = d.InsertarProducto(nuevo);

                if (ok)
                {
                    MessageBox.Show("¡Producto guardado exitosamente!", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CerrarPanelEdicion();
                    CargarProductos();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el producto.", "Fallo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en base de datos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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