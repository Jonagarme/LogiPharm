using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using LogiPharm.Entidades;
using LogiPharm.Presentacion.Utilidades; // Asegúrate de tener tu clase SesionActual aquí

namespace LogiPharm.Datos
{
    public class DCierreCaja
    {
        //✅ NUEVO: Obtiene la primera caja que esté abierta (automático)
        public DataRow ObtenerPrimeraCajaAbierta()
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string sql = @"SELECT cc.idCaja, c.nombre AS nombreCaja
                               FROM cierres_caja cc
                               INNER JOIN cajas c ON c.id = cc.idCaja
                               WHERE cc.estado = 'ABIERTA'
                               ORDER BY cc.fechaApertura DESC
                               LIMIT 1;";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    var dt = new DataTable();
                    new MySqlDataAdapter(cmd).Fill(dt);
                    return dt.Rows.Count > 0 ? dt.Rows[0] : null;
                }
            }
        }

        //✅ VERIFICA EN 'cierres_caja' USANDO 'estado' (sin restricción de fecha)
        public bool VerificarCajaAbiertaHoy(int idCaja)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string sql = @"SELECT COUNT(*) 
                               FROM cierres_caja 
                               WHERE estado = 'ABIERTA' 
                                 AND idCaja = @idCaja";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idCaja", idCaja);
                    cn.Open();
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        //✅ BUSCA LA APERTURA ACTIVA EN 'cierres_caja'
        // En DCierreCaja.cs
        public DataRow ObtenerDatosAperturaAbierta(int idCaja) // Cambiado a int
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                // La consulta ya esperaba un INT para idCaja, así que está perfecta.
                string sql = @"SELECT * FROM cierres_caja
                       WHERE estado = 'ABIERTA' AND idCaja = @idCaja
                       ORDER BY fechaApertura DESC LIMIT 1;";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idCaja", idCaja); // Ahora el tipo coincide
                    var dt = new DataTable();
                    new MySqlDataAdapter(cmd).Fill(dt);
                    return dt.Rows.Count > 0 ? dt.Rows[0] : null;
                }
            }
        }

        //✅ INSERTA UNA NUEVA APERTURA EN 'cierres_caja'
        public void RegistrarApertura(decimal montoInicial, int idUsuario, int idCaja)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string sql = @"INSERT INTO cierres_caja 
                               (idCaja, idUsuarioApertura, fechaApertura, saldoInicial, estado, creadoPor, creadoDate) 
                               VALUES 
                               (@idCaja, @idUsuario, NOW(), @saldoInicial, 'ABIERTA', @idUsuario, NOW())";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idCaja", idCaja);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@saldoInicial", montoInicial);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //✅ ESTE MÉTODO OBTIENE EL TOTAL DE VENTAS PARA UN CIERRE ESPECÍFICO
        public decimal ObtenerTotalVentas(int idCierreCaja)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string sql = @"SELECT IFNULL(SUM(total), 0) 
                               FROM facturas_venta 
                               WHERE idCierreCaja = @idCierreCaja AND anulado = 0"; // Usamos 'anulado' de tu tabla
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idCierreCaja", idCierreCaja);
                    cn.Open();
                    object resultado = cmd.ExecuteScalar();
                    return Convert.ToDecimal(resultado ?? 0);
                }
            }
        }

        //✅ NUEVO: Calcula los ingresos del sistema (ventas) para un cierre
        public decimal CalcularIngresosSistema(int idCierreCaja)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string sql = @"SELECT IFNULL(SUM(total), 0) 
                               FROM facturas_venta 
                               WHERE idCierreCaja = @idCierreCaja AND anulado = 0";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idCierreCaja", idCierreCaja);
                    cn.Open();
                    object resultado = cmd.ExecuteScalar();
                    return Convert.ToDecimal(resultado ?? 0);
                }
            }
        }

        //✅ NUEVO: Calcula los egresos del sistema para un cierre
        // Por ahora retorna 0, pero puedes agregar lógica para gastos/retiros si los tienes
        public decimal CalcularEgresosSistema(int idCierreCaja)
        {
            // TODO: Si tienes una tabla de egresos/retiros de caja, calcúlalos aquí
            return 0m;
        }

        //✅ NUEVO: Actualiza los totales del sistema en el registro de cierre
        public void ActualizarTotalesSistema(int idCierreCaja)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                decimal ingresos = CalcularIngresosSistema(idCierreCaja);
                decimal egresos = CalcularEgresosSistema(idCierreCaja);

                string sql = @"UPDATE cierres_caja SET
                                totalIngresosSistema = @ingresos,
                                totalEgresosSistema = @egresos
                               WHERE id = @idCierreCaja";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idCierreCaja", idCierreCaja);
                    cmd.Parameters.AddWithValue("@ingresos", ingresos);
                    cmd.Parameters.AddWithValue("@egresos", egresos);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //✅ ESTE MÉTODO ACTUALIZA EL REGISTRO PARA CERRAR LA CAJA
        public void CerrarCaja(int idCierre, decimal totalContado, decimal saldoTeorico, decimal diferencia, int idUsuarioCierre)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                // Primero actualizamos los totales del sistema
                ActualizarTotalesSistema(idCierre);

                // Ahora cerramos la caja con todos los datos actualizados
                string sql = @"UPDATE cierres_caja SET
                                fechaCierre = NOW(),
                                totalContadoFisico = @totalContado,
                                saldoTeoricoSistema = @saldoTeorico,
                                diferencia = @diferencia,
                                idUsuarioCierre = @idUsuarioCierre,
                                estado = 'CERRADA',
                                editadoPor = @idUsuarioCierre,
                                editadoDate = NOW()
                               WHERE id = @idCierre";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idCierre", idCierre);
                    cmd.Parameters.AddWithValue("@totalContado", totalContado);
                    cmd.Parameters.AddWithValue("@saldoTeorico", saldoTeorico);
                    cmd.Parameters.AddWithValue("@diferencia", diferencia);
                    cmd.Parameters.AddWithValue("@idUsuarioCierre", idUsuarioCierre);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ==========================================
        // NUEVOS MÉTODOS PARA CIERRES MENSUALES Y ANUALES
        // ==========================================

        /// <summary>
        /// Obtiene todos los cierres de caja de un rango de fechas
        /// </summary>
        public List<ECierreCaja> ObtenerCierresPorRango(DateTime fechaInicio, DateTime fechaFin, int? idCaja = null)
        {
            List<ECierreCaja> lista = new List<ECierreCaja>();
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string sql = @"
                     SELECT c.*, u1.nombreUsuario AS NombreUsuarioApertura, 
                            u2.nombreUsuario AS NombreUsuarioCierre
                     FROM cierres_caja c
                     LEFT JOIN usuarios u1 ON c.idUsuarioApertura = u1.id
                     LEFT JOIN usuarios u2 ON c.idUsuarioCierre = u2.id
                     WHERE c.fechaApertura BETWEEN @fechaInicio AND @fechaFin
                     AND c.anulado = 0";
                
                if (idCaja.HasValue)
                    sql += " AND c.idCaja = @idCaja";
                
                sql += " ORDER BY c.fechaApertura DESC";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin);
                    if (idCaja.HasValue)
                        cmd.Parameters.AddWithValue("@idCaja", idCaja.Value);
                    
                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ECierreCaja
                            {
                                Id = dr.GetInt64("id"),
                                IdCaja = dr.GetInt32("idCaja"),
                                IdUsuarioApertura = dr.GetInt32("idUsuarioApertura"),
                                IdUsuarioCierre = dr["idUsuarioCierre"] != DBNull.Value ? (int?)dr.GetInt32("idUsuarioCierre") : null,
                                FechaApertura = dr.GetDateTime("fechaApertura"),
                                FechaCierre = dr["fechaCierre"] != DBNull.Value ? (DateTime?)dr.GetDateTime("fechaCierre") : null,
                                SaldoInicial = dr.GetDecimal("saldoInicial"),
                                TotalIngresosSistema = dr["totalIngresosSistema"] != DBNull.Value ? dr.GetDecimal("totalIngresosSistema") : 0,
                                TotalEgresosSistema = dr["totalEgresosSistema"] != DBNull.Value ? dr.GetDecimal("totalEgresosSistema") : 0,
                                SaldoTeoricoSistema = dr["saldoTeoricoSistema"] != DBNull.Value ? dr.GetDecimal("saldoTeoricoSistema") : 0,
                                TotalContadoFisico = dr["totalContadoFisico"] != DBNull.Value ? dr.GetDecimal("totalContadoFisico") : 0,
                                Diferencia = dr["diferencia"] != DBNull.Value ? dr.GetDecimal("diferencia") : 0,
                                Estado = dr["estado"].ToString(),
                                NombreUsuarioApertura = dr["NombreUsuarioApertura"]?.ToString(),
                                NombreUsuarioCierre = dr["NombreUsuarioCierre"]?.ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }

        /// <summary>
        /// Obtiene resumen de cierres diarios de un mes
        /// </summary>
        public DataTable ObtenerResumenCierresMes(int año, int mes, int? idCaja = null)
        {
            DataTable tabla = new DataTable();
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string sql = @"
                    SELECT 
                        DATE(fechaApertura) AS Fecha,
                        COUNT(*) AS TotalCierres,
                        SUM(saldoInicial) AS TotalSaldoInicial,
                        SUM(totalIngresosSistema) AS TotalIngresos,
                        SUM(totalEgresosSistema) AS TotalEgresos,
                        SUM(saldoTeoricoSistema) AS TotalSaldoTeorico,
                        SUM(totalContadoFisico) AS TotalContado,
                        SUM(diferencia) AS TotalDiferencia,
                        SUM(CASE WHEN estado = 'ABIERTA' THEN 1 ELSE 0 END) AS CajasAbiertas
                    FROM cierres_caja
                    WHERE YEAR(fechaApertura) = @año 
                      AND MONTH(fechaApertura) = @mes
                      AND anulado = 0";
                
                if (idCaja.HasValue)
                    sql += " AND idCaja = @idCaja";
                
                sql += @"
                    GROUP BY DATE(fechaApertura)
                    ORDER BY DATE(fechaApertura) DESC";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@año", año);
                    cmd.Parameters.AddWithValue("@mes", mes);
                    if (idCaja.HasValue)
                        cmd.Parameters.AddWithValue("@idCaja", idCaja.Value);
                    
                    using (var da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(tabla);
                    }
                }
            }
            return tabla;
        }

        /// <summary>
        /// Obtiene resumen de cierres mensuales de un año
        /// </summary>
        public DataTable ObtenerResumenCierresAño(int año, int? idCaja = null)
        {
            DataTable tabla = new DataTable();
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string sql = @"
                    SELECT 
                        MONTH(fechaApertura) AS Mes,
                        MONTHNAME(fechaApertura) AS NombreMes,
                        COUNT(*) AS TotalCierres,
                        SUM(saldoInicial) AS TotalSaldoInicial,
                        SUM(totalIngresosSistema) AS TotalIngresos,
                        SUM(totalEgresosSistema) AS TotalEgresos,
                        SUM(saldoTeoricoSistema) AS TotalSaldoTeorico,
                        SUM(totalContadoFisico) AS TotalContado,
                        SUM(diferencia) AS TotalDiferencia,
                        AVG(diferencia) AS PromedioDiferencia
                    FROM cierres_caja
                    WHERE YEAR(fechaApertura) = @año
                      AND anulado = 0";
                
                if (idCaja.HasValue)
                    sql += " AND idCaja = @idCaja";
                
                sql += @"
                    GROUP BY MONTH(fechaApertura), MONTHNAME(fechaApertura)
                    ORDER BY MONTH(fechaApertura)";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@año", año);
                    if (idCaja.HasValue)
                        cmd.Parameters.AddWithValue("@idCaja", idCaja.Value);
                    
                    using (var da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(tabla);
                    }
                }
            }
            return tabla;
        }

        /// <summary>
        /// Obtiene un cierre específico por ID
        /// </summary>
        public ECierreCaja ObtenerCierrePorId(long idCierre)
        {
            ECierreCaja cierre = null;
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string sql = @"
                    SELECT c.*, u1.nombreUsuario AS NombreUsuarioApertura, 
                           u2.nombreUsuario AS NombreUsuarioCierre
                    FROM cierres_caja c
                    LEFT JOIN usuarios u1 ON c.idUsuarioApertura = u1.id
                    LEFT JOIN usuarios u2 ON c.idUsuarioCierre = u2.id
                    WHERE c.id = @id";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", idCierre);
                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            cierre = new ECierreCaja
                            {
                                Id = dr.GetInt64("id"),
                                IdCaja = dr.GetInt32("idCaja"),
                                IdUsuarioApertura = dr.GetInt32("idUsuarioApertura"),
                                IdUsuarioCierre = dr["idUsuarioCierre"] != DBNull.Value ? (int?)dr.GetInt32("idUsuarioCierre") : null,
                                FechaApertura = dr.GetDateTime("fechaApertura"),
                                FechaCierre = dr["fechaCierre"] != DBNull.Value ? (DateTime?)dr.GetDateTime("fechaCierre") : null,
                                SaldoInicial = dr.GetDecimal("saldoInicial"),
                                TotalIngresosSistema = dr["totalIngresosSistema"] != DBNull.Value ? dr.GetDecimal("totalIngresosSistema") : 0,
                                TotalEgresosSistema = dr["totalEgresosSistema"] != DBNull.Value ? dr.GetDecimal("totalEgresosSistema") : 0,
                                SaldoTeoricoSistema = dr["saldoTeoricoSistema"] != DBNull.Value ? dr.GetDecimal("saldoTeoricoSistema") : 0,
                                TotalContadoFisico = dr["totalContadoFisico"] != DBNull.Value ? dr.GetDecimal("totalContadoFisico") : 0,
                                Diferencia = dr["diferencia"] != DBNull.Value ? dr.GetDecimal("diferencia") : 0,
                                Estado = dr["estado"].ToString(),
                                NombreUsuarioApertura = dr["NombreUsuarioApertura"]?.ToString(),
                                NombreUsuarioCierre = dr["NombreUsuarioCierre"]?.ToString()
                            };
                        }
                    }
                }
            }
            return cierre;
        }

        /// <summary>
        /// Obtiene estadísticas generales de caja
        /// </summary>
        public Dictionary<string, decimal> ObtenerEstadisticasCaja(int? idCaja = null, DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            var estadisticas = new Dictionary<string, decimal>();
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string sql = @"
                    SELECT 
                        COUNT(*) AS TotalCierres,
                        SUM(CASE WHEN estado = 'CERRADA' THEN 1 ELSE 0 END) AS CierresCerrados,
                        SUM(saldoInicial) AS TotalSaldoInicial,
                        SUM(totalIngresosSistema) AS TotalIngresos,
                        SUM(totalEgresosSistema) AS TotalEgresos,
                        SUM(diferencia) AS DiferenciaTotal,
                        AVG(diferencia) AS DiferenciaPromedio,
                        MAX(diferencia) AS DiferenciaMaxima,
                        MIN(diferencia) AS DiferenciaMinima
                    FROM cierres_caja
                    WHERE anulado = 0";
                
                if (idCaja.HasValue)
                    sql += " AND idCaja = @idCaja";
                if (fechaInicio.HasValue)
                    sql += " AND fechaApertura >= @fechaInicio";
                if (fechaFin.HasValue)
                    sql += " AND fechaApertura <= @fechaFin";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    if (idCaja.HasValue)
                        cmd.Parameters.AddWithValue("@idCaja", idCaja.Value);
                    if (fechaInicio.HasValue)
                        cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio.Value);
                    if (fechaFin.HasValue)
                        cmd.Parameters.AddWithValue("@fechaFin", fechaFin.Value);
                    
                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            estadisticas["TotalCierres"] = dr["TotalCierres"] != DBNull.Value ? Convert.ToDecimal(dr["TotalCierres"]) : 0;
                            estadisticas["CierresCerrados"] = dr["CierresCerrados"] != DBNull.Value ? Convert.ToDecimal(dr["CierresCerrados"]) : 0;
                            estadisticas["TotalSaldoInicial"] = dr["TotalSaldoInicial"] != DBNull.Value ? Convert.ToDecimal(dr["TotalSaldoInicial"]) : 0;
                            estadisticas["TotalIngresos"] = dr["TotalIngresos"] != DBNull.Value ? Convert.ToDecimal(dr["TotalIngresos"]) : 0;
                            estadisticas["TotalEgresos"] = dr["TotalEgresos"] != DBNull.Value ? Convert.ToDecimal(dr["TotalEgresos"]) : 0;
                            estadisticas["DiferenciaTotal"] = dr["DiferenciaTotal"] != DBNull.Value ? Convert.ToDecimal(dr["DiferenciaTotal"]) : 0;
                            estadisticas["DiferenciaPromedio"] = dr["DiferenciaPromedio"] != DBNull.Value ? Convert.ToDecimal(dr["DiferenciaPromedio"]) : 0;
                            estadisticas["DiferenciaMaxima"] = dr["DiferenciaMaxima"] != DBNull.Value ? Convert.ToDecimal(dr["DiferenciaMaxima"]) : 0;
                            estadisticas["DiferenciaMinima"] = dr["DiferenciaMinima"] != DBNull.Value ? Convert.ToDecimal(dr["DiferenciaMinima"]) : 0;
                        }
                    }
                }
            }
            return estadisticas;
        }
    }
}