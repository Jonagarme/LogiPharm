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

        private static string GenerarSecuencial()
        {
            // Toma los últimos 9 dígitos de un timestamp + aleatorio para evitar colisiones
            var random = new Random();
            int aleatorio = random.Next(1, 999); // número entre 001 y 999
            string baseNumero = DateTime.Now.ToString("yyyyMMdd") + aleatorio.ToString("D3"); // ej: 20250819123
                                                                                              // Nos quedamos con los últimos 9 dígitos
            return baseNumero.Substring(baseNumero.Length - 9);
        }

        private async void btnCobrarImprimir_Click(object sender, EventArgs e)
        {
            // --- (Tus validaciones de monto no cambian) ---
            if (!decimal.TryParse(txtEfectivoRecibido.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal efectivoRecibido))
            {
                MessageBox.Show("Por favor, ingrese un monto válido.", "Monto Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (efectivoRecibido < _totalAPagar)
            {
                MessageBox.Show("El monto recibido es menor al total a pagar.", "Monto Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Habilitamos un indicador de carga para que el usuario sepa que se está procesando
            this.Cursor = Cursors.WaitCursor;
            btnCobrarImprimir.Enabled = false;

            try
            {
                // ⚙️ Parámetros de emisor
                string empresaRuc = "0915912604001";
                int ambiente = 1; // 1=pruebas, 2=producción
                string estab = "001";
                string ptoEmi = "001";
                string dirMatriz = "AV. AMAZONAS Y NACIONES UNIDAS";
                string dirEstablecimiento = "AV. 6 DE DICIEMBRE Y PORTUGAL";
                string rimpe = "CONTRIBUYENTE RÉGIMEN RIMPE";
                bool obligadoContabilidad = true;

                var datosSecuencial = new LogiPharm.Datos.DGenerarSecuancial();

                // ✅ 1. OBTENER EL NÚMERO DE FACTURA COMPLETO DESDE LA BASE DE DATOS
                string numeroFacturaCompleto = datosSecuencial.ObtenerSiguienteSecuencial(estab, ptoEmi);

                // ✅ 2. EXTRAER SOLO LA PARTE DEL SECUENCIAL (los 9 dígitos)
                // El método devuelve "001-001-000000123", y el builder solo necesita la última parte.
                string secuencial = numeroFacturaCompleto.Split('-')[2];

                // 🧱 Construir payload
                var factura = FacturaBuilder.BuildFactura(
                    empresaRuc,
                    ambiente,
                    estab,
                    ptoEmi,
                    secuencial, // Se pasa solo el secuencial
                    dirMatriz,
                    dirEstablecimiento,
                    rimpe,
                    obligadoContabilidad,
                    _cliente,
                    _productos
                );

                // 🚀 Enviar a la API y leer respuesta
                var r = await EnviarFacturaAPI(factura);

                // Guardar en propiedades públicas
                this.ClaveAcceso = r.claveAcceso ?? "";
                this.NumeroAutorizacion = r.numeroAutorizacion ?? "";
                this.EstadoAutorizacion = r.estadoFinal ?? "";
                this.FechaAutorizacionIso = r.fechaAutorizacion ?? "";

                // ✅ 3. GUARDAR EL NÚMERO DE FACTURA COMPLETO
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
                // Se asegura de que el cursor y el botón vuelvan a la normalidad, incluso si hay un error
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
