using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using LogiPharm.Entidades;
using LogiPharm.Negocio;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmFirmaElectronica : Form
    {
        private EEmpresa _empresaActual;
        private string _rutaArchivoSeleccionado = "";
        private DateTime _fechaExpiracionCertificado;

        public FrmFirmaElectronica()
        {
            InitializeComponent();
            
            // Eventos
            this.Load += FrmFirmaElectronica_Load;
            this.btnSeleccionarCertificado.Click += BtnSeleccionarCertificado_Click;
            this.btnValidar.Click += BtnValidar_Click;
            this.btnGuardar.Click += BtnGuardar_Click;
            this.btnCancelar.Click += (s, e) => this.Close();
        }

        private void FrmFirmaElectronica_Load(object sender, EventArgs e)
        {
            try { NBitacora.Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Configuración", "VISUALIZAR", "firma_electronica", null, "Abrir Configuración de Firma Electrónica", null, Environment.MachineName, "UI"); } catch { }

            EstilosHelper.EstilizarFormulario(this);
            ConfigurarColoresEstilos();
            CargarDatosExistentes();
        }

        private void ConfigurarColoresEstilos()
        {
            // Aplicar colores de la paleta
            this.BackColor = EstilosHelper.Colores.FondoSecundario;
            guna2Panel1.BackColor = EstilosHelper.Colores.FondoPrimario;
            
            label1.Font = EstilosHelper.Fuentes.TituloGrande;
            label1.ForeColor = EstilosHelper.Colores.TextoPrincipal;

            lblRuta.Font = EstilosHelper.Fuentes.TextoNormalBold;
            lblRuta.ForeColor = EstilosHelper.Colores.TextoPrincipal;
            txtRutaCertificado.Font = EstilosHelper.Fuentes.TextoNormal;

            lblPassword.Font = EstilosHelper.Fuentes.TextoNormalBold;
            lblPassword.ForeColor = EstilosHelper.Colores.TextoPrincipal;
            txtCertificadoPass.Font = EstilosHelper.Fuentes.TextoNormal;

            btnValidar.FillColor = EstilosHelper.Colores.PrincipalOscuro;
            btnValidar.Font = EstilosHelper.Fuentes.TextoNormalBold;
            btnValidar.ForeColor = EstilosHelper.Colores.TextoBlanco;

            btnCancelar.FillColor = EstilosHelper.Colores.FondoSecundario;
            btnCancelar.Font = EstilosHelper.Fuentes.TextoNormal;
            btnCancelar.ForeColor = EstilosHelper.Colores.TextoPrincipal;

            btnGuardar.Font = EstilosHelper.Fuentes.TextoNormalBold;
            btnGuardar.ForeColor = EstilosHelper.Colores.TextoBlanco;
            
            // Panel de detalles
            lblDetalleTitulo.Font = EstilosHelper.Fuentes.SubTitulo;
            lblDetalleTitulo.ForeColor = EstilosHelper.Colores.PrincipalOscuro;
            lblPropietario.Font = EstilosHelper.Fuentes.TextoPequeño;
            lblEmisor.Font = EstilosHelper.Fuentes.TextoPequeño;
            lblVigencia.Font = EstilosHelper.Fuentes.TextoPequeño;
            lblExpiracion.Font = EstilosHelper.Fuentes.TextoPequeño;
            lblEstado.Font = EstilosHelper.Fuentes.TextoPequeñoBold;
        }

        private void CargarDatosExistentes()
        {
            try
            {
                _empresaActual = NEmpresa.ObtenerDatosEmpresa();
                if (_empresaActual == null)
                {
                    _empresaActual = new EEmpresa();
                    return;
                }

                if (!string.IsNullOrEmpty(_empresaActual.CertificadoP12Path))
                {
                    txtRutaCertificado.Text = _empresaActual.CertificadoP12Path;
                    _rutaArchivoSeleccionado = _empresaActual.CertificadoP12Path;

                    if (!string.IsNullOrEmpty(_empresaActual.CertificadoPassword))
                    {
                        try
                        {
                            string passDesencriptada = Encriptador.Desencriptar(_empresaActual.CertificadoPassword);
                            txtCertificadoPass.Text = passDesencriptada;
                            
                            // Validar y cargar detalles automáticamente si el archivo existe
                            if (File.Exists(_rutaArchivoSeleccionado))
                            {
                                IntentarValidarCertificado(_rutaArchivoSeleccionado, passDesencriptada, false);
                            }
                        }
                        catch
                        {
                            // Ignorar error de desencriptación/validación silenciosa al cargar
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos existentes de firma electrónica: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSeleccionarCertificado_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Certificado de Firma Electrónica (*.p12)|*.p12|Todos los archivos (*.*)|*.*";
                ofd.Title = "Seleccionar Certificado P12";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _rutaArchivoSeleccionado = ofd.FileName;
                    txtRutaCertificado.Text = _rutaArchivoSeleccionado;
                    
                    // Resetear estado de guardado
                    btnGuardar.Enabled = false;
                    guna2PanelDetalles.Visible = false;
                }
            }
        }

        private void BtnValidar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_rutaArchivoSeleccionado))
            {
                MessageBox.Show("Por favor, seleccione un archivo de certificado (.p12).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string password = txtCertificadoPass.Text.Trim();
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, ingrese la contraseña del certificado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IntentarValidarCertificado(_rutaArchivoSeleccionado, password, true);
        }

        private void IntentarValidarCertificado(string ruta, string password, bool mostrarMensajeExito)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!File.Exists(ruta))
                {
                    throw new FileNotFoundException("El archivo del certificado no se encuentra en la ruta especificada.");
                }

                // Cargar el certificado usando la contraseña
                X509Certificate2 cert = new X509Certificate2(ruta, password, X509KeyStorageFlags.Exportable);
                
                // Extraer detalles
                string propietario = cert.Subject;
                string emisor = cert.Issuer;
                DateTime desde = cert.NotBefore;
                DateTime hasta = cert.NotAfter;
                
                _fechaExpiracionCertificado = hasta;

                // Formatear y mostrar detalles
                lblPropietario.Text = "Propietario: " + ExtraerValorDeDistinguishedName(propietario, "CN=");
                lblEmisor.Text = "Emisor: " + ExtraerValorDeDistinguishedName(emisor, "CN=");
                lblVigencia.Text = "Validez Desde: " + desde.ToString("dd/MM/yyyy HH:mm:ss");
                lblExpiracion.Text = "Validez Hasta: " + hasta.ToString("dd/MM/yyyy HH:mm:ss");

                // Verificar vigencia
                bool estaVigente = DateTime.Now >= desde && DateTime.Now <= hasta;
                if (estaVigente)
                {
                    lblEstado.Text = "Estado: VIGENTE";
                    lblEstado.ForeColor = EstilosHelper.Colores.Exito;
                }
                else
                {
                    lblEstado.Text = "Estado: EXPIRADO";
                    lblEstado.ForeColor = EstilosHelper.Colores.Peligro;
                }

                guna2PanelDetalles.Visible = true;
                btnGuardar.Enabled = true;

                if (mostrarMensajeExito)
                {
                    MessageBox.Show("Certificado validado con éxito. Su firma es " + (estaVigente ? "vigente." : "inválida/expirada."), "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                btnGuardar.Enabled = false;
                guna2PanelDetalles.Visible = false;
                MessageBox.Show("Error al validar el certificado: " + ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private string ExtraerValorDeDistinguishedName(string dn, string key)
        {
            if (string.IsNullOrEmpty(dn)) return "-";
            int idx = dn.IndexOf(key, StringComparison.OrdinalIgnoreCase);
            if (idx == -1) return dn;
            
            idx += key.Length;
            int endIdx = dn.IndexOf(',', idx);
            if (endIdx == -1)
            {
                return dn.Substring(idx).Trim();
            }
            return dn.Substring(idx, endIdx - idx).Trim();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_rutaArchivoSeleccionado))
            {
                MessageBox.Show("Seleccione primero un certificado.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de que desea guardar la configuración de firma electrónica?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Si es un archivo nuevo seleccionado desde otra ubicación, copiarlo a la carpeta del sistema
                string carpetaCertificados = Path.Combine(Application.StartupPath, "Certificados");
                if (!Directory.Exists(carpetaCertificados))
                {
                    Directory.CreateDirectory(carpetaCertificados);
                }

                string nombreArchivo = Path.GetFileName(_rutaArchivoSeleccionado);
                string rutaDestino = Path.Combine(carpetaCertificados, nombreArchivo);

                if (_rutaArchivoSeleccionado != rutaDestino)
                {
                    File.Copy(_rutaArchivoSeleccionado, rutaDestino, true);
                }

                // Guardar en la base de datos
                _empresaActual.CertificadoP12Path = rutaDestino;
                _empresaActual.CertificadoPassword = Encriptador.Encriptar(txtCertificadoPass.Text.Trim());
                _empresaActual.CertificadoFechaExpiracion = _fechaExpiracionCertificado;

                NEmpresa.GuardarDatosEmpresa(_empresaActual);

                // Registrar auditoría
                try { NBitacora.Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Configuración", "EDITAR", "firma_electronica", null, "Guardar configuración de firma electrónica", null, Environment.MachineName, "UI"); } catch { }

                MessageBox.Show("Configuración de firma electrónica guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la configuración: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
