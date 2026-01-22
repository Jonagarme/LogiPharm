using MySqlConnector;
using System;
using System.Data;

namespace LogiPharm.Datos
{
    public class DEstablecimientos
    {
        public DataTable Listar()
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            using (var da = new MySqlDataAdapter(@"SELECT id, codigo, nombre_comercial, direccion, estado, creado_en
FROM establecimientos
ORDER BY codigo", cn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public int Insertar(string codigo, string nombreComercial, string direccion, string estado)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            using (var cmd = new MySqlCommand(@"INSERT INTO establecimientos (codigo, nombre_comercial, direccion, estado)
VALUES (@codigo, @nombre, @direccion, @estado);
SELECT LAST_INSERT_ID();", cn))
            {
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.Parameters.AddWithValue("@nombre", nombreComercial);
                cmd.Parameters.AddWithValue("@direccion", (object)direccion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@estado", string.IsNullOrWhiteSpace(estado) ? "Activo" : estado);

                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void Actualizar(int id, string codigo, string nombreComercial, string direccion, string estado)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            using (var cmd = new MySqlCommand(@"UPDATE establecimientos
SET codigo=@codigo,
    nombre_comercial=@nombre,
    direccion=@direccion,
    estado=@estado
WHERE id=@id", cn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.Parameters.AddWithValue("@nombre", nombreComercial);
                cmd.Parameters.AddWithValue("@direccion", (object)direccion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@estado", string.IsNullOrWhiteSpace(estado) ? "Activo" : estado);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            using (var cmd = new MySqlCommand("DELETE FROM establecimientos WHERE id=@id", cn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
