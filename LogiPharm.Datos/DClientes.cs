using MySqlConnector;
using System;
using System.Data;
using LogiPharm.Entidades;

namespace LogiPharm.Datos
{
    public class DClientes
    {
        public ECliente BuscarClientePorId(string cedulaRuc)
        {
            ECliente cliente = null;
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = "SELECT * FROM clientes WHERE cedula_ruc = @cedulaRuc AND anulado = 0 LIMIT 1";
                    var cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@cedulaRuc", cedulaRuc);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cliente = new ECliente
                            {
                                Id = reader.GetInt32("id"),
                                TipoIdentificacion = reader["tipo_identificacion"].ToString(),
                                RazonSocial = reader["nombres"].ToString(),
                                Direccion = reader["direccion"]?.ToString(),
                                Telefono = reader["telefono"]?.ToString(),
                                Email = reader["email"]?.ToString(),
                                CreadoPor = reader["creadoPor"] != DBNull.Value ? Convert.ToInt32(reader["creadoPor"]) : 1,
                                EditadoPor = reader["editadoPor"] != DBNull.Value ? Convert.ToInt32(reader["editadoPor"]) : (int?)null
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar cliente: " + ex.Message);
                }
            }
            return cliente;
        }


        public DataTable ListarClientes(string criterio)
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                SELECT id, tipo_identificacion, cedula_ruc, nombres, apellidos, celular, direccion,telefono, email, razonSocial
                FROM clientes
                WHERE anulado = 0 
                  AND (cedula_ruc LIKE @criterio OR razonSocial LIKE @criterio)
                ORDER BY razonSocial ASC;";
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@criterio", $"%{criterio}%");
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar los clientes: " + ex.Message);
                }
            }
            return tabla;
        }


        public bool ActualizarCliente(ECliente cliente)
        {
            int filasAfectadas = 0;
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                UPDATE clientes SET
                    tipo_identificacion = @tipoIdentificacion,
                    cedula_ruc = @cedulaRuc,
                    nombres = @nombres,
                    apellidos = @apellidos,
                    razonSocial = @razonSocial,
                    direccion = @direccion,
                    telefono = @telefono,
                    celular = @celular,
                    email = @email,
                    fecha_nacimiento = @fechaNacimiento,
                    tipo_cliente = @tipoCliente,
                    estado = @estado,
                    editadoPor = @editadoPor,
                    editadoDate = @editadoDate
                WHERE id = @id;";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", cliente.Id);
                    cmd.Parameters.AddWithValue("@tipoIdentificacion", cliente.TipoIdentificacion);
                    cmd.Parameters.AddWithValue("@cedulaRuc", cliente.CedulaRuc);
                    cmd.Parameters.AddWithValue("@nombres", (object)cliente.Nombres ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@apellidos", (object)cliente.Apellidos ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@razonSocial", cliente.RazonSocial);
                    cmd.Parameters.AddWithValue("@direccion", (object)cliente.Direccion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@telefono", (object)cliente.Telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@celular", (object)cliente.Celular ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@email", (object)cliente.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@fechaNacimiento", cliente.FechaNacimiento.HasValue ? (object)cliente.FechaNacimiento.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@tipoCliente", (object)cliente.TipoCliente ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@estado", cliente.Estado);
                    cmd.Parameters.AddWithValue("@editadoPor", cliente.EditadoPor);
                    cmd.Parameters.AddWithValue("@editadoDate", DateTime.Now);

                    filasAfectadas = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar el cliente: " + ex.Message);
                }
            }
            return filasAfectadas > 0;
        }



        public bool InsertarCliente(ECliente cliente)
        {
            int filasAfectadas = 0;
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                INSERT INTO clientes
                    (tipo_identificacion, cedula_ruc, nombres, apellidos, razonSocial, direccion, telefono, celular, email, fecha_nacimiento, tipo_cliente, estado, creadoPor, creadoDate)
                VALUES
                    (@tipoIdentificacion, @cedulaRuc, @nombres, @apellidos, @razonSocial, @direccion, @telefono, @celular, @email, @fechaNacimiento, @tipoCliente, @estado, @creadoPor, @creadoDate);";

                    var cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@tipoIdentificacion", cliente.TipoIdentificacion);
                    cmd.Parameters.AddWithValue("@cedulaRuc", cliente.CedulaRuc);
                    cmd.Parameters.AddWithValue("@nombres", (object)cliente.Nombres ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@apellidos", (object)cliente.Apellidos ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@razonSocial", cliente.RazonSocial);
                    cmd.Parameters.AddWithValue("@direccion", (object)cliente.Direccion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@telefono", (object)cliente.Telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@celular", (object)cliente.Celular ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@email", (object)cliente.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@fechaNacimiento", cliente.FechaNacimiento.HasValue ? (object)cliente.FechaNacimiento.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@tipoCliente", (object)cliente.TipoCliente ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@estado", cliente.Estado);
                    cmd.Parameters.AddWithValue("@creadoPor", cliente.CreadoPor);
                    cmd.Parameters.AddWithValue("@creadoDate", DateTime.Now);

                    filasAfectadas = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al guardar el cliente: " + ex.Message);
                }
            }
            return filasAfectadas > 0;
        }


        public DataTable ListarClientesActivos()
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = "SELECT id, razonSocial FROM clientes WHERE anulado = 0 AND estado = 1 ORDER BY razonSocial ASC";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, cn);
                    da.Fill(tabla);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar clientes: " + ex.Message);
                }
            }
            return tabla;
        }

    }
}
