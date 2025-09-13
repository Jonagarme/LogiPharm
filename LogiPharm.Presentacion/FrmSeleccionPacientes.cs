using System;
using System.Data;
using System.Windows.Forms;
using LogiPharm.Datos;

namespace LogiPharm.Presentacion
{
    public partial class FrmSeleccionPacientes : Form
    {
        public int? PacienteSeleccionadoId { get; private set; }
        public string FiltroAplicado { get; private set; }
        public FrmSeleccionPacientes()
        {
            InitializeComponent();
            this.Load += FrmSeleccionPacientes_Load;
            this.txtBuscar.TextChanged += (s,e)=> Cargar(this.txtBuscar.Text);
            this.dgv.DoubleClick += (s,e)=> SeleccionarActual();
            this.btnAceptar.Click += (s,e)=> SeleccionarActual();
            this.btnCancelar.Click += (s,e)=> this.DialogResult = DialogResult.Cancel;
        }
        private void FrmSeleccionPacientes_Load(object sender, EventArgs e)
        {
            Cargar(null);
        }
        private void Cargar(string filtro)
        {
            try
            {
                var dt = new DPacientes().Listar(filtro);
                dgv.AutoGenerateColumns = true;
                dgv.DataSource = dt;
                FiltroAplicado = filtro;
            }
            catch (Exception ex) { MessageBox.Show("Error: "+ex.Message); }
        }
        private void SeleccionarActual()
        {
            if (dgv.CurrentRow == null) return;
            var drv = dgv.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) return;
            PacienteSeleccionadoId = Convert.ToInt32(drv["id"]);
            this.DialogResult = DialogResult.OK;
        }
    }
}
