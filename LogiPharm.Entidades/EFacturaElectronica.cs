using System;
using System.Collections.Generic;

namespace LogiPharm.Entidades
{
    public class EFacturaElectronica
    {
        public string ClaveAcceso { get; set; }
        public string Ambiente { get; set; }
        public string TipoEmision { get; set; }
        public string RazonSocialEmisor { get; set; }
        public string NombreComercialEmisor { get; set; }
        public string RucEmisor { get; set; }
        public string Establecimiento { get; set; }
        public string PuntoEmision { get; set; }
        public string Secuencial { get; set; }
        public DateTime FechaEmision { get; set; }
        public string DireccionMatriz { get; set; }

        // Comprador
        public string RazonSocialComprador { get; set; }
        public string IdentificacionComprador { get; set; }
        public string DireccionComprador { get; set; }

        // Totales
        public decimal TotalSinImpuestos { get; set; }
        public decimal TotalDescuento { get; set; }
        public decimal TotalImpuestos { get; set; }
        public decimal ImporteTotal { get; set; }

        // Detalles
        public List<EDetalleFacturaXML> Detalles { get; set; }

        public EFacturaElectronica()
        {
            Detalles = new List<EDetalleFacturaXML>();
        }
    }

    public class EDetalleFacturaXML
    {
        public string CodigoPrincipal { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Descuento { get; set; }
        public decimal PrecioTotalSinImpuesto { get; set; }
        public decimal ValorImpuesto { get; set; }
        public decimal Tarifa { get; set; }

        // Para matching con productos existentes
        public int? IdProductoEncontrado { get; set; }
        public string NombreProductoEncontrado { get; set; }
        public bool EsProductoNuevo { get; set; }
        
        // Para productos similares detectados
        public List<ProductoSimilarDetectado> ProductosSimilares { get; set; }
        public bool TieneSimilares => ProductosSimilares != null && ProductosSimilares.Count > 0;
        
        public decimal CostoPorUnidad => Cantidad > 0 ? PrecioTotalSinImpuesto / Cantidad : 0;
        public decimal PVPSugerido => CostoPorUnidad * 1.30m; // 30% margen sugerido

        public EDetalleFacturaXML()
        {
            ProductosSimilares = new List<ProductoSimilarDetectado>();
        }
    }

    /// <summary>
    /// Clase para representar un producto similar detectado durante la importación
    /// </summary>
    public class ProductoSimilarDetectado
    {
        public long Id { get; set; }
        public string CodigoPrincipal { get; set; }
        public string Nombre { get; set; }
        public decimal Stock { get; set; }
        public decimal PrecioVenta { get; set; }
        public double PorcentajeSimilitud { get; set; }
    }
}
