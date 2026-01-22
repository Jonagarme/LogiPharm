using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmPuntosEmision : Form
    {
        private int _idEstablecimientoActual;

        public FrmPuntosEmision()
        {
            InitializeComponent();

            dgvEstablecimientos.AutoGenerateColumns = false;
            dgvPuntos.AutoGenerateColumns = false;

            this.Load += FrmPuntosEmision_Load;
            dgvEstablecimientos.SelectionChanged += dgvEstablecimientos_SelectionChanged;

            btnNuevoEstab.Click += btnNuevoEstab_Click;
            btnEditarEstab.Click += btnEditarEstab_Click;
            btnEliminarEstab.Click += btnEliminarEstab_Click;

            btnNuevoPunto.Click += btnNuevoPunto_Click;
            btnEditarPunto.Click += btnEditarPunto_Click;
            btnEliminarPunto.Click += btnEliminarPunto_Click;
        }

        private void FrmPuntosEmision_Load(object sender, EventArgs e)
        {
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Configuración", "VISUALIZAR", "puntos_emision", null, "Abrir Configuración de Puntos de Emisión", null, Environment.MachineName, "UI"); } catch { }
            CargarEstablecimientos();
        }

        private void CargarEstablecimientos()
        {
            try
            {
                var dt = new DEstablecimientos().Listar();
                dgvEstablecimientos.DataSource = dt;

                if (dgvEstablecimientos.Rows.Count > 0)
                {
                    dgvEstablecimientos.ClearSelection();
                    dgvEstablecimientos.Rows[0].Selected = true;
                }
                else
                {
                    _idEstablecimientoActual = 0;
                    dgvPuntos.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar establecimientos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPuntos(int idEstablecimiento)
        {
            try
            {
                var dt = new DPuntosEmision().ListarPorEstablecimiento(idEstablecimiento);
                dgvPuntos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar puntos de emisión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEstablecimientos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEstablecimientos.CurrentRow == null)
            {
                _idEstablecimientoActual = 0;
                dgvPuntos.DataSource = null;
                return;
            }

            var drv = dgvEstablecimientos.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) return;

            _idEstablecimientoActual = Convert.ToInt32(drv["id"]);
            CargarPuntos(_idEstablecimientoActual);
        }

        private void btnNuevoEstab_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmEstablecimientoEdit(null))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                    CargarEstablecimientos();
            }
        }

        private void btnEditarEstab_Click(object sender, EventArgs e)
        {
            if (dgvEstablecimientos.CurrentRow == null) return;

            var drv = dgvEstablecimientos.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) return;

            var estab = new EEstablecimiento
            {
                Id = Convert.ToInt32(drv["id"]),
                Codigo = Convert.ToString(drv["codigo"]),
                NombreComercial = Convert.ToString(drv["nombre_comercial"]),
                Direccion = Convert.ToString(drv["direccion"]),
                Estado = Convert.ToString(drv["estado"])
            };

            using (var frm = new FrmEstablecimientoEdit(estab))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                    CargarEstablecimientos();
            }
        }

        private void btnEliminarEstab_Click(object sender, EventArgs e)
        {
            if (dgvEstablecimientos.CurrentRow == null) return;

            var drv = dgvEstablecimientos.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) return;

            int id = Convert.ToInt32(drv["id"]);
            string codigo = Convert.ToString(drv["codigo"]);

            var r = MessageBox.Show($"¿Eliminar el establecimiento '{codigo}'?\n\nEsto eliminará también sus puntos de emisión.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r != DialogResult.Yes) return;

            try
            {
                new DEstablecimientos().Eliminar(id);
                try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Configuración", "ELIMINAR", "establecimientos", id, $"Eliminar establecimiento {codigo}", null, Environment.MachineName, "UI"); } catch { }
                CargarEstablecimientos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevoPunto_Click(object sender, EventArgs e)
        {
            if (_idEstablecimientoActual <= 0)
            {
                MessageBox.Show("Seleccione un establecimiento primero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var frm = new FrmPuntoEmisionEdit(_idEstablecimientoActual, null))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                    CargarPuntos(_idEstablecimientoActual);
            }
        }

        private void btnEditarPunto_Click(object sender, EventArgs e)
        {
            if (dgvPuntos.CurrentRow == null) return;

            var drv = dgvPuntos.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) return;

            var p = new EPuntoEmision
            {
                Id = Convert.ToInt32(drv["id"]),
                IdEstablecimiento = Convert.ToInt32(drv["id_establecimiento"]),
                Codigo = Convert.ToString(drv["codigo"]),
                Descripcion = Convert.ToString(drv["descripcion"]),
                IdUsuarioResponsable = drv["id_usuario_responsable"] == DBNull.Value ? (int?)null : Convert.ToInt32(drv["id_usuario_responsable"]),
                Activo = Convert.ToInt32(drv["activo"]) == 1,
                SecuencialFactura = Convert.ToInt32(drv["secuencial_factura"]),
                SecuencialNotaCredito = Convert.ToInt32(drv["secuencial_nota_credito"]),
                SecuencialNotaDebito = Convert.ToInt32(drv["secuencial_nota_debito"]),
                SecuencialGuiaRemision = Convert.ToInt32(drv["secuencial_guia_remision"]),
                SecuencialRetencion = Convert.ToInt32(drv["secuencial_retencion"])
            };

            using (var frm = new FrmPuntoEmisionEdit(_idEstablecimientoActual, p))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                    CargarPuntos(_idEstablecimientoActual);
            }
        }

        private void btnEliminarPunto_Click(object sender, EventArgs e)
        {
            if (dgvPuntos.CurrentRow == null) return;

            var drv = dgvPuntos.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) return;

            int id = Convert.ToInt32(drv["id"]);
            string codigo = Convert.ToString(drv["codigo"]);

            var r = MessageBox.Show($"¿Eliminar el punto de emisión '{codigo}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            try
            {
                new DPuntosEmision().Eliminar(id);
                try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Configuración", "ELIMINAR", "puntos_emision", id, $"Eliminar punto emisión {codigo}", null, Environment.MachineName, "UI"); } catch { }
                CargarPuntos(_idEstablecimientoActual);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
