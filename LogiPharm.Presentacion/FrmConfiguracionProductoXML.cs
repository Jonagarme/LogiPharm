using System;
using System.Windows.Forms;
using System.Linq;
using LogiPharm.Entidades;
using LogiPharm.Datos;

namespace LogiPharm.Presentacion
{
    public partial class FrmConfiguracionProductoXML : Form
    {
        private EDetalleFacturaXML _detalleProducto;
        private EProducto _productoExistente;
        private bool _mostrarSimilares;

        public EDetalleFacturaXML DetalleProducto => _detalleProducto;

        public FrmConfiguracionProductoXML(EDetalleFacturaXML detalleProducto, bool mostrarSimilares = false)
        {
            InitializeComponent();
            _detalleProducto = detalleProducto;
            _mostrarSimilares = mostrarSimilares;
            this.Load += FrmConfiguracionProductoXML_Load;
            
            // Habilitar cierre con tecla ESC
            this.KeyPreview = true;
            this.KeyDown += FrmConfiguracionProductoXML_KeyDown;
        }

        private void FrmConfiguracionProductoXML_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void FrmConfiguracionProductoXML_Load(object sender, EventArgs e)
        {
            CargarDatosProducto();
            
            if (_mostrarSimilares && _detalleProducto.TieneSimilares)
            {
                MostrarPanelSimilares();
            }
        }

        private void CargarDatosProducto()
        {
            if (_detalleProducto == null) return;

            // Título del panel
            lblTitulo.Text = _detalleProducto.EsProductoNuevo ? "NUEVO PRODUCTO" : "ACTUALIZAR PRODUCTO";
            
            // Información básica
            txtCodigoPrincipal.Text = _detalleProducto.CodigoPrincipal;
            txtDescripcion.Text = _detalleProducto.Descripcion;

            // Precios desde el XML
            numCostoPorUnidad.Value = _detalleProducto.PrecioUnitario;
            numCostoPorCaja.Value = 0; // Se calculará si ingresa unidades por caja

            // Si el producto existe, cargar sus datos actuales
            if (!_detalleProducto.EsProductoNuevo && _detalleProducto.IdProductoEncontrado.HasValue && _detalleProducto.IdProductoEncontrado.Value > 0)
            {
                CargarDatosProductoExistente(_detalleProducto.IdProductoEncontrado.Value);
            }
            else
            {
                // Valores por defecto para producto nuevo
                numPVPUnidad.Value = _detalleProducto.PrecioUnitario * 1.30m; // 30% margen sugerido
                chkEsFraccionable.Checked = false;
                numDivision.Value = 1;
            }

            // Cálculo inicial
            CalcularPrecios();
        }

