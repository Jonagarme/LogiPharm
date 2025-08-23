using System;
using System.Data;
using System.Windows.Forms;
using LogiPharm.Datos;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace LogiPharm.Presentacion
{
    public partial class FrmHistorialVentas : Form
    {
        private AutoCompleteStringCollection _acClientes;
        private Dictionary<string, int> _mapNombreToId; // nombre normalizado -> id
        private int _clienteIdSeleccionado = 0;

        public FrmHistorialVentas()
        {
            InitializeComponent();
            this.Load += FrmHistorialVentas_Load;
            this.btnConsultar.Click += btnConsultar_Click;
        }

        private void FrmHistorialVentas_Load(object sender, EventArgs e)
        {
            CargarClientes();
            // Cargar historial del día actual al iniciar
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;
            btnConsultar_Click(sender, e);
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
                // asegúrate de resolver lo escrito antes de consultar
                ResolverClienteDesdeTexto();

                int idClienteSeleccionado = _clienteIdSeleccionado; // <- aquí
                string productoBuscado = txtProducto.Text.Trim();
                DateTime fechaInicio = dtpFechaInicio.Value;
                DateTime fechaFin = dtpFechaFin.Value;

                DHistorialVentas d_Historial = new DHistorialVentas();
                dgvHistorial.DataSource = d_Historial.ConsultarHistorial(
                    fechaInicio, fechaFin, idClienteSeleccionado, productoBuscado
                );

                EstilizarGrid();
                CalcularTotales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al consultar historial", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void EstilizarGrid()
        {
            if (dgvHistorial.DataSource == null) return;
            // Configura las columnas que quieres mostrar. Si AutoGenerateColumns es true, esto puede no ser necesario.
            // dgvHistorial.Columns["Fecha"].HeaderText = "Fecha de Emisión";
            // dgvHistorial.Columns["Total"].DefaultCellStyle.Format = "C2";
            // ... etc.
        }

        private void CalcularTotales()
        {
            decimal totalVenta = 0;
            int totalUnidades = dgvHistorial.Rows.Count; // Asumiendo una factura por fila

            foreach (DataGridViewRow row in dgvHistorial.Rows)
            {
                if (row.Cells["Total"].Value != null)
                {
                    totalVenta += Convert.ToDecimal(row.Cells["Total"].Value);
                }
            }

            lblTotalUnidades.Text = totalUnidades.ToString();
            lblTotalVenta.Text = totalVenta.ToString("C2", CultureInfo.CurrentCulture);
        }
    }
}