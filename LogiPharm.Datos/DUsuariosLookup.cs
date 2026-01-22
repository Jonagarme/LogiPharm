using MySqlConnector;
using System.Data;

namespace LogiPharm.Datos
{
    public class DUsuariosLookup
    {
        public DataTable ListarActivos()
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            using (var da = new MySqlDataAdapter(@"SELECT id, nombreUsuario
FROM usuarios
WHERE anulado = 0 AND activo = 1
ORDER BY nombreUsuario", cn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
