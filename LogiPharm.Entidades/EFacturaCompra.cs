using System;
using System.Collections.Generic;

namespace LogiPharm.Entidades
{
    public class EFacturaCompra
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }
        public int IdUsuario { get; set; }
        public string NumeroFactura { get; set; }
        public string Autorizacion { get; set; } // Clave de acceso del XML
        public DateTime FechaRecepcion { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public string RucProveedor { get; set; }
        public string RazonSocialProveedor { get; set; }
        public string DireccionProveedor { get; set; }
        public List<EFacturaCompraDetalle> Detalles { get; set; }

        public EFacturaCompra()
        {
            Detalles = new List<EFacturaCompraDetalle>();
        }
    }

    public class EFacturaCompraDetalle
    {
        public int IdProducto { get; set; } // ID interno del producto en el sistema
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }

        public decimal Cantidad { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal Total { get; set; }
    }
}
