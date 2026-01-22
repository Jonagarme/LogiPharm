using System;

namespace LogiPharm.Entidades
{
    public class EEstablecimiento
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string NombreComercial { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }
        public DateTime CreadoEn { get; set; }
    }
}
