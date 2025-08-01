using LogiPharm.Entidades;
using System.Configuration;
using System;
using MySqlConnector;
using System.Security.Cryptography;
using System.Text;
using System.Data;

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

        public DataTable ListarUsuarios(string criterio)
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                        SELECT u.id, u.nombreCompleto, u.nombreUsuario, u.email, u.idRol, u.activo, r.nombre as rolNombre
                        FROM usuarios u
                        INNER JOIN roles r ON u.idRol = r.id
                        WHERE u.anulado = 0 AND (u.nombreCompleto LIKE @criterio OR u.nombreUsuario LIKE @criterio)
                        ORDER BY u.nombreCompleto ASC;";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@criterio", $"%{criterio}%");

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar los usuarios: " + ex.Message);
                }
            }
            return tabla;
        }

        public bool InsertarUsuario(EUsuario usuario)
        {
            int filasAfectadas = 0;
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                        INSERT INTO usuarios (idRol, nombreUsuario, contrasenaHash, nombreCompleto, email, activo, creadoPor, creadoDate)
                        VALUES (@idRol, @nombreUsuario, @contrasenaHash, @nombreCompleto, @email, @activo, @creadoPor, @creadoDate);";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idRol", usuario.IdRol);
                    cmd.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                    cmd.Parameters.AddWithValue("@contrasenaHash", CalcularSHA256(usuario.ContrasenaHash)); // Encriptamos la clave
                    cmd.Parameters.AddWithValue("@nombreCompleto", usuario.NombreCompleto);
                    cmd.Parameters.AddWithValue("@email", usuario.Email);
                    cmd.Parameters.AddWithValue("@activo", usuario.Activo);
                    cmd.Parameters.AddWithValue("@creadoPor", usuario.CreadoPor);
                    cmd.Parameters.AddWithValue("@creadoDate", DateTime.Now);

                    filasAfectadas = cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex) when (ex.Number == 1062) // Error de nombreUsuario o email duplicado
                {
                    throw new Exception("El nombre de usuario o el e-mail ya existen.");
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al guardar el usuario: " + ex.Message);
                }
            }
            return filasAfectadas > 0;
        }

        // --- MÉTODO PARA ACTUALIZAR UN USUARIO EXISTENTE ---
        public bool ActualizarUsuario(EUsuario usuario)
        {
            int filasAfectadas = 0;
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    // Si la contraseña está vacía, no la actualizamos.
                    string query = string.IsNullOrWhiteSpace(usuario.ContrasenaHash)
                        ? @"UPDATE usuarios SET idRol = @idRol, nombreUsuario = @nombreUsuario, nombreCompleto = @nombreCompleto, 
                                             email = @email, activo = @activo, editadoPor = @editadoPor, editadoDate = @editadoDate
                              WHERE id = @id;"
                        : @"UPDATE usuarios SET idRol = @idRol, nombreUsuario = @nombreUsuario, contrasenaHash = @contrasenaHash, 
                                             nombreCompleto = @nombreCompleto, email = @email, activo = @activo, 
                                             editadoPor = @editadoPor, editadoDate = @editadoDate
                              WHERE id = @id;";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", usuario.Id);
                    cmd.Parameters.AddWithValue("@idRol", usuario.IdRol);
                    cmd.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                    cmd.Parameters.AddWithValue("@nombreCompleto", usuario.NombreCompleto);
                    cmd.Parameters.AddWithValue("@email", usuario.Email);
                    cmd.Parameters.AddWithValue("@activo", usuario.Activo);
                    cmd.Parameters.AddWithValue("@editadoPor", usuario.EditadoPor);
                    cmd.Parameters.AddWithValue("@editadoDate", DateTime.Now);

                    if (!string.IsNullOrWhiteSpace(usuario.ContrasenaHash))
                    {
                        cmd.Parameters.AddWithValue("@contrasenaHash", CalcularSHA256(usuario.ContrasenaHash));
                    }

                    filasAfectadas = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar el usuario: " + ex.Message);
                }
            }
            return filasAfectadas > 0;
        }

        // --- MÉTODO PARA ANULAR (ELIMINAR LÓGICAMENTE) UN USUARIO ---
        public bool AnularUsuario(int idUsuario, int idUsuarioAnulador)
        {
            int filasAfectadas = 0;
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"UPDATE usuarios SET anulado = 1, anuladoPor = @anuladoPor, anuladoDate = @anuladoDate WHERE id = @id;";
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", idUsuario);
                    cmd.Parameters.AddWithValue("@anuladoPor", idUsuarioAnulador);
                    cmd.Parameters.AddWithValue("@anuladoDate", DateTime.Now);
                    filasAfectadas = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al anular el usuario: " + ex.Message);
                }
            }
            return filasAfectadas > 0;
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
