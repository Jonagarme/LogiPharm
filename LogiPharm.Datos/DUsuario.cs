using LogiPharm.Entidades;
using System.Configuration;
using System;
using MySqlConnector;
using System.Security.Cryptography;
using System.Text;

namespace LogiPharm.Datos
{
    public class DUsuario
    {
        public EUsuario Login(string usuario, string clave)
        {
            using (MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cadena_conexion"].ConnectionString))
            {
                cn.Open();

                // Hashea la clave antes de enviarla a la consulta
                string hashClave = CalcularSHA256(clave);

                MySqlCommand cmd = new MySqlCommand(@"
            SELECT u.*, r.nombre AS NombreRol
            FROM usuarios u
            INNER JOIN roles r ON r.id = u.idRol
            WHERE u.nombreUsuario = @usuario 
              AND u.contrasenaHash = @clave 
              AND u.activo = 1 
              AND u.anulado = 0
        ", cn);

                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@clave", hashClave);  // <--- el hash, no la clave en texto

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new EUsuario
                        {
                            IdUsuario = Convert.ToInt32(dr["id"]),
                            Usuario = dr["nombreUsuario"].ToString(),
                            Clave = dr["contrasenaHash"].ToString(),
                            Rol = dr["NombreRol"].ToString(),
                            NombreCompleto = dr["nombreCompleto"].ToString()
                        };
                    }
                }
                return null;
            }
        }


        public static string CalcularSHA256(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(texto));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2")); // hex
                return sb.ToString();
            }
        }
    }
}
