using System;

namespace LogiPharm.Entidades
{
    public class ECliente
    {
        public int Id { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int CreadoPor { get; set; }
    }
}
