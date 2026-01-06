using CapaDatos;
using LogiPharm.Entidades;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace LogiPharm.Datos
{
    public class DTransferencias
    {
        // =====================
        // LISTAR TRANSFERENCIAS
        // =====================
        public DataTable ListarTransferencias(string filtroEstado = "")
        {
            DataTable tabla = new DataTable();
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                        SELECT 
                            t.id,
                            t.numero_transferencia AS numeroTransferencia,
                            t.fecha_creacion AS fechaTransferencia,
                            uOrigen.nombre AS ubicacionOrigen,
                            uDestino.nombre AS ubicacionDestino,
                            t.motivo,
                            t.estado,
                            t.tipo,
                            t.observaciones
                        FROM inventario_transferenciastock t
                        LEFT JOIN inventario_ubicacion uOrigen ON t.ubicacion_origen_id = uOrigen.id
                        LEFT JOIN inventario_ubicacion uDestino ON t.ubicacion_destino_id = uDestino.id
                        WHERE 1=1";

                    if (!string.IsNullOrWhiteSpace(filtroEstado))
                    {
                        query += " AND t.estado = @estado";
                    }

                    query += " ORDER BY t.fecha_creacion DESC;";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    if (!string.IsNullOrWhiteSpace(filtroEstado))
                    {
                        cmd.Parameters.AddWithValue("@estado", filtroEstado);
                    }

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar transferencias: " + ex.Message);
                }
            }
            return tabla;
        }

        // =====================
        // OBTENER TRANSFERENCIA POR ID CON DETALLE
        // =====================
        public ETransferencia ObtenerPorId(long id)
        {
            ETransferencia transferencia = null;
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    cn.Open();

                    // Obtener encabezado
                    string queryHeader = @"
                        SELECT 
                            t.*,
                            uOrigen.nombre AS ubicacionOrigen,
                            uDestino.nombre AS ubicacionDestino
                        FROM inventario_transferenciastock t
                        LEFT JOIN inventario_ubicacion uOrigen ON t.ubicacion_origen_id = uOrigen.id
                        LEFT JOIN inventario_ubicacion uDestino ON t.ubicacion_destino_id = uDestino.id
                        WHERE t.id = @id;";

                    MySqlCommand cmd = new MySqlCommand(queryHeader, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            transferencia = new ETransferencia
                            {
                                Id = reader.GetInt64("id"),
                                NumeroTransferencia = reader["numero_transferencia"] != DBNull.Value ? reader.GetString("numero_transferencia") : "",
                                FechaTransferencia = reader["fecha_creacion"] != DBNull.Value ? reader.GetDateTime("fecha_creacion") : DateTime.Now,
                                IdUbicacionOrigen = reader["ubicacion_origen_id"] != DBNull.Value ? reader.GetInt32("ubicacion_origen_id") : 0,
                                UbicacionOrigen = reader["ubicacionOrigen"] != DBNull.Value ? reader.GetString("ubicacionOrigen") : "",
                                IdUbicacionDestino = reader["ubicacion_destino_id"] != DBNull.Value ? reader.GetInt32("ubicacion_destino_id") : 0,
                                UbicacionDestino = reader["ubicacionDestino"] != DBNull.Value ? reader.GetString("ubicacionDestino") : "",
                                MotivoTransferencia = reader["motivo"] != DBNull.Value ? reader.GetString("motivo") : "",
                                Observaciones = reader["observaciones"] != DBNull.Value ? reader.GetString("observaciones") : "",
                                Estado = reader["estado"] != DBNull.Value ? reader.GetString("estado") : "PENDIENTE",
                                CreadoPor = reader["creadoPor_id"] != DBNull.Value ? reader.GetInt32("creadoPor_id") : 0,
                                CreadoDate = reader["fecha_creacion"] != DBNull.Value ? reader.GetDateTime("fecha_creacion") : DateTime.Now
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener la transferencia: " + ex.Message);
                }
            }
            return transferencia;
        }

        // =====================
        // INSERTAR TRANSFERENCIA
        // =====================
        public bool InsertarTransferencia(ETransferencia transferencia)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                cn.Open();
                using (var transaction = cn.BeginTransaction())
                {
                    try
                    {
                        // Insertar encabezado
                        string queryHeader = @"
                            INSERT INTO inventario_transferenciastock (
                                numero_transferencia, fecha_creacion, fecha_envio,
                                ubicacion_origen_id, ubicacion_destino_id,
                                motivo, observaciones, estado, tipo,
                                creadoPor_id, editadoDate
                            ) VALUES (
                                @numeroTransferencia, @fechaCreacion, NULL,
                                @ubicacionOrigenId, @ubicacionDestinoId,
                                @motivo, @observaciones, @estado, @tipo,
                                @creadoPorId, NULL
                            );
                            SELECT LAST_INSERT_ID();";

                        MySqlCommand cmd = new MySqlCommand(queryHeader, cn, transaction);
                        cmd.Parameters.AddWithValue("@numeroTransferencia", transferencia.NumeroTransferencia);
                        cmd.Parameters.AddWithValue("@fechaCreacion", transferencia.FechaTransferencia);
                        cmd.Parameters.AddWithValue("@ubicacionOrigenId", transferencia.IdUbicacionOrigen);
                        cmd.Parameters.AddWithValue("@ubicacionDestinoId", transferencia.IdUbicacionDestino);
                        cmd.Parameters.AddWithValue("@motivo", transferencia.MotivoTransferencia ?? "");
                        cmd.Parameters.AddWithValue("@observaciones", transferencia.Observaciones ?? "");
                        cmd.Parameters.AddWithValue("@estado", transferencia.Estado);
                        cmd.Parameters.AddWithValue("@tipo", "TRANSFERENCIA");
                        cmd.Parameters.AddWithValue("@creadoPorId", transferencia.CreadoPor);

                        long idTransferencia = Convert.ToInt64(cmd.ExecuteScalar());

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al insertar la transferencia: " + ex.Message);
                    }
                }
            }
        }

        // =====================
        // RECIBIR TRANSFERENCIA
        // =====================
        public bool RecibirTransferencia(long idTransferencia, int usuarioId)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                cn.Open();
                using (var transaction = cn.BeginTransaction())
                {
                    try
                    {
                        // Actualizar estado y fecha de recepción
                        string queryUpdate = @"
                            UPDATE inventario_transferenciastock 
                            SET estado = 'RECIBIDA',
                                fecha_recepcion = @fechaRecepcion,
                                usuario_recepcion_id = @usuarioRecepcionId
                            WHERE id = @id AND estado = 'PENDIENTE';";

                        MySqlCommand cmd = new MySqlCommand(queryUpdate, cn, transaction);
                        cmd.Parameters.AddWithValue("@id", idTransferencia);
                        cmd.Parameters.AddWithValue("@fechaRecepcion", DateTime.Now);
                        cmd.Parameters.AddWithValue("@usuarioRecepcionId", usuarioId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            throw new Exception("La transferencia no existe o ya fue procesada.");
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al recibir la transferencia: " + ex.Message);
                    }
                }
            }
        }

        // =====================
        // ANULAR TRANSFERENCIA
        // =====================
        public bool AnularTransferencia(long idTransferencia, int usuarioId)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                cn.Open();
                using (var transaction = cn.BeginTransaction())
                {
                    try
                    {
                        string query = @"
                            UPDATE inventario_transferenciastock 
                            SET estado = 'CANCELADA',
                                anulado = 1,
                                editadoPor_id = @editadoPorId,
                                editadoDate = @editadoDate
                            WHERE id = @id AND estado = 'PENDIENTE';";

                        MySqlCommand cmd = new MySqlCommand(query, cn, transaction);
                        cmd.Parameters.AddWithValue("@id", idTransferencia);
                        cmd.Parameters.AddWithValue("@editadoPorId", usuarioId);
                        cmd.Parameters.AddWithValue("@editadoDate", DateTime.Now);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            throw new Exception("La transferencia no existe o ya fue procesada.");
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al anular la transferencia: " + ex.Message);
                    }
                }
            }
        }

        // =====================
        // OBTENER LOTES DISPONIBLES POR PRODUCTO
        // =====================
        public DataTable ObtenerLotesDisponibles(long idProducto)
        {
            DataTable tabla = new DataTable();
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    // Aquí deberías tener una tabla de lotes por producto
                    // Por ahora simulamos con datos dummy
                    string query = @"
                        SELECT 
                            lote,
                            fechaCaducidad,
                            stockDisponible,
                            DATEDIFF(fechaCaducidad, CURDATE()) AS diasParaCaducidad
                        FROM lotes_productos
                        WHERE idProducto = @idProducto 
                          AND stockDisponible > 0
                          AND fechaCaducidad > CURDATE()
                        ORDER BY fechaCaducidad ASC;";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
                catch (Exception ex)
                {
                    // Si la tabla no existe, devolvemos tabla vacía
                    // throw new Exception("Error al obtener lotes: " + ex.Message);
                }
            }
            return tabla;
        }

        // =====================
        // GENERAR NÚMERO DE TRANSFERENCIA
        // =====================
        public string GenerarNumeroTransferencia()
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                        SELECT COALESCE(MAX(CAST(SUBSTRING(numero_transferencia, 5) AS UNSIGNED)), 0) + 1
                        FROM inventario_transferenciastock
                        WHERE YEAR(fecha_creacion) = YEAR(CURDATE());";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    int secuencial = Convert.ToInt32(cmd.ExecuteScalar());

                    return $"TRF-{DateTime.Now.Year}-{secuencial.ToString("D6")}";
                }
                catch (Exception ex)
                {
                    // Fallback
                    return $"TRF-{DateTime.Now:yyyyMMddHHmmss}";
                }
            }
        }
    }
}
