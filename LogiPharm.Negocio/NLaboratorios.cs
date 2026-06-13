using System;
using System.Data;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Negocio
{
    public static class NLaboratorios
    {
        public static DataTable Listar()
        {
            return new DLaboratorios().Listar();
        }

        public static void Insertar(ELaboratorio e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));
            if (string.IsNullOrWhiteSpace(e.Nombre)) throw new ArgumentException("El nombre del laboratorio es obligatorio.");

            new DLaboratorios().Insertar(e);
        }

        public static void Actualizar(ELaboratorio e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));
            if (e.Id <= 0) throw new ArgumentException("ID de laboratorio no válido para actualizar.");
            if (string.IsNullOrWhiteSpace(e.Nombre)) throw new ArgumentException("El nombre del laboratorio es obligatorio.");

            new DLaboratorios().Actualizar(e);
        }

        public static void Eliminar(int id)
        {
            if (id <= 0) throw new ArgumentException("ID de laboratorio no válido.");
            new DLaboratorios().Eliminar(id);
        }
    }
}
