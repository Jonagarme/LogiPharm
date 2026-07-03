using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using MySqlConnector;
using LogiPharm.Datos;
using LogiPharm.Presentacion.Utilidades;

namespace LogiPharm.Presentacion
{
    public partial class FrmBarcodeGenerator : Form
    {
        private long idProductoSeleccionado = 0;
        private string codigoProducto = "";
        private string nombreProducto = "";
        private decimal precioProducto = 0m;
        private Bitmap barcodeBitmap = null;

        public FrmBarcodeGenerator()
        {
            InitializeComponent();
            this.Load += FrmBarcodeGenerator_Load;
        }

        private void FrmBarcodeGenerator_Load(object sender, EventArgs e)
        {
            try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Inventario", "VISUALIZAR", "codigo_barras", null, "Abrir Generador de Códigos de Barras", null, Environment.MachineName, "UI"); } catch { }

            EstilosHelper.EstilizarFormulario(this);

            // Eventos
            btnBuscarProducto.Click += BtnBuscarProducto_Click;
            btnGenerar.Click += BtnGenerar_Click;
            btnPrint.Click += BtnPrint_Click;
        }

        private void BtnBuscarProducto_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmSeleccionarProducto())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idProductoSeleccionado = frm.ProductoSeleccionado.Id;
                    codigoProducto = frm.ProductoSeleccionado.CodigoPrincipal;
                    nombreProducto = frm.ProductoSeleccionado.Nombre;
                    precioProducto = frm.ProductoSeleccionado.PrecioVenta;

                    txtProducto.Text = $"{codigoProducto} - {nombreProducto} (${precioProducto:N2})";
                    txtCodigo.Text = codigoProducto;
                    
