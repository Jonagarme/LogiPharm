using System.Data;
using LogiPharm.Datos;

namespace LogiPharm.Negocio
{
    public static class NEstablecimiento
    {
        public static DataTable Listar()
        {
            return new DEstablecimientos().Listar();
        }

        public static int Insertar(string codigo, string nombreComercial, string direccion, string estado)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new System.ArgumentException("El código es obligatorio.");
            if (string.IsNullOrWhiteSpace(nombreComercial))
                throw new System.ArgumentException("El nombre comercial es obligatorio.");

            return new DEstablecimientos().Insertar(codigo, nombreComercial, direccion, estado);
        }

        public static void Actualizar(int id, string codigo, string nombreComercial, string direccion, string estado)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new System.ArgumentException("El código es obligatorio.");
            if (string.IsNullOrWhiteSpace(nombreComercial))
                throw new System.ArgumentException("El nombre comercial es obligatorio.");

            new DEstablecimientos().Actualizar(id, codigo, nombreComercial, direccion, estado);
        }

        public static void Eliminar(int id)
        {
            new DEstablecimientos().Eliminar(id);
        }
    }
}
