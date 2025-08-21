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
            this.Load += FrmEmpresa_Load;
            this.btnGuardar.Click += btnGuardar_Click;
            this.btnCambiarLogo.Click += btnCambiarLogo_Click;
            this.btnCancelar.Click += (s, e) => this.Close();
            this.btnSeleccionarCertificado.Click += btnSeleccionarCertificado_Click;
        }

        private void FrmEmpresa_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            CargarDatos();
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

                // ✅ LÍNEAS MOVIDAS AQUÍ: Ahora se cargan los datos del certificado de forma segura.
                txtRutaCertificado.Text = _empresaActual.CertificadoP12Path;
                if (_empresaActual.CertificadoFechaExpiracion.HasValue)
                {
                    dtpFechaExpiracion.Value = _empresaActual.CertificadoFechaExpiracion.Value;
                }

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
                // Pasamos los datos de la UI a nuestro objeto
                _empresaActual.Ruc = txtRuc.Text;
                _empresaActual.RazonSocial = txtRazonSocial.Text;
                _empresaActual.NombreComercial = txtNombreComercial.Text;
                _empresaActual.DireccionMatriz = txtDireccion.Text;
                _empresaActual.Telefono = txtTelefono.Text;
                _empresaActual.Email = txtEmail.Text;

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