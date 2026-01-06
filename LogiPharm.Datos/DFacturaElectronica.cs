using System;
using System.Globalization;
using System.Xml;
using System.Linq;
using LogiPharm.Entidades;

namespace LogiPharm.Datos
{
    public class DFacturaElectronica
    {
        public EFacturaElectronica ParsearXML(string rutaArchivoOContenido)
        {
            var factura = new EFacturaElectronica();
            XmlDocument doc = new XmlDocument();

            try
            {
                // Detectar si es ruta o contenido XML
                if (rutaArchivoOContenido.TrimStart().StartsWith("<"))
                {
                    doc.LoadXml(rutaArchivoOContenido);
                }
                else
                {
                    doc.Load(rutaArchivoOContenido);
                }

                // Verificar si el XML viene envuelto en una estructura de autorización del SRI
                XmlNode autorizacionNode = doc.SelectSingleNode("//autorizacion");
                if (autorizacionNode != null)
                {
                    // Extraer el comprobante del CDATA
                    XmlNode comprobanteNode = autorizacionNode.SelectSingleNode("comprobante");
                    if (comprobanteNode != null && !string.IsNullOrWhiteSpace(comprobanteNode.InnerText))
                    {
                        // El contenido está en CDATA, necesitamos parsearlo
                        string xmlComprobante = comprobanteNode.InnerText;
                        doc = new XmlDocument();
                        doc.LoadXml(xmlComprobante);
                    }
                }

                // Parsear Info Tributaria
                XmlNode infoTrib = doc.SelectSingleNode("//infoTributaria");
                if (infoTrib != null)
                {
                    factura.ClaveAcceso = GetNodeValue(infoTrib, "claveAcceso");
                    factura.Ambiente = GetNodeValue(infoTrib, "ambiente");
                    factura.TipoEmision = GetNodeValue(infoTrib, "tipoEmision");
                    factura.RazonSocialEmisor = GetNodeValue(infoTrib, "razonSocial");
                    factura.NombreComercialEmisor = GetNodeValue(infoTrib, "nombreComercial");
                    factura.RucEmisor = GetNodeValue(infoTrib, "ruc");
                    factura.Establecimiento = GetNodeValue(infoTrib, "estab");
                    factura.PuntoEmision = GetNodeValue(infoTrib, "ptoEmi");
                    factura.Secuencial = GetNodeValue(infoTrib, "secuencial");
                    factura.DireccionMatriz = GetNodeValue(infoTrib, "dirMatriz");
                }

                // Parsear Info Factura
                XmlNode infoFact = doc.SelectSingleNode("//infoFactura");
                if (infoFact != null)
                {
                    string fechaStr = GetNodeValue(infoFact, "fechaEmision");
                    factura.FechaEmision = ParsearFecha(fechaStr);

                    factura.RazonSocialComprador = GetNodeValue(infoFact, "razonSocialComprador");
                    factura.IdentificacionComprador = GetNodeValue(infoFact, "identificacionComprador");
                    factura.DireccionComprador = GetNodeValue(infoFact, "direccionComprador");

                    factura.TotalSinImpuestos = ParseDecimal(GetNodeValue(infoFact, "totalSinImpuestos"));
                    factura.TotalDescuento = ParseDecimal(GetNodeValue(infoFact, "totalDescuento"));
                    factura.ImporteTotal = ParseDecimal(GetNodeValue(infoFact, "importeTotal"));

                    // Impuestos
                    XmlNode totalImpuesto = infoFact.SelectSingleNode("totalConImpuestos/totalImpuesto");
                    if (totalImpuesto != null)
                    {
                        factura.TotalImpuestos = ParseDecimal(GetNodeValue(totalImpuesto, "valor"));
                    }
                }

                // Parsear Detalles
                XmlNodeList detalles = doc.SelectNodes("//detalles/detalle");
                if (detalles != null)
                {
                    foreach (XmlNode detalle in detalles)
                    {
                        var det = new EDetalleFacturaXML
                        {
                            CodigoPrincipal = GetNodeValue(detalle, "codigoPrincipal"),
                            Descripcion = GetNodeValue(detalle, "descripcion"),
                            Cantidad = ParseDecimal(GetNodeValue(detalle, "cantidad")),
                            PrecioUnitario = ParseDecimal(GetNodeValue(detalle, "precioUnitario")),
                            Descuento = ParseDecimal(GetNodeValue(detalle, "descuento")),
                            PrecioTotalSinImpuesto = ParseDecimal(GetNodeValue(detalle, "precioTotalSinImpuesto")),
                            EsProductoNuevo = true // por defecto, luego se busca
                        };

                        // Impuesto del detalle
                        XmlNode impuesto = detalle.SelectSingleNode("impuestos/impuesto");
                        if (impuesto != null)
                        {
                            det.ValorImpuesto = ParseDecimal(GetNodeValue(impuesto, "valor"));
                            det.Tarifa = ParseDecimal(GetNodeValue(impuesto, "tarifa"));
                        }

                        factura.Detalles.Add(det);
                    }
                }

                return factura;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al parsear XML: " + ex.Message, ex);
            }
        }

