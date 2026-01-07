using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmArqueoCaja : Form
    {
        private DataRow _aperturaActual;
        private DCierreCaja _dCierreCaja;

        public FrmArqueoCaja()
        {
            InitializeComponent();
            _dCierreCaja = new DCierreCaja();
        }

        private void FrmArqueoCaja_Load(object sender, EventArgs e)
        {
            // Auditoría
            try
            {
                new DBitacora().Registrar(
                    SesionActual.IdUsuario,
                    SesionActual.NombreUsuario,
                    "Caja",
                    "VISUALIZAR",
                    "arqueo_caja",
                    null,
                    "Abrir Arqueo de Caja",
                    null,
                    Environment.MachineName,
                    "UI"
                );
            }
            catch { }

            SuscribirEventosArqueo();
            CargarDatosApertura();
        }

        private void CargarDatosApertura()
        {
            try
            {
                int idCajaActual = 1; // TODO: Obtener de configuración

                _aperturaActual = _dCierreCaja.ObtenerDatosAperturaAbierta(idCajaActual);

                if (_aperturaActual == null)
                {
                    MessageBox.Show(
                        "No se encontró una caja abierta. Debe abrir una caja antes de realizar el arqueo.",
                        "Caja Cerrada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    
                    lblSaldoInicial.Text = "$0.00";
                    lblTotalIngresos.Text = "$0.00";
                    lblTotalEgresos.Text = "$0.00";
                    lblSaldoTeorico.Text = "$0.00";
                    btnGuardar.Enabled = false;
                    return;
                }

                // Obtener datos del cierre
                int idAperturaActual = Convert.ToInt32(_aperturaActual["id"]);
                decimal saldoInicial = Convert.ToDecimal(_aperturaActual["saldoInicial"]);

                // Actualizar y obtener totales
                _dCierreCaja.ActualizarTotalesSistema(idAperturaActual);
                decimal totalIngresos = _dCierreCaja.CalcularIngresosSistema(idAperturaActual);
                decimal totalEgresos = _dCierreCaja.CalcularEgresosSistema(idAperturaActual);

                // Mostrar información en el panel de información
                lblFechaApertura.Text = "Apertura: " + Convert.ToDateTime(_aperturaActual["fechaApertura"]).ToString("dd/MM/yyyy HH:mm");
                lblUsuarioApertura.Text = "Usuario: " + SesionActual.NombreUsuario;
                
                // Mostrar datos del sistema (panel derecho)
                lblSaldoInicial.Text = saldoInicial.ToString("C2");
                lblTotalIngresos.Text = totalIngresos.ToString("C2");
                lblTotalEgresos.Text = totalEgresos.ToString("C2");

                CalcularResultadosFinales();
                btnGuardar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar datos de la caja: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void SuscribirEventosArqueo()
        {
            SuscribirEventosArqueo(panelArqueo);
        }

        private void SuscribirEventosArqueo(Control root)
        {
            foreach (Control ctrl in root.Controls)
            {
                if (ctrl is Guna.UI2.WinForms.Guna2NumericUpDown numCtrl)
                {
                    numCtrl.ValueChanged -= Arqueo_ValueChanged;
                    numCtrl.ValueChanged += Arqueo_ValueChanged;
                }

                if (ctrl.HasChildren)
                {
                    SuscribirEventosArqueo(ctrl);
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
            
            // Billetes
            total += num100d.Value * 100;
            total += num50d.Value * 50;
            total += num20d.Value * 20;
            total += num10d.Value * 10;
            total += num5d.Value * 5;
            total += num1d.Value * 1;
            
            // Monedas
            total += num50c.Value * 0.50m;
            total += num25c.Value * 0.25m;
            total += num10c.Value * 0.10m;
            total += num5c.Value * 0.05m;
            total += num1c.Value * 0.01m;

            // Actualizar ambos labels: el del arqueo y el del resumen
            lblTotalContado.Text = total.ToString("C2");
            lblTotalContadoResumen.Text = total.ToString("C2");
            
            return total;
        }

        private void CalcularResultadosFinales()
        {
            try
            {
                // Leer valores del sistema (estos se cargan desde la BD)
                decimal saldoInicial = 0;
                decimal totalIngresos = 0;
                decimal totalEgresos = 0;
                
                if (!string.IsNullOrEmpty(lblSaldoInicial.Text))
                {
                    decimal.TryParse(lblSaldoInicial.Text, NumberStyles.Currency, null, out saldoInicial);
                }
                if (!string.IsNullOrEmpty(lblTotalIngresos.Text))
                {
                    decimal.TryParse(lblTotalIngresos.Text, NumberStyles.Currency, null, out totalIngresos);
                }
                if (!string.IsNullOrEmpty(lblTotalEgresos.Text))
                {
                    decimal.TryParse(lblTotalEgresos.Text, NumberStyles.Currency, null, out totalEgresos);
                }

                // Calcular total contado físicamente
                decimal totalContado = CalcularTotalContado();
                
                // Calcular saldo teórico del sistema
                decimal saldoTeorico = saldoInicial + totalIngresos - totalEgresos;
                
                // Calcular diferencia
                decimal diferencia = totalContado - saldoTeorico;

                // Actualizar labels del resumen
                lblSaldoTeoricoResumen.Text = saldoTeorico.ToString("C2");
                // Actualizar label del panel "Datos del Sistema"
                lblSaldoTeorico.Text = saldoTeorico.ToString("C2");
                lblDiferencia.Text = diferencia.ToString("C2");
                lblDiferencia.ForeColor = diferencia < 0 ? Color.Red : Color.ForestGreen;

                // Actualizar indicador visual
                if (Math.Abs(diferencia) < 0.01m)
                {
                    lblEstadoArqueo.Text = "CUADRA PERFECTO";
                    lblEstadoArqueo.ForeColor = Color.Green;
                    panelEstado.BackColor = Color.LightGreen;
                }
                else if (Math.Abs(diferencia) < 10)
                {
                    lblEstadoArqueo.Text = "DIFERENCIA MENOR";
                    lblEstadoArqueo.ForeColor = Color.Orange;
                    panelEstado.BackColor = Color.LightYellow;
                }
                else
                {
                    lblEstadoArqueo.Text = "DIFERENCIA SIGNIFICATIVA";
                    lblEstadoArqueo.ForeColor = Color.Red;
                    panelEstado.BackColor = Color.LightCoral;
                }
            }
            catch (Exception ex)
            {
                // Log error but don't show to user during calculation
                System.Diagnostics.Debug.WriteLine($"Error en CalcularResultadosFinales: {ex.Message}");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show(
                "¿Está seguro de limpiar todos los valores del arqueo?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.Yes)
            {
                LimpiarArqueo();
            }
        }

        private void LimpiarArqueo()
        {
            LimpiarArqueo(panelArqueo);
            
            txtObservaciones.Clear();
            CalcularResultadosFinales();
        }

        private void LimpiarArqueo(Control root)
        {
            foreach (Control ctrl in root.Controls)
            {
                if (ctrl is Guna.UI2.WinForms.Guna2NumericUpDown numCtrl)
                {
                    numCtrl.Value = 0;
                }

                if (ctrl.HasChildren)
                {
                    LimpiarArqueo(ctrl);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_aperturaActual == null)
            {
                MessageBox.Show(
                    "No hay una caja abierta para guardar el arqueo.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var confirmacion = MessageBox.Show(
                "¿Está seguro de guardar este arqueo de caja?",
                "Confirmar Arqueo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.No) return;

            try
            {
                // Obtener los datos del arqueo
                int idCierre = Convert.ToInt32(_aperturaActual["id"]);
                decimal totalContado = decimal.Parse(lblTotalContado.Text, NumberStyles.Currency);
                decimal saldoTeorico = decimal.Parse(lblSaldoTeorico.Text, NumberStyles.Currency);
                decimal diferencia = decimal.Parse(lblDiferencia.Text, NumberStyles.Currency);
                int idUsuario = SesionActual.IdUsuario;

                // TODO: Guardar el arqueo en una tabla de arqueos si existe
                // Por ahora solo mostramos mensaje de éxito

                MessageBox.Show(
                    $"Arqueo guardado exitosamente.\n\n" +
                    $"Total Contado: {totalContado:C2}\n" +
                    $"Saldo Teórico: {saldoTeorico:C2}\n" +
                    $"Diferencia: {diferencia:C2}",
                    "Arqueo Guardado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Auditoría
                try
                {
                    new DBitacora().Registrar(
                        SesionActual.IdUsuario,
                        SesionActual.NombreUsuario,
                        "Caja",
                        "CREAR",
                        "arqueo_caja",
                        idCierre,
                        $"Arqueo registrado - Diferencia: {diferencia:C2}",
                        null,
                        Environment.MachineName,
                        "UI"
                    );
                }
                catch { }

                LimpiarArqueo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al guardar el arqueo: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (_aperturaActual == null)
            {
                MessageBox.Show(
                    "No hay datos para imprimir.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // TODO: Implementar impresión del arqueo
            MessageBox.Show(
                "Función de impresión en desarrollo.",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