        private void CargarDatosProductoExistente(int idProducto)
        {
            try
            {
                var dProductos = new DProductos();
                _productoExistente = dProductos.ObtenerPorId(idProducto);

                if (_productoExistente != null)
                {
                    lblProductoEncontrado.Text = $"Producto encontrado en sistema: {_productoExistente.Nombre}";
                    lblProductoEncontrado.ForeColor = System.Drawing.Color.Green;
                    lblProductoEncontrado.Visible = true;

                    numPVPUnidad.Value = _productoExistente.PrecioVenta;
                    chkEsFraccionable.Checked = _productoExistente.EsDivisible;
                    numDivision.Value = 1; // No tenemos este dato en el modelo actual
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar producto existente: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularPrecios()
        {
            try
            {
                decimal costoPorUnidad = numCostoPorUnidad.Value;
                decimal pvpUnidad = numPVPUnidad.Value;

                // Calcular ganancia unitaria
                decimal gananciaUnitaria = pvpUnidad - costoPorUnidad;
                lblGanancia.Text = gananciaUnitaria.ToString("C2");

                // Calcular margen porcentual
                if (costoPorUnidad > 0)
                {
                    decimal margen = ((pvpUnidad - costoPorUnidad) / costoPorUnidad) * 100;
                    lblMargen.Text = margen.ToString("N2") + "%";
                    lblMargen.ForeColor = margen >= 30 ? System.Drawing.Color.Green : System.Drawing.Color.Orange;
                }
                else
                {
                    lblMargen.Text = "N/A";
                }

                // Calcular valor de inventario (ejemplo con cantidad del XML)
                decimal valorInventario = costoPorUnidad * _detalleProducto.Cantidad;
                lblValorInventario.Text = valorInventario.ToString("C2");
            }
            catch { }
        }

        private void numCostoPorUnidad_ValueChanged(object sender, EventArgs e)
        {
            CalcularPrecios();
        }

        private void numPVPUnidad_ValueChanged(object sender, EventArgs e)
        {
            CalcularPrecios();
        }

        private void chkEsFraccionable_CheckedChanged(object sender, EventArgs e)
        {
            // Habilitar/deshabilitar sección de fraccionamiento
            panelFraccionamiento.Enabled = chkEsFraccionable.Checked;
            
            if (!chkEsFraccionable.Checked)
            {
                numDivision.Value = 1;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }

            try
            {
                // Actualizar el objeto con los datos ingresados
                _detalleProducto.PrecioUnitario = numCostoPorUnidad.Value;
                
                // Aquí podrías guardar directamente o retornar el objeto modificado
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar configuración: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarDatos()
        {
            if (numCostoPorUnidad.Value <= 0)
            {
                MessageBox.Show("El costo por unidad debe ser mayor a 0.", 
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numCostoPorUnidad.Focus();
                return false;
            }

            if (numPVPUnidad.Value <= 0)
            {
                MessageBox.Show("El precio de venta debe ser mayor a 0.", 
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPVPUnidad.Focus();
                return false;
            }

            if (numPVPUnidad.Value < numCostoPorUnidad.Value)
            {
                var result = MessageBox.Show(
                    "El precio de venta es menor al costo. ¿Desea continuar de todas formas?", 
                    "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
                if (result == DialogResult.No)
                {
                    numPVPUnidad.Focus();
                    return false;
                }
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Muestra un panel con productos similares detectados para que el usuario seleccione uno
        /// </summary>
        private void MostrarPanelSimilares()
        {
            // Ajustar tamaño del formulario
            this.Width = 900;
            this.Height = 750;

            // Crear panel de advertencia
            var panelAdvertencia = new Guna.UI2.WinForms.Guna2Panel
            {
                Location = new System.Drawing.Point(20, 70),
                Size = new System.Drawing.Size(840, 100),
                BorderRadius = 8,
                FillColor = System.Drawing.Color.FromArgb(255, 243, 205), // Amarillo claro
                BorderColor = System.Drawing.Color.FromArgb(255, 193, 7),
                BorderThickness = 2
            };

            // Ícono de advertencia
            var lblIcono = new System.Windows.Forms.Label
            {
                Text = "!",
                Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(255, 140, 0),
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(60, 60),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                BackColor = System.Drawing.Color.Transparent
            };

            var lblTitulo = new System.Windows.Forms.Label
            {
                Text = "Producto Similar Detectado",
                Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(184, 84, 0),
                Location = new System.Drawing.Point(90, 20),
                Size = new System.Drawing.Size(400, 30)
            };

            var lblMensaje = new System.Windows.Forms.Label
            {
                Text = "Se encontro un producto similar en tu inventario. Por favor, selecciona que accion deseas realizar.",
                Font = new System.Drawing.Font("Segoe UI", 10F),
                ForeColor = System.Drawing.Color.FromArgb(108, 117, 125),
                Location = new System.Drawing.Point(90, 50),
                Size = new System.Drawing.Size(730, 40)
            };

            panelAdvertencia.Controls.Add(lblIcono);
            panelAdvertencia.Controls.Add(lblTitulo);
            panelAdvertencia.Controls.Add(lblMensaje);

            // Panel con productos similares
            var groupSimilares = new Guna.UI2.WinForms.Guna2GroupBox
            {
                Text = "Productos Similares en Inventario",
                Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold),
                CustomBorderColor = System.Drawing.Color.FromArgb(52, 152, 219),
                ForeColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(20, 185),
                Size = new System.Drawing.Size(840, 420),
                BorderRadius = 8
            };

            // Campo de búsqueda/filtro
            var lblBuscar = new System.Windows.Forms.Label
            {
                Text = "Buscar por Codigo o Nombre",
                Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.Black,
                Location = new System.Drawing.Point(15, 50),
                Size = new System.Drawing.Size(250, 20)
            };

            var txtBuscar = new Guna.UI2.WinForms.Guna2TextBox
            {
                PlaceholderText = "Escanea codigo de barras o busca por nombre...",
                BorderRadius = 6,
                Location = new System.Drawing.Point(15, 75),
                Size = new System.Drawing.Size(480, 36),
                Font = new System.Drawing.Font("Segoe UI", 10F)
            };

            // Botón para limpiar búsqueda
            var btnLimpiar = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "X",
                BorderRadius = 6,
                FillColor = System.Drawing.Color.FromArgb(192, 57, 43),
                Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(505, 75),
                Size = new System.Drawing.Size(45, 36)
            };

            btnLimpiar.Click += (s, e) =>
            {
                txtBuscar.Clear();
                txtBuscar.Focus();
            };

            // Label para mostrar resultados
            var lblResultados = new System.Windows.Forms.Label
            {
                Text = $"Mostrando {_detalleProducto.ProductosSimilares.Count} producto(s) similar(es)",
                Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic),
                ForeColor = System.Drawing.Color.Gray,
                Location = new System.Drawing.Point(15, 120),
                Size = new System.Drawing.Size(400, 20)
            };

            // Lista de productos similares con DataGridView
            var dgvSimilares = new Guna.UI2.WinForms.Guna2DataGridView
            {
                Location = new System.Drawing.Point(15, 145),
                Size = new System.Drawing.Size(810, 200),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoGenerateColumns = false,
                BorderStyle = BorderStyle.None,
                BackgroundColor = System.Drawing.Color.White,
                RowHeadersVisible = false,
                ColumnHeadersHeight = 40,
                RowTemplate = { Height = 35 },
                EnableHeadersVisualStyles = false
            };

            // Estilo de encabezados
            dgvSimilares.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(52, 152, 219),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = System.Drawing.Color.FromArgb(52, 152, 219),
                SelectionForeColor = System.Drawing.Color.White
            };

            // Estilo de filas
            dgvSimilares.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.White,
                ForeColor = System.Drawing.Color.Black,
                Font = new System.Drawing.Font("Segoe UI", 9F),
                SelectionBackColor = System.Drawing.Color.FromArgb(41, 128, 185),
                SelectionForeColor = System.Drawing.Color.White,
                Padding = new Padding(5, 3, 5, 3)
            };

            // Alternar colores de filas
            dgvSimilares.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(245, 245, 245),
                ForeColor = System.Drawing.Color.Black,
                Font = new System.Drawing.Font("Segoe UI", 9F),
                SelectionBackColor = System.Drawing.Color.FromArgb(41, 128, 185),
                SelectionForeColor = System.Drawing.Color.White,
                Padding = new Padding(5, 3, 5, 3)
            };

            // Configurar columnas del DataGridView
            var colCodigo = new DataGridViewTextBoxColumn
            {
                Name = "colCodigo",
                HeaderText = "Codigo",
                DataPropertyName = "CodigoPrincipal",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle 
                { 
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    Font = new System.Drawing.Font("Consolas", 9F)
                }
            };
            dgvSimilares.Columns.Add(colCodigo);

            var colNombre = new DataGridViewTextBoxColumn
            {
                Name = "colNombre",
                HeaderText = "Nombre del Producto",
                DataPropertyName = "Nombre",
                Width = 350,
                DefaultCellStyle = new DataGridViewCellStyle 
                { 
                    Alignment = DataGridViewContentAlignment.MiddleLeft 
                }
            };
            dgvSimilares.Columns.Add(colNombre);

            var colStock = new DataGridViewTextBoxColumn
            {
                Name = "colStock",
                HeaderText = "Stock",
                DataPropertyName = "Stock",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle 
                { 
                    Format = "N0", 
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold)
                }
            };
            dgvSimilares.Columns.Add(colStock);

            var colPrecio = new DataGridViewTextBoxColumn
            {
                Name = "colPrecio",
                HeaderText = "Precio",
                DataPropertyName = "PrecioVenta",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle 
                { 
                    Format = "C2", 
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Font = new System.Drawing.Font("Segoe UI", 9F)
                }
            };
            dgvSimilares.Columns.Add(colPrecio);

            var colSimilitud = new DataGridViewTextBoxColumn
            {
                Name = "colSimilitud",
                HeaderText = "Similitud",
                DataPropertyName = "PorcentajeSimilitud",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle 
                { 
                    Format = "0.0'%'", 
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold)
                }
            };
            dgvSimilares.Columns.Add(colSimilitud);

            // Cargar datos iniciales
            dgvSimilares.DataSource = new BindingSource(_detalleProducto.ProductosSimilares, null);

            // Estilo para las filas
            dgvSimilares.CellFormatting += (s, e) =>
            {
                if (dgvSimilares.Columns[e.ColumnIndex].Name == "colSimilitud" && e.Value != null)
                {
                    double similitud = Convert.ToDouble(e.Value);
                    if (similitud >= 70)
                        e.CellStyle.BackColor = System.Drawing.Color.FromArgb(200, 255, 200); // Verde claro
                    else if (similitud >= 50)
                        e.CellStyle.BackColor = System.Drawing.Color.FromArgb(255, 250, 200); // Amarillo claro
                    else
                        e.CellStyle.BackColor = System.Drawing.Color.FromArgb(255, 230, 230); // Rojo claro
                }
            };

            // Evento de búsqueda/filtro en tiempo real
            txtBuscar.TextChanged += (s, e) =>
            {
                string filtro = txtBuscar.Text.Trim().ToUpper();
                
                if (string.IsNullOrEmpty(filtro))
                {
                    // Mostrar todos
                    dgvSimilares.DataSource = new BindingSource(_detalleProducto.ProductosSimilares, null);
                    lblResultados.Text = $"Mostrando {_detalleProducto.ProductosSimilares.Count} producto(s) similar(es)";
                }
                else
                {
                    // Filtrar por código o nombre
                    var filtrados = _detalleProducto.ProductosSimilares
                        .Where(p => p.CodigoPrincipal.ToUpper().Contains(filtro) || 
                                   p.Nombre.ToUpper().Contains(filtro))
                        .ToList();
                    
                    dgvSimilares.DataSource = new BindingSource(filtrados, null);
                    lblResultados.Text = $"Mostrando {filtrados.Count} de {_detalleProducto.ProductosSimilares.Count} producto(s)";
                    
                    // Si solo hay un resultado, seleccionarlo automáticamente
                    if (filtrados.Count == 1 && dgvSimilares.Rows.Count > 0)
                    {
                        dgvSimilares.Rows[0].Selected = true;
                    }
                }
            };

            // Evento Enter para búsqueda rápida
            txtBuscar.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    
                    // Si hay solo un resultado seleccionado, vincularlo
                    if (dgvSimilares.SelectedRows.Count == 1)
                    {
                        VincularProductoSeleccionado(dgvSimilares);
                    }
                }
            };

            // Botón para crear como nuevo producto
            var btnNuevo = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "CREAR COMO NUEVO PRODUCTO",
                FillColor = System.Drawing.Color.FromArgb(39, 174, 96),
                Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.White,
                BorderRadius = 6,
                Location = new System.Drawing.Point(15, 360),
                Size = new System.Drawing.Size(260, 42)
            };

