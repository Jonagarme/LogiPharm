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
                    // Cambiamos la condición para que traiga también los NULL
                    string query = "SELECT id, codigo, nombre, tipo, direccion FROM inventario_ubicacion WHERE (activo = 1 OR activo IS NULL) ORDER BY nombre";
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

        public bool InsertarUbicacion(string codigo, string nombre, string tipo, string direccion)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                        INSERT INTO inventario_ubicacion (codigo, nombre, tipo, direccion, activo, creadoDate) 
                        VALUES (@codigo, @nombre, @tipo, @direccion, 1, @creadoDate)";
                    
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@tipo", tipo ?? "");
                    cmd.Parameters.AddWithValue("@direccion", direccion ?? "");
                    cmd.Parameters.AddWithValue("@creadoDate", DateTime.Now);
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar ubicación: " + ex.Message);
                }
            }
        }
    }
}
