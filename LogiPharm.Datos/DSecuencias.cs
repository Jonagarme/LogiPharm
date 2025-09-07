using System;
using System.Data;
using MySqlConnector;

namespace LogiPharm.Datos
{
    public class DSecuencias
    {
        public DataTable ListarSecuencias()
        {
            var dt = new DataTable();
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            using (var cmd = new MySqlCommand("SELECT nombre, valor, prefijo, longitud, activo FROM secuencias ORDER BY nombre", cn))
            using (var da = new MySqlDataAdapter(cmd))
            {
                cn.Open();
                da.Fill(dt);
            }
            return dt;
        }

        public void GuardarSecuencia(string nombre, int valor, string prefijo, int longitud, bool activo)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                using (var cmd = new MySqlCommand(@"INSERT INTO secuencias(nombre, valor, prefijo, longitud, activo)
VALUES(@n, @v, @p, @l, @a)
ON DUPLICATE KEY UPDATE valor=@v, prefijo=@p, longitud=@l, activo=@a", cn))
                {
                    cmd.Parameters.AddWithValue("@n", nombre);
                    cmd.Parameters.AddWithValue("@v", valor);
                    cmd.Parameters.AddWithValue("@p", (object)prefijo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@l", longitud);
                    cmd.Parameters.AddWithValue("@a", activo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarSecuencia(string nombre)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            using (var cmd = new MySqlCommand("DELETE FROM secuencias WHERE nombre=@n", cn))
            {
                cn.Open();
                cmd.Parameters.AddWithValue("@n", nombre);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
