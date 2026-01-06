using LogiPharm.Entidades;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace LogiPharm.Datos
{
    public class DInventarioLotes
    {
        /// <summary>
        /// Obtiene todos los lotes de un producto buscando por código de producto
        /// </summary>
        public List<EInventarioLote> ObtenerLotesPorCodigoProducto(string codigoProducto, int? idUbicacion = null, bool? soloActivos = true)
        {
            var lotes = new List<EInventarioLote>();
            
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                        SELECT 
                            il.id,
                            il.producto_id,
                            il.ubicacion_id,
                            il.numero_lote,
                            il.fecha_ingreso,
                            il.fecha_caducidad,
                            il.cantidad_disponible,
                            il.cantidad_reservada,
                            il.cantidad_inicial,
                            il.activo,
                            DATEDIFF(il.fecha_caducidad, CURDATE()) AS diasParaCaducidad,
                            p.codigoPrincipal AS codigoProducto,
                            p.nombre AS nombreProducto,
                            u.nombre AS nombreUbicacion
                        FROM inventario_loteproducto il
                        INNER JOIN productos p ON il.producto_id = p.id
                        INNER JOIN inventario_ubicacion u ON il.ubicacion_id = u.id
                        WHERE p.codigoPrincipal = @codigoProducto";

                    if (idUbicacion.HasValue)
                        query += " AND il.ubicacion_id = @idUbicacion";
                    
                    if (soloActivos.HasValue && soloActivos.Value)
                        query += " AND il.activo = 1 AND il.cantidad_disponible > 0";

                    query += " ORDER BY il.fecha_caducidad ASC, il.fecha_ingreso ASC;";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@codigoProducto", codigoProducto);
                    
                    if (idUbicacion.HasValue)
                        cmd.Parameters.AddWithValue("@idUbicacion", idUbicacion.Value);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lotes.Add(new EInventarioLote
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                IdProducto = Convert.ToInt32(reader["producto_id"]),
                                IdUbicacion = Convert.ToInt32(reader["ubicacion_id"]),
                                NumeroLote = reader["numero_lote"]?.ToString() ?? "",
                                FechaIngreso = Convert.ToDateTime(reader["fecha_ingreso"]),
                                FechaCaducidad = Convert.ToDateTime(reader["fecha_caducidad"]),
                                StockDisponible = Convert.ToDecimal(reader["cantidad_disponible"]),
                                StockReservado = Convert.ToDecimal(reader["cantidad_reservada"]),
                                StockTotal = Convert.ToDecimal(reader["cantidad_inicial"]),
                                Estado = Convert.ToBoolean(reader["activo"]) ? "VIGENTE" : "INACTIVO",
                                DiasParaCaducidad = Convert.ToInt32(reader["diasParaCaducidad"]),
                                CodigoProducto = reader["codigoProducto"]?.ToString() ?? "",
                                NombreProducto = reader["nombreProducto"]?.ToString() ?? "",
                                NombreUbicacion = reader["nombreUbicacion"]?.ToString() ?? ""
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener lotes por código de producto: " + ex.Message);
                }
            }

            return lotes;
        }

        /// <summary>
        /// Obtiene los lotes disponibles de un producto en una ubicación específica
        /// </summary>
        public List<EInventarioLote> ObtenerLotesDisponiblesPorProductoYUbicacion(int idProducto, int idUbicacion)
        {
            var lotes = new List<EInventarioLote>();
            
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                        SELECT 
                            il.id,
                            il.producto_id,
                            il.ubicacion_id,
                            il.numero_lote,
                            il.fecha_ingreso,
                            il.fecha_caducidad,
                            il.cantidad_disponible,
                            il.cantidad_reservada,
                            il.cantidad_inicial,
                            il.activo,
                            DATEDIFF(il.fecha_caducidad, CURDATE()) AS diasParaCaducidad,
                            p.codigoPrincipal AS codigoProducto,
                            p.nombre AS nombreProducto,
                            u.nombre AS nombreUbicacion
                        FROM inventario_loteproducto il
                        INNER JOIN productos p ON il.producto_id = p.id
                        INNER JOIN inventario_ubicacion u ON il.ubicacion_id = u.id
                        WHERE il.producto_id = @idProducto 
                          AND il.ubicacion_id = @idUbicacion
                          AND il.cantidad_disponible > 0
                          AND il.activo = 1
                        ORDER BY il.fecha_caducidad ASC, il.fecha_ingreso ASC;";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);
                    cmd.Parameters.AddWithValue("@idUbicacion", idUbicacion);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lotes.Add(new EInventarioLote
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                IdProducto = Convert.ToInt32(reader["producto_id"]),
                                IdUbicacion = Convert.ToInt32(reader["ubicacion_id"]),
                                NumeroLote = reader["numero_lote"]?.ToString() ?? "",
                                FechaIngreso = Convert.ToDateTime(reader["fecha_ingreso"]),
                                FechaCaducidad = Convert.ToDateTime(reader["fecha_caducidad"]),
                                StockDisponible = Convert.ToDecimal(reader["cantidad_disponible"]),
                                StockReservado = Convert.ToDecimal(reader["cantidad_reservada"]),
                                StockTotal = Convert.ToDecimal(reader["cantidad_inicial"]),
                                Estado = Convert.ToBoolean(reader["activo"]) ? "VIGENTE" : "INACTIVO",
                                DiasParaCaducidad = Convert.ToInt32(reader["diasParaCaducidad"]),
                                CodigoProducto = reader["codigoProducto"]?.ToString() ?? "",
                                NombreProducto = reader["nombreProducto"]?.ToString() ?? "",
                                NombreUbicacion = reader["nombreUbicacion"]?.ToString() ?? ""
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener lotes disponibles: " + ex.Message);
                }
            }

            return lotes;
        }

        /// <summary>
        /// Obtiene todos los lotes de un producto en todas las ubicaciones
        /// </summary>
        public List<EInventarioLote> ObtenerLotesPorProducto(int idProducto)
        {
            var lotes = new List<EInventarioLote>();
            
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                        SELECT 
                            il.id,
                            il.producto_id,
                            il.ubicacion_id,
                            il.numero_lote,
                            il.fecha_ingreso,
                            il.fecha_caducidad,
                            il.cantidad_disponible,
                            il.cantidad_reservada,
                            il.cantidad_inicial,
                            il.activo,
                            DATEDIFF(il.fecha_caducidad, CURDATE()) AS diasParaCaducidad,
                            p.codigoPrincipal AS codigoProducto,
                            p.nombre AS nombreProducto,
                            u.nombre AS nombreUbicacion
                        FROM inventario_loteproducto il
                        INNER JOIN productos p ON il.producto_id = p.id
                        INNER JOIN inventario_ubicacion u ON il.ubicacion_id = u.id
                        WHERE il.producto_id = @idProducto
                          AND il.cantidad_disponible > 0
                          AND il.activo = 1
                        ORDER BY il.ubicacion_id, il.fecha_caducidad ASC;";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lotes.Add(new EInventarioLote
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                IdProducto = Convert.ToInt32(reader["producto_id"]),
                                IdUbicacion = Convert.ToInt32(reader["ubicacion_id"]),
                                NumeroLote = reader["numero_lote"]?.ToString() ?? "",
                                FechaIngreso = Convert.ToDateTime(reader["fecha_ingreso"]),
                                FechaCaducidad = Convert.ToDateTime(reader["fecha_caducidad"]),
                                StockDisponible = Convert.ToDecimal(reader["cantidad_disponible"]),
                                StockReservado = Convert.ToDecimal(reader["cantidad_reservada"]),
                                StockTotal = Convert.ToDecimal(reader["cantidad_inicial"]),
                                Estado = Convert.ToBoolean(reader["activo"]) ? "VIGENTE" : "INACTIVO",
                                DiasParaCaducidad = Convert.ToInt32(reader["diasParaCaducidad"]),
                                CodigoProducto = reader["codigoProducto"]?.ToString() ?? "",
                                NombreProducto = reader["nombreProducto"]?.ToString() ?? "",
                                NombreUbicacion = reader["nombreUbicacion"]?.ToString() ?? ""
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener lotes del producto: " + ex.Message);
                }
            }

            return lotes;
        }

        /// <summary>
        /// Obtiene el stock total disponible de un producto en una ubicación
        /// </summary>
        public decimal ObtenerStockTotalDisponible(int idProducto, int idUbicacion)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                        SELECT COALESCE(SUM(cantidad_disponible), 0) 
                        FROM inventario_loteproducto
                        WHERE producto_id = @idProducto 
                          AND ubicacion_id = @idUbicacion
                          AND activo = 1
                          AND cantidad_disponible > 0;";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);
                    cmd.Parameters.AddWithValue("@idUbicacion", idUbicacion);

                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener stock total: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Reserva stock de un lote específico
        /// </summary>
        public bool ReservarStock(int idLote, decimal cantidad)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                using (var transaction = cn.BeginTransaction())
                {
                    try
                    {
                        string query = @"
                            UPDATE inventario_loteproducto 
                            SET cantidad_disponible = cantidad_disponible - @cantidad,
                                cantidad_reservada = cantidad_reservada + @cantidad
                            WHERE id = @id 
                              AND cantidad_disponible >= @cantidad;";

                        MySqlCommand cmd = new MySqlCommand(query, cn, transaction);
                        cmd.Parameters.AddWithValue("@id", idLote);
                        cmd.Parameters.AddWithValue("@cantidad", cantidad);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            throw new Exception("No hay stock suficiente disponible en el lote.");
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Libera stock reservado de un lote
        /// </summary>
        public bool LiberarStockReservado(int idLote, decimal cantidad)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                using (var transaction = cn.BeginTransaction())
                {
                    try
                    {
                        string query = @"
                            UPDATE inventario_loteproducto 
                            SET cantidad_disponible = cantidad_disponible + @cantidad,
                                cantidad_reservada = cantidad_reservada - @cantidad
                            WHERE id = @id;";

                        MySqlCommand cmd = new MySqlCommand(query, cn, transaction);
                        cmd.Parameters.AddWithValue("@id", idLote);
                        cmd.Parameters.AddWithValue("@cantidad", cantidad);

                        cmd.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Obtiene todos los lotes con filtros opcionales
        /// </summary>
        public List<EInventarioLote> ObtenerTodosLotes(int? idProducto = null, int? idUbicacion = null, DateTime? fechaDesde = null, DateTime? fechaHasta = null, bool? soloActivos = true)
        {
            var lotes = new List<EInventarioLote>();
            
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                        SELECT 
                            il.id,
                            il.producto_id,
                            il.ubicacion_id,
                            il.numero_lote,
                            il.fecha_ingreso,
                            il.fecha_fabricacion,
                            il.fecha_caducidad,
                            il.cantidad_disponible,
                            il.cantidad_reservada,
                            il.cantidad_inicial,
                            il.costo_unitario,
                            il.numero_factura,
                            il.activo,
                            DATEDIFF(il.fecha_caducidad, CURDATE()) AS diasParaCaducidad,
                            p.codigoPrincipal AS codigoProducto,
                            p.nombre AS nombreProducto,
                            u.nombre AS nombreUbicacion
                        FROM inventario_loteproducto il
                        INNER JOIN productos p ON il.producto_id = p.id
                        INNER JOIN inventario_ubicacion u ON il.ubicacion_id = u.id
                        WHERE 1=1";

                    if (idProducto.HasValue)
                        query += " AND il.producto_id = @idProducto";
                    
                    if (idUbicacion.HasValue)
                        query += " AND il.ubicacion_id = @idUbicacion";
                    
                    if (fechaDesde.HasValue)
                        query += " AND il.fecha_caducidad >= @fechaDesde";
                    
                    if (fechaHasta.HasValue)
                        query += " AND il.fecha_caducidad <= @fechaHasta";
                    
                    if (soloActivos.HasValue && soloActivos.Value)
                        query += " AND il.activo = 1";

                    query += " ORDER BY il.fecha_caducidad ASC, p.nombre ASC LIMIT 500;";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    
                    if (idProducto.HasValue)
                        cmd.Parameters.AddWithValue("@idProducto", idProducto.Value);
                    
                    if (idUbicacion.HasValue)
                        cmd.Parameters.AddWithValue("@idUbicacion", idUbicacion.Value);
                    
                    if (fechaDesde.HasValue)
                        cmd.Parameters.AddWithValue("@fechaDesde", fechaDesde.Value);
                    
                    if (fechaHasta.HasValue)
                        cmd.Parameters.AddWithValue("@fechaHasta", fechaHasta.Value);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var lote = new EInventarioLote
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                IdProducto = Convert.ToInt32(reader["producto_id"]),
                                IdUbicacion = Convert.ToInt32(reader["ubicacion_id"]),
                                NumeroLote = reader["numero_lote"]?.ToString() ?? "",
                                FechaIngreso = Convert.ToDateTime(reader["fecha_ingreso"]),
                                FechaCaducidad = Convert.ToDateTime(reader["fecha_caducidad"]),
                                StockDisponible = Convert.ToDecimal(reader["cantidad_disponible"]),
                                StockReservado = Convert.ToDecimal(reader["cantidad_reservada"]),
                                StockTotal = Convert.ToDecimal(reader["cantidad_inicial"]),
                                Estado = Convert.ToBoolean(reader["activo"]) ? "VIGENTE" : "INACTIVO",
                                DiasParaCaducidad = Convert.ToInt32(reader["diasParaCaducidad"]),
                                CodigoProducto = reader["codigoProducto"]?.ToString() ?? "",
                                NombreProducto = reader["nombreProducto"]?.ToString() ?? "",
                                NombreUbicacion = reader["nombreUbicacion"]?.ToString() ?? ""
                            };
                            
                            lotes.Add(lote);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener lotes: " + ex.Message + " | Inner: " + (ex.InnerException?.Message ?? ""));
                }
            }

            return lotes;
        }

        /// <summary>
        /// Obtiene un lote específico por su ID
        /// </summary>
        public EInventarioLote ObtenerLotePorId(int idLote)
        {
            EInventarioLote lote = null;
            
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                        SELECT 
                            il.id,
                            il.producto_id,
                            il.ubicacion_id,
                            il.numero_lote,
                            il.fecha_ingreso,
                            il.fecha_fabricacion,
                            il.fecha_caducidad,
                            il.cantidad_disponible,
                            il.cantidad_reservada,
                            il.cantidad_inicial,
                            il.costo_unitario,
                            il.numero_factura,
                            il.observaciones,
                            il.activo,
                            DATEDIFF(il.fecha_caducidad, CURDATE()) AS diasParaCaducidad,
                            p.codigoPrincipal AS codigoProducto,
                            p.nombre AS nombreProducto,
                            u.nombre AS nombreUbicacion
                        FROM inventario_loteproducto il
                        INNER JOIN productos p ON il.producto_id = p.id
                        INNER JOIN inventario_ubicacion u ON il.ubicacion_id = u.id
                        WHERE il.id = @idLote;";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idLote", idLote);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lote = new EInventarioLote
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                IdProducto = Convert.ToInt32(reader["producto_id"]),
                                IdUbicacion = Convert.ToInt32(reader["ubicacion_id"]),
                                NumeroLote = reader["numero_lote"]?.ToString() ?? "",
                                FechaIngreso = Convert.ToDateTime(reader["fecha_ingreso"]),
                                FechaFabricacion = reader["fecha_fabricacion"] != DBNull.Value ? Convert.ToDateTime(reader["fecha_fabricacion"]) : DateTime.Today,
                                FechaCaducidad = Convert.ToDateTime(reader["fecha_caducidad"]),
                                StockDisponible = Convert.ToDecimal(reader["cantidad_disponible"]),
                                StockReservado = Convert.ToDecimal(reader["cantidad_reservada"]),
                                StockTotal = Convert.ToDecimal(reader["cantidad_inicial"]),
                                CostoUnitario = reader["costo_unitario"] != DBNull.Value ? Convert.ToDecimal(reader["costo_unitario"]) : 0m,
                                NumeroFactura = reader["numero_factura"]?.ToString() ?? "",
                                Observaciones = reader["observaciones"]?.ToString() ?? "",
                                Estado = Convert.ToBoolean(reader["activo"]) ? "VIGENTE" : "INACTIVO",
                                DiasParaCaducidad = Convert.ToInt32(reader["diasParaCaducidad"]),
                                CodigoProducto = reader["codigoProducto"]?.ToString() ?? "",
                                NombreProducto = reader["nombreProducto"]?.ToString() ?? "",
                                NombreUbicacion = reader["nombreUbicacion"]?.ToString() ?? ""
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el lote: " + ex.Message);
                }
            }

            return lote;
        }

        /// <summary>
        /// Actualiza un lote existente
        /// </summary>
        public bool ActualizarLote(int idLote, string numeroLote, DateTime fechaIngreso, 
            DateTime fechaFabricacion, DateTime fechaCaducidad, decimal costoUnitario, 
            string numeroFactura, string observaciones, bool activo)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                using (var transaction = cn.BeginTransaction())
                {
                    try
                    {
                        string query = @"UPDATE inventario_loteproducto 
                            SET numero_lote = @numero_lote,
                                fecha_ingreso = @fecha_ingreso,
                                fecha_fabricacion = @fecha_fabricacion,
                                fecha_caducidad = @fecha_caducidad,
                                costo_unitario = @costo_unitario,
                                numero_factura = @numero_factura,
                                observaciones = @observaciones,
                                activo = @activo
                            WHERE id = @id";

                        MySqlCommand cmd = new MySqlCommand(query, cn, transaction);
                        cmd.Parameters.AddWithValue("@id", idLote);
                        cmd.Parameters.AddWithValue("@numero_lote", numeroLote ?? "");
                        cmd.Parameters.AddWithValue("@fecha_ingreso", fechaIngreso.Date);
                        cmd.Parameters.AddWithValue("@fecha_fabricacion", fechaFabricacion.Date);
                        cmd.Parameters.AddWithValue("@fecha_caducidad", fechaCaducidad.Date);
                        cmd.Parameters.AddWithValue("@costo_unitario", costoUnitario);
                        cmd.Parameters.AddWithValue("@numero_factura", numeroFactura ?? "");
                        cmd.Parameters.AddWithValue("@observaciones", observaciones ?? "");
                        cmd.Parameters.AddWithValue("@activo", activo ? 1 : 0);

                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Inserta un nuevo lote de producto
        /// </summary>
        public bool InsertarLote(int productoId, int ubicacionId, string numeroLote, DateTime fechaIngreso, 
            DateTime fechaFabricacion, DateTime fechaCaducidad, decimal cantidadInicial, decimal costoUnitario, 
            string numeroFactura, string observaciones, bool activo)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                using (var transaction = cn.BeginTransaction())
                {
                    try
                    {
                        string query = @"INSERT INTO inventario_loteproducto 
                            (producto_id, ubicacion_id, numero_lote, fecha_ingreso, fecha_fabricacion, fecha_caducidad, 
                             cantidad_inicial, cantidad_disponible, cantidad_reservada, costo_unitario, numero_factura, 
                             observaciones, activo, creadoDate) 
                            VALUES 
                            (@producto_id, @ubicacion_id, @numero_lote, @fecha_ingreso, @fecha_fabricacion, @fecha_caducidad, 
                             @cantidad_inicial, @cantidad_inicial, 0, @costo_unitario, @numero_factura, 
                             @observaciones, @activo, @creadoDate)";

                        MySqlCommand cmd = new MySqlCommand(query, cn, transaction);
                        cmd.Parameters.AddWithValue("@producto_id", productoId);
                        cmd.Parameters.AddWithValue("@ubicacion_id", ubicacionId);
                        cmd.Parameters.AddWithValue("@numero_lote", numeroLote ?? "");
                        cmd.Parameters.AddWithValue("@fecha_ingreso", fechaIngreso.Date);
                        cmd.Parameters.AddWithValue("@fecha_fabricacion", fechaFabricacion.Date);
                        cmd.Parameters.AddWithValue("@fecha_caducidad", fechaCaducidad.Date);
                        cmd.Parameters.AddWithValue("@cantidad_inicial", cantidadInicial);
                        cmd.Parameters.AddWithValue("@costo_unitario", costoUnitario);
                        cmd.Parameters.AddWithValue("@numero_factura", numeroFactura ?? "");
                        cmd.Parameters.AddWithValue("@observaciones", observaciones ?? "");
                        cmd.Parameters.AddWithValue("@activo", activo ? 1 : 0);
                        cmd.Parameters.AddWithValue("@creadoDate", DateTime.Now);

                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
