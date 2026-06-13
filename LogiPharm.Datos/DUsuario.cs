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
        public EUsuario Login(string companyId, string usuario, string clave)
        {
            using (MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cadena_conexion"].ConnectionString))
            {
                cn.Open();

                MySqlCommand cmd = new MySqlCommand(@"
                    SELECT u.*, r.nombre AS NombreRol, e.razon_social, e.activo AS EmpresaActiva
                    FROM usuarios u
                    INNER JOIN empresas e ON u.idEmpresa = e.id
                    LEFT JOIN roles r ON r.id = u.idRol
                    WHERE u.nombreUsuario = @usuario 
                      AND u.activo = 1 
                      AND u.anulado = 0
                      AND (e.ruc = @companyId OR e.email = @companyId)
                ", cn);

                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@companyId", companyId);

                bool valid = false;
                int userId = 0;
                string usernameValue = "";
                string contrasenaHash = "";
                string rolValue = "";
                string nombreCompleto = "";
                int idEmpresa = 0;
                int? idUbicacion = null;

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        // Validar si la empresa está activa
                        bool empresaActiva = Convert.ToBoolean(dr["EmpresaActiva"]);
                        if (!empresaActiva)
                        {
                            throw new Exception("La empresa se encuentra inactiva. Contacte a soporte.");
                        }

                        contrasenaHash = dr["contrasenaHash"].ToString();

                        if (contrasenaHash.StartsWith("pbkdf2_sha256$"))
                        {
                            valid = DjangoPasswordHasher.VerifyPassword(clave, contrasenaHash);
                        }
                        else if (contrasenaHash.StartsWith("$2y$") || contrasenaHash.StartsWith("$2a$") || contrasenaHash.StartsWith("$2b$"))
                        {
                            valid = BCrypt.Verify(clave, contrasenaHash);
                        }
                        else if (contrasenaHash.Length == 64) // SHA-256 en hexadecimal
                        {
                            valid = contrasenaHash.Equals(CalcularSHA256(clave), StringComparison.OrdinalIgnoreCase);
                        }

                        if (valid)
                        {
                            userId = Convert.ToInt32(dr["id"]);
                            usernameValue = dr["nombreUsuario"].ToString();
                            rolValue = dr["NombreRol"].ToString();
                            nombreCompleto = dr["nombreCompleto"].ToString();
                            idEmpresa = Convert.ToInt32(dr["idEmpresa"]);
                            idUbicacion = dr["idUbicacion"] != DBNull.Value ? (int?)Convert.ToInt32(dr["idUbicacion"]) : null;
                        }
                    }
                }

                if (valid)
                {
                    // Lógica de fallback para idUbicacion en caso de ser NULL
                    if (!idUbicacion.HasValue)
                    {
                        using (MySqlCommand cmdPrincipal = new MySqlCommand(@"
                            SELECT id FROM inventario_ubicacion 
                            WHERE idEmpresa = @idEmpresa AND es_principal = 1 AND activo = 1 AND anulado = 0 LIMIT 1", cn))
                        {
                            cmdPrincipal.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                            object obj = cmdPrincipal.ExecuteScalar();
                            if (obj != null && obj != DBNull.Value)
                            {
                                idUbicacion = Convert.ToInt32(obj);
                            }
                        }

                        if (!idUbicacion.HasValue)
                        {
                            using (MySqlCommand cmdFirst = new MySqlCommand(@"
                                SELECT id FROM inventario_ubicacion 
                                WHERE idEmpresa = @idEmpresa AND activo = 1 AND anulado = 0 LIMIT 1", cn))
                            {
                                cmdFirst.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                                object obj = cmdFirst.ExecuteScalar();
                                if (obj != null && obj != DBNull.Value)
                                {
                                    idUbicacion = Convert.ToInt32(obj);
                                }
                            }
                        }
                    }

                    return new EUsuario
                    {
                        IdUsuario = userId,
                        Usuario = usernameValue,
                        Clave = contrasenaHash,
                        Rol = rolValue,
                        NombreCompleto = nombreCompleto,
                        IdEmpresa = idEmpresa,
                        IdUbicacion = idUbicacion
                    };
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
                        SELECT u.id, u.nombreCompleto, u.nombreUsuario, u.email, u.idRol, u.activo, r.nombre as rolNombre, u.idUbicacion, uo.nombre as ubicacionNombre
                        FROM usuarios u
                        INNER JOIN roles r ON u.idRol = r.id
                        LEFT JOIN inventario_ubicacion uo ON u.idUbicacion = uo.id
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
                        INSERT INTO usuarios (idRol, nombreUsuario, contrasenaHash, nombreCompleto, email, activo, creadoPor, creadoDate, idUbicacion)
                        VALUES (@idRol, @nombreUsuario, @contrasenaHash, @nombreCompleto, @email, @activo, @creadoPor, @creadoDate, @idUbicacion);";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idRol", usuario.IdRol);
                    cmd.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                    cmd.Parameters.AddWithValue("@contrasenaHash", CalcularSHA256(usuario.ContrasenaHash)); // Encriptamos la clave
                    cmd.Parameters.AddWithValue("@nombreCompleto", usuario.NombreCompleto);
                    cmd.Parameters.AddWithValue("@email", usuario.Email);
                    cmd.Parameters.AddWithValue("@activo", usuario.Activo);
                    cmd.Parameters.AddWithValue("@creadoPor", usuario.CreadoPor);
                    cmd.Parameters.AddWithValue("@creadoDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@idUbicacion", (object)usuario.IdUbicacion ?? DBNull.Value);

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
                                             email = @email, activo = @activo, editadoPor = @editadoPor, editadoDate = @editadoDate,
                                             idUbicacion = @idUbicacion
                              WHERE id = @id;"
                        : @"UPDATE usuarios SET idRol = @idRol, nombreUsuario = @nombreUsuario, contrasenaHash = @contrasenaHash, 
                                             nombreCompleto = @nombreCompleto, email = @email, activo = @activo, 
                                             editadoPor = @editadoPor, editadoDate = @editadoDate, idUbicacion = @idUbicacion
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
                    cmd.Parameters.AddWithValue("@idUbicacion", (object)usuario.IdUbicacion ?? DBNull.Value);

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
