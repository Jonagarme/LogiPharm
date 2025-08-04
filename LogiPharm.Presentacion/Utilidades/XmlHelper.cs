using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Xml;
using LogiPharm.Entidades;

namespace LogiPharm.Presentacion.Utilidades
{
    public static class XmlHelper
    {
        public static EFacturaCompraXml ParseFactura(string xmlContent)
        {
            var factura = new EFacturaCompraXml();
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlContent);

            // --- Extraer datos de infoTributaria ---
            var infoTributaria = xmlDoc.SelectSingleNode("//infoTributaria");
            if (infoTributaria != null)
            {
                factura.RucProveedor = infoTributaria.SelectSingleNode("ruc")?.InnerText;
                factura.RazonSocialProveedor = infoTributaria.SelectSingleNode("razonSocial")?.InnerText;
                factura.DireccionProveedor = infoTributaria.SelectSingleNode("dirMatriz")?.InnerText;
                factura.ClaveAcceso = infoTributaria.SelectSingleNode("claveAcceso")?.InnerText;
                string estab = infoTributaria.SelectSingleNode("estab")?.InnerText;
                string ptoEmi = infoTributaria.SelectSingleNode("ptoEmi")?.InnerText;
                string secuencial = infoTributaria.SelectSingleNode("secuencial")?.InnerText;
                factura.NumeroFactura = $"{estab}-{ptoEmi}-{secuencial}";
            }

            // --- Extraer datos de infoFactura ---
            var infoFactura = xmlDoc.SelectSingleNode("//infoFactura");
            if (infoFactura != null)
            {
                factura.FechaEmision = DateTime.ParseExact(infoFactura.SelectSingleNode("fechaEmision")?.InnerText, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                factura.TotalSinImpuestos = Convert.ToDecimal(infoFactura.SelectSingleNode("totalSinImpuestos")?.InnerText, CultureInfo.InvariantCulture);
                factura.TotalDescuento = Convert.ToDecimal(infoFactura.SelectSingleNode("totalDescuento")?.InnerText, CultureInfo.InvariantCulture);
                factura.ImporteTotal = Convert.ToDecimal(infoFactura.SelectSingleNode("importeTotal")?.InnerText, CultureInfo.InvariantCulture);
            }

            // --- Extraer el valor del IVA ---
            var totalImpuesto = xmlDoc.SelectSingleNode("//totalImpuesto[codigo='2']"); // 2 es el código para IVA
            if (totalImpuesto != null)
            {
                factura.ValorIVA = Convert.ToDecimal(totalImpuesto.SelectSingleNode("valor")?.InnerText, CultureInfo.InvariantCulture);
            }

            // --- Extraer detalles de productos ---
            var detalles = xmlDoc.SelectNodes("//detalles/detalle");
            foreach (XmlNode detalleNode in detalles)
            {
                var detalle = new EFacturaDetalleXml
                {
                    CodigoPrincipal = detalleNode.SelectSingleNode("codigoPrincipal")?.InnerText,
                    Descripcion = detalleNode.SelectSingleNode("descripcion")?.InnerText,
                    Cantidad = Convert.ToDecimal(detalleNode.SelectSingleNode("cantidad")?.InnerText, CultureInfo.InvariantCulture),
                    PrecioUnitario = Convert.ToDecimal(detalleNode.SelectSingleNode("precioUnitario")?.InnerText, CultureInfo.InvariantCulture),
                    Descuento = Convert.ToDecimal(detalleNode.SelectSingleNode("descuento")?.InnerText, CultureInfo.InvariantCulture),
                    PrecioTotalSinImpuesto = Convert.ToDecimal(detalleNode.SelectSingleNode("precioTotalSinImpuesto")?.InnerText, CultureInfo.InvariantCulture)
                };
                factura.Detalles.Add(detalle);
            }

            return factura;
        }
    }
}
