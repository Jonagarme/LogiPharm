using System;

namespace LogiPharm.Entidades
{
    /// <summary>
    /// Entidad que representa un lote de inventario con su ubicación
    /// </summary>
    public class EInventarioLote
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdUbicacion { get; set; }
        public string NumeroLote { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaFabricacion { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public decimal StockDisponible { get; set; }
        public decimal StockReservado { get; set; }
        public decimal StockTotal { get; set; }
        public decimal CostoUnitario { get; set; }
        public string NumeroFactura { get; set; }
        public string Observaciones { get; set; }
        public string Estado { get; set; } // VIGENTE, POR_CADUCAR, CADUCADO
        public int DiasParaCaducidad { get; set; }
        
        // Información del producto (para mostrar en grid)
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string NombreUbicacion { get; set; }
        
        // Auditoría
        public int CreadoPor { get; set; }
        public DateTime CreadoDate { get; set; }
    }
}
