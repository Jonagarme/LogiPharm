using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmFacturasCompra : Form
    {
        private DFacturasCompra datosFacturas;

        public FrmFacturasCompra()
        {
            InitializeComponent();
            datosFacturas = new DFacturasCompra();
            this.Load += FrmFacturasCompra_Load;
        }

        private void FrmFacturasCompra_Load(object sender, EventArgs e)
        {
            // Auditoría: VISUALIZAR
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Compras", "VISUALIZAR", "facturas_compra", null, "Abrir Facturas de Compra", null, Environment.MachineName, "UI"); } catch { }

            // Configurar valores iniciales
            ConfigurarGrid();
            dtpFechaInicio.Value = DateTime.Today.AddMonths(-1);
            dtpFechaFin.Value = DateTime.Today;
            cboEstado.SelectedIndex = 0; // TODOS
            
            // Conectar eventos
            btnBuscar.Click += BtnBuscar_Click;
            btnNuevo.Click += BtnNuevo_Click;
            btnAnular.Click += BtnAnular_Click;
            dgvFacturas.SelectionChanged += DgvFacturas_SelectionChanged;

            // Cargar datos iniciales
            CargarFacturas();
        }

        private void ConfigurarGrid()
        {
            // Configurar grid principal
            dgvFacturas.AutoGenerateColumns = false;
            dgvFacturas.Columns.Clear();
            
            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn { Name = "NumeroFactura", DataPropertyName = "NumeroFactura", HeaderText = "No. Factura", Width = 120 });
            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn { Name = "RUC", DataPropertyName = "RUC", HeaderText = "RUC", Width = 110 });
            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn { Name = "Proveedor", DataPropertyName = "Proveedor", HeaderText = "Proveedor", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "Fecha", 
                DataPropertyName = "Fecha", 
                HeaderText = "Fecha", 
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "Total", 
                DataPropertyName = "Total", 
                HeaderText = "Total", 
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn { Name = "Estado", DataPropertyName = "Estado", HeaderText = "Estado", Width = 100 });

            // Configurar grid detalle
            dgvDetalle.AutoGenerateColumns = false;
            dgvDetalle.Columns.Clear();
            
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn { Name = "Codigo", DataPropertyName = "Codigo", HeaderText = "Código", Width = 120 });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn { Name = "Producto", DataPropertyName = "Producto", HeaderText = "Producto", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "Cantidad", 
                DataPropertyName = "Cantidad", 
                HeaderText = "Cantidad", 
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "CostoUnitario", 
                DataPropertyName = "CostoUnitario", 
                HeaderText = "Costo Unit.", 
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C6", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                Name = "Total", 
                DataPropertyName = "Total", 
                HeaderText = "Total", 
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
        }

        private void CargarFacturas()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                string busqueda = txtBusqueda.Text.Trim();
                string estado = cboEstado.SelectedItem?.ToString() ?? "TODOS";

                var dt = datosFacturas.ListarFacturas(dtpFechaInicio.Value, dtpFechaFin.Value, busqueda, estado);
                dgvFacturas.DataSource = dt;
                
                lblTotalRegistros.Text = $"Total de Registros: {dt.Rows.Count}";
                
                // Limpiar detalle
                LimpiarDetalle();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar facturas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargarFacturas();
        }

        private void DgvFacturas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFacturas.CurrentRow == null)
            {
                LimpiarDetalle();
                return;
            }

            try
            {
                var drv = dgvFacturas.CurrentRow.DataBoundItem as DataRowView;
                if (drv == null) return;

                int idFactura = Convert.ToInt32(drv["Id"]);
                
                // Cargar información de la factura
                var factura = datosFacturas.ObtenerFactura(idFactura);
                if (factura != null)
                {
                    lblRUC.Text = factura["ruc"]?.ToString() ?? "...";
                    lblProveedor.Text = factura["proveedor"]?.ToString() ?? "...";
                    lblNumeroFactura.Text = factura["numeroFactura"]?.ToString() ?? "...";
                    lblFecha.Text = factura["fechaRecepcion"] is DateTime fecha ? fecha.ToString("dd/MM/yyyy") : "...";
                    
                    decimal subtotal = factura["subtotal"] != DBNull.Value ? Convert.ToDecimal(factura["subtotal"]) : 0;
                    decimal iva = factura["iva"] != DBNull.Value ? Convert.ToDecimal(factura["iva"]) : 0;
                    decimal total = factura["total"] != DBNull.Value ? Convert.ToDecimal(factura["total"]) : 0;
                    
                    lblSubtotal.Text = subtotal.ToString("C2");
                    lblIVA.Text = iva.ToString("C2");
                    lblTotal.Text = total.ToString("C2");
                }

                // Cargar detalle
                var detalle = datosFacturas.ObtenerDetalle(idFactura);
                dgvDetalle.DataSource = detalle;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarDetalle();
            }
        }

        private void LimpiarDetalle()
        {
            lblRUC.Text = "...";
            lblProveedor.Text = "...";
            lblNumeroFactura.Text = "...";
            lblFecha.Text = "...";
            lblSubtotal.Text = "$0.00";
            lblIVA.Text = "$0.00";
            lblTotal.Text = "$0.00";
            dgvDetalle.DataSource = null;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            // Abrir formulario de ingreso de XML (que ya existe)
            var frmIngreso = new FrmIngresoXML();
            if (frmIngreso.ShowDialog() == DialogResult.OK)
            {
                CargarFacturas();
            }
        }

        private void BtnAnular_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una factura para anular.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var drv = dgvFacturas.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) return;

            string estado = drv["Estado"]?.ToString();
            if (estado == "ANULADA")
            {
                MessageBox.Show("Esta factura ya está anulada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirmacion = MessageBox.Show(
                "¿Está seguro que desea anular esta factura de compra?",
                "Confirmar Anulación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion != DialogResult.Yes) return;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                int idFactura = Convert.ToInt32(drv["Id"]);
                
                bool resultado = datosFacturas.AnularFactura(idFactura, SesionActual.IdUsuario);
                
                if (resultado)
                {
                    MessageBox.Show("Factura anulada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Auditoría
                    try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Compras", "ANULAR", "facturas_compra", idFactura, $"Anular factura {drv["NumeroFactura"]}", null, Environment.MachineName, "UI"); } catch { }
                    
                    CargarFacturas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al anular factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
