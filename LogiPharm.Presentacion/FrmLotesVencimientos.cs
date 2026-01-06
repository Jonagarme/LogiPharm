using LogiPharm.Datos;
using LogiPharm.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LogiPharm.Presentacion
{
    public partial class FrmLotesVencimientos : Form
    {
        private readonly DInventarioLotes _dInventarioLotes = new DInventarioLotes();
        private readonly DUbicaciones _dUbicaciones = new DUbicaciones();
        private long? _idProductoSeleccionado;

        public FrmLotesVencimientos()
        {
            InitializeComponent();
            ConfigurarFormulario();
            ConfigurarEventos();
        }

        private void ConfigurarFormulario()
        {
            dgvLotes.Columns.Clear();

            dgvLotes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            });

            dgvLotes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Producto",
                HeaderText = "Producto",
                DataPropertyName = "NombreProducto",
                Width = 220
            });

            dgvLotes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NumeroLote",
                HeaderText = "N° Lote",
                DataPropertyName = "NumeroLote",
                Width = 100
            });

            dgvLotes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Ubicacion",
                HeaderText = "Ubicación",
                DataPropertyName = "NombreUbicacion",
                Width = 120
            });

            dgvLotes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaIngreso",
                HeaderText = "Ingreso",
                DataPropertyName = "FechaIngreso",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "d" }
            });

            dgvLotes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaCaducidad",
                HeaderText = "Vencimiento",
                DataPropertyName = "FechaCaducidad",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "d" }
            });

            dgvLotes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StockTotal",
                HeaderText = "Cant. inicial",
                DataPropertyName = "StockTotal",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N2" }
            });

            dgvLotes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StockDisponible",
                HeaderText = "Disponible",
                DataPropertyName = "StockDisponible",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N2" }
            });

            dgvLotes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StockReservado",
                HeaderText = "Reservado",
                DataPropertyName = "StockReservado",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N2" }
            });

            dgvLotes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DiasParaCaducidad",
                HeaderText = "Días para vto.",
                DataPropertyName = "DiasParaCaducidad",
                Width = 80
            });

            dgvLotes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Estado",
                HeaderText = "Estado",
                DataPropertyName = "Estado",
                Width = 80
            });

            dgvLotes.RowPrePaint += DgvLotes_RowPrePaint;
        }

        private void ConfigurarEventos()
        {
            btnBuscarProducto.Click += BtnBuscarProducto_Click;
            btnBuscar.Click += (s, e) => CargarLotes();
            btnLimpiar.Click += (s, e) => LimpiarFiltros();
            btnCerrar.Click += (s, e) => Close();
            dgvLotes.DoubleClick += DgvLotes_DoubleClick;
            btnNuevo.Click += BtnNuevo_Click;
            btnEditar.Click += BtnEditar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnExportar.Click += BtnExportar_Click;
            txtProducto.KeyDown += TxtProducto_KeyDown;
        }

        private void TxtProducto_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BuscarProductoPorTexto();
            }
        }

        private void BuscarProductoPorTexto()
        {
            string textoBusqueda = txtProducto.Text.Trim();

            if (string.IsNullOrWhiteSpace(textoBusqueda))
            {
                BtnBuscarProducto_Click(null, null);
                return;
            }

            try
            {
                var dProductos = new DProductos();
                var productosEncontrados = dProductos.BuscarProductosActivos(textoBusqueda);

                if (productosEncontrados.Count == 0)
                {
                    MessageBox.Show("No se encontraron productos con ese criterio.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (productosEncontrados.Count == 1)
                {
                    _idProductoSeleccionado = productosEncontrados[0].Id;
                    txtProducto.Text = productosEncontrados[0].CodigoPrincipal + " - " + productosEncontrados[0].Nombre;
                    CargarLotes();
                }
                else
                {
                    using (var frm = new FrmSeleccionarProducto(productosEncontrados))
                    {
                        if (frm.ShowDialog() == DialogResult.OK && frm.ProductoSeleccionado != null)
                        {
                            _idProductoSeleccionado = frm.ProductoSeleccionado.Id;
                            txtProducto.Text = frm.ProductoSeleccionado.CodigoPrincipal + " - " + frm.ProductoSeleccionado.Nombre;
                            CargarLotes();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmLotesVencimientos_Load(object sender, EventArgs e)
        {
            CargarUbicaciones();
            // Cambiar el rango de fechas para incluir lotes vencidos y futuros
            dtpDesde.Value = DateTime.Today.AddYears(-2); // 2 años atrás
            dtpHasta.Value = DateTime.Today.AddYears(5);  // 5 años adelante
            CargarLotes();
        }

        private void BtnBuscarProducto_Click(object sender, EventArgs e)
        {
            var frmBuscador = new FrmSeleccionarProducto();
            if (frmBuscador.ShowDialog() == DialogResult.OK && frmBuscador.ProductoSeleccionado != null)
            {
                _idProductoSeleccionado = frmBuscador.ProductoSeleccionado.Id;
                txtProducto.Text = frmBuscador.ProductoSeleccionado.CodigoPrincipal + " - " + frmBuscador.ProductoSeleccionado.Nombre;
                CargarLotes();
            }
        }

        private void CargarUbicaciones()
        {
            try
            {
                DataTable tabla = _dUbicaciones.ListarUbicacionesActivas();
                cboUbicacion.DataSource = tabla;
                cboUbicacion.DisplayMember = "nombre";
                cboUbicacion.ValueMember = "id";
                cboUbicacion.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ubicaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarLotes()
        {
            try
            {
                int? idProducto = _idProductoSeleccionado.HasValue ? (int?)_idProductoSeleccionado.Value : null;
                int? idUbicacion = cboUbicacion.SelectedValue != null ? (int?)Convert.ToInt32(cboUbicacion.SelectedValue) : null;
                DateTime? fechaDesde = dtpDesde.Value.Date;
                DateTime? fechaHasta = dtpHasta.Value.Date;
                bool? soloActivos = chkSoloActivos.Checked;

                var lotes = _dInventarioLotes.ObtenerTodosLotes(idProducto, idUbicacion, fechaDesde, fechaHasta, soloActivos);

                // Limpiar el DataSource antes de asignar uno nuevo
                dgvLotes.DataSource = null;
                dgvLotes.Refresh();
                
                // Asignar el nuevo DataSource
                dgvLotes.DataSource = lotes;
                dgvLotes.Refresh();

                decimal totalDisponible = lotes.Sum(l => l.StockDisponible);
                decimal totalReservado = lotes.Sum(l => l.StockReservado);
                int cantidadLotes = lotes.Count;
                int lotesVencidos = lotes.Count(l => l.FechaCaducidad.Date < DateTime.Today.Date);
                int lotesPorVencer = lotes.Count(l => l.DiasParaCaducidad > 0 && l.DiasParaCaducidad <= 30);

                lblResumen.Text = string.Format(
                    "Total lotes: {0} | Disponible: {1:N2} | Reservado: {2:N2} | Vencidos: {3} | Por vencer (30 días): {4}",
                    cantidadLotes, totalDisponible, totalReservado, lotesVencidos, lotesPorVencer
                );

                if (lotes.Count == 0)
                {
                    MessageBox.Show("No se encontraron lotes con los criterios especificados.\n\nVerifica:\n- Las fechas de vencimiento\n- Que los lotes estén activos\n- Que tengan cantidad disponible", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar lotes: " + ex.Message + "\n\nStack: " + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFiltros()
        {
            _idProductoSeleccionado = null;
            txtProducto.Text = string.Empty;
            cboUbicacion.SelectedIndex = -1;
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today.AddMonths(6);
            chkSoloActivos.Checked = true;
            dgvLotes.DataSource = null;
            lblResumen.Text = string.Empty;
        }

        private void DgvLotes_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvLotes.Rows[e.RowIndex];
            var lote = row.DataBoundItem as EInventarioLote;
            if (lote == null) return;

            DateTime hoy = DateTime.Today;

            if (lote.FechaCaducidad.Date < hoy)
            {
                row.DefaultCellStyle.BackColor = Color.MistyRose;
                row.DefaultCellStyle.ForeColor = Color.DarkRed;
            }
            else if (lote.DiasParaCaducidad <= 30)
            {
                row.DefaultCellStyle.BackColor = Color.LemonChiffon;
                row.DefaultCellStyle.ForeColor = Color.DarkOrange;
            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void DgvLotes_DoubleClick(object sender, EventArgs e)
        {
            if (dgvLotes.CurrentRow == null) return;
            BtnEditar_Click(sender, e);
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmLoteDetalle())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarLotes();
                    MessageBox.Show("Lote creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvLotes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un lote para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var lote = dgvLotes.CurrentRow.DataBoundItem as EInventarioLote;
            if (lote == null) return;

            using (var frm = new FrmLoteDetalle(lote.Id))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarLotes();
                    MessageBox.Show("Lote actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvLotes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un lote para desactivar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var lote = dgvLotes.CurrentRow.DataBoundItem as EInventarioLote;
            if (lote == null) return;

            var result = MessageBox.Show(
                string.Format("¿Está seguro de desactivar el lote '{0}' del producto '{1}'?", lote.NumeroLote, lote.NombreProducto),
                "Confirmar desactivación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Funcionalidad en desarrollo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            if (dgvLotes.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Archivos CSV (*.csv)|*.csv|Todos los archivos (*.*)|*.*",
                    FileName = "Lotes_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(saveDialog.FileName, false, System.Text.Encoding.UTF8))
                    {
                        sw.WriteLine("Producto,Numero Lote,Ubicacion,Fecha Ingreso,Fecha Vencimiento,Cant Inicial,Disponible,Reservado,Dias Para Vto,Estado");

                        foreach (DataGridViewRow row in dgvLotes.Rows)
                        {
                            var lote = row.DataBoundItem as EInventarioLote;
                            if (lote != null)
                            {
                                sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",{3:d},{4:d},{5},{6},{7},{8},\"{9}\"",
                                    lote.NombreProducto,
                                    lote.NumeroLote,
                                    lote.NombreUbicacion,
                                    lote.FechaIngreso,
                                    lote.FechaCaducidad,
                                    lote.StockTotal,
                                    lote.StockDisponible,
                                    lote.StockReservado,
                                    lote.DiasParaCaducidad,
                                    lote.Estado
                                ));
                            }
                        }
                    }

                    MessageBox.Show("Datos exportados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
