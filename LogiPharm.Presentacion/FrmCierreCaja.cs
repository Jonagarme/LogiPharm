using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using LogiPharm.Datos;

namespace LogiPharm.Presentacion
{
    public partial class FrmCierreCaja : Form
    {
        private decimal _saldoInicial = 0m;
        private decimal _totalIngresos = 0m;
        private decimal _totalEgresos = 0m;

        public FrmCierreCaja()
        {
            InitializeComponent();
            // Asignamos el mismo evento a todos los NumericUpDown
            SuscribirEventosArqueo();
        }

        private void FrmCierreCaja_Load(object sender, EventArgs e)
        {
            // Puedes establecer valores iniciales aquí si es necesario
            cboCaja.SelectedIndex = 0;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                DCierreCaja d_Cierre = new DCierreCaja();
                // Suponemos que se elige la caja 1 y la fecha del control
                DataSet ds = d_Cierre.ObtenerDatosCierre(1, dtpFechaCierre.Value);

                // Llenar Totales del Sistema
                _saldoInicial = Convert.ToDecimal(ds.Tables["Totales"].Rows[0]["SaldoInicial"]);
                _totalIngresos = Convert.ToDecimal(ds.Tables["Ingresos"].Compute("SUM(Total)", ""));
                _totalEgresos = Convert.ToDecimal(ds.Tables["Egresos"].Compute("SUM(Total)", ""));

                lblSaldoInicial.Text = _saldoInicial.ToString("C2");
                lblTotalIngresos.Text = _totalIngresos.ToString("C2");
                lblTotalEgresos.Text = _totalEgresos.ToString("C2");

                CalcularResultadosFinales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al generar reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SuscribirEventosArqueo()
        {
            // Este método asigna el mismo manejador de eventos a todos los NumericUpDown
            // para que cualquier cambio recalcule el total contado.
            num100d.ValueChanged += new EventHandler(Arqueo_ValueChanged);
            num50d.ValueChanged += new EventHandler(Arqueo_ValueChanged);
            num20d.ValueChanged += new EventHandler(Arqueo_ValueChanged);
            num10d.ValueChanged += new EventHandler(Arqueo_ValueChanged);
            num5d.ValueChanged += new EventHandler(Arqueo_ValueChanged);
            num1d.ValueChanged += new EventHandler(Arqueo_ValueChanged);
            num50c.ValueChanged += new EventHandler(Arqueo_ValueChanged);
            num25c.ValueChanged += new EventHandler(Arqueo_ValueChanged);
            num10c.ValueChanged += new EventHandler(Arqueo_ValueChanged);
            num5c.ValueChanged += new EventHandler(Arqueo_ValueChanged);
            num1c.ValueChanged += new EventHandler(Arqueo_ValueChanged);
        }

        private void Arqueo_ValueChanged(object sender, EventArgs e)
        {
            // Cada vez que cambia un valor del conteo, recalculamos todo.
            CalcularTotalContado();
            CalcularResultadosFinales();
        }

        private void CalcularTotalContado()
        {
            decimal total = 0;
            total += num100d.Value * 100;
            total += num50d.Value * 50;
            total += num20d.Value * 20;
            total += num10d.Value * 10;
            total += num5d.Value * 5;
            total += num1d.Value * 1;
            total += num50c.Value * 0.50m;
            total += num25c.Value * 0.25m;
            total += num10c.Value * 0.10m;
            total += num5c.Value * 0.05m;
            total += num1c.Value * 0.01m;

            lblTotalContado.Text = total.ToString("C2");
        }

        private void CalcularResultadosFinales()
        {
            decimal saldoTeorico = _saldoInicial + _totalIngresos - _totalEgresos;
            decimal totalContado = 0;
            Decimal.TryParse(lblTotalContado.Text, System.Globalization.NumberStyles.Currency, CultureInfo.CurrentCulture, out totalContado);

            decimal diferencia = totalContado - saldoTeorico;

            lblSaldoTeorico.Text = saldoTeorico.ToString("C2");
            lblDiferencia.Text = diferencia.ToString("C2");

            // Cambiar color de la diferencia si es negativa
            if (diferencia < 0)
            {
                lblDiferencia.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblDiferencia.ForeColor = System.Drawing.Color.Green;
            }
        }
    }
}
