using System;
using System.Data;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmPuntoEmisionEdit : Form
    {
        private readonly int _idEstablecimiento;
        private readonly EPuntoEmision _model;

        public FrmPuntoEmisionEdit(int idEstablecimiento, EPuntoEmision model)
        {
            InitializeComponent();
            _idEstablecimiento = idEstablecimiento;
            _model = model;

            this.Load += FrmPuntoEmisionEdit_Load;
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            btnGuardar.Click += BtnGuardar_Click;
        }

        private void FrmPuntoEmisionEdit_Load(object sender, EventArgs e)
        {
            CargarUsuarios();

            if (_model != null)
            {
                Text = "Editar Punto de Emisión";
                txtCodigo.Text = _model.Codigo;
                txtDescripcion.Text = _model.Descripcion;
                chkActivo.Checked = _model.Activo;

                numFactura.Value = _model.SecuencialFactura;
                numNotaCredito.Value = _model.SecuencialNotaCredito;
                numNotaDebito.Value = _model.SecuencialNotaDebito;
                numGuiaRemision.Value = _model.SecuencialGuiaRemision;
                numRetencion.Value = _model.SecuencialRetencion;

                if (_model.IdUsuarioResponsable.HasValue)
                    cboUsuarioResponsable.SelectedValue = _model.IdUsuarioResponsable.Value;
            }
            else
            {
                Text = "Nuevo Punto de Emisión";
                chkActivo.Checked = true;
                numFactura.Value = 1;
                numNotaCredito.Value = 1;
                numNotaDebito.Value = 1;
                numGuiaRemision.Value = 1;
                numRetencion.Value = 1;
            }
        }

        private void CargarUsuarios()
        {
            var dt = new DUsuariosLookup().ListarActivos();
            if (dt == null) dt = new DataTable();

            if (!dt.Columns.Contains("id")) dt.Columns.Add("id", typeof(int));
            if (!dt.Columns.Contains("nombreUsuario")) dt.Columns.Add("nombreUsuario", typeof(string));

            var row = dt.NewRow();
            row["id"] = 0;
            row["nombreUsuario"] = "-- Seleccionar Usuario --";
            dt.Rows.InsertAt(row, 0);

            cboUsuarioResponsable.DataSource = dt;
            cboUsuarioResponsable.DisplayMember = "nombreUsuario";
            cboUsuarioResponsable.ValueMember = "id";
            cboUsuarioResponsable.SelectedIndex = 0;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string codigo = (txtCodigo.Text ?? "").Trim();
            if (codigo.Length != 3)
            {
                MessageBox.Show("El código debe tener exactamente 3 dígitos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return;
            }

            int idUsuario = 0;
            if (cboUsuarioResponsable.SelectedValue != null)
                int.TryParse(Convert.ToString(cboUsuarioResponsable.SelectedValue), out idUsuario);

            var p = _model ?? new EPuntoEmision();
            p.IdEstablecimiento = _idEstablecimiento;
            p.Codigo = codigo;
            p.Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? null : txtDescripcion.Text.Trim();
            p.IdUsuarioResponsable = (idUsuario > 0) ? (int?)idUsuario : null;
            p.Activo = chkActivo.Checked;

            p.SecuencialFactura = (int)numFactura.Value;
            p.SecuencialNotaCredito = (int)numNotaCredito.Value;
            p.SecuencialNotaDebito = (int)numNotaDebito.Value;
            p.SecuencialGuiaRemision = (int)numGuiaRemision.Value;
            p.SecuencialRetencion = (int)numRetencion.Value;

            try
            {
                var d = new DPuntosEmision();
                if (_model == null)
                {
                    int id = d.Insertar(p);
                    try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Configuración", "CREAR", "puntos_emision", id, $"Crear punto emisión {codigo}", null, Environment.MachineName, "UI"); } catch { }
                }
                else
                {
                    p.Id = _model.Id;
                    d.Actualizar(p);
                    try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Configuración", "EDITAR", "puntos_emision", p.Id, $"Editar punto emisión {codigo}", null, Environment.MachineName, "UI"); } catch { }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
