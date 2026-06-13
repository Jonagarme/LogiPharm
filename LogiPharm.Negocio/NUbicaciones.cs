using System;
using System.Data;
using LogiPharm.Datos;

namespace LogiPharm.Negocio
{
    public static class NUbicaciones
    {
        public static DataTable ListarUbicacionesActivas()
        {
            return new DUbicaciones().ListarUbicacionesActivas();
        }

        public static bool InsertarUbicacion(string codigo, string nombre, string tipo, string direccion, string telefono, string responsable, int idEmpresa, int creadoPor)
        {
            if (string.IsNullOrWhiteSpace(codigo)) throw new ArgumentException("El código de la ubicación es obligatorio.");
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre de la ubicación es obligatorio.");

            return new DUbicaciones().InsertarUbicacion(codigo, nombre, tipo, direccion, telefono, responsable, idEmpresa, creadoPor);
        }

        public static DataTable ObtenerUbicacionPorId(int id)
        {
            return new DUbicaciones().ObtenerUbicacionPorId(id);
        }

        public static bool ActualizarUbicacion(int id, string codigo, string nombre, string tipo, string direccion, string telefono, string responsable, int editadoPor)
        {
            if (id <= 0) throw new ArgumentException("ID de ubicación no válido.");
            if (string.IsNullOrWhiteSpace(codigo)) throw new ArgumentException("El código de la ubicación es obligatorio.");
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre de la ubicación es obligatorio.");

            return new DUbicaciones().ActualizarUbicacion(id, codigo, nombre, tipo, direccion, telefono, responsable, editadoPor);
        }
    }
}
