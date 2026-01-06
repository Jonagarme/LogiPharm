using System;
using System.Data;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmAsignarProductoPercha : Form
    {
        private int perchaId;
        private EPercha percha;
        private DPerchas datosPerchas;
        private int? productoSeleccionadoId;

        public FrmAsignarProductoPercha(int idPercha)
        {
            InitializeComponent();
            perchaId = idPercha;
            datosPerchas = new DPerchas();
            
            this.Load += FrmAsignarProductoPercha_Load;
            this.KeyPreview = true;
        }

        private void FrmAsignarProductoPercha_Load(object sender, EventArgs e)
        {
            percha = datosPerchas.ObtenerPercha(perchaId);
            
            if (percha == null)
            {
                MessageBox.Show("No se pudo cargar la información de la percha.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            CargarInformacionPercha();
            ConfigurarGrid();
            
            // Configurar límites de fila y columna
            numFila.Maximum = percha.Filas;
            numColumna.Maximum = percha.Columnas;
            
            // Eventos
            txtBusqueda.TextChanged += TxtBusqueda_TextChanged;
            txtBusqueda.KeyDown += TxtBusqueda_KeyDown;
            dgvProductos.SelectionChanged += DgvProductos_SelectionChanged;
            dgvProductos.DoubleClick += DgvProductos_DoubleClick;
            btnAsignar.Click += BtnAsignar_Click;
            btnCancelar.Click += (s, ev) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            this.KeyDown += FrmAsignarProductoPercha_KeyDown;
        }

        private void FrmAsignarProductoPercha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                txtBusqueda.Focus();
                txtBusqueda.SelectAll();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void CargarInformacionPercha()
        {
            lblPercha.Text = $"{percha.Nombre} - {percha.Descripcion}";
            lblCapacidad.Text = $"{percha.Filas} filas × {percha.Columnas} columnas = {percha.Filas * percha.Columnas} espacios";
        }

        private void ConfigurarGrid()
        {
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.Columns.Clear();

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "Id", 
                DataPropertyName = "Id", 
                Visible = false 
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "Codigo", 
                DataPropertyName = "Codigo", 
                HeaderText = "Código", 
                Width = 120 
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "Nombre", 
                DataPropertyName = "Nombre", 
                HeaderText = "Producto", 
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill 
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "Stock", 
                DataPropertyName = "Stock", 
                HeaderText = "Stock", 
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "Categoria", 
                DataPropertyName = "Categoria", 
                HeaderText = "Categoría", 
                Width = 120 
            });
        }

        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text.Length >= 3)
            {
                BuscarProductos();
            }
            else
            {
                dgvProductos.DataSource = null;
                lblProductoSeleccionado.Text = "Seleccione un producto de la lista";
                productoSeleccionadoId = null;
            }
        }

        private void TxtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtBusqueda.Text.Length >= 3)
            {
                e.Handled = true;
                BuscarProductos();
                
                if (dgvProductos.Rows.Count > 0)
                {
                    dgvProductos.Focus();
                    dgvProductos.Rows[0].Selected = true;
                }
            }
            else if (e.KeyCode == Keys.Down && dgvProductos.Rows.Count > 0)
            {
                dgvProductos.Focus();
                dgvProductos.Rows[0].Selected = true;
                e.Handled = true;
            }
        }

        private void BuscarProductos()
        {
            try
            {
                var dt = datosPerchas.BuscarProductosDisponibles(txtBusqueda.Text.Trim());
                dgvProductos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null) return;

            var drv = dgvProductos.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) return;

            productoSeleccionadoId = Convert.ToInt32(drv["Id"]);
            string codigo = drv["Codigo"]?.ToString();
            string nombre = drv["Nombre"]?.ToString();
            
            lblProductoSeleccionado.Text = $"{codigo} - {nombre}";
        }

        private void DgvProductos_DoubleClick(object sender, EventArgs e)
        {
            if (productoSeleccionadoId.HasValue)
            {
                numFila.Focus();
            }
        }

        private void BtnAsignar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            try
            {
                var ubicacion = new EUbicacionProducto
                {
                    PerchaId = perchaId,
                    ProductoId = productoSeleccionadoId.Value,
                    Fila = (int)numFila.Value,
                    Columna = (int)numColumna.Value,
                    Observaciones = txtObservaciones.Text.Trim(),
                    Activo = true,
                    FechaUbicacion = DateTime.Now,
                    UsuarioUbicacionId = SesionActual.IdUsuario
                };

                bool resultado = datosPerchas.AsignarProductoPercha(ubicacion);

                if (resultado)
                {
                    MessageBox.Show(
                        $"Producto asignado correctamente a la posición (Fila {ubicacion.Fila}, Columna {ubicacion.Columna})",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Auditoría
                    try
                    {
                        new DBitacora().Registrar(
                            SesionActual.IdUsuario,
                            SesionActual.NombreUsuario,
                            "Inventario",
                            "ASIGNAR",
                            "productos_ubicacionproducto",
                            ubicacion.ProductoId,
                            $"Asignar producto {lblProductoSeleccionado.Text} a percha {percha.Nombre} en posición ({ubicacion.Fila},{ubicacion.Columna})",
                            null,
                            Environment.MachineName,
                            "UI"
                        );
                    }
                    catch { }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al asignar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarFormulario()
        {
            if (!productoSeleccionadoId.HasValue)
            {
                MessageBox.Show("Debe seleccionar un producto de la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBusqueda.Focus();
                return false;
            }

            if (numFila.Value < 1 || numFila.Value > percha.Filas)
            {
                MessageBox.Show($"La fila debe estar entre 1 y {percha.Filas}.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numFila.Focus();
                return false;
            }

            if (numColumna.Value < 1 || numColumna.Value > percha.Columnas)
            {
                MessageBox.Show($"La columna debe estar entre 1 y {percha.Columnas}.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numColumna.Focus();
                return false;
            }

            return true;
        }
    }
}
