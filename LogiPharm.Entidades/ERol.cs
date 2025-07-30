using System;

namespace LogiPharm.Entidades
{
    /// <summary>
    /// Representa la entidad Rol, que corresponde a la tabla 'roles' en la base de datos.
    /// </summary>
    public class ERol
    {
        // Propiedades que coinciden con las columnas de la tabla 'roles'

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CreadoPor { get; set; }
        public DateTime CreadoDate { get; set; }

        // Usamos tipos que aceptan nulos (nullable types) para las columnas que pueden ser NULL en la BD
        public int? EditadoPor { get; set; }
        public DateTime? EditadoDate { get; set; }

        // Un TINYINT(1) en MySQL se mapea bien a un booleano (bool) en C#
        public bool Anulado { get; set; }

        public int? AnuladoPor { get; set; }
        public DateTime? AnuladoDate { get; set; }

        // Constructor vacío (buena práctica)
        public ERol() { }
    }
}
