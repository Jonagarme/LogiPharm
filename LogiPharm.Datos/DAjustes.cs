using System;
using System.Collections.Generic;
using MySqlConnector;
using LogiPharm.Entidades;
using CapaDatos;

namespace LogiPharm.Datos
{
    public class DAjustes
    {
        public bool GuardarAjuste(EAjuste ajuste)
        {
            if (ajuste == null)
                throw new ArgumentNullException(nameof(ajuste));

            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                cn.Open();
                using (var tx = cn.BeginTransaction())
                {
                    try
                    {
                        // 1. Generar secuencial de documento si no viene especificado
                        if (string.IsNullOrEmpty(ajuste.NumeroDocumento) || ajuste.NumeroDocumento == "000001")
                        {
                            using (var cmdSeq = new MySqlCommand("SELECT COALESCE(MAX(CAST(numeroDocumento AS SIGNED)), 0) + 1 FROM ajustes_inventario WHERE idEmpresa = @idEmpresa", cn, tx))
                            {
                                cmdSeq.Parameters.AddWithValue("@idEmpresa", Conexion.IdEmpresa);
                                int nextSeq = Convert.ToInt32(cmdSeq.ExecuteScalar());
                                ajuste.NumeroDocumento = nextSeq.ToString("D6");
                            }
                        }

                        // 2. Insertar cabecera de ajuste
                        string sqlCab = @"INSERT INTO ajustes_inventario 
                            (numeroDocumento, idTipoAjuste, fecha, observaciones, totalCosto, creadoPor, creadoDate, idEmpresa, anulado)
                            VALUES (@numeroDocumento, @idTipoAjuste, NOW(), @observaciones, @totalCosto, @creadoPor, NOW(), @idEmpresa, 0);
                            SELECT LAST_INSERT_ID();";

                        long idAjuste;
                        using (var cmdCab = new MySqlCommand(sqlCab, cn, tx))
                        {
                            cmdCab.Parameters.AddWithValue("@numeroDocumento", ajuste.NumeroDocumento);
                            cmdCab.Parameters.AddWithValue("@idTipoAjuste", GetIdTipoAjuste(ajuste.TipoAjuste));
                            cmdCab.Parameters.AddWithValue("@observaciones", ajuste.Observaciones ?? "");
                            cmdCab.Parameters.AddWithValue("@totalCosto", ajuste.Total);
                            cmdCab.Parameters.AddWithValue("@creadoPor", ajuste.IdUsuario);
                            cmdCab.Parameters.AddWithValue("@idEmpresa", Conexion.IdEmpresa);
                            idAjuste = Convert.ToInt64(cmdCab.ExecuteScalar());
                        }

                        // Obtener nombre del usuario para el Kardex
                        string nombreUsuario = "Usuario Sistema";
                        using (var cmdUser = new MySqlCommand("SELECT COALESCE(NULLIF(nombreCompleto, ''), nombreUsuario) FROM usuarios WHERE id = @idUsuario", cn, tx))
                        {
                            cmdUser.Parameters.AddWithValue("@idUsuario", ajuste.IdUsuario);
                            object uVal = cmdUser.ExecuteScalar();
                            if (uVal != null && uVal != DBNull.Value)
                                nombreUsuario = Convert.ToString(uVal);
                        }

                        // 3. Procesar los detalles
                        foreach (var det in ajuste.Detalles)
                        {
                            // A. Consultar stock y precio actuales del producto
                            decimal stockAnterior = 0;
                            decimal precioAnterior = 0;
                            using (var cmdProdInfo = new MySqlCommand("SELECT stock, COALESCE(costoUnidad, 0) FROM productos WHERE id = @idProducto", cn, tx))
                            {
                                cmdProdInfo.Parameters.AddWithValue("@idProducto", det.IdProducto);
                                using (var rd = cmdProdInfo.ExecuteReader())
                                {
                                    if (rd.Read())
                                    {
                                        stockAnterior = rd.GetDecimal(0);
                                        precioAnterior = rd.GetDecimal(1);
                                    }
                                }
                            }

                            decimal diferencia = det.Cantidad - stockAnterior;

                            // B. Insertar detalle del ajuste
                            string sqlDet = @"INSERT INTO ajustes_inventario_detalle 
                                (idAjuste, idProducto, cantidad, costoUnitario, total, precioAnterior, stockAnterior, diferencia)
                                VALUES (@idAjuste, @idProducto, @cantidad, @costoUnitario, @total, @precioAnterior, @stockAnterior, @diferencia);";
                            using (var cmdDet = new MySqlCommand(sqlDet, cn, tx))
                            {
                                cmdDet.Parameters.AddWithValue("@idAjuste", idAjuste);
                                cmdDet.Parameters.AddWithValue("@idProducto", det.IdProducto);
                                cmdDet.Parameters.AddWithValue("@cantidad", det.Cantidad);
                                cmdDet.Parameters.AddWithValue("@costoUnitario", det.Costo);
                                cmdDet.Parameters.AddWithValue("@total", det.Total);
                                cmdDet.Parameters.AddWithValue("@precioAnterior", precioAnterior);
                                cmdDet.Parameters.AddWithValue("@stockAnterior", stockAnterior);
                                cmdDet.Parameters.AddWithValue("@diferencia", diferencia);
                                cmdDet.ExecuteNonQuery();
                            }

                            // C. Actualizar producto (stock global y costo)
                            string sqlUpdProd = "UPDATE productos SET stock = @stock, costoUnidad = @costo WHERE id = @idProducto;";
                            using (var cmdUpdProd = new MySqlCommand(sqlUpdProd, cn, tx))
                            {
                                cmdUpdProd.Parameters.AddWithValue("@stock", det.Cantidad);
                                cmdUpdProd.Parameters.AddWithValue("@costo", det.Costo);
                                cmdUpdProd.Parameters.AddWithValue("@idProducto", det.IdProducto);
                                cmdUpdProd.ExecuteNonQuery();
                            }

                            // D. Sincronizar con la tabla de lotes (inventario_loteproducto)
                            if (ajuste.IdUbicacion > 0)
                            {
                                var lotes = new List<Tuple<int, decimal>>();
                                using (var cmdLotes = new MySqlCommand(@"
                                    SELECT id, cantidad_disponible 
                                    FROM inventario_loteproducto 
                                    WHERE producto_id = @idProducto AND ubicacion_id = @idUbicacion AND activo = 1 
                                    ORDER BY fecha_caducidad ASC, id ASC", cn, tx))
                                {
                                    cmdLotes.Parameters.AddWithValue("@idProducto", det.IdProducto);
                                    cmdLotes.Parameters.AddWithValue("@idUbicacion", ajuste.IdUbicacion);
                                    using (var rdL = cmdLotes.ExecuteReader())
                                    {
                                        while (rdL.Read())
                                        {
                                            lotes.Add(Tuple.Create(rdL.GetInt32(0), rdL.GetDecimal(1)));
                                        }
                                    }
                                }

                                if (lotes.Count > 0)
                                {
                                    // Actualizar el primer lote con la cantidad nueva total
                                    int firstLoteId = lotes[0].Item1;
                                    using (var cmdUpdLote = new MySqlCommand("UPDATE inventario_loteproducto SET cantidad_disponible = @cantidad, costo_unitario = @costo, fecha_actualizacion = NOW() WHERE id = @id", cn, tx))
                                    {
                                        cmdUpdLote.Parameters.AddWithValue("@cantidad", det.Cantidad);
                                        cmdUpdLote.Parameters.AddWithValue("@costo", det.Costo);
                                        cmdUpdLote.Parameters.AddWithValue("@id", firstLoteId);
                                        cmdUpdLote.ExecuteNonQuery();
                                    }

                                    // Poner a 0 los otros lotes para evitar duplicación
                                    for (int i = 1; i < lotes.Count; i++)
                                    {
                                        using (var cmdUpdOther = new MySqlCommand("UPDATE inventario_loteproducto SET cantidad_disponible = 0, fecha_actualizacion = NOW() WHERE id = @id", cn, tx))
                                        {
                                            cmdUpdOther.Parameters.AddWithValue("@id", lotes[i].Item1);
                                            cmdUpdOther.ExecuteNonQuery();
                                        }
                                    }
                                }
                                else
                                {
                                    // Si no hay lote, se crea un lote GENERICO
                                    string sqlInsLote = @"INSERT INTO inventario_loteproducto 
                                        (producto_id, ubicacion_id, numero_lote, fecha_ingreso, fecha_creacion, fecha_actualizacion, cantidad_inicial, cantidad_disponible, costo_unitario, activo, idEmpresa) 
                                        VALUES (@idProducto, @idUbicacion, 'GENERICO', CURDATE(), NOW(), NOW(), @cantidad, @cantidad, @costo, 1, @idEmpresa);";
                                    using (var cmdInsLote = new MySqlCommand(sqlInsLote, cn, tx))
                                    {
                                        cmdInsLote.Parameters.AddWithValue("@idProducto", det.IdProducto);
                                        cmdInsLote.Parameters.AddWithValue("@idUbicacion", ajuste.IdUbicacion);
                                        cmdInsLote.Parameters.AddWithValue("@cantidad", det.Cantidad);
                                        cmdInsLote.Parameters.AddWithValue("@costo", det.Costo);
                                        cmdInsLote.Parameters.AddWithValue("@idEmpresa", Conexion.IdEmpresa);
                                        cmdInsLote.ExecuteNonQuery();
                                    }
                                }

                                // E. Sincronizar en la tabla de stock por ubicación (inventario_stockubicacion)
                                long stockLocId = 0;
                                using (var cmdCheckStockLoc = new MySqlCommand("SELECT id FROM inventario_stockubicacion WHERE producto_id = @idProducto AND ubicacion_id = @idUbicacion AND idEmpresa = @idEmpresa LIMIT 1", cn, tx))
                                {
                                    cmdCheckStockLoc.Parameters.AddWithValue("@idProducto", det.IdProducto);
                                    cmdCheckStockLoc.Parameters.AddWithValue("@idUbicacion", ajuste.IdUbicacion);
                                    cmdCheckStockLoc.Parameters.AddWithValue("@idEmpresa", Conexion.IdEmpresa);
                                    object val = cmdCheckStockLoc.ExecuteScalar();
                                    if (val != null && val != DBNull.Value)
                                        stockLocId = Convert.ToInt64(val);
                                }

                                if (stockLocId > 0)
                                {
                                    using (var cmdUpdLoc = new MySqlCommand("UPDATE inventario_stockubicacion SET cantidad = @cantidad, editadoDate = NOW(), ultima_actualizacion = NOW() WHERE id = @id", cn, tx))
                                    {
                                        cmdUpdLoc.Parameters.AddWithValue("@cantidad", det.Cantidad);
                                        cmdUpdLoc.Parameters.AddWithValue("@id", stockLocId);
                                        cmdUpdLoc.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    using (var cmdInsLoc = new MySqlCommand(@"INSERT INTO inventario_stockubicacion 
                                        (cantidad, stock_minimo, stock_maximo, punto_reorden, creadoDate, editadoDate, producto_id, ubicacion_id, idEmpresa, ultima_actualizacion) 
                                        VALUES (@cantidad, 0.00, 0.00, 0.00, NOW(), NOW(), @idProducto, @idUbicacion, @idEmpresa, NOW());", cn, tx))
                                    {
                                        cmdInsLoc.Parameters.AddWithValue("@cantidad", det.Cantidad);
                                        cmdInsLoc.Parameters.AddWithValue("@idProducto", det.IdProducto);
                                        cmdInsLoc.Parameters.AddWithValue("@idUbicacion", ajuste.IdUbicacion);
                                        cmdInsLoc.Parameters.AddWithValue("@idEmpresa", Conexion.IdEmpresa);
                                        cmdInsLoc.ExecuteNonQuery();
                                    }
                                }
                            }

                            // F. Integrar con kardex_movimientos si hay diferencia
                            if (diferencia != 0)
                            {
                                string insertKardexQuery = @"
                                    INSERT INTO kardex_movimientos (
                                        idProducto, fecha, tipoMovimiento, detalle, 
                                        ingreso, egreso, saldo, costo, costo_promedio, precio, usuario, numero_documento, idEmpresa, idUbicacion
                                    ) VALUES (
                                        @idProducto, NOW(), @tipoMovimiento, @detalle, 
                                        @ingreso, @egreso, @saldo, @costo, @costo, 0.00, @usuario, @numero_documento, @idEmpresa, @idUbicacion
                                    );";

                                using (var cmdKardex = new MySqlCommand(insertKardexQuery, cn, tx))
                                {
                                    string mType = (diferencia > 0) ? "AJUSTE INGRESO" : "AJUSTE EGRESO";
                                    decimal ingreso = (diferencia > 0) ? diferencia : 0;
                                    decimal egreso = (diferencia < 0) ? Math.Abs(diferencia) : 0;

                                    cmdKardex.Parameters.AddWithValue("@idProducto", det.IdProducto);
                                    cmdKardex.Parameters.AddWithValue("@tipoMovimiento", mType);
                                    cmdKardex.Parameters.AddWithValue("@detalle", "AJUSTE DE INVENTARIO NRO. " + ajuste.NumeroDocumento);
                                    cmdKardex.Parameters.AddWithValue("@ingreso", ingreso);
                                    cmdKardex.Parameters.AddWithValue("@egreso", egreso);
                                    cmdKardex.Parameters.AddWithValue("@saldo", det.Cantidad);
                                    cmdKardex.Parameters.AddWithValue("@costo", det.Costo);
                                    cmdKardex.Parameters.AddWithValue("@usuario", nombreUsuario);
                                    cmdKardex.Parameters.AddWithValue("@numero_documento", ajuste.NumeroDocumento);
                                    cmdKardex.Parameters.AddWithValue("@idEmpresa", Conexion.IdEmpresa);
                                    cmdKardex.Parameters.AddWithValue("@idUbicacion", (ajuste.IdUbicacion > 0) ? (object)ajuste.IdUbicacion : DBNull.Value);
                                    cmdKardex.ExecuteNonQuery();
                                }
                            }
                        }

                        tx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        throw new Exception("Error al guardar ajuste: " + ex.Message);
                    }
                }
            }
        }

        private static int GetIdTipoAjuste(string tipo)
        {
            switch (tipo?.ToUpper())
            {
                case "INGRESO POR AJUSTE":
                case "INGRESO":
                    return 1;
                case "EGRESO POR AJUSTE":
                case "EGRESO":
                    return 2;
                case "PRODUCTO DAÑADO":
                case "PRODUCTO DAADO":
                    return 3;
                case "PRODUCTO VENCIDO":
                    return 4;
                default:
                    return 1;
            }
        }
    }
}
