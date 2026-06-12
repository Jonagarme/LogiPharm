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
            DisenarInterfazPremium();
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
            dgvProductos.CurrentCellDirtyStateChanged += DgvProductos_CurrentCellDirtyStateChanged;
            dgvProductos.CellValueChanged += DgvProductos_CellValueChanged;
        }

        private void DgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var item = dgvProductos.Rows[e.RowIndex].DataBoundItem as EDetalleFacturaXML;
            if (item == null) return;

            // 1. Configuración para la columna de Estado
            if (dgvProductos.Columns[e.ColumnIndex].Name == "colEstado")
            {
                if (item.TieneSimilares)
                {
                    e.Value = "SIMILAR";
                    e.CellStyle.ForeColor = Color.FromArgb(154, 52, 18); // Orange 800
                    e.CellStyle.BackColor = Color.FromArgb(255, 237, 213); // Orange 100
                }
                else if (item.EsProductoNuevo)
                {
                    e.Value = "NUEVO";
                    e.CellStyle.ForeColor = Color.FromArgb(22, 101, 52); // Green 800
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231); // Green 100
                }
                else
                {
                    e.Value = "ACTUALIZAR";
                    e.CellStyle.ForeColor = Color.FromArgb(30, 64, 175); // Blue 800
                    e.CellStyle.BackColor = Color.FromArgb(219, 234, 254); // Blue 100
                }

                e.CellStyle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            // 2. Configuración para la columna de Vincular (Ahora al mismo nivel que colEstado)
            else if (dgvProductos.Columns[e.ColumnIndex].Name == "colVincular")
            {
                if (item.TieneSimilares)
                {
                    e.Value = "Vincular";
                    e.CellStyle.BackColor = Color.FromArgb(52, 152, 219); // Blue 500
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185); // Blue 600
                    e.CellStyle.SelectionForeColor = Color.White;
                }
                else
                {
                    e.Value = "Configurar";
                    e.CellStyle.BackColor = Color.FromArgb(224, 231, 255); // Indigo 100
                    e.CellStyle.ForeColor = Color.FromArgb(67, 56, 202); // Indigo 700
                    e.CellStyle.SelectionBackColor = Color.FromArgb(199, 210, 254); // Indigo 200
                    e.CellStyle.SelectionForeColor = Color.FromArgb(67, 56, 202);
                }

                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

        private async void btnConsultarSRI_Click(object sender, EventArgs e)
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
                this.Cursor = Cursors.WaitCursor;
                btnConsultarSRI.Enabled = false;

                var parser = new DFacturaElectronica();
                _factura = await parser.ConsultarPorClaveAccesoAsync(clave);
                parser.BuscarProductosExistentes(_factura);

                CargarDatosEnRevisar();
                tabControl.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnConsultarSRI.Enabled = true;
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

                // Actualizar cabecera de proveedor premium
                if (lblProvName != null) lblProvName.Text = _factura.RazonSocialEmisor;
                if (lblProvRUC != null) lblProvRUC.Text = $"RUC: {_factura.RucEmisor}";

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

                // Seleccionar todos por defecto y configurar botones de acción
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    row.Cells["colSeleccionar"].Value = true;
                    var item = row.DataBoundItem as EDetalleFacturaXML;
                    if (item != null)
                    {
                        row.Cells["colVincular"].Value = item.TieneSimilares ? "Vincular" : "Configurar";
                    }
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

            // Actualizar las nuevas tarjetas de estadísticas
            if (lblCardTotalVal != null) lblCardTotalVal.Text = total.ToString();
            if (lblCardNuevosVal != null) lblCardNuevosVal.Text = nuevos.ToString();
            if (lblCardActualizarVal != null) lblCardActualizarVal.Text = actualizar.ToString();
            if (lblCardImporteVal != null) lblCardImporteVal.Text = _factura.ImporteTotal.ToString("C2");

            // Ejecutar la validación dinámica de totales
            ActualizarValidacionTotales();
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
                    "SelecciÃ³n requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show(
                "Â¿EstÃ¡ seguro de procesar el ingreso de esta factura de compra?\nSe actualizarÃ¡ el inventario, costos, PVP y se registrarÃ¡n los movimientos correspondientes.",
                "Confirmar Procesamiento",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                btnProcesarIngreso.Enabled = false;

                // Instanciar capa de datos
                var dFacturaCompra = new DFacturasCompra();
                
                // Usar IdUsuario de la sesiÃ³n actual
                int idUsuario = LogiPharm.Presentacion.Utilidades.SesionActual.IdUsuario;
                if (idUsuario <= 0) idUsuario = 1; // Fallback por seguridad si no estÃ¡ iniciada

                bool exito = dFacturaCompra.GuardarIngresoXML(_factura, seleccionados, idUsuario);

                if (exito)
                {
                    // Registrar en bitÃ¡cora
                    try
                    {
                        string numeroFactura = $"{_factura.Establecimiento}-{_factura.PuntoEmision}-{_factura.Secuencial}";
                        new DBitacora().Registrar(
                            idUsuario, 
                            LogiPharm.Presentacion.Utilidades.SesionActual.NombreUsuario ?? "System", 
                            "Compras", 
                            "CREAR", 
                            "facturas_compra", 
                            null, 
                            $"Registro de compra XML Nro: {numeroFactura} del proveedor RUC: {_factura.RucEmisor}", 
                            null, 
                            Environment.MachineName, 
                            "UI"
                        );
                    }
                    catch { }

                    string resultadoMsg = $"• Productos procesados y registrados: {seleccionados.Count}\n" +
                        $"• Proveedor registrado/asociado: {_factura.RazonSocialEmisor}\n" +
                        $"• Total factura: {_factura.ImporteTotal:C2}\n\n" +
                        $"Inventario, costos, PVP y movimientos de Kardex actualizados correctamente.";

                    lblResultado.Text = resultadoMsg;
                    if (lblResultadoActualizado != null)
                    {
                        lblResultadoActualizado.Text = resultadoMsg;
                    }

                    tabControl.SelectedIndex = 2; // Ir a tab Resultado
                }
                else
                {
                    MessageBox.Show("No se pudo procesar el ingreso de la factura.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el ingreso:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnProcesarIngreso.Enabled = true;
            }
        }

        #region Premium UI Interface Design (Replicating ingreso_xml.php)

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private Guna.UI2.WinForms.Guna2Panel pnlBadgeVersion;
        private System.Windows.Forms.Label lblBadgeVersion;

        // Stats Cards
        private Guna.UI2.WinForms.Guna2Panel cardTotalProductos;
        private System.Windows.Forms.Label lblCardTotalVal;
        private System.Windows.Forms.Label lblCardTotalLabel;

        private Guna.UI2.WinForms.Guna2Panel cardNuevos;
        private System.Windows.Forms.Label lblCardNuevosVal;
        private System.Windows.Forms.Label lblCardNuevosLabel;

        private Guna.UI2.WinForms.Guna2Panel cardActualizar;
        private System.Windows.Forms.Label lblCardActualizarVal;
        private System.Windows.Forms.Label lblCardActualizarLabel;

        private Guna.UI2.WinForms.Guna2Panel cardImporteTotal;
        private System.Windows.Forms.Label lblCardImporteVal;
        private System.Windows.Forms.Label lblCardImporteLabel;

        // Validation Panel
        private Guna.UI2.WinForms.Guna2Panel pnlValidation;
        private System.Windows.Forms.Label lblValidationTitle;
        private System.Windows.Forms.Label lblValidationDesc;

        private Label lblProvName;
        private Label lblProvRUC;

        private Guna.UI2.WinForms.Guna2Panel pnlResultadoPremium;
        private Label lblResultadoActualizado;

        private void DisenarInterfazPremium()
        {
            // Ajustar tamaño del formulario y de la ventana a través de ClientSize
            this.ClientSize = new Size(1200, 760);
            this.Text = "Asistente de Importación XML - LogiPharm";
            
            // Diseñar Cabecera Superior
            CrearCabeceraSuperior();

            // Evitar que el TabControl se traslape con la cabecera
            this.tabControl.Dock = DockStyle.None;
            this.tabControl.Location = new Point(0, 75);
            this.tabControl.Size = new Size(1200, 760 - 75);
            this.tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // Diseñar Controles de Tab 1
            AjustarTabCargar();

            // Diseñar Controles de Tab 2
            CrearTabRevisarPremium();

            // Configurar estilos avanzados para la Grilla
            EstilizarGridViewProductos();

            // Diseñar Tab 3 (Resultado)
            CrearTabResultadoPremium();
        }

        private void CrearCabeceraSuperior()
        {
            pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            pnlHeader.Height = 75;
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.FillColor = Color.FromArgb(79, 70, 229);      // Indigo 600
            pnlHeader.UseTransparentBackground = false;

            lblHeaderTitle = new Label();
            lblHeaderTitle.Text = "Asistente de Importación XML";
            lblHeaderTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Location = new Point(20, 12);
            lblHeaderTitle.BackColor = Color.Transparent;

            lblHeaderSubtitle = new Label();
            lblHeaderSubtitle.Text = "Revisión inteligente de facturas electrónicas del SRI";
            lblHeaderSubtitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblHeaderSubtitle.ForeColor = Color.FromArgb(224, 231, 255); // Indigo 100
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Location = new Point(22, 45);
            lblHeaderSubtitle.BackColor = Color.Transparent;

            pnlBadgeVersion = new Guna.UI2.WinForms.Guna2Panel();
            pnlBadgeVersion.Size = new Size(185, 32);
            pnlBadgeVersion.Location = new Point(1000, 21);
            pnlBadgeVersion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlBadgeVersion.BorderRadius = 16;
            pnlBadgeVersion.FillColor = Color.White;
            pnlBadgeVersion.BackColor = Color.Transparent;

            lblBadgeVersion = new Label();
            lblBadgeVersion.Text = "Procesamiento XML v2.0";
            lblBadgeVersion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBadgeVersion.ForeColor = Color.FromArgb(79, 70, 229); // Indigo 600
            lblBadgeVersion.AutoSize = true;
            lblBadgeVersion.Location = new Point(12, 8);
            lblBadgeVersion.BackColor = Color.Transparent;

            pnlBadgeVersion.Controls.Add(lblBadgeVersion);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Controls.Add(lblHeaderSubtitle);
            pnlHeader.Controls.Add(pnlBadgeVersion);

            this.Controls.Add(pnlHeader);
            
            // Asegurar que el TabControl esté debajo de la cabecera
            this.tabControl.SendToBack();
            pnlHeader.BringToFront();
        }

        private void AjustarTabCargar()
        {
            // Panel XML
            panelXML.FillColor = Color.White;
            panelXML.BorderColor = Color.FromArgb(226, 232, 240); // Slate 200
            panelXML.BorderRadius = 16;
            panelXML.BorderThickness = 1;
            panelXML.Location = new Point(60, 90);
            panelXML.Size = new Size(500, 380);

            lblTituloXML.Text = "Archivo XML de Factura";
            lblTituloXML.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTituloXML.ForeColor = Color.FromArgb(30, 41, 59); // Slate 800
            lblTituloXML.Location = new Point(30, 30);
            lblTituloXML.Size = new Size(440, 30);
            lblTituloXML.TextAlign = ContentAlignment.MiddleCenter;

            btnExaminar.FillColor = Color.FromArgb(79, 70, 229); // Indigo 600
            btnExaminar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnExaminar.BorderRadius = 12;
            btnExaminar.Location = new Point(125, 110);
            btnExaminar.Size = new Size(250, 50);

            lblArchivoSeleccionado.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblArchivoSeleccionado.ForeColor = Color.FromArgb(100, 116, 139); // Slate 500
            lblArchivoSeleccionado.Location = new Point(30, 185);
            lblArchivoSeleccionado.Size = new Size(440, 50);

            btnProcesarXML.FillColor = Color.FromArgb(16, 185, 129); // Emerald 500
            btnProcesarXML.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnProcesarXML.BorderRadius = 12;
            btnProcesarXML.Location = new Point(75, 270);
            btnProcesarXML.Size = new Size(350, 55);

            // Panel Clave
            panelClave.FillColor = Color.White;
            panelClave.BorderColor = Color.FromArgb(226, 232, 240); // Slate 200
            panelClave.BorderRadius = 16;
            panelClave.BorderThickness = 1;
            panelClave.Location = new Point(620, 90);
            panelClave.Size = new Size(500, 380);

            lblTituloClave.Text = "Clave de Acceso SRI";
            lblTituloClave.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTituloClave.ForeColor = Color.FromArgb(30, 41, 59); // Slate 800
            lblTituloClave.Location = new Point(30, 30);
            lblTituloClave.Size = new Size(440, 30);
            lblTituloClave.TextAlign = ContentAlignment.MiddleCenter;

            txtClaveAcceso.Font = new Font("Segoe UI", 11F);
            txtClaveAcceso.BorderRadius = 12;
            txtClaveAcceso.BorderColor = Color.FromArgb(203, 213, 225); // Slate 300
            txtClaveAcceso.FocusedState.BorderColor = Color.FromArgb(79, 70, 229); // Indigo 600
            txtClaveAcceso.Location = new Point(40, 115);
            txtClaveAcceso.Size = new Size(420, 45);
            txtClaveAcceso.PlaceholderText = "Ingrese los 49 dígitos de la clave de acceso";

            btnConsultarSRI.FillColor = Color.FromArgb(79, 70, 229); // Indigo 600
            btnConsultarSRI.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnConsultarSRI.BorderRadius = 12;
            btnConsultarSRI.Location = new Point(75, 200);
            btnConsultarSRI.Size = new Size(350, 55);

            // Agregar un banner de información como el de PHP
            var pnlInfoClave = new Guna.UI2.WinForms.Guna2Panel();
            pnlInfoClave.Size = new Size(420, 65);
            pnlInfoClave.Location = new Point(40, 280);
            pnlInfoClave.BorderRadius = 12;
            pnlInfoClave.FillColor = Color.FromArgb(254, 243, 199); // Amber 100
            pnlInfoClave.BorderColor = Color.FromArgb(253, 230, 138); // Amber 200
            pnlInfoClave.BorderThickness = 1;

            var lblInfoClave = new Label();
            lblInfoClave.Text = "ℹ El sistema extraerá automáticamente el proveedor y los productos autorizados directamente desde la base de datos del SRI.";
            lblInfoClave.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblInfoClave.ForeColor = Color.FromArgb(146, 64, 14); // Amber 800
            lblInfoClave.AutoSize = false;
            lblInfoClave.Size = new Size(400, 50);
            lblInfoClave.Location = new Point(10, 8);
            lblInfoClave.BackColor = Color.Transparent;
            lblInfoClave.TextAlign = ContentAlignment.MiddleLeft;

            pnlInfoClave.Controls.Add(lblInfoClave);
            panelClave.Controls.Add(pnlInfoClave);
        }

        private void CrearTabRevisarPremium()
        {
            // Ocultar componentes tradicionales
            groupProveedor.Visible = false;
            groupResumen.Visible = false;

            // 1. Tarjeta Proveedor Premium
            var pnlProv = new Guna.UI2.WinForms.Guna2Panel();
            pnlProv.Size = new Size(400, 95);
            pnlProv.Location = new Point(20, 15);
            pnlProv.BorderRadius = 12;
            pnlProv.FillColor = Color.FromArgb(248, 250, 252); // Slate 50
            pnlProv.BorderColor = Color.FromArgb(226, 232, 240); // Slate 200
            pnlProv.BorderThickness = 1;

            var lblProvLabel = new Label();
            lblProvLabel.Text = "PROVEEDOR SELECCIONADO";
            lblProvLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblProvLabel.ForeColor = Color.FromArgb(100, 116, 139); // Slate 500
            lblProvLabel.Location = new Point(15, 12);
            lblProvLabel.AutoSize = true;
            lblProvLabel.BackColor = Color.Transparent;

            lblProvName = new Label();
            lblProvName.Text = "Ninguno";
            lblProvName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblProvName.ForeColor = Color.FromArgb(15, 23, 42); // Slate 900
            lblProvName.Location = new Point(15, 32);
            lblProvName.Size = new Size(370, 25);
            lblProvName.BackColor = Color.Transparent;
            lblProvName.AutoEllipsis = true;

            lblProvRUC = new Label();
            lblProvRUC.Text = "RUC: ---";
            lblProvRUC.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblProvRUC.ForeColor = Color.FromArgb(79, 70, 229); // Indigo 600
            lblProvRUC.Location = new Point(15, 60);
            lblProvRUC.AutoSize = true;
            lblProvRUC.BackColor = Color.Transparent;

            pnlProv.Controls.Add(lblProvLabel);
            pnlProv.Controls.Add(lblProvName);
            pnlProv.Controls.Add(lblProvRUC);
            tabRevisar.Controls.Add(pnlProv);

            // 2. Tarjeta 1: Total Productos
            cardTotalProductos = CrearStatsCard(
                "PRODUCTOS HALLADOS", 
                "0", 
                Color.FromArgb(239, 246, 255), // Blue 50
                Color.FromArgb(59, 130, 246),  // Blue 500
                Color.FromArgb(219, 234, 254), // Blue 100
                new Point(435, 15), 
                out lblCardTotalVal,
                out lblCardTotalLabel
            );
            tabRevisar.Controls.Add(cardTotalProductos);

            // 3. Tarjeta 2: Nuevos en Sistema
            cardNuevos = CrearStatsCard(
                "NUEVOS PARA SISTEMA", 
                "0", 
                Color.FromArgb(240, 253, 250), // Teal 50
                Color.FromArgb(16, 185, 129),  // Emerald 500
                Color.FromArgb(204, 251, 241), // Teal 100
                new Point(625, 15), 
                out lblCardNuevosVal,
                out lblCardNuevosLabel
            );
            tabRevisar.Controls.Add(cardNuevos);

            // 4. Tarjeta 3: Por Actualizar / Duplicados
            cardActualizar = CrearStatsCard(
                "POSIBLES DUPLICADOS", 
                "0", 
                Color.FromArgb(255, 247, 237), // Orange 50
                Color.FromArgb(245, 158, 11),  // Amber 500
                Color.FromArgb(254, 215, 170), // Orange 100
                new Point(815, 15), 
                out lblCardActualizarVal,
                out lblCardActualizarLabel
            );
            tabRevisar.Controls.Add(cardActualizar);

            // 5. Tarjeta 4: Total Importe
            cardImporteTotal = CrearStatsCard(
                "IMPORTE TOTAL XML", 
                "$0.00", 
                Color.FromArgb(245, 243, 255), // Purple 50
                Color.FromArgb(139, 92, 246),  // Violet 500
                Color.FromArgb(237, 233, 254), // Purple 100
                new Point(1005, 15), 
                out lblCardImporteVal,
                out lblCardImporteLabel
            );
            cardImporteTotal.Width = 165;
            tabRevisar.Controls.Add(cardImporteTotal);

            // 6. Panel de Validación de Totales (Bottom Left)
            pnlValidation = new Guna.UI2.WinForms.Guna2Panel();
            pnlValidation.Size = new Size(500, 60);
            pnlValidation.Location = new Point(415, 575);
            pnlValidation.BorderRadius = 12;
            pnlValidation.FillColor = Color.FromArgb(248, 250, 252); // Slate 50 default
            pnlValidation.BorderColor = Color.FromArgb(226, 232, 240); // Slate 200 default
            pnlValidation.BorderThickness = 1;

            lblValidationTitle = new Label();
            lblValidationTitle.Text = "Calculando...";
            lblValidationTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblValidationTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblValidationTitle.Location = new Point(15, 8);
            lblValidationTitle.AutoSize = true;
            lblValidationTitle.BackColor = Color.Transparent;

            lblValidationDesc = new Label();
            lblValidationDesc.Text = "Comprobando totales entre la grilla y el XML...";
            lblValidationDesc.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular);
            lblValidationDesc.ForeColor = Color.FromArgb(100, 116, 139);
            lblValidationDesc.Location = new Point(15, 30);
            lblValidationDesc.Size = new Size(470, 20);
            lblValidationDesc.BackColor = Color.Transparent;

            pnlValidation.Controls.Add(lblValidationTitle);
            pnlValidation.Controls.Add(lblValidationDesc);
            tabRevisar.Controls.Add(pnlValidation);
            
            // Re-posicionar botones del pie
            btnSeleccionarTodo.Location = new Point(20, 580);
            btnSeleccionarTodo.Size = new Size(180, 45);
            btnSeleccionarTodo.FillColor = Color.FromArgb(79, 70, 229); // Indigo 600

            btnDeseleccionarTodo.Location = new Point(215, 580);
            btnDeseleccionarTodo.Size = new Size(180, 45);
            btnDeseleccionarTodo.FillColor = Color.FromArgb(148, 163, 184); // Slate 400

            btnProcesarIngreso.Location = new Point(935, 580);
            btnProcesarIngreso.Size = new Size(235, 45);
            btnProcesarIngreso.FillColor = Color.FromArgb(16, 185, 129); // Emerald 500
        }

        private Guna.UI2.WinForms.Guna2Panel CrearStatsCard(
            string label, 
            string val, 
            Color bg, 
            Color primary, 
            Color border, 
            Point loc, 
            out Label valLabel,
            out Label labelLabel)
        {
            var card = new Guna.UI2.WinForms.Guna2Panel();
            card.Size = new Size(175, 95);
            card.Location = loc;
            card.BorderRadius = 12;
            card.FillColor = bg;
            card.BorderColor = border;
            card.BorderThickness = 1;

            labelLabel = new Label();
            labelLabel.Text = label;
            labelLabel.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            labelLabel.ForeColor = primary;
            labelLabel.Location = new Point(12, 12);
            labelLabel.AutoSize = true;
            labelLabel.BackColor = Color.Transparent;

            valLabel = new Label();
            valLabel.Text = val;
            valLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            valLabel.ForeColor = primary;
            valLabel.Location = new Point(10, 32);
            valLabel.AutoSize = true;
            valLabel.BackColor = Color.Transparent;

            card.Controls.Add(labelLabel);
            card.Controls.Add(valLabel);
            return card;
        }

        private void EstilizarGridViewProductos()
        {
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.GridColor = Color.FromArgb(241, 245, 249); // Slate 100
            
            // Cabeceras
            dgvProductos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252); // Slate 50
            dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105); // Slate 600
            dgvProductos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvProductos.ColumnHeadersHeight = 35;
            
            // Filas
            dgvProductos.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvProductos.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(15, 23, 42); // Slate 900
            dgvProductos.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(238, 242, 255); // Indigo 50
            dgvProductos.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(67, 56, 202); // Indigo 700
            dgvProductos.RowsDefaultCellStyle.Font = new Font("Segoe UI", 9.5F);

            // Alternating
            dgvProductos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252); // Slate 50
            
            // Ajustar altura de las filas
            dgvProductos.RowTemplate.Height = 35;
        }

        private void CrearTabResultadoPremium()
        {
            lblResultado.Visible = false;

            pnlResultadoPremium = new Guna.UI2.WinForms.Guna2Panel();
            pnlResultadoPremium.Size = new Size(800, 350);
            pnlResultadoPremium.Location = new Point(190, 80);
            pnlResultadoPremium.BorderRadius = 16;
            pnlResultadoPremium.FillColor = Color.White;
            pnlResultadoPremium.BorderColor = Color.FromArgb(226, 232, 240);
            pnlResultadoPremium.BorderThickness = 1;

            var lblCheckIcon = new Label();
            lblCheckIcon.Text = "✓";
            lblCheckIcon.Font = new Font("Segoe UI", 48F, FontStyle.Bold);
            lblCheckIcon.ForeColor = Color.FromArgb(16, 185, 129); // Emerald 500
            lblCheckIcon.Size = new Size(100, 90);
            lblCheckIcon.Location = new Point(350, 20);
            lblCheckIcon.TextAlign = ContentAlignment.MiddleCenter;
            lblCheckIcon.BackColor = Color.Transparent;

            var lblResultadoTitle = new Label();
            lblResultadoTitle.Text = "¡Importación Procesada Exitosamente!";
            lblResultadoTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblResultadoTitle.ForeColor = Color.FromArgb(15, 23, 42); // Slate 900
            lblResultadoTitle.Size = new Size(760, 35);
            lblResultadoTitle.Location = new Point(20, 120);
            lblResultadoTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblResultadoTitle.BackColor = Color.Transparent;

            lblResultadoActualizado = new Label();
            lblResultadoActualizado.Font = new Font("Segoe UI", 11F);
            lblResultadoActualizado.ForeColor = Color.FromArgb(71, 85, 105); // Slate 600
            lblResultadoActualizado.Size = new Size(700, 160);
            lblResultadoActualizado.Location = new Point(50, 170);
            lblResultadoActualizado.TextAlign = ContentAlignment.TopCenter;
            lblResultadoActualizado.BackColor = Color.Transparent;

            pnlResultadoPremium.Controls.Add(lblCheckIcon);
            pnlResultadoPremium.Controls.Add(lblResultadoTitle);
            pnlResultadoPremium.Controls.Add(lblResultadoActualizado);
            tabResultado.Controls.Add(pnlResultadoPremium);

            // Re-posicionar botón Cerrar
            btnCerrar.Location = new Point(495, 460);
            btnCerrar.Size = new Size(200, 50);
            btnCerrar.FillColor = Color.FromArgb(79, 70, 229); // Indigo 600
            btnCerrar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        }

        private void ActualizarValidacionTotales()
        {
            if (_factura == null || pnlValidation == null) return;

            decimal calculatedTotal = 0;
            int countChecked = 0;

            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                var isSelected = Convert.ToBoolean(row.Cells["colSeleccionar"].Value ?? false);
                if (isSelected)
                {
                    var item = row.DataBoundItem as EDetalleFacturaXML;
                    if (item != null)
                    {
                        decimal subtotal = item.Cantidad * item.PrecioUnitario;
                        decimal iva = subtotal * (item.Tarifa / 100m);
                        calculatedTotal += (subtotal + iva);
                        countChecked++;
                    }
                }
            }

            decimal originalTotal = _factura.ImporteTotal;
            decimal diff = Math.Abs(calculatedTotal - originalTotal);

            if (diff < 0.10m)
            {
                pnlValidation.FillColor = Color.FromArgb(220, 252, 231); // Green 100
                pnlValidation.BorderColor = Color.FromArgb(187, 247, 208); // Green 200
                lblValidationTitle.Text = "✓ Validación Correcta";
                lblValidationTitle.ForeColor = Color.FromArgb(21, 128, 61); // Green 700
                lblValidationDesc.Text = $"El total calculado (${calculatedTotal:N2}) coincide con el total del XML original (${originalTotal:N2}).";
                lblValidationDesc.ForeColor = Color.FromArgb(21, 128, 61);
            }
            else
            {
                pnlValidation.FillColor = Color.FromArgb(254, 243, 199); // Amber 100
                pnlValidation.BorderColor = Color.FromArgb(253, 230, 138); // Amber 200
                lblValidationTitle.Text = "⚠ Diferencia en Totales Detectada";
                lblValidationTitle.ForeColor = Color.FromArgb(180, 83, 9); // Amber 700
                lblValidationDesc.Text = $"Calculado: ${calculatedTotal:N2} | XML: ${originalTotal:N2} (Diferencia: ${diff:N2}).";
                lblValidationDesc.ForeColor = Color.FromArgb(180, 83, 9);
            }
        }

        private void DgvProductos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvProductos.IsCurrentCellDirty)
            {
                dgvProductos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DgvProductos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvProductos.Columns[e.ColumnIndex].Name == "colSeleccionar")
            {
                ActualizarResumen();
            }
        }

        #endregion

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
