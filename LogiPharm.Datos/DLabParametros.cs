using MySqlConnector;
using System;
using System.Data;
using LogiPharm.Entidades;

namespace LogiPharm.Datos
{
    public class DLabParametros
    {
        public DataTable Listar(int procesoId)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                string sql = @"SELECT id, nombre, unidad, ref_min, ref_max, orden, notas, activo 
                               FROM lab_parametros WHERE proceso_id = @procId ORDER BY orden, nombre";
                using (var da = new MySqlDataAdapter(sql, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@procId", procesoId);
                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public void Insertar(ELabParametro p)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                string sql = @"INSERT INTO lab_parametros (proceso_id, nombre, unidad, ref_min, ref_max, orden, notas, activo) 
                               VALUES (@procId, @nombre, @unidad, @refMin, @refMax, @orden, @notas, @activo)";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@procId", p.ProcesoId);
                    cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                    cmd.Parameters.AddWithValue("@unidad", (object)p.Unidad ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@refMin", (object)p.RefMin ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@refMax", (object)p.RefMax ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@orden", p.Orden);
                    cmd.Parameters.AddWithValue("@notas", (object)p.Notas ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@activo", p.Activo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Actualizar(ELabParametro p)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                string sql = @"UPDATE lab_parametros SET nombre=@nombre, unidad=@unidad, ref_min=@refMin, 
                               ref_max=@refMax, orden=@orden, notas=@notas, activo=@activo 
                               WHERE id=@id";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", p.Id);
                    cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                    cmd.Parameters.AddWithValue("@unidad", (object)p.Unidad ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@refMin", (object)p.RefMin ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@refMax", (object)p.RefMax ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@orden", p.Orden);
                    cmd.Parameters.AddWithValue("@notas", (object)p.Notas ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@activo", p.Activo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Eliminar(int id)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                string sql = "DELETE FROM lab_parametros WHERE id=@id";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
