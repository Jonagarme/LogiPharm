using MySqlConnector;
using System;
using System.Data;
using System.Text;
using LogiPharm.Entidades;

namespace LogiPharm.Datos
{
    public class DLabProcesos
    {
        public DataTable Listar(int laboratorioId)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                string sql = "SELECT id, nombre, metodo, activo FROM lab_procesos WHERE laboratorio_id = @labId ORDER BY nombre";
                using (var da = new MySqlDataAdapter(sql, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@labId", laboratorioId);
                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public void Insertar(ELabProceso p)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                string sql = @"INSERT INTO lab_procesos (laboratorio_id, nombre, metodo, activo) 
                               VALUES (@labId, @nombre, @metodo, @activo)";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@labId", p.LaboratorioId);
                    cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                    cmd.Parameters.AddWithValue("@metodo", (object)p.Metodo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@activo", p.Activo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Actualizar(ELabProceso p)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                string sql = @"UPDATE lab_procesos SET nombre=@nombre, metodo=@metodo, activo=@activo 
                               WHERE id=@id";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", p.Id);
                    cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                    cmd.Parameters.AddWithValue("@metodo", (object)p.Metodo ?? DBNull.Value);
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
                string sql = "DELETE FROM lab_procesos WHERE id=@id";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
