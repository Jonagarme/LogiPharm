using MySqlConnector;
using System;
using System.Data;
using LogiPharm.Entidades;

namespace LogiPharm.Datos
{
    public class DPacientes
    {
        public DataTable Listar(string filtro = null)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                string sql = "SELECT id, documento, nombre, fecha_nacimiento, telefono, email, direccion, activo FROM pacientes";
                if (!string.IsNullOrWhiteSpace(filtro))
                    sql += " WHERE nombre LIKE @f OR documento LIKE @f";
                sql += " ORDER BY nombre";

                using (var da = new MySqlDataAdapter(sql, cn))
                {
                    if (!string.IsNullOrWhiteSpace(filtro))
                        da.SelectCommand.Parameters.AddWithValue("@f", "%" + filtro + "%");
                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public bool ExisteDocumento(string documento, int? excluirId = null)
        {
            if (string.IsNullOrWhiteSpace(documento)) return false;
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                string sql = "SELECT COUNT(*) FROM pacientes WHERE documento=@doc";
                if (excluirId.HasValue) sql += " AND id<>@id";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@doc", documento);
                    if (excluirId.HasValue) cmd.Parameters.AddWithValue("@id", excluirId.Value);
                    var count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public int Insertar(EPaciente p)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                var sql = @"INSERT INTO pacientes (documento, nombre, fecha_nacimiento, telefono, email, direccion, activo)
                             VALUES (@doc, @nom, @fec, @tel, @ema, @dir, @act);
                             SELECT LAST_INSERT_ID();";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@doc", (object)p.Documento ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@nom", p.Nombre);
                    cmd.Parameters.AddWithValue("@fec", (object)p.FechaNacimiento ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@tel", (object)p.Telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ema", (object)p.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@dir", (object)p.Direccion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@act", p.Activo);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void Actualizar(EPaciente p)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                var sql = @"UPDATE pacientes SET documento=@doc, nombre=@nom, fecha_nacimiento=@fec, telefono=@tel, email=@ema, direccion=@dir, activo=@act
                             WHERE id=@id";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", p.Id);
                    cmd.Parameters.AddWithValue("@doc", (object)p.Documento ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@nom", p.Nombre);
                    cmd.Parameters.AddWithValue("@fec", (object)p.FechaNacimiento ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@tel", (object)p.Telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ema", (object)p.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@dir", (object)p.Direccion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@act", p.Activo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Eliminar(int id)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                var sql = "DELETE FROM pacientes WHERE id=@id";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
