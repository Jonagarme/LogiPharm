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
        private const string TablaTransferencia = "inventario_transferenciastock";
        private const string TablaTransferenciaDetalle = "inventario_detalletransferencia";

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
                    // Intentamos primero traer totales desde la tabla (si existen las columnas).
                    string queryConTotales = @"
                        SELECT 
                            t.id,
                            t.numero_transferencia AS numeroTransferencia,
                            t.fecha_creacion AS fechaTransferencia,
                            uOrigen.nombre AS ubicacionOrigen,
                            uDestino.nombre AS ubicacionDestino,
                            t.motivo AS motivoTransferencia,
                            COALESCE(t.total_productos, 0) AS totalProductos,
                            COALESCE(t.total_unidades, 0) AS totalUnidades,
                            t.estado AS estado,
                            t.tipo,
                            t.observaciones
                        FROM " + TablaTransferencia + @" t
                        LEFT JOIN inventario_ubicacion uOrigen ON t.ubicacion_origen_id = uOrigen.id
                        LEFT JOIN inventario_ubicacion uDestino ON t.ubicacion_destino_id = uDestino.id
                        WHERE 1=1";

                    if (!string.IsNullOrWhiteSpace(filtroEstado))
                        queryConTotales += " AND t.estado = @estado";

                    queryConTotales += " ORDER BY t.fecha_creacion DESC;";

                    bool ejecutado = false;
                    try
                    {
                        using (var cmd = new MySqlCommand(queryConTotales, cn))
                        {
                            if (!string.IsNullOrWhiteSpace(filtroEstado))
                                cmd.Parameters.AddWithValue("@estado", filtroEstado);

                            using (var da = new MySqlDataAdapter(cmd))
                                da.Fill(tabla);
                        }
                        ejecutado = true;
                    }
                    catch (MySqlException ex)
                    {
                        // Compatibilidad hacia atras: BD sin columnas de totales.
                        if (ex.Message != null && ex.Message.IndexOf("Unknown column", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            tabla.Clear();
                        }
                        else
                        {
                            throw;
                        }
                    }

                    if (!ejecutado)
                    {
                        string querySinTotales = @"
                            SELECT 
                                t.id,
                                t.numero_transferencia AS numeroTransferencia,
                                t.fecha_creacion AS fechaTransferencia,
                                uOrigen.nombre AS ubicacionOrigen,
                                uDestino.nombre AS ubicacionDestino,
                                t.motivo AS motivoTransferencia,
                                0 AS totalProductos,
                                0 AS totalUnidades,
                                t.estado AS estado,
                                t.tipo,
                                t.observaciones
                            FROM " + TablaTransferencia + @" t
                            LEFT JOIN inventario_ubicacion uOrigen ON t.ubicacion_origen_id = uOrigen.id
                            LEFT JOIN inventario_ubicacion uDestino ON t.ubicacion_destino_id = uDestino.id
                            WHERE 1=1";

                        if (!string.IsNullOrWhiteSpace(filtroEstado))
                            querySinTotales += " AND t.estado = @estado";

                        querySinTotales += " ORDER BY t.fecha_creacion DESC;";

                        using (var cmd = new MySqlCommand(querySinTotales, cn))
                        {
                            if (!string.IsNullOrWhiteSpace(filtroEstado))
                                cmd.Parameters.AddWithValue("@estado", filtroEstado);

                            using (var da = new MySqlDataAdapter(cmd))
                                da.Fill(tabla);
                        }
                    }
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

                    // Intentar cargar detalle (si existe la tabla)
                    if (transferencia != null)
                    {
                        try
                        {
                            string qDetalle = @"
                                SELECT 
                                    d.id,
                                    d.transferencia_id,
                                    d.producto_id,
                                    p.codigoPrincipal AS codigoProducto,
                                    p.nombre AS nombreProducto,
                                    d.numero_lote,
                                    d.fecha_caducidad,
                                    d.cantidad_solicitada,
                                    d.cantidad_recibida,
                                    d.estado
                                FROM " + TablaTransferenciaDetalle + @" d
                                INNER JOIN productos p ON d.producto_id = p.id
                                WHERE d.transferencia_id = @id
                                ORDER BY d.id;";

                            using (var cmdDet = new MySqlCommand(qDetalle, cn))
                            {
                                cmdDet.Parameters.AddWithValue("@id", id);
                                using (var rd = cmdDet.ExecuteReader())
                                {
                                    while (rd.Read())
                                    {
                                        transferencia.Detalles.Add(new ETransferenciaDetalle
                                        {
                                            Id = rd["id"] != DBNull.Value ? Convert.ToInt64(rd["id"]) : 0,
                                            IdTransferencia = rd["transferencia_id"] != DBNull.Value ? Convert.ToInt64(rd["transferencia_id"]) : 0,
                                            IdProducto = rd["producto_id"] != DBNull.Value ? Convert.ToInt64(rd["producto_id"]) : 0,
                                            CodigoProducto = rd["codigoProducto"]?.ToString() ?? "",
                                            NombreProducto = rd["nombreProducto"]?.ToString() ?? "",
                                            Lote = rd["numero_lote"]?.ToString() ?? "",
                                            FechaCaducidad = rd["fecha_caducidad"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(rd["fecha_caducidad"]) : null,
                                            CantidadSolicitada = rd["cantidad_solicitada"] != DBNull.Value ? Convert.ToInt32(rd["cantidad_solicitada"]) : 0,
                                            CantidadRecibida = rd["cantidad_recibida"] != DBNull.Value ? Convert.ToInt32(rd["cantidad_recibida"]) : 0,
                                            Estado = rd["estado"]?.ToString() ?? "PENDIENTE"
                                        });
                                    }
                                }
                            }

                            transferencia.TotalProductos = transferencia.Detalles.Count;
                            transferencia.TotalUnidades = 0;
                            foreach (var d in transferencia.Detalles)
                                transferencia.TotalUnidades += d.CantidadSolicitada;
                        }
                        catch (MySqlException ex)
                        {
                            // Si la tabla no existe afan, no rompemos la consulta.
                            if (ex.Message == null || ex.Message.IndexOf("doesn't exist", StringComparison.OrdinalIgnoreCase) < 0)
                                throw;
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
                        if (transferencia == null)
                            throw new ArgumentNullException(nameof(transferencia));

                        int totalProductos = transferencia.Detalles != null ? transferencia.Detalles.Count : 0;
                        decimal totalUnidades = 0m;
                        if (transferencia.Detalles != null)
                            foreach (var d in transferencia.Detalles) totalUnidades += d.CantidadSolicitada;

                        // Insertar encabezado
                        long idTransferencia;

                        // Intento 1: insertar con columnas de totales
                        try
                        {
                            string queryHeaderConTotales = @"
                                INSERT INTO " + TablaTransferencia + @" (
                                    numero_transferencia, fecha_creacion, fecha_envio,
                                    ubicacion_origen_id, ubicacion_destino_id,
                                    motivo, observaciones, estado, tipo,
                                    total_productos, total_unidades,
                                    creadoPor_id, editadoDate
                                ) VALUES (
                                    @numeroTransferencia, @fechaCreacion, NULL,
                                    @ubicacionOrigenId, @ubicacionDestinoId,
                                    @motivo, @observaciones, @estado, @tipo,
                                    @totalProductos, @totalUnidades,
                                    @creadoPorId, NULL
                                );
                                SELECT LAST_INSERT_ID();";

                            using (var cmd = new MySqlCommand(queryHeaderConTotales, cn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@numeroTransferencia", transferencia.NumeroTransferencia);
                                cmd.Parameters.AddWithValue("@fechaCreacion", transferencia.FechaTransferencia);
                                cmd.Parameters.AddWithValue("@ubicacionOrigenId", transferencia.IdUbicacionOrigen);
                                cmd.Parameters.AddWithValue("@ubicacionDestinoId", transferencia.IdUbicacionDestino);
                                cmd.Parameters.AddWithValue("@motivo", transferencia.MotivoTransferencia ?? "");
                                cmd.Parameters.AddWithValue("@observaciones", transferencia.Observaciones ?? "");
                                cmd.Parameters.AddWithValue("@estado", transferencia.Estado);
                                cmd.Parameters.AddWithValue("@tipo", "TRANSFERENCIA");
                                cmd.Parameters.AddWithValue("@totalProductos", totalProductos);
                                cmd.Parameters.AddWithValue("@totalUnidades", totalUnidades);
                                cmd.Parameters.AddWithValue("@creadoPorId", transferencia.CreadoPor);
                                idTransferencia = Convert.ToInt64(cmd.ExecuteScalar());
                            }
                        }
                        catch (MySqlException ex)
                        {
                            if (ex.Message == null || ex.Message.IndexOf("Unknown column", StringComparison.OrdinalIgnoreCase) < 0)
                                throw;

                            // Intento 2: BD sin columnas de totales
                            string queryHeader = @"
                                INSERT INTO " + TablaTransferencia + @" (
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

                            using (var cmd = new MySqlCommand(queryHeader, cn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@numeroTransferencia", transferencia.NumeroTransferencia);
                                cmd.Parameters.AddWithValue("@fechaCreacion", transferencia.FechaTransferencia);
                                cmd.Parameters.AddWithValue("@ubicacionOrigenId", transferencia.IdUbicacionOrigen);
                                cmd.Parameters.AddWithValue("@ubicacionDestinoId", transferencia.IdUbicacionDestino);
                                cmd.Parameters.AddWithValue("@motivo", transferencia.MotivoTransferencia ?? "");
                                cmd.Parameters.AddWithValue("@observaciones", transferencia.Observaciones ?? "");
                                cmd.Parameters.AddWithValue("@estado", transferencia.Estado);
                                cmd.Parameters.AddWithValue("@tipo", "TRANSFERENCIA");
                                cmd.Parameters.AddWithValue("@creadoPorId", transferencia.CreadoPor);
                                idTransferencia = Convert.ToInt64(cmd.ExecuteScalar());
                            }
                        }

                        // Insertar detalle + reservar stock
                        if (transferencia.Detalles != null)
                        {
                            foreach (var det in transferencia.Detalles)
                            {
                                 InsertarDetalleTransferencia(cn, transaction, idTransferencia, transferencia.IdUbicacionOrigen, det);
                            }
                        }

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

        private static void InsertarDetalleTransferencia(MySqlConnection cn, MySqlTransaction tx, long idTransferencia, int idUbicacionOrigen, ETransferenciaDetalle det)
        {
            if (det == null)
                throw new ArgumentNullException(nameof(det));

            // 1) Buscar el lote origen
            int idLoteOrigen;
            using (var cmdLote = new MySqlCommand(@"
                SELECT id
                FROM inventario_loteproducto
                WHERE producto_id = @productoId
                  AND ubicacion_id = @ubicacionId
                  AND numero_lote = @numeroLote
                  AND (@fechaCaducidad IS NULL OR fecha_caducidad = @fechaCaducidad)
                ORDER BY fecha_ingreso ASC
                LIMIT 1;", cn, tx))
            {
                cmdLote.Parameters.AddWithValue("@productoId", det.IdProducto);
                cmdLote.Parameters.AddWithValue("@ubicacionId", idUbicacionOrigen);
                cmdLote.Parameters.AddWithValue("@numeroLote", det.Lote ?? "GENERICO");
                cmdLote.Parameters.AddWithValue("@fechaCaducidad", (object)det.FechaCaducidad ?? DBNull.Value);

                object scalar = cmdLote.ExecuteScalar();
                if (scalar == null || scalar == DBNull.Value)
                {
                    // Fallback to GENERICO lot
                    using (var cmdGen = new MySqlCommand(@"
                        SELECT id FROM inventario_loteproducto 
                        WHERE producto_id = @productoId AND ubicacion_id = @ubicacionId AND numero_lote = 'GENERICO' LIMIT 1;", cn, tx))
                    {
                        cmdGen.Parameters.AddWithValue("@productoId", det.IdProducto);
                        cmdGen.Parameters.AddWithValue("@ubicacionId", idUbicacionOrigen);
                        object scalarGen = cmdGen.ExecuteScalar();
                        if (scalarGen != null && scalarGen != DBNull.Value)
                            idLoteOrigen = Convert.ToInt32(scalarGen);
                        else
                            throw new Exception($"No se encontró el lote '{det.Lote}' para el producto ID {det.IdProducto} en la ubicación origen.");
                    }
                }
                else
                {
                    idLoteOrigen = Convert.ToInt32(scalar);
                }
            }

            // 2) Insertar detalle (sin reservar stock en la base de datos)
            try
            {
                using (var cmdDet = new MySqlCommand(@"
                    INSERT INTO " + TablaTransferenciaDetalle + @" (
                        transferencia_id, producto_id, lote_id, cantidad, cantidad_recibida, 
                        stock_origen_antes, stock_destino_antes, observaciones, 
                        precio_origen, precio_destino, cambio_precio, 
                        cantidad_cajas, cantidad_fracciones, unidades_por_caja
                    ) VALUES (
                        @transferenciaId, @productoId, @loteId, @cantidad, 0, 
                        @stockOrigenAntes, 0, '', 
                        0, 0, 0, 
                        0, 0, 1
                    );", cn, tx))
                {
                    cmdDet.Parameters.AddWithValue("@transferenciaId", idTransferencia);
                    cmdDet.Parameters.AddWithValue("@productoId", det.IdProducto);
                    cmdDet.Parameters.AddWithValue("@loteId", idLoteOrigen);
                    cmdDet.Parameters.AddWithValue("@cantidad", det.CantidadSolicitada);
                    cmdDet.Parameters.AddWithValue("@stockOrigenAntes", det.StockDisponibleOrigen);
                    cmdDet.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Message != null && ex.Message.IndexOf("doesn't exist", StringComparison.OrdinalIgnoreCase) >= 0)
                    throw new Exception("Falta la tabla de detalle de transferencias. Cree la tabla 'inventario_detalletransferencia' para guardar productos/lotes de la transferencia.");
                throw;
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

                        // Procesar el traspaso físico de inventarios y lotes
                        ProcesarRecepcionStock(cn, transaction, idTransferencia, usuarioId);

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
                            UPDATE " + TablaTransferencia + @" 
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

        private static void ProcesarRecepcionStock(MySqlConnection cn, MySqlTransaction tx, long idTransferencia, int usuarioId)
        {
            // Obtener ubicaciones y número de transferencia
            int idOrigen = 0;
            int idDestino = 0;
            string numTransferencia = "";
            using (var cmdHead = new MySqlCommand(@"
                SELECT ubicacion_origen_id, ubicacion_destino_id, numero_transferencia
                FROM " + TablaTransferencia + @"
                WHERE id = @id;", cn, tx))
            {
                cmdHead.Parameters.AddWithValue("@id", idTransferencia);
                using (var rd = cmdHead.ExecuteReader())
                {
                    if (!rd.Read())
                        throw new Exception("La transferencia no existe.");

                    idOrigen = rd["ubicacion_origen_id"] != DBNull.Value ? Convert.ToInt32(rd["ubicacion_origen_id"]) : 0;
                    idDestino = rd["ubicacion_destino_id"] != DBNull.Value ? Convert.ToInt32(rd["ubicacion_destino_id"]) : 0;
                    numTransferencia = rd["numero_transferencia"]?.ToString() ?? "";
                }
            }

            // Obtener nombre del usuario
            string nombreUsuario = "Usuario Sistema";
            using (var cmdUser = new MySqlCommand("SELECT COALESCE(NULLIF(nombreCompleto, ''), nombreUsuario) FROM usuarios WHERE id = @idUsuario", cn, tx))
            {
                cmdUser.Parameters.AddWithValue("@idUsuario", usuarioId);
                object uVal = cmdUser.ExecuteScalar();
                if (uVal != null && uVal != DBNull.Value)
                    nombreUsuario = Convert.ToString(uVal);
            }

            // Leer detalles
            var detalles = new List<Tuple<int, long, string, DateTime?, decimal>>();
            using (var cmdDet = new MySqlCommand(@"
                SELECT 
                    d.lote_id AS lote_origen_id, 
                    d.producto_id, 
                    COALESCE(l.numero_lote, 'GENERICO') AS numero_lote, 
                    l.fecha_caducidad, 
                    d.cantidad AS cantidad_solicitada
                FROM " + TablaTransferenciaDetalle + @" d
                LEFT JOIN inventario_loteproducto l ON d.lote_id = l.id
                WHERE d.transferencia_id = @id;", cn, tx))
            {
                cmdDet.Parameters.AddWithValue("@id", idTransferencia);
                using (var rd = cmdDet.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        int loteOrigenId = rd["lote_origen_id"] != DBNull.Value ? Convert.ToInt32(rd["lote_origen_id"]) : 0;
                        long productoId = rd["producto_id"] != DBNull.Value ? Convert.ToInt64(rd["producto_id"]) : 0;
                        string numeroLote = rd["numero_lote"]?.ToString() ?? "";
                        DateTime? fechaCad = rd["fecha_caducidad"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(rd["fecha_caducidad"]) : null;
                        decimal qty = rd["cantidad_solicitada"] != DBNull.Value ? Convert.ToDecimal(rd["cantidad_solicitada"]) : 0m;
                        if (loteOrigenId > 0 && productoId > 0 && qty > 0)
                            detalles.Add(Tuple.Create(loteOrigenId, productoId, numeroLote, fechaCad, qty));
                    }
                }
            }

            foreach (var it in detalles)
            {
                int loteOrigenId = it.Item1;
                long productoId = it.Item2;
                string numeroLote = it.Item3;
                DateTime? fechaCad = it.Item4;
                decimal qty = it.Item5;

                // 1) Descontar stock disponible en origen
                using (var cmdUpdOrigen = new MySqlCommand(@"
                    UPDATE inventario_loteproducto
                    SET cantidad_disponible = cantidad_disponible - @cantidad,
                        fecha_actualizacion = NOW()
                    WHERE id = @idLote
                      AND cantidad_disponible >= @cantidad;", cn, tx))
                {
                    cmdUpdOrigen.Parameters.AddWithValue("@idLote", loteOrigenId);
                    cmdUpdOrigen.Parameters.AddWithValue("@cantidad", qty);
                    int rows = cmdUpdOrigen.ExecuteNonQuery();
                    if (rows == 0)
                        throw new Exception($"Stock insuficiente en el lote de origen (Lote ID {loteOrigenId}) para realizar la transferencia.");
                }

                // Descontar de inventario_stockubicacion (Origen)
                using (var cmdStockOrig = new MySqlCommand(@"
                    UPDATE inventario_stockubicacion 
                    SET cantidad = cantidad - @cantidad, ultima_actualizacion = NOW() 
                    WHERE producto_id = @productoId AND ubicacion_id = @ubicacionId AND idEmpresa = @idEmpresa;", cn, tx))
                {
                    cmdStockOrig.Parameters.AddWithValue("@cantidad", qty);
                    cmdStockOrig.Parameters.AddWithValue("@productoId", productoId);
                    cmdStockOrig.Parameters.AddWithValue("@ubicacionId", idOrigen);
                    cmdStockOrig.Parameters.AddWithValue("@idEmpresa", Conexion.IdEmpresa);
                    cmdStockOrig.ExecuteNonQuery();
                }

                // 2) Aumentar disponible en destino (si existe el lote), si no existe lo crea
                int rowsDestino;
                using (var cmdUpdDest = new MySqlCommand(@"
                    UPDATE inventario_loteproducto
                    SET cantidad_disponible = cantidad_disponible + @cantidad,
                        fecha_actualizacion = NOW()
                    WHERE producto_id = @productoId
                      AND ubicacion_id = @ubicacionDestino
                      AND numero_lote = @numeroLote
                      AND (@fechaCaducidad IS NULL OR fecha_caducidad = @fechaCaducidad)
                      AND activo = 1
                    LIMIT 1;", cn, tx))
                {
                    cmdUpdDest.Parameters.AddWithValue("@cantidad", qty);
                    cmdUpdDest.Parameters.AddWithValue("@productoId", productoId);
                    cmdUpdDest.Parameters.AddWithValue("@ubicacionDestino", idDestino);
                    cmdUpdDest.Parameters.AddWithValue("@numeroLote", numeroLote);
                    cmdUpdDest.Parameters.AddWithValue("@fechaCaducidad", (object)fechaCad ?? DBNull.Value);
                    rowsDestino = cmdUpdDest.ExecuteNonQuery();
                }

                if (rowsDestino == 0)
                {
                    // Copiar costo unitario y fecha fabricacion desde lote origen
                    decimal costoUnitario = 0m;
                    DateTime fechaFab = DateTime.Today;
                    using (var cmdInfo = new MySqlCommand(@"
                        SELECT costo_unitario, fecha_fabricacion
                        FROM inventario_loteproducto
                        WHERE id = @idLote;", cn, tx))
                    {
                        cmdInfo.Parameters.AddWithValue("@idLote", loteOrigenId);
                        using (var rd = cmdInfo.ExecuteReader())
                        {
                            if (rd.Read())
                            {
                                if (rd["costo_unitario"] != DBNull.Value) costoUnitario = Convert.ToDecimal(rd["costo_unitario"]);
                                if (rd["fecha_fabricacion"] != DBNull.Value) fechaFab = Convert.ToDateTime(rd["fecha_fabricacion"]);
                            }
                        }
                    }

                    using (var cmdIns = new MySqlCommand(@"
                        INSERT INTO inventario_loteproducto
                            (producto_id, ubicacion_id, numero_lote, fecha_ingreso, fecha_fabricacion, fecha_caducidad,
                             cantidad_inicial, cantidad_disponible, cantidad_reservada, costo_unitario, numero_factura,
                             observaciones, activo, creadoDate, editadoDate, idEmpresa, fecha_creacion, fecha_actualizacion)
                        VALUES
                            (@productoId, @ubicacionId, @numeroLote, CURDATE(), @fechaFabricacion, @fechaCaducidad,
                             @cantidad, @cantidad, 0, @costoUnitario, '',
                             'Transferencia interna', 1, NOW(), NOW(), @idEmpresa, NOW(), NOW());", cn, tx))
                    {
                        cmdIns.Parameters.AddWithValue("@productoId", productoId);
                        cmdIns.Parameters.AddWithValue("@ubicacionId", idDestino);
                        cmdIns.Parameters.AddWithValue("@numeroLote", numeroLote);
                        cmdIns.Parameters.AddWithValue("@fechaFabricacion", fechaFab);
                        cmdIns.Parameters.AddWithValue("@fechaCaducidad", (object)fechaCad ?? DBNull.Value);
                        cmdIns.Parameters.AddWithValue("@cantidad", qty);
                        cmdIns.Parameters.AddWithValue("@costoUnitario", costoUnitario);
                        cmdIns.Parameters.AddWithValue("@idEmpresa", Conexion.IdEmpresa);
                        cmdIns.ExecuteNonQuery();
                    }
                }

                // Registrar/Actualizar en inventario_stockubicacion (Destino)
                long stockDestId = 0;
                using (var cmdCheck = new MySqlCommand(@"
                    SELECT id FROM inventario_stockubicacion 
                    WHERE producto_id = @productoId AND ubicacion_id = @ubicacionId AND idEmpresa = @idEmpresa LIMIT 1;", cn, tx))
                {
                    cmdCheck.Parameters.AddWithValue("@productoId", productoId);
                    cmdCheck.Parameters.AddWithValue("@ubicacionId", idDestino);
                    cmdCheck.Parameters.AddWithValue("@idEmpresa", Conexion.IdEmpresa);
                    object scalar = cmdCheck.ExecuteScalar();
                    if (scalar != null && scalar != DBNull.Value)
                        stockDestId = Convert.ToInt64(scalar);
                }

                if (stockDestId > 0)
                {
                    using (var cmdUpdDestStock = new MySqlCommand(@"
                        UPDATE inventario_stockubicacion 
                        SET cantidad = cantidad + @cantidad, ultima_actualizacion = NOW() 
                        WHERE id = @id;", cn, tx))
                    {
                        cmdUpdDestStock.Parameters.AddWithValue("@cantidad", qty);
                        cmdUpdDestStock.Parameters.AddWithValue("@id", stockDestId);
                        cmdUpdDestStock.ExecuteNonQuery();
                    }
                }
                else
                {
                    using (var cmdInsDestStock = new MySqlCommand(@"
                        INSERT INTO inventario_stockubicacion 
                        (cantidad, stock_minimo, stock_maximo, punto_reorden, creadoDate, editadoDate, producto_id, ubicacion_id, idEmpresa, ultima_actualizacion) 
                        VALUES (@cantidad, 0.00, 0.00, 0.00, NOW(), NOW(), @productoId, @ubicacionId, @idEmpresa, NOW());", cn, tx))
                    {
                        cmdInsDestStock.Parameters.AddWithValue("@cantidad", qty);
                        cmdInsDestStock.Parameters.AddWithValue("@productoId", productoId);
                        cmdInsDestStock.Parameters.AddWithValue("@ubicacionId", idDestino);
                        cmdInsDestStock.Parameters.AddWithValue("@idEmpresa", Conexion.IdEmpresa);
                        cmdInsDestStock.ExecuteNonQuery();
                    }
                }

                // 3) Integrar con kardex_movimientos (EGRESO e INGRESO)
                decimal globalStock = 0;
                decimal unitCost = 0;
                using (var cmdProd = new MySqlCommand(@"
                    SELECT stock, COALESCE(costoUnidad, 0) FROM productos WHERE id = @idProducto;", cn, tx))
                {
                    cmdProd.Parameters.AddWithValue("@idProducto", productoId);
                    using (var rdProd = cmdProd.ExecuteReader())
                    {
                        if (rdProd.Read())
                        {
                            globalStock = rdProd.GetDecimal(0);
                            unitCost = rdProd.GetDecimal(1);
                        }
                    }
                }

                // 3.1) Kardex EGRESO
                string insertKardexOrig = @"
                    INSERT INTO kardex_movimientos (
                        idProducto, fecha, tipoMovimiento, detalle, 
                        ingreso, egreso, saldo, costo, costo_promedio, precio, usuario, numero_documento, idEmpresa, idUbicacion
                    ) VALUES (
                        @idProducto, NOW(), 'TRANSFERENCIA EGRESO', @detalle, 
                        0.00, @egreso, @saldo, @costo, @costo, 0.00, @usuario, @numero_documento, @idEmpresa, @idUbicacion
                    );";
                using (var cmdKOrig = new MySqlCommand(insertKardexOrig, cn, tx))
                {
                    cmdKOrig.Parameters.AddWithValue("@idProducto", productoId);
                    cmdKOrig.Parameters.AddWithValue("@detalle", "SALIDA POR TRANSFERENCIA STOCK HASTA UBICACION ID " + idDestino);
                    cmdKOrig.Parameters.AddWithValue("@egreso", qty);
                    cmdKOrig.Parameters.AddWithValue("@saldo", globalStock);
                    cmdKOrig.Parameters.AddWithValue("@costo", unitCost);
                    cmdKOrig.Parameters.AddWithValue("@usuario", nombreUsuario);
                    cmdKOrig.Parameters.AddWithValue("@numero_documento", numTransferencia);
                    cmdKOrig.Parameters.AddWithValue("@idEmpresa", Conexion.IdEmpresa);
                    cmdKOrig.Parameters.AddWithValue("@idUbicacion", idOrigen);
                    cmdKOrig.ExecuteNonQuery();
                }

                // 3.2) Kardex INGRESO
                string insertKardexDest = @"
                    INSERT INTO kardex_movimientos (
                        idProducto, fecha, tipoMovimiento, detalle, 
                        ingreso, egreso, saldo, costo, costo_promedio, precio, usuario, numero_documento, idEmpresa, idUbicacion
                    ) VALUES (
                        @idProducto, NOW(), 'TRANSFERENCIA INGRESO', @detalle, 
                        @ingreso, 0.00, @saldo, @costo, @costo, 0.00, @usuario, @numero_documento, @idEmpresa, @idUbicacion
                    );";
                using (var cmdKDest = new MySqlCommand(insertKardexDest, cn, tx))
                {
                    cmdKDest.Parameters.AddWithValue("@idProducto", productoId);
                    cmdKDest.Parameters.AddWithValue("@detalle", "INGRESO POR TRANSFERENCIA STOCK DESDE UBICACION ID " + idOrigen);
                    cmdKDest.Parameters.AddWithValue("@ingreso", qty);
                    cmdKDest.Parameters.AddWithValue("@saldo", globalStock);
                    cmdKDest.Parameters.AddWithValue("@costo", unitCost);
                    cmdKDest.Parameters.AddWithValue("@usuario", nombreUsuario);
                    cmdKDest.Parameters.AddWithValue("@numero_documento", numTransferencia);
                    cmdKDest.Parameters.AddWithValue("@idEmpresa", Conexion.IdEmpresa);
                    cmdKDest.Parameters.AddWithValue("@idUbicacion", idDestino);
                    cmdKDest.ExecuteNonQuery();
                }
            }

            // Marcar detalle como recibido en la base de datos
            using (var cmdUpdDet = new MySqlCommand(@"
                UPDATE " + TablaTransferenciaDetalle + @"
                SET cantidad_recibida = cantidad
                WHERE transferencia_id = @id;", cn, tx))
            {
                cmdUpdDet.Parameters.AddWithValue("@id", idTransferencia);
                cmdUpdDet.ExecuteNonQuery();
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
