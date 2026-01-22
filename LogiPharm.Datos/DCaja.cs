using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using LogiPharm.Entidades;

namespace LogiPharm.Datos
{
    public class DCaja
    {
        /// <summary>
        /// Obtiene todas las cajas (incluyendo anuladas opcionalmente)
        /// </summary>
        public List<ECaja> ObtenerTodas(bool incluirAnuladas = false)
        {
            List<ECaja> lista = new List<ECaja>();
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string sql = @"
                    SELECT c.*, 
                           u1.nombreUsuario AS UsuarioCreador,
                           u2.nombreUsuario AS UsuarioEditor,
                           (SELECT COUNT(*) FROM cierres_caja cc 
                            WHERE cc.idCaja = c.id AND cc.estado = 'ABIERTA' AND cc.anulado = 0) AS TieneAperturaActiva
                    FROM cajas c
                    LEFT JOIN usuarios u1 ON c.creadoPor = u1.id
                    LEFT JOIN usuarios u2 ON c.editadoPor = u2.id";
                
                if (!incluirAnuladas)
                    sql += " WHERE c.anulado = 0";
                
                sql += " ORDER BY c.codigo";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ECaja
                            {
                                Id = dr.GetInt32("id"),
                                Codigo = dr["codigo"]?.ToString(),
                                Nombre = dr["nombre"]?.ToString(),
                                Descripcion = dr["descripcion"]?.ToString(),
                                Anulado = dr["anulado"] != DBNull.Value && Convert.ToBoolean(dr["anulado"]),
                                Activa = dr["activa"] != DBNull.Value && Convert.ToBoolean(dr["activa"]),
                                IdUbicacion = dr["idUbicacion"] != DBNull.Value ? (int?)dr.GetInt32("idUbicacion") : null,
                                CreadoPor = dr.GetInt32("creadoPor"),
                                CreadoDate = dr.GetDateTime("creadoDate"),
                                EditadoPor = dr["editadoPor"] != DBNull.Value ? (int?)dr.GetInt32("editadoPor") : null,
                                EditadoDate = dr["editadoDate"] != DBNull.Value ? (DateTime?)dr.GetDateTime("editadoDate") : null,
                                UsuarioCreador = dr["UsuarioCreador"]?.ToString(),
                                UsuarioEditor = dr["UsuarioEditor"]?.ToString(),
                                TieneAperturaActiva = Convert.ToInt32(dr["TieneAperturaActiva"]) > 0
                            });
                        }
                    }
                }
            }
            return lista;
        }

        /// <summary>
        /// Obtiene una caja por ID con información del estado actual
        /// </summary>
        public ECaja ObtenerPorId(int id)
        {
            ECaja caja = null;
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string sql = @"
                    SELECT c.*, 
                           u1.nombreUsuario AS UsuarioCreador,
                           u2.nombreUsuario AS UsuarioEditor,
                           cc.id AS IdAperturaActiva,
                           cc.fechaApertura AS FechaAperturaActiva,
                           cc.saldoInicial + IFNULL(cc.totalIngresosSistema, 0) - IFNULL(cc.totalEgresosSistema, 0) AS SaldoActual,
                           u3.nombreUsuario AS NombreUsuarioActivo
                    FROM cajas c
                    LEFT JOIN usuarios u1 ON c.creadoPor = u1.id
                    LEFT JOIN usuarios u2 ON c.editadoPor = u2.id
                    LEFT JOIN cierres_caja cc ON cc.idCaja = c.id AND cc.estado = 'ABIERTA' AND cc.anulado = 0
                    LEFT JOIN usuarios u3 ON cc.idUsuarioApertura = u3.id
                    WHERE c.id = @id";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            caja = new ECaja
                            {
                                Id = dr.GetInt32("id"),
                                Codigo = dr["codigo"]?.ToString(),
                                Nombre = dr["nombre"]?.ToString(),
                                Descripcion = dr["descripcion"]?.ToString(),
                                Anulado = dr["anulado"] != DBNull.Value && Convert.ToBoolean(dr["anulado"]),
                                Activa = dr["activa"] != DBNull.Value && Convert.ToBoolean(dr["activa"]),
                                IdUbicacion = dr["idUbicacion"] != DBNull.Value ? (int?)dr.GetInt32("idUbicacion") : null,
                                CreadoPor = dr.GetInt32("creadoPor"),
                                CreadoDate = dr.GetDateTime("creadoDate"),
                                EditadoPor = dr["editadoPor"] != DBNull.Value ? (int?)dr.GetInt32("editadoPor") : null,
                                EditadoDate = dr["editadoDate"] != DBNull.Value ? (DateTime?)dr.GetDateTime("editadoDate") : null,
                                UsuarioCreador = dr["UsuarioCreador"]?.ToString(),
                                UsuarioEditor = dr["UsuarioEditor"]?.ToString(),
                                IdAperturaActiva = dr["IdAperturaActiva"] != DBNull.Value ? (long?)dr.GetInt64("IdAperturaActiva") : null,
                                FechaAperturaActiva = dr["FechaAperturaActiva"] != DBNull.Value ? (DateTime?)dr.GetDateTime("FechaAperturaActiva") : null,
                                SaldoActual = dr["SaldoActual"] != DBNull.Value ? (decimal?)Convert.ToDecimal(dr["SaldoActual"]) : null,
                                NombreUsuarioActivo = dr["NombreUsuarioActivo"]?.ToString(),
                                TieneAperturaActiva = dr["IdAperturaActiva"] != DBNull.Value
                            };
                        }
                    }
                }
            }
            return caja;
        }

        /// <summary>
        /// Obtiene cajas activas (no anuladas y marcadas como activas)
        /// </summary>
        public List<ECaja> ObtenerActivas()
        {
            List<ECaja> lista = new List<ECaja>();
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string sql = @"
                    SELECT c.*, 
                           (SELECT COUNT(*) FROM cierres_caja cc 
                            WHERE cc.idCaja = c.id AND cc.estado = 'ABIERTA' AND cc.anulado = 0) AS TieneAperturaActiva
                    FROM cajas c
                    WHERE c.anulado = 0 AND c.activa = 1
                    ORDER BY c.codigo";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ECaja
                            {
                                Id = dr.GetInt32("id"),
                                Codigo = dr["codigo"]?.ToString(),
                                Nombre = dr["nombre"]?.ToString(),
                                Descripcion = dr["descripcion"]?.ToString(),
                                Anulado = false,
                                Activa = true,
                                IdUbicacion = dr["idUbicacion"] != DBNull.Value ? (int?)dr.GetInt32("idUbicacion") : null,
                                TieneAperturaActiva = Convert.ToInt32(dr["TieneAperturaActiva"]) > 0
                            });
                        }
                    }
                }
            }
            return lista;
        }

        /// <summary>
        /// Inserta una nueva caja
        /// </summary>
        public bool Insertar(ECaja caja)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string sql = @"
                    INSERT INTO cajas (codigo, nombre, descripcion, anulado, activa, idUbicacion, creadoPor, creadoDate)
                    VALUES (@codigo, @nombre, @descripcion, @anulado, @activa, @idUbicacion, @creadoPor, @creadoDate)";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@codigo", caja.Codigo);
                    cmd.Parameters.AddWithValue("@nombre", caja.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", (object)caja.Descripcion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@anulado", caja.Anulado);
                    cmd.Parameters.AddWithValue("@activa", caja.Activa);
                    cmd.Parameters.AddWithValue("@idUbicacion", (object)caja.IdUbicacion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@creadoPor", caja.CreadoPor);
                    cmd.Parameters.AddWithValue("@creadoDate", DateTime.Now);
                    
                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Actualiza una caja existente
        /// </summary>
        public bool Actualizar(ECaja caja)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string sql = @"
                    UPDATE cajas SET
                        codigo = @codigo,
                        nombre = @nombre,
                        descripcion = @descripcion,
                        activa = @activa,
                        idUbicacion = @idUbicacion,
                        editadoPor = @editadoPor,
                        editadoDate = @editadoDate
                    WHERE id = @id";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", caja.Id);
                    cmd.Parameters.AddWithValue("@codigo", caja.Codigo);
                    cmd.Parameters.AddWithValue("@nombre", caja.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", (object)caja.Descripcion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@activa", caja.Activa);
                    cmd.Parameters.AddWithValue("@idUbicacion", (object)caja.IdUbicacion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@editadoPor", caja.EditadoPor);
                    cmd.Parameters.AddWithValue("@editadoDate", DateTime.Now);
                    
                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Anula (elimina lógicamente) una caja
        /// </summary>
        public bool Anular(int id, int usuarioId)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string sql = @"
                    UPDATE cajas SET
                        anulado = 1,
                        activa = 0,
                        editadoPor = @editadoPor,
                        editadoDate = @editadoDate
                    WHERE id = @id";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@editadoPor", usuarioId);
                    cmd.Parameters.AddWithValue("@editadoDate", DateTime.Now);
                    
                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Activa/Desactiva una caja
        /// </summary>
        public bool CambiarEstadoActiva(int id, bool activa, int usuarioId)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string sql = @"
                    UPDATE cajas SET
                        activa = @activa,
                        editadoPor = @editadoPor,
                        editadoDate = @editadoDate
                    WHERE id = @id AND anulado = 0";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@activa", activa);
                    cmd.Parameters.AddWithValue("@editadoPor", usuarioId);
                    cmd.Parameters.AddWithValue("@editadoDate", DateTime.Now);
                    
                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Verifica si un código de caja ya existe
        /// </summary>
        public bool ExisteCodigo(string codigo, int? idExcluir = null)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string sql = "SELECT COUNT(*) FROM cajas WHERE codigo = @codigo AND anulado = 0";
                if (idExcluir.HasValue)
                    sql += " AND id != @idExcluir";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    if (idExcluir.HasValue)
                        cmd.Parameters.AddWithValue("@idExcluir", idExcluir.Value);
                    
                    cn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        /// <summary>
        /// Obtiene estadísticas de una caja específica
        /// </summary>
        public Dictionary<string, object> ObtenerEstadisticas(int idCaja, DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            var stats = new Dictionary<string, object>();
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string sql = @"
                    SELECT 
                        COUNT(*) AS TotalCierres,
                        COUNT(CASE WHEN estado = 'CERRADA' THEN 1 END) AS CierresCerrados,
                        SUM(totalIngresosSistema) AS TotalIngresos,
                        SUM(totalEgresosSistema) AS TotalEgresos,
                        SUM(diferencia) AS DiferenciaTotal,
                        AVG(diferencia) AS DiferenciaPromedio
                    FROM cierres_caja
                    WHERE idCaja = @idCaja AND anulado = 0";
                
                if (fechaInicio.HasValue)
                    sql += " AND fechaApertura >= @fechaInicio";
                if (fechaFin.HasValue)
                    sql += " AND fechaApertura <= @fechaFin";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idCaja", idCaja);
                    if (fechaInicio.HasValue)
                        cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio.Value);
                    if (fechaFin.HasValue)
                        cmd.Parameters.AddWithValue("@fechaFin", fechaFin.Value);
                    
                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            stats["TotalCierres"] = dr["TotalCierres"] != DBNull.Value ? Convert.ToInt32(dr["TotalCierres"]) : 0;
                            stats["CierresCerrados"] = dr["CierresCerrados"] != DBNull.Value ? Convert.ToInt32(dr["CierresCerrados"]) : 0;
                            stats["TotalIngresos"] = dr["TotalIngresos"] != DBNull.Value ? Convert.ToDecimal(dr["TotalIngresos"]) : 0m;
                            stats["TotalEgresos"] = dr["TotalEgresos"] != DBNull.Value ? Convert.ToDecimal(dr["TotalEgresos"]) : 0m;
                            stats["DiferenciaTotal"] = dr["DiferenciaTotal"] != DBNull.Value ? Convert.ToDecimal(dr["DiferenciaTotal"]) : 0m;
                            stats["DiferenciaPromedio"] = dr["DiferenciaPromedio"] != DBNull.Value ? Convert.ToDecimal(dr["DiferenciaPromedio"]) : 0m;
                        }
                    }
                }
            }
            return stats;
        }

        /// <summary>
        /// Obtiene todas las cajas con su estado actual (para DataGridView)
        /// </summary>
        public DataTable ObtenerParaListado(bool incluirAnuladas = false)
        {
            DataTable tabla = new DataTable();
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string sql = @"
                    SELECT 
                        c.id AS 'ID',
                        c.codigo AS 'Código',
                        c.nombre AS 'Nombre',
                        c.descripcion AS 'Descripción',
                        CASE 
                            WHEN c.anulado = 1 THEN 'ANULADA'
                            WHEN c.activa = 0 THEN 'INACTIVA'
                            WHEN EXISTS(SELECT 1 FROM cierres_caja cc WHERE cc.idCaja = c.id AND cc.estado = 'ABIERTA' AND cc.anulado = 0) THEN 'ABIERTA'
                            ELSE 'CERRADA'
                        END AS 'Estado',
                        c.activa AS 'Activa',
                        c.anulado AS 'Anulado'
                    FROM cajas c";
                
                if (!incluirAnuladas)
                    sql += " WHERE c.anulado = 0";
                
                sql += " ORDER BY c.codigo";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    using (var da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(tabla);
                    }
                }
            }
            return tabla;
        }
    }
}
