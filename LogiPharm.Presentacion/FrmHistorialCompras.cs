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
    public partial class FrmHistorialCompras : Form
    {
        public FrmHistorialCompras()
        {
            InitializeComponent();
            this.Load += FrmHistorialCompras_Load;
        }

        private void FrmHistorialCompras_Load(object sender, EventArgs e)
        {
            // Auditoría: VISUALIZAR
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Compras", "VISUALIZAR", "historial_compras", null, "Abrir Historial de Compras", null, Environment.MachineName, "UI"); } catch { }
        }
    }
}