        public EFacturaElectronica ConsultarPorClaveAcceso(string claveAcceso)
        {
            // TODO: Implementar consulta al SRI o servicio externo
            // Por ahora retorna null, deberías integrarlo con tu proveedor de servicios
            throw new NotImplementedException("La consulta por clave de acceso requiere integración con el SRI o proveedor de servicios.");
        }

        public void BuscarProductosExistentes(EFacturaElectronica factura)
        {
            var dProd = new DProductos();
            foreach (var detalle in factura.Detalles)
            {
                bool encontradoExacto = false;
                
                // Intentar buscar por código exacto
                var productos = dProd.BuscarProductosActivos(detalle.CodigoPrincipal);
                if (productos != null && productos.Count == 1)
                {
                    // Solo si hay UNA coincidencia exacta
                    detalle.IdProductoEncontrado = (int)productos[0].Id;
                    detalle.NombreProductoEncontrado = productos[0].Nombre;
                    detalle.EsProductoNuevo = false;
                    encontradoExacto = true;
                }
                else if (productos != null && productos.Count == 0)
                {
                    // Intentar por nombre/descripción exacta
                    productos = dProd.BuscarProductosActivos(detalle.Descripcion);
                    if (productos != null && productos.Count == 1)
                    {
                        detalle.IdProductoEncontrado = (int)productos[0].Id;
                        detalle.NombreProductoEncontrado = productos[0].Nombre;
                        detalle.EsProductoNuevo = false;
                        encontradoExacto = true;
                    }
                }
                
                // Si no se encontró exacto O hay múltiples coincidencias, buscar similares
                if (!encontradoExacto || (productos != null && productos.Count > 1))
                {
                    detalle.EsProductoNuevo = true;
                    BuscarProductosSimilares(detalle, dProd);
                }
            }
        }

        /// <summary>
        /// Busca productos similares para un detalle de factura XML
        /// </summary>
        private void BuscarProductosSimilares(EDetalleFacturaXML detalle, DProductos dProd)
        {
            // Buscar primero por código con umbral más bajo (40%)
            var similaresPorCodigo = dProd.BuscarProductosSimilares(detalle.CodigoPrincipal, umbralSimilitud: 40.0, maxResultados: 10);
            
            // Buscar por nombre/descripción con umbral más bajo (40%)
            var similaresPorNombre = dProd.BuscarProductosSimilares(detalle.Descripcion, umbralSimilitud: 40.0, maxResultados: 10);

            // Combinar resultados y eliminar duplicados
            var todosSimilares = similaresPorCodigo.Concat(similaresPorNombre)
                .GroupBy(p => p.Id)
                .Select(g => g.OrderByDescending(p => p.PorcentajeSimilitud).First())
                .OrderByDescending(p => p.PorcentajeSimilitud)
                .Take(10)
                .ToList();

            // Convertir a ProductoSimilarDetectado
            detalle.ProductosSimilares = todosSimilares.Select(ps => new ProductoSimilarDetectado
            {
                Id = ps.Id,
                CodigoPrincipal = ps.CodigoPrincipal,
                Nombre = ps.Nombre,
                Stock = ps.Stock,
                PrecioVenta = ps.PrecioVenta,
                PorcentajeSimilitud = ps.PorcentajeSimilitud
            }).ToList();
        }

        private string GetNodeValue(XmlNode parent, string nodeName)
        {
            var node = parent.SelectSingleNode(nodeName);
            return node?.InnerText ?? string.Empty;
        }

        private decimal ParseDecimal(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor)) return 0;
            valor = valor.Replace(",", ".");
            if (decimal.TryParse(valor, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
                return result;
            return 0;
        }

        private DateTime ParsearFecha(string fecha)
        {
            if (string.IsNullOrWhiteSpace(fecha)) return DateTime.Now;
            
            // Intentar formato dd/MM/yyyy
            if (DateTime.TryParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                return result;
            
            // Otros formatos
            if (DateTime.TryParse(fecha, out result))
                return result;

            return DateTime.Now;
        }
    }
}
