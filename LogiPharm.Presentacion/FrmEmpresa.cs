using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using LogiPharm.Datos;
using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmEmpresa : Form
    {
        private EEmpresa _empresaActual;
        private string _rutaArchivoP12Seleccionado = ""; // Para guardar la ruta del archivo que el usuario elige

        public FrmEmpresa()
        {
            InitializeComponent();
            
            // ✨ APLICAR ESTILOS PROFESIONALES
            ConfigurarEstilosProfesionales();
            
            this.Load += FrmEmpresa_Load;
            this.btnGuardar.Click += btnGuardar_Click;
            this.btnCambiarLogo.Click += btnCambiarLogo_Click;
            this.btnCancelar.Click += (s, e) => this.Close();
            this.btnSeleccionarCertificado.Click += btnSeleccionarCertificado_Click;
        }
        
        // ========================================
        // CONFIGURACIÓN DE ESTILOS PROFESIONALES
        // ========================================
        private void ConfigurarEstilosProfesionales()
        {
            // === FORMULARIO ===
            this.BackColor = EstilosHelper.Colores.FondoSecundario;
            guna2Panel1.BackColor = EstilosHelper.Colores.FondoPrimario;
            
            // === TÍTULO ===
            label1.Font = EstilosHelper.Fuentes.TituloGrande;
            label1.ForeColor = EstilosHelper.Colores.TextoPrincipal;
            
            // === TAB CONTROL - AZUL PROFESIONAL ===
            // Tab seleccionado
            guna2TabControl1.TabButtonSelectedState.FillColor = Color.White;
            guna2TabControl1.TabButtonSelectedState.ForeColor = EstilosHelper.Colores.PrincipalOscuro;
            guna2TabControl1.TabButtonSelectedState.InnerColor = EstilosHelper.Colores.PrincipalOscuro;
            guna2TabControl1.TabButtonSelectedState.Font = EstilosHelper.Fuentes.TextoNormalBold;
            
            // Tab hover
            guna2TabControl1.TabButtonHoverState.FillColor = EstilosHelper.Colores.FondoHover;
            guna2TabControl1.TabButtonHoverState.ForeColor = EstilosHelper.Colores.PrincipalOscuro;
            guna2TabControl1.TabButtonHoverState.InnerColor = EstilosHelper.Colores.PrincipalClaro;
            guna2TabControl1.TabButtonHoverState.Font = EstilosHelper.Fuentes.TextoNormal;
            
            // Tab inactivo
            guna2TabControl1.TabButtonIdleState.FillColor = Color.White;
            guna2TabControl1.TabButtonIdleState.ForeColor = EstilosHelper.Colores.TextoSecundario;
            guna2TabControl1.TabButtonIdleState.InnerColor = Color.White;
            guna2TabControl1.TabButtonIdleState.Font = EstilosHelper.Fuentes.TextoNormal;
            
            // === BOTÓN GUARDAR - AZUL PROFESIONAL ===
            btnGuardar.FillColor = EstilosHelper.Colores.PrincipalOscuro;
            btnGuardar.Font = EstilosHelper.Fuentes.TextoNormalBold;
            btnGuardar.ForeColor = EstilosHelper.Colores.TextoBlanco;
            
            // === BOTÓN CANCELAR - GRIS ===
            btnCancelar.FillColor = EstilosHelper.Colores.FondoSecundario;
            btnCancelar.Font = EstilosHelper.Fuentes.TextoNormal;
            btnCancelar.ForeColor = EstilosHelper.Colores.TextoPrincipal;
            
            // === LABELS DE SECCIÓN ===
            label2.Font = EstilosHelper.Fuentes.SubTitulo;
            label2.ForeColor = EstilosHelper.Colores.TextoPrincipal;
            
            label4.Font = EstilosHelper.Fuentes.TextoPequeño;
            label4.ForeColor = EstilosHelper.Colores.TextoSecundario;
            
            // === TEXTBOXES ===
            foreach (Control control in tabPageDatosGenerales.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2TextBox txt)
                {
                    txt.Font = EstilosHelper.Fuentes.TextoNormal;
                }
            }
            
            foreach (Control control in tabPageFacturacion.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2TextBox txt)
                {
                    txt.Font = EstilosHelper.Fuentes.TextoNormal;
                }
            }
        }

        private void FrmEmpresa_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            CargarDatos();

            // Auditoría: VISUALIZAR
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Configuración", "VISUALIZAR", "empresa", null, "Abrir Configuración de Empresa", null, Environment.MachineName, "UI"); } catch { }
        }

        private void CargarDatos()
        {
            try
            {
                DEmpresa d_empresa = new DEmpresa();
                _empresaActual = d_empresa.ObtenerDatosEmpresa();

                if (_empresaActual == null)
                {
                    // Si no se encuentra empresa, creamos un objeto nuevo y vacío.
                    _empresaActual = new EEmpresa();
                    MessageBox.Show("No se encontraron datos de la empresa. Por favor, complete la información para crear el registro.", "Primera Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; // Salimos para no intentar llenar los campos desde un objeto vacío.
                }

                // Si el código llega hasta aquí, significa que _empresaActual SÍ tiene datos.
                // Por lo tanto, ahora es seguro llenar todos los campos.
                txtRuc.Text = _empresaActual.Ruc;
                txtRazonSocial.Text = _empresaActual.RazonSocial;
                txtNombreComercial.Text = _empresaActual.NombreComercial;
                txtDireccion.Text = _empresaActual.DireccionMatriz;
                txtTelefono.Text = _empresaActual.Telefono;
                txtEmail.Text = _empresaActual.Email;

                // ✅ Cargar datos del certificado
                txtRutaCertificado.Text = _empresaActual.CertificadoP12Path;
                if (_empresaActual.CertificadoFechaExpiracion.HasValue)
                {
                    dtpFechaExpiracion.Value = _empresaActual.CertificadoFechaExpiracion.Value;
                }

                // ✅ NUEVOS CAMPOS - Información Fiscal
                txtContribuyenteEspecial.Text = _empresaActual.ContribuyenteEspecial ?? "";
                cboAmbienteSRI.SelectedItem = _empresaActual.AmbienteSRI ?? "Pruebas";
                chkObligadoContabilidad.Checked = _empresaActual.ObligadoContabilidad;

                if (_empresaActual.Logo != null && _empresaActual.Logo.Length > 0)
                {
                    using (var ms = new MemoryStream(_empresaActual.Logo))
                    {
                        picLogo.Image = Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de la empresa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCambiarLogo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.gif";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picLogo.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void btnSeleccionarCertificado_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Certificado P12|*.p12";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _rutaArchivoP12Seleccionado = ofd.FileName;
                    txtRutaCertificado.Text = _rutaArchivoP12Seleccionado;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea guardar los cambios?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                bool esNuevo = string.IsNullOrWhiteSpace(_empresaActual?.Ruc);

                // Pasamos los datos de la UI a nuestro objeto
                _empresaActual.Ruc = txtRuc.Text;
                _empresaActual.RazonSocial = txtRazonSocial.Text;
                _empresaActual.NombreComercial = txtNombreComercial.Text;
                _empresaActual.DireccionMatriz = txtDireccion.Text;
                _empresaActual.Telefono = txtTelefono.Text;
                _empresaActual.Email = txtEmail.Text;

                // ✅ NUEVOS CAMPOS - Información Fiscal (comentados hasta agregar controles)
                _empresaActual.ContribuyenteEspecial = txtContribuyenteEspecial.Text;
                _empresaActual.AmbienteSRI = cboAmbienteSRI.SelectedItem?.ToString();
                _empresaActual.ObligadoContabilidad = chkObligadoContabilidad.Checked;

                // Convertimos la imagen a byte[] para guardarla
                if (picLogo.Image != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        picLogo.Image.Save(ms, picLogo.Image.RawFormat);
                        _empresaActual.Logo = ms.ToArray();
                    }
                }

                if (!string.IsNullOrEmpty(_rutaArchivoP12Seleccionado))
                {
                    string carpetaDestino = Path.Combine(Application.StartupPath, "Certificados");
                    Directory.CreateDirectory(carpetaDestino);
                    string nombreArchivo = Path.GetFileName(_rutaArchivoP12Seleccionado);
                    string rutaDestinoFinal = Path.Combine(carpetaDestino, nombreArchivo);
                    File.Copy(_rutaArchivoP12Seleccionado, rutaDestinoFinal, true);

                    _empresaActual.CertificadoP12Path = rutaDestinoFinal; // Guardamos la nueva ruta
                }

                // Si el usuario escribió una nueva contraseña, la encriptamos y guardamos
                if (!string.IsNullOrEmpty(txtCertificadoPass.Text))
                {
                    _empresaActual.CertificadoPassword = Encriptador.Encriptar(txtCertificadoPass.Text);
                }

                _empresaActual.CertificadoFechaExpiracion = dtpFechaExpiracion.Value;

                // Guardamos en la base de datos
                DEmpresa d_empresa = new DEmpresa();
                d_empresa.GuardarDatosEmpresa(_empresaActual);

                // Auditoría: CREAR / EDITAR
                try
                {
                    string accion = esNuevo ? "CREAR" : "EDITAR";
                    new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Configuración", accion, "empresa", null, "Guardar configuración de empresa", null, Environment.MachineName, "UI");
                }
                catch { }

                MessageBox.Show("Datos de la empresa actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}