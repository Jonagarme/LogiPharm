using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Presentacion.Utilidades; // Asegúrate de tener tu clase de Sesión aquí

namespace LogiPharm.Presentacion
{
    public partial class FrmCierreCaja : Form
    {

        private DataRow _aperturaActual; // Para guardar toda la info de la apertura abierta

        public FrmCierreCaja()
        {
            InitializeComponent();
            SuscribirEventosArqueo();
        }

        private void FrmCierreCaja_Load(object sender, EventArgs e)
        {
            // Ya no es necesario cboCaja.SelectedIndex = 0;
            // Lo cargaremos todo desde la base de datos
            CargarDatosApertura();
        }

        // ✨ MÉTODO NUEVO: Carga los datos de la caja que esté abierta.
        private void CargarDatosApertura()
        {
            try
            {
                DCierreCaja d_Cierre = new DCierreCaja();

                int idCajaActual = 1;

                _aperturaActual = d_Cierre.ObtenerDatosAperturaAbierta(idCajaActual);

                if (_aperturaActual == null)
                {
                    MessageBox.Show("No se encontró una caja abierta para este puesto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnCerrarCaja.Enabled = false;
                    // Limpiamos los labels por si había datos de una consulta anterior
                    lblSaldoInicial.Text = (0m).ToString("C2");
                    lblTotalIngresos.Text = (0m).ToString("C2");
                    lblTotalEgresos.Text = (0m).ToString("C2");
                    CalcularResultadosFinales();
                    return;
                }

                // --- El resto del código se mantiene igual ---

                int idAperturaActual = Convert.ToInt32(_aperturaActual["id"]);
                decimal saldoInicial = Convert.ToDecimal(_aperturaActual["saldoInicial"]);

                decimal totalVentas = d_Cierre.ObtenerTotalVentas(idAperturaActual);
                decimal totalEgresos = 0;

                lblSaldoInicial.Text = saldoInicial.ToString("C2");
                lblTotalIngresos.Text = totalVentas.ToString("C2");
                lblTotalEgresos.Text = totalEgresos.ToString("C2");

                CalcularResultadosFinales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de la caja: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // El botón "Generar" ya no es tan necesario si los datos se cargan al inicio,
        // pero lo mantenemos por si quieres refrescar la información.
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            CargarDatosApertura();
        }

        private void SuscribirEventosArqueo()
        {
            // Este método está bien, pero es más robusto si recorremos los controles del GroupBox
            foreach (Control ctrl in guna2GroupBox3.Controls) // Asegúrate que el GroupBox se llame así
            {
                if (ctrl is Guna.UI2.WinForms.Guna2NumericUpDown numCtrl)
                {
                    numCtrl.ValueChanged += Arqueo_ValueChanged;
                }
            }
        }

        private void Arqueo_ValueChanged(object sender, EventArgs e)
        {
            CalcularResultadosFinales();
        }

        private decimal CalcularTotalContado()
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
            return total;
        }

        private void CalcularResultadosFinales()
        {
            // Leemos los valores directamente de las etiquetas para asegurar consistencia
            decimal saldoInicial = decimal.Parse(lblSaldoInicial.Text, NumberStyles.Currency);
            decimal totalIngresos = decimal.Parse(lblTotalIngresos.Text, NumberStyles.Currency);
            decimal totalEgresos = decimal.Parse(lblTotalEgresos.Text, NumberStyles.Currency);

            decimal totalContado = CalcularTotalContado();
            decimal saldoTeorico = saldoInicial + totalIngresos - totalEgresos;
            decimal diferencia = totalContado - saldoTeorico;

            lblSaldoTeorico.Text = saldoTeorico.ToString("C2");
            lblDiferencia.Text = diferencia.ToString("C2");

            lblDiferencia.ForeColor = diferencia < 0 ? Color.Red : Color.ForestGreen;
        }

        // ✨ MÉTODO NUEVO: Para manejar el clic del botón "Cerrar Caja"
        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            if (_aperturaActual == null)
            {
                MessageBox.Show("No hay ninguna caja abierta para cerrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacion = MessageBox.Show("¿Está seguro de que desea cerrar la caja? Esta acción no se puede deshacer.", "Confirmar Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.No) return;

            try
            {
                // Obtenemos todos los datos necesarios para el cierre
                int idCierre = Convert.ToInt32(_aperturaActual["id"]);
                int idUsuarioCierre = SesionActual.IdUsuario; // Debes tener esto en tu clase de sesión
                decimal totalContado = decimal.Parse(lblTotalContado.Text, NumberStyles.Currency);
                decimal saldoTeorico = decimal.Parse(lblSaldoTeorico.Text, NumberStyles.Currency);
                decimal diferencia = decimal.Parse(lblDiferencia.Text, NumberStyles.Currency);

                // Llamamos a la capa de datos para ejecutar el UPDATE
                DCierreCaja d_Cierre = new DCierreCaja();
                d_Cierre.CerrarCaja(idCierre, totalContado, saldoTeorico, diferencia, idUsuarioCierre);

                MessageBox.Show("La caja se ha cerrado exitosamente.", "Cierre Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el cierre de caja: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Crear instancia del DataSet
                dsCierre ds = new dsCierre();
                DataTable dt = ds.Tables["dtCierreInfo"];

                // 2. Llenar la tabla con los datos del formulario
                dt.Rows.Add(
                    "LogiPharm S.A.",                                 // NombreComercial (ejemplo)
                    "0991234567001",                                  // RucEmpresa (ejemplo)
                    "GUAYAQUIL / FEBRES CORDERO",                       // DireccionSucursal (ejemplo)
                    cboCaja.Text,                                     // Caja
                    "admin",                                          // UsuarioApertura (obtener de la BD)
                    SesionActual.NombreUsuario,                       // UsuarioCierre
                                                                      // ... obtener fechaApertura de _aperturaActual
                    DateTime.Now.ToString("g"),                       // FechaCierre
                    decimal.Parse(lblSaldoInicial.Text, NumberStyles.Currency),
                    decimal.Parse(lblTotalIngresos.Text, NumberStyles.Currency),
                    decimal.Parse(lblTotalEgresos.Text, NumberStyles.Currency),
                    decimal.Parse(lblSaldoTeorico.Text, NumberStyles.Currency),
                    decimal.Parse(lblTotalContado.Text, NumberStyles.Currency),
                    decimal.Parse(lblDiferencia.Text, NumberStyles.Currency)
                );

                // 3. Abrir el visor de reportes
                using (FrmVisorCierre frmVisor = new FrmVisorCierre(dt))
                {
                    frmVisor.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}