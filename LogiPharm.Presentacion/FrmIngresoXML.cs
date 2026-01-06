using System;
using System.Windows.Forms;
using System.Drawing;
using LogiPharm.Datos;
using LogiPharm.Entidades;
using System.IO;
using System.Linq;

namespace LogiPharm.Presentacion
{
    public partial class FrmIngresoXML : Form
    {
        private string _archivoXML;
        private EFacturaElectronica _factura;

        public FrmIngresoXML()
        {
            InitializeComponent();
            this.Load += FrmIngresoXML_Load;
            ConfigurarDataGridView();
            tabControl.SelectedIndex = 0;
            
            // Habilitar cierre con tecla ESC
            this.KeyPreview = true;
            this.KeyDown += FrmIngresoXML_KeyDown;
        }

        private void FrmIngresoXML_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                // Confirmar antes de cerrar si hay datos cargados
                if (_factura != null && _factura.Detalles != null && _factura.Detalles.Count > 0)
                {
                    var result = MessageBox.Show(
                        "Hay productos cargados. Seguro que deseas salir?",
                        "Confirmar Salida",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    
                    if (result == DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void FrmIngresoXML_Load(object sender, EventArgs e)
        {
            // Asegurar que el grid esté configurado
            if (dgvProductos.Columns.Count == 0)
            {
                ConfigurarDataGridView();
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.Columns.Clear();

            dgvProductos.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "colSeleccionar",
                HeaderText = "✓",
                Width = 40,
                ReadOnly = false
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCodigo",
                HeaderText = "Código",
                DataPropertyName = "CodigoPrincipal",
                Width = 110,
                ReadOnly = true
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDescripcion",
                HeaderText = "Descripción",
                DataPropertyName = "Descripcion",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCantidad",
                HeaderText = "Cantidad",
                DataPropertyName = "Cantidad",
                Width = 80,
                ReadOnly = false
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPrecioUnidad",
                HeaderText = "Precio Unit.",
                DataPropertyName = "PrecioUnitario",
                Width = 100,
                ReadOnly = false,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSubtotal",
                HeaderText = "Subtotal",
                DataPropertyName = "PrecioTotalSinImpuesto",
                Width = 100,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEstado",
                HeaderText = "Estado",
                Width = 100,
                ReadOnly = true
            });

            // Columna de Vincular (solo visible cuando hay similares)
            var colVincular = new DataGridViewButtonColumn
            {
                Name = "colVincular",
                HeaderText = "Acción",
                Width = 100,
                ReadOnly = true
            };
            // Configurar estilo por defecto
            colVincular.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            colVincular.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            colVincular.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            colVincular.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            colVincular.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            colVincular.FlatStyle = FlatStyle.Flat;
            dgvProductos.Columns.Add(colVincular);

            dgvProductos.CellFormatting += DgvProductos_CellFormatting;
            dgvProductos.CellClick += DgvProductos_CellClick;
        }

        private void DgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            
            var item = dgvProductos.Rows[e.RowIndex].DataBoundItem as EDetalleFacturaXML;
            if (item == null) return;

            if (dgvProductos.Columns[e.ColumnIndex].Name == "colEstado")
            {
                if (item.TieneSimilares)
                {
                    e.Value = "SIMILAR";
                    e.CellStyle.ForeColor = System.Drawing.Color.FromArgb(255, 140, 0); // Orange
                    e.CellStyle.BackColor = System.Drawing.Color.FromArgb(255, 250, 205); // Light orange background
                }
                else
                {
                    e.Value = item.EsProductoNuevo ? "NUEVO" : "ACTUALIZAR";
                    e.CellStyle.ForeColor = item.EsProductoNuevo ? System.Drawing.Color.Green : System.Drawing.Color.Blue;
                }
                e.CellStyle.Font = new System.Drawing.Font(e.CellStyle.Font, System.Drawing.FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else if (dgvProductos.Columns[e.ColumnIndex].Name == "colVincular")
            {
                // Solo mostrar el botón si hay productos similares detectados
                if (item.TieneSimilares)
                {
                    e.Value = "Vincular";
                    e.CellStyle.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
                    e.CellStyle.ForeColor = System.Drawing.Color.White;
                    e.CellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(41, 128, 185);
                    e.CellStyle.SelectionForeColor = System.Drawing.Color.White;
                    e.CellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    e.Value = "";
                    e.CellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
                    e.CellStyle.ForeColor = System.Drawing.Color.Gray;
                }
            }
        }

        private void DgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que no sea el header
            if (e.RowIndex < 0)
            {
                return;
            }

            try
            {
                var detalleProducto = dgvProductos.Rows[e.RowIndex].DataBoundItem as EDetalleFacturaXML;
                
                if (detalleProducto == null) return;

                // Si se hizo clic en el checkbox, no hacer nada más
                if (dgvProductos.Columns[e.ColumnIndex].Name == "colSeleccionar")
                {
                    return;
                }

                // Si se hizo clic en el botón de vincular y hay similares
                if (dgvProductos.Columns[e.ColumnIndex].Name == "colVincular" && detalleProducto.TieneSimilares)
                {
                    AbrirDialogoVinculacion(detalleProducto, e.RowIndex);
                    return;
                }

                // Clic en cualquier otra celda abre la configuración normal
                AbrirConfiguracionProducto(detalleProducto, e.RowIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la acción:\n{ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirConfiguracionProducto(EDetalleFacturaXML detalleProducto, int rowIndex)
        {
            try
            {
                // Abrir el formulario de configuración normal (sin modo similares)
                using (var frmConfig = new FrmConfiguracionProductoXML(detalleProducto, mostrarSimilares: false))
                {
                    if (frmConfig.ShowDialog() == DialogResult.OK)
                    {
                        // Actualizar el grid con los cambios
                        dgvProductos.Refresh();
                        ActualizarResumen();
                        
                        MessageBox.Show("Configuración guardada correctamente.", 
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir configuración del producto:\n{ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirDialogoVinculacion(EDetalleFacturaXML detalleProducto, int rowIndex)
        {
            try
            {
                // Abrir el formulario de configuración con los productos similares
                using (var frmConfig = new FrmConfiguracionProductoXML(detalleProducto, mostrarSimilares: true))
                {
                    if (frmConfig.ShowDialog() == DialogResult.OK)
                    {
                        // Actualizar el grid con los cambios
                        dgvProductos.Refresh();
                        ActualizarResumen();
                        
                        MessageBox.Show("Producto vinculado correctamente.", 
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir diálogo de vinculación:\n{ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos XML|*.xml|Todos los archivos|*.*";
                ofd.Title = "Seleccione el archivo XML de la factura";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _archivoXML = ofd.FileName;
                    lblArchivoSeleccionado.Text = $"Archivo: {Path.GetFileName(_archivoXML)}";
                }
            }
        }

        private void btnProcesarXML_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_archivoXML))
            {
                MessageBox.Show("Por favor, seleccione un archivo XML primero.", "Archivo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var parser = new DFacturaElectronica();
                _factura = parser.ParsearXML(_archivoXML);
                parser.BuscarProductosExistentes(_factura);

                CargarDatosEnRevisar();
                tabControl.SelectedIndex = 1; // Ir a tab Revisar
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el XML:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultarSRI_Click(object sender, EventArgs e)
        {
            string clave = txtClaveAcceso.Text.Trim();
            if (string.IsNullOrEmpty(clave) || clave.Length != 49)
            {
                MessageBox.Show("La clave de acceso debe contener exactamente 49 dígitos.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var parser = new DFacturaElectronica();
                _factura = parser.ConsultarPorClaveAcceso(clave);
                parser.BuscarProductosExistentes(_factura);

                CargarDatosEnRevisar();
                tabControl.SelectedIndex = 1;
            }
            catch (NotImplementedException)
            {
                MessageBox.Show("La consulta por clave de acceso aún no está implementada.\n" +
                    "Requiere integración con el SRI o su proveedor de servicios.",
                    "Función no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosEnRevisar()
        {
            try
            {
                if (_factura == null)
                {
                    MessageBox.Show("No hay factura cargada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Info Proveedor
                lblRazonSocial.Text = $"Proveedor: {_factura.RazonSocialEmisor}";
                lblRUC.Text = $"RUC: {_factura.RucEmisor}";

                // Verificar si hay detalles
                if (_factura.Detalles == null || _factura.Detalles.Count == 0)
                {
                    MessageBox.Show($"El XML no contiene productos.\nProveedor: {_factura.RazonSocialEmisor}", 
                        "Sin productos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Bind productos - limpiamos primero
                dgvProductos.DataSource = null;
                dgvProductos.Rows.Clear();
                
                // Ahora asignamos la fuente
                dgvProductos.DataSource = _factura.Detalles;

                // Forzar refresh
                dgvProductos.Refresh();

                // Seleccionar todos por defecto
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    row.Cells["colSeleccionar"].Value = true;
                }

                ActualizarResumen();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos en revisar:\n{ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarResumen()
        {
            int total = _factura.Detalles.Count;
            int nuevos = _factura.Detalles.Count(d => d.EsProductoNuevo);
            int actualizar = total - nuevos;

            lblProductosIngresar.Text = $"Productos a Ingresar: {total}";
            lblNuevos.Text = $"Nuevos: {nuevos}";
            lblActualizar.Text = $"A Actualizar: {actualizar}";
            lblTotal.Text = $"Total: {_factura.ImporteTotal:C2}";
        }

        private void btnSeleccionarTodo_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                row.Cells["colSeleccionar"].Value = true;
            }
        }

        private void btnDeseleccionarTodo_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                row.Cells["colSeleccionar"].Value = false;
            }
        }

        private void btnProcesarIngreso_Click(object sender, EventArgs e)
        {
            // Obtener productos seleccionados
            var seleccionados = dgvProductos.Rows.Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells["colSeleccionar"].Value ?? false))
                .Select(r => r.DataBoundItem as EDetalleFacturaXML)
                .ToList();

            if (seleccionados.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un producto para procesar.",
                    "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // TODO: Integrar con tu lógica de recepción/ingreso
                // Por ahora simulación
                int procesados = 0;
                int errores = 0;

                foreach (var producto in seleccionados)
                {
                    try
                    {
                        // Aquí iría tu lógica de ingreso real
                        procesados++;
                    }
                    catch
                    {
                        errores++;
                    }
                }

                lblResultado.Text = $"Proceso completado:\n\n" +
                    $"? Productos procesados: {procesados}\n" +
                    $"? Errores: {errores}\n\n" +
                    $"Proveedor: {_factura.RazonSocialEmisor}\n" +
                    $"Total factura: {_factura.ImporteTotal:C2}";

                tabControl.SelectedIndex = 2; // Ir a tab Resultado
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el ingreso:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
