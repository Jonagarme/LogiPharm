using MySqlConnector;
using System;
using System.Data;
using System.Text;
using LogiPharm.Entidades;

namespace LogiPharm.Datos
{
    public class DLaboratorios
    {
        private bool ExisteColumna(MySqlConnection cn, string tabla, string columna)
        {
            using (var cmd = new MySqlCommand(@"SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = @t AND COLUMN_NAME = @c;", cn))
            {
                cmd.Parameters.AddWithValue("@t", tabla);
                cmd.Parameters.AddWithValue("@c", columna);
                var count = Convert.ToInt64(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        public DataTable Listar()
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                var dt = new DataTable();
                try
                {
                    // Intento preferido con columnas conocidas
                    string sqlPreferido = "SELECT id, codigo, nombre, contacto, telefono, email, direccion, activo FROM laboratorios ORDER BY nombre";
                    using (var da = new MySqlDataAdapter(sqlPreferido, cn))
                    {
                        da.Fill(dt);
                    }
                }
                catch (MySqlException ex) when (ex.Number == 1054) // Unknown column
                {
                    // Fallback: traer todo lo que exista y luego completar columnas faltantes en memoria
                    string sql = "SELECT * FROM laboratorios";
                    // Ordenar por nombre si existe
                    if (ExisteColumna(cn, "laboratorios", "nombre")) sql += " ORDER BY nombre";
                    using (var da = new MySqlDataAdapter(sql, cn))
                    {
                        dt.Clear();
                        da.Fill(dt);
                    }
                }

                // Asegurar columnas esperadas para el binding
                if (!dt.Columns.Contains("id")) dt.Columns.Add("id", typeof(int));
                if (!dt.Columns.Contains("codigo")) dt.Columns.Add("codigo", typeof(string));
                if (!dt.Columns.Contains("nombre")) dt.Columns.Add("nombre", typeof(string));
                if (!dt.Columns.Contains("contacto")) dt.Columns.Add("contacto", typeof(string));
                if (!dt.Columns.Contains("telefono")) dt.Columns.Add("telefono", typeof(string));
                if (!dt.Columns.Contains("email")) dt.Columns.Add("email", typeof(string));
                if (!dt.Columns.Contains("direccion")) dt.Columns.Add("direccion", typeof(string));
                if (!dt.Columns.Contains("activo")) dt.Columns.Add("activo", typeof(bool));

                return dt;
            }
        }

        public void Insertar(ELaboratorio e)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();

                bool hasCodigo = ExisteColumna(cn, "laboratorios", "codigo");
                bool hasContacto = ExisteColumna(cn, "laboratorios", "contacto");
                bool hasTelefono = ExisteColumna(cn, "laboratorios", "telefono");
                bool hasEmail = ExisteColumna(cn, "laboratorios", "email");
                bool hasDireccion = ExisteColumna(cn, "laboratorios", "direccion");
                bool hasActivo = ExisteColumna(cn, "laboratorios", "activo");

                var cols = new StringBuilder();
                var vals = new StringBuilder();

                // nombre es obligatorio
                cols.Append("nombre");
                vals.Append("@nombre");

                if (hasCodigo) { cols.Append(", codigo"); vals.Append(", @codigo"); }
                if (hasContacto) { cols.Append(", contacto"); vals.Append(", @contacto"); }
                if (hasTelefono) { cols.Append(", telefono"); vals.Append(", @telefono"); }
                if (hasEmail) { cols.Append(", email"); vals.Append(", @email"); }
                if (hasDireccion) { cols.Append(", direccion"); vals.Append(", @direccion"); }
                if (hasActivo) { cols.Append(", activo"); vals.Append(", @activo"); }

                string sql = $"INSERT INTO laboratorios ({cols}) VALUES ({vals})";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", e.Nombre);
                    if (hasCodigo) cmd.Parameters.AddWithValue("@codigo", (object)e.Codigo ?? DBNull.Value);
                    if (hasContacto) cmd.Parameters.AddWithValue("@contacto", (object)e.Contacto ?? DBNull.Value);
                    if (hasTelefono) cmd.Parameters.AddWithValue("@telefono", (object)e.Telefono ?? DBNull.Value);
                    if (hasEmail) cmd.Parameters.AddWithValue("@email", (object)e.Email ?? DBNull.Value);
                    if (hasDireccion) cmd.Parameters.AddWithValue("@direccion", (object)e.Direccion ?? DBNull.Value);
                    if (hasActivo) cmd.Parameters.AddWithValue("@activo", e.Activo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Actualizar(ELaboratorio e)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();

                bool hasCodigo = ExisteColumna(cn, "laboratorios", "codigo");
                bool hasContacto = ExisteColumna(cn, "laboratorios", "contacto");
                bool hasTelefono = ExisteColumna(cn, "laboratorios", "telefono");
                bool hasEmail = ExisteColumna(cn, "laboratorios", "email");
                bool hasDireccion = ExisteColumna(cn, "laboratorios", "direccion");
                bool hasActivo = ExisteColumna(cn, "laboratorios", "activo");

                var sets = new StringBuilder();
                sets.Append("nombre=@nombre");
                if (hasCodigo) sets.Append(", codigo=@codigo");
                if (hasContacto) sets.Append(", contacto=@contacto");
                if (hasTelefono) sets.Append(", telefono=@telefono");
                if (hasEmail) sets.Append(", email=@email");
                if (hasDireccion) sets.Append(", direccion=@direccion");
                if (hasActivo) sets.Append(", activo=@activo");

                string sql = $"UPDATE laboratorios SET {sets} WHERE id=@id";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", e.Id);
                    cmd.Parameters.AddWithValue("@nombre", e.Nombre);
                    if (hasCodigo) cmd.Parameters.AddWithValue("@codigo", (object)e.Codigo ?? DBNull.Value);
                    if (hasContacto) cmd.Parameters.AddWithValue("@contacto", (object)e.Contacto ?? DBNull.Value);
                    if (hasTelefono) cmd.Parameters.AddWithValue("@telefono", (object)e.Telefono ?? DBNull.Value);
                    if (hasEmail) cmd.Parameters.AddWithValue("@email", (object)e.Email ?? DBNull.Value);
                    if (hasDireccion) cmd.Parameters.AddWithValue("@direccion", (object)e.Direccion ?? DBNull.Value);
                    if (hasActivo) cmd.Parameters.AddWithValue("@activo", e.Activo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Eliminar(int id)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                const string sql = @"DELETE FROM laboratorios WHERE id=@id";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
