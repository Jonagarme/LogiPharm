using System.Windows.Forms;
using System.Drawing;
using LogiPharm.Datos; 
using System;

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
            else if (rolUsuario == "Cajera")
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

            ToolStripMenuItem puntoDeVenta = new ToolStripMenuItem("Punto de venta");
            puntoDeVenta.Click += (s, e) => AbrirPuntoDeVentaConVerificacion(formulario);
            ventas.DropDownItems.Add(puntoDeVenta);

            ToolStripMenuItem facturacion = new ToolStripMenuItem("Facturación");
            facturacion.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmFacturacion>(formulario);
            ventas.DropDownItems.Add(facturacion);

            ToolStripMenuItem devoluciones = new ToolStripMenuItem("Devoluciones");
            devoluciones.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmDevoluciones>(formulario);
            ventas.DropDownItems.Add(devoluciones);
            //ventas.DropDownItems.Add("Devoluciones");

            ToolStripMenuItem cierreDeCaja = new ToolStripMenuItem("Cierre de Caja");
            cierreDeCaja.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmCierreCaja>(formulario);
            ventas.DropDownItems.Add(cierreDeCaja);

            //ventas.DropDownItems.Add("Historial de ventas");

            ToolStripMenuItem historialDeVentas = new ToolStripMenuItem("Historial de ventas");
            historialDeVentas.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmHistorialVentas>(formulario);
            ventas.DropDownItems.Add(historialDeVentas);

            ToolStripMenuItem cotizaciones = new ToolStripMenuItem("Cotizaciones");
            cotizaciones.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmCotizaciones>(formulario);
            ventas.DropDownItems.Add(cotizaciones);

            ventas.DropDownItems.Add("Recetas médicas");
            return ventas;
        }

        private static void AbrirPuntoDeVentaConVerificacion(Form formularioPrincipal)
        {
            // ✅ CAMBIO: Ahora usamos DCierreCaja para toda la lógica.
            DCierreCaja d_Cierre = new DCierreCaja();

            // ✅ CAMBIO: Usamos el ID numérico de la caja, no el texto.
            int idCajaActual = 1; // Asumimos que la caja principal es la 1.

            try
            {
                // 1. VERIFICAMOS SI LA CAJA YA ESTÁ ABIERTA
                bool cajaAbierta = d_Cierre.VerificarCajaAbiertaHoy(idCajaActual);

                if (cajaAbierta)
                {
                    // Si está abierta, abre el POS directamente
                    FormulariosHelper.AbrirFormulario<FrmPuntoDeVenta>(formularioPrincipal);
                }
                else
                {
                    // 2. SI NO ESTÁ ABIERTA, FORZAMOS LA APERTURA
                    MessageBox.Show("Debe realizar la apertura de caja para poder iniciar las ventas.", "Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    using (FrmAperturaCaja frmApertura = new FrmAperturaCaja())
                    {
                        if (frmApertura.ShowDialog() == DialogResult.OK)
                        {
                            // 3. SI EL USUARIO ACEPTA, REGISTRAMOS Y ABRIMOS EL POS
                            decimal montoInicial = frmApertura.MontoInicial;

                            // ✅ CAMBIO: Enviamos el ID del usuario (INT), no el nombre (string).
                            int idUsuarioActual = SesionActual.IdUsuario;

                            // Llamamos al método RegistrarApertura de nuestra clase unificada
                            d_Cierre.RegistrarApertura(montoInicial, idUsuarioActual, idCajaActual);

                            MessageBox.Show($"Caja abierta con {montoInicial:C2}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Abre el POS usando tu Helper
                            FormulariosHelper.AbrirFormulario<FrmPuntoDeVenta>(formularioPrincipal);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al verificar el estado de la caja: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            ToolStripMenuItem kardex = new ToolStripMenuItem("Kardex");
            kardex.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmKardex>(formulario);
            inventario.DropDownItems.Add(kardex);
            //inventario.DropDownItems.Add("Kardex");

            //inventario.DropDownItems.Add("Ajustes de inventario");
            ToolStripMenuItem ajusteDeInventario = new ToolStripMenuItem("Ajustes de inventario");
            ajusteDeInventario.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmAjusteInventario>(formulario);
            inventario.DropDownItems.Add(ajusteDeInventario);

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

            //ToolStripMenuItem proveedores = new ToolStripMenuItem("Gestión de proveedores");
            //proveedores.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmProveedores>(formulario);
            compras.DropDownItems.Add("Órdenes de compra");

            ToolStripMenuItem recepcionProductos = new ToolStripMenuItem("Recepcion de Productos");
            recepcionProductos.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmRecepcionProductos>(formulario);
            compras.DropDownItems.Add(recepcionProductos);


            ToolStripMenuItem facturasCompra = new ToolStripMenuItem("Facturas de compra");
            facturasCompra.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmFacturasCompra>(formulario);
            compras.DropDownItems.Add(facturasCompra);

            ToolStripMenuItem historialCompra = new ToolStripMenuItem("Historial de compras");
            historialCompra.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmHistorialCompras>(formulario);
            compras.DropDownItems.Add(historialCompra);

            //compras.DropDownItems.Add(proveedores);
            ToolStripMenuItem proveedores = new ToolStripMenuItem("Proveedores");
            proveedores.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmProveedores>(formulario);
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

            //seguridad.DropDownItems.Add("Roles");
            ToolStripMenuItem roles = new ToolStripMenuItem("Roles");
            roles.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmRoles>(formulario);
            seguridad.DropDownItems.Add(roles);

            ToolStripMenuItem bitacora = new ToolStripMenuItem("Bitácora");
            bitacora.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmBitacora>(formulario);
            seguridad.DropDownItems.Add(bitacora);

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
