using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades;
using System.Globalization;
using LogiPharm.Datos;
using System.Collections.Generic;
using System.Windows.Media.TextFormatting;

namespace LogiPharm.Presentacion
{
    public partial class FrmRecepcionProductos : Form
    {
        public FrmRecepcionProductos()
        {
            InitializeComponent();
            // Conectar los eventos de los botones en el constructor o en el evento Load
            this.Load += FrmRecepcionProductos_Load;
        }

        private void FrmRecepcionProductos_Load(object sender, EventArgs e)
        {
            // Aseguramos que los eventos Click de los botones estén conectados a sus métodos
            //this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // Iniciar con la pantalla limpia
            //LimpiarPantalla();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Seleccionar Factura Electrónica (XML)";
                openFileDialog.Filter = "Archivos XML (*.xml)|*.xml";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = openFileDialog.FileName;

                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePath);

                        XmlNode cdataNode = doc.SelectSingleNode("//comprobante");
                        if (cdataNode == null)
                        {
                            throw new Exception("El archivo XML no tiene el formato de factura electrónica esperado (falta la etiqueta 'comprobante').");
                        }

                        string facturaXmlInterno = cdataNode.InnerText;

                        EFacturaCompraXml factura = XmlHelper.ParseFactura(facturaXmlInterno);

                        LlenarFormularioConDatosXML(factura);

                        MessageBox.Show("Factura XML importada con éxito.", "Importación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al procesar el archivo XML:\n" + ex.Message,
                                        "Error de Importación",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        LimpiarPantalla(); // Si hay un error, limpiar la pantalla
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Al cancelar, simplemente limpiamos la pantalla
            LimpiarPantalla();
        }

        /// <summary>
        /// Limpia todos los controles del formulario a su estado inicial.
        /// </summary>
        private void LimpiarPantalla()
        {
            // Limpiar campos de texto del encabezado
            txtClaveAcceso.Clear();
            txtProveedor.Clear();
            txtRUC.Clear();
            txtDireccion.Clear();
            txtFechaEmision.Clear();
            txtFechaAutorizacion.Clear();
            txtNumeroFactura.Clear();
            txtAutorizacion.Clear();

            // Resetear los totales a "0.00"
            txtSubtotalSinIVA.Text = "0.00";
            txtSubtotalIVA.Text = "0.00";
            txtDescuento.Text = "0.00";
            txtImpuestoIVA.Text = "0.00";
            txtSubtotal.Text = "0.00";
            txtTotal.Text = "0.00";

            // Limpiar la tabla de productos de forma segura
            dgvProductos.DataSource = null;

            // Poner el foco de nuevo en el campo principal
            txtClaveAcceso.Focus();
        }

        private void LlenarFormularioConDatosXML(EFacturaCompraXml factura)
        {
            txtClaveAcceso.Text = factura.ClaveAcceso;
            txtProveedor.Text = factura.RazonSocialProveedor;
            txtRUC.Text = factura.RucProveedor;
            txtDireccion.Text = factura.DireccionProveedor;
            txtFechaEmision.Text = factura.FechaEmision.ToString("dd/MM/yyyy");
            txtNumeroFactura.Text = factura.NumeroFactura;
            txtAutorizacion.Text = factura.ClaveAcceso;

            txtSubtotal.Text = factura.TotalSinImpuestos.ToString("N2");
            txtDescuento.Text = factura.TotalDescuento.ToString("N2");
            txtImpuestoIVA.Text = factura.ValorIVA.ToString("N2");
            txtTotal.Text = factura.ImporteTotal.ToString("N2");

            decimal subtotalConIVA = 0;
            if (factura.ValorIVA > 0)
            {
                subtotalConIVA = factura.ValorIVA / 0.15m; // Asumiendo IVA del 15%
            }
            decimal subtotalSinIVA = factura.TotalSinImpuestos - subtotalConIVA;

            txtSubtotalIVA.Text = subtotalConIVA.ToString("N2");
            txtSubtotalSinIVA.Text = subtotalSinIVA.ToString("N2");

            DataTable dtProductos = new DataTable();
            dtProductos.Columns.Add("Codigo", typeof(string));
            dtProductos.Columns.Add("Producto", typeof(string));
            dtProductos.Columns.Add("Cantidad", typeof(decimal));
            dtProductos.Columns.Add("PrecioUnitario", typeof(decimal));
            dtProductos.Columns.Add("Descuento", typeof(decimal));
            dtProductos.Columns.Add("Total", typeof(decimal));

            foreach (var detalle in factura.Detalles)
            {
                dtProductos.Rows.Add(
                    detalle.CodigoPrincipal,
                    detalle.Descripcion,
                    detalle.Cantidad,
                    detalle.PrecioUnitario,
                    detalle.Descuento,
                    detalle.PrecioTotalSinImpuesto
                );
            }

            dgvProductos.DataSource = dtProductos;
            EstilizarGrid();
        }

