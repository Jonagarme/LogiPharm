using System.Data;
using LogiPharm.Datos;

namespace LogiPharm.Negocio
{
    public static class NUsuariosLookup
    {
        public static DataTable ListarActivos()
        {
            return new DUsuariosLookup().ListarActivos();
        }
    }
}
