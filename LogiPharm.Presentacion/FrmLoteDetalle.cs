using LogiPharm.Datos;
using LogiPharm.Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace LogiPharm.Presentacion
{
    public partial class FrmLoteDetalle : Form
    {
        private readonly DUbicaciones _dUbicaciones = new DUbicaciones();
        private readonly DInventarioLotes _dInventarioLotes = new DInventarioLotes();
        private long? _idProductoSeleccionado;
        private int? _idLoteEditar;

        public FrmLoteDetalle()
        {
            InitializeComponent();
        }

        public FrmLoteDetalle(int idLote) : this()
        {
            _idLoteEditar = idLote;
            lblTitulo.Text = "Editar Lote";
        }

        private void FrmLoteDetalle_Load(object sender, EventArgs e)
        {
            CargarUbicaciones();
            dtpFechaIngreso.Value = DateTime.Today;
            dtpFechaFabricacion.Value = DateTime.Today;
            dtpFechaCaducidad.Value = DateTime.Today.AddYears(2);

            if (_idLoteEditar.HasValue)
            {
                CargarDatosLote();
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

        private void CargarDatosLote()
        {
            try
            {
                var lote = _dInventarioLotes.ObtenerLotePorId(_idLoteEditar.Value);
                if (lote == null)
                {
                    MessageBox.Show("No se encontró el lote especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Cargar producto
                _idProductoSeleccionado = lote.IdProducto;
                txtProducto.Text = lote.CodigoProducto + " - " + lote.NombreProducto;
                txtProducto.Enabled = false;
                btnBuscarProducto.Enabled = false;

                // Cargar datos del lote
                cboUbicacion.SelectedValue = lote.IdUbicacion;
                txtNumeroLote.Text = lote.NumeroLote;
                dtpFechaIngreso.Value = lote.FechaIngreso;
                dtpFechaCaducidad.Value = lote.FechaCaducidad;
                
                // La cantidad inicial no se puede modificar en edición
                numCantidadInicial.Value = lote.StockTotal;
                numCantidadInicial.Enabled = false;
                
                chkActivo.Checked = lote.Estado == "VIGENTE";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del lote: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            var frmBuscador = new FrmSeleccionarProducto();
            if (frmBuscador.ShowDialog() == DialogResult.OK && frmBuscador.ProductoSeleccionado != null)
            {
                _idProductoSeleccionado = frmBuscador.ProductoSeleccionado.Id;
                txtProducto.Text = frmBuscador.ProductoSeleccionado.CodigoPrincipal + " - " + frmBuscador.ProductoSeleccionado.Nombre;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            try
            {
                if (_idLoteEditar.HasValue)
                {
                    // Actualizar lote existente
                    ActualizarLoteExistente();
                }
                else
                {
                    // Insertar nuevo lote
                    InsertarNuevoLote();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarFormulario()
        {
            if (!_idProductoSeleccionado.HasValue)
            {
                MessageBox.Show("Debe seleccionar un producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnBuscarProducto.Focus();
                return false;
            }

            if (cboUbicacion.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una ubicación.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboUbicacion.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNumeroLote.Text))
            {
                MessageBox.Show("Debe ingresar el número de lote.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumeroLote.Focus();
                return false;
            }

            // Solo validar cantidad inicial si es un lote nuevo
            if (!_idLoteEditar.HasValue && numCantidadInicial.Value <= 0)
            {
                MessageBox.Show("La cantidad inicial debe ser mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numCantidadInicial.Focus();
                return false;
            }

            if (dtpFechaCaducidad.Value.Date < dtpFechaIngreso.Value.Date)
            {
                MessageBox.Show("La fecha de caducidad no puede ser anterior a la fecha de ingreso.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFechaCaducidad.Focus();
                return false;
            }

            return true;
        }

        private void InsertarNuevoLote()
        {
            bool resultado = _dInventarioLotes.InsertarLote(
                productoId: (int)_idProductoSeleccionado.Value,
                ubicacionId: Convert.ToInt32(cboUbicacion.SelectedValue),
                numeroLote: txtNumeroLote.Text.Trim(),
                fechaIngreso: dtpFechaIngreso.Value.Date,
                fechaFabricacion: dtpFechaFabricacion.Value.Date,
                fechaCaducidad: dtpFechaCaducidad.Value.Date,
                cantidadInicial: numCantidadInicial.Value,
                costoUnitario: numCostoUnitario.Value,
                numeroFactura: txtNumeroFactura.Text.Trim(),
                observaciones: txtObservaciones.Text.Trim(),
                activo: chkActivo.Checked
            );

            if (resultado)
            {
                MessageBox.Show("Lote guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo guardar el lote.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarLoteExistente()
        {
            bool resultado = _dInventarioLotes.ActualizarLote(
                idLote: _idLoteEditar.Value,
                numeroLote: txtNumeroLote.Text.Trim(),
                fechaIngreso: dtpFechaIngreso.Value.Date,
                fechaFabricacion: dtpFechaFabricacion.Value.Date,
                fechaCaducidad: dtpFechaCaducidad.Value.Date,
                costoUnitario: numCostoUnitario.Value,
                numeroFactura: txtNumeroFactura.Text.Trim(),
                observaciones: txtObservaciones.Text.Trim(),
                activo: chkActivo.Checked
            );

            if (resultado)
            {
                MessageBox.Show("Lote actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el lote.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
