namespace LogiPharm.Presentacion.Utilidades
{
    public static class SesionActual
    {
        public static int IdUsuario { get; set; }
        public static string NombreUsuario { get; set; }
        public static string NombreCompleto { get; set; }
        public static string Rol { get; set; }
        public static bool Activa => IdUsuario > 0;

        public static void Limpiar()
        {
            IdUsuario = 0;
            NombreUsuario = null;
            NombreCompleto = null;
            Rol = null;
        }
    }
}
