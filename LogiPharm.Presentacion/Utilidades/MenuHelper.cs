using System.Windows.Forms;
using System.Drawing;

namespace LogiPharm.Presentacion.Utilidades
{
    public static class MenuHelper
    {
        public static MenuStrip ConstruirMenu(Form formulario, string rolUsuario)
        {
            MenuStrip menu = new MenuStrip
            {
                Dock = DockStyle.Top,
                BackColor = Color.WhiteSmoke,
                Font = new Font("Segoe UI", 10, FontStyle.Regular)
            };

            // Menús disponibles
            ToolStripMenuItem inicio = ConstruirMenuInicio();
            ToolStripMenuItem ventas = ConstruirMenuVentas(formulario);
            ToolStripMenuItem inventario = ConstruirMenuInventario(formulario);
            ToolStripMenuItem compras = ConstruirMenuCompras(formulario);
            ToolStripMenuItem clientes = ConstruirMenuClientes(formulario);
            ToolStripMenuItem finanzas = ConstruirMenuFinanzas();
            ToolStripMenuItem normativas = ConstruirMenuNormativas();
            ToolStripMenuItem seguridad = ConstruirMenuSeguridad(formulario);
            ToolStripMenuItem configuracion = ConstruirMenuConfiguracion();
            ToolStripMenuItem sucursales = ConstruirMenuSucursales();

            // Agregar menús según el rol
            if (rolUsuario == "Administrador")
            {
                menu.Items.AddRange(new ToolStripItem[]
                {
                    inicio, ventas, inventario, compras, clientes, finanzas, normativas, seguridad, configuracion, sucursales
                });
            }
            else if (rolUsuario == "Farmacéutico")
            {
                menu.Items.AddRange(new ToolStripItem[]
                {
                    inicio, ventas, inventario, clientes, normativas
                });
            }
            else if (rolUsuario == "Cajero")
            {
                menu.Items.AddRange(new ToolStripItem[]
                {
                    inicio, ventas, clientes
                });
            }
            else
            {
                // Rol desconocido: menú mínimo
                menu.Items.Add(inicio);
            }

            return menu;
        }

        // Métodos privados para construir submenús

        private static ToolStripMenuItem ConstruirMenuInicio()
        {
            ToolStripMenuItem inicio = new ToolStripMenuItem("🏠 Inicio");
            inicio.DropDownItems.Add("Dashboard");
            inicio.DropDownItems.Add("Notificaciones");
            return inicio;
        }

        private static ToolStripMenuItem ConstruirMenuVentas(Form formulario)
        {
            ToolStripMenuItem ventas = new ToolStripMenuItem("🧾 Ventas y Recetas");
            ventas.DropDownItems.Add("Punto de venta");
            ventas.DropDownItems.Add("Facturación");
            ventas.DropDownItems.Add("Devoluciones");
            ventas.DropDownItems.Add("Cierre de caja");
            ventas.DropDownItems.Add("Historial de ventas");
            ventas.DropDownItems.Add("Cotizaciones");
            ventas.DropDownItems.Add("Recetas médicas");
            return ventas;
        }

        private static ToolStripMenuItem ConstruirMenuInventario(Form formulario)
        {
            ToolStripMenuItem inventario = new ToolStripMenuItem("📦 Inventario y Medicamentos");

            ToolStripMenuItem productos = new ToolStripMenuItem("Productos");
            productos.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmProductos>(formulario);
            inventario.DropDownItems.Add(productos);

            inventario.DropDownItems.Add("Laboratorios");
            inventario.DropDownItems.Add("Perchas");
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

            return inventario;
        }

        private static ToolStripMenuItem ConstruirMenuCompras(Form formulario)
        {
            ToolStripMenuItem compras = new ToolStripMenuItem("🛒 Compras y Proveedores");

            ToolStripMenuItem proveedores = new ToolStripMenuItem("Gestión de proveedores");
            proveedores.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmProveedores>(formulario);
            compras.DropDownItems.Add("Órdenes de compra");
            compras.DropDownItems.Add("Recepción de productos");
            compras.DropDownItems.Add("Facturas de compra");
            compras.DropDownItems.Add("Historial de compras");
            compras.DropDownItems.Add(proveedores);
            compras.DropDownItems.Add("Ranking");

            return compras;
        }

        private static ToolStripMenuItem ConstruirMenuClientes(Form formulario)
        {
            ToolStripMenuItem clientes = new ToolStripMenuItem("👥 Clientes");

            ToolStripMenuItem gestionClientes = new ToolStripMenuItem("Gestión de Clientes");
            gestionClientes.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmClientes>(formulario);
            clientes.DropDownItems.Add(gestionClientes);

            clientes.DropDownItems.Add("Historial de compras");
            clientes.DropDownItems.Add("Créditos / puntos");

            return clientes;
        }

        private static ToolStripMenuItem ConstruirMenuFinanzas()
        {
            ToolStripMenuItem finanzas = new ToolStripMenuItem("📊 Finanzas y Reportes");
            finanzas.DropDownItems.Add("CxC / CxP");
            finanzas.DropDownItems.Add("Libro diario / mayor");
            finanzas.DropDownItems.Add("Conciliaciones");
            finanzas.DropDownItems.Add("Reporte de ventas");
            finanzas.DropDownItems.Add("Reporte de inventario");
            finanzas.DropDownItems.Add("Reporte de compras");
            finanzas.DropDownItems.Add("Reportes financieros");
            return finanzas;
        }

        private static ToolStripMenuItem ConstruirMenuNormativas()
        {
            ToolStripMenuItem normativas = new ToolStripMenuItem("🏥 Normativas");
            normativas.DropDownItems.Add("Control psicotrópicos");
            normativas.DropDownItems.Add("ANMAT/SRI");
            return normativas;
        }

        private static ToolStripMenuItem ConstruirMenuSeguridad(Form formulario)
        {
            ToolStripMenuItem seguridad = new ToolStripMenuItem("👤 Seguridad");

            ToolStripMenuItem usuarios = new ToolStripMenuItem("Usuarios");
            usuarios.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmUsuarios>(formulario);
            seguridad.DropDownItems.Add(usuarios);

            seguridad.DropDownItems.Add("Roles");
            seguridad.DropDownItems.Add("Bitácora");
            return seguridad;
        }

        private static ToolStripMenuItem ConstruirMenuConfiguracion()
        {
            ToolStripMenuItem configuracion = new ToolStripMenuItem("⚙️ Configuración");
            configuracion.DropDownItems.Add("Empresa");
            configuracion.DropDownItems.Add("Impuestos");
            configuracion.DropDownItems.Add("Secuencias");
            configuracion.DropDownItems.Add("Firma electrónica");
            configuracion.DropDownItems.Add("Integraciones");
            return configuracion;
        }

        private static ToolStripMenuItem ConstruirMenuSucursales()
        {
            ToolStripMenuItem sucursales = new ToolStripMenuItem("🏪 Sucursales");
            sucursales.DropDownItems.Add("Gestión de Sucursales");
            sucursales.DropDownItems.Add("Transferencias internas");
            return sucursales;
        }
    }
}
