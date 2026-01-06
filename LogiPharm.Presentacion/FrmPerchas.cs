using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmPerchas : Form
    {
        private DPerchas datosPerchas;

        public FrmPerchas()
        {
            InitializeComponent();
            datosPerchas = new DPerchas();
            this.Load += FrmPerchas_Load;
        }

        private void FrmPerchas_Load(object sender, EventArgs e)
        {
            // Auditoría: VISUALIZAR
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Inventario", "VISUALIZAR", "perchas", null, "Abrir Gestión de Perchas", null, Environment.MachineName, "UI"); } catch { }

            ConfigurarGrids();
            CargarSecciones();
            
            // Conectar eventos
            btnNuevo.Click += BtnNuevo_Click;
            btnEditar.Click += BtnEditar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnAsignarProducto.Click += BtnAsignarProducto_Click;
            btnBuscar.Click += BtnBuscar_Click;
            dgvPerchas.SelectionChanged += DgvPerchas_SelectionChanged;
            txtBusqueda.KeyPress += TxtBusqueda_KeyPress;

            // Cargar datos iniciales
            CargarPerchas();
        }

        private void ConfigurarGrids()
        {
            // Configurar grid principal de perchas
            dgvPerchas.AutoGenerateColumns = false;
            dgvPerchas.Columns.Clear();

            dgvPerchas.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "Id", 
                DataPropertyName = "Id", 
                Visible = false 
            });

            dgvPerchas.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "Nombre", 
                DataPropertyName = "Nombre", 
                HeaderText = "Nombre", 
                Width = 120 
            });

            dgvPerchas.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "Descripcion", 
                DataPropertyName = "Descripcion", 
                HeaderText = "Descripción", 
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill 
            });

            dgvPerchas.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "SeccionNombre", 
                DataPropertyName = "SeccionNombre", 
                HeaderText = "Sección", 
                Width = 120 
            });

            dgvPerchas.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "Filas", 
                DataPropertyName = "Filas", 
                HeaderText = "Filas", 
                Width = 60,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvPerchas.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "Columnas", 
                DataPropertyName = "Columnas", 
                HeaderText = "Cols", 
                Width = 60,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvPerchas.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "ProductosAsignados", 
                DataPropertyName = "ProductosAsignados", 
                HeaderText = "Productos", 
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvPerchas.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "EspaciosDisponibles", 
                DataPropertyName = "EspaciosDisponibles", 
                HeaderText = "Disponibles", 
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // Configurar grid de productos
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.Columns.Clear();

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "Codigo", 
                DataPropertyName = "Codigo", 
                HeaderText = "Código", 
                Width = 120 
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "Producto", 
                DataPropertyName = "Producto", 
                HeaderText = "Producto", 
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill 
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "Fila", 
                DataPropertyName = "Fila", 
                HeaderText = "Fila", 
                Width = 50,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "Columna", 
                DataPropertyName = "Columna", 
                HeaderText = "Col", 
                Width = 50,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "Stock", 
                DataPropertyName = "Stock", 
                HeaderText = "Stock", 
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter, Format = "N0" }
            });
        }

        private void CargarSecciones()
        {
            try
            {
                var dt = datosPerchas.ListarSecciones();
                
                cboSeccion.DataSource = null;
                cboSeccion.Items.Clear();
                
                // Agregar opción "Todas"
                DataRow drTodas = dt.NewRow();
                drTodas["Id"] = 0;
                drTodas["Nombre"] = "TODAS LAS SECCIONES";
                dt.Rows.InsertAt(drTodas, 0);
                
                cboSeccion.DataSource = dt;
                cboSeccion.DisplayMember = "Nombre";
                cboSeccion.ValueMember = "Id";
                cboSeccion.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar secciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPerchas()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string busqueda = txtBusqueda.Text.Trim();
                int? seccionId = null;
                
                if (cboSeccion.SelectedValue != null && Convert.ToInt32(cboSeccion.SelectedValue) > 0)
                    seccionId = Convert.ToInt32(cboSeccion.SelectedValue);

                var dt = datosPerchas.ListarPerchas(busqueda, seccionId);
                dgvPerchas.DataSource = dt;

                lblTotalRegistros.Text = $"Total de Registros: {dt.Rows.Count}";

                // Colorear filas según disponibilidad
                foreach (DataGridViewRow row in dgvPerchas.Rows)
                {
                    if (row.Cells["EspaciosDisponibles"].Value != null)
                    {
                        int disponibles = Convert.ToInt32(row.Cells["EspaciosDisponibles"].Value);
                        int capacidad = Convert.ToInt32(row.Cells["Filas"].Value) * Convert.ToInt32(row.Cells["Columnas"].Value);
                        
                        double porcentaje = (double)disponibles / capacidad * 100;
                        
                        if (porcentaje <= 10) // Menos del 10% disponible
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 224, 224);
                        else if (porcentaje <= 30) // Menos del 30% disponible
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 204);
                    }
                }

                LimpiarDetalle();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar perchas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargarPerchas();
        }

        private void TxtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                CargarPerchas();
            }
        }

        private void DgvPerchas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPerchas.CurrentRow == null)
            {
                LimpiarDetalle();
                return;
            }

            try
            {
                var drv = dgvPerchas.CurrentRow.DataBoundItem as DataRowView;
                if (drv == null) return;

                int perchaId = Convert.ToInt32(drv["Id"]);

                // Mostrar información de la percha
                lblSeccion.Text = drv["SeccionNombre"]?.ToString() ?? "Sin sección";
                
                int filas = Convert.ToInt32(drv["Filas"]);
                int columnas = Convert.ToInt32(drv["Columnas"]);
                int capacidad = filas * columnas;
                lblCapacidad.Text = $"{capacidad} espacios ({filas} x {columnas})";
                
                int productosAsignados = Convert.ToInt32(drv["ProductosAsignados"]);
                lblProductosAsignados.Text = $"{productosAsignados} productos";
                
                int espaciosDisponibles = Convert.ToInt32(drv["EspaciosDisponibles"]);
                lblEspaciosDisponibles.Text = $"{espaciosDisponibles} espacios libres";

                // Cambiar color según disponibilidad
                double porcentaje = (double)espaciosDisponibles / capacidad * 100;
                if (porcentaje <= 10)
                    lblEspaciosDisponibles.ForeColor = Color.Red;
                else if (porcentaje <= 30)
                    lblEspaciosDisponibles.ForeColor = Color.Orange;
                else
                    lblEspaciosDisponibles.ForeColor = Color.Green;

                // Cargar productos en la percha
                var dtProductos = datosPerchas.ObtenerProductosEnPercha(perchaId);
                dgvProductos.DataSource = dtProductos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar detalles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarDetalle();
            }
        }

        private void LimpiarDetalle()
        {
            lblSeccion.Text = "...";
            lblCapacidad.Text = "...";
            lblProductosAsignados.Text = "...";
            lblEspaciosDisponibles.Text = "...";
            lblEspaciosDisponibles.ForeColor = Color.FromArgb(64, 64, 64);
            dgvProductos.DataSource = null;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmPerchaEditor(null))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarPerchas();
                    MessageBox.Show("Percha creada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPerchas.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una percha para editar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var drv = dgvPerchas.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) return;

            int perchaId = Convert.ToInt32(drv["Id"]);

            using (var frm = new FrmPerchaEditor(perchaId))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarPerchas();
                    MessageBox.Show("Percha actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPerchas.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una percha para eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var drv = dgvPerchas.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) return;

            int perchaId = Convert.ToInt32(drv["Id"]);
            string nombrePercha = drv["Nombre"]?.ToString();

            var confirmacion = MessageBox.Show(
                $"¿Está seguro que desea eliminar la percha '{nombrePercha}'?\n\nNOTA: Solo se pueden eliminar perchas sin productos asignados.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion != DialogResult.Yes) return;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                bool resultado = datosPerchas.EliminarPercha(perchaId);

                if (resultado)
                {
                    MessageBox.Show("Percha eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Auditoría
                    try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Inventario", "ELIMINAR", "perchas", perchaId, $"Eliminar percha {nombrePercha}", null, Environment.MachineName, "UI"); } catch { }
                    
                    CargarPerchas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar percha: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnAsignarProducto_Click(object sender, EventArgs e)
        {
            if (dgvPerchas.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una percha para asignar productos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var drv = dgvPerchas.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) return;

            int perchaId = Convert.ToInt32(drv["Id"]);
            string nombrePercha = drv["Nombre"]?.ToString();

            using (var frm = new FrmAsignarProductoPercha(perchaId))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarPerchas();
                    
                    // Refrescar la selección actual para ver los productos actualizados
                    DgvPerchas_SelectionChanged(null, EventArgs.Empty);
                }
            }
        }
    }
}
