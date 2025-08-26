using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using LogiPharm.Datos;
using TheArtOfDevHtmlRenderer.Adapters;

namespace LogiPharm.Presentacion
{
    public partial class FrmReporteVentas : Form
    {
        private AutoCompleteStringCollection _acClientes;
        private Dictionary<string, int> _mapNombreToId; // nombre normalizado -> id
        private int _clienteIdSeleccionado = 0;

        public FrmReporteVentas()
        {
            InitializeComponent();
            this.Load += FrmReporteVentas_Load;
            this.btnConsultar.Click += btnConsultar_Click;
        }

        private void FrmReporteVentas_Load(object sender, EventArgs e)
        {
            CargarClientes();
            // Aquí deberías tener un método similar para cargar los usuarios/cajeros
            // CargarUsuarios(); 

            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;
            btnConsultar_Click(null, null); // Carga inicial
        }

        private void CargarClientes()
        {
            try
            {
                DClientes d_Clientes = new DClientes();
                DataTable dt = d_Clientes.ListarClientesActivos();

                // Inserta opción [TODOS]
                DataRow dr = dt.NewRow();
                dr["id"] = 0;
                dr["nombres"] = "[TODOS LOS CLIENTES]";
                dt.Rows.InsertAt(dr, 0);

                // Bind al combo oculto (por si quieres reutilizarlo)
                cboCliente.DisplayMember = "nombres";
                cboCliente.ValueMember = "id";
                cboCliente.DataSource = dt;
                cboCliente.Visible = false;

                // --- AutoComplete para el TextBox ---
                _acClientes = new AutoCompleteStringCollection();
                _mapNombreToId = new Dictionary<string, int>();

                foreach (DataRow r in dt.Rows)
                {
                    string nombre = Convert.ToString(r["nombres"]) ?? "";
                    int id = Convert.ToInt32(r["id"]);

                    // agrega variantes de búsqueda si quieres (ej: "NOMBRE - CI")
                    _acClientes.Add(nombre);
                    var key = Norm(nombre);
                    if (!_mapNombreToId.ContainsKey(key))
                        _mapNombreToId[key] = id;
                }

                txtCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtCliente.AutoCompleteCustomSource = _acClientes;

                // Valor por defecto: todos
                txtCliente.Text = "[TODOS LOS CLIENTES]";
                _clienteIdSeleccionado = 0;

                // Eventos para resolver selección
                txtCliente.Leave += (s, e) => ResolverClienteDesdeTexto();
                txtCliente.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { ResolverClienteDesdeTexto(); e.Handled = true; e.SuppressKeyPress = true; } };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static string Norm(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return "";
            s = s.Trim();
            s = s.ToUpperInvariant();
            // quita tildes
            var normalized = s.Normalize(NormalizationForm.FormD);
            var sb = new System.Text.StringBuilder();
            foreach (var ch in normalized)
            {
                var uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                    sb.Append(ch);
            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        private void ResolverClienteDesdeTexto()
        {
            string txt = txtCliente.Text?.Trim() ?? "";

            if (string.IsNullOrEmpty(txt) || txt == "[TODOS LOS CLIENTES]")
            {
                _clienteIdSeleccionado = 0;
                txtCliente.Text = "[TODOS LOS CLIENTES]";
                return;
            }

            string key = Norm(txt);

            // 1) coincidencia exacta por nombre normalizado
            if (_mapNombreToId.TryGetValue(key, out int idExacto))
            {
                _clienteIdSeleccionado = idExacto;
                return;
            }

            // 2) si no hay exacta, intenta coincidencia única por "empieza con"
            var matches = new List<KeyValuePair<string, int>>();
            foreach (var kv in _mapNombreToId)
                if (kv.Key.StartsWith(key))
                    matches.Add(kv);

            if (matches.Count == 1)
            {
                _clienteIdSeleccionado = matches[0].Value;
                // opcional: escribe el nombre real exacto en el textbox
                foreach (DataRow r in ((DataTable)cboCliente.DataSource).Rows)
                {
                    if (Convert.ToInt32(r["id"]) == _clienteIdSeleccionado)
                    {
                        txtCliente.Text = Convert.ToString(r["nombres"]);
                        break;
                    }
                }
                return;
            }

            // 3) varias coincidencias o ninguna → deja TODOS o abre selector personalizado
            // (si tienes un FrmSeleccionarCliente, podrías abrirlo aquí y filtrar por 'txt')
            _clienteIdSeleccionado = 0;
            // opcional: mensaje suave
            // MessageBox.Show("No se pudo determinar un cliente único. Se usará [TODOS].");
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                var dReportes = new DReportes();
                int idCliente = Convert.ToInt32(cboCliente.SelectedValue ?? 0);
                int idUsuario = 0; // Convert.ToInt32(cboCajero.SelectedValue ?? 0);
                string producto = txtProducto.Text.Trim();

                DataTable dt = dReportes.GenerarReporteVentas(dtpFechaInicio.Value, dtpFechaFin.Value, idCliente, idUsuario, producto);
                dgvReporte.DataSource = dt;

                CalcularKPIs(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularKPIs(DataTable dt)
        {
            if (dt == null) return;

            // Usamos DataTable.Compute para calcular los totales de forma eficiente
            decimal totalVendido = dt.Rows.Count > 0 ? Convert.ToDecimal(dt.Compute("SUM(Total)", "Estado <> 'ANULADA'")) : 0;
            int numFacturas = dt.Rows.Count;
            decimal ticketPromedio = numFacturas > 0 ? totalVendido / numFacturas : 0;

            // Actualizamos las etiquetas de los KPIs
            lblTotalVendido.Text = totalVendido.ToString("C2", CultureInfo.CurrentCulture);
            lblNumFacturas.Text = numFacturas.ToString();
            lblTicketPromedio.Text = ticketPromedio.ToString("C2", CultureInfo.CurrentCulture);
        }

        // Aquí iría la lógica para el botón Exportar, que requiere una librería como EPPlus o ClosedXML
        private void btnExportar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función de exportar a Excel no implementada.", "Información");
        }
    }
}