namespace LogiPharm.Presentacion.Utilidades
{
    public static class SesionActual
    {
        public static int IdUsuario { get; set; }
        public static string NombreUsuario { get; set; }
        public static string NombreCompleto { get; set; }
        public static string Rol { get; set; }
        public static int IdCaja { get; set; } = 2; // ID de la caja asignada al usuario/terminal
        public static string NombreCaja { get; set; } = "CAJA 002"; // Nombre de la caja
        public static bool Activa => IdUsuario > 0;

        /// <summary>
        /// Configura la caja desde App.config, o usa valores por defecto si no está configurada.
        /// Debe llamarse al iniciar la aplicación (en Program.cs o FrmLogin).
        /// </summary>
        public static void ConfigurarCaja()
        {
            try
            {
                // Intentar leer desde App.config
                string idCajaConfig = System.Configuration.ConfigurationManager.AppSettings["IdCaja"];
                string nombreCajaConfig = System.Configuration.ConfigurationManager.AppSettings["NombreCaja"];

                if (!string.IsNullOrEmpty(idCajaConfig) && int.TryParse(idCajaConfig, out int idCaja))
                {
                    IdCaja = idCaja;
                }

                if (!string.IsNullOrEmpty(nombreCajaConfig))
                {
                    NombreCaja = nombreCajaConfig;
                }

                // Si prefieres cargar desde base de datos en lugar de App.config, puedes:
                // var caja = new DCaja().ObtenerCajaPorMaquina(Environment.MachineName);
                // if (caja != null) { IdCaja = caja.Id; NombreCaja = caja.Nombre; }
            }
            catch
            {
                // Si falla, mantener valores por defecto
            }
        }

        public static void Limpiar()
        {
            IdUsuario = 0;
            NombreUsuario = null;
            NombreCompleto = null;
            Rol = null;
            // No limpiamos IdCaja porque es específico de la terminal/equipo
        }
    }
}
