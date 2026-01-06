using System;
using System.Collections.Generic;

namespace LogiPharm.Entidades
{
    /// <summary>
    /// Entidad que representa una transferencia de stock entre ubicaciones
    /// </summary>
    public class ETransferencia
    {
        public long Id { get; set; }
        public string NumeroTransferencia { get; set; }
        public DateTime FechaTransferencia { get; set; }
        
        // Ubicaciones
        public int IdUbicacionOrigen { get; set; }
        public string UbicacionOrigen { get; set; }
        public int IdUbicacionDestino { get; set; }
        public string UbicacionDestino { get; set; }
        
        // Motivo y observaciones
        public string MotivoTransferencia { get; set; }
        public string Observaciones { get; set; }
        
        // Estado: PENDIENTE, EN_TRANSITO, RECIBIDA, CANCELADA
        public string Estado { get; set; }
        
        // Totales
        public int TotalProductos { get; set; }
        public int TotalUnidades { get; set; }
        
        // Auditoría
        public int CreadoPor { get; set; }
        public DateTime CreadoDate { get; set; }
        public int? RecibidoPor { get; set; }
        public DateTime? RecibidoDate { get; set; }
        public int? AnuladoPor { get; set; }
        public DateTime? AnuladoDate { get; set; }
        
        // Detalle
        public List<ETransferenciaDetalle> Detalles { get; set; }
        
        public ETransferencia()
        {
            Detalles = new List<ETransferenciaDetalle>();
            Estado = "PENDIENTE";
            FechaTransferencia = DateTime.Now;
        }
    }
}
