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
        public FrmFacturasCompra()
        {
            InitializeComponent();
            this.Load += FrmFacturasCompra_Load;
        }

        private void FrmFacturasCompra_Load(object sender, EventArgs e)
        {
            // Auditoría: VISUALIZAR
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Compras", "VISUALIZAR", "facturas_compra", null, "Abrir Facturas de Compra", null, Environment.MachineName, "UI"); } catch { }
        }
    }
}
