using MySqlConnector;
using System;
using System.Data;
using System.Collections.Generic;
using LogiPharm.Entidades;

namespace LogiPharm.Datos
{
    public class DPrincipioActivo
    {
        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string sql = "SELECT id, nombre, descripcion, activo FROM principios_activos WHERE anulado = 0 ORDER BY nombre ASC;";
                    using (var da = new MySqlDataAdapter(sql, cn))
                    {
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar principios activos: " + ex.Message);
                }
            }
            return dt;
        }

        public DataTable ListarActivos()
        {
            DataTable dt = new DataTable();
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string sql = "SELECT id, nombre FROM principios_activos WHERE anulado = 0 AND activo = 1 ORDER BY nombre ASC;";
                    using (var da = new MySqlDataAdapter(sql, cn))
                    {
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar principios activos activos: " + ex.Message);
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
                                   FROM principios_activos 
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
                    throw new Exception("Error al buscar principios activos: " + ex.Message);
                }
            }
            return dt;
        }

        public bool Insertar(EPrincipioActivo principio)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string sql = "INSERT INTO principios_activos (nombre, descripcion, activo) VALUES (@nombre, @descripcion, @activo);";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", principio.Nombre);
                        cmd.Parameters.AddWithValue("@descripcion", (object)principio.Descripcion ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@activo", principio.Activo);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al guardar principio activo: " + ex.Message);
                }
            }
        }

        public bool Actualizar(EPrincipioActivo principio)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string sql = "UPDATE principios_activos SET nombre = @nombre, descripcion = @descripcion, activo = @activo WHERE id = @id;";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@id", principio.Id);
                        cmd.Parameters.AddWithValue("@nombre", principio.Nombre);
                        cmd.Parameters.AddWithValue("@descripcion", (object)principio.Descripcion ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@activo", principio.Activo);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar principio activo: " + ex.Message);
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
                    // Eliminación lógica (anulado = 1)
                    string sql = "UPDATE principios_activos SET anulado = 1 WHERE id = @id;";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar principio activo: " + ex.Message);
                }
            }
        }
    }
}
