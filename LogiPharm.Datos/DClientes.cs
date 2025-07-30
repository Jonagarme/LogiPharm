using MySqlConnector;
using System;
using System.Data;
using LogiPharm.Entidades;

namespace LogiPharm.Datos
{
    public class D_Clientes
    {
        public ECliente BuscarClientePorId(string identificacion)
        {
            ECliente cliente = null;
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = "SELECT * FROM clientes WHERE identificacion = @id AND anulado = 0 LIMIT 1";
                    var cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", identificacion);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cliente = new ECliente
                            {
                                Id = reader.GetInt32("id"),
                                Identificacion = reader["identificacion"].ToString(),
                                RazonSocial = reader["razonSocial"].ToString(),
                                Direccion = reader["direccion"].ToString(),
                                Telefono = reader["telefono"].ToString(),
                                Email = reader["email"].ToString()
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

        public bool InsertarCliente(ECliente cliente)
        {
            int filasAfectadas = 0;
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                        INSERT INTO clientes (tipoIdentificacion, identificacion, razonSocial, direccion, telefono, email, creadoPor, creadoDate) 
                        VALUES (@tipoId, @id, @razonSocial, @direccion, @telefono, @email, @creadoPor, @creadoDate);";

                    var cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@tipoId", cliente.TipoIdentificacion);
                    cmd.Parameters.AddWithValue("@id", cliente.Identificacion);
                    cmd.Parameters.AddWithValue("@razonSocial", cliente.RazonSocial);
                    cmd.Parameters.AddWithValue("@direccion", (object)cliente.Direccion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@telefono", (object)cliente.Telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@email", (object)cliente.Email ?? DBNull.Value);
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
                    // Seleccionamos el ID y la razón social para el ComboBox
                    string query = "SELECT id, razonSocial FROM clientes WHERE anulado = 0 ORDER BY razonSocial ASC";

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