            btnNuevo.Click += (s, e) =>
            {
                var result = MessageBox.Show(
                    "Estas seguro de crear este producto como NUEVO en el inventario?",
                    "Confirmar Nuevo Producto",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _detalleProducto.EsProductoNuevo = true;
                    _detalleProducto.IdProductoEncontrado = null;
                    _detalleProducto.NombreProductoEncontrado = null;
                    _detalleProducto.ProductosSimilares.Clear();
                    
                    groupSimilares.Visible = false;
                    panelAdvertencia.Visible = false;
                    MostrarConfiguracionNormal();
                    
                    MessageBox.Show("Este producto se creara como NUEVO en el inventario.",
                        "Nuevo Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            // Botón para confirmar selección
            var btnConfirmar = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "VINCULAR PRODUCTO SELECCIONADO",
                FillColor = System.Drawing.Color.FromArgb(52, 152, 219),
                Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.White,
                BorderRadius = 6,
                Location = new System.Drawing.Point(290, 360),
                Size = new System.Drawing.Size(300, 42)
            };

            btnConfirmar.Click += (s, e) => VincularProductoSeleccionado(dgvSimilares);

            // Doble clic en el grid también vincula
            dgvSimilares.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    VincularProductoSeleccionado(dgvSimilares);
                }
            };

