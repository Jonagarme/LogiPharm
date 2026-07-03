using System;

namespace LogiPharm.Entidades
{
    public class EPresentacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public bool Anulado { get; set; }
    }
}
