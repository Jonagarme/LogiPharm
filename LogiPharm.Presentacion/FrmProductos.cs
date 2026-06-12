using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmProductos : Form
    {
        // Estado para carga incremental
        private DataTable _tablaProductos;
        private int _pageSize = 50;
        private int _offset = 0;
        private bool _isLoading = false;
        private bool _allLoaded = false;
        private string _criterioActual = null; // null = listado normal; texto = búsqueda
        private int _totalRegistros = -1;

        // Debounce/Cancelación
        private System.Windows.Forms.Timer _debounceTimer;
        private CancellationTokenSource _ctsBusqueda;

        private int _hoverRow = -1;
        private int _hoverCol = -1;

        // ===== NUEVOS CONTROLES PARA ALINEACIÓN CON PHP =====
        private TableLayoutPanel tblStats;
        private TableLayoutPanel tblFilters;
        private Guna.UI2.WinForms.Guna2ComboBox cboFilterCategoria;
        private Guna.UI2.WinForms.Guna2ComboBox cboFilterLaboratorio;
        private Guna.UI2.WinForms.Guna2Button btnFiltrar;
        private Guna.UI2.WinForms.Guna2Button btnLimpiar;
        private Guna.UI2.WinForms.Guna2Button btnCatalogoPdf;

        private Label lblTotalVal;
        private Label lblEnStockVal;
        private Label lblStockBajoVal;
        private Label lblCategoriasVal;

        private int? _filtroCategoria = null;
        private int? _filtroLaboratorio = null;

        public FrmProductos()
        {
            InitializeComponent();

            // DoubleBuffer para menos parpadeo
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null, DgvListado, new object[] { true });

            // VirtualMode: cuando el DataSource es DataTable no es estrictamente necesario, pero lo preparamos
            DgvListado.VirtualMode = false; // si migras a un proveedor virtual, colócalo en true y maneja CellValueNeeded

            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += BtnCancelar_Click;
            
            // Wire up toolbar buttons that are not wired in designer
            btnOpciones.Click += BtnOpciones_Click;
            btnExportar.Click += BtnExportar_Click;

            DgvListado.CellDoubleClick += DgvListado_CellDoubleClick;
            DgvListado.CellMouseMove += DgvListado_CellMouseMove;
            DgvListado.CellMouseLeave += DgvListado_CellMouseLeave;
            DgvListado.CellFormatting += DgvListado_CellFormatting;
            DgvListado.Columns["colStatus"].DefaultCellStyle.NullValue = null;
            DgvListado.Columns["colEditar"].DefaultCellStyle.NullValue = null;
            DgvListado.Columns["colEliminar"].DefaultCellStyle.NullValue = null;

            DgvListado.DataError += (s, e) => { e.ThrowException = false; };
            DgvListado.Scroll += DgvListado_Scroll;

            AsignarEventosMenu();

            DgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvListado.MultiSelect = false;
            DgvListado.AllowUserToAddRows = false;
            DgvListado.RowHeadersVisible = false;
            DgvListado.RowTemplate.Height = Math.Max(DgvListado.RowTemplate.Height, 28);

            // Debounce para búsqueda
            _debounceTimer = new System.Windows.Forms.Timer { Interval = 300 };
            _debounceTimer.Tick += async (s, e) =>
            {
                _debounceTimer.Stop();
                await EjecutarBusquedaDebouncedAsync();
            };
        }

        private async Task EjecutarBusquedaDebouncedAsync()
        {
            CancelarBusquedaEnCurso();
            _ctsBusqueda = new CancellationTokenSource();
            try
            {
                string criterio = txtBuscar.Text.Trim();
                if (string.IsNullOrWhiteSpace(criterio))
                {
                    await ResetearListadoAsync(null);
                }
                else
                {
                    await ResetearListadoAsync(criterio);
                }
            }
            catch (OperationCanceledException) { }
            finally
            {
                _ctsBusqueda = null;
            }
        }

        private void CancelarBusquedaEnCurso()
        {
            if (_ctsBusqueda != null && !_ctsBusqueda.IsCancellationRequested)
            {
                _ctsBusqueda.Cancel();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            _debounceTimer.Stop();
            _debounceTimer.Start();
        }

        private void BtnCancelar_Click(object sender, EventArgs e) => CerrarPanelEdicion();

        private void BtnOpciones_Click(object sender, EventArgs e)
        {
            contextMenuOpciones.Show(btnOpciones, new Point(0, btnOpciones.Height));
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                var sfd = new SaveFileDialog
                {
                    Filter = "Archivo CSV (*.csv)|*.csv",
                    FileName = $"Productos_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var d = new DProductos();
                    DataTable dt = d.ListarProductosFiltradoPaginado(_criterioActual, _filtroCategoria, _filtroLaboratorio, 0, 1000000);

                    using (var sw = new System.IO.StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                    {
                        sw.WriteLine("Código,Nombre,Stock,PVP,Stock Mínimo,Estado");

                        foreach (DataRow row in dt.Rows)
                        {
                            string codigo = row["Código"]?.ToString() ?? string.Empty;
                            string nombre = row["Nombre"]?.ToString() ?? string.Empty;
                            string stock = row["Stock"]?.ToString() ?? "0";
                            string pvp = row["PVP"]?.ToString() ?? "0";
                            string stockMin = row["StockMinimo"]?.ToString() ?? "0";
                            bool activo = Convert.ToBoolean(row["Activo"]);
                            string estado = activo ? "Activo" : "Inactivo";

                            nombre = nombre.Replace("\"", "\"\"");

                            sw.WriteLine($"\"{codigo}\",\"{nombre}\",{stock},{pvp},{stockMin},\"{estado}\"");
                        }
                    }

                    MessageBox.Show("Exportación completada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void FrmProductos_Load(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = true;
            CerrarPanelEdicion();

            // Programmatic layout configuration to include Stats and Filters panels
            panelListado.Controls.Remove(txtBuscar);
            panelListado.Controls.Remove(DgvListado);

            // Stats Table
            tblStats = new TableLayoutPanel
            {
                Location = new Point(13, 13),
                Size = new Size(panelListado.Width - 26, 68),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                ColumnCount = 4,
                RowCount = 1,
                BackColor = Color.Transparent
            };
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblStats.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            tblStats.Controls.Add(CrearTarjetaEstadistica("TOTAL PRODUCTOS", "0", Color.FromArgb(239, 246, 255), Color.FromArgb(191, 219, 254), Color.FromArgb(29, 78, 216), out lblTotalVal), 0, 0);
            tblStats.Controls.Add(CrearTarjetaEstadistica("EN STOCK", "0", Color.FromArgb(240, 253, 250), Color.FromArgb(153, 246, 228), Color.FromArgb(15, 118, 110), out lblEnStockVal), 1, 0);
            tblStats.Controls.Add(CrearTarjetaEstadistica("STOCK BAJO", "0", Color.FromArgb(254, 242, 242), Color.FromArgb(254, 202, 202), Color.FromArgb(185, 28, 28), out lblStockBajoVal), 2, 0);
            tblStats.Controls.Add(CrearTarjetaEstadistica("CATEGORÍAS", "0", Color.FromArgb(250, 245, 255), Color.FromArgb(233, 213, 255), Color.FromArgb(109, 40, 217), out lblCategoriasVal), 3, 0);

            panelListado.Controls.Add(tblStats);

            // Filters Table
            tblFilters = new TableLayoutPanel
            {
                Location = new Point(13, 90),
                Size = new Size(panelListado.Width - 26, 40),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                ColumnCount = 5,
                RowCount = 1,
                BackColor = Color.Transparent
            };
            tblFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tblFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23F));
            tblFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
            tblFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tblFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tblFilters.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            txtBuscar.Dock = DockStyle.Fill;
            txtBuscar.Margin = new Padding(2);
            tblFilters.Controls.Add(txtBuscar, 0, 0);

            cboFilterCategoria = new Guna.UI2.WinForms.Guna2ComboBox
            {
                Dock = DockStyle.Fill,
                BorderRadius = 8,
                Font = new Font("Segoe UI", 9F),
                Margin = new Padding(2),
                Height = 36,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            tblFilters.Controls.Add(cboFilterCategoria, 1, 0);

            cboFilterLaboratorio = new Guna.UI2.WinForms.Guna2ComboBox
            {
                Dock = DockStyle.Fill,
                BorderRadius = 8,
                Font = new Font("Segoe UI", 9F),
                Margin = new Padding(2),
                Height = 36,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            tblFilters.Controls.Add(cboFilterLaboratorio, 2, 0);

            btnFiltrar = new Guna.UI2.WinForms.Guna2Button
            {
                Dock = DockStyle.Fill,
                BorderRadius = 8,
                FillColor = Color.FromArgb(37, 99, 235),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Text = "Filtrar",
                Margin = new Padding(2)
            };
            btnFiltrar.Click += BtnFiltrar_Click;
            tblFilters.Controls.Add(btnFiltrar, 3, 0);

            btnLimpiar = new Guna.UI2.WinForms.Guna2Button
            {
                Dock = DockStyle.Fill,
                BorderRadius = 8,
                FillColor = Color.FromArgb(156, 163, 175),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Text = "Limpiar",
                Margin = new Padding(2)
            };
            btnLimpiar.Click += BtnLimpiar_Click;
            tblFilters.Controls.Add(btnLimpiar, 4, 0);

            panelListado.Controls.Add(tblFilters);

            // Re-add Grid below filters
            DgvListado.Location = new Point(13, 140);
            DgvListado.Size = new Size(panelListado.Width - 26, panelListado.Height - 140 - 35);
            DgvListado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelListado.Controls.Add(DgvListado);

            // Add catalog PDF button to toolbar
            btnCatalogoPdf = new Guna.UI2.WinForms.Guna2Button
            {
                Location = new Point(524, 12),
                Size = new Size(120, 45),
                BorderRadius = 8,
                FillColor = Color.FromArgb(220, 38, 38),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.White,
                Text = "Catálogo PDF"
            };
            btnCatalogoPdf.Click += BtnCatalogoPdf_Click;
            panelToolbar.Controls.Add(btnCatalogoPdf);

            // Data loadings
            try
            {
                DataTable dtCategorias = new DProductos().ListarCategorias();
                DataRow rowCat = dtCategorias.NewRow();
                rowCat["id"] = 0;
                rowCat["nombre"] = "-- Todas las Categorías --";
                dtCategorias.Rows.InsertAt(rowCat, 0);
                cboFilterCategoria.DataSource = dtCategorias;
                cboFilterCategoria.DisplayMember = "nombre";
                cboFilterCategoria.ValueMember = "id";
                cboFilterCategoria.SelectedIndex = 0;
            }
            catch { }

            try
            {
                DataTable dtLabs = new DLaboratorios().Listar();
                DataRow rowLab = dtLabs.NewRow();
                rowLab["id"] = 0;
                rowLab["nombre"] = "-- Todos los Laboratorios --";
                dtLabs.Rows.InsertAt(rowLab, 0);
                cboFilterLaboratorio.DataSource = dtLabs;
                cboFilterLaboratorio.DisplayMember = "nombre";
                cboFilterLaboratorio.ValueMember = "id";
                cboFilterLaboratorio.SelectedIndex = 0;
            }
            catch { }

            txtBuscar.TextChanged += txtBuscar_TextChanged;

            ActualizarEstadisticas();
            await ResetearListadoAsync(null);

            // Auditoría: VISUALIZAR listado
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Productos", "VISUALIZAR", "productos", null, "Abrir listado de productos", null, Environment.MachineName, "UI"); } catch { }
        }

        private async void BtnFiltrar_Click(object sender, EventArgs e)
        {
            if (cboFilterCategoria.SelectedValue != null && int.TryParse(cboFilterCategoria.SelectedValue.ToString(), out int catId) && catId > 0)
            {
                _filtroCategoria = catId;
            }
            else
            {
                _filtroCategoria = null;
            }

            if (cboFilterLaboratorio.SelectedValue != null && int.TryParse(cboFilterLaboratorio.SelectedValue.ToString(), out int labId) && labId > 0)
            {
                _filtroLaboratorio = labId;
            }
            else
            {
                _filtroLaboratorio = null;
            }

            await ResetearListadoAsync(txtBuscar.Text.Trim());
        }

        private async void BtnLimpiar_Click(object sender, EventArgs e)
        {
            _filtroCategoria = null;
            _filtroLaboratorio = null;
            txtBuscar.Text = string.Empty;
            
            if (cboFilterCategoria.Items.Count > 0) cboFilterCategoria.SelectedIndex = 0;
            if (cboFilterLaboratorio.Items.Count > 0) cboFilterLaboratorio.SelectedIndex = 0;

            await ResetearListadoAsync(null);
        }

        private void BtnCatalogoPdf_Click(object sender, EventArgs e)
        {
            try
            {
                var empData = new DEmpresa().ObtenerDatosEmpresa();
                string razonSocial = empData?.RazonSocial ?? "LOGIPHARM SYSTEM";
                string nombreComercial = empData?.NombreComercial ?? "LOGIPHARM";
                string ruc = empData?.Ruc ?? "0999999999001";
                string direccion = empData?.DireccionMatriz ?? "Av. Principal";

                var d = new DProductos();
                DataTable dt = d.ListarProductosFiltradoPaginado(_criterioActual, _filtroCategoria, _filtroLaboratorio, 0, 1000000);

                int totalItems = dt.Rows.Count;
                decimal totalStock = 0;
                decimal totalValorVenta = 0;

                var rowsHtml = new System.Text.StringBuilder();
                foreach (DataRow r in dt.Rows)
                {
                    string codigo = r["Código"]?.ToString() ?? "";
                    string nombre = r["Nombre"]?.ToString() ?? "";
                    decimal.TryParse(r["Stock"]?.ToString(), out decimal stock);
                    decimal.TryParse(r["PVP"]?.ToString(), out decimal pvp);
                    decimal.TryParse(r["StockMinimo"]?.ToString(), out decimal stockMinimo);

                    totalStock += stock;
                    totalValorVenta += (stock * pvp);

                    bool isLow = stock <= stockMinimo;
                    string stockBadgeClass = isLow ? "low-stock" : "normal-stock";

                    rowsHtml.AppendLine($@"
                    <tr>
                        <td style='font-family: monospace; font-weight: 700;'>{System.Net.WebUtility.HtmlEncode(codigo)}</td>
                        <td>{System.Net.WebUtility.HtmlEncode(nombre)}</td>
                        <td class='text-center'>
                            <span class='stock-badge {stockBadgeClass}'>{stock:N0}</span>
                        </td>
                        <td class='text-right'>${pvp:N2}</td>
                        <td class='text-right' style='font-weight:700;'>${(stock * pvp):N2}</td>
                    </tr>");
                }

                string htmlContent = $@"<!DOCTYPE html>
<html lang='es'>
<head>
    <meta charset='UTF-8'>
    <title>Reporte de Inventario - {DateTime.Now:dd-MM-yyyy}</title>
    <link href='https://fonts.googleapis.com/css2?family=Roboto:wght@300;400;500;700&display=swap' rel='stylesheet'>
    <style>
        :root {{
            --primary-color: #4f46e5;
            --text-dark: #1e293b;
            --text-gray: #64748b;
        }}
        body {{
            font-family: 'Roboto', sans-serif;
            margin: 0;
            padding: 20px;
            color: var(--text-dark);
            font-size: 11px;
            background: #fff;
        }}
        .container {{
            max-width: 1000px;
            margin: 0 auto;
        }}
        .header {{
            display: flex;
            justify-content: space-between;
            align-items: flex-start;
            border-bottom: 2px solid var(--primary-color);
            padding-bottom: 10px;
            margin-bottom: 20px;
        }}
        .company-info h1 {{
            margin: 0;
            font-size: 18px;
            color: var(--primary-color);
            text-transform: uppercase;
        }}
        .company-info p {{
            margin: 2px 0;
            color: var(--text-gray);
        }}
        .report-title {{
            text-align: right;
        }}
        .report-title h2 {{
            margin: 0;
            font-size: 16px;
            color: var(--text-dark);
        }}
        .report-title p {{
            margin: 2px 0;
            font-weight: bold;
        }}
        .stats-grid {{
            display: flex;
            gap: 15px;
            margin-bottom: 20px;
        }}
        .stat-box {{
            flex: 1;
            background: #f8fafc;
            border: 1px solid #e2e8f0;
            padding: 10px;
            border-radius: 8px;
            text-align: center;
        }}
        .stat-box label {{
            display: block;
            font-size: 9px;
            color: var(--text-gray);
            text-transform: uppercase;
            margin-bottom: 3px;
        }}
        .stat-box span {{
            font-size: 14px;
            font-weight: 700;
            color: var(--primary-color);
        }}
        .inventory-table {{
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }}
        .inventory-table th {{
            background: var(--primary-color);
            color: white;
            padding: 8px;
            text-align: left;
            text-transform: uppercase;
            font-size: 9px;
        }}
        .inventory-table td {{
            padding: 6px 8px;
            border-bottom: 1px solid #f1f5f9;
        }}
        .inventory-table tr:nth-child(even) {{
            background: #fcfcfc;
        }}
        .inventory-table tr:hover {{
            background: #f1f5f9;
        }}
        .text-right {{
            text-align: right !important;
        }}
        .text-center {{
            text-align: center !important;
        }}
        .stock-badge {{
            padding: 2px 6px;
            border-radius: 4px;
            font-weight: 700;
        }}
        .low-stock {{
            background: #fee2e2;
            color: #991b1b;
        }}
        .normal-stock {{
            background: #dcfce7;
            color: #166534;
        }}
        .footer {{
            margin-top: 30px;
            padding-top: 10px;
            border-top: 1px dashed #cbd5e1;
            font-size: 8px;
            color: var(--text-gray);
            text-align: center;
        }}
        .actions-no-print {{
            position: fixed;
            bottom: 20px;
            right: 20px;
            display: flex;
            gap: 10px;
            z-index: 1000;
        }}
        .btn {{
            padding: 10px 20px;
            border-radius: 6px;
            border: none;
            color: white;
            cursor: pointer;
            font-weight: 700;
            text-decoration: none;
            font-size: 11px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
        }}
        .btn-print {{
            background: #4f46e5;
        }}
        @media print {{
            .actions-no-print {{
                display: none;
            }}
            body {{
                padding: 0;
            }}
        }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <div class='company-info'>
                <h1>{System.Net.WebUtility.HtmlEncode(nombreComercial)}</h1>
                <p><strong>Razón Social:</strong> {System.Net.WebUtility.HtmlEncode(razonSocial)}</p>
                <p><strong>RUC:</strong> {System.Net.WebUtility.HtmlEncode(ruc)}</p>
                <p><strong>DIR:</strong> {System.Net.WebUtility.HtmlEncode(direccion)}</p>
            </div>
            <div class='report-title'>
                <h2>CATÁLOGO DE INVENTARIO</h2>
                <p>FECHA: {DateTime.Now:dd/MM/yyyy HH:mm}</p>
            </div>
        </div>

        <div class='stats-grid'>
            <div class='stat-box'>
                <label>Total Items</label>
                <span>{totalItems}</span>
            </div>
            <div class='stat-box'>
                <label>Stock Total</label>
                <span>{totalStock:N0} Unidades</span>
            </div>
            <div class='stat-box'>
                <label>Valoración Estimada (Venta)</label>
                <span>${totalValorVenta:N2}</span>
            </div>
        </div>

        <table class='inventory-table'>
            <thead>
                <tr>
                    <th style='width: 120px;'>Código</th>
                    <th>Nombre del Producto</th>
                    <th style='width: 70px;' class='text-center'>Stock</th>
                    <th style='width: 70px;' class='text-right'>Precio Venta</th>
                    <th style='width: 70px;' class='text-right'>Total Est.</th>
                </tr>
            </thead>
            <tbody>
                {rowsHtml}
            </tbody>
        </table>

        <div class='footer'>
            Reporte de catálogo generado automáticamente por el sistema LogiPharm POS.
        </div>
    </div>

    <div class='actions-no-print'>
        <button onclick='window.print()' class='btn btn-print'>Imprimir / Guardar a PDF</button>
    </div>
</body>
</html>";

                string exportsDir = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Exports");
                if (!System.IO.Directory.Exists(exportsDir))
                {
                    System.IO.Directory.CreateDirectory(exportsDir);
                }

                string filePath = System.IO.Path.Combine(exportsDir, $"Catalogo_Productos_{DateTime.Now:yyyyMMdd_HHmmss}.html");
                System.IO.File.WriteAllText(filePath, htmlContent, System.Text.Encoding.UTF8);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(filePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el catálogo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarEstadisticas()
        {
            try
            {
                int total, enStock, stockBajo, totalCategorias;
                new DProductos().ObtenerEstadisticasProductos(out total, out enStock, out stockBajo, out totalCategorias);

                if (lblTotalVal != null) lblTotalVal.Text = total.ToString("N0");
                if (lblEnStockVal != null) lblEnStockVal.Text = enStock.ToString("N0");
                if (lblStockBajoVal != null) lblStockBajoVal.Text = stockBajo.ToString("N0");
                if (lblCategoriasVal != null) lblCategoriasVal.Text = totalCategorias.ToString("N0");
            }
            catch { }
        }

        private Guna.UI2.WinForms.Guna2Panel CrearTarjetaEstadistica(string titulo, string valorInicial, Color bg, Color border, Color textColor, out Label lblVal)
        {
            var card = new Guna.UI2.WinForms.Guna2Panel
            {
                Dock = DockStyle.Fill,
                FillColor = bg,
                BorderColor = border,
                BorderThickness = 1,
                BorderRadius = 8,
                Padding = new Padding(10, 8, 10, 8)
            };

            var table = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = Color.Transparent
            };
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));

            var lblTitle = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI Semibold", 8.5F),
                ForeColor = Color.FromArgb(100, 116, 139),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.BottomLeft
            };

            lblVal = new Label
            {
                Text = valorInicial,
                Font = new Font("Segoe UI Black", 16F, FontStyle.Bold),
                ForeColor = textColor,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopLeft
            };

            table.Controls.Add(lblTitle, 0, 0);
            table.Controls.Add(lblVal, 0, 1);
            card.Controls.Add(table);

            return card;
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
        private async void menuNuevoProducto_Click(object sender, EventArgs e)
        {
            // Abrir FrmEditarProducto en modo creación (sin ID)
            using (var frm = new FrmEditarProducto())
            {
                // Auditoría: VISUALIZAR formulario nuevo
                try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Productos", "VISUALIZAR", "productos", null, "Abrir formulario nuevo producto", null, Environment.MachineName, "UI"); } catch { }

                DialogResult resultado = frm.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    await ResetearListadoAsync(_criterioActual);
                    MessageBox.Show("Producto creado exitosamente. Lista actualizada.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Auditoría: CREAR
                    try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Productos", "CREAR", "productos", null, "Producto creado desde editor", null, Environment.MachineName, "UI"); } catch { }
                }
            }
        }

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
        private void DgvListado_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = DgvListado.Columns[e.ColumnIndex].Name;
            bool esIconoAccion = (colName == "colEditar" || colName == "colEliminar");

            if (esIconoAccion)
            {
                DgvListado.Cursor = Cursors.Hand;
                if (e.RowIndex != _hoverRow || e.ColumnIndex != _hoverCol)
                {
                    int prevR = _hoverRow, prevC = _hoverCol;
                    _hoverRow = e.RowIndex;
                    _hoverCol = e.ColumnIndex;
                    if (prevR >= 0 && prevC >= 0) DgvListado.InvalidateCell(prevC, prevR);
                    DgvListado.InvalidateCell(e.ColumnIndex, e.RowIndex);
                }
            }
            else
            {
                if (_hoverRow != -1 || _hoverCol != -1)
                {
                    int r = _hoverRow, c = _hoverCol;
                    _hoverRow = -1;
                    _hoverCol = -1;
                    if (r >= 0 && c >= 0) DgvListado.InvalidateCell(c, r);
                }
                DgvListado.Cursor = Cursors.Default;
            }
        }

        private void DgvListado_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (_hoverRow != -1 || _hoverCol != -1)
            {
                int r = _hoverRow, c = _hoverCol;
                _hoverRow = -1;
                _hoverCol = -1;
                if (r >= 0 && c >= 0 && r < DgvListado.RowCount && c < DgvListado.ColumnCount)
                {
                    DgvListado.InvalidateCell(c, r);
                }
            }
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

                        // Auditoría: ELIMINAR (simulada)
                        try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Productos", "ELIMINAR", "productos", idProducto, "Eliminación de producto (simulada)", null, Environment.MachineName, "UI"); } catch { }

                        // Refrescar listado desde el inicio
                        _ = ResetearListadoAsync(_criterioActual);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el producto: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Helper para rectángulo redondeado
        private static System.Drawing.Drawing2D.GraphicsPath MakeRoundRect(Rectangle r, int radius)
        {
            int d = radius * 2;
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        // --- Pines y botones modernos ---
        private void DgvListado_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = DgvListado.Columns[e.ColumnIndex].Name;

            if (colName == "colStatus")
            {
                e.PaintBackground(e.CellBounds, true);

                bool esActivo = Convert.ToBoolean(DgvListado.Rows[e.RowIndex].Cells["Activo"].Value);
                Color statusColor = esActivo ? Color.FromArgb(32, 201, 151) : Color.FromArgb(220, 53, 69); // Verde teal o Rojo

                int circleSize = 12;
                int x = e.CellBounds.Left + (e.CellBounds.Width - circleSize) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - circleSize) / 2;

                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (SolidBrush brush = new SolidBrush(statusColor))
                {
                    e.Graphics.FillEllipse(brush, new Rectangle(x, y, circleSize, circleSize));
                }

                e.Handled = true;
            }
            else if (colName == "colEditar" || colName == "colEliminar")
            {
                e.PaintBackground(e.CellBounds, true);

                var g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                int pad = 6;
                int size = Math.Min(e.CellBounds.Height - pad * 2, e.CellBounds.Width - pad * 2);
                int x = e.CellBounds.X + (e.CellBounds.Width - size) / 2;
                int y = e.CellBounds.Y + (e.CellBounds.Height - size) / 2;
                var pill = new Rectangle(x, y, size, size);

                bool hover = (e.RowIndex == _hoverRow && e.ColumnIndex == _hoverCol);
                Color baseColor = (colName == "colEliminar") ? Color.FromArgb(231, 76, 60) : Color.FromArgb(52, 152, 219);
                Color fill = hover ? ControlPaint.Light(baseColor, 0.15f) : baseColor;
                Color line = ControlPaint.Dark(fill);

                using (var path = MakeRoundRect(pill, size / 2))
                using (var sb = new SolidBrush(fill))
                using (var pen = new Pen(line, 1))
                {
                    g.FillPath(sb, path);
                    g.DrawPath(pen, path);
                }

                Image icon = (colName == "colEliminar") ? Properties.Resources.ic_delete : Properties.Resources.boligrafo;
                int iconSize = Math.Max(14, size - 12);
                var iconRect = new Rectangle(
                    pill.X + (pill.Width - iconSize) / 2,
                    pill.Y + (pill.Height - iconSize) / 2,
                    iconSize,
                    iconSize
                );

                if (icon != null)
                {
                    g.DrawImage(icon, iconRect);
                }

                e.Handled = true;
            }
        }

        // --- Colores por stock ---
        private void DgvListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

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

        // --- Scroll: cargar más ---
        private async void DgvListado_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation != ScrollOrientation.VerticalScroll) return;
            await TryLoadMoreAsync();
        }

        private async Task TryLoadMoreAsync()
        {
            if (_isLoading || _allLoaded || DgvListado.RowCount == 0) return;

            int first = DgvListado.FirstDisplayedScrollingRowIndex;
            if (first < 0) return;
            int visible = DgvListado.DisplayedRowCount(false);
            int bottomIndex = first + visible;
            if (bottomIndex >= DgvListado.RowCount - 2) // cerca del final
            {
                await CargarPaginaAsync();
            }
        }

        // --- Botón "Listar/Refrescar" ---
        private async void iconButton4_Click(object sender, EventArgs e)
        {
            await ResetearListadoAsync(_criterioActual);

            // Auditoría: VISUALIZAR (refrescar list)
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Productos", "VISUALIZAR", "productos", null, "Refrescar listado de productos", null, Environment.MachineName, "UI"); } catch { }
        }

        private void DgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var colName = DgvListado.Columns[e.ColumnIndex].Name;
            if (colName == "colEditar" || colName == "colEliminar" || colName == "colStatus")
                return;

            AbrirFormularioEditarProducto();
        }

        private void iconButton2_Click(object sender, EventArgs e) => AbrirFormularioEditarProducto();

        private async void AbrirFormularioEditarProducto()
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
                    // Auditoría: VISUALIZAR detalle
                    try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Productos", "VISUALIZAR", "productos", idProductoSeleccionado, "Abrir detalle de producto", null, Environment.MachineName, "UI"); } catch { }

                    DialogResult resultado = frm.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        await ResetearListadoAsync(_criterioActual);
                        MessageBox.Show("Producto actualizado. Refrescando lista...");

                        // Auditoría: EDITAR
                        try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Productos", "EDITAR", "productos", idProductoSeleccionado, "Producto editado desde editor", null, Environment.MachineName, "UI"); } catch { }
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
                    _ = ResetearListadoAsync(_criterioActual);

                    // Auditoría: CREAR
                    try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Productos", "CREAR", "productos", null, $"Creación de producto '{nuevo.Nombre}'", null, Environment.MachineName, "UI"); } catch { }
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

        // --- Listado con carga incremental ---
        private async Task ResetearListadoAsync(string criterio)
        {
            _criterioActual = string.IsNullOrWhiteSpace(criterio) ? null : criterio.Trim();
            _offset = 0;
            _allLoaded = false;
            _tablaProductos = null;
            DgvListado.DataSource = null;

            // Total with filters
            var d = new DProductos();
            _totalRegistros = d.ContarProductosFiltrado(_criterioActual, _filtroCategoria, _filtroLaboratorio);

            // Automatically refresh global stats on lists reload
            ActualizarEstadisticas();

            await CargarPaginaAsync(true);
        }

        private async Task CargarPaginaAsync(bool esPrimera = false)
        {
            if (_isLoading || _allLoaded) return;
            _isLoading = true;

            // Guardar posición del scroll antes de cargar
            int firstDisplayedRow = -1;
            if (DgvListado.FirstDisplayedScrollingRowIndex >= 0 && !esPrimera)
            {
                firstDisplayedRow = DgvListado.FirstDisplayedScrollingRowIndex;
            }

            try
            {
                DataTable pagina;
                var d = new DProductos();
                await Task.Yield(); // ceder UI

                pagina = d.ListarProductosFiltradoPaginado(_criterioActual, _filtroCategoria, _filtroLaboratorio, _offset, _pageSize);

                if (pagina == null || pagina.Rows.Count == 0)
                {
                    _allLoaded = true;
                    return;
                }

                if (_tablaProductos == null)
                {
                    _tablaProductos = pagina.Clone(); // misma estructura
                    _tablaProductos.Locale = System.Globalization.CultureInfo.CurrentCulture;
                }

                // Desuscribir eventos temporalmente para evitar disparos durante la carga
                DgvListado.Scroll -= DgvListado_Scroll;
                
                foreach (DataRow r in pagina.Rows)
                {
                    _tablaProductos.ImportRow(r);
                }
                _offset += pagina.Rows.Count;
                if (_offset >= _totalRegistros) _allLoaded = true;

                if (DgvListado.DataSource == null)
                {
                    DgvListado.DataSource = _tablaProductos;
                    DgvListado.RowHeadersVisible = false;
                    if (DgvListado.Columns["ID"] != null)
                        DgvListado.Columns["ID"].Visible = false;
                    EnsureActionColumns();
                }
                else
                {
                    // Notificar cambios sin perder posición
                    var cm = (CurrencyManager)BindingContext[DgvListado.DataSource];
                    cm.Refresh();
                }

                lblTotal.Text = $"Total: {_totalRegistros} | Mostrando: {DgvListado.Rows.Count}";

                // Restaurar posición del scroll
                if (firstDisplayedRow >= 0 && firstDisplayedRow < DgvListado.Rows.Count)
                {
                    try
                    {
                        DgvListado.FirstDisplayedScrollingRowIndex = firstDisplayedRow;
                    }
                    catch { /* ignorar si la fila ya no existe */ }
                }

                // Reactivar eventos
                DgvListado.Scroll += DgvListado_Scroll;

                // Prefetch: si faltan <=10 filas para llegar al final, comenzar siguiente carga en background
                if (!_allLoaded && DgvListado.RowCount - (DgvListado.FirstDisplayedScrollingRowIndex + DgvListado.DisplayedRowCount(false)) <= 10)
                {
                    _ = Task.Run(async () => await CargarPaginaAsync());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _allLoaded = true; // evitar bucles
            }
            finally
            {
                _isLoading = false;
                // Asegurar que el evento está conectado
                DgvListado.Scroll -= DgvListado_Scroll;
                DgvListado.Scroll += DgvListado_Scroll;
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            _debounceTimer.Stop();
            await EjecutarBusquedaDebouncedAsync();
        }

        // --- Columnas de acción con PNG ---
        private void EnsureActionColumns()
        {
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
