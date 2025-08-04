using MySqlConnector;
using System;
using System.Data;
using LogiPharm.Entidades;

namespace LogiPharm.Datos
{
    public class DRecepcionProductos
    {
        /// <summary>
        /// Guarda la factura de compra, su detalle, actualiza el stock y registra los movimientos.
        /// Busca o crea el proveedor si es necesario. Todo dentro de una única transacción.
        /// </summary>
        public bool GuardarRecepcion(EFacturaCompra factura)
        {
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                MySqlTransaction transaction = cn.BeginTransaction();

                try
                {
                    // 1. VERIFICAR SI LA FACTURA YA EXISTE POR NÚMERO DE AUTORIZACIÓN
                    string checkQuery = "SELECT COUNT(1) FROM facturas_compra WHERE autorizacion = @autorizacion";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, cn, transaction);
                    checkCmd.Parameters.AddWithValue("@autorizacion", factura.Autorizacion);
                    if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                    {
                        throw new Exception("La factura con este número de autorización ya ha sido registrada.");
                    }

                    // 2. BUSCAR O CREAR EL PROVEEDOR
                    string proveedorQuery = "SELECT id FROM proveedores WHERE ruc = @ruc LIMIT 1";
                    MySqlCommand cmdProveedor = new MySqlCommand(proveedorQuery, cn, transaction);
                    cmdProveedor.Parameters.AddWithValue("@ruc", factura.RucProveedor);
                    object proveedorResult = cmdProveedor.ExecuteScalar();

                    int idProveedor;
                    if (proveedorResult != null)
                    {
                        idProveedor = Convert.ToInt32(proveedorResult);
                    }
                    else
                    {
                        // Si el proveedor no existe, lo creamos
                        string insertProveedor = @"
                            INSERT INTO proveedores (ruc, razonSocial, direccion, creadoPor, creadoDate)
                            VALUES (@ruc, @razon, @direccion, 1, NOW());
                            SELECT LAST_INSERT_ID();";
                        MySqlCommand insertCmd = new MySqlCommand(insertProveedor, cn, transaction);
                        insertCmd.Parameters.AddWithValue("@ruc", factura.RucProveedor);
                        insertCmd.Parameters.AddWithValue("@razon", factura.RazonSocialProveedor);
                        insertCmd.Parameters.AddWithValue("@direccion", factura.DireccionProveedor);
                        insertCmd.Parameters.AddWithValue("@creadoPor", factura.IdUsuario);
                        idProveedor = Convert.ToInt32(insertCmd.ExecuteScalar());
                    }

                    // 3. INSERTAR EL ENCABEZADO DE LA FACTURA DE COMPRA
                    string insertFacturaQuery = @"
                        INSERT INTO facturas_compra (idProveedor, idUsuario, numeroFactura, autorizacion, fechaRecepcion, subtotal, descuento, iva, total, creadoPor, creadoDate)
                        VALUES (@idProveedor, @idUsuario, @numeroFactura, @autorizacion, @fecha, @subtotal, @descuento, @iva, @total, @creadoPor, NOW());
                        SELECT LAST_INSERT_ID();";

                    MySqlCommand cmdFactura = new MySqlCommand(insertFacturaQuery, cn, transaction);
                    cmdFactura.Parameters.AddWithValue("@idProveedor", idProveedor);
                    cmdFactura.Parameters.AddWithValue("@idUsuario", factura.IdUsuario);
                    cmdFactura.Parameters.AddWithValue("@numeroFactura", factura.NumeroFactura);
                    cmdFactura.Parameters.AddWithValue("@autorizacion", factura.Autorizacion);
                    cmdFactura.Parameters.AddWithValue("@fecha", factura.FechaRecepcion);
                    cmdFactura.Parameters.AddWithValue("@subtotal", factura.Subtotal);
                    cmdFactura.Parameters.AddWithValue("@descuento", factura.Descuento);
                    cmdFactura.Parameters.AddWithValue("@iva", factura.Iva);
                    cmdFactura.Parameters.AddWithValue("@total", factura.Total);
                    cmdFactura.Parameters.AddWithValue("@creadoPor", factura.IdUsuario);

                    long idFacturaCompra = Convert.ToInt64(cmdFactura.ExecuteScalar());

                    // 4. RECORRER LOS DETALLES, GUARDARLOS Y ACTUALIZAR EL STOCK
                    foreach (var detalle in factura.Detalles)
                    {
                        //if (detalle.IdProducto == 0)
                        //{
                        //    throw new Exception($"El producto con código '{detalle.CodigoProducto}' no está mapeado a un producto interno.");
                        //}

                        if (detalle.IdProducto == 0)
                        {
                            string insertProductoQuery = @"
                                INSERT INTO productos 
                                (
                                      nombre, codigoPrincipal, codigoAuxiliar,
                                    idTipoProducto, idClaseProducto, idCategoria, idSubcategoria, idSubnivel,
                                    idMarca, idLaboratorio,
                                    stock, stockMinimo, stockMaximo,
                                    esDivisible, esPsicotropico, requiereCadenaFrio, requiereSeguimiento,
                                    calculoABCManual, activo,
                                    creadoPor, creadoDate, precioVenta
                                )
                                VALUES 
                                (
                                     @nombre, @codigoPrincipal, @codigoAuxiliar,
                                        1, 1, 1, 1, 1, 1, 1,
                                        @stock, 0, 0,
                                        0, 0, 0, 0,
                                        0, 1,
                                        @creadoPor, NOW(), @precioVenta
                                );
                                SELECT LAST_INSERT_ID();";

                            MySqlCommand insertProductoCmd = new MySqlCommand(insertProductoQuery, cn, transaction);

                            // Asegúrate de que los nombres de los parámetros coincidan con la consulta
                            insertProductoCmd.Parameters.AddWithValue("@codigoPrincipal", detalle.CodigoProducto);
                            // Idealmente, el objeto 'detalle' debería tener una propiedad 'NombreProducto'
                            insertProductoCmd.Parameters.AddWithValue("@codigoAuxiliar", detalle.CodigoProducto);
                            insertProductoCmd.Parameters.AddWithValue("@stock", detalle.Cantidad);
                            insertProductoCmd.Parameters.AddWithValue("@nombre", detalle.NombreProducto); // <-- IMPORTANTE: Añadir esta propiedad a tu clase de detalle
                            insertProductoCmd.Parameters.AddWithValue("@descripcion", detalle.NombreProducto); // Puedes usar el mismo nombre como descripción inicial
                            insertProductoCmd.Parameters.AddWithValue("@creadoPor", factura.IdUsuario);
                            insertProductoCmd.Parameters.AddWithValue("@precioVenta", detalle.CostoUnitario);

                            // Ejecutamos la consulta y obtenemos el nuevo ID
                            detalle.IdProducto = Convert.ToInt32(insertProductoCmd.ExecuteScalar());
                        }

                        // Insertar en facturas_compra_detalle
                        string insertDetalleQuery = @"
                            INSERT INTO facturas_compra_detalle (idFacturaCompra, idProducto, cantidad, costoUnitario, total)
                            VALUES (@idFactura, @idProducto, @cantidad, @costo, @total);";
                        MySqlCommand cmdDetalle = new MySqlCommand(insertDetalleQuery, cn, transaction);
                        cmdDetalle.Parameters.AddWithValue("@idFactura", idFacturaCompra);
                        cmdDetalle.Parameters.AddWithValue("@idProducto", detalle.IdProducto);
                        cmdDetalle.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                        cmdDetalle.Parameters.AddWithValue("@costo", detalle.CostoUnitario);
                        cmdDetalle.Parameters.AddWithValue("@total", detalle.Total);
                        cmdDetalle.ExecuteNonQuery();

                        // Actualizar el stock del producto
                        string updateStockQuery = "UPDATE productos SET stock = stock + @cantidad WHERE id = @idProducto;";
                        MySqlCommand cmdStock = new MySqlCommand(updateStockQuery, cn, transaction);
                        cmdStock.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                        cmdStock.Parameters.AddWithValue("@idProducto", detalle.IdProducto);
                        cmdStock.ExecuteNonQuery();

                        // Insertar en movimientos_inventario
                        string insertMovimientoQuery = @"
                        INSERT INTO movimientos_inventario 
                        (idProducto, tipoMovimiento, cantidad, costoUnitario, idDocumentoReferencia, creadoPor, creadoDate)
                        VALUES (@idProducto, 'ENTRADA_COMPRA', @cantidad, @costo, @idFactura, @creadoPor, NOW());";
                        MySqlCommand cmdMovimiento = new MySqlCommand(insertMovimientoQuery, cn, transaction);
                        cmdMovimiento.Parameters.AddWithValue("@idProducto", detalle.IdProducto);
                        cmdMovimiento.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                        cmdMovimiento.Parameters.AddWithValue("@costo", detalle.CostoUnitario);
                        cmdMovimiento.Parameters.AddWithValue("@idFactura", idFacturaCompra);
                        cmdMovimiento.Parameters.AddWithValue("@creadoPor", factura.IdUsuario);
                        cmdMovimiento.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
