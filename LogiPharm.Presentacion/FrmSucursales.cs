using LogiPharm.Datos;
using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace LogiPharm.Presentacion
{
    public partial class FrmSucursales : Form
    {
        private readonly BindingSource _bs = new BindingSource();
        private DataTable _dt;

        public FrmSucursales()
        {
            InitializeComponent();
        }

        private void FrmSucursales_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarSucursales();

            txtBuscar.TextChanged += (s, ee) => AplicarFiltro();
        }

        private void ConfigurarGrid()
        {
            dgvSucursales.AutoGenerateColumns = false;
            dgvSucursales.Columns.Clear();

            dgvSucursales.Columns.Add(new DataGridViewTextBoxColumn { Name = "colId", HeaderText = "ID", DataPropertyName = "id", Visible = false });
            dgvSucursales.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCodigo", HeaderText = "CÓDIGO", DataPropertyName = "codigo", Width = 90, ReadOnly = true });
            dgvSucursales.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNombre", HeaderText = "NOMBRE COMERCIAL", DataPropertyName = "nombre_comercial", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, ReadOnly = true });
            dgvSucursales.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDireccion", HeaderText = "DIRECCIÓN", DataPropertyName = "direccion", Width = 220, ReadOnly = true });
            dgvSucursales.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEstado", HeaderText = "ESTADO", DataPropertyName = "estado", Width = 90, ReadOnly = true });
            dgvSucursales.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCreado", HeaderText = "CREADO", DataPropertyName = "creado_en", Width = 110, DefaultCellStyle = { Format = "dd/MM/yyyy" }, ReadOnly = true });

            dgvSucursales.DataSource = _bs;
        }

        private void CargarSucursales()
        {
            try
            {
                var d = new DEstablecimientos();
                _dt = d.Listar();
                _bs.DataSource = _dt;
                AplicarFiltro();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar sucursales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFiltro()
        {
            if (_dt == null)
            {
                lblTotal.Text = "Total: 0";
                return;
            }

            string crit = (txtBuscar.Text ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(crit))
            {
                _bs.Filter = null;
                lblTotal.Text = $"Total: {_dt.Rows.Count}";
                return;
            }

            string f = EscapeLikeValue(crit);
            _bs.Filter = $"codigo LIKE '%{f}%' OR nombre_comercial LIKE '%{f}%' OR direccion LIKE '%{f}%'";

            int total = 0;
            try
            {
                if (_bs.List is DataView view) total = view.Count;
                else total = _bs.Count;
            }
            catch { total = _bs.Count; }

            lblTotal.Text = $"Total: {total}";
        }

        private static string EscapeLikeValue(string value)
        {
            if (value == null) return string.Empty;
            return value.Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]").Replace("'", "''");
        }

        private int? ObtenerIdSeleccionado()
        {
            if (dgvSucursales.CurrentRow == null) return null;
            object val = dgvSucursales.CurrentRow.Cells["colId"].Value;
            if (val == null || val == DBNull.Value) return null;
            return Convert.ToInt32(val);
        }

        private EEstablecimiento ObtenerModeloSeleccionado()
        {
            if (dgvSucursales.CurrentRow == null) return null;
            var r = dgvSucursales.CurrentRow;

            object idObj = r.Cells["colId"].Value;
            if (idObj == null || idObj == DBNull.Value) return null;

            return new EEstablecimiento
            {
                Id = Convert.ToInt32(idObj),
                Codigo = Convert.ToString(r.Cells["colCodigo"].Value),
                NombreComercial = Convert.ToString(r.Cells["colNombre"].Value),
                Direccion = Convert.ToString(r.Cells["colDireccion"].Value),
                Estado = Convert.ToString(r.Cells["colEstado"].Value)
            };
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (var f = new FrmEstablecimientoEdit(null))
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                    CargarSucursales();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var model = ObtenerModeloSeleccionado();
            if (model == null)
            {
                MessageBox.Show("Seleccione una sucursal para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var f = new FrmEstablecimientoEdit(model))
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                    CargarSucursales();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? id = ObtenerIdSeleccionado();
            if (id == null)
            {
                MessageBox.Show("Seleccione una sucursal para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Desea eliminar esta sucursal?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                var d = new DEstablecimientos();
                d.Eliminar(id.Value);
                try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Sucursales", "ELIMINAR", "establecimientos", id.Value, $"Eliminar sucursal {id.Value}", null, Environment.MachineName, "UI"); } catch { }
                CargarSucursales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarSucursales();
        }

        private void dgvSucursales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            btnEditar_Click(sender, e);
        }
    }
}
