using System.Collections.Generic;

namespace LogiPharm.Entidades
{
    /// <summary>
    /// Clase principal que representa la estructura completa del JSON a enviar a la API de facturación.
    /// </summary>
    public class VentaPayload
    {
        public int empresaId { get; set; } = 2; // Valor fijo según tu ejemplo
        public string identificacionReceptor { get; set; }
        public string razonSocialReceptor { get; set; }
        public List<DetallePayload> detalles { get; set; }

        public VentaPayload()
        {
            detalles = new List<DetallePayload>();
        }
    }

    /// <summary>
    /// Representa un ítem de producto dentro del payload de la venta.
    /// </summary>
    public class DetallePayload
    {
        public string codigoPrincipal { get; set; }
        public string descripcion { get; set; }
        public decimal cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal descuento { get; set; }
        public decimal precioTotalSinImpuesto { get; set; }
    }

    /// <summary>
    /// Clase auxiliar utilizada para recolectar la información de los productos
    /// desde el DataGridView del Punto de Venta antes de crear el payload final.
    /// </summary>
    public class ProductoVenta
    {
        public string CodigoPrincipal { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Descuento { get; set; }
        public decimal PrecioTotalSinImpuesto { get; set; }
    }
}
