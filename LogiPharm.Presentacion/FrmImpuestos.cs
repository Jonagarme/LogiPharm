using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmImpuestos : Form
    {
        private int? _idEditando = null;

        public FrmImpuestos()
        {
            InitializeComponent();
            this.Load += FrmImpuestos_Load;
            this.btnGuardar.Click += btnGuardar_Click;
            this.btnNuevo.Click += btnNuevo_Click;
            this.dgvImpuestos.SelectionChanged += dgvImpuestos_SelectionChanged;
        }

        private void FrmImpuestos_Load(object sender, EventArgs e)
        {
            CargarImpuestos();
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Configuración", "VISUALIZAR", "impuestos", null, "Abrir Impuestos", null, Environment.MachineName, "UI"); } catch { }
        }

        private void CargarImpuestos()
        {
            try
            {
                var d = new DImpuestos();
                var dt = d.ListarImpuestos();
                dgvImpuestos.DataSource = dt;
                if (dgvImpuestos.Columns.Contains("id")) dgvImpuestos.Columns["id"].Visible = false;

                // Ajuste de encabezados
                if (dgvImpuestos.Columns.Contains("codigo")) dgvImpuestos.Columns["codigo"].HeaderText = "Código";
                if (dgvImpuestos.Columns.Contains("nombre")) dgvImpuestos.Columns["nombre"].HeaderText = "Nombre";
                if (dgvImpuestos.Columns.Contains("porcentaje")) dgvImpuestos.Columns["porcentaje"].HeaderText = "%";
                if (dgvImpuestos.Columns.Contains("vigenteDesde")) dgvImpuestos.Columns["vigenteDesde"].HeaderText = "Desde";
                if (dgvImpuestos.Columns.Contains("vigenteHasta")) dgvImpuestos.Columns["vigenteHasta"].HeaderText = "Hasta";
                if (dgvImpuestos.Columns.Contains("activo")) dgvImpuestos.Columns["activo"].HeaderText = "Activo";
                if (dgvImpuestos.Columns.Contains("descripcion")) dgvImpuestos.Columns["descripcion"].HeaderText = "Descripción";

                dgvImpuestos.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar impuestos: " + ex.Message);
            }
        }

        private void dgvImpuestos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvImpuestos.CurrentRow == null || dgvImpuestos.CurrentRow.DataBoundItem == null)
            {
                _idEditando = null;
                return;
            }

            var drv = dgvImpuestos.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) { _idEditando = null; return; }

            // Llenar campos desde la fila seleccionada
            _idEditando = Convert.ToInt32(drv["id"]);
            txtCodigo.Text = Convert.ToString(drv["codigo"]);
            txtNombre.Text = Convert.ToString(drv["nombre"]);

            // porcentaje se almacena como 0.15 -> mostrar 15
            decimal porc = 0m;
            if (drv.Row.Table.Columns.Contains("porcentaje") && decimal.TryParse(Convert.ToString(drv["porcentaje"]), out porc))
            {
                if (porc < 1) porc *= 100m; // si viene 0.15, mostrar 15
                if (porc > numPorcentaje.Maximum) porc = numPorcentaje.Maximum;
                if (porc < numPorcentaje.Minimum) porc = numPorcentaje.Minimum;
                numPorcentaje.Value = porc;
            }
            else
            {
                numPorcentaje.Value = 0;
            }

            if (drv.Row.Table.Columns.Contains("vigenteDesde"))
            {
                if (drv["vigenteDesde"] == DBNull.Value) { dtDesde.Checked = false; }
                else { dtDesde.Checked = true; dtDesde.Value = Convert.ToDateTime(drv["vigenteDesde"]); }
            }
            if (drv.Row.Table.Columns.Contains("vigenteHasta"))
            {
                if (drv["vigenteHasta"] == DBNull.Value) { dtHasta.Checked = false; }
                else { dtHasta.Checked = true; dtHasta.Value = Convert.ToDateTime(drv["vigenteHasta"]); }
            }

            if (drv.Row.Table.Columns.Contains("activo"))
                chkActivo.Checked = Convert.ToBoolean(drv["activo"]);
           
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _idEditando = null;
            txtCodigo.Text = "IVA";
            txtNombre.Text = "Impuesto al Valor Agregado";
            numPorcentaje.Value = 12; // ejemplo
            chkActivo.Checked = true;
            dtDesde.Checked = false;
            dtHasta.Checked = false;
            dgvImpuestos.ClearSelection();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    MessageBox.Show("El código es obligatorio.");
                    txtCodigo.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("El nombre es obligatorio.");
                    txtNombre.Focus();
                    return;
                }

                var imp = new EImpuesto
                {
                    Id = _idEditando ?? 0,
                    Codigo = txtCodigo.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Porcentaje = numPorcentaje.Value / 100m,
                    VigenteDesde = dtDesde.Checked ? dtDesde.Value.Date : (DateTime?)null,
                    VigenteHasta = dtHasta.Checked ? dtHasta.Value.Date : (DateTime?)null,
                    Activo = chkActivo.Checked
                };

                var d = new DImpuestos();
                if (_idEditando.HasValue && _idEditando.Value > 0)
                {
                    d.ActualizarImpuesto(imp);
                    try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Configuración", "EDITAR", "impuestos", imp.Id, $"Actualizar impuesto {imp.Codigo} {imp.Porcentaje:P2}", null, Environment.MachineName, "UI"); } catch { }
                }
                else
                {
                    d.GuardarImpuesto(imp);
                    try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Configuración", "CREAR", "impuestos", null, $"Guardar impuesto {imp.Codigo} {imp.Porcentaje:P2}", null, Environment.MachineName, "UI"); } catch { }
                }

                ImpuestoProvider.Invalidate();

                MessageBox.Show("Impuesto guardado.");
                CargarImpuestos();
                btnNuevo_Click(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }
    }
}
