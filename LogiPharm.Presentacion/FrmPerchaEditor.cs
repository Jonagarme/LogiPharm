using System;
using System.Data;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmPerchaEditor : Form
    {
        private int? perchaId;
        private DPerchas datosPerchas;

        public FrmPerchaEditor(int? idPercha)
        {
            InitializeComponent();
            perchaId = idPercha;
            datosPerchas = new DPerchas();
            
            this.Load += FrmPerchaEditor_Load;
        }

        private void FrmPerchaEditor_Load(object sender, EventArgs e)
        {
            CargarSecciones();
            
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (s, ev) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            if (perchaId.HasValue)
            {
                lblTitulo.Text = "Editar Percha";
                this.Text = "Editar Percha";
                CargarDatosPercha();
            }
            else
            {
                lblTitulo.Text = "Nueva Percha";
                this.Text = "Nueva Percha";
                chkActivo.Checked = true;
            }
        }

        private void CargarSecciones()
        {
            try
            {
                var dt = datosPerchas.ListarSecciones();
                
                // Agregar opción "Sin sección"
                DataRow drNinguna = dt.NewRow();
                drNinguna["Id"] = 0;
                drNinguna["Nombre"] = "(Sin sección)";
                dt.Rows.InsertAt(drNinguna, 0);
                
                cboSeccion.DataSource = dt;
                cboSeccion.DisplayMember = "Nombre";
                cboSeccion.ValueMember = "Id";
                cboSeccion.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar secciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosPercha()
        {
            try
            {
                var percha = datosPerchas.ObtenerPercha(perchaId.Value);
                
                if (percha != null)
                {
                    txtNombre.Text = percha.Nombre;
                    txtDescripcion.Text = percha.Descripcion;
                    numFilas.Value = percha.Filas;
                    numColumnas.Value = percha.Columnas;
                    chkActivo.Checked = percha.Activo;
                    
                    if (percha.SeccionId > 0)
                        cboSeccion.SelectedValue = percha.SeccionId;
                    else
                        cboSeccion.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de la percha: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            try
            {
                var percha = new EPercha
                {
                    Id = perchaId ?? 0,
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Filas = (int)numFilas.Value,
                    Columnas = (int)numColumnas.Value,
                    Activo = chkActivo.Checked,
                    SeccionId = cboSeccion.SelectedValue != null && Convert.ToInt32(cboSeccion.SelectedValue) > 0
                        ? Convert.ToInt32(cboSeccion.SelectedValue)
                        : 0
                };

                bool resultado;
                string accion;

                if (perchaId.HasValue)
                {
                    resultado = datosPerchas.ActualizarPercha(percha);
                    accion = "EDITAR";
                }
                else
                {
                    int nuevoId = datosPerchas.GuardarPercha(percha);
                    resultado = nuevoId > 0;
                    accion = "CREAR";
                }

                if (resultado)
                {
                    // Auditoría
                    try 
                    { 
                        new DBitacora().Registrar(
                            SesionActual.IdUsuario, 
                            SesionActual.NombreUsuario, 
                            "Inventario", 
                            accion, 
                            "perchas", 
                            percha.Id, 
                            $"{accion} percha {percha.Nombre}", 
                            null, 
                            Environment.MachineName, 
                            "UI"
                        ); 
                    } 
                    catch { }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre de la percha.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            // Verificar si el nombre ya existe
            if (datosPerchas.ExisteNombrePercha(txtNombre.Text.Trim(), perchaId))
            {
                MessageBox.Show("Ya existe una percha con ese nombre. Por favor, elija otro nombre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                txtNombre.SelectAll();
                return false;
            }

            if (numFilas.Value < 1 || numFilas.Value > 20)
            {
                MessageBox.Show("El número de filas debe estar entre 1 y 20.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numFilas.Focus();
                return false;
            }

            if (numColumnas.Value < 1 || numColumnas.Value > 20)
            {
                MessageBox.Show("El número de columnas debe estar entre 1 y 20.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numColumnas.Focus();
                return false;
            }

            return true;
        }
    }
}
