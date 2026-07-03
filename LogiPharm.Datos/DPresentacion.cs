using MySqlConnector;
using System;
using System.Data;
using System.Collections.Generic;
using LogiPharm.Entidades;

namespace LogiPharm.Datos
{
    public class DPresentacion
    {
        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string sql = "SELECT id, nombre, descripcion, activo FROM presentaciones WHERE anulado = 0 ORDER BY nombre ASC;";
                    using (var da = new MySqlDataAdapter(sql, cn))
                    {
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar presentaciones: " + ex.Message);
                }
            }
            return dt;
        }

        public DataTable ListarActivas()
        {
            DataTable dt = new DataTable();
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string sql = "SELECT id, nombre FROM presentaciones WHERE anulado = 0 AND activo = 1 ORDER BY nombre ASC;";
                    using (var da = new MySqlDataAdapter(sql, cn))
                    {
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar presentaciones activas: " + ex.Message);
                }
            }
            return dt;
        }

        public DataTable Buscar(string criterio)
        {
            DataTable dt = new DataTable();
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string sql = @"SELECT id, nombre, descripcion, activo 
                                   FROM presentaciones 
                                   WHERE anulado = 0 AND (nombre LIKE @criterio OR descripcion LIKE @criterio) 
                                   ORDER BY nombre ASC;";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@criterio", $"%{criterio}%");
                        using (var da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar presentaciones: " + ex.Message);
                }
            }
            return dt;
        }

        public bool Insertar(EPresentacion presentacion)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string sql = "INSERT INTO presentaciones (nombre, descripcion, activo) VALUES (@nombre, @descripcion, @activo);";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", presentacion.Nombre);
                        cmd.Parameters.AddWithValue("@descripcion", (object)presentacion.Descripcion ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@activo", presentacion.Activo);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al guardar presentación: " + ex.Message);
                }
            }
        }

        public bool Actualizar(EPresentacion presentacion)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string sql = "UPDATE presentaciones SET nombre = @nombre, descripcion = @descripcion, activo = @activo WHERE id = @id;";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@id", presentacion.Id);
                        cmd.Parameters.AddWithValue("@nombre", presentacion.Nombre);
                        cmd.Parameters.AddWithValue("@descripcion", (object)presentacion.Descripcion ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@activo", presentacion.Activo);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar presentación: " + ex.Message);
                }
            }
        }

        public bool Eliminar(int id)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    // Eliminación lógica
                    string sql = "UPDATE presentaciones SET anulado = 1 WHERE id = @id;";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar presentación: " + ex.Message);
                }
            }
        }
    }
}
