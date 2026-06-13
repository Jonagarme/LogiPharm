using System;

namespace LogiPharm.Presentacion.Utilidades
{
    public static class SesionActual
    {
        public static int IdUsuario { get; set; }
        public static string NombreUsuario { get; set; }
        public static string NombreCompleto { get; set; }
        public static string Rol { get; set; }
        public static int IdEmpresa { get; set; } = 1;
        public static int? IdUbicacion { get; set; }
        public static int IdCaja { get; set; } = 0; // ID de la caja asignada (0 = detectar automáticamente)
        public static string NombreCaja { get; set; } = "SIN CAJA"; // Nombre de la caja
        public static bool Activa => IdUsuario > 0;

        /// <summary>
        /// Configura la caja detectando automáticamente cuál está abierta.
        /// Si hay una caja abierta, la asigna. Si no, usa valores por defecto.
        /// Debe llamarse al iniciar la aplicación (en Program.cs o FrmLogin).
        /// </summary>
        public static void ConfigurarCaja()
        {
            try
            {
                // ✅ DETECCIÓN AUTOMÁTICA: Buscar la primera caja abierta
                var d_cierre = new LogiPharm.Datos.DCierreCaja();
                var cajaAbierta = d_cierre.ObtenerPrimeraCajaAbierta();

                if (cajaAbierta != null)
                {
                    // Si hay una caja abierta, usarla
                    IdCaja = Convert.ToInt32(cajaAbierta["idCaja"]);
                    NombreCaja = Convert.ToString(cajaAbierta["nombreCaja"]);
                }
                else
                {
                    // Si no hay cajas abiertas, intentar leer desde App.config (fallback)
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
                }
            }
            catch
            {
                // Si falla, mantener valores por defecto (0, "SIN CAJA")
            }
        }

        public static void Limpiar()
        {
            IdUsuario = 0;
            NombreUsuario = null;
            NombreCompleto = null;
            Rol = null;
            IdEmpresa = 1;
            IdUbicacion = null;
            CapaDatos.Conexion.IdEmpresa = 1;
            // No limpiamos IdCaja porque es específico de la terminal/equipo
        }
    }
}
