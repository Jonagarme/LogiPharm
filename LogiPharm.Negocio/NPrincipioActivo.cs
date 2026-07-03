using System;
using System.Data;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Negocio
{
    public static class NPrincipioActivo
    {
        public static DataTable Listar()
        {
            return new DPrincipioActivo().Listar();
        }

        public static DataTable ListarActivos()
        {
            return new DPrincipioActivo().ListarActivos();
        }

        public static DataTable Buscar(string criterio)
        {
            return new DPrincipioActivo().Buscar(criterio);
        }

        public static bool Insertar(EPrincipioActivo principio)
        {
            if (principio == null) throw new ArgumentNullException(nameof(principio));
            if (string.IsNullOrWhiteSpace(principio.Nombre))
                throw new ArgumentException("El nombre del principio activo es obligatorio.");
            return new DPrincipioActivo().Insertar(principio);
        }

        public static bool Actualizar(EPrincipioActivo principio)
        {
            if (principio == null) throw new ArgumentNullException(nameof(principio));
            if (principio.Id <= 0)
                throw new ArgumentException("ID de principio activo no válido.");
            if (string.IsNullOrWhiteSpace(principio.Nombre))
                throw new ArgumentException("El nombre del principio activo es obligatorio.");
            return new DPrincipioActivo().Actualizar(principio);
        }

        public static bool Eliminar(int id)
        {
            if (id <= 0) throw new ArgumentException("ID no válido.");
            return new DPrincipioActivo().Eliminar(id);
        }
    }
}
