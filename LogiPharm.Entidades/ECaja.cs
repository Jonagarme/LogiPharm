using System;

namespace LogiPharm.Entidades
{
    public class ECaja
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Anulado { get; set; }
        public bool Activa { get; set; }
        public int? IdUbicacion { get; set; }
        
        // Campos de auditoría
        public int CreadoPor { get; set; }
        public DateTime CreadoDate { get; set; }
        public int? EditadoPor { get; set; }
        public DateTime? EditadoDate { get; set; }
        
        // Propiedades adicionales para vistas
        public string NombreUbicacion { get; set; }
        public string UsuarioCreador { get; set; }
        public string UsuarioEditor { get; set; }
        
        // Estado actual de la caja
        public bool TieneAperturaActiva { get; set; }
        public long? IdAperturaActiva { get; set; }
        public DateTime? FechaAperturaActiva { get; set; }
        public decimal? SaldoActual { get; set; }
        public string NombreUsuarioActivo { get; set; }
        
        // Propiedades calculadas
        public string EstadoTexto
        {
            get
            {
                if (Anulado)
                    return "ANULADA";
                if (!Activa)
                    return "INACTIVA";
                if (TieneAperturaActiva)
                    return "ABIERTA";
                return "CERRADA";
            }
        }
        
        public string EstadoColor
        {
            get
            {
                if (Anulado)
                    return "Gray";
                if (!Activa)
                    return "Orange";
                if (TieneAperturaActiva)
                    return "Green";
                return "Blue";
            }
        }
        
        public string EstadoIcono
        {
            get
            {
                if (Anulado)
                    return "??";
                if (!Activa)
                    return "??";
                if (TieneAperturaActiva)
                    return "?";
                return "??";
            }
        }
    }
}
