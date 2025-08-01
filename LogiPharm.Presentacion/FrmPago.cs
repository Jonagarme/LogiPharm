using System;
using System.Globalization;
using System.Windows.Forms;

namespace LogiPharm.Presentacion
{
    public partial class FrmPago : Form
    {
        private decimal _totalAPagar;
        public DialogResult Resultado { get; private set; }

        // Constructor que recibe el total de la venta desde el FrmPuntoDeVenta
        public FrmPago(decimal totalAPagar)
        {
            InitializeComponent();
            _totalAPagar = totalAPagar;
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
            if (decimal.TryParse(txtEfectivoRecibido.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal efectivoRecibido))
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

        private void btnCobrarImprimir_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtEfectivoRecibido.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal efectivoRecibido))
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

            this.Resultado = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Resultado = DialogResult.Cancel;
            this.Close();
        }
    }
}
