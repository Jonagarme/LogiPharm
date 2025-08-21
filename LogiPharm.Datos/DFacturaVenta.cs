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
        public void GuardarFactura(ECliente cliente, List<ProductoVenta> productos, string numeroFactura, int idCierreCaja, int idUsuario, string numeroAutorizacion)
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
                        }
                        iva = subtotal * 0.15m; // Asumiendo IVA 15%
                        total = subtotal - descuento + iva;

                        // --- 2. Insertar el encabezado de la factura (facturas_venta) ---
                        string sqlFactura = @"INSERT INTO facturas_venta 
                                            (idCliente, idUsuario, idCierreCaja, numeroFactura, numeroAutorizacion, fechaEmision, 
                                            subtotal, descuento, iva, total, estado, creadoPor, creadoDate, anulado)
                                            VALUES
                                            (@idCliente, @idUsuario, @idCierreCaja, @numeroFactura, @numeroAutorizacion, NOW(),
                                            @subtotal, @descuento, @iva, @total, 'PAGADA', @idUsuario, NOW(), 0);
                                            SELECT LAST_INSERT_ID();";

                        long idFacturaVenta;
                        using (var cmdFactura = new MySqlCommand(sqlFactura, cn, tran))
                        {
                            cmdFactura.Parameters.AddWithValue("@idCliente", cliente.Id);
                            cmdFactura.Parameters.AddWithValue("@idUsuario", idUsuario);
                            cmdFactura.Parameters.AddWithValue("@idCierreCaja", idCierreCaja);
                            cmdFactura.Parameters.AddWithValue("@numeroFactura", numeroFactura);
                            cmdFactura.Parameters.AddWithValue("@numeroAutorizacion", numeroAutorizacion); // ✅ Se añade el nuevo parámetro
                            cmdFactura.Parameters.AddWithValue("@subtotal", subtotal);
                            cmdFactura.Parameters.AddWithValue("@descuento", descuento);
                            cmdFactura.Parameters.AddWithValue("@iva", iva);
                            cmdFactura.Parameters.AddWithValue("@total", total);
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
                                decimal ivaProducto = prod.PrecioTotalSinImpuesto * 0.15m;
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
                        }

                        // --- 4. Si todo salió bien, confirma la transacción ---
                        tran.Commit();
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