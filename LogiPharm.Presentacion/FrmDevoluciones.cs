using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogiPharm.Datos;
using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace LogiPharm.Presentacion
{
    public partial class FrmDevoluciones : Form
    {
        public FrmDevoluciones()
        {
            InitializeComponent();
        }

        private void FrmDevoluciones_Load(object sender, EventArgs e)
        {
            // Ocultar el panel de información hasta que se busque una factura
            groupInfoFactura.Visible = false;
            // Wire-up events del grid
            this.dgvProductosDevolver.CellValueChanged += dgvProductosDevolver_CellValueChanged;
            this.dgvProductosDevolver.CurrentCellDirtyStateChanged += dgvProductosDevolver_CurrentCellDirtyStateChanged;
            // Botón principal
            this.btnGenerarNC.Click += btnGenerarNC_Click;
        }

        private void btnBuscarFactura_Click(object sender, EventArgs e)
        {
            string termino = txtNumeroFactura.Text?.Trim();
            if (string.IsNullOrWhiteSpace(termino))
            {
                MessageBox.Show("Por favor, ingrese un número de factura para buscar.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                var dFac = new DFacturacion();
                var res = dFac.ObtenerFacturaPorNumero(termino);

                if (res.Encabezado == null)
                {
                    MessageBox.Show("No se encontró una factura con el número proporcionado (pruebe con los últimos dígitos o con guiones).",
                        "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupInfoFactura.Visible = false;
                    dgvProductosDevolver.Rows.Clear();
                    CalcularTotalesDevolucion();
                    return;
                }

                // Encabezado
                var enc = res.Encabezado;
                lblIdentificacion.Text = Convert.ToString(enc["Identificacion"] ?? "...");
                lblCliente.Text = Convert.ToString(enc["RazonSocial"] ?? "...");
                if (enc["FechaEmision"] is DateTime fe)
                    lblFechaEmision.Text = fe.ToString("dd/MM/yyyy");
                else
                    lblFechaEmision.Text = Convert.ToString(enc["FechaEmision"] ?? "...");

                groupInfoFactura.Visible = true;

                // Detalle -> llenar el grid manualmente respetando las columnas del diseñador
                dgvProductosDevolver.Rows.Clear();
                foreach (DataRow dr in res.Detalle.Rows)
                {
                    string codigo = Convert.ToString(dr["Codigo"] ?? "");
                    string producto = Convert.ToString(dr["Descripcion"] ?? "");
                    decimal cantDec = 0m;
                    try { cantDec = Convert.ToDecimal(dr["Cantidad"] ?? 0); } catch { cantDec = 0m; }
                    int cantVendida = (int)Math.Round(cantDec, MidpointRounding.AwayFromZero);
                    decimal precio = 0m;
                    try { precio = Convert.ToDecimal(dr["PrecioUnitario"] ?? 0); } catch { precio = 0m; }
                    decimal total = Math.Round(precio * cantVendida, 2);

                    dgvProductosDevolver.Rows.Add(
                        false,          // colSeleccionar
                        codigo,         // colCodigo
                        producto,       // colProducto
                        cantVendida,    // colCantidadVendida
                        0,              // colCantidadDevolver
                        precio,         // colPrecio
                        total           // colTotal
                    );
                }

                EstilizarGrid();
                CalcularTotalesDevolucion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar la factura:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void CargarDatosDePrueba()
        {
            // --- 1. Llenar Información de la Factura Original ---
            lblIdentificacion.Text = "0932267339";
            lblCliente.Text = "JONATHAN GERMAN GARCIA MERINO";
            lblFechaEmision.Text = DateTime.Now.AddDays(-5).ToString("dd/MM/yyyy");

            // --- 2. Llenar Tabla de Productos de la Factura Original ---
            DataTable dtProductos = new DataTable();
            dtProductos.Columns.Add("Seleccionar", typeof(bool));
            dtProductos.Columns.Add("Codigo", typeof(string));
            dtProductos.Columns.Add("Producto", typeof(string));
            dtProductos.Columns.Add("CantVendida", typeof(int));
            dtProductos.Columns.Add("CantDevolver", typeof(int));
            dtProductos.Columns.Add("Precio", typeof(decimal));
            dtProductos.Columns.Add("Total", typeof(decimal));

            // Añadir filas de ejemplo
            dtProductos.Rows.Add(false, "7861097200475", "CEMIN 500MG/5ML CJX10 AMPOLLAS IM-IV", 2, 0, 1.50m, 3.00m);
            dtProductos.Rows.Add(false, "8904159404011", "PARACETAMOL 500MG CJX100 TAB - ECUAQ", 1, 0, 5.00m, 5.00m);
            dtProductos.Rows.Add(false, "7702057074272", "METFORMINA 850 MG CJ X30 - MK", 3, 0, 8.20m, 24.60m);

            dgvProductosDevolver.DataSource = dtProductos;
            EstilizarGrid();
        }

        private void EstilizarGrid()
        {
            if (dgvProductosDevolver.Columns.Count > 0)
            {
                dgvProductosDevolver.Columns["colSeleccionar"].Width = 40;
                dgvProductosDevolver.Columns["colCodigo"].ReadOnly = true;
                dgvProductosDevolver.Columns["colProducto"].ReadOnly = true;
                dgvProductosDevolver.Columns["colProducto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvProductosDevolver.Columns["colCantidadVendida"].ReadOnly = true;
                dgvProductosDevolver.Columns["colPrecio"].ReadOnly = true;
                dgvProductosDevolver.Columns["colTotal"].ReadOnly = true;

                string[] columnasNumericas = { "colCantidadVendida", "colCantidadDevolver" };
                foreach (string colName in columnasNumericas)
                {
                    var col = dgvProductosDevolver.Columns[colName];
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                string[] columnasMoneda = { "colPrecio", "colTotal" };
                foreach (string colName in columnasMoneda)
                {
                    var col = dgvProductosDevolver.Columns[colName];
                    col.DefaultCellStyle.Format = "N2";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private void dgvProductosDevolver_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Si el cambio ocurrió en la columna de CheckBox o en la cantidad a devolver, recalculamos
            if (e.RowIndex >= 0 && (dgvProductosDevolver.Columns[e.ColumnIndex].Name == "colSeleccionar" || dgvProductosDevolver.Columns[e.ColumnIndex].Name == "colCantidadDevolver"))
            {
                CalcularTotalesDevolucion();
            }
        }

        private void dgvProductosDevolver_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // Este truco es para que el evento CellValueChanged se dispare inmediatamente al hacer clic en el CheckBox
            if (dgvProductosDevolver.IsCurrentCellDirty)
            {
                dgvProductosDevolver.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void CalcularTotalesDevolucion()
        {
            decimal subtotal = 0;
            foreach (DataGridViewRow row in dgvProductosDevolver.Rows)
            {
                // Verificamos si la fila está seleccionada para la devolución
                bool seleccionado = Convert.ToBoolean(row.Cells["colSeleccionar"].Value ?? false);
                if (seleccionado)
                {
                    int cantDevolver = Convert.ToInt32(row.Cells["colCantidadDevolver"].Value ?? 0);
                    decimal precio = Convert.ToDecimal(row.Cells["colPrecio"].Value ?? 0);
                    subtotal += cantDevolver * precio;
                }
            }

            decimal iva = subtotal * 0.15m; // Asumiendo IVA del 15%
            decimal total = subtotal + iva;

            lblSubtotal.Text = subtotal.ToString("C2");
            lblIVA.Text = iva.ToString("C2");
            lblTotalDevolucion.Text = total.ToString("C2");
        }

        private async void btnGenerarNC_Click(object sender, EventArgs e)
        {
            if (!groupInfoFactura.Visible)
            {
                MessageBox.Show("Primero busque una factura.", "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Construir listado de ítems seleccionados
            var items = new List<NotaCreditoBuilder.ItemDevolucion>();
            foreach (DataGridViewRow row in dgvProductosDevolver.Rows)
            {
                bool seleccionado = Convert.ToBoolean(row.Cells["colSeleccionar"].Value ?? false);
                if (!seleccionado) continue;

                int cantVendida = Convert.ToInt32(row.Cells["colCantidadVendida"].Value ?? 0);
                int cantDev = Convert.ToInt32(row.Cells["colCantidadDevolver"].Value ?? 0);
                if (cantDev <= 0)
                {
                    MessageBox.Show("Hay ítems seleccionados con cantidad a devolver 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cantDev > cantVendida)
                {
                    MessageBox.Show("La cantidad a devolver no puede ser mayor a la vendida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                items.Add(new NotaCreditoBuilder.ItemDevolucion
                {
                    CodigoInterno = Convert.ToString(row.Cells["colCodigo"].Value ?? ""),
                    Descripcion = Convert.ToString(row.Cells["colProducto"].Value ?? ""),
                    Cantidad = cantDev,
                    PrecioUnitario = Convert.ToDecimal(row.Cells["colPrecio"].Value ?? 0),
                    DescuentoValor = 0m // si manejas descuentos por línea, mapéalos aquí
                });
            }

            if (items.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un producto para la devolución.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                btnGenerarNC.Enabled = false;

                // 1) Datos de empresa
                var d_empresa = new DEmpresa();
                var empresa = d_empresa.ObtenerDatosEmpresa();
                if (empresa == null)
                {
                    MessageBox.Show("No se encontraron datos de la empresa.", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string empresaRuc = empresa.Ruc;
                int ambiente = 1; // 1=pruebas, 2=prod
                string estab = "001"; // si tienes almacenados por caja, léelos
                string ptoEmi = "001";
                string dirMatriz = empresa.DireccionMatriz;
                string dirEstablecimiento = empresa.DireccionMatriz;
                string rimpe = empresa.ContribuyenteEspecial ?? "CONTRIBUYENTE RÉGIMEN GENERAL";
                bool obligadoContabilidad = empresa.ObligadoContabilidad;

                // 2) Secuencial (puedes usar otro talonario específico para N/C si lo tienes)
                var datosSec = new DGenerarSecuancial();
                string numeroNC = datosSec.ObtenerSiguienteSecuencial(estab, ptoEmi);
                string secuencial = numeroNC.Split('-')[2];

                // 3) Cliente. En este ejemplo tomamos lo mostrado en labels; si ya tienes el cliente original, úsalo
                var cliente = new ECliente
                {
                    CedulaRuc = lblIdentificacion.Text,
                    Identificacion = lblIdentificacion.Text,
                    RazonSocial = lblCliente.Text,
                    Direccion = "S/D"
                };

                // 4) Datos del documento modificado desde la UI
                string numDocModificado = txtNumeroFactura.Text.Trim();
                DateTime fechaEmiDocSustento;
                if (!DateTime.TryParseExact(lblFechaEmision.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaEmiDocSustento))
                {
                    fechaEmiDocSustento = DateTime.Today;
                }

                string motivo = "ANULACIÓN TOTAL DE LA FACTURA"; // o permitir editar

                // 5) Construir payload
                var payload = NotaCreditoBuilder.Build(
                    empresaRuc,
                    ambiente,
                    estab,
                    ptoEmi,
                    secuencial,
                    dirMatriz,
                    dirEstablecimiento,
                    rimpe,
                    obligadoContabilidad,
                    cliente,
                    numDocModificado,
                    fechaEmiDocSustento,
                    motivo,
                    items,
                    itemsGravadosConIva: true
                );

                // 6) Enviar a API
                var respuesta = await EnviarNotaCreditoApi(payload);

                MessageBox.Show($"Nota de crédito emitida. Estado: {respuesta?.estadoFinal}\nAutorización: {respuesta?.numeroAutorizacion}",
                    "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar la nota de crédito:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnGenerarNC.Enabled = true;
            }
        }

        private async Task<RespuestaFacturaApi> EnviarNotaCreditoApi(NotaCreditoPayload payload)
        {
            string apiUrl = "http://127.0.0.1:5001/api/nota_credito"; // ajusta a tu endpoint real

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
    }
}
