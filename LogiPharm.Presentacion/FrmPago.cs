using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogiPharm.Datos;
using Formatting = Newtonsoft.Json.Formatting;

namespace LogiPharm.Presentacion
{

    public partial class FrmPago : Form
    {
        private readonly decimal _totalAPagar;
        private readonly ECliente _cliente;
        private readonly List<ProductoVenta> _productos;

        // ↓↓↓ Añadir en FrmPago (dentro de la clase, fuera de métodos)
        public string ClaveAcceso { get; private set; } = "";
        public string NumeroAutorizacion { get; private set; } = "";
        public string SecuencialUsado { get; private set; } = "";
        public string EstadoAutorizacion { get; private set; } = "";
        public string FechaAutorizacionIso { get; private set; } = "";
        public decimal EfectivoRecibido { get; private set; } = 0m;

        public DialogResult Resultado { get; private set; }

        // Constructor actualizado para recibir toda la información de la venta
        public FrmPago(decimal totalAPagar, ECliente cliente, List<ProductoVenta> productos)
        {
            InitializeComponent();
            _totalAPagar = totalAPagar;
            _cliente = cliente;
            _productos = productos;
            Resultado = DialogResult.Cancel;
            
            // Habilitar cierre con tecla ESC
            this.KeyPreview = true;
            this.KeyDown += FrmPago_KeyDown;
        }

