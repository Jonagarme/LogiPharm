namespace LogiPharm.Entidades
{
    public class EUsuario
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Rol { get; set; }
        public string NombreCompleto { get; set; }

        public int Id { get; set; }
        public int IdRol { get; set; }
        public string NombreUsuario { get; set; }
        public string ContrasenaHash { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }

        // Propiedades de auditoría
        public int CreadoPor { get; set; }
        public int? EditadoPor { get; set; }


    }
}
