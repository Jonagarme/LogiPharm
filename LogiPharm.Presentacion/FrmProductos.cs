using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();

            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += BtnCancelar_Click;

            DgvListado.CellDoubleClick += DgvListado_CellDoubleClick;
            DgvListado.CellMouseEnter += DgvListado_CellMouseEnter;
            DgvListado.CellFormatting += DgvListado_CellFormatting;   // <-- importante
            DgvListado.DataError += (s, e) => { e.ThrowException = false; };

            AsignarEventosMenu();

            DgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvListado.MultiSelect = false;
            DgvListado.AllowUserToAddRows = false;
            DgvListado.RowHeadersVisible = false;
            DgvListado.RowTemplate.Height = Math.Max(DgvListado.RowTemplate.Height, 28);
        }



        private void AsignarEventosMenu()
        {
            contextMenuOpciones.Items.Clear();
            contextMenuOpciones.Items.AddRange(new ToolStripItem[] {
                new ToolStripMenuItem("➕ Nueva Categoría",   null, new EventHandler(menuNuevaCategoria_Click)),
                new ToolStripMenuItem("➕ Nueva Subcategoría", null, new EventHandler(menuNuevaSubcategoria_Click)),
                new ToolStripMenuItem("➕ Nuevo Subnivel",     null, new EventHandler(menuNuevoSubnivel_Click)),
                new ToolStripMenuItem("➕ Nueva Marca",        null, new EventHandler(menuNuevaMarca_Click)),
                new ToolStripMenuItem("➕ Nueva Publicidad",   null, new EventHandler(menuNuevaPublicidad_Click)),
                new ToolStripMenuItem("➕ Nuevo Laboratorio",  null, new EventHandler(menuNuevoLaboratorio_Click)),
                new ToolStripSeparator(),
                new ToolStripMenuItem("➕ Nuevo Producto",     null, new EventHandler(menuNuevoProducto_Click))
            });
        }

        private void BtnCancelar_Click(object sender, EventArgs e) => CerrarPanelEdicion();

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = true;
            CerrarPanelEdicion();
            CargarProductos();
        }

        // --- Panel edición ---
        private void AbrirPanelEdicion()
        {
            splitContainer1.Panel2Collapsed = false;
            int panel2Width = 420;
            int minLeft = 400;
            int distancia = Math.Max(minLeft, this.Width - panel2Width);
            splitContainer1.SplitterDistance = Math.Min(distancia, this.Width - panel2Width);
            panelDatos.BringToFront();
        }

        private void CerrarPanelEdicion() => splitContainer1.Panel2Collapsed = true;

        // --- Menús ---
        private void menuNuevoProducto_Click(object sender, EventArgs e) => AbrirPanelEdicion();

        private void menuNuevaCategoria_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmGestionCategoria())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("¡Lista de categorías actualizada!");
                }
            }
        }

        private void menuNuevaSubcategoria_Click(object sender, EventArgs e) => MessageBox.Show("Nueva Subcategoría");
        private void menuNuevoSubnivel_Click(object sender, EventArgs e) => MessageBox.Show("Nuevo Subnivel");
        private void menuNuevaMarca_Click(object sender, EventArgs e) => MessageBox.Show("Nueva Marca");
        private void menuNuevaPublicidad_Click(object sender, EventArgs e) => MessageBox.Show("Nueva Publicidad");
        private void menuNuevoLaboratorio_Click(object sender, EventArgs e) => MessageBox.Show("Nuevo Laboratorio");

        // --- DataGridView: icono mano sobre acciones ---
        private void DgvListado_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 &&
                (DgvListado.Columns["colEditar"] != null && e.ColumnIndex == DgvListado.Columns["colEditar"].Index
              || DgvListado.Columns["colEliminar"] != null && e.ColumnIndex == DgvListado.Columns["colEliminar"].Index))
                DgvListado.Cursor = Cursors.Hand;
            else
                DgvListado.Cursor = Cursors.Default;
        }

        // --- Click en iconos Editar/Eliminar ---
        private void DgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = DgvListado.Columns[e.ColumnIndex].Name;

            if (nombreColumna == "colEditar")
            {
                AbrirFormularioEditarProducto();
            }
            else if (nombreColumna == "colEliminar")
            {
                if (MessageBox.Show("¿Está seguro de que desea eliminar este producto?",
                                    "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        int idProducto = Convert.ToInt32(DgvListado.Rows[e.RowIndex].Cells["ID"].Value);
                        // TODO: eliminar/desactivar en BD
                        // var d = new DProductos();
                        // var ok = d.Eliminar(idProducto);
                        MessageBox.Show($"Producto con ID {idProducto} eliminado (simulación).");
                        CargarProductos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el producto: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // --- Circulito de status ---
        private void DgvListado_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (DgvListado.Columns.Contains("colStatus") &&
                e.ColumnIndex == DgvListado.Columns["colStatus"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                bool esActivo = Convert.ToBoolean(DgvListado.Rows[e.RowIndex].Cells["Activo"].Value);
                Color statusColor = esActivo ? Color.MediumSeaGreen : Color.Crimson;

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

        // --- Colores por stock ---
        private void DgvListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Pone los PNG siempre, sin depender del valor de la celda
            var colName = DgvListado.Columns[e.ColumnIndex].Name;
            if (colName == "colEditar")
            {
                e.Value = Properties.Resources.boligrafo; // tu recurso
                e.FormattingApplied = true;
                return;
            }
            if (colName == "colEliminar")
            {
                e.Value = Properties.Resources.ic_delete; // tu recurso
                e.FormattingApplied = true;
                return;
            }

            // --- lo que ya tenías para colores por stock ---
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


        // --- Botón "Listar/Refrescar" ---
        private async void iconButton4_Click(object sender, EventArgs e)
        {
            FrmLoading loadingForm = new FrmLoading();
            try
            {
                loadingForm.Show(this);
                await Task.Delay(50);

                DProductos d_Productos = new DProductos();
                DataTable dt = await Task.Run(() => d_Productos.ListarProductos());

                DgvListado.DataSource = dt;
                DgvListado.RowHeadersVisible = false;

                if (DgvListado.Columns["ID"] != null)
                    DgvListado.Columns["ID"].Visible = false;

                EnsureActionColumns();

                lblTotal.Text = "Total de Registros: " + DgvListado.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                loadingForm.Close();
            }
        }

        private void DgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var colName = DgvListado.Columns[e.ColumnIndex].Name;
            // Evita doble apertura si el doble clic fue en las columnas de acción
            if (colName == "colEditar" || colName == "colEliminar" || colName == "colStatus")
                return;

            AbrirFormularioEditarProducto();
        }


        private void iconButton2_Click(object sender, EventArgs e) => AbrirFormularioEditarProducto();

        private void AbrirFormularioEditarProducto()
        {
            if (DgvListado.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un producto de la lista para editar.",
                                "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idProductoSeleccionado = Convert.ToInt32(DgvListado.CurrentRow.Cells["ID"].Value);

                using (var frm = new FrmEditarProducto(idProductoSeleccionado))
                {
                    DialogResult resultado = frm.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        CargarProductos();
                        MessageBox.Show("Producto actualizado. Refrescando lista...");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar abrir la ventana de edición: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Guardar nuevo producto ---
        private void btnGuardar_Click(object sender, EventArgs e)
        {
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
                tabProducto.SelectedTab = tabClasificacion; cboTipoProducto.Focus(); return;
            }
            if (cboClaseProducto.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una Clase de Producto.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabProducto.SelectedTab = tabClasificacion; cboClaseProducto.Focus(); return;
            }
            if (cboCategoria.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una Categoría.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabProducto.SelectedTab = tabClasificacion; cboCategoria.Focus(); return;
            }
            if (cboSubcategoria.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una Subcategoría.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabProducto.SelectedTab = tabClasificacion; cboSubcategoria.Focus(); return;
            }
            if (cboMarca.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una Marca.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabProducto.SelectedTab = tabClasificacion; cboMarca.Focus(); return;
            }

            var nuevo = new EProducto();
            try
            {
                nuevo.Nombre = txtNombre.Text.Trim();
                nuevo.CodigoPrincipal = txtCodigoPrincipal.Text.Trim();
                nuevo.CodigoAuxiliar = txtCodigoAuxiliar.Text.Trim();
                nuevo.Descripcion = txtDescripcion.Text.Trim();
                nuevo.Observaciones = txtObservaciones.Text.Trim();
                nuevo.RegistroSanitario = txtRegistroSanitario.Text.Trim();

                nuevo.IdTipoProducto = Convert.ToInt32(cboTipoProducto.SelectedValue);
                nuevo.IdClaseProducto = Convert.ToInt32(cboClaseProducto.SelectedValue);
                nuevo.IdCategoria = Convert.ToInt32(cboCategoria.SelectedValue);
                nuevo.IdSubcategoria = Convert.ToInt32(cboSubcategoria.SelectedValue);
                nuevo.IdMarca = Convert.ToInt32(cboMarca.SelectedValue);

                nuevo.IdSubnivel = cboSubnivel.SelectedValue != null ? (int?)Convert.ToInt32(cboSubnivel.SelectedValue) : null;
                nuevo.IdLaboratorio = cboLaboratorio.SelectedValue != null ? (int?)Convert.ToInt32(cboLaboratorio.SelectedValue) : null;
                nuevo.ClasificacionABC = cboClasificacionABC.SelectedItem?.ToString();

                nuevo.Stock = numStock.Value;
                nuevo.StockMinimo = numStockMinimo.Value;
                nuevo.StockMaximo = numStockMaximo.Value;
                nuevo.PrecioVenta = numPrecioVenta.Value;

                nuevo.EsDivisible = chkEsDivisible.Checked;
                nuevo.EsPsicotropico = chkEsPsicotropico.Checked;
                nuevo.RequiereCadenaFrio = chkRequiereCadenaFrio.Checked;
                nuevo.RequiereSeguimiento = chkRequiereSeguimiento.Checked;
                nuevo.CalculoABCManual = chkCalculoABCManual.Checked;

                nuevo.CreadoPor = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al preparar los datos: " + ex.Message, "Datos inválidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

        // --- Cargar/Buscar listado ---
        private void CargarProductos()
        {
            try
            {
                DProductos d_Productos = new DProductos();
                DgvListado.DataSource = d_Productos.ListarProductos();

                DgvListado.RowHeadersVisible = false;

                if (DgvListado.Columns["Column1"] != null)
                    DgvListado.Columns["Column1"].Visible = false;

                if (DgvListado.Columns["ID"] != null)
                    DgvListado.Columns["ID"].Visible = false;

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
                    DgvListado.Columns["ID"].Visible = false;


                lblTotal.Text = "Total de Registros: " + DgvListado.Rows.Count.ToString();

                if (DgvListado.Rows.Count == 0)
                    MessageBox.Show("No se encontraron productos para el criterio ingresado.", "Búsqueda",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar productos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // --- Columnas de acción con PNG ---
        private void EnsureActionColumns()
        {
            // Columna indicador de estado (pintada en CellPainting)
            if (DgvListado.Columns["colStatus"] == null)
            {
                var colStatus = new DataGridViewTextBoxColumn
                {
                    Name = "colStatus",
                    HeaderText = "",
                    ReadOnly = true,
                    Width = 26,
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    Frozen = true,
                    DataPropertyName = string.Empty // <-- NO enlazada
                };
                DgvListado.Columns.Insert(0, colStatus);
            }

            if (DgvListado.Columns["colEditar"] == null)
            {
                var colEditar = new DataGridViewImageColumn
                {
                    Name = "colEditar",
                    HeaderText = "",
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                    Width = 20,
                    ReadOnly = true,
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    Frozen = true,
                    DataPropertyName = string.Empty, // <-- NO enlazada
                    ValuesAreIcons = false,
                    ValueType = typeof(Image)
                };
                DgvListado.Columns.Insert(1, colEditar);
            }

            if (DgvListado.Columns["colEliminar"] == null)
            {
                var colEliminar = new DataGridViewImageColumn
                {
                    Name = "colEliminar",
                    HeaderText = "",
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                    Width = 20,
                    ReadOnly = true,
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    Frozen = true,
                    DataPropertyName = string.Empty, // <-- NO enlazada
                    ValuesAreIcons = false,
                    ValueType = typeof(Image)
                };
                DgvListado.Columns.Insert(2, colEliminar);
            }

            // Orden asegurado
            DgvListado.Columns["colStatus"].DisplayIndex = 0;
            DgvListado.Columns["colEditar"].DisplayIndex = 1;
            DgvListado.Columns["colEliminar"].DisplayIndex = 2;

            DgvListado.RowTemplate.Height = Math.Max(DgvListado.RowTemplate.Height, 25);
        }


    }
}
