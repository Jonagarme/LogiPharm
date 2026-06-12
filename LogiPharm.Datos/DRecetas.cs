using System;
using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using LogiPharm.Entidades;
using CapaDatos;

namespace LogiPharm.Datos
{
    public class DRecetas
    {
        public DataTable Listar(string criterio = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (var con = new MySqlConnection(Conexion.cadena))
                {
                    string sql = @"SELECT id, numero_receta, paciente_nombre, medico_nombre,
                                   fecha_emision, fecha_vencimiento, estado
                                   FROM recetas
                                   WHERE activo = 1
                                   AND (@crit IS NULL OR @crit = ''
                                        OR numero_receta LIKE CONCAT('%', @crit, '%')
                                        OR paciente_nombre LIKE CONCAT('%', @crit, '%')
                                        OR medico_nombre LIKE CONCAT('%', @crit, '%'))
                                   ORDER BY id DESC";
                    using (var cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@crit", (object)criterio ?? DBNull.Value);
                        using (var da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception) { throw; }
            return dt;
        }

        public EReceta ObtenerPorId(int idReceta)
        {
            try
            {
                using (var con = new MySqlConnection(Conexion.cadena))
                {
                    con.Open();

                    string sql = @"SELECT id, numero_receta, id_cliente, paciente_nombre, medico_nombre,
                                   medico_registro, medico_especialidad, fecha_emision, fecha_vencimiento,
                                   estado, observaciones, activo
                                   FROM recetas
                                   WHERE id = @id AND activo = 1";
                    EReceta rec = null;
                    using (var cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", idReceta);
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (!dr.Read()) return null;

                            rec = new EReceta
                            {
                                Id = Convert.ToInt32(dr["id"]),
                                NumeroReceta = dr["numero_receta"] == DBNull.Value ? null : dr["numero_receta"].ToString(),
                                IdCliente = dr["id_cliente"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["id_cliente"]),
                                PacienteNombre = dr["paciente_nombre"].ToString(),
                                MedicoNombre = dr["medico_nombre"].ToString(),
                                MedicoRegistro = dr["medico_registro"] == DBNull.Value ? null : dr["medico_registro"].ToString(),
                                MedicoEspecialidad = dr["medico_especialidad"] == DBNull.Value ? null : dr["medico_especialidad"].ToString(),
                                FechaEmision = Convert.ToDateTime(dr["fecha_emision"]),
                                FechaVencimiento = dr["fecha_vencimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["fecha_vencimiento"]),
                                Estado = dr["estado"].ToString(),
                                Observaciones = dr["observaciones"] == DBNull.Value ? null : dr["observaciones"].ToString(),
                                Activo = Convert.ToBoolean(dr["activo"])
                            };
                        }
                    }

                    rec.Detalles = ListarDetalles(idReceta, con);
                    return rec;
                }
            }
            catch (Exception) { throw; }
        }

        private static List<ERecetaDetalle> ListarDetalles(int idReceta, MySqlConnection con)
        {
            var lista = new List<ERecetaDetalle>();
            string sqlDet = @"SELECT id, id_receta, id_producto, producto_nombre, cantidad, indicaciones
                              FROM receta_detalles
                              WHERE id_receta = @id
                              ORDER BY id";
            using (var cmd = new MySqlCommand(sqlDet, con))
            {
                cmd.Parameters.AddWithValue("@id", idReceta);
                using (var da = new MySqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow r in dt.Rows)
                    {
                        lista.Add(new ERecetaDetalle
                        {
                            Id = Convert.ToInt32(r["id"]),
                            IdReceta = Convert.ToInt32(r["id_receta"]),
                            IdProducto = r["id_producto"] == DBNull.Value ? (int?)null : Convert.ToInt32(r["id_producto"]),
                            ProductoNombre = Convert.ToString(r["producto_nombre"]),
                            Cantidad = Convert.ToDecimal(r["cantidad"]),
                            Indicaciones = r["indicaciones"] == DBNull.Value ? null : Convert.ToString(r["indicaciones"])
                        });
                    }
                }
            }
            return lista;
        }

        public bool Insertar(EReceta obj)
        {
            bool respuesta = false;
            try
            {
                using (var con = new MySqlConnection(Conexion.cadena))
                {
                    con.Open();
                    using (var tr = con.BeginTransaction())
                    {
                        try
                        {
                            string sql = @"INSERT INTO recetas 
                                          (numero_receta, id_cliente, paciente_nombre, medico_nombre, 
                                           medico_registro, medico_especialidad, fecha_emision, 
                                           fecha_vencimiento, estado, observaciones, activo) 
                                          VALUES 
                                          (@n_receta, @id_cliente, @paciente, @medico, 
                                           @registro, @especialidad, @f_emision, 
                                           @f_vencimiento, @estado, @obs, 1);
                                          SELECT LAST_INSERT_ID();";

                            int idGenerado = 0;
                            using (var cmd = new MySqlCommand(sql, con, tr))
                            {
                                cmd.Parameters.AddWithValue("@n_receta", obj.NumeroReceta ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@id_cliente", obj.IdCliente ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@paciente", obj.PacienteNombre);
                                cmd.Parameters.AddWithValue("@medico", obj.MedicoNombre);
                                cmd.Parameters.AddWithValue("@registro", obj.MedicoRegistro ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@especialidad", obj.MedicoEspecialidad ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@f_emision", obj.FechaEmision);
                                cmd.Parameters.AddWithValue("@f_vencimiento", obj.FechaVencimiento ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@estado", obj.Estado ?? "Ingresada");
                                cmd.Parameters.AddWithValue("@obs", obj.Observaciones ?? (object)DBNull.Value);

                                idGenerado = Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            if (obj.Detalles != null && obj.Detalles.Count > 0)
                            {
                                string sqlDet = @"INSERT INTO receta_detalles 
                                                  (id_receta, id_producto, producto_nombre, cantidad, indicaciones) 
                                                  VALUES 
                                                  (@id_receta, @id_producto, @producto, @cantidad, @indicaciones)";
                                foreach (var det in obj.Detalles)
                                {
                                    using (var cDet = new MySqlCommand(sqlDet, con, tr))
                                    {
                                        cDet.Parameters.AddWithValue("@id_receta", idGenerado);
                                        cDet.Parameters.AddWithValue("@id_producto", det.IdProducto ?? (object)DBNull.Value);
                                        cDet.Parameters.AddWithValue("@producto", det.ProductoNombre);
                                        cDet.Parameters.AddWithValue("@cantidad", det.Cantidad);
                                        cDet.Parameters.AddWithValue("@indicaciones", det.Indicaciones ?? (object)DBNull.Value);
                                        cDet.ExecuteNonQuery();
                                    }
                                }
                            }

                            tr.Commit();
                            respuesta = true;
                        }
                        catch
                        {
                            tr.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception) { throw; }
            return respuesta;
        }

        public bool Actualizar(EReceta obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (obj.Id <= 0) throw new ArgumentException("Id inválido", nameof(obj));

            try
            {
                using (var con = new MySqlConnection(Conexion.cadena))
                {
                    con.Open();
                    using (var tr = con.BeginTransaction())
                    {
                        try
                        {
                            string sql = @"UPDATE recetas SET
                                           numero_receta = @n_receta,
                                           id_cliente = @id_cliente,
                                           paciente_nombre = @paciente,
                                           medico_nombre = @medico,
                                           medico_registro = @registro,
                                           medico_especialidad = @especialidad,
                                           fecha_emision = @f_emision,
                                           fecha_vencimiento = @f_vencimiento,
                                           estado = @estado,
                                           observaciones = @obs
                                           WHERE id = @id";
                            using (var cmd = new MySqlCommand(sql, con, tr))
                            {
                                cmd.Parameters.AddWithValue("@id", obj.Id);
                                cmd.Parameters.AddWithValue("@n_receta", obj.NumeroReceta ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@id_cliente", obj.IdCliente ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@paciente", obj.PacienteNombre);
                                cmd.Parameters.AddWithValue("@medico", obj.MedicoNombre);
                                cmd.Parameters.AddWithValue("@registro", obj.MedicoRegistro ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@especialidad", obj.MedicoEspecialidad ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@f_emision", obj.FechaEmision);
                                cmd.Parameters.AddWithValue("@f_vencimiento", obj.FechaVencimiento ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@estado", obj.Estado ?? "Ingresada");
                                cmd.Parameters.AddWithValue("@obs", obj.Observaciones ?? (object)DBNull.Value);
                                cmd.ExecuteNonQuery();
                            }

                            using (var cmdDel = new MySqlCommand("DELETE FROM receta_detalles WHERE id_receta = @id", con, tr))
                            {
                                cmdDel.Parameters.AddWithValue("@id", obj.Id);
                                cmdDel.ExecuteNonQuery();
                            }

                            if (obj.Detalles != null && obj.Detalles.Count > 0)
                            {
                                string sqlDet = @"INSERT INTO receta_detalles
                                                  (id_receta, id_producto, producto_nombre, cantidad, indicaciones)
                                                  VALUES
                                                  (@id_receta, @id_producto, @producto, @cantidad, @indicaciones)";
                                foreach (var det in obj.Detalles)
                                {
                                    using (var cDet = new MySqlCommand(sqlDet, con, tr))
                                    {
                                        cDet.Parameters.AddWithValue("@id_receta", obj.Id);
                                        cDet.Parameters.AddWithValue("@id_producto", det.IdProducto ?? (object)DBNull.Value);
                                        cDet.Parameters.AddWithValue("@producto", det.ProductoNombre);
                                        cDet.Parameters.AddWithValue("@cantidad", det.Cantidad);
                                        cDet.Parameters.AddWithValue("@indicaciones", det.Indicaciones ?? (object)DBNull.Value);
                                        cDet.ExecuteNonQuery();
                                    }
                                }
                            }

                            tr.Commit();
                            return true;
                        }
                        catch
                        {
                            tr.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception) { throw; }
        }

        public bool Eliminar(int idReceta)
        {
            try
            {
                using (var con = new MySqlConnection(Conexion.cadena))
                {
                    con.Open();
                    using (var cmd = new MySqlCommand("UPDATE recetas SET activo = 0 WHERE id = @id", con))
                    {
                        cmd.Parameters.AddWithValue("@id", idReceta);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception) { throw; }
        }

        public bool CambiarEstado(int idReceta, string nuevoEstado)
        {
            try
            {
                using (var con = new MySqlConnection(Conexion.cadena))
                {
                    con.Open();
                    string sql = "UPDATE recetas SET estado = @est WHERE id = @id";
                    using (var cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@est", nuevoEstado);
                        cmd.Parameters.AddWithValue("@id", idReceta);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception) { throw; }
        }
    }
}
