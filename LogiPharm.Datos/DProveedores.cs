using MySqlConnector;
using System;
using System.Data;
using LogiPharm.Entidades;

namespace LogiPharm.Datos
{
    public class DProveedores
    {
        public DataTable ListarProveedores(string criterio)
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                        SELECT id, ruc, razonSocial, nombreComercial, direccion, telefono, email
                        FROM proveedores
                        WHERE anulado = 0 AND (ruc LIKE @criterio OR razonSocial LIKE @criterio OR nombreComercial LIKE @criterio)
                        ORDER BY razonSocial ASC;";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@criterio", $"%{criterio}%");

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar proveedores: " + ex.Message);
                }
            }
            return tabla;
        }

        public bool InsertarProveedor(EProveedor proveedor)
        {
            int filasAfectadas = 0;
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                        INSERT INTO proveedores (ruc, razonSocial, nombreComercial, direccion, telefono, email, creadoPor, creadoDate)
                        VALUES (@ruc, @razonSocial, @nombreComercial, @direccion, @telefono, @email, @creadoPor, @creadoDate);";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ruc", proveedor.Ruc);
                    cmd.Parameters.AddWithValue("@razonSocial", proveedor.RazonSocial);
                    cmd.Parameters.AddWithValue("@nombreComercial", (object)proveedor.NombreComercial ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@direccion", (object)proveedor.Direccion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@telefono", (object)proveedor.Telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@email", (object)proveedor.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@creadoPor", proveedor.CreadoPor);
                    cmd.Parameters.AddWithValue("@creadoDate", DateTime.Now);

                    filasAfectadas = cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex) when (ex.Number == 1062) // Error de RUC duplicado
                {
                    throw new Exception("El RUC ingresado ya pertenece a otro proveedor.");
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al guardar el proveedor: " + ex.Message);
                }
            }
            return filasAfectadas > 0;
        }

        public bool ActualizarProveedor(EProveedor proveedor)
        {
            int filasAfectadas = 0;
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                        UPDATE proveedores SET
                            ruc = @ruc,
                            razonSocial = @razonSocial,
                            nombreComercial = @nombreComercial,
                            direccion = @direccion,
                            telefono = @telefono,
                            email = @email,
                            editadoPor = @editadoPor,
                            editadoDate = @editadoDate
                        WHERE id = @id;";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", proveedor.Id);
                    cmd.Parameters.AddWithValue("@ruc", proveedor.Ruc);
                    cmd.Parameters.AddWithValue("@razonSocial", proveedor.RazonSocial);
                    cmd.Parameters.AddWithValue("@nombreComercial", (object)proveedor.NombreComercial ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@direccion", (object)proveedor.Direccion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@telefono", (object)proveedor.Telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@email", (object)proveedor.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@editadoPor", proveedor.CreadoPor); // Asumimos que el que edita es el usuario actual
                    cmd.Parameters.AddWithValue("@editadoDate", DateTime.Now);

                    filasAfectadas = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar el proveedor: " + ex.Message);
                }
            }
            return filasAfectadas > 0;
        }

        /// <summary>
        /// Lista todos los proveedores activos para combobox
        /// </summary>
        public DataTable ListarProveedoresActivos()
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                        SELECT id, ruc, razonSocial, nombreComercial, direccion, telefono, email
                        FROM proveedores
                        WHERE anulado = 0
                        ORDER BY razonSocial ASC;";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar proveedores activos: " + ex.Message);
                }
            }
            return tabla;
        }
    }
}
