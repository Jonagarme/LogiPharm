using MySqlConnector;
using System;
using System.Data;
using LogiPharm.Entidades; // Asegúrate de tener la referencia a tus Entidades

namespace LogiPharm.Datos
{
    public class DRoles
    {
        /// <summary>
        /// Obtiene una lista de todos los roles que no están anulados.
        /// </summary>
        /// <returns>Un DataTable con el ID y el Nombre de los roles.</returns>
        public DataTable ListarRolesActivos()
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    // Consulta para traer solo los roles activos
                    string query = "SELECT id, nombre, descripcion FROM roles WHERE anulado = 0 ORDER BY nombre ASC";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, cn);
                    da.Fill(tabla);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar los roles: " + ex.Message);
                }
            }
            return tabla;
        }

        public DataTable ListarPermisosActivos()
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = "SELECT id, nombreMenu as Nombre FROM permisos ORDER BY nombre ASC";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, cn);
                    da.Fill(tabla);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar los permisos: " + ex.Message);
                }
            }
            return tabla;
        }

        public bool InsertarRol(ERol rol)
        {
            int filasAfectadas = 0;
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                        INSERT INTO roles (nombre, descripcion, creadoPor, creadoDate) 
                        VALUES (@nombre, @descripcion, @creadoPor, @creadoDate);";

                    MySqlCommand cmd = new MySqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@nombre", rol.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", (object)rol.Descripcion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@creadoPor", rol.CreadoPor);
                    cmd.Parameters.AddWithValue("@creadoDate", DateTime.Now);

                    filasAfectadas = cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex) when (ex.Number == 1062) // Error de entrada duplicada
                {
                    throw new Exception("Ya existe un rol con ese nombre.");
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar el rol: " + ex.Message);
                }
            }
            return filasAfectadas > 0;
        }
    }
}