        private void FrmPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                var result = MessageBox.Show(
                    "Seguro que deseas cancelar el cobro?",
                    "Cancelar Pago",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    this.Resultado = DialogResult.Cancel;
                    this.Close();
                }
            }
            else if (e.KeyCode == Keys.F12 && btnCobrarImprimir.Enabled)
            {
                // Atajo de teclado F12 para cobrar rápidamente
                btnCobrarImprimir_Click(this, EventArgs.Empty);
            }
        }

        private void FrmPago_Load(object sender, EventArgs e)
        {
            lblTotalPagar.Text = _totalAPagar.ToString("C2");
            txtEfectivoRecibido.Text = _totalAPagar.ToString("N2");
            txtEfectivoRecibido.SelectAll();
            txtEfectivoRecibido.Focus();

            this.txtEfectivoRecibido.TextChanged += txtEfectivoRecibido_TextChanged;
            this.btnCobrarImprimir.Click += btnCobrarImprimir_Click;
            this.btnCancelar.Click += btnCancelar_Click;
            this.btnCerrar.Click += btnCancelar_Click;
        }

        private void txtEfectivoRecibido_TextChanged(object sender, EventArgs e)
        {
            CalcularVuelto();
        }

        private void CalcularVuelto()
        {
            if (decimal.TryParse(txtEfectivoRecibido.Text, out decimal efectivoRecibido))
            {
                decimal vuelto = efectivoRecibido - _totalAPagar;
                lblVuelto.Text = vuelto.ToString("C2");
                lblVuelto.ForeColor = vuelto < 0 ? System.Drawing.Color.Red : System.Drawing.Color.Green;
            }
            else
            {
                lblVuelto.Text = (0 - _totalAPagar).ToString("C2");
                lblVuelto.ForeColor = System.Drawing.Color.Red;
            }
        }

        private async void btnCobrarImprimir_Click(object sender, EventArgs e)
        {
            // --- (Tus validaciones de monto no cambian) ---
            if (!decimal.TryParse(txtEfectivoRecibido.Text, out decimal efectivoRecibido) || efectivoRecibido < _totalAPagar)
            {
                MessageBox.Show("Monto recibido es inválido o insuficiente.", "Error de Monto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            btnCobrarImprimir.Enabled = false;

            try
            {
                // ✅ 1. LEER LOS DATOS DE LA EMPRESA DESDE LA BASE DE DATOS
                DEmpresa d_empresa = new DEmpresa();
                EEmpresa empresa = d_empresa.ObtenerDatosEmpresa();

                if (empresa == null)
                {
                    MessageBox.Show("No se encontraron los datos de configuración de la empresa.", "Error de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Detenemos el proceso si no hay datos de la empresa
                }

                // ✨ Se reemplazan los datos fijos por los de la base de datos
                string empresaRuc = empresa.Ruc;
                int ambiente = 1; // 1=pruebas, 2=producción
                string estab = "001"; 
                string ptoEmi = "001"; 
                string dirMatriz = empresa.DireccionMatriz;
                string dirEstablecimiento = empresa.DireccionMatriz; 
                string rimpe = empresa.ContribuyenteEspecial ?? "CONTRIBUYENTE RÉGIMEN GENERAL"; 
                bool obligadoContabilidad = empresa.ObligadoContabilidad;

                // --- (El resto de tu lógica para obtener el secuencial no cambia) ---
                var datosSecuencial = new LogiPharm.Datos.DGenerarSecuancial();
                string numeroFacturaCompleto = datosSecuencial.ObtenerSiguienteSecuencial(estab, ptoEmi);
                string secuencial = numeroFacturaCompleto.Split('-')[2];

                // 🧱 Construir payload con los datos dinámicos
                var factura = FacturaBuilder.BuildFactura(
                      empresaRuc,
                      ambiente,
                      estab,
                      ptoEmi,
                      secuencial,
                      dirMatriz,
                      dirEstablecimiento,
                      rimpe,
                      obligadoContabilidad,
                      _cliente,
                      _productos
                );

                // 🚀 Enviar a la API y leer respuesta
                var r = await EnviarFacturaAPI(factura);
                this.NumeroAutorizacion = r.numeroAutorizacion ?? "";

                try
                {
                    DCierreCaja d_cierre = new DCierreCaja();
                    // Asume que tienes una forma de obtener el ID de la caja actual (ej: "1")
                    var apertura = d_cierre.ObtenerDatosAperturaAbierta(1);
                    if (apertura == null) throw new Exception("No se pudo encontrar la sesión de caja abierta.");

                    int idCierreCaja = Convert.ToInt32(apertura["id"]);
                    int idUsuario = SesionActual.IdUsuario; // De tu clase de sesión

                    DFacturaVenta d_factura = new DFacturaVenta();
                    d_factura.GuardarFactura(_cliente, _productos, numeroFacturaCompleto, idCierreCaja, idUsuario, this.NumeroAutorizacion);
                }
                catch (Exception dbEx)
                {
                    // Si la API funcionó pero la base de datos local falló, es un problema crítico
                    MessageBox.Show("¡ATENCIÓN! La factura fue autorizada por el SRI, pero falló al guardarse en la base de datos local.\n\nError: " + dbEx.Message, "Error Crítico de Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Aquí NO cerramos el formulario, para que el usuario pueda intentar de nuevo o tomar nota.
                    return;
                }

                // --- (El resto de tu código para guardar el resultado no cambia) ---
                this.ClaveAcceso = r.claveAcceso ?? "";
                this.NumeroAutorizacion = r.numeroAutorizacion ?? "";
                this.EstadoAutorizacion = r.estadoFinal ?? "";
                this.FechaAutorizacionIso = r.fechaAutorizacion ?? "";
                this.SecuencialUsado = numeroFacturaCompleto;
                this.EfectivoRecibido = efectivoRecibido;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la factura:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnCobrarImprimir.Enabled = true;
            }
        }



        private async Task<RespuestaFacturaApi> EnviarFacturaAPI(FacturaPayload payload)
        {
            string apiUrl = "http://127.0.0.1:5001/api/factura";

            var json = JsonConvert.SerializeObject(
                payload,
                Formatting.None,
                new JsonSerializerSettings
                {
                    Culture = CultureInfo.InvariantCulture,
                    NullValueHandling = NullValueHandling.Ignore
                });

            using (var client = new HttpClient())
            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                var resp = await client.PostAsync(apiUrl, content);
                var body = await resp.Content.ReadAsStringAsync();

                if (!resp.IsSuccessStatusCode)
                {
                    // Intenta leer { error, mensajes }
                    try
                    {
                        var raw = JsonConvert.DeserializeObject<dynamic>(body);
                        string err = (string)(raw?.error ?? "Error desconocido");
                        string msgs = raw?.mensajes != null ? JsonConvert.SerializeObject(raw.mensajes, Formatting.Indented) : "[]";
                        throw new Exception($"HTTP {(int)resp.StatusCode} {resp.ReasonPhrase}\n{err}\nMensajes: {msgs}");
                    }
                    catch
                    {
                        throw new Exception($"HTTP {(int)resp.StatusCode} {resp.ReasonPhrase}\n{body}");
                    }
                }

                var data = JsonConvert.DeserializeObject<RespuestaFacturaApi>(body);
                if (data == null) throw new Exception("No se pudo leer la respuesta de la API.");
                return data;
            }
        }





        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Resultado = DialogResult.Cancel;
            this.Close();
        }
    }
}
