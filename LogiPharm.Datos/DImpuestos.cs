using MySqlConnector;
using System;
using System.Data;
using LogiPharm.Entidades;

namespace LogiPharm.Datos
{
    public class DImpuestos
    {
        public EImpuesto ObtenerImpuestoVigente(string codigo)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                const string sql = @"
                SELECT id, codigo, nombre, porcentaje, vigenteDesde, vigenteHasta, activo, descripcion
                FROM impuestos
                WHERE codigo = @codigo AND activo = 1
                  AND (vigenteDesde IS NULL OR vigenteDesde <= CURRENT_DATE())
                  AND (vigenteHasta IS NULL OR vigenteHasta >= CURRENT_DATE())
                ORDER BY vigenteDesde DESC
                LIMIT 1;";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return new EImpuesto
                            {
                                Id = Convert.ToInt32(dr["id"]),
                                Codigo = Convert.ToString(dr["codigo"]),
                                Nombre = Convert.ToString(dr["nombre"]),
                                Porcentaje = Convert.ToDecimal(dr["porcentaje"]),
                                VigenteDesde = dr["vigenteDesde"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["vigenteDesde"]),
                                VigenteHasta = dr["vigenteHasta"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["vigenteHasta"]),
                                Activo = Convert.ToBoolean(dr["activo"]),
                                Descripcion = dr["descripcion"] == DBNull.Value ? null : Convert.ToString(dr["descripcion"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        public DataTable ListarImpuestos()
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                const string sql = @"SELECT id, codigo, nombre, porcentaje, vigenteDesde, vigenteHasta, activo, descripcion FROM impuestos ORDER BY codigo, vigenteDesde DESC";
                using (var da = new MySqlDataAdapter(sql, cn))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public void GuardarImpuesto(EImpuesto imp)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                const string sql = @"
                INSERT INTO impuestos (codigo, nombre, porcentaje, vigenteDesde, vigenteHasta, activo, descripcion)
                VALUES (@codigo, @nombre, @porcentaje, @desde, @hasta, @activo, @descripcion);";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@codigo", imp.Codigo);
                    cmd.Parameters.AddWithValue("@nombre", imp.Nombre);
                    cmd.Parameters.AddWithValue("@porcentaje", imp.Porcentaje);
                    cmd.Parameters.AddWithValue("@desde", (object)imp.VigenteDesde ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@hasta", (object)imp.VigenteHasta ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@activo", imp.Activo);
                    cmd.Parameters.AddWithValue("@descripcion", (object)imp.Descripcion ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarImpuesto(EImpuesto imp)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                const string sql = @"
                UPDATE impuestos SET nombre=@nombre, porcentaje=@porcentaje, vigenteDesde=@desde, vigenteHasta=@hasta, activo=@activo, descripcion=@descripcion
                WHERE id = @id;";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", imp.Id);
                    cmd.Parameters.AddWithValue("@nombre", imp.Nombre);
                    cmd.Parameters.AddWithValue("@porcentaje", imp.Porcentaje);
                    cmd.Parameters.AddWithValue("@desde", (object)imp.VigenteDesde ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@hasta", (object)imp.VigenteHasta ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@activo", imp.Activo);
                    cmd.Parameters.AddWithValue("@descripcion", (object)imp.Descripcion ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
