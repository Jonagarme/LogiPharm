using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using LogiPharm.Entidades;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace LogiPharm.Presentacion
{

    public partial class FrmPago : Form
    {
        private readonly decimal _totalAPagar;
        private readonly ECliente _cliente;
        private readonly List<ProductoVenta> _productos;
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

        private async void btnCobrarImprimir_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtEfectivoRecibido.Text, out decimal efectivoRecibido))
            {
                if (efectivoRecibido < _totalAPagar)
                {
                    MessageBox.Show("El monto recibido es menor al total a pagar.", "Monto Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un monto válido.", "Monto Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Construir el objeto del payload con los datos de la venta
                var payload = new VentaPayload
                {
                    identificacionReceptor = _cliente.Identificacion,
                    razonSocialReceptor = _cliente.RazonSocial,
                    detalles = new List<DetallePayload>()
                };

                foreach (var prod in _productos)
                {
                    payload.detalles.Add(new DetallePayload
                    {
                        codigoPrincipal = prod.CodigoPrincipal,
                        descripcion = prod.Descripcion,
                        cantidad = prod.Cantidad,
                        precioUnitario = prod.PrecioUnitario,
                        descuento = prod.Descuento,
                        precioTotalSinImpuesto = prod.PrecioTotalSinImpuesto
                    });
                }

                // 2. Enviar a la API de forma asíncrona
               // await EnviarFacturaAPI(payload);

                // 3. Si todo sale bien, cerrar el formulario con resultado OK
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar la factura a la API:\n" + ex.Message, "Error de API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private async Task EnviarFacturaAPI(VentaPayload payload)
        //{
        //    // Usar Newtonsoft.Json para serializar el objeto a un string JSON
        //    string jsonPayload = JsonConvert.SerializeObject(payload, Formatting.Indented);

        //    // Muestra el JSON que se va a enviar (muy útil para depuración)
        //    MessageBox.Show("JSON a enviar:\n" + jsonPayload, "Debug JSON");

        //    using (HttpClient client = new HttpClient())
        //    {
        //        // ** IMPORTANTE: Reemplaza esta URL con la de tu API real **
        //        string apiUrl = "https://tu-api.com/facturacion";

        //        StringContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        //        // Enviar la petición POST y esperar la respuesta
        //        HttpResponseMessage response = await client.PostAsync(apiUrl, content);

        //        // Verificar si la petición fue exitosa (código 2xx)
        //        if (!response.IsSuccessStatusCode)
        //        {
        //            string errorContent = await response.Content.ReadAsStringAsync();
        //            throw new Exception($"Error de la API: {response.StatusCode}\n{errorContent}");
        //        }
        //    }
        //}

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Resultado = DialogResult.Cancel;
            this.Close();
        }
    }
}
