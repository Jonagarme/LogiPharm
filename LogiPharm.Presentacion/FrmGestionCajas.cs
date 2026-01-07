using System;
using System.Drawing;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmGestionCajas : Form
    {
        private DCaja d_Caja;
        private bool modoEdicion = false;
        private int? idCajaSeleccionada = null;

        public FrmGestionCajas()
        {
            InitializeComponent();
            d_Caja = new DCaja();
        }

        private void FrmGestionCajas_Load(object sender, EventArgs e)
        {
            // Auditoría
            try
            {
                new DBitacora().Registrar(
                    SesionActual.IdUsuario,
                    SesionActual.NombreUsuario,
                    "Caja",
                    "VISUALIZAR",
                    "cajas",
                    null,
                    "Abrir Gestión de Cajas",
                    null,
                    Environment.MachineName,
                    "UI"
                );
            }
            catch { }

            ConfigurarDataGridView();
            CargarCajas();
            LimpiarFormulario();
            HabilitarControles(false);

            if (dgvCajas.Rows.Count > 0)
            {
                try { dgvCajas.Rows[0].Selected = true; } catch { }
            }
            else
            {
                ActualizarBotonesAccion();
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvCajas.AutoGenerateColumns = false;
            dgvCajas.AllowUserToAddRows = false;
            dgvCajas.AllowUserToDeleteRows = false;
            dgvCajas.ReadOnly = true;
            dgvCajas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCajas.MultiSelect = false;
        }

        private void CargarCajas()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var tabla = d_Caja.ObtenerParaListado(chkMostrarAnuladas.Checked);
                dgvCajas.DataSource = tabla;

                // Personalizar columnas
                if (dgvCajas.Columns.Count > 0)
                {
                    dgvCajas.Columns["ID"].Visible = false;
                    dgvCajas.Columns["Activa"].Visible = false;
                    dgvCajas.Columns["Anulado"].Visible = false;
                }

                lblTotalCajas.Text = $"Total: {dgvCajas.Rows.Count} cajas";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar las cajas: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void dgvCajas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCajas.CurrentRow == null || dgvCajas.CurrentRow.IsNewRow)
                {
                    idCajaSeleccionada = null;
                    ActualizarBotonesAccion();
                    return;
                }

                var val = dgvCajas.CurrentRow.Cells["ID"].Value;
                if (val == null || val == DBNull.Value)
                {
                    idCajaSeleccionada = null;
                    ActualizarBotonesAccion();
                    return;
                }

                idCajaSeleccionada = Convert.ToInt32(val);
                MostrarDetallesCaja();
                ActualizarBotonesAccion();
            }
            catch
            {
                idCajaSeleccionada = null;
                ActualizarBotonesAccion();
            }
        }

        private void MostrarDetallesCaja()
        {
            if (!idCajaSeleccionada.HasValue) return;

            try
            {
                var caja = d_Caja.ObtenerPorId(idCajaSeleccionada.Value);
                if (caja != null)
                {
                    // Información básica
                    lblCodigoDetalle.Text = caja.Codigo;
                    lblNombreDetalle.Text = caja.Nombre;
                    lblDescripcionDetalle.Text = !string.IsNullOrEmpty(caja.Descripcion) ? caja.Descripcion : "Sin descripción";
                    
                    // Estado
                    lblEstadoDetalle.Text = $"{caja.EstadoIcono} {caja.EstadoTexto}";
                    lblEstadoDetalle.ForeColor = Color.FromName(caja.EstadoColor);

                    // Si está abierta, mostrar info de apertura
                    if (caja.TieneAperturaActiva)
                    {
                        pnlAperturaActiva.Visible = true;
                        lblFechaApertura.Text = caja.FechaAperturaActiva?.ToString("dd/MM/yyyy HH:mm");
                        lblUsuarioApertura.Text = caja.NombreUsuarioActivo;
                        lblSaldoActual.Text = caja.SaldoActual?.ToString("C2") ?? "$0.00";
                    }
                    else
                    {
                        pnlAperturaActiva.Visible = false;
                    }

                    // Estadísticas
                    CargarEstadisticas(caja.Id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al mostrar detalles: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void CargarEstadisticas(int idCaja)
        {
            try
            {
                var stats = d_Caja.ObtenerEstadisticas(idCaja);
                
                lblTotalCierresStats.Text = stats["TotalCierres"].ToString();
                lblTotalIngresosStats.Text = Convert.ToDecimal(stats["TotalIngresos"]).ToString("C2");
                lblTotalEgresosStats.Text = Convert.ToDecimal(stats["TotalEgresos"]).ToString("C2");
                lblDiferenciaPromedioStats.Text = Convert.ToDecimal(stats["DiferenciaPromedio"]).ToString("C2");
            }
            catch
            {
                // Si falla, mostrar valores en 0
                lblTotalCierresStats.Text = "0";
                lblTotalIngresosStats.Text = "$0.00";
                lblTotalEgresosStats.Text = "$0.00";
                lblDiferenciaPromedioStats.Text = "$0.00";
            }
        }

        private void ActualizarBotonesAccion()
        {
            if (!idCajaSeleccionada.HasValue || dgvCajas.CurrentRow == null)
            {
                btnEditar.Enabled = false;
                btnActivarDesactivar.Enabled = false;
                btnAnular.Enabled = false;
                btnVerEstado.Enabled = false;
                return;
            }

            bool anulado = Convert.ToBoolean(dgvCajas.CurrentRow.Cells["Anulado"].Value);
            bool activa = Convert.ToBoolean(dgvCajas.CurrentRow.Cells["Activa"].Value);

            btnEditar.Enabled = !anulado;
            btnActivarDesactivar.Enabled = !anulado;
            btnActivarDesactivar.Text = activa ? "Desactivar" : "Activar";
            btnAnular.Enabled = !anulado;
            btnVerEstado.Enabled = !anulado;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            modoEdicion = false;
            idCajaSeleccionada = null;
            LimpiarFormulario();
            HabilitarControles(true);
            txtCodigo.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!idCajaSeleccionada.HasValue) return;

            try
            {
                var caja = d_Caja.ObtenerPorId(idCajaSeleccionada.Value);
                if (caja == null) return;

                modoEdicion = true;
                txtCodigo.Text = caja.Codigo;
                txtNombre.Text = caja.Nombre;
                txtDescripcion.Text = caja.Descripcion;
                chkActiva.Checked = caja.Activa;

                HabilitarControles(true);
                txtNombre.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar la caja: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            try
            {
                var caja = new ECaja
                {
                    Codigo = txtCodigo.Text.Trim().ToUpper(),
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Activa = chkActiva.Checked,
                    Anulado = false
                };

                bool exito;

                if (modoEdicion && idCajaSeleccionada.HasValue)
                {
                    caja.Id = idCajaSeleccionada.Value;
                    caja.EditadoPor = SesionActual.IdUsuario;
                    exito = d_Caja.Actualizar(caja);

                    // Auditoría
                    try
                    {
                        new DBitacora().Registrar(
                            SesionActual.IdUsuario,
                            SesionActual.NombreUsuario,
                            "Caja",
                            "EDITAR",
                            "cajas",
                            caja.Id,
                            $"Caja editada: {caja.Codigo}",
                            null,
                            Environment.MachineName,
                            "UI"
                        );
                    }
                    catch { }
                }
                else
                {
                    caja.CreadoPor = SesionActual.IdUsuario;
                    exito = d_Caja.Insertar(caja);

                    // Auditoría
                    try
                    {
                        new DBitacora().Registrar(
                            SesionActual.IdUsuario,
                            SesionActual.NombreUsuario,
                            "Caja",
                            "CREAR",
                            "cajas",
                            null,
                            $"Nueva caja creada: {caja.Codigo}",
                            null,
                            Environment.MachineName,
                            "UI"
                        );
                    }
                    catch { }
                }

                if (exito)
                {
                    MessageBox.Show(
                        modoEdicion ? "Caja actualizada correctamente" : "Caja creada correctamente",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    CargarCajas();
                    LimpiarFormulario();
                    HabilitarControles(false);
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo guardar la caja",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al guardar la caja: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            HabilitarControles(false);
        }

        private void btnActivarDesactivar_Click(object sender, EventArgs e)
        {
            if (!idCajaSeleccionada.HasValue || dgvCajas.CurrentRow == null) return;

            bool activa = Convert.ToBoolean(dgvCajas.CurrentRow.Cells["Activa"].Value);
            string accion = activa ? "desactivar" : "activar";
            string codigo = dgvCajas.CurrentRow.Cells["Código"].Value.ToString();

            var confirmacion = MessageBox.Show(
                $"¿Está seguro que desea {accion} la caja '{codigo}'?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.No) return;

            try
            {
                bool exito = d_Caja.CambiarEstadoActiva(idCajaSeleccionada.Value, !activa, SesionActual.IdUsuario);

                if (exito)
                {
                    MessageBox.Show(
                        $"Caja {(activa ? "desactivada" : "activada")} correctamente",
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
                            "Caja",
                            activa ? "DESACTIVAR" : "ACTIVAR",
                            "cajas",
                            idCajaSeleccionada.Value,
                            $"Caja {codigo} {(activa ? "desactivada" : "activada")}",
                            null,
                            Environment.MachineName,
                            "UI"
                        );
                    }
                    catch { }

                    CargarCajas();
                }
                else
                {
                    MessageBox.Show(
                        $"No se pudo {accion} la caja",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al {accion} la caja: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (!idCajaSeleccionada.HasValue || dgvCajas.CurrentRow == null) return;

            string codigo = dgvCajas.CurrentRow.Cells["Código"].Value.ToString();
            var confirmacion = MessageBox.Show(
                $"¿Está seguro que desea ANULAR la caja '{codigo}'?\n\nEsta acción no se puede deshacer.",
                "Confirmar Anulación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacion == DialogResult.No) return;

            try
            {
                bool exito = d_Caja.Anular(idCajaSeleccionada.Value, SesionActual.IdUsuario);

                if (exito)
                {
                    MessageBox.Show(
                        "Caja anulada correctamente",
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
                            "Caja",
                            "ANULAR",
                            "cajas",
                            idCajaSeleccionada.Value,
                            $"Caja {codigo} anulada",
                            null,
                            Environment.MachineName,
                            "UI"
                        );
                    }
                    catch { }

                    CargarCajas();
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo anular la caja",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al anular la caja: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnVerEstado_Click(object sender, EventArgs e)
        {
            if (!idCajaSeleccionada.HasValue) return;

            // Abrir formulario de estado de caja
            using (var frm = new FrmEstadoCaja(idCajaSeleccionada.Value))
            {
                frm.ShowDialog();
            }

            // Refrescar después de cerrar
            CargarCajas();
            MostrarDetallesCaja();
        }

        private void chkMostrarAnuladas_CheckedChanged(object sender, EventArgs e)
        {
            CargarCajas();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Implementar filtro en el DataGridView
            if (dgvCajas.DataSource is System.Data.DataTable dt)
            {
                string filtro = txtBuscar.Text.Trim();
                if (string.IsNullOrEmpty(filtro))
                {
                    dt.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    dt.DefaultView.RowFilter = $"Código LIKE '%{filtro}%' OR Nombre LIKE '%{filtro}%'";
                }
            }
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Debe ingresar un código", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar un nombre", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            // Verificar código único
            string codigo = txtCodigo.Text.Trim().ToUpper();
            if (d_Caja.ExisteCodigo(codigo, idCajaSeleccionada))
            {
                MessageBox.Show($"El código '{codigo}' ya existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarFormulario()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            chkActiva.Checked = true;
        }

        private void HabilitarControles(bool habilitar)
        {
            txtCodigo.Enabled = habilitar && !modoEdicion; // El código no se puede editar
            txtNombre.Enabled = habilitar;
            txtDescripcion.Enabled = habilitar;
            chkActiva.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;

            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = !habilitar;
            btnActivarDesactivar.Enabled = !habilitar;
            btnAnular.Enabled = !habilitar;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCajas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCajas.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value != null)
                {
                    string estado = e.Value.ToString();
                    switch (estado)
                    {
                        case "ABIERTA":
                            e.CellStyle.BackColor = Color.LightGreen;
                            e.CellStyle.ForeColor = Color.DarkGreen;
                            e.CellStyle.Font = new Font(dgvCajas.Font, FontStyle.Bold);
                            break;
                        case "CERRADA":
                            e.CellStyle.BackColor = Color.LightBlue;
                            e.CellStyle.ForeColor = Color.DarkBlue;
                            break;
                        case "INACTIVA":
                            e.CellStyle.BackColor = Color.LightYellow;
                            e.CellStyle.ForeColor = Color.DarkOrange;
                            break;
                        case "ANULADA":
                            e.CellStyle.BackColor = Color.LightGray;
                            e.CellStyle.ForeColor = Color.DarkGray;
                            break;
                    }
                }
            }
        }
    }
}
