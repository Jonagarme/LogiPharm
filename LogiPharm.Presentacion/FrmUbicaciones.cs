using LogiPharm.Datos;
using LogiPharm.Entidades;
using LogiPharm.Negocio;
using LogiPharm.Presentacion.Utilidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace LogiPharm.Presentacion
{
    public partial class FrmUbicaciones : Form
    {
        private readonly BindingSource _bs = new BindingSource();
        private DataTable _dt;

        public FrmUbicaciones()
        {
            InitializeComponent();
        }

        private void FrmUbicaciones_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarUbicaciones();

            txtBuscar.TextChanged += (s, ee) => AplicarFiltro();
            btnNuevo.Click += BtnNuevo_Click;
            btnActualizar.Click += BtnActualizar_Click;
            dgvUbicaciones.CellDoubleClick += DgvUbicaciones_CellDoubleClick;
            
            // Log auditoría
            try
            {
                new DBitacora().Registrar(
                    SesionActual.IdUsuario, 
                    SesionActual.NombreUsuario, 
                    "Inventario", 
                    "VISUALIZAR", 
                    "inventario_ubicacion", 
                    null, 
                    "Abrir Gestión de Ubicaciones/Bodegas", 
                    null, 
                    Environment.MachineName, 
                    "UI"
                );
            }
            catch { }
        }

        private void ConfigurarGrid()
        {
            dgvUbicaciones.AutoGenerateColumns = false;
            dgvUbicaciones.Columns.Clear();

            dgvUbicaciones.Columns.Add(new DataGridViewTextBoxColumn { Name = "colId", HeaderText = "ID", DataPropertyName = "id", Visible = false });
            dgvUbicaciones.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCodigo", HeaderText = "CÓDIGO", DataPropertyName = "codigo", Width = 90, ReadOnly = true });
            dgvUbicaciones.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNombre", HeaderText = "NOMBRE BODEGA", DataPropertyName = "nombre", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, ReadOnly = true });
            dgvUbicaciones.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTipo", HeaderText = "TIPO", DataPropertyName = "tipo", Width = 110, ReadOnly = true });
            dgvUbicaciones.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDireccion", HeaderText = "DIRECCIÓN", DataPropertyName = "direccion", Width = 220, ReadOnly = true });
            dgvUbicaciones.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTelefono", HeaderText = "TELÉFONO", DataPropertyName = "telefono", Width = 110, ReadOnly = true });
            dgvUbicaciones.Columns.Add(new DataGridViewTextBoxColumn { Name = "colResponsable", HeaderText = "RESPONSABLE", DataPropertyName = "responsable", Width = 130, ReadOnly = true });

            dgvUbicaciones.DataSource = _bs;
        }

        private void CargarUbicaciones()
        {
            try
            {
                _dt = NUbicaciones.ListarUbicacionesActivas();
                _bs.DataSource = _dt;
                AplicarFiltro();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ubicaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            _bs.Filter = $"codigo LIKE '%{f}%' OR nombre LIKE '%{f}%' OR direccion LIKE '%{f}%' OR responsable LIKE '%{f}%'";

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

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            using (var f = new FrmUbicacionEdit())
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                    CargarUbicaciones();
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarUbicaciones();
        }

        private void DgvUbicaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvUbicaciones.Rows[e.RowIndex];
            if (row.Cells["colId"].Value != null && int.TryParse(row.Cells["colId"].Value.ToString(), out int idUbicacion))
            {
                using (var f = new FrmUbicacionEdit(idUbicacion))
                {
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        CargarUbicaciones();
                    }
                }
            }
        }
    }
}
