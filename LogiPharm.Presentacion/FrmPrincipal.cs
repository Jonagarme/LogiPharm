using System;
using System.Drawing;
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
            MenuStrip menu = new MenuStrip();
            menu.Dock = DockStyle.Top;
            menu.BackColor = Color.WhiteSmoke;
            menu.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            // INICIO
            ToolStripMenuItem inicio = new ToolStripMenuItem("🏠 Inicio");
            inicio.DropDownItems.Add("Dashboard");
            inicio.DropDownItems.Add("Notificaciones");

            // VENTAS Y RECETAS
            ToolStripMenuItem ventas = new ToolStripMenuItem("🧾 Ventas y Recetas");
            ventas.DropDownItems.Add("Punto de venta");
            ventas.DropDownItems.Add("Facturación");
            ventas.DropDownItems.Add("Devoluciones");
            ventas.DropDownItems.Add("Cierre de caja");
            ventas.DropDownItems.Add("Historial de ventas");
            ventas.DropDownItems.Add("Cotizaciones");
            ventas.DropDownItems.Add("Recetas médicas");

            // INVENTARIO Y MEDICAMENTOS
            ToolStripMenuItem inventario = new ToolStripMenuItem("📦 Inventario y Medicamentos");
            inventario.DropDownItems.Add("Gestión de Productos");
            inventario.DropDownItems.Add("Ingreso de productos");
            inventario.DropDownItems.Add("Lotes y vencimientos");
            inventario.DropDownItems.Add("Kardex");
            inventario.DropDownItems.Add("Ajustes de inventario");
            inventario.DropDownItems.Add("Transferencias entre sucursales");
            inventario.DropDownItems.Add("Alertas de stock mínimo");
            inventario.DropDownItems.Add("Principios activos");
            inventario.DropDownItems.Add("Presentaciones");
            inventario.DropDownItems.Add("Medicamentos controlados");
            inventario.DropDownItems.Add("Código de barras");
            inventario.DropDownItems.Add("Vademécum");

            // COMPRAS Y PROVEEDORES
            ToolStripMenuItem compras = new ToolStripMenuItem("🛒 Compras y Proveedores");
            compras.DropDownItems.Add("Órdenes de compra");
            compras.DropDownItems.Add("Recepción de productos");
            compras.DropDownItems.Add("Facturas de compra");
            compras.DropDownItems.Add("Historial de compras");
            compras.DropDownItems.Add("Gestión de proveedores");
            compras.DropDownItems.Add("Ranking");

            // CLIENTES
            ToolStripMenuItem clientes = new ToolStripMenuItem("👥 Clientes");
            clientes.DropDownItems.Add("Gestión de Clientes");
            clientes.DropDownItems.Add("Historial de compras");
            clientes.DropDownItems.Add("Créditos / puntos");

            // CONTABILIDAD Y REPORTES
            ToolStripMenuItem finanzas = new ToolStripMenuItem("📊 Finanzas y Reportes");
            finanzas.DropDownItems.Add("CxC / CxP");
            finanzas.DropDownItems.Add("Libro diario / mayor");
            finanzas.DropDownItems.Add("Conciliaciones");
            finanzas.DropDownItems.Add("Reporte de ventas");
            finanzas.DropDownItems.Add("Reporte de inventario");
            finanzas.DropDownItems.Add("Reporte de compras");
            finanzas.DropDownItems.Add("Reportes financieros");

            // NORMATIVAS
            ToolStripMenuItem normativas = new ToolStripMenuItem("🏥 Normativas");
            normativas.DropDownItems.Add("Control psicotrópicos");
            normativas.DropDownItems.Add("ANMAT/SRI");

            // SEGURIDAD
            ToolStripMenuItem seguridad = new ToolStripMenuItem("👤 Seguridad");
            seguridad.DropDownItems.Add("Usuarios");
            seguridad.DropDownItems.Add("Roles");
            seguridad.DropDownItems.Add("Bitácora");

            // CONFIGURACIÓN
            ToolStripMenuItem configuracion = new ToolStripMenuItem("⚙️ Configuración");
            configuracion.DropDownItems.Add("Empresa");
            configuracion.DropDownItems.Add("Impuestos");
            configuracion.DropDownItems.Add("Secuencias");
            configuracion.DropDownItems.Add("Firma electrónica");
            configuracion.DropDownItems.Add("Integraciones");

            // SUCURSALES
            ToolStripMenuItem sucursales = new ToolStripMenuItem("🏪 Sucursales");
            sucursales.DropDownItems.Add("Gestión de Sucursales");
            sucursales.DropDownItems.Add("Transferencias internas");

            // Agregar al menú principal
            menu.Items.Add(inicio);
            menu.Items.Add(ventas);
            menu.Items.Add(inventario);
            menu.Items.Add(compras);
            menu.Items.Add(clientes);
            menu.Items.Add(finanzas);
            menu.Items.Add(normativas);
            menu.Items.Add(seguridad);
            menu.Items.Add(configuracion);
            menu.Items.Add(sucursales);

            this.MainMenuStrip = menu;
            this.Controls.Add(menu);
        }
    }
}
