using System;

namespace LogiPharm.Entidades
{
    public class EProveedor
    {
        public int Id { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int CreadoPor { get; set; }
        // Puedes añadir más propiedades si las necesitas
    }
}
