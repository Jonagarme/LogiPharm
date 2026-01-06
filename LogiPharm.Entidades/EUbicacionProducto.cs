using System;

namespace LogiPharm.Entidades
{
    public class EUbicacionProducto
    {
        public int Id { get; set; }
        public int PerchaId { get; set; }
        public int ProductoId { get; set; }
        public int Fila { get; set; }
        public int Columna { get; set; }
        public string Observaciones { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaUbicacion { get; set; }
        public int UsuarioUbicacionId { get; set; }

        // Propiedades adicionales para mostrar información
        public string PercchaNombre { get; set; }
        public string ProductoCodigo { get; set; }
        public string ProductoNombre { get; set; }
        public string UsuarioNombre { get; set; }

        public EUbicacionProducto()
        {
            Activo = true;
            FechaUbicacion = DateTime.Now;
        }
    }
}
