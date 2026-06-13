using CapaDatos;
using MySqlConnector;
using System;
using System.Data;

namespace LogiPharm.Datos
{
    public class DUbicaciones
    {
        public DataTable ListarUbicacionesActivas()
        {
            DataTable tabla = new DataTable();
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    // Seleccionar también teléfono y responsable, y filtrar que no esté anulada
                    string query = "SELECT id, codigo, nombre, tipo, direccion, telefono, responsable FROM inventario_ubicacion WHERE (activo = 1 OR activo IS NULL) AND (anulado = 0 OR anulado IS NULL) ORDER BY nombre";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, cn);
                    da.Fill(tabla);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar ubicaciones: " + ex.Message);
                }
            }
            return tabla;
        }

        public DataTable ObtenerUbicacionPorId(int id)
        {
            DataTable tabla = new DataTable();
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = "SELECT id, codigo, nombre, tipo, direccion, telefono, responsable FROM inventario_ubicacion WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(tabla);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener ubicación por ID: " + ex.Message);
                }
            }
            return tabla;
        }

        public bool InsertarUbicacion(string codigo, string nombre, string tipo, string direccion, string telefono, string responsable, int idEmpresa, int creadoPor)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                        INSERT INTO inventario_ubicacion (codigo, nombre, tipo, direccion, telefono, responsable, activo, es_principal, anulado, creadoDate, creadoPor_id, idEmpresa) 
                        VALUES (@codigo, @nombre, @tipo, @direccion, @telefono, @responsable, 1, 0, 0, @creadoDate, @creadoPor, @idEmpresa)";
                    
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@tipo", tipo ?? "Bodega");
                    cmd.Parameters.AddWithValue("@direccion", direccion ?? "");
                    cmd.Parameters.AddWithValue("@telefono", telefono ?? "");
                    cmd.Parameters.AddWithValue("@responsable", responsable ?? "");
                    cmd.Parameters.AddWithValue("@creadoDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@creadoPor", creadoPor);
                    cmd.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar ubicación: " + ex.Message);
                }
            }
        }

        public bool ActualizarUbicacion(int id, string codigo, string nombre, string tipo, string direccion, string telefono, string responsable, int editadoPor)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                        UPDATE inventario_ubicacion 
                        SET codigo = @codigo, 
                            nombre = @nombre, 
                            tipo = @tipo, 
                            direccion = @direccion, 
                            telefono = @telefono, 
                            responsable = @responsable, 
                            editadoDate = @editadoDate, 
                            editadoPor_id = @editadoPor
                        WHERE id = @id";
                    
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@tipo", tipo ?? "Bodega");
                    cmd.Parameters.AddWithValue("@direccion", direccion ?? "");
                    cmd.Parameters.AddWithValue("@telefono", telefono ?? "");
                    cmd.Parameters.AddWithValue("@responsable", responsable ?? "");
                    cmd.Parameters.AddWithValue("@editadoDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@editadoPor", editadoPor);
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar ubicación: " + ex.Message);
                }
            }
        }
    }
}
