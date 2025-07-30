using LogiPharm.Presentacion.Utilidades;
using System;
using System.Windows.Forms;

namespace LogiPharm.Presentacion
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            IsMdiContainer = true;
            this.Load += FrmPrincipal_Load;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            // Construir y añadir el menú principal
            var menu = Utilidades.MenuHelper.ConstruirMenu(this, "Administrador");
            this.MainMenuStrip = menu;
            this.Controls.Add(menu);

            // --- CAMBIO CLAVE: ABRIR EL DASHBOARD COMO FORMULARIO HIJO ---
            FormulariosHelper.AbrirFormulario<FrmDashboard>(this);
        }
    }
}
