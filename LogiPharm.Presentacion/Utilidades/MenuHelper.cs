using LogiPharm.Datos; 
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace LogiPharm.Presentacion.Utilidades
{
    public static class MenuHelper
    {
        // === PALETA DE COLORES PROFESIONAL ===
        private static class Colores
        {
            // Color principal - Azul profesional
            public static readonly Color PrincipalOscuro = Color.FromArgb(41, 98, 255);
            public static readonly Color PrincipalClaro = Color.FromArgb(56, 116, 255);
            
            // Color de fondo
            public static readonly Color FondoMenu = Color.FromArgb(248, 249, 250);
            public static readonly Color FondoMenuHover = Color.FromArgb(230, 236, 245);
            public static readonly Color FondoMenuSeleccionado = Color.FromArgb(214, 228, 255);
            
            // Texto
            public static readonly Color TextoPrincipal = Color.FromArgb(33, 37, 41);
            public static readonly Color TextoSecundario = Color.FromArgb(108, 117, 125);
            public static readonly Color TextoBlanco = Color.White;
            
            // Bordes
            public static readonly Color Borde = Color.FromArgb(222, 226, 230);
            public static readonly Color BordeSombra = Color.FromArgb(206, 212, 218);
            
            // Estados
            public static readonly Color Exito = Color.FromArgb(40, 167, 69);
            public static readonly Color Advertencia = Color.FromArgb(255, 193, 7);
            public static readonly Color Peligro = Color.FromArgb(220, 53, 69);
            public static readonly Color Info = Color.FromArgb(23, 162, 184);
        }
        
        // === FUENTES ===
        private static class Fuentes
        {
            public static readonly Font MenuPrincipal = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            public static readonly Font MenuDestacado = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            public static readonly Font SubMenu = new Font("Segoe UI", 9F, FontStyle.Regular);
            public static readonly Font Indicador = new Font("Segoe UI", 8F, FontStyle.Regular);
        }
        public static MenuStrip ConstruirMenu(Form formulario, string rolUsuario)
        {
            MenuStrip menu = new MenuStrip
            {
                Dock = DockStyle.Top,
                BackColor = Colores.FondoMenu,
                ForeColor = Colores.TextoPrincipal,
                Font = Fuentes.MenuPrincipal,
                CanOverflow = true,
                LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow,
                Padding = new Padding(8, 4, 8, 4),
                RenderMode = ToolStripRenderMode.Professional,
                Renderer = new MenuRendererProfesional()
            };

            // Diccionario para acceder fácilmente a cada menú por un nombre clave
            var todosLosMenus = new Dictionary<string, ToolStripMenuItem>
                {
                    { "Inicio", ConstruirMenuInicio(formulario) },
                    { "Ventas", ConstruirMenuVentas(formulario) },
                    { "Caja", ConstruirMenuCaja(formulario) },
                    { "Inventario", ConstruirMenuInventario(formulario) },
                    { "Compras", ConstruirMenuCompras(formulario) },
                    { "Clientes", ConstruirMenuClientes(formulario) },
                    { "Finanzas", ConstruirMenuFinanzas(formulario) },
                    { "Normativas", ConstruirMenuNormativas() },
                    { "Seguridad", ConstruirMenuSeguridad(formulario) },
                    { "Configuracion", ConstruirMenuConfiguracion(formulario) },
                    { "Sucursales", ConstruirMenuSucursales(formulario) },
                    { "Ventanas", ConstruirMenuVentanas(formulario) }
                };

            // 2. Creamos una lista vacía y la llenamos SÓLO con los menús del rol actual
            var menusParaEsteRol = new List<ToolStripMenuItem>();

            switch (rolUsuario)
            {
                case "Administrador":
                    menusParaEsteRol.AddRange(new[] { todosLosMenus["Inicio"], todosLosMenus["Ventas"], todosLosMenus["Caja"], todosLosMenus["Inventario"], todosLosMenus["Compras"], todosLosMenus["Clientes"], todosLosMenus["Finanzas"], todosLosMenus["Normativas"], todosLosMenus["Seguridad"], todosLosMenus["Configuracion"], todosLosMenus["Sucursales"], todosLosMenus["Ventanas"] });
                    break;
                case "Farmacéutico":
                    menusParaEsteRol.AddRange(new[] { todosLosMenus["Inicio"], todosLosMenus["Ventas"], todosLosMenus["Caja"], todosLosMenus["Inventario"], todosLosMenus["Clientes"], todosLosMenus["Normativas"], todosLosMenus["Ventanas"] });
                    break;
                case "Cajera":
                    menusParaEsteRol.AddRange(new[] { todosLosMenus["Inicio"], todosLosMenus["Ventas"], todosLosMenus["Caja"], todosLosMenus["Clientes"], todosLosMenus["Ventanas"] });
                    break;
                default: // Rol desconocido
                    menusParaEsteRol.AddRange(new[] { todosLosMenus["Inicio"], todosLosMenus["Ventanas"] });
                    break;
            }

            // 3. Añadimos los menús del rol al MenuStrip
            menu.Items.AddRange(menusParaEsteRol.ToArray());

            // 4. Agregar indicador de sesión
            AgregarIndicadorSesion(menu);

            // 5. AL FINAL, añadimos los controles de navegación anclados a la derecha
            AgregarNavegadorVentanas(menu, formulario);

            return menu;
        }

        // === RENDERER PERSONALIZADO ===
        private class MenuRendererProfesional : ToolStripProfessionalRenderer
        {
            public MenuRendererProfesional() : base(new ColoresMenuProfesional()) { }

            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (!e.Item.Selected)
                {
                    base.OnRenderMenuItemBackground(e);
                    return;
                }

                Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                
                // Efecto hover con gradiente sutil
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    rc, 
                    Colores.FondoMenuHover, 
                    Colores.FondoMenuSeleccionado, 
                    LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, rc);
                }
                
                // Borde inferior sutil
                using (Pen pen = new Pen(Colores.PrincipalClaro, 2))
                {
                    e.Graphics.DrawLine(pen, rc.Left, rc.Bottom - 1, rc.Right, rc.Bottom - 1);
                }
            }

            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                // Mejorar el renderizado del texto
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                e.TextColor = e.Item.Selected ? Colores.PrincipalOscuro : Colores.TextoPrincipal;
                base.OnRenderItemText(e);
            }
        }

        private class ColoresMenuProfesional : ProfessionalColorTable
        {
            public override Color MenuItemSelected => Colores.FondoMenuHover;
            public override Color MenuItemSelectedGradientBegin => Colores.FondoMenuHover;
            public override Color MenuItemSelectedGradientEnd => Colores.FondoMenuSeleccionado;
            public override Color MenuItemBorder => Colores.Borde;
            public override Color MenuBorder => Colores.Borde;
            public override Color MenuItemPressedGradientBegin => Colores.PrincipalClaro;
            public override Color MenuItemPressedGradientEnd => Colores.PrincipalOscuro;
            public override Color ToolStripDropDownBackground => Color.White;
            public override Color ImageMarginGradientBegin => Colores.FondoMenu;
            public override Color ImageMarginGradientMiddle => Colores.FondoMenu;
            public override Color ImageMarginGradientEnd => Colores.FondoMenu;
        }

        // === INDICADOR DE SESIÓN ===
        private static void AgregarIndicadorSesion(MenuStrip menu)
        {
            // Separador visual
            var separador = new ToolStripSeparator
            {
                Alignment = ToolStripItemAlignment.Right
            };

            // Indicador de estado de caja
            var lblCaja = new ToolStripLabel
            {
                Text = ObtenerTextoEstadoCaja(),
                ForeColor = ObtenerColorEstadoCaja(),
                Font = Fuentes.Indicador,
                Alignment = ToolStripItemAlignment.Right,
                Padding = new Padding(8, 0, 8, 0),
                ToolTipText = "Estado de la caja actual"
            };

            // Indicador de usuario
            var lblUsuario = new ToolStripLabel
            {
                Text = $"👤 {SesionActual.NombreUsuario} ({SesionActual.Rol})",
                ForeColor = Colores.TextoSecundario,
                Font = Fuentes.Indicador,
                Alignment = ToolStripItemAlignment.Right,
                Padding = new Padding(8, 0, 8, 0)
            };

            menu.Items.Add(lblUsuario);
            menu.Items.Add(lblCaja);
            menu.Items.Add(separador);
        }

        private static string ObtenerTextoEstadoCaja()
        {
            try
            {
                DCierreCaja d_Cierre = new DCierreCaja();
                bool cajaAbierta = d_Cierre.VerificarCajaAbiertaHoy(SesionActual.IdCaja);
                return cajaAbierta ? $"💰 {SesionActual.NombreCaja} - ABIERTA" : $"💰 {SesionActual.NombreCaja} - CERRADA";
            }
            catch
            {
                return "💰 Caja - Estado desconocido";
            }
        }

        private static Color ObtenerColorEstadoCaja()
        {
            try
            {
                DCierreCaja d_Cierre = new DCierreCaja();
                bool cajaAbierta = d_Cierre.VerificarCajaAbiertaHoy(SesionActual.IdCaja);
                return cajaAbierta ? Colores.Exito : Colores.Peligro;
            }
            catch
            {
                return Colores.Advertencia;
            }
        }

        // === MÉTODOS PARA CONSTRUIR SUBMENÚS ===

        private static ToolStripMenuItem ConstruirMenuInicio(Form formulario)
        {
            var inicio = new ToolStripMenuItem("🏠 Inicio")
            {
                Font = Fuentes.MenuDestacado
            };

            var mDashboard = new ToolStripMenuItem("Dashboard")
            {
                Font = Fuentes.SubMenu,
                ShortcutKeys = Keys.Control | Keys.D,
                ShowShortcutKeys = true
            };
            mDashboard.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmDashboard>(formulario);

            var mNotif = new ToolStripMenuItem("Notificaciones")
            {
                Font = Fuentes.SubMenu,
                ShortcutKeys = Keys.Control | Keys.N,
                ShowShortcutKeys = true
            };

            var mCerrar = new ToolStripMenuItem("Cerrar Sesión")
            {
                Font = Fuentes.SubMenu,
                ForeColor = Colores.Peligro,
                ShortcutKeys = Keys.Control | Keys.L,
                ShowShortcutKeys = true
            };
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
            ToolStripMenuItem ventas = new ToolStripMenuItem("🧾 Ventas y Recetas")
            {
                Font = Fuentes.MenuPrincipal
            };
            ToolStripMenuItem puntoDeVenta = new ToolStripMenuItem("Punto de venta")
            {
                Font = Fuentes.MenuDestacado,
                ForeColor = Colores.PrincipalOscuro,
                ShortcutKeys = Keys.F2,
                ShowShortcutKeys = true
            };
            puntoDeVenta.Click += (s, e) => AbrirPuntoDeVentaConVerificacion(formulario);
            ventas.DropDownItems.Add(puntoDeVenta);
            ToolStripMenuItem facturacion = new ToolStripMenuItem("Facturación");
            facturacion.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmFacturacion>(formulario);
            ventas.DropDownItems.Add(facturacion);
            ToolStripMenuItem devoluciones = new ToolStripMenuItem("Devoluciones");
            devoluciones.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmDevoluciones>(formulario);
            ventas.DropDownItems.Add(devoluciones);
            ToolStripMenuItem historialDeVentas = new ToolStripMenuItem("Historial de ventas");
            historialDeVentas.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmHistorialVentas>(formulario);
            ventas.DropDownItems.Add(historialDeVentas);
            ToolStripMenuItem cotizaciones = new ToolStripMenuItem("Cotizaciones");
            cotizaciones.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmCotizaciones>(formulario);
            ventas.DropDownItems.Add(cotizaciones);
            ToolStripMenuItem recetas = new ToolStripMenuItem("Recetas médicas");
            recetas.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmRecetasMedicas>(formulario);
            ventas.DropDownItems.Add(recetas);
            return ventas;
        }

        private static ToolStripMenuItem ConstruirMenuCaja(Form formulario)
        {
            ToolStripMenuItem caja = new ToolStripMenuItem("💰 Caja")
            {
                Font = Fuentes.MenuPrincipal
            };
            
            // Gestión de Cajas
            var gestionCajas = new ToolStripMenuItem("Gestión de Cajas");
            gestionCajas.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmGestionCajas>(formulario);
            caja.DropDownItems.Add(gestionCajas);
            
            caja.DropDownItems.Add(new ToolStripSeparator());
            
            // Operaciones de Caja
            var aperturaCaja = new ToolStripMenuItem("Apertura de Caja");
            aperturaCaja.Click += (s, e) =>
            {
                using (FrmAperturaCaja frm = new FrmAperturaCaja())
                {
                    frm.ShowDialog();
                }
            };
            caja.DropDownItems.Add(aperturaCaja);
            
            var cierreCaja = new ToolStripMenuItem("Cierre de Caja");
            cierreCaja.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmCierreCaja>(formulario);
            caja.DropDownItems.Add(cierreCaja);
            
            var estadoCaja = new ToolStripMenuItem("Estado de Caja");
            estadoCaja.Click += (s, e) =>
            {
                int idCajaActual = SesionActual.IdCaja; // Usar la caja de la sesión
                using (var frm = new FrmEstadoCaja(idCajaActual))
                {
                    frm.ShowDialog(formulario);
                }
            };
            caja.DropDownItems.Add(estadoCaja);
            
            caja.DropDownItems.Add(new ToolStripSeparator());
            
            // Reportes y Cierres
            var cierresDiarios = new ToolStripMenuItem("Cierres Diarios/Mensuales/Anuales");
            cierresDiarios.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmReporteCierres>(formulario);
            caja.DropDownItems.Add(cierresDiarios);
            
            var movimientos = new ToolStripMenuItem("Movimientos de Caja");
            movimientos.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmMovimientosCaja>(formulario);
            caja.DropDownItems.Add(movimientos);
            
            caja.DropDownItems.Add(new ToolStripSeparator());
            
            // Arqueo y Cuadre de Caja
            var arqueoCaja = new ToolStripMenuItem("Arqueo de Caja");
            arqueoCaja.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmArqueoCaja>(formulario);
            caja.DropDownItems.Add(arqueoCaja);
            
            var cuadreCaja = new ToolStripMenuItem("Cuadre de Caja");
            // El cuadre se realiza en el cierre (o puedes crear FrmCuadreCaja luego)
            cuadreCaja.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmCierreCaja>(formulario);
            caja.DropDownItems.Add(cuadreCaja);
            
            return caja;
        }

        private static void AbrirPuntoDeVentaConVerificacion(Form formularioPrincipal)
        {
            DCierreCaja d_Cierre = new DCierreCaja();
            int idCajaActual = SesionActual.IdCaja; // Usar la caja de la sesión
            try
            {
                bool cajaAbierta = d_Cierre.VerificarCajaAbiertaHoy(idCajaActual);
                if (cajaAbierta)
                {
                    FormulariosHelper.AbrirFormulario<FrmPuntoDeVenta>(formularioPrincipal);
                }
                else
                {
                    MessageBox.Show($"Debe realizar la apertura de {SesionActual.NombreCaja} para poder iniciar las ventas.", "Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    using (FrmAperturaCaja frmApertura = new FrmAperturaCaja())
                    {
                        if (frmApertura.ShowDialog() == DialogResult.OK)
                        {
                            decimal montoInicial = frmApertura.MontoInicial;
                            int idUsuarioActual = SesionActual.IdUsuario;
                            d_Cierre.RegistrarApertura(montoInicial, idUsuarioActual, idCajaActual);
                            MessageBox.Show($"{SesionActual.NombreCaja} abierta con {montoInicial:C2}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ToolStripMenuItem inventario = new ToolStripMenuItem("📦 Inventario y Medicamentos")
            {
                Font = Fuentes.MenuPrincipal
            };

            ToolStripMenuItem productos = new ToolStripMenuItem("Productos");
            productos.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmProductos>(formulario);
            inventario.DropDownItems.Add(productos);

            ToolStripMenuItem laboratorios = new ToolStripMenuItem("Laboratorios");
            laboratorios.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmLaboratorios>(formulario);
            inventario.DropDownItems.Add(laboratorios);

            ToolStripMenuItem perchas = new ToolStripMenuItem("Perchas");
            perchas.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmPerchas>(formulario);
            inventario.DropDownItems.Add(perchas);

            ToolStripMenuItem ingreso = new ToolStripMenuItem("Ingreso de productos");
            ingreso.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmIngresoXML>(formulario);
            inventario.DropDownItems.Add(ingreso);


            ToolStripMenuItem lotesVencimientos = new ToolStripMenuItem("Lotes y vencimientos");
            lotesVencimientos.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmLotesVencimientos>(formulario);
            inventario.DropDownItems.Add(lotesVencimientos);
            ToolStripMenuItem kardex = new ToolStripMenuItem("Kardex");
            kardex.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmKardex>(formulario);
            inventario.DropDownItems.Add(kardex);
            ToolStripMenuItem ajusteDeInventario = new ToolStripMenuItem("Ajustes de inventario");
            ajusteDeInventario.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmAjusteInventario>(formulario);
            inventario.DropDownItems.Add(ajusteDeInventario);
            
            ToolStripMenuItem transferencias = new ToolStripMenuItem("Transferencias entre sucursales");
            transferencias.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmTransferencias>(formulario);
            inventario.DropDownItems.Add(transferencias);
            
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
            ToolStripMenuItem compras = new ToolStripMenuItem("🛒 Compras y Proveedores")
            {
                Font = Fuentes.MenuPrincipal
            };
            ToolStripMenuItem ordenesCompra = new ToolStripMenuItem("Órdenes de compra");
            ordenesCompra.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmOrdenesCompra>(formulario);
            compras.DropDownItems.Add(ordenesCompra);
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
            ToolStripMenuItem clientes = new ToolStripMenuItem("👥 Clientes")
            {
                Font = Fuentes.MenuPrincipal
            };
            ToolStripMenuItem gestionClientes = new ToolStripMenuItem("Gestión de Clientes");
            gestionClientes.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmClientes>(formulario);
            clientes.DropDownItems.Add(gestionClientes);
            clientes.DropDownItems.Add("Historial de compras");
            clientes.DropDownItems.Add("Créditos / puntos");
            return clientes;
        }

        private static ToolStripMenuItem ConstruirMenuFinanzas(Form formulario)
        {
            ToolStripMenuItem finanzas = new ToolStripMenuItem("📊 Finanzas y Reportes")
            {
                Font = Fuentes.MenuPrincipal
            };
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
            ToolStripMenuItem normativas = new ToolStripMenuItem("🏥 Normativas")
            {
                Font = Fuentes.MenuPrincipal
            };
            normativas.DropDownItems.Add("Control psicotrópicos");
            normativas.DropDownItems.Add("ANMAT/SRI");
            return normativas;
        }

        private static ToolStripMenuItem ConstruirMenuSeguridad(Form formulario)
        {
            ToolStripMenuItem seguridad = new ToolStripMenuItem("👤 Seguridad")
            {
                Font = Fuentes.MenuPrincipal
            };
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
            ToolStripMenuItem configuracion = new ToolStripMenuItem("⚙️ Configuración")
            {
                Font = Fuentes.MenuPrincipal
            };
            ToolStripMenuItem empresa = new ToolStripMenuItem("Empresa");
            empresa.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmEmpresa>(formulario);
            configuracion.DropDownItems.Add(empresa);
            var impuestos = new ToolStripMenuItem("Impuestos");
            impuestos.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmImpuestos>(formulario);
            configuracion.DropDownItems.Add(impuestos);
            var secuencias = new ToolStripMenuItem("Secuencias");
            secuencias.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmSecuencias>(formulario);

            // Subopciones de secuencias
            var puntosEmision = new ToolStripMenuItem("Puntos de emisión");
            puntosEmision.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmPuntosEmision>(formulario);
            secuencias.DropDownItems.Add(puntosEmision);

            configuracion.DropDownItems.Add(secuencias);
            configuracion.DropDownItems.Add("Firma electrónica");
            configuracion.DropDownItems.Add("Integraciones");
            return configuracion;
        }

        private static ToolStripMenuItem ConstruirMenuSucursales(Form formulario)
        {
            ToolStripMenuItem sucursales = new ToolStripMenuItem("🏪 Sucursales")
            {
                Font = Fuentes.MenuPrincipal
            };

            ToolStripMenuItem mGestion = new ToolStripMenuItem("Gestión de Sucursales");
            mGestion.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmSucursales>(formulario);

            ToolStripMenuItem mBodegas = new ToolStripMenuItem("Gestionar Bodegas/Ubicaciones");
            mBodegas.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmUbicaciones>(formulario);

            ToolStripMenuItem mTransferencias = new ToolStripMenuItem("Transferencias internas");
            mTransferencias.Click += (s, e) => FormulariosHelper.AbrirFormulario<FrmTransferencias>(formulario);

            sucursales.DropDownItems.Add(mGestion);
            sucursales.DropDownItems.Add(mBodegas);
            sucursales.DropDownItems.Add(mTransferencias);
            return sucursales;
        }

        // === Ventanas: listado dinámico de formularios abiertos y navegación rápida ===
        private static ToolStripMenuItem ConstruirMenuVentanas(Form formulario)
        {
            var ventanas = new ToolStripMenuItem("🗂 Ventanas")
            {
                Font = Fuentes.MenuPrincipal
            };
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

        // === NAVEGADOR DE VENTANAS ===
        private static void AgregarNavegadorVentanas(MenuStrip menu, Form formulario)
        {
            // Botones de navegación con estilo profesional
            var btnPrev = new ToolStripButton("◀")
            {
                ToolTipText = "Ventana anterior (Ctrl+Shift+F6)",
                Alignment = ToolStripItemAlignment.Right,
                Font = Fuentes.MenuPrincipal,
                ForeColor = Colores.PrincipalOscuro,
                DisplayStyle = ToolStripItemDisplayStyle.Text,
                AutoSize = false,
                Width = 30
            };
            
            var ddStack = new ToolStripDropDownButton("Ventanas")
            {
                ToolTipText = "Ventanas abiertas",
                Alignment = ToolStripItemAlignment.Right,
                Font = Fuentes.Indicador,
                ForeColor = Colores.TextoSecundario,
                DisplayStyle = ToolStripItemDisplayStyle.Text,
                ShowDropDownArrow = true
            };
            
            var btnNext = new ToolStripButton("▶")
            {
                ToolTipText = "Ventana siguiente (Ctrl+F6)",
                Alignment = ToolStripItemAlignment.Right,
                Font = Fuentes.MenuPrincipal,
                ForeColor = Colores.PrincipalOscuro,
                DisplayStyle = ToolStripItemDisplayStyle.Text,
                AutoSize = false,
                Width = 30
            };

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

            // 2. AÑADIMOS LOS CONTROLES AL MENÚ PRINCIPAL
            // El orden es importante para que aparezcan correctamente alineados a la derecha.
            menu.Items.Add(btnNext);
            menu.Items.Add(ddStack);
            menu.Items.Add(btnPrev);
        }

        private static string TruncTitulo(string text, int max = 28)
        {
            if (string.IsNullOrEmpty(text)) return "Ventanas";
            return text.Length <= max ? text : text.Substring(0, max - 1) + "…";
        }

    }
}
