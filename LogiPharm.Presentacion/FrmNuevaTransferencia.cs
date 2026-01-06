using Guna.UI2.WinForms;
using LogiPharm.Datos;
using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LogiPharm.Presentacion
{
    public partial class FrmNuevaTransferencia : Form
    {
        private readonly DTransferencias _dTransferencias;
        private readonly DUbicaciones _dUbicaciones;
        private DataTable _dtUbicaciones;
        private List<ETransferenciaDetalle> _detallesTransferencia;

        public FrmNuevaTransferencia()
        {
            InitializeComponent();
            _dTransferencias = new DTransferencias();
            _dUbicaciones = new DUbicaciones();
            _detallesTransferencia = new List<ETransferenciaDetalle>();
        }

        private void FrmNuevaTransferencia_Load(object sender, EventArgs e)
        {
            // Generar número automático
            txtNumero.Text = _dTransferencias.GenerarNumeroTransferencia();
            txtNumero.ReadOnly = true;
            
            // Fecha actual
            dtpFecha.Value = DateTime.Now;
            
            // Cargar ubicaciones
            CargarUbicaciones();
            
            // Cargar motivos
            CargarMotivos();
            
            // Configurar DataGridView de detalles
            ConfigurarGridDetalles();
        }

        private void CargarUbicaciones()
        {
            try
            {
                _dtUbicaciones = _dUbicaciones.ListarUbicacionesActivas();

                if (_dtUbicaciones == null || _dtUbicaciones.Rows.Count == 0)
                {
                    MessageBox.Show("No hay ubicaciones registradas en el sistema.\n\n" +
                        "Por favor, registre al menos dos ubicaciones en la tabla 'inventario_ubicacion'.", 
                        "Sin ubicaciones", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning);
                    return;
                }

                // IMPORTANTE: Limpiar primero
                cboOrigen.DataSource = null;
                cboDestino.DataSource = null;

                // Configurar combo origen
                cboOrigen.DisplayMember = "nombre";
                cboOrigen.ValueMember = "id";
                cboOrigen.DataSource = _dtUbicaciones.Copy();
                cboOrigen.SelectedIndex = -1;

                // Configurar combo destino
                cboDestino.DisplayMember = "nombre";
                cboDestino.ValueMember = "id";
                cboDestino.DataSource = _dtUbicaciones.Copy();
                cboDestino.SelectedIndex = -1;

                // Mensaje de depuración (puedes quitarlo después)
                MessageBox.Show($"? Se cargaron {_dtUbicaciones.Rows.Count} ubicaciones correctamente.", 
                    "Depuración", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"? Error al cargar ubicaciones:\n\n{ex.Message}\n\nStack Trace:\n{ex.StackTrace}", 
                    "Error Detallado",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        private void CargarMotivos()
        {
            cboMotivo.Items.Clear();
            cboMotivo.Items.Add("Reposición de stock");
            cboMotivo.Items.Add("Traslado entre sucursales");
            cboMotivo.Items.Add("Ajuste de inventario");
            cboMotivo.Items.Add("Redistribución");
            cboMotivo.Items.Add("Otro");
            cboMotivo.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cancelar la transferencia?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones básicas
                if (cboOrigen.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione la ubicación de origen", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboOrigen.Focus();
                    return;
                }

                if (cboDestino.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione la ubicación de destino", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboDestino.Focus();
                    return;
                }

                if (cboOrigen.SelectedValue.ToString() == cboDestino.SelectedValue.ToString())
                {
                    MessageBox.Show("La ubicación origen y destino no pueden ser iguales", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboDestino.Focus();
                    return;
                }

                if (cboMotivo.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione el motivo de la transferencia", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboMotivo.Focus();
                    return;
                }

                // Validar que haya al menos un producto
                if (_detallesTransferencia == null || _detallesTransferencia.Count == 0)
                {
                    MessageBox.Show("Debe agregar al menos un producto a la transferencia", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear entidad
                var transferencia = new ETransferencia
                {
                    NumeroTransferencia = txtNumero.Text,
                    FechaTransferencia = dtpFecha.Value,
                    IdUbicacionOrigen = Convert.ToInt32(cboOrigen.SelectedValue),
                    IdUbicacionDestino = Convert.ToInt32(cboDestino.SelectedValue),
                    MotivoTransferencia = cboMotivo.SelectedItem.ToString(),
                    Observaciones = txtObservaciones.Text.Trim(),
                    Estado = "PENDIENTE",
                    CreadoPor = SesionActual.IdUsuario,
                    Detalles = _detallesTransferencia
                };

                // Guardar
                if (_dTransferencias.InsertarTransferencia(transferencia))
                {
                    MessageBox.Show("Transferencia creada exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo crear la transferencia", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear transferencia: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGridDetalles()
        {
            dgvDetalles.Columns.Clear();
            dgvDetalles.AutoGenerateColumns = false;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.MultiSelect = false;
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.ReadOnly = true;
            dgvDetalles.RowHeadersVisible = false;

            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCodigo",
                HeaderText = "Código",
                DataPropertyName = "CodigoProducto",
                Width = 100
            });

            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProducto",
                HeaderText = "Producto",
                DataPropertyName = "NombreProducto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLote",
                HeaderText = "Lote",
                DataPropertyName = "Lote",
                Width = 100
            });

            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCaducidad",
                HeaderText = "Caducidad",
                DataPropertyName = "FechaCaducidad",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCantidad",
                HeaderText = "Cantidad",
                DataPropertyName = "CantidadSolicitada",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStock",
                HeaderText = "Stock Disp.",
                DataPropertyName = "StockDisponibleOrigen",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            // Columna de acción (eliminar)
            var colEliminar = new DataGridViewButtonColumn
            {
                Name = "colEliminar",
                HeaderText = "",
                Text = "?",
                UseColumnTextForButtonValue = true,
                Width = 40
            };
            dgvDetalles.Columns.Add(colEliminar);

            dgvDetalles.CellContentClick += DgvDetalles_CellContentClick;
        }

        private void DgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvDetalles.Columns[e.ColumnIndex].Name == "colEliminar")
            {
                if (MessageBox.Show("¿Está seguro de eliminar este producto de la transferencia?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _detallesTransferencia.RemoveAt(e.RowIndex);
                    ActualizarGridDetalles();
                }
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            // Validar que se haya seleccionado ubicación de origen
            if (cboOrigen.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione la ubicación de origen antes de agregar productos",
                    "Ubicación requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboOrigen.Focus();
                return;
            }

            int ubicacionOrigenId = Convert.ToInt32(cboOrigen.SelectedValue);

            using (var frm = new FrmConfigProductoTransferencia(ubicacionOrigenId))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Verificar que el producto no esté ya agregado con el mismo lote
                    var productoExistente = _detallesTransferencia.FirstOrDefault(d =>
                        d.IdProducto == frm.ProductoSeleccionado.Id &&
                        d.Lote == frm.LoteSeleccionado.NumeroLote);

                    if (productoExistente != null)
                    {
                        // Actualizar cantidad
                        productoExistente.CantidadSolicitada += (int)frm.CantidadSeleccionada;
                    }
                    else
                    {
                        // Agregar nuevo detalle
                        var detalle = new ETransferenciaDetalle
                        {
                            IdProducto = frm.ProductoSeleccionado.Id,
                            CodigoProducto = frm.ProductoSeleccionado.CodigoPrincipal,
                            NombreProducto = frm.ProductoSeleccionado.Nombre,
                            Lote = frm.LoteSeleccionado.NumeroLote,
                            FechaCaducidad = frm.LoteSeleccionado.FechaCaducidad,
                            CantidadSolicitada = (int)frm.CantidadSeleccionada,
                            StockDisponibleOrigen = (int)frm.LoteSeleccionado.StockDisponible,
                            DiasParaCaducidad = frm.LoteSeleccionado.DiasParaCaducidad,
                            EstadoCaducidad = frm.LoteSeleccionado.Estado
                        };

                        _detallesTransferencia.Add(detalle);
                    }

                    ActualizarGridDetalles();
                }
            }
        }

        private void ActualizarGridDetalles()
        {
            dgvDetalles.DataSource = null;
            dgvDetalles.DataSource = _detallesTransferencia;
            dgvDetalles.Refresh();

            // Actualizar contador
            lblTotalProductos.Text = $"Total productos: {_detallesTransferencia.Count}";
            lblTotalUnidades.Text = $"Total unidades: {_detallesTransferencia.Sum(d => d.CantidadSolicitada)}";
        }
    }
}
