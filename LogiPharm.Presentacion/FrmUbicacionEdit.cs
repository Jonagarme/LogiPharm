using System;
using System.Data;
using System.Windows.Forms;
using LogiPharm.Negocio;
using LogiPharm.Datos;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmUbicacionEdit : Form
    {
        private int _idUbicacion = 0;

        public FrmUbicacionEdit()
        {
            InitializeComponent();
            this.Load += FrmUbicacionEdit_Load;
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            btnGuardar.Click += BtnGuardar_Click;
        }

        public FrmUbicacionEdit(int idUbicacion) : this()
        {
            _idUbicacion = idUbicacion;
        }

        private void FrmUbicacionEdit_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterParent;

            cboTipo.Items.Clear();
            cboTipo.Items.AddRange(new object[] { "Bodega", "Sucursal", "Almacen" });
            cboTipo.SelectedItem = "Bodega";

            if (_idUbicacion > 0)
            {
                this.Text = "Editar Bodega / Ubicación";
                CargarDatosUbicacion();
            }
            else
            {
                this.Text = "Nueva Bodega / Ubicación";
            }
        }

        private void CargarDatosUbicacion()
        {
            try
            {
                DataTable dt = NUbicaciones.ObtenerUbicacionPorId(_idUbicacion);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtCodigo.Text = row["codigo"].ToString();
                    txtNombre.Text = row["nombre"].ToString();
                    txtDireccion.Text = row["direccion"].ToString();
                    txtTelefono.Text = row["telefono"].ToString();
                    txtResponsable.Text = row["responsable"].ToString();

                    string tipo = row["tipo"].ToString();
                    if (cboTipo.Items.Contains(tipo))
                    {
                        cboTipo.SelectedItem = tipo;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de la ubicación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string codigo = (txtCodigo.Text ?? "").Trim();
            string nombre = (txtNombre.Text ?? "").Trim();
            string tipo = cboTipo.SelectedItem?.ToString() ?? "Bodega";
            string direccion = (txtDireccion.Text ?? "").Trim();
            string telefono = (txtTelefono.Text ?? "").Trim();
            string responsable = (txtResponsable.Text ?? "").Trim();

            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("El código de la ubicación es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre de la ubicación es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            try
            {
                int idEmpresa = SesionActual.IdEmpresa;
                int creadoPor = SesionActual.IdUsuario;
                bool exito;

                if (_idUbicacion > 0)
                {
                    exito = NUbicaciones.ActualizarUbicacion(
                        _idUbicacion,
                        codigo,
                        nombre,
                        tipo,
                        direccion,
                        telefono,
                        responsable,
                        SesionActual.IdUsuario
                    );
                }
                else
                {
                    exito = NUbicaciones.InsertarUbicacion(
                        codigo,
                        nombre,
                        tipo,
                        direccion,
                        telefono,
                        responsable,
                        idEmpresa,
                        creadoPor
                    );
                }

                if (exito)
                {
                    try
                    {
                        new DBitacora().Registrar(
                            SesionActual.IdUsuario, 
                            SesionActual.NombreUsuario, 
                            "Inventario", 
                            _idUbicacion > 0 ? "EDITAR" : "CREAR", 
                            "inventario_ubicacion", 
                            _idUbicacion > 0 ? (int?)_idUbicacion : null, 
                            _idUbicacion > 0 ? $"Editar ubicación/bodega {codigo}: {nombre}" : $"Crear ubicación/bodega {codigo}: {nombre}", 
                            null, 
                            Environment.MachineName, 
                            "UI"
                        );
                    }
                    catch { }

                    MessageBox.Show("Bodega/Ubicación guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la bodega/ubicación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
