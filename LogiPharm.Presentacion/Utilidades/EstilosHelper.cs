using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LogiPharm.Presentacion.Utilidades
{
    /// <summary>
    /// Clase de utilidades para mantener consistencia visual en toda la aplicación.
    /// Proporciona paleta de colores, fuentes y métodos de estilizado reutilizables.
    /// </summary>
    public static class EstilosHelper
    {
        // === PALETA DE COLORES PROFESIONAL ===
        public static class Colores
        {
            // Color principal - Azul profesional
            public static readonly Color PrincipalOscuro = Color.FromArgb(41, 98, 255);
            public static readonly Color PrincipalClaro = Color.FromArgb(56, 116, 255);
            public static readonly Color PrincipalMuyClaro = Color.FromArgb(214, 228, 255);
            
            // Color de fondo
            public static readonly Color FondoPrimario = Color.White;
            public static readonly Color FondoSecundario = Color.FromArgb(248, 249, 250);
            public static readonly Color FondoTerciario = Color.FromArgb(242, 245, 250);
            public static readonly Color FondoHover = Color.FromArgb(230, 236, 245);
            public static readonly Color FondoSeleccionado = Color.FromArgb(214, 228, 255);
            
            // Texto
            public static readonly Color TextoPrincipal = Color.FromArgb(33, 37, 41);
            public static readonly Color TextoSecundario = Color.FromArgb(108, 117, 125);
            public static readonly Color TextoTerciario = Color.FromArgb(173, 181, 189);
            public static readonly Color TextoBlanco = Color.White;
            
            // Bordes
            public static readonly Color Borde = Color.FromArgb(222, 226, 230);
            public static readonly Color BordeSuave = Color.FromArgb(233, 236, 239);
            public static readonly Color BordeSombra = Color.FromArgb(206, 212, 218);
            
            // Estados
            public static readonly Color Exito = Color.FromArgb(40, 167, 69);
            public static readonly Color ExitoClaro = Color.FromArgb(212, 237, 218);
            public static readonly Color Advertencia = Color.FromArgb(255, 193, 7);
            public static readonly Color AdvertenciaClaro = Color.FromArgb(255, 243, 205);
            public static readonly Color Peligro = Color.FromArgb(220, 53, 69);
            public static readonly Color PeligroClaro = Color.FromArgb(248, 215, 218);
            public static readonly Color Info = Color.FromArgb(23, 162, 184);
            public static readonly Color InfoClaro = Color.FromArgb(209, 236, 241);
            
            // DataGridView
            public static readonly Color GridHeaderFondo = Color.FromArgb(248, 249, 250);
            public static readonly Color GridHeaderTexto = Color.FromArgb(73, 80, 87);
            public static readonly Color GridFilaAlterna = Color.FromArgb(252, 253, 254);
            public static readonly Color GridSeleccion = Color.FromArgb(214, 228, 255);
        }
        
        // === FUENTES ===
        public static class Fuentes
        {
            // Fuentes generales
            public static readonly Font TituloGrande = new Font("Segoe UI", 16F, FontStyle.Bold);
            public static readonly Font Titulo = new Font("Segoe UI", 14F, FontStyle.Bold);
            public static readonly Font SubTitulo = new Font("Segoe UI", 12F, FontStyle.Bold);
            public static readonly Font TextoNormal = new Font("Segoe UI", 10F, FontStyle.Regular);
            public static readonly Font TextoNormalBold = new Font("Segoe UI", 10F, FontStyle.Bold);
            public static readonly Font TextoPequeño = new Font("Segoe UI", 9F, FontStyle.Regular);
            public static readonly Font TextoPequeñoBold = new Font("Segoe UI", 9F, FontStyle.Bold);
            public static readonly Font TextoMuyPequeño = new Font("Segoe UI", 8F, FontStyle.Regular);
            
            // Fuentes para números (totales, precios)
            public static readonly Font NumeroGrande = new Font("Segoe UI", 24F, FontStyle.Bold);
            public static readonly Font NumeroMediano = new Font("Segoe UI", 18F, FontStyle.Bold);
            public static readonly Font NumeroPequeño = new Font("Segoe UI", 14F, FontStyle.Bold);
        }
        
        // === MÉTODOS DE ESTILIZADO ===
        
        /// <summary>
        /// Aplica estilo profesional a un DataGridView
        /// </summary>
        public static void EstilizarDataGridView(DataGridView dgv, bool mostrarFilasAlternas = true)
        {
            // Configuración general
            dgv.EnableHeadersVisualStyles = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.BackgroundColor = Colores.FondoPrimario;
            dgv.GridColor = Colores.BordeSuave;
            
            // Estilo del header
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Colores.GridHeaderFondo;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Colores.GridHeaderTexto;
            dgv.ColumnHeadersDefaultCellStyle.Font = Fuentes.TextoPequeñoBold;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Colores.GridHeaderFondo;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 8, 10, 8);
            dgv.ColumnHeadersHeight = 45;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            
            // Estilo de celdas
            dgv.DefaultCellStyle.BackColor = Colores.FondoPrimario;
            dgv.DefaultCellStyle.ForeColor = Colores.TextoPrincipal;
            dgv.DefaultCellStyle.Font = Fuentes.TextoPequeño;
            dgv.DefaultCellStyle.SelectionBackColor = Colores.GridSeleccion;
            dgv.DefaultCellStyle.SelectionForeColor = Colores.TextoPrincipal;
            dgv.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            dgv.RowTemplate.Height = 40;
            
            // Filas alternas
            if (mostrarFilasAlternas)
            {
                dgv.AlternatingRowsDefaultCellStyle.BackColor = Colores.GridFilaAlterna;
            }
        }
        
        /// <summary>
        /// Aplica estilo a un panel de totales (para punto de venta)
        /// </summary>
        public static void EstilizarPanelTotal(Panel panel, bool esDestacado = false)
        {
            panel.BackColor = esDestacado ? Colores.PrincipalOscuro : Colores.FondoSecundario;
            panel.ForeColor = esDestacado ? Colores.TextoBlanco : Colores.TextoPrincipal;
        }
        
        /// <summary>
        /// Crea un borde redondeado para un control
        /// </summary>
        public static GraphicsPath CrearBordeRedondeado(Rectangle rect, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            int diametro = radio * 2;
            
            path.AddArc(rect.X, rect.Y, diametro, diametro, 180, 90);
            path.AddArc(rect.Right - diametro, rect.Y, diametro, diametro, 270, 90);
            path.AddArc(rect.Right - diametro, rect.Bottom - diametro, diametro, diametro, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diametro, diametro, diametro, 90, 90);
            path.CloseFigure();
            
            return path;
        }
        
        /// <summary>
        /// Dibuja un botón personalizado con bordes redondeados
        /// </summary>
        public static void DibujarBotonRedondeado(Graphics g, Rectangle rect, string texto, Font fuente, 
            Color colorFondo, Color colorTexto, int radio = 8, bool esHover = false)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            
            Color fondoFinal = esHover ? ControlPaint.Light(colorFondo, 0.1f) : colorFondo;
            
            using (GraphicsPath path = CrearBordeRedondeado(rect, radio))
            using (SolidBrush brushFondo = new SolidBrush(fondoFinal))
            using (SolidBrush brushTexto = new SolidBrush(colorTexto))
            using (Pen pen = new Pen(ControlPaint.Dark(fondoFinal, 0.1f), 1))
            {
                g.FillPath(brushFondo, path);
                g.DrawPath(pen, path);
                
                // Dibujar texto centrado
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString(texto, fuente, brushTexto, rect, sf);
            }
        }
        
        /// <summary>
        /// Crea un efecto de sombra suave
        /// </summary>
        public static void DibujarSombra(Graphics g, Rectangle rect, int grosor = 5)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            
            for (int i = 0; i < grosor; i++)
            {
                int alpha = (int)(30 * (1 - (float)i / grosor));
                using (Pen pen = new Pen(Color.FromArgb(alpha, Color.Black)))
                {
                    Rectangle shadowRect = new Rectangle(
                        rect.X + i,
                        rect.Y + i,
                        rect.Width - i * 2,
                        rect.Height - i * 2
                    );
                    g.DrawRectangle(pen, shadowRect);
                }
            }
        }
        
        /// <summary>
        /// Formatea un valor decimal como moneda
        /// </summary>
        public static string FormatearMoneda(decimal valor)
        {
            return valor.ToString("C2");
        }
        
        /// <summary>
        /// Formatea un número con separadores de miles
        /// </summary>
        public static string FormatearNumero(decimal valor, int decimales = 2)
        {
            return valor.ToString($"N{decimales}");
        }
        
        /// <summary>
        /// Obtiene un color según el estado (para badges, indicadores, etc.)
        /// </summary>
        public static Color ObtenerColorEstado(string estado)
        {
            switch (estado?.ToUpper())
            {
                case "ACTIVO":
                case "ABIERTA":
                case "APROBADO":
                case "COMPLETADO":
                case "EXITO":
                    return Colores.Exito;
                    
                case "PENDIENTE":
                case "EN_PROCESO":
                case "ADVERTENCIA":
                    return Colores.Advertencia;
                    
                case "INACTIVO":
                case "CERRADA":
                case "CANCELADO":
                case "ERROR":
                case "RECHAZADO":
                    return Colores.Peligro;
                    
                case "INFO":
                case "INFORMACION":
                    return Colores.Info;
                    
                default:
                    return Colores.TextoSecundario;
            }
        }
        
        /// <summary>
        /// Aplica efecto hover a un control
        /// </summary>
        public static void AplicarEfectoHover(Control control, Color colorNormal, Color colorHover)
        {
            control.MouseEnter += (s, e) => control.BackColor = colorHover;
            control.MouseLeave += (s, e) => control.BackColor = colorNormal;
        }
        
        /// <summary>
        /// Crea un label de badge (etiqueta de estado)
        /// </summary>
        public static Label CrearBadge(string texto, string estado = "INFO")
        {
            Color colorFondo = ObtenerColorEstado(estado);
            Color colorTexto = Colores.TextoBlanco;
            
            Label badge = new Label
            {
                Text = texto,
                Font = Fuentes.TextoMuyPequeño,
                BackColor = colorFondo,
                ForeColor = colorTexto,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(8, 4, 8, 4),
                Height = 22
            };
            
            // Aplicar bordes redondeados (esto requeriría un custom control o paint event)
            // Por simplicidad, aquí solo configuramos los colores
            
            return badge;
        }
        
        /// <summary>
        /// Aplica animación de fade in a un control
        /// </summary>
        public static async System.Threading.Tasks.Task AnimarFadeIn(Control control, int duracionMs = 300)
        {
            control.Visible = true;
            int pasos = 10;
            int delay = duracionMs / pasos;
            
            for (int i = 0; i <= pasos; i++)
            {
                double opacity = (double)i / pasos;
                // Nota: Opacity solo funciona en Form, para controles necesitarías un enfoque diferente
                await System.Threading.Tasks.Task.Delay(delay);
            }
        }
        
        /// <summary>
        /// Aplica estilo profesional a un formulario
        /// </summary>
        public static void EstilizarFormulario(Form form, bool maximizado = false)
        {
            form.BackColor = Colores.FondoSecundario;
            form.Font = Fuentes.TextoNormal;
            form.StartPosition = FormStartPosition.CenterScreen;
            
            if (maximizado)
            {
                form.WindowState = FormWindowState.Maximized;
            }
        }
        
        /// <summary>
        /// Crea un separador visual
        /// </summary>
        public static Panel CrearSeparador(int altura = 1, DockStyle dock = DockStyle.Top)
        {
            return new Panel
            {
                Height = altura,
                Dock = dock,
                BackColor = Colores.Borde
            };
        }
        
        /// <summary>
        /// Aplica estilo a un TextBox para búsqueda
        /// </summary>
        public static void EstilizarTextBoxBusqueda(TextBox txt)
        {
            txt.Font = Fuentes.TextoNormal;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Height = 32;
        }
        
        /// <summary>
        /// Muestra un mensaje toast personalizado
        /// </summary>
        public static void MostrarToast(Form parent, string mensaje, string tipo = "INFO", int duracionMs = 3000)
        {
            Color colorFondo = ObtenerColorEstado(tipo);
            
            Form toast = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.Manual,
                Size = new Size(300, 80),
                BackColor = colorFondo,
                ShowInTaskbar = false,
                TopMost = true
            };
            
            Label lblMensaje = new Label
            {
                Text = mensaje,
                ForeColor = Colores.TextoBlanco,
                Font = Fuentes.TextoNormal,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(10)
            };
            
            toast.Controls.Add(lblMensaje);
            
            // Posicionar en la esquina inferior derecha del formulario padre
            if (parent != null)
            {
                toast.Location = new Point(
                    parent.Right - toast.Width - 20,
                    parent.Bottom - toast.Height - 20
                );
            }
            
            toast.Show();
            
            // Auto-cerrar después de la duración
            Timer timer = new Timer { Interval = duracionMs };
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                toast.Close();
                timer.Dispose();
            };
            timer.Start();
        }
    }
}