        private void EstilizarGrid()
        {
            if (dgvProductos.Columns.Count > 0)
            {
                dgvProductos.Columns["Producto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                string[] columnasMoneda = { "PrecioUnitario", "Descuento", "Total" };
                foreach (string colName in columnasMoneda)
                {
                    if (dgvProductos.Columns.Contains(colName))
                    {
                        var col = dgvProductos.Columns[colName];
                        col.DefaultCellStyle.Format = "N2";
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }

                if (dgvProductos.Columns.Contains("Cantidad"))
                {
                    var col = dgvProductos.Columns["Cantidad"];
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos en el detalle para guardar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAutorizacion.Text))
            {
                MessageBox.Show("No se ha cargado una factura válida (falta número de autorización).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {

                // 1. Crear el objeto de la factura con los datos de la pantalla
                EFacturaCompra factura = new EFacturaCompra
                {
                    IdUsuario = 1, // TODO: Reemplazar con el ID del usuario de la sesión
                    NumeroFactura = txtNumeroFactura.Text,
                    Autorizacion = txtAutorizacion.Text,
                    FechaRecepcion = DateTime.Now,
                    Subtotal = decimal.Parse(txtSubtotal.Text, CultureInfo.InvariantCulture),
                    Descuento = decimal.Parse(txtDescuento.Text, CultureInfo.InvariantCulture),
                    Iva = decimal.Parse(txtImpuestoIVA.Text, CultureInfo.InvariantCulture),
                    Total = decimal.Parse(txtTotal.Text, CultureInfo.InvariantCulture),

                    RucProveedor = txtRUC.Text,
                    RazonSocialProveedor = txtProveedor.Text,
                    DireccionProveedor = txtDireccion.Text,
                    Detalles = new List<EFacturaCompraDetalle>()
                };

                // 2. Llenar el detalle de la factura desde el DataGridView
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    // Lógica para mapear el producto
                    string codigoProveedor = row.Cells["Codigo"].Value.ToString();
                    string nombreProducto = row.Cells["Producto"].Value?.ToString() ?? "";
                    DProductos d_productos = new DProductos();
                    EProducto productoInterno = d_productos.BuscarProductoPorCodigoONombre(codigoProveedor);

                    if (productoInterno == null)
                    {
                        productoInterno = new EProducto
                        {
                            Id = 0, // Esto permitirá que se cree en la capa de datos
                            CodigoPrincipal = codigoProveedor,
                            Nombre = nombreProducto
                        };
                    }

                    if (productoInterno == null)
                    {
                        // Si no se encuentra, abrir el formulario de selección
                        MessageBox.Show($"El producto con código '{codigoProveedor}' no se encuentra en su catálogo. Por favor, selecciónelo para mapearlo.");
                        using (var frmSeleccionar = new FrmSeleccionarProducto())
                        {
                            if (frmSeleccionar.ShowDialog() == DialogResult.OK)
                            {
                                productoInterno = frmSeleccionar.ProductoSeleccionado;
                            }
                            else
                            {
                                throw new Exception("Se canceló el mapeo de productos. No se puede guardar la factura.");
                            }
                        }
                    }

                    factura.Detalles.Add(new EFacturaCompraDetalle
                    {
                        IdProducto = (int)productoInterno.Id,
                        CodigoProducto = codigoProveedor,
                        NombreProducto = nombreProducto,
                        Cantidad = Convert.ToDecimal(row.Cells["Cantidad"].Value),
                        CostoUnitario = Convert.ToDecimal(row.Cells["PrecioUnitario"].Value),
                        Total = Convert.ToDecimal(row.Cells["Total"].Value)
                    });
                }

                // 3. Llamar a la capa de datos para guardar todo en una transacción
                DRecepcionProductos dRecepcion = new DRecepcionProductos();
                if (dRecepcion.GuardarRecepcion(factura))
                {
                    MessageBox.Show("Factura de compra guardada y stock actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarPantalla();
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al guardar la recepción:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta función es para cargar datos de prueba. Use el botón 'Importar' para cargar una factura real.", "Aviso");
        }
    }
}
