using System.Windows.Forms;
using System.Drawing;
using LogiPharm.Datos; 
using System;
using System.Linq;
using System.Configuration;

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
            ToolStripMenuItem inicio = ConstruirMenuInicio(formulario);
            ToolStripMenuItem ventas = ConstruirMenuVentas(formulario);
            ToolStripMenuItem inventario = ConstruirMenuInventario(formulario);
            ToolStripMenuItem compras = ConstruirMenuCompras(formulario);
            ToolStripMenuItem clientes = ConstruirMenuClientes(formulario);
            ToolStripMenuItem finanzas = ConstruirMenuFinanzas(formulario);
            ToolStripMenuItem normativas = ConstruirMenuNormativas();
            ToolStripMenuItem seguridad = ConstruirMenuSeguridad(formulario);
            ToolStripMenuItem configuracion = ConstruirMenuConfiguracion(formulario);
            ToolStripMenuItem sucursales = ConstruirMenuSucursales();
            ToolStripMenuItem ventanas = ConstruirMenuVentanas(formulario);

            // Agregar menús según el rol
            if (rolUsuario == "Administrador")
            {
                menu.Items.AddRange(new ToolStripItem[]
                {
                    inicio, ventas, inventario, compras, clientes, finanzas, normativas, seguridad, configuracion, sucursales, ventanas
                });
            }
            else if (rolUsuario == "Farmacéutico")
            {
                menu.Items.AddRange(new ToolStripItem[]
                {
                    inicio, ventas, inventario, clientes, normativas, ventanas
                });
            }
            else if (rolUsuario == "Cajera")
            {
                menu.Items.AddRange(new ToolStripItem[]
                {
                    inicio, ventas, clientes, ventanas
                });
            }
            else
            {
                // Rol desconocido: menú mínimo
                menu.Items.Add(inicio);
                menu.Items.Add(ventanas);
            }

            // Agregar control visual de navegación de ventanas abiertas
            AgregarNavegadorVentanas(menu, formulario);

            return menu;
        }

        // Métodos privados para construir submenús

        private static ToolStripMenuItem ConstruirMenuInicio(Form formulario)
        {
            var inicio = new ToolStripMenuItem("🏠 Inicio");

            var mDashboard = new ToolStripMenuItem("Dashboard");
            mDashboard.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmDashboard>(formulario);

            var mNotif = new ToolStripMenuItem("Notificaciones");

            var mCerrar = new ToolStripMenuItem("Cerrar Sesión");
            mCerrar.ShortcutKeys = Keys.Control | Keys.L;
            mCerrar.Click += (s, e) => CerrarSesion(formulario);

            inicio.DropDownItems.Add(mDashboard);
            inicio.DropDownItems.Add(mNotif);
            inicio.DropDownItems.Add(new ToolStripSeparator());
            inicio.DropDownItems.Add(mCerrar);

            return inicio;
        }

        private static void CerrarSesion(Form formulario)
        {
            var r = MessageBox.Show("¿Deseas cerrar sesión?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            try
            {
                if (SesionActual.Activa)
                    new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Login", "LOGOUT", "usuarios", SesionActual.IdUsuario, "Cierre de sesión", null, Environment.MachineName, "UI");
            }
            catch { }

            foreach (var child in formulario.MdiChildren) child.Close();
            SesionActual.Limpiar();

            var frmLogin = Application.OpenForms.OfType<FrmLogin>().FirstOrDefault();
            if (frmLogin == null) frmLogin = new FrmLogin();

            frmLogin.Show();
            frmLogin.BringToFront();
            formulario.Close();
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
            ToolStripMenuItem cierreDeCaja = new ToolStripMenuItem("Cierre de Caja");
            cierreDeCaja.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmCierreCaja>(formulario);
            ventas.DropDownItems.Add(cierreDeCaja);
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
            DCierreCaja d_Cierre = new DCierreCaja();
            int idCajaActual = 1;
            try
            {
                bool cajaAbierta = d_Cierre.VerificarCajaAbiertaHoy(idCajaActual);
                if (cajaAbierta)
                {
                    FormulariosHelper.AbrirFormulario<FrmPuntoDeVenta>(formularioPrincipal);
                }
                else
                {
                    MessageBox.Show("Debe realizar la apertura de caja para poder iniciar las ventas.", "Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    using (FrmAperturaCaja frmApertura = new FrmAperturaCaja())
                    {
                        if (frmApertura.ShowDialog() == DialogResult.OK)
                        {
                            decimal montoInicial = frmApertura.MontoInicial;
                            int idUsuarioActual = SesionActual.IdUsuario;
                            d_Cierre.RegistrarApertura(montoInicial, idUsuarioActual, idCajaActual);
                            MessageBox.Show($"Caja abierta con {montoInicial:C2}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            ToolStripMenuItem laboratorios = new ToolStripMenuItem("Laboratorios");
            laboratorios.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmLaboratorios>(formulario);
            inventario.DropDownItems.Add(laboratorios);

            inventario.DropDownItems.Add("Perchas");
            inventario.DropDownItems.Add("Ingreso de productos");
            inventario.DropDownItems.Add("Lotes y vencimientos");
            ToolStripMenuItem kardex = new ToolStripMenuItem("Kardex");
            kardex.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmKardex>(formulario);
            inventario.DropDownItems.Add(kardex);
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

        private static ToolStripMenuItem ConstruirMenuFinanzas(Form formulario)
        {
            ToolStripMenuItem finanzas = new ToolStripMenuItem("📊 Finanzas y Reportes");
            ToolStripMenuItem Reporteventas = new ToolStripMenuItem("Reporte de ventas");
            Reporteventas.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmReporteVentas>(formulario);
            finanzas.DropDownItems.Add("CxC / CxP");
            finanzas.DropDownItems.Add("Libro diario / mayor");
            finanzas.DropDownItems.Add("Conciliaciones");
            finanzas.DropDownItems.Add(Reporteventas);
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
            ToolStripMenuItem roles = new ToolStripMenuItem("Roles");
            roles.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmRoles>(formulario);
            seguridad.DropDownItems.Add(roles);
            ToolStripMenuItem bitacora = new ToolStripMenuItem("Bitácora");
            bitacora.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmBitacora>(formulario);
            seguridad.DropDownItems.Add(bitacora);
            return seguridad;
        }

        private static ToolStripMenuItem ConstruirMenuConfiguracion(Form formulario)
        {
            ToolStripMenuItem configuracion = new ToolStripMenuItem("⚙️ Configuración");
            ToolStripMenuItem empresa = new ToolStripMenuItem("Empresa");
            empresa.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmEmpresa>(formulario);
            configuracion.DropDownItems.Add(empresa);
            var impuestos = new ToolStripMenuItem("Impuestos");
            impuestos.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmImpuestos>(formulario);
            configuracion.DropDownItems.Add(impuestos);
            var secuencias = new ToolStripMenuItem("Secuencias");
            secuencias.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmSecuencias>(formulario);
            configuracion.DropDownItems.Add(secuencias);
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

        // === Ventanas: listado dinámico de formularios abiertos y navegación rápida ===
        private static ToolStripMenuItem ConstruirMenuVentanas(Form formulario)
        {
            var ventanas = new ToolStripMenuItem("🗂 Ventanas");
            var mAnterior = new ToolStripMenuItem("Anterior");
            mAnterior.ShortcutKeys = Keys.Control | Keys.Shift | Keys.F6;
            mAnterior.Click += (s, e) => ActivarVentanaOffset(formulario, -1);
            var mSiguiente = new ToolStripMenuItem("Siguiente");
            mSiguiente.ShortcutKeys = Keys.Control | Keys.F6;
            mSiguiente.Click += (s, e) => ActivarVentanaOffset(formulario, +1);
            ventanas.DropDownOpening += (s, e) =>
            {
                ventanas.DropDownItems.Clear();
                ventanas.DropDownItems.Add(mAnterior);
                ventanas.DropDownItems.Add(mSiguiente);
                ventanas.DropDownItems.Add(new ToolStripSeparator());
                var forms = ObtenerVentanas(formulario);
                foreach (var f in forms)
                {
                    var item = new ToolStripMenuItem(f.Text) { Checked = (f == GetActiva(formulario)), Tag = f };
                    item.Click += (ss, ee) => { ActivarVentana((Form)((ToolStripMenuItem)ss).Tag); };
                    ventanas.DropDownItems.Add(item);
                }
                if (forms.Count == 0)
                    ventanas.DropDownItems.Add(new ToolStripMenuItem("(No hay ventanas abiertas)") { Enabled = false });
            };
            return ventanas;
        }

        private static void ActivarVentanaOffset(Form formulario, int offset)
        {
            var forms = ObtenerVentanas(formulario);
            if (forms.Count == 0) return;
            Form activa = GetActiva(formulario) ?? forms[0];
            int idx = forms.IndexOf(activa);
            if (idx < 0) idx = 0;
            idx = (idx + offset) % forms.Count;
            if (idx < 0) idx += forms.Count;
            ActivarVentana(forms[idx]);
        }

        private static void ActivarVentana(Form f)
        {
            if (f.WindowState == FormWindowState.Minimized) f.WindowState = FormWindowState.Normal;
            f.Activate();
            f.BringToFront();
        }

        private static System.Collections.Generic.List<Form> ObtenerVentanas(Form formulario)
        {
            return formulario.IsMdiContainer
                ? formulario.MdiChildren.Where(f => f.Visible).ToList()
                : Application.OpenForms.Cast<Form>().Where(f => f.Visible).ToList();
        }

        private static Form GetActiva(Form formulario)
        {
            return formulario.IsMdiContainer ? formulario.ActiveMdiChild : Form.ActiveForm;
        }

        // Control visual: flechas + dropdown con ventanas
        private static void AgregarNavegadorVentanas(MenuStrip menu, Form formulario)
        {
            var btnPrev = new ToolStripButton("◀") { ToolTipText = "Ventana anterior" };
            var ddStack = new ToolStripDropDownButton("Ventanas") { ToolTipText = "Ventanas abiertas" };
            var btnNext = new ToolStripButton("▶") { ToolTipText = "Ventana siguiente" };

            btnPrev.Click += (s, e) => ActivarVentanaOffset(formulario, -1);
            btnNext.Click += (s, e) => ActivarVentanaOffset(formulario, +1);

            ddStack.DropDownOpening += (s, e) =>
            {
                ddStack.DropDownItems.Clear();
                var forms = ObtenerVentanas(formulario);
                var activa = GetActiva(formulario);
                ddStack.Text = activa != null ? TruncTitulo(activa.Text) : "Ventanas";
                foreach (var f in forms)
                {
                    var item = new ToolStripMenuItem(f.Text) { Checked = (f == activa), Tag = f };
                    item.Click += (ss, ee) => { ActivarVentana((Form)((ToolStripMenuItem)ss).Tag); };
                    ddStack.DropDownItems.Add(item);
                }
                if (forms.Count == 0)
                    ddStack.DropDownItems.Add(new ToolStripMenuItem("(No hay ventanas abiertas)") { Enabled = false });
            };

            // Opcional: separador y alineación a la derecha
            var sep = new ToolStripSeparator();
            menu.Items.Add(sep);
            menu.Items.Add(btnPrev);
            menu.Items.Add(ddStack);
            menu.Items.Add(btnNext);
        }

        private static string TruncTitulo(string text, int max = 28)
        {
            if (string.IsNullOrEmpty(text)) return "Ventanas";
            return text.Length <= max ? text : text.Substring(0, max - 1) + "…";
        }

    }
}
