using System;
using System.Data;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmLaboratorios : Form
    {
        private int? _idEditando;
        private int? _idProcEditando;
        private int? _idParamEditando;

        public FrmLaboratorios()
        {
            InitializeComponent();
            this.Load += FrmLaboratorios_Load;
            // Laboratorios
            this.btnCerrar.Click += (s,e) => this.Close();
            this.btnNuevo.Click += BtnNuevo_Click;
            this.btnGuardar.Click += BtnGuardar_Click;
            this.btnEliminar.Click += BtnEliminar_Click;
            this.dgvLaboratorios.SelectionChanged += DgvLaboratorios_SelectionChanged;
            this.dgvLaboratorios.AutoGenerateColumns = false;

            // Procesos
            this.btnProcNuevo.Click += BtnProcNuevo_Click;
            this.btnProcGuardar.Click += BtnProcGuardar_Click;
            this.btnProcEliminar.Click += BtnProcEliminar_Click;
            this.dgvProcesos.SelectionChanged += DgvProcesos_SelectionChanged;
            this.dgvProcesos.AutoGenerateColumns = false;

            // Parámetros
            this.btnParamNuevo.Click += BtnParamNuevo_Click;
            this.btnParamGuardar.Click += BtnParamGuardar_Click;
            this.btnParamEliminar.Click += BtnParamEliminar_Click;
            this.dgvParametros.SelectionChanged += DgvParametros_SelectionChanged;
            this.dgvParametros.AutoGenerateColumns = false;

            // Emisión
            this.btnEmitirResultado.Click += BtnEmitirResultado_Click;

            EnsureGridsConfigured();
        }

        private void EnsureGridsConfigured()
        {
            // Laboratorios
            if (dgvLaboratorios.Columns.Count == 0)
            {
                dgvLaboratorios.Columns.Add(new DataGridViewTextBoxColumn { Name = "colLabId", HeaderText = "Id", DataPropertyName = "id", Visible = false });
                dgvLaboratorios.Columns.Add(new DataGridViewTextBoxColumn { Name = "colLabCodigo", HeaderText = "Código", DataPropertyName = "codigo", Width = 110 });
                dgvLaboratorios.Columns.Add(new DataGridViewTextBoxColumn { Name = "colLabNombre", HeaderText = "Nombre", DataPropertyName = "nombre", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                dgvLaboratorios.Columns.Add(new DataGridViewTextBoxColumn { Name = "colLabContacto", HeaderText = "Contacto", DataPropertyName = "contacto", Width = 140 });
                dgvLaboratorios.Columns.Add(new DataGridViewTextBoxColumn { Name = "colLabTelefono", HeaderText = "Teléfono", DataPropertyName = "telefono", Width = 110 });
                dgvLaboratorios.Columns.Add(new DataGridViewTextBoxColumn { Name = "colLabEmail", HeaderText = "Email", DataPropertyName = "email", Width = 160 });
                dgvLaboratorios.Columns.Add(new DataGridViewTextBoxColumn { Name = "colLabDireccion", HeaderText = "Dirección", DataPropertyName = "direccion", Width = 240 });
                dgvLaboratorios.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colLabActivo", HeaderText = "Activo", DataPropertyName = "activo", Width = 60 });
            }

            // Procesos
            if (dgvProcesos.Columns.Count == 0)
            {
                dgvProcesos.Columns.Add(new DataGridViewTextBoxColumn { Name = "colProcId", HeaderText = "Id", DataPropertyName = "id", Visible = false });
                dgvProcesos.Columns.Add(new DataGridViewTextBoxColumn { Name = "colProcNombre", HeaderText = "Proceso", DataPropertyName = "nombre", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                dgvProcesos.Columns.Add(new DataGridViewTextBoxColumn { Name = "colProcMetodo", HeaderText = "Método", DataPropertyName = "metodo", Width = 140 });
                dgvProcesos.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colProcActivo", HeaderText = "Activo", DataPropertyName = "activo", Width = 60 });
            }

            // Parámetros
            if (dgvParametros.Columns.Count == 0)
            {
                dgvParametros.Columns.Add(new DataGridViewTextBoxColumn { Name = "colParId", HeaderText = "Id", DataPropertyName = "id", Visible = false });
                dgvParametros.Columns.Add(new DataGridViewTextBoxColumn { Name = "colParNombre", HeaderText = "Parámetro", DataPropertyName = "nombre", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                dgvParametros.Columns.Add(new DataGridViewTextBoxColumn { Name = "colParUnidad", HeaderText = "Unidad", DataPropertyName = "unidad", Width = 80 });
                dgvParametros.Columns.Add(new DataGridViewTextBoxColumn { Name = "colParMin", HeaderText = "Ref. Min", DataPropertyName = "ref_min", Width = 80 });
                dgvParametros.Columns.Add(new DataGridViewTextBoxColumn { Name = "colParMax", HeaderText = "Ref. Max", DataPropertyName = "ref_max", Width = 80 });
                dgvParametros.Columns.Add(new DataGridViewTextBoxColumn { Name = "colParOrden", HeaderText = "Orden", DataPropertyName = "orden", Width = 60 });
                dgvParametros.Columns.Add(new DataGridViewTextBoxColumn { Name = "colParNotas", HeaderText = "Notas", DataPropertyName = "notas", Width = 160 });
                dgvParametros.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colParActivo", HeaderText = "Activo", DataPropertyName = "activo", Width = 60 });
            }
        }

        private void SelectFirstVisibleRow(DataGridView dgv)
        {
            if (dgv.Rows.Count == 0) return;
            int colIndex = -1;
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (dgv.Columns[i].Visible) { colIndex = i; break; }
            }
            if (colIndex < 0) colIndex = 0;
            dgv.ClearSelection();
            dgv.CurrentCell = dgv.Rows[0].Cells[colIndex];
            dgv.Rows[0].Selected = true;
        }

        private void FrmLaboratorios_Load(object sender, EventArgs e)
        {
            CargarDatos();
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Laboratorios", "VISUALIZAR", "laboratorios", null, "Abrir Laboratorios", null, Environment.MachineName, "UI"); } catch { }
        }

        private static string SafeString(object v) => v == null || v == DBNull.Value ? string.Empty : Convert.ToString(v);
        private static bool SafeBool(object v)
        {
            if (v == null || v == DBNull.Value) return false;
            if (v is bool b) return b;
            try { return Convert.ToInt32(v) != 0; } catch { return false; }
        }
        private static int? SafeInt(object v)
        {
            if (v == null || v == DBNull.Value) return null;
            try { return Convert.ToInt32(v); } catch { return null; }
        }
        private static int SafeIntForOrder(object v) => SafeInt(v) ?? 0;


        #region Laboratorios
        private void CargarDatos()
        {
            try
            {
                var d = new DLaboratorios();
                var dt = d.Listar();
                dgvLaboratorios.DataSource = dt;

                // Seleccionar primera fila automáticamente para ver procesos
                if (dt != null && dt.Rows.Count > 0)
                {
                    SelectFirstVisibleRow(dgvLaboratorios);
                    DgvLaboratorios_SelectionChanged(null, EventArgs.Empty);
                }
                else
                {
                    LimpiarProcesosYParams();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar: "+ex.Message);
            }
        }

        private void DgvLaboratorios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLaboratorios.CurrentRow == null) { _idEditando = null; LimpiarProcesosYParams(); return; }
            var drv = dgvLaboratorios.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) { _idEditando = null; LimpiarProcesosYParams(); return; }
            _idEditando = SafeInt(drv["id"]);
            txtCodigo.Text = SafeString(drv["codigo"]);
            txtNombre.Text = SafeString(drv["nombre"]);
            txtContacto.Text = SafeString(drv["contacto"]);
            txtTelefono.Text = SafeString(drv["telefono"]);
            txtEmail.Text = SafeString(drv["email"]);
            txtDireccion.Text = SafeString(drv["direccion"]);
            chkActivo.Checked = SafeBool(drv["activo"]);

            CargarProcesos();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            _idEditando = null;
            txtCodigo.Clear();
            txtNombre.Clear();
            txtContacto.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            chkActivo.Checked = true;
            dgvLaboratorios.ClearSelection();
            txtCodigo.Focus();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text)) { MessageBox.Show("Nombre requerido"); txtNombre.Focus(); return; }

                var lab = new ELaboratorio
                {
                    Id = _idEditando ?? 0,
                    Codigo = txtCodigo.Text?.Trim(),
                    Nombre = txtNombre.Text?.Trim(),
                    Contacto = txtContacto.Text?.Trim(),
                    Telefono = txtTelefono.Text?.Trim(),
                    Email = txtEmail.Text?.Trim(),
                    Direccion = txtDireccion.Text?.Trim(),
                    Activo = chkActivo.Checked
                };

                var d = new DLaboratorios();
                if (_idEditando.HasValue && _idEditando.Value > 0)
                {
                    d.Actualizar(lab);
                    try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Laboratorios", "EDITAR", "laboratorios", lab.Id, $"Editar laboratorio {lab.Codigo}", null, Environment.MachineName, "UI"); } catch { }
                }
                else
                {
                    d.Insertar(lab);
                    try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Laboratorios", "CREAR", "laboratorios", null, $"Crear laboratorio {lab.Codigo}", null, Environment.MachineName, "UI"); } catch { }
                }

                MessageBox.Show("Guardado correctamente");
                CargarDatos();
                BtnNuevo_Click(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ex.Message);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (!_idEditando.HasValue || _idEditando.Value <= 0) { MessageBox.Show("Seleccione un laboratorio"); return; }
            if (MessageBox.Show("¿Eliminar laboratorio?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                var d = new DLaboratorios();
                d.Eliminar(_idEditando.Value);
                try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Laboratorios", "ELIMINAR", "laboratorios", _idEditando, $"Eliminar laboratorio {_idEditando}", null, Environment.MachineName, "UI"); } catch { }
                CargarDatos();
                BtnNuevo_Click(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: "+ex.Message);
            }
        }
        #endregion

        #region Procesos
        private void LimpiarProcesosYParams()
        {
            dgvProcesos.DataSource = null;
            dgvParametros.DataSource = null;
            BtnProcNuevo_Click(null, EventArgs.Empty);
            BtnParamNuevo_Click(null, EventArgs.Empty);
        }

        private void CargarProcesos()
        {
            if (!_idEditando.HasValue) { dgvProcesos.DataSource = null; return; }
            try
            {
                var d = new DLabProcesos();
                var dt = d.Listar(_idEditando.Value);
                dgvProcesos.DataSource = dt;

                if (dt != null && dt.Rows.Count > 0)
                {
                    SelectFirstVisibleRow(dgvProcesos);
                    DgvProcesos_SelectionChanged(null, EventArgs.Empty);
                }
                else
                {
                    dgvParametros.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar procesos: " + ex.Message);
            }
        }

        private void DgvProcesos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProcesos.CurrentRow == null) { _idProcEditando = null; dgvParametros.DataSource = null; return; }
            var drv = dgvProcesos.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) { _idProcEditando = null; dgvParametros.DataSource = null; return; }
            _idProcEditando = SafeInt(drv["id"]);
            txtProcNombre.Text = SafeString(drv["nombre"]);
            txtProcMetodo.Text = SafeString(drv["metodo"]);
            chkProcActivo.Checked = SafeBool(drv["activo"]);

            CargarParametros();
        }

        private void BtnProcNuevo_Click(object sender, EventArgs e)
        {
            _idProcEditando = null;
            txtProcNombre.Clear();
            txtProcMetodo.Clear();
            chkProcActivo.Checked = true;
            dgvProcesos.ClearSelection();
            txtProcNombre.Focus();
        }

        private void BtnProcGuardar_Click(object sender, EventArgs e)
        {
            if (!_idEditando.HasValue) { MessageBox.Show("Seleccione un laboratorio primero."); return; }
            if (string.IsNullOrWhiteSpace(txtProcNombre.Text)) { MessageBox.Show("Nombre de proceso requerido."); txtProcNombre.Focus(); return; }

            var proc = new ELabProceso
            {
                Id = _idProcEditando ?? 0,
                LaboratorioId = _idEditando.Value,
                Nombre = txtProcNombre.Text.Trim(),
                Metodo = txtProcMetodo.Text.Trim(),
                Activo = chkProcActivo.Checked
            };

            try
            {
                var d = new DLabProcesos();
                if (_idProcEditando.HasValue) d.Actualizar(proc); else d.Insertar(proc);
                MessageBox.Show("Proceso guardado.");
                CargarProcesos();
                BtnProcNuevo_Click(null, EventArgs.Empty);
            }
            catch (Exception ex) { MessageBox.Show("Error al guardar proceso: " + ex.Message); }
        }

        private void BtnProcEliminar_Click(object sender, EventArgs e)
        {
            if (!_idProcEditando.HasValue) { MessageBox.Show("Seleccione un proceso."); return; }
            if (MessageBox.Show("¿Eliminar proceso?", "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try
            {
                new DLabProcesos().Eliminar(_idProcEditando.Value);
                CargarProcesos();
            }
            catch (Exception ex) { MessageBox.Show("Error al eliminar proceso: " + ex.Message); }
        }
        #endregion

        #region Parámetros
        private void CargarParametros()
        {
            if (!_idProcEditando.HasValue) { dgvParametros.DataSource = null; return; }
            try
            {
                var d = new DLabParametros();
                var dt = d.Listar(_idProcEditando.Value);
                dgvParametros.DataSource = dt;
                if (dt != null && dt.Rows.Count > 0)
                {
                    SelectFirstVisibleRow(dgvParametros);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar parámetros: " + ex.Message);
            }
        }

        private void DgvParametros_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvParametros.CurrentRow == null) { _idParamEditando = null; return; }
            var drv = dgvParametros.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) { _idParamEditando = null; return; }
            _idParamEditando = SafeInt(drv["id"]);
            txtParamNombre.Text = SafeString(drv["nombre"]);
            txtParamUnidad.Text = SafeString(drv["unidad"]);
            txtParamMin.Text = SafeString(drv["ref_min"]);
            txtParamMax.Text = SafeString(drv["ref_max"]);
            txtParamOrden.Text = SafeString(drv["orden"]);
            txtParamNotas.Text = SafeString(drv["notas"]);
            if (drv.Row.Table.Columns.Contains("activo"))
            {
                chkParamActivo.Checked = SafeBool(drv["activo"]);
            }
        }

        private void BtnParamNuevo_Click(object sender, EventArgs e)
        {
            _idParamEditando = null;
            txtParamNombre.Clear();
            txtParamUnidad.Clear();
            txtParamMin.Clear();
            txtParamMax.Clear();
            txtParamOrden.Clear();
            txtParamNotas.Clear();
            chkParamActivo.Checked = true;
            dgvParametros.ClearSelection();
            txtParamNombre.Focus();
        }

        private void BtnParamGuardar_Click(object sender, EventArgs e)
        {
            if (!_idProcEditando.HasValue) { MessageBox.Show("Seleccione un proceso primero."); return; }
            if (string.IsNullOrWhiteSpace(txtParamNombre.Text)) { MessageBox.Show("Nombre de parámetro requerido."); txtParamNombre.Focus(); return; }

            var param = new ELabParametro
            {
                Id = _idParamEditando ?? 0,
                ProcesoId = _idProcEditando.Value,
                Nombre = txtParamNombre.Text.Trim(),
                Unidad = txtParamUnidad.Text.Trim(),
                RefMin = txtParamMin.Text.Trim(),
                RefMax = txtParamMax.Text.Trim(),
                Orden = SafeIntForOrder(txtParamOrden.Text),
                Notas = txtParamNotas.Text.Trim(),
                Activo = chkParamActivo.Checked
            };

            try
            {
                var d = new DLabParametros();
                if (_idParamEditando.HasValue) d.Actualizar(param); else d.Insertar(param);
                MessageBox.Show("Parámetro guardado.");
                CargarParametros();
                BtnParamNuevo_Click(null, EventArgs.Empty);
            }
            catch (Exception ex) { MessageBox.Show("Error al guardar parámetro: " + ex.Message); }
        }

        private void BtnParamEliminar_Click(object sender, EventArgs e)
        {
            if (!_idParamEditando.HasValue) { MessageBox.Show("Seleccione un parámetro."); return; }
            if (MessageBox.Show("¿Eliminar parámetro?", "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try
            {
                new DLabParametros().Eliminar(_idParamEditando.Value);
                CargarParametros();
            }
            catch (Exception ex) { MessageBox.Show("Error al eliminar parámetro: " + ex.Message); }
        }
        #endregion

        #region Emision de Resultados
        private void BtnEmitirResultado_Click(object sender, EventArgs e)
        {
            if (!_idProcEditando.HasValue)
            {
                MessageBox.Show("Por favor, seleccione un proceso para emitir un resultado.", "Proceso no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var form = new FrmEmitirResultado(_idProcEditando.Value))
            {
                form.ShowDialog();
            }
        }
        #endregion
    }
}
