using Guna.UI2.WinForms;
using LogiPharm.Datos;
using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LogiPharm.Presentacion
{
    public partial class FrmConfigProductoTransferencia : Form
    {
        private EProducto _productoSeleccionado;
        private int _ubicacionOrigenId;
        private EInventarioLote _loteSeleccionado;

        public EProducto ProductoSeleccionado => _productoSeleccionado;
        public EInventarioLote LoteSeleccionado => _loteSeleccionado;
        public decimal CantidadSeleccionada { get; private set; }

        public FrmConfigProductoTransferencia(int ubicacionOrigenId)
        {
            InitializeComponent();
            _ubicacionOrigenId = ubicacionOrigenId;
        }

        private void FrmConfigProductoTransferencia_Load(object sender, EventArgs e)
        {
            lblPasoActual.Text = "Buscar y seleccionar producto";
            txtBuscarProducto.Focus();
            
            // Configurar DataGridView de lotes
            ConfigurarGridLotes();
        }

        private void ConfigurarGridLotes()
        {
            dgvLotes.Columns.Clear();
            dgvLotes.AutoGenerateColumns = false;
            dgvLotes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLotes.MultiSelect = false;
            dgvLotes.ReadOnly = false; // Cambiar a false para permitir editar checkboxes
            dgvLotes.AllowUserToAddRows = false;
            dgvLotes.RowHeadersVisible = false;

            // Columna de selección (checkbox)
            var colSeleccionar = new DataGridViewCheckBoxColumn
            {
                Name = "colSeleccionar",
                HeaderText = "Selec.",
                Width = 50,
                ReadOnly = false
            };
            dgvLotes.Columns.Add(colSeleccionar);

            dgvLotes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLote",
                HeaderText = "Lote",
                DataPropertyName = "NumeroLote",
                Width = 120,
                ReadOnly = true
            });

            dgvLotes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCaducidad",
                HeaderText = "Caducidad",
                DataPropertyName = "FechaCaducidad",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                ReadOnly = true
            });

            dgvLotes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDias",
                HeaderText = "Días",
                DataPropertyName = "DiasParaCaducidad",
                Width = 60,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter },
                ReadOnly = true
            });

            dgvLotes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStock",
                HeaderText = "Stock Disponible",
                DataPropertyName = "StockDisponible",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight },
                ReadOnly = true
            });

            dgvLotes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEstado",
                HeaderText = "Estado",
                DataPropertyName = "Estado",
                Width = 100,
                ReadOnly = true
            });

            // Eventos
            dgvLotes.CellContentClick += DgvLotes_CellContentClick;
            dgvLotes.CellFormatting += DgvLotes_CellFormatting;
        }

        private void DgvLotes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Colorear según días para caducidad
            if (dgvLotes.Columns[e.ColumnIndex].Name == "colDias")
            {
                if (int.TryParse(e.Value?.ToString(), out int dias))
                {
                    if (dias < 30)
                        e.CellStyle.BackColor = Color.FromArgb(255, 235, 238);
                    else if (dias < 90)
                        e.CellStyle.BackColor = Color.FromArgb(255, 250, 230);
                    else
                        e.CellStyle.BackColor = Color.FromArgb(230, 245, 237);
                }
            }

            // Colorear estado
            if (dgvLotes.Columns[e.ColumnIndex].Name == "colEstado")
            {
                string estado = e.Value?.ToString();
                if (estado == "VIGENTE")
                    e.CellStyle.ForeColor = Color.FromArgb(0, 100, 0);
                else if (estado == "POR_CADUCAR")
                    e.CellStyle.ForeColor = Color.FromArgb(200, 100, 0);
            }
        }

        private void DgvLotes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            
            // Si se hace clic en el checkbox de selección
            if (dgvLotes.Columns[e.ColumnIndex].Name == "colSeleccionar")
            {
                // Desmarcar todas las demás filas
                foreach (DataGridViewRow row in dgvLotes.Rows)
                {
                    if (row.Index != e.RowIndex)
                        row.Cells["colSeleccionar"].Value = false;
                }
            }
        }

        private void txtBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BuscarProducto();
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }

        private void BuscarProducto()
        {
            string criterio = txtBuscarProducto.Text.Trim();
            if (string.IsNullOrWhiteSpace(criterio))
            {
                MessageBox.Show("Por favor, ingrese un código o nombre de producto para buscar.",
                    "Búsqueda requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBuscarProducto.Focus();
                return;
            }

            try
            {
                var dProductos = new DProductos();
                var productos = dProductos.BuscarProductosActivos(criterio);

                if (productos == null || productos.Count == 0)
                {
                    MessageBox.Show("No se encontraron productos que coincidan con el criterio de búsqueda.",
                        "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBuscarProducto.Focus();
                    return;
                }

                if (productos.Count == 1)
                {
                    SeleccionarProducto(productos[0]);
                }
                else
                {
                    // Abrir selector de productos
                    using (var frmSelector = new FrmSeleccionarProducto(productos))
                    {
                        if (frmSelector.ShowDialog() == DialogResult.OK)
                        {
                            SeleccionarProducto(frmSelector.ProductoSeleccionado);
                        }
                    }
                }

                // Auditoría
                try
                {
                    new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario,
                        "Transferencias", "VISUALIZAR", "inventario_transferenciastock", null,
                        $"Buscar producto '{criterio}' para transferencia", null,
                        Environment.MachineName, "UI");
                }
                catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar producto: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeleccionarProducto(EProducto producto)
        {
            _productoSeleccionado = producto;
            
            // Mostrar información del producto
            lblProductoNombre.Text = producto.Nombre;
            lblProductoCodigo.Text = $"Código: {producto.CodigoPrincipal}";
            
            // Obtener stock total disponible
            var dLotes = new DInventarioLotes();
            var stockTotal = dLotes.ObtenerStockTotalDisponible((int)producto.Id, _ubicacionOrigenId);
            lblStockTotal.Text = $"{stockTotal:N2} unid.";

            if (stockTotal > 0)
            {
                panelStockTotal.FillColor = Color.FromArgb(230, 245, 237);
                lblStockTotal.ForeColor = Color.FromArgb(0, 100, 0);
            }
            else
            {
                panelStockTotal.FillColor = Color.FromArgb(255, 235, 238);
                lblStockTotal.ForeColor = Color.FromArgb(192, 0, 0);
            }

            // Cambiar a paso 2
            lblPasoActual.Text = "PASO 1: Seleccionar Lote y Caducidad";
            
            // Cargar lotes disponibles
            CargarLotesDisponibles();
        }

        private void CargarLotesDisponibles()
        {
            try
            {
                var dLotes = new DInventarioLotes();
                var lotes = dLotes.ObtenerLotesDisponiblesPorProductoYUbicacion(
                    (int)_productoSeleccionado.Id, _ubicacionOrigenId);

                dgvLotes.DataSource = lotes;

                if (lotes.Count == 0)
                {
                    MessageBox.Show("No hay lotes disponibles para este producto en la ubicación de origen.",
                        "Sin lotes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Agregar columna de checkbox si no existe
                    if (!dgvLotes.Columns.Contains("colSeleccionar"))
                    {
                        dgvLotes.Columns.Insert(0, new DataGridViewCheckBoxColumn
                        {
                            Name = "colSeleccionar",
                            HeaderText = "Selec.",
                            Width = 50
                        });
                    }
                }

                // Habilitar controles de cantidad
                numCantidad.Enabled = lotes.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar lotes: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAgregarTransferencia_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (_productoSeleccionado == null)
            {
                MessageBox.Show("Por favor, seleccione un producto primero.",
                    "Producto requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuscarProducto.Focus();
                return;
            }

            // Verificar que hay un lote seleccionado
            bool loteSeleccionado = false;
            int indiceLoteSeleccionado = -1;

            for (int i = 0; i < dgvLotes.Rows.Count; i++)
            {
                var cell = dgvLotes.Rows[i].Cells["colSeleccionar"];
                if (cell.Value != null && Convert.ToBoolean(cell.Value))
                {
                    loteSeleccionado = true;
                    indiceLoteSeleccionado = i;
                    break;
                }
            }

            if (!loteSeleccionado)
            {
                MessageBox.Show("Por favor, seleccione un lote de la lista.",
                    "Lote requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar cantidad
            if (numCantidad.Value <= 0)
            {
                MessageBox.Show("Por favor, ingrese una cantidad mayor a cero.",
                    "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numCantidad.Focus();
                return;
            }

            // Obtener el lote seleccionado
            var lote = dgvLotes.Rows[indiceLoteSeleccionado].DataBoundItem as EInventarioLote;
            
            if (lote == null)
            {
                MessageBox.Show("Error al obtener información del lote seleccionado.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que la cantidad no exceda el stock disponible
            if (numCantidad.Value > lote.StockDisponible)
            {
                MessageBox.Show($"La cantidad ingresada ({numCantidad.Value:N2}) excede el stock disponible ({lote.StockDisponible:N2}).",
                    "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numCantidad.Value = lote.StockDisponible;
                numCantidad.Focus();
                return;
            }

            // Guardar selección
            _loteSeleccionado = lote;
            CantidadSeleccionada = numCantidad.Value;

            // Auditoría
            try
            {
                new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario,
                    "Transferencias", "CREAR", "inventario_transferenciastock", null,
                    $"Agregar producto '{_productoSeleccionado.Nombre}' lote '{lote.NumeroLote}' cantidad {CantidadSeleccionada}",
                    null, Environment.MachineName, "UI");
            }
            catch { }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
