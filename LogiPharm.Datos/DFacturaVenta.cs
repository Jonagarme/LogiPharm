using CapaDatos;
using LogiPharm.Entidades;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace LogiPharm.Datos
{
    public class DFacturaVenta
    {
        public void GuardarFactura(ECliente cliente, List<ProductoVenta> productos, string numeroFactura, int idCierreCaja, int idUsuario, string numeroAutorizacion, string claveAcceso, int idEmpresa, bool esEntrega = false, string estadoFactura = "PENDIENTE", int? idUbicacion = null)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                cn.Open();
                using (var tran = cn.BeginTransaction())
                {
                    try
                    {
                        // --- 1. Calcular totales ---
                        decimal subtotal = 0m, descuento = 0m, iva = 0m, total = 0m;
                        foreach (var prod in productos)
                        {
                            subtotal += prod.PrecioTotalSinImpuesto;
                            descuento += prod.Descuento;
                            
                            decimal prodIvaRate = prod.AplicaIva ? 0.15m : 0m;
                            iva += prod.PrecioTotalSinImpuesto * prodIvaRate;
                        }
                        iva = Math.Round(iva, 4, MidpointRounding.AwayFromZero);
                        total = Math.Round(subtotal + iva, 4, MidpointRounding.AwayFromZero);

                        // --- 2. Insertar el encabezado de la factura (facturas_venta) ---
                        string sqlFactura = @"INSERT INTO facturas_venta 
                                            (idCliente, idUsuario, idCierreCaja, numeroFactura, numeroAutorizacion, claveAcceso, fechaEmision, 
                                            subtotal, descuento, iva, total, estado, creadoPor, creadoDate, anulado,
                                            es_entrega, estadoFactura, idEmpresa)
                                            VALUES
                                            (@idCliente, @idUsuario, @idCierreCaja, @numeroFactura, @numeroAutorizacion, @claveAcceso, NOW(),
                                            @subtotal, @descuento, @iva, @total, 'PAGADA', @idUsuario, NOW(), 0,
                                            @es_entrega, @estadoFactura, @idEmpresa);
                                            SELECT LAST_INSERT_ID();";

                        long idFacturaVenta;
                        using (var cmdFactura = new MySqlCommand(sqlFactura, cn, tran))
                        {
                            cmdFactura.Parameters.AddWithValue("@idCliente", cliente.Id);
                            cmdFactura.Parameters.AddWithValue("@idUsuario", idUsuario);
                            cmdFactura.Parameters.AddWithValue("@idCierreCaja", idCierreCaja);
                            cmdFactura.Parameters.AddWithValue("@numeroFactura", numeroFactura);
                            cmdFactura.Parameters.AddWithValue("@numeroAutorizacion", numeroAutorizacion);
                            cmdFactura.Parameters.AddWithValue("@claveAcceso", claveAcceso ?? "");
                            cmdFactura.Parameters.AddWithValue("@subtotal", subtotal);
                            cmdFactura.Parameters.AddWithValue("@descuento", descuento);
                            cmdFactura.Parameters.AddWithValue("@iva", iva);
                            cmdFactura.Parameters.AddWithValue("@total", total);
                            cmdFactura.Parameters.AddWithValue("@es_entrega", esEntrega ? 1 : 0);
                            cmdFactura.Parameters.AddWithValue("@estadoFactura", estadoFactura);
                            cmdFactura.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                            idFacturaVenta = Convert.ToInt64(cmdFactura.ExecuteScalar());
                        }


                        // --- 3. Insertar cada producto en el detalle (facturas_venta_detalle) ---
                        foreach (var prod in productos)
                        {
                            string sqlDetalle = @"INSERT INTO facturas_venta_detalle
                                                (idFacturaVenta, idProducto, cantidad, precioUnitario, descuentoValor, ivaValor, total, productoNombre)
                                                VALUES
                                                (@idFacturaVenta, @idProducto, @cantidad, @precioUnitario, @descuentoValor, @ivaValor, @total, @productoNombre)";

                            using (var cmdDetalle = new MySqlCommand(sqlDetalle, cn, tran))
                            {
                                decimal prodIvaRate = prod.AplicaIva ? 0.15m : 0m;
                                decimal ivaProducto = Math.Round(prod.PrecioTotalSinImpuesto * prodIvaRate, 4, MidpointRounding.AwayFromZero);
                                cmdDetalle.Parameters.AddWithValue("@idFacturaVenta", idFacturaVenta);
                                cmdDetalle.Parameters.AddWithValue("@idProducto", prod.Id); // Necesitas el ID del producto
                                cmdDetalle.Parameters.AddWithValue("@cantidad", prod.Cantidad);
                                cmdDetalle.Parameters.AddWithValue("@precioUnitario", prod.PrecioUnitario);
                                cmdDetalle.Parameters.AddWithValue("@descuentoValor", prod.Descuento);
                                cmdDetalle.Parameters.AddWithValue("@ivaValor", ivaProducto);
                                cmdDetalle.Parameters.AddWithValue("@total", prod.PrecioTotalSinImpuesto + ivaProducto);
                                cmdDetalle.Parameters.AddWithValue("@productoNombre", prod.Descripcion);
                                cmdDetalle.ExecuteNonQuery();
                            }

                            // Descontar stock específico por ubicación/bodega en la tabla de lotes (inventario_loteproducto)
                            if (idUbicacion.HasValue)
                            {
                                decimal cantidadRestante = prod.Cantidad;
                                List<Tuple<int, decimal>> lotes = new List<Tuple<int, decimal>>();
                                string sqlSelectLotes = @"SELECT id, cantidad_disponible 
                                                         FROM inventario_loteproducto 
                                                         WHERE producto_id = @idProducto AND ubicacion_id = @idUbicacion AND activo = 1 AND cantidad_disponible > 0
                                                         ORDER BY fecha_caducidad ASC, id ASC;";
                                                         
                                using (var cmdLotes = new MySqlCommand(sqlSelectLotes, cn, tran))
                                {
                                    cmdLotes.Parameters.AddWithValue("@idProducto", prod.Id);
                                    cmdLotes.Parameters.AddWithValue("@idUbicacion", idUbicacion.Value);
                                    using (var readerLotes = cmdLotes.ExecuteReader())
                                    {
                                        while (readerLotes.Read())
                                        {
                                            lotes.Add(new Tuple<int, decimal>(
                                                Convert.ToInt32(readerLotes["id"]),
                                                Convert.ToDecimal(readerLotes["cantidad_disponible"])
                                            ));
                                        }
                                    }
                                }

                                foreach (var lote in lotes)
                                {
                                    if (cantidadRestante <= 0) break;

                                    int loteId = lote.Item1;
                                    decimal disponible = lote.Item2;

                                    if (disponible >= cantidadRestante)
                                    {
                                        string sqlUpdateL = "UPDATE inventario_loteproducto SET cantidad_disponible = cantidad_disponible - @cantidad WHERE id = @loteId;";
                                        using (var cmdUpdateL = new MySqlCommand(sqlUpdateL, cn, tran))
                                        {
                                            cmdUpdateL.Parameters.AddWithValue("@cantidad", cantidadRestante);
                                            cmdUpdateL.Parameters.AddWithValue("@loteId", loteId);
                                            cmdUpdateL.ExecuteNonQuery();
                                        }
                                        cantidadRestante = 0;
                                    }
                                    else
                                    {
                                        string sqlUpdateL = "UPDATE inventario_loteproducto SET cantidad_disponible = 0 WHERE id = @loteId;";
                                        using (var cmdUpdateL = new MySqlCommand(sqlUpdateL, cn, tran))
                                        {
                                            cmdUpdateL.Parameters.AddWithValue("@loteId", loteId);
                                            cmdUpdateL.ExecuteNonQuery();
                                        }
                                        cantidadRestante -= disponible;
                                    }
                                }

                                if (cantidadRestante > 0)
                                {
                                    if (lotes.Count > 0)
                                    {
                                        int firstLoteId = lotes[0].Item1;
                                        string sqlUpdateL = "UPDATE inventario_loteproducto SET cantidad_disponible = cantidad_disponible - @cantidad WHERE id = @loteId;";
                                        using (var cmdUpdateL = new MySqlCommand(sqlUpdateL, cn, tran))
                                        {
                                            cmdUpdateL.Parameters.AddWithValue("@cantidad", cantidadRestante);
                                            cmdUpdateL.Parameters.AddWithValue("@loteId", firstLoteId);
                                            cmdUpdateL.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        string sqlInsertL = @"INSERT INTO inventario_loteproducto 
                                            (producto_id, ubicacion_id, numero_lote, fecha_caducidad, cantidad_disponible, activo, creadoDate, editadoDate, idEmpresa) 
                                            VALUES (@idProducto, @idUbicacion, 'GENERICO', DATE_ADD(NOW(), INTERVAL 1 YEAR), @cantidadNegativa, 1, NOW(), NOW(), @idEmpresa);";
                                        using (var cmdInsertL = new MySqlCommand(sqlInsertL, cn, tran))
                                        {
                                            cmdInsertL.Parameters.AddWithValue("@idProducto", prod.Id);
                                            cmdInsertL.Parameters.AddWithValue("@idUbicacion", idUbicacion.Value);
                                            cmdInsertL.Parameters.AddWithValue("@cantidadNegativa", -cantidadRestante);
                                            cmdInsertL.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                                            cmdInsertL.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }

                            string sqlSaldo = "SELECT stock FROM productos WHERE id = @idProducto;";
                            decimal saldoActual;
                            using (var cmdSaldo = new MySqlCommand(sqlSaldo, cn, tran))
                            {
                                cmdSaldo.Parameters.AddWithValue("@idProducto", prod.Id);
                                saldoActual = Convert.ToDecimal(cmdSaldo.ExecuteScalar());
                            }

                            decimal nuevoSaldo = saldoActual - prod.Cantidad;

                            // ✨ 2. INSERTAR EL MOVIMIENTO EN EL KARDEX DETALLADO
                            string sqlKardex = @"INSERT INTO kardex_movimientos 
                                        (idProducto, tipoMovimiento, detalle, egreso, saldo, fecha, costo, costo_promedio, precio, usuario, cliente_proveedor, numero_documento, idEmpresa, idUbicacion, ingreso)
                                        VALUES 
                                        (@idProducto, 'EGRESO', @detalle, @egreso, @saldo, NOW(), @costo, @costo_promedio, @precio, @usuario, @cliente_proveedor, @numero_documento, @idEmpresa, @idUbicacion, 0);";
                            
                            using (var cmdKardex = new MySqlCommand(sqlKardex, cn, tran))
                            {
                                cmdKardex.Parameters.AddWithValue("@idProducto", prod.Id);
                                string tipoDocText = esEntrega ? "Nota de Entrega" : "Factura Venta";
                                cmdKardex.Parameters.AddWithValue("@detalle", $"{tipoDocText} N° {numeroFactura}");
                                cmdKardex.Parameters.AddWithValue("@egreso", prod.Cantidad);
                                cmdKardex.Parameters.AddWithValue("@saldo", nuevoSaldo);

                                // Obtener costo unitario
                                decimal costoU = 0m;
                                string sqlGetCosto = "SELECT costoUnidad FROM productos WHERE id = @idProducto;";
                                using (var cmdCosto = new MySqlCommand(sqlGetCosto, cn, tran))
                                {
                                    cmdCosto.Parameters.AddWithValue("@idProducto", prod.Id);
                                    var resCosto = cmdCosto.ExecuteScalar();
                                    if (resCosto != null && resCosto != DBNull.Value)
                                    {
                                        costoU = Convert.ToDecimal(resCosto);
                                    }
                                }

                                // Obtener nombre del usuario
                                string nombreUsuario = "";
                                string sqlGetUsuario = "SELECT nombreCompleto FROM usuarios WHERE id = @idUsuario;";
                                using (var cmdUser = new MySqlCommand(sqlGetUsuario, cn, tran))
                                {
                                    cmdUser.Parameters.AddWithValue("@idUsuario", idUsuario);
                                    var resUser = cmdUser.ExecuteScalar();
                                    if (resUser != null && resUser != DBNull.Value)
                                    {
                                        nombreUsuario = resUser.ToString();
                                    }
                                }

                                cmdKardex.Parameters.AddWithValue("@costo", costoU);
                                cmdKardex.Parameters.AddWithValue("@costo_promedio", costoU);
                                cmdKardex.Parameters.AddWithValue("@precio", prod.PrecioUnitario);
                                cmdKardex.Parameters.AddWithValue("@usuario", nombreUsuario);
                                cmdKardex.Parameters.AddWithValue("@cliente_proveedor", cliente.RazonSocial);
                                cmdKardex.Parameters.AddWithValue("@numero_documento", (esEntrega ? "N/E-" : "FAC-") + numeroFactura);
                                cmdKardex.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                                cmdKardex.Parameters.AddWithValue("@idUbicacion", (object)idUbicacion ?? DBNull.Value);
                                cmdKardex.ExecuteNonQuery();
                            }

                            // ✨ 3. ACTUALIZAR EL STOCK EN LA TABLA DE PRODUCTOS
                            string sqlUpdateStock = "UPDATE productos SET stock = @nuevoStock WHERE id = @idProducto;";
                            using (var cmdUpdateStock = new MySqlCommand(sqlUpdateStock, cn, tran))
                            {
                                cmdUpdateStock.Parameters.AddWithValue("@nuevoStock", nuevoSaldo);
                                cmdUpdateStock.Parameters.AddWithValue("@idProducto", prod.Id);
                                cmdUpdateStock.ExecuteNonQuery();
                            }
                        }

                        // --- 4. Si todo salió bien, confirma la transacción ---
                        tran.Commit();

                        // ✨ NUEVO: Actualizar los totales del cierre de caja después de guardar la venta
                        DCierreCaja d_Cierre = new DCierreCaja();
                        d_Cierre.ActualizarTotalesSistema(idCierreCaja);
                    }
                    catch (Exception)
                    {
                        // Si algo falla, revierte todos los cambios
                        tran.Rollback();
                        throw; // Lanza la excepción para que el formulario la capture
                    }
                }
            }
        }
    }
}