            // Agregar controles al grupo
            groupSimilares.Controls.Add(lblBuscar);
            groupSimilares.Controls.Add(txtBuscar);
            groupSimilares.Controls.Add(btnLimpiar);
            groupSimilares.Controls.Add(lblResultados);
            groupSimilares.Controls.Add(dgvSimilares);
            groupSimilares.Controls.Add(btnNuevo);
            groupSimilares.Controls.Add(btnConfirmar);

            // Añadir al formulario
            panelPrincipal.Controls.Add(panelAdvertencia);
            panelPrincipal.Controls.Add(groupSimilares);

            // Ocultar otros paneles hasta que se seleccione
            groupInfo.Visible = false;
            groupPrecios.Visible = false;
            panelFraccionamiento.Visible = false;
            groupResumen.Visible = false;
            btnGuardar.Visible = false;
            btnCancelar.Location = new System.Drawing.Point(panelPrincipal.Width - 140, 620);

            // Dar foco al campo de búsqueda
            txtBuscar.Focus();
        }

        private void VincularProductoSeleccionado(Guna.UI2.WinForms.Guna2DataGridView dgvSimilares)
        {
            if (dgvSimilares.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un producto de la lista.",
                    "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var productoSeleccionado = dgvSimilares.SelectedRows[0].DataBoundItem as ProductoSimilarDetectado;
            if (productoSeleccionado != null)
            {
                _detalleProducto.EsProductoNuevo = false;
                _detalleProducto.IdProductoEncontrado = (int)productoSeleccionado.Id;
                _detalleProducto.NombreProductoEncontrado = productoSeleccionado.Nombre;
                
                // Limpiar lista de similares
                _detalleProducto.ProductosSimilares.Clear();
                
                // Cargar datos del producto existente
                CargarDatosProductoExistente((int)productoSeleccionado.Id);
                
                // Mostrar configuración normal
                MostrarConfiguracionNormal();
                
                MessageBox.Show($"Producto vinculado con:\n{productoSeleccionado.Nombre}\n\nAhora puedes ajustar precios y costos.",
                    "Vinculacion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MostrarConfiguracionNormal()
        {
            // Mostrar paneles de configuración
            groupInfo.Visible = true;
            groupInfo.Location = new System.Drawing.Point(20, 70);
            
            groupPrecios.Visible = true;
            groupPrecios.Location = new System.Drawing.Point(20, 230);
            
            panelFraccionamiento.Visible = true;
            panelFraccionamiento.Location = new System.Drawing.Point(20, 410);
            
            groupResumen.Visible = true;
            groupResumen.Location = new System.Drawing.Point(20, 540);
            
            btnGuardar.Visible = true;
            btnGuardar.Location = new System.Drawing.Point(330, 650);
            
            btnCancelar.Location = new System.Drawing.Point(460, 650);
            
            // Ajustar tamaño del formulario
            this.Width = 600;
            this.Height = 720;
        }

        private void BuscarPorCodigoBarras(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return;

            try
            {
                var dProductos = new DProductos();
                var producto = dProductos.BuscarProducto(codigo);

                if (producto != null)
                {
                    _detalleProducto.EsProductoNuevo = false;
                    _detalleProducto.IdProductoEncontrado = (int)producto.Id;
                    _detalleProducto.NombreProductoEncontrado = producto.Nombre;
                    CargarDatosProductoExistente((int)producto.Id);
                    MessageBox.Show($"Producto encontrado: {producto.Nombre}",
                        "Vinculación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se encontró ningún producto con ese código de barras.",
                        "No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar producto: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
