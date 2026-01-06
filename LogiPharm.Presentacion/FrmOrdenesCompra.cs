using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmOrdenesCompra : Form
    {
        private DataTable _tablaOrdenes;
        private int _pageSize = 50;
        private int _offset = 0;
        private bool _isLoading = false;
        private bool _allLoaded = false;
        private string _criterioActual = null;
        private int _totalRegistros = -1;
        private System.Windows.Forms.Timer _debounceTimer;

        public FrmOrdenesCompra()
        {
            InitializeComponent();

            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null, dgvOrdenes, new object[] { true });

            dgvOrdenes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrdenes.MultiSelect = false;
            dgvOrdenes.AllowUserToAddRows = false;
            dgvOrdenes.RowHeadersVisible = false;
            dgvOrdenes.RowTemplate.Height = Math.Max(dgvOrdenes.RowTemplate.Height, 32);

            _debounceTimer = new System.Windows.Forms.Timer { Interval = 300 };
            _debounceTimer.Tick += async (s, e) =>
            {
                _debounceTimer.Stop();
                await EjecutarBusquedaDebouncedAsync();
            };
        }

        private async void FrmOrdenesCompra_Load(object sender, EventArgs e)
        {
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            await ResetearListadoAsync(null);

            try
            {
                new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario,
                    "Compras", "VISUALIZAR", "ordenes_compra", null,
                    "Abrir listado de órdenes de compra", null, Environment.MachineName, "UI");
            }
            catch { }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            _debounceTimer.Stop();
            _debounceTimer.Start();
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

        private async Task EjecutarBusquedaDebouncedAsync()
        {
            string criterio = txtBuscar.Text.Trim();
            if (string.IsNullOrWhiteSpace(criterio))
                await ResetearListadoAsync(null);
            else
                await ResetearListadoAsync(criterio);
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            _debounceTimer.Stop();
            await EjecutarBusquedaDebouncedAsync();
        }

        private async void btnRefrescar_Click(object sender, EventArgs e)
        {
            await ResetearListadoAsync(_criterioActual);

            try
            {
                new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario,
                    "Compras", "VISUALIZAR", "ordenes_compra", null,
                    "Refrescar listado de órdenes de compra", null, Environment.MachineName, "UI");
            }
            catch { }
        }

        private async void btnNuevaOrden_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmNuevaOrdenCompra())
            {
                try
                {
                    new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario,
                        "Compras", "VISUALIZAR", "ordenes_compra", null,
                        "Abrir formulario nueva orden de compra", null, Environment.MachineName, "UI");
                }
                catch { }

                DialogResult resultado = frm.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    await ResetearListadoAsync(_criterioActual);
                    MessageBox.Show("Orden de compra creada exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario,
                            "Compras", "CREAR", "ordenes_compra", null,
                            "Orden de compra creada", null, Environment.MachineName, "UI");
                    }
                    catch { }
                }
            }
        }

        private async Task ResetearListadoAsync(string criterio)
        {
            _criterioActual = string.IsNullOrWhiteSpace(criterio) ? null : criterio.Trim();
            _offset = 0;
            _allLoaded = false;
            _tablaOrdenes = null;
            dgvOrdenes.DataSource = null;

            var d = new DOrdenesCompra();
            _totalRegistros = _criterioActual == null ? d.ContarOrdenes() : d.ContarOrdenesBusqueda(_criterioActual);

            await CargarPaginaAsync(true);
        }

        private async Task CargarPaginaAsync(bool esPrimera = false)
        {
            if (_isLoading || _allLoaded) return;
            _isLoading = true;

            int firstDisplayedRow = -1;
            if (dgvOrdenes.FirstDisplayedScrollingRowIndex >= 0 && !esPrimera)
            {
                firstDisplayedRow = dgvOrdenes.FirstDisplayedScrollingRowIndex;
            }

            try
            {
                DataTable pagina;
                var d = new DOrdenesCompra();
                await Task.Yield();

                if (_criterioActual == null)
                    pagina = d.ListarOrdenesPaginado(_offset, _pageSize);
                else
                    pagina = d.BuscarOrdenesPaginado(_criterioActual, _offset, _pageSize);

                if (pagina == null || pagina.Rows.Count == 0)
                {
                    _allLoaded = true;
                    return;
                }

                if (_tablaOrdenes == null)
                {
                    _tablaOrdenes = pagina.Clone();
                    _tablaOrdenes.Locale = System.Globalization.CultureInfo.CurrentCulture;
                }

                dgvOrdenes.Scroll -= dgvOrdenes_Scroll;

                foreach (DataRow r in pagina.Rows)
                {
                    _tablaOrdenes.ImportRow(r);
                }
                _offset += pagina.Rows.Count;
                if (_offset >= _totalRegistros) _allLoaded = true;

                if (dgvOrdenes.DataSource == null)
                {
                    dgvOrdenes.DataSource = _tablaOrdenes;
                    dgvOrdenes.RowHeadersVisible = false;
                    if (dgvOrdenes.Columns["Id"] != null)
                        dgvOrdenes.Columns["Id"].Visible = false;
                    ConfigurarColumnas();
                }
                else
                {
                    var cm = (System.Windows.Forms.CurrencyManager)BindingContext[dgvOrdenes.DataSource];
                    cm.Refresh();
                }

                lblTotal.Text = $"Total: {_totalRegistros} | Mostrando: {dgvOrdenes.Rows.Count}";

                if (firstDisplayedRow >= 0 && firstDisplayedRow < dgvOrdenes.Rows.Count)
                {
                    try
                    {
                        dgvOrdenes.FirstDisplayedScrollingRowIndex = firstDisplayedRow;
                    }
                    catch { }
                }

                dgvOrdenes.Scroll += dgvOrdenes_Scroll;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar órdenes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _allLoaded = true;
            }
            finally
            {
                _isLoading = false;
                dgvOrdenes.Scroll -= dgvOrdenes_Scroll;
                dgvOrdenes.Scroll += dgvOrdenes_Scroll;
            }
        }

        private void ConfigurarColumnas()
        {
            if (dgvOrdenes.Columns["colFechaEmision"] != null)
            {
                dgvOrdenes.Columns["colFechaEmision"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvOrdenes.Columns["colFechaEntrega"] != null)
            {
                dgvOrdenes.Columns["colFechaEntrega"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvOrdenes.Columns["colTotal"] != null)
            {
                dgvOrdenes.Columns["colTotal"].DefaultCellStyle.Format = "C2";
                dgvOrdenes.Columns["colTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private async void dgvOrdenes_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation != ScrollOrientation.VerticalScroll) return;
            await TryLoadMoreAsync();
        }

        private async Task TryLoadMoreAsync()
        {
            if (_isLoading || _allLoaded || dgvOrdenes.RowCount == 0) return;

            int first = dgvOrdenes.FirstDisplayedScrollingRowIndex;
            if (first < 0) return;
            int visible = dgvOrdenes.DisplayedRowCount(false);
            int bottomIndex = first + visible;
            if (bottomIndex >= dgvOrdenes.RowCount - 2)
            {
                await CargarPaginaAsync();
            }
        }

        private void dgvOrdenes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var colName = dgvOrdenes.Columns[e.ColumnIndex].Name;

            if (colName == "colEditar")
            {
                e.Value = Properties.Resources.boligrafo;
                e.FormattingApplied = true;
                return;
            }
            if (colName == "colVer")
            {
                e.Value = Properties.Resources.boligrafo;
                e.FormattingApplied = true;
                return;
            }
            if (colName == "colAnular")
            {
                e.Value = Properties.Resources.ic_delete;
                e.FormattingApplied = true;
                return;
            }

            if (colName == "colEstado")
            {
                string estado = dgvOrdenes.Rows[e.RowIndex].Cells["colEstado"].Value?.ToString();
                if (!string.IsNullOrEmpty(estado))
                {
                    switch (estado.ToUpper())
                    {
                        case "PENDIENTE":
                            e.CellStyle.BackColor = Color.FromArgb(255, 250, 230);
                            e.CellStyle.ForeColor = Color.FromArgb(200, 150, 0);
                            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                            break;
                        case "APROBADA":
                            e.CellStyle.BackColor = Color.FromArgb(230, 245, 255);
                            e.CellStyle.ForeColor = Color.FromArgb(0, 100, 200);
                            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                            break;
                        case "RECIBIDA":
                            e.CellStyle.BackColor = Color.FromArgb(230, 255, 230);
                            e.CellStyle.ForeColor = Color.FromArgb(0, 150, 0);
                            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                            break;
                        case "PARCIAL":
                            e.CellStyle.BackColor = Color.FromArgb(255, 245, 235);
                            e.CellStyle.ForeColor = Color.FromArgb(200, 100, 0);
                            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                            break;
                        case "CANCELADA":
                            e.CellStyle.BackColor = Color.FromArgb(255, 235, 238);
                            e.CellStyle.ForeColor = Color.FromArgb(200, 0, 0);
                            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                            break;
                    }
                }
            }
        }

        private async void dgvOrdenes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = dgvOrdenes.Columns[e.ColumnIndex].Name;
            long idOrden = Convert.ToInt64(dgvOrdenes.Rows[e.RowIndex].Cells["colId"].Value);

            if (nombreColumna == "colEditar")
            {
                using (var frm = new FrmNuevaOrdenCompra(idOrden))
                {
                    try
                    {
                        new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario,
                            "Compras", "VISUALIZAR", "ordenes_compra", idOrden,
                            "Abrir edición de orden de compra", null, Environment.MachineName, "UI");
                    }
                    catch { }

                    DialogResult resultado = frm.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        await ResetearListadoAsync(_criterioActual);
                        MessageBox.Show("Orden de compra actualizada exitosamente.");

                        try
                        {
                            new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario,
                                "Compras", "EDITAR", "ordenes_compra", idOrden,
                                "Orden de compra editada", null, Environment.MachineName, "UI");
                        }
                        catch { }
                    }
                }
            }
            else if (nombreColumna == "colVer")
            {
                using (var frm = new FrmNuevaOrdenCompra(idOrden, true))
                {
                    try
                    {
                        new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario,
                            "Compras", "VISUALIZAR", "ordenes_compra", idOrden,
                            "Ver detalle de orden de compra", null, Environment.MachineName, "UI");
                    }
                    catch { }

                    frm.ShowDialog();
                }
            }
            else if (nombreColumna == "colAnular")
            {
                var result = MessageBox.Show(
                    "¿Está seguro de que desea anular esta orden de compra?",
                    "Confirmar Anulación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var d = new DOrdenesCompra();
                        bool ok = d.AnularOrdenCompra(idOrden, SesionActual.IdUsuario);

                        if (ok)
                        {
                            MessageBox.Show("Orden de compra anulada exitosamente.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await ResetearListadoAsync(_criterioActual);

                            try
                            {
                                new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario,
                                    "Compras", "ELIMINAR", "ordenes_compra", idOrden,
                                    "Orden de compra anulada", null, Environment.MachineName, "UI");
                            }
                            catch { }
                        }
                        else
                        {
                            MessageBox.Show("No se pudo anular la orden de compra.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al anular la orden: " + ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
