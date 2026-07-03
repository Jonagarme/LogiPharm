using System;
using System.Data;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Negocio
{
    public static class NPresentacion
    {
        public static DataTable Listar()
        {
            return new DPresentacion().Listar();
        }

        public static DataTable ListarActivas()
        {
            return new DPresentacion().ListarActivas();
        }

        public static DataTable Buscar(string criterio)
        {
            return new DPresentacion().Buscar(criterio);
        }

        public static bool Insertar(EPresentacion presentacion)
        {
            if (presentacion == null) throw new ArgumentNullException(nameof(presentacion));
            if (string.IsNullOrWhiteSpace(presentacion.Nombre))
                throw new ArgumentException("El nombre de la presentación es obligatorio.");
            return new DPresentacion().Insertar(presentacion);
        }

        public static bool Actualizar(EPresentacion presentacion)
        {
            if (presentacion == null) throw new ArgumentNullException(nameof(presentacion));
            if (presentacion.Id <= 0)
                throw new ArgumentException("ID de presentación no válido.");
            if (string.IsNullOrWhiteSpace(presentacion.Nombre))
                throw new ArgumentException("El nombre de la presentación es obligatorio.");
            return new DPresentacion().Actualizar(presentacion);
        }

        public static bool Eliminar(int id)
        {
            if (id <= 0) throw new ArgumentException("ID no válido.");
            return new DPresentacion().Eliminar(id);
        }
    }
}