                    GenerarBarcode();
                }
            }
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Por favor, ingrese o busque un código para generar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            codigoProducto = txtCodigo.Text.Trim();
            GenerarBarcode();
        }

        private void GenerarBarcode()
        {
            try
            {
                string code = txtCodigo.Text.Trim().ToUpper();
                if (string.IsNullOrEmpty(code)) return;

                // Dibujar el código de barras usando nuestro generador nativo Code 39
                barcodeBitmap = GenerarImagenCode39(code, 400, 120);
                pbBarcode.Image = barcodeBitmap;

                btnPrint.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar código de barras: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================
        // DIBUJADO NATIVO CODE 39
        // ======================
        private static readonly System.Collections.Generic.Dictionary<char, string> Code39Map = new System.Collections.Generic.Dictionary<char, string>
        {
            {'0', "000110100"}, {'1', "100100001"}, {'2', "001100001"}, {'3', "101100000"},
            {'4', "000110001"}, {'5', "100110000"}, {'6', "001110000"}, {'7', "000100101"},
            {'8', "100100100"}, {'9', "001100100"}, {'A', "100001001"}, {'B', "001001001"},
            {'C', "101001000"}, {'D', "000011001"}, {'E', "100011000"}, {'F', "001011000"},
            {'G', "000001101"}, {'H', "100001100"}, {'I', "001001100"}, {'J', "000011100"},
            {'K', "100000011"}, {'L', "001000011"}, {'M', "101000010"}, {'N', "000010011"},
            {'O', "100010010"}, {'P', "001010010"}, {'Q', "000000111"}, {'R', "100000110"},
            {'S', "001000110"}, {'T', "000010110"}, {'U', "110000001"}, {'V', "011000001"},
            {'W', "111000000"}, {'X', "010010001"}, {'Y', "110010000"}, {'Z', "011010000"},
            {'-', "010000101"}, {'.', "110000100"}, {' ', "011000100"}, {'*', "010010100"},
            {'$', "010101000"}, {'/', "010100010"}, {'+', "010001010"}, {'%', "000101010"}
        };

        private Bitmap GenerarImagenCode39(string text, int width, int height)
        {
            // Ajustar texto agregando asteriscos de inicio/fin si no están presentes
            string formattedText = text;
            if (!formattedText.StartsWith("*")) formattedText = "*" + formattedText;
            if (!formattedText.EndsWith("*")) formattedText = formattedText + "*";

            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                // Calcular ancho de barras
                // Contar número total de elementos a dibujar
                // Cada carácter tiene 9 elementos (5 barras, 4 espacios).
                // Entre carácteres hay un espacio angosto.
                int charCount = formattedText.Length;
                int totalElements = (charCount * 9) + (charCount - 1);

                // Asignar grosores
                float x = 20; // Margen inicial
                float narrowWidth = (width - 40f) / (totalElements * 1.3f);
                if (narrowWidth < 1f) narrowWidth = 1f;
                float wideWidth = narrowWidth * 2.5f;

                for (int i = 0; i < charCount; i++)
                {
                    char c = formattedText[i];
                    if (!Code39Map.ContainsKey(c)) continue;

                    string pattern = Code39Map[c];

                    // Dibujar el patrón del carácter
                    for (int j = 0; j < 9; j++)
                    {
                        bool isBar = (j % 2 == 0);
                        bool isWide = (pattern[j] == '1');
                        float w = isWide ? wideWidth : narrowWidth;

                        if (isBar)
                        {
                            using (Brush b = new SolidBrush(Color.Black))
                            {
                                g.FillRectangle(b, x, 10, w, height - 35);
                            }
                        }
                        x += w;
                    }

                    // Espacio intercaracter (angosto)
                    x += narrowWidth;
                }

                // Dibujar texto human-readable debajo del código
                using (Font font = new Font("Arial", 10, FontStyle.Bold))
                using (Brush brush = new SolidBrush(Color.Black))
                {
                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Far
                    };
                    g.DrawString(text, font, brush, new RectangleF(0, 0, width, height - 5), sf);
                }
            }

            return bmp;
        }

        // ======================
        // LOGICA DE IMPRESION
        // ======================
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (barcodeBitmap == null) return;

            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Etiqueta LogiPharm - " + codigoProducto;
            printDoc.PrintPage += PrintDoc_PrintPage;
            printDlg.Document = printDoc;

            if (printDlg.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
                try { new DBitacora().Registrar(SesionActual.IdUsuario, SesionActual.NombreUsuario, "Inventario", "IMPRIMIR", "codigo_barras", idProductoSeleccionado, $"Imprimir código de barras para producto {nombreProducto}", null, Environment.MachineName, "UI"); } catch { }
            }
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Dibujar la etiqueta: Nombre de empresa, nombre de producto, código de barras y precio
            Graphics g = e.Graphics;
            Font fontEmpresa = new Font("Segoe UI", 8, FontStyle.Bold);
            Font fontProducto = new Font("Segoe UI", 10, FontStyle.Regular);
            Font fontPrecio = new Font("Segoe UI", 12, FontStyle.Bold);

            // Dibujar textos
            g.DrawString("LOGIPHARM SYSTEM", fontEmpresa, Brushes.Black, 20, 20);
            
            string nameToDraw = string.IsNullOrEmpty(nombreProducto) ? "Código Genérico" : nombreProducto;
            if (nameToDraw.Length > 28) nameToDraw = nameToDraw.Substring(0, 26) + "...";
            g.DrawString(nameToDraw, fontProducto, Brushes.Black, 20, 35);

            // Dibujar imagen del código de barras (escala reducida para etiqueta de góndola)
            if (barcodeBitmap != null)
            {
                g.DrawImage(barcodeBitmap, 20, 55, 200, 60);
            }

            // Dibujar precio
            string precioText = precioProducto > 0 ? $"P.V.P: ${precioProducto:N2}" : "";
            g.DrawString(precioText, fontPrecio, Brushes.Black, 20, 120);

            e.HasMorePages = false;
        }
    }
}
