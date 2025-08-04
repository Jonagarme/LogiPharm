using System;
using System.Collections.Generic;

namespace LogiPharm.Entidades
{
    /// <summary>
    /// Representa los datos extraídos de una factura electrónica en formato XML.
    /// </summary>
    public class EFacturaCompraXml
    {
        // Datos del Proveedor (Emisor)
        public string RucProveedor { get; set; }
        public string RazonSocialProveedor { get; set; }
        public string DireccionProveedor { get; set; }

        // Datos de la Factura
        public string NumeroFactura { get; set; }
        public string ClaveAcceso { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaAutorizacion { get; set; }

        // Totales de la Factura
        public decimal TotalSinImpuestos { get; set; }
        public decimal TotalDescuento { get; set; }
        public decimal ValorIVA { get; set; }
        public decimal ImporteTotal { get; set; }

        // Detalle de productos
        public List<EFacturaDetalleXml> Detalles { get; set; }

        public EFacturaCompraXml()
        {
            Detalles = new List<EFacturaDetalleXml>();
        }
    }

    /// <summary>
    /// Representa un item (producto) dentro del detalle de la factura XML.
    /// </summary>
    public class EFacturaDetalleXml
    {
        public string CodigoPrincipal { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Descuento { get; set; }
        public decimal PrecioTotalSinImpuesto { get; set; }
    }
}
