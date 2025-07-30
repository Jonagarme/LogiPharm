using System;
using System.Collections.Generic;
using System.Drawing; // Necesario para los colores
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmAjusteInventario : Form
    {
        public FrmAjusteInventario()
        {
            InitializeComponent();
            // Asociamos el evento CellEndEdit una sola vez en el constructor
            dgvDetalleAjuste.CellEndEdit += dgvDetalleAjuste_CellEndEdit;
            // NUEVO: Suscribimos el evento KeyDown para poder usar la tecla Supr
            dgvDetalleAjuste.KeyDown += dgvDetalleAjuste_KeyDown;
        }

        private void FrmAjusteInventario_Load(object sender, EventArgs e)
        {
            ConfigurarEstadoFormulario(true);
            ConfigurarGridDetalle(); // Llamamos a la configuración mejorada
        }

        /// <summary>
        /// Configura la apariencia y las columnas del DataGridView para el detalle del ajuste.
        /// </summary>
        private void ConfigurarGridDetalle()
        {
            dgvDetalleAjuste.Columns.Clear();
            dgvDetalleAjuste.AutoGenerateColumns = false;

            // --- Estilos Visuales ---
            dgvDetalleAjuste.BorderStyle = BorderStyle.None;
            dgvDetalleAjuste.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(242, 242, 242);
            dgvDetalleAjuste.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDetalleAjuste.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dgvDetalleAjuste.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvDetalleAjuste.BackgroundColor = Color.White;
            dgvDetalleAjuste.RowHeadersWidth = 25;

            // --- Definición de Columnas ---
            dgvDetalleAjuste.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCodigo",
                HeaderText = "Código",
                Width = 130
            });

            dgvDetalleAjuste.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProducto",
                HeaderText = "Producto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true // El nombre no se debe editar directamente
            });

            dgvDetalleAjuste.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCantidad",
                HeaderText = "Cantidad",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter, Format = "N2" }
            });

            dgvDetalleAjuste.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCosto",
                HeaderText = "Costo Unit.",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvDetalleAjuste.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTotal",
                HeaderText = "Total",
                Width = 120,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight, BackColor = Color.WhiteSmoke }
            });

            // --- Comportamiento ---
            dgvDetalleAjuste.AllowUserToAddRows = true;
            dgvDetalleAjuste.EditMode = DataGridViewEditMode.EditOnEnter; // Más intuitivo
        }

        private void ConfigurarEstadoFormulario(bool habilitado)
        {
            dtpFecha.Enabled = habilitado;
            cboBodega.Enabled = habilitado;
            cboTipoAjuste.Enabled = habilitado;
            dgvDetalleAjuste.Enabled = habilitado;
            txtObservaciones.Enabled = habilitado;
            btnGuardar.Enabled = habilitado;
            btnAnular.Enabled = habilitado;
        }

        private void LimpiarFormulario()
        {
            txtNumeroDocumento.Text = "000001"; // TODO: Cargar nuevo secuencial de la BD
            dtpFecha.Value = DateTime.Now;
            cboBodega.SelectedIndex = -1;
            cboTipoAjuste.SelectedIndex = -1;
            txtObservaciones.Clear();
            dgvDetalleAjuste.Rows.Clear();
            dgvDetalleAjuste.AllowUserToAddRows = true; // Permite que se cree la fila para nuevos datos
            lblTotalAjuste.Text = "$0.00";
        }

        private void dgvDetalleAjuste_KeyDown(object sender, KeyEventArgs e)
        {
            // Si la tecla presionada es Supr (Delete)
            if (e.KeyCode == Keys.Delete)
            {
                // Evita que el evento se propague y llame a la misma lógica de eliminación
                e.Handled = true;
                EliminarFilaSeleccionada();
            }
        }

        private void btnEliminarFila_Click(object sender, EventArgs e)
        {
            EliminarFilaSeleccionada();
        }

        private void EliminarFilaSeleccionada()
        {
            // Validar que hay una fila seleccionada y que no es la fila nueva (la del final)
            if (dgvDetalleAjuste.CurrentRow != null && !dgvDetalleAjuste.CurrentRow.IsNewRow)
            {
                // Preguntar al usuario para estar seguros (opcional pero recomendado)
                var confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar esta fila?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    // Eliminar la fila seleccionada
                    dgvDetalleAjuste.Rows.Remove(dgvDetalleAjuste.CurrentRow);

                    // Recalcular el total general del ajuste
                    CalcularTotalGeneral();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione la fila que desea eliminar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ConfigurarEstadoFormulario(true);
            LimpiarFormulario();
            // No es necesario añadir una fila manualmente si AllowUserToAddRows es true
            dgvDetalleAjuste.Focus();
            dgvDetalleAjuste.CurrentCell = dgvDetalleAjuste.Rows[0].Cells["colCodigo"];
            dgvDetalleAjuste.BeginEdit(true);
        }

        // --- LÓGICA DEL DATAGRIDVIEW (NÚCLEO DE LA SOLUCIÓN) ---

        private void dgvDetalleAjuste_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Solo actuar si se editó la columna de código
            if (dgvDetalleAjuste.Columns[e.ColumnIndex].Name != "colCodigo")
            {
                // Si se edita cantidad o costo, recalcular
                if (dgvDetalleAjuste.Columns[e.ColumnIndex].Name == "colCantidad" || dgvDetalleAjuste.Columns[e.ColumnIndex].Name == "colCosto")
                {
                    CalcularTotalFila(dgvDetalleAjuste.Rows[e.RowIndex]);
                }
                return;
            }

            string textoBuscado = dgvDetalleAjuste.Rows[e.RowIndex].Cells["colCodigo"].Value?.ToString();

            if (string.IsNullOrWhiteSpace(textoBuscado))
            {
                return;
            }

            try
            {
                DProductos d_Productos = new DProductos();
                List<EProducto> productosEncontrados = d_Productos.BuscarProductosActivos(textoBuscado);

                if (productosEncontrados.Count == 0)
                {
                    MessageBox.Show("No se encontró ningún producto con ese código o nombre.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvDetalleAjuste.Rows[e.RowIndex].Cells["colCodigo"].Value = null; // Limpiar la celda
                }
                else if (productosEncontrados.Count == 1)
                {
                    // Si solo hay un resultado, lo usamos directamente
                    PoblarFilaConProducto(productosEncontrados[0], e.RowIndex);
                }
                else
                {
                    // Si hay múltiples resultados, abrimos el formulario de selección
                    using (FrmSeleccionarProducto frmSeleccion = new FrmSeleccionarProducto(productosEncontrados))
                    {
                        if (frmSeleccion.ShowDialog() == DialogResult.OK)
                        {
                            PoblarFilaConProducto(frmSeleccion.ProductoSeleccionado, e.RowIndex);
                        }
                        else
                        {
                            // Si el usuario cancela, limpiamos la celda para que pueda volver a intentar
                            dgvDetalleAjuste.Rows[e.RowIndex].Cells["colCodigo"].Value = string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el producto: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Rellena una fila del DataGridView con la información de un producto.
        /// </summary>
        /// <param name="producto">El producto a añadir.</param>
        /// <param name="rowIndex">El índice de la fila a rellenar.</param>
        private void PoblarFilaConProducto(EProducto producto, int rowIndex)
        {
            if (producto == null) return;

            DataGridViewRow fila = dgvDetalleAjuste.Rows[rowIndex];

            // Rellenar las celdas con los datos del producto seleccionado
            fila.Cells["colCodigo"].Value = producto.CodigoPrincipal;
            fila.Cells["colProducto"].Value = producto.Nombre;
            fila.Cells["colCosto"].Value = producto.PrecioVenta; // Usamos PVP como costo de ejemplo. ¡Ajustar si tienes costo real!
            fila.Cells["colCantidad"].Value = 1; // Cantidad por defecto

            // Calculamos el total de la fila inicial
            CalcularTotalFila(fila);

            // Mover el foco a la celda de cantidad para agilizar el ingreso
            dgvDetalleAjuste.CurrentCell = fila.Cells["colCantidad"];
            dgvDetalleAjuste.BeginEdit(true);
        }

        private void CalcularTotalFila(DataGridViewRow fila)
        {
            try
            {
                decimal cantidad = Convert.ToDecimal(fila.Cells["colCantidad"].Value ?? 0);
                decimal costo = Convert.ToDecimal(fila.Cells["colCosto"].Value ?? 0);
                fila.Cells["colTotal"].Value = cantidad * costo;

                CalcularTotalGeneral();
            }
            catch (FormatException)
            {
                // Si el usuario escribe texto no numérico, lo ignoramos y dejamos el valor en 0
                fila.Cells["colTotal"].Value = 0;
            }
        }

        private void CalcularTotalGeneral()
        {
            decimal totalAjuste = 0;
            foreach (DataGridViewRow row in dgvDetalleAjuste.Rows)
            {
                if (row.IsNewRow) continue;
                totalAjuste += Convert.ToDecimal(row.Cells["colTotal"].Value ?? 0);
            }
            lblTotalAjuste.Text = totalAjuste.ToString("C2");
        }
    }
}