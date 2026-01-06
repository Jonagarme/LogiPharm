using System;

namespace LogiPharm.Entidades
{
    /// <summary>
    /// Entidad que representa el detalle de productos en una transferencia
    /// </summary>
    public class ETransferenciaDetalle
    {
        public long Id { get; set; }
        public long IdTransferencia { get; set; }
        
        // Producto
        public long IdProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        
        // Lote y caducidad
        public string Lote { get; set; }
        public DateTime? FechaCaducidad { get; set; }
        public int DiasParaCaducidad { get; set; }
        public string EstadoCaducidad { get; set; } // Vigente, Por Caducar, Caducado
        
        // Cantidades
        public int CantidadSolicitada { get; set; }
        public int CantidadRecibida { get; set; }
        public int StockDisponibleOrigen { get; set; }
        
        // Precios (para valorización)
        public decimal PrecioUnitario { get; set; }
        public decimal Total { get; set; }
        
        // Estado del detalle: PENDIENTE, RECIBIDO_COMPLETO, RECIBIDO_PARCIAL
        public string Estado { get; set; }
        
        public ETransferenciaDetalle()
        {
            Estado = "PENDIENTE";
            EstadoCaducidad = "Vigente";
        }
    }
}
