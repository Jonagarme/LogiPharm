using System;

namespace LogiPharm.Entidades
{
    public class ECierreCaja
    {
        public long Id { get; set; }
        public int IdCaja { get; set; }
        public int IdUsuarioApertura { get; set; }
        public int? IdUsuarioCierre { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime? FechaCierre { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal TotalIngresosSistema { get; set; }
        public decimal TotalEgresosSistema { get; set; }
        public decimal SaldoTeoricoSistema { get; set; }
        public decimal TotalContadoFisico { get; set; }
        public decimal Diferencia { get; set; }
        public string Estado { get; set; } // ABIERTA, CERRADA
        public bool Anulado { get; set; }
        
        // Campos de auditoría
        public int CreadoPor { get; set; }
        public DateTime CreadoDate { get; set; }
        public int? EditadoPor { get; set; }
        public DateTime? EditadoDate { get; set; }
        
        // Propiedades adicionales para vistas
        public string NombreCaja { get; set; }
        public string NombreUsuarioApertura { get; set; }
        public string NombreUsuarioCierre { get; set; }
        public int? IdUbicacion { get; set; }
        
        // Propiedades calculadas
        public string EstadoColor
        {
            get
            {
                return Estado == "ABIERTA" ? "Green" : "Gray";
            }
        }
        
        public string DiferenciaFormateada
        {
            get
            {
                if (Diferencia > 0)
                    return $"+{Diferencia:C2}";
                else if (Diferencia < 0)
                    return $"{Diferencia:C2}";
                else
                    return "$0.00";
            }
        }
        
        public string DuracionCierre
        {
            get
            {
                if (!FechaCierre.HasValue)
                    return "En curso";
                
                TimeSpan duracion = FechaCierre.Value - FechaApertura;
                if (duracion.TotalHours < 24)
                    return $"{duracion.Hours}h {duracion.Minutes}m";
                else
                    return $"{duracion.Days}d {duracion.Hours}h";
            }
        }
    }
}
