using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogiPharm.Negocio;

namespace LogiPharm.Presentacion
{

    public partial class FrmPago : Form
    {
        private readonly decimal _totalAPagar;
        private readonly ECliente _cliente;
        private readonly List<ProductoVenta> _productos;
        private readonly bool _esEntrega;

        // ↓↓↓ Añadir en FrmPago (dentro de la clase, fuera de métodos)
        public string ClaveAcceso { get; private set; } = "";
        public string NumeroAutorizacion { get; private set; } = "";
        public string SecuencialUsado { get; private set; } = "";
        public string EstadoAutorizacion { get; private set; } = "";
        public string FechaAutorizacionIso { get; private set; } = "";
        public decimal EfectivoRecibido { get; private set; } = 0m;

        public DialogResult Resultado { get; private set; }

        // Constructor actualizado para recibir toda la información de la venta
        public FrmPago(decimal totalAPagar, ECliente cliente, List<ProductoVenta> productos, bool esEntrega = false)
        {
            InitializeComponent();
            _totalAPagar = totalAPagar;
            _cliente = cliente;
            _productos = productos;
            _esEntrega = esEntrega;
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
                EEmpresa empresa = NEmpresa.ObtenerDatosEmpresa();

                if (empresa == null)
                {
                    MessageBox.Show("No se encontraron los datos de configuración de la empresa.", "Error de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Detenemos el proceso si no hay datos de la empresa
                }

				// ✨ Se reemplazan los datos fijos por los de la base de datos
                string estab = "001"; 
                string ptoEmi = "001"; 

                // --- (El resto de tu lógica para obtener el secuencial no cambia) ---
                string numeroFacturaCompleto = NSecuencia.ObtenerSiguienteSecuencial(estab, ptoEmi);
                string secuencial = numeroFacturaCompleto.Split('-')[2];

				// 🧱 Construir JSON para el nuevo endpoint
				var request = FacturaBuilder.BuildProcesarFacturaRequest(
					"FACTURA",
					empresa,
					estab,
					ptoEmi,
					secuencial,
					_cliente,
					_productos,
					formaPago: "EFECTIVO"
				);

				// 🚀 Enviar a la API y leer respuesta
				RespuestaFacturaApi r = null;
                if (!_esEntrega)
                {
                    r = await NFacturacion.ProcesarFacturaApiAsync(request);
                    this.NumeroAutorizacion = r.numeroAutorizacion ?? "";
                    this.ClaveAcceso = r.claveAcceso ?? "";
                    this.EstadoAutorizacion = r.estadoFinal ?? "";
                    this.FechaAutorizacionIso = r.fechaAutorizacion ?? "";
                }
                else
                {
                    this.NumeroAutorizacion = "";
                    this.ClaveAcceso = "";
                    this.EstadoAutorizacion = "NOTA_ENTREGA";
                    this.FechaAutorizacionIso = DateTime.Now.ToString("o");
                }

                try
                {
                    // Asume que tienes una forma de obtener el ID de la caja actual (ej: "1")
                    var apertura = NCierreCaja.ObtenerDatosAperturaAbierta(1);
                    if (apertura == null) throw new Exception("No se pudo encontrar la sesión de caja abierta.");

                    int idCierreCaja = Convert.ToInt32(apertura["id"]);
                    int idUsuario = SesionActual.IdUsuario; // De tu clase de sesión

                    NVenta.GuardarFactura(_cliente, _productos, numeroFacturaCompleto, idCierreCaja, idUsuario, this.NumeroAutorizacion, this.ClaveAcceso, SesionActual.IdEmpresa, _esEntrega, this.EstadoAutorizacion, SesionActual.IdUbicacion);
                }
                catch (Exception dbEx)
                {
                    // Si la API funcionó pero la base de datos local falló, es un problema crítico
                    string errorMsgMsg = _esEntrega ? "FallÃ³ al guardarse la Nota de Entrega localmente." : "Â¡ATENCIÃ“N! La factura fue autorizada por el SRI, pero fallÃ³ al guardarse en la base de datos local.";
                    MessageBox.Show(errorMsgMsg + "\n\nError: " + dbEx.Message, "Error CrÃ­tico de Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Aquí NO cerramos el formulario, para que el usuario pueda intentar de nuevo o tomar nota.
                    return;
                }

                // --- (El resto de tu código para guardar el resultado no cambia) ---
                if (r != null)
                {
                    this.ClaveAcceso = r.claveAcceso ?? "";
                    this.NumeroAutorizacion = r.numeroAutorizacion ?? "";
                    this.EstadoAutorizacion = r.estadoFinal ?? "";
                    this.FechaAutorizacionIso = r.fechaAutorizacion ?? "";
                }
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



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Resultado = DialogResult.Cancel;
            this.Close();
        }
    }
}



