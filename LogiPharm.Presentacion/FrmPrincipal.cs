using LogiPharm.Presentacion.Utilidades;
using System;
using System.Windows.Forms;

namespace LogiPharm.Presentacion
{
    public partial class FrmPrincipal : Form
    {
        private string _rolUsuario;

        public FrmPrincipal(string rolUsuario)
        {
            InitializeComponent();
            _rolUsuario = rolUsuario;
            IsMdiContainer = true;
            this.Load += FrmPrincipal_Load;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            var menu = Utilidades.MenuHelper.ConstruirMenu(this, _rolUsuario);
            this.MainMenuStrip = menu;
            this.Controls.Add(menu);
        }
    }
}
