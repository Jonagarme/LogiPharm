using CapaDatos;
using MySqlConnector;
using System;
using System.Data;
using LogiPharm.Entidades;

namespace LogiPharm.Datos
{
    public class DFacturasCompra
    {
        /// <summary>
        /// Lista todas las facturas de compra con filtros
        /// </summary>
        public DataTable ListarFacturas(DateTime fechaInicio, DateTime fechaFin, string busqueda, string estado)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                string filtroEstado = "";
                if (estado != "TODOS")
                {
                    filtroEstado = "AND fc.estado = @estado";
                }

                string sql = $@"
                    SELECT 
                        fc.id AS Id,
                        fc.numeroFactura AS NumeroFactura,
                        fc.autorizacion AS Autorizacion,
                        p.ruc AS RUC,
                        p.razonSocial AS Proveedor,
                        fc.fechaRecepcion AS Fecha,
                        fc.subtotal AS Subtotal,
                        fc.iva AS IVA,
                        fc.total AS Total,
                        'INGRESADA' AS Estado
                    FROM facturas_compra fc
                    LEFT JOIN proveedores p ON fc.idProveedor = p.id
                    WHERE DATE(fc.fechaRecepcion) BETWEEN @fechaInicio AND @fechaFin
                    {filtroEstado}
                    AND (
                        p.razonSocial LIKE @busqueda
                        OR fc.numeroFactura LIKE @busqueda
                        OR fc.autorizacion LIKE @busqueda
                    )
                    ORDER BY fc.fechaRecepcion DESC, fc.id DESC";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio.Date);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin.Date);
                    cmd.Parameters.AddWithValue("@busqueda", $"%{busqueda}%");
                    if (estado != "TODOS")
                    {
                        cmd.Parameters.AddWithValue("@estado", estado);
                    }

                    var dt = new DataTable();
                    new MySqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// Obtiene el detalle de una factura de compra espec�fica
        /// </summary>
        public DataTable ObtenerDetalle(int idFactura)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                string sql = @"
                    SELECT 
                        p.codigoPrincipal AS Codigo,
                        p.nombre AS Producto,
                        fcd.cantidad AS Cantidad,
                        fcd.costoUnitario AS CostoUnitario,
                        fcd.total AS Total
                    FROM facturas_compra_detalle fcd
                    INNER JOIN productos p ON fcd.idProducto = p.id
                    WHERE fcd.idFacturaCompra = @idFactura";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idFactura", idFactura);

                    var dt = new DataTable();
                    new MySqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// Obtiene informaci�n completa de una factura (encabezado)
        /// </summary>
        public DataRow ObtenerFactura(int idFactura)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                string sql = @"
                    SELECT 
                        fc.id,
                        fc.numeroFactura,
                        fc.autorizacion,
                        p.ruc,
                        p.razonSocial AS proveedor,
                        fc.fechaRecepcion,
                        fc.subtotal,
                        fc.iva,
                        fc.total
                    FROM facturas_compra fc
                    LEFT JOIN proveedores p ON fc.idProveedor = p.id
                    WHERE fc.id = @idFactura";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idFactura", idFactura);

                    var dt = new DataTable();
                    new MySqlDataAdapter(cmd).Fill(dt);

                    if (dt.Rows.Count > 0)
                        return dt.Rows[0];
                    return null;
                }
            }
        }

        /// <summary>
        /// Anula una factura de compra (marca como anulada pero no elimina)
        /// </summary>
        public bool AnularFactura(int idFactura, int idUsuario)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                cn.Open();
                MySqlTransaction transaction = cn.BeginTransaction();

                try
                {
                    // Actualizar estado de la factura
                    string updateFactura = @"
                        UPDATE facturas_compra 
                        SET estado = 'ANULADA',
                            editadoPor = @idUsuario,
                            editadoDate = NOW()
                        WHERE id = @idFactura";

                    MySqlCommand cmd = new MySqlCommand(updateFactura, cn, transaction);
                    cmd.Parameters.AddWithValue("@idFactura", idFactura);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.ExecuteNonQuery();

                    // Aqu� podr�as revertir el stock si es necesario
                    // TODO: Implementar l�gica de reversi�n de stock si se requiere

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

        public bool GuardarIngresoXML(EFacturaElectronica factura, System.Collections.Generic.List<EDetalleFacturaXML> detalles, int idUsuario)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                using (var transaction = cn.BeginTransaction())
                {
                    try
                    {
                        // 1. Evitar duplicidad por clave de acceso
                        string sqlCheck = "SELECT COUNT(1) FROM facturas_compra WHERE autorizacion = @autorizacion AND anulado = 0";
                        using (var cmdCheck = new MySqlCommand(sqlCheck, cn, transaction))
                        {
                            cmdCheck.Parameters.AddWithValue("@autorizacion", factura.ClaveAcceso);
                            if (Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0)
                            {
                                throw new Exception("Esta factura de compra (con clave de autorizaciÃ³n) ya se encuentra registrada en el sistema.");
                            }
                        }

                        // 2. Obtener o crear proveedor
                        int idProveedor = 0;
                        string sqlProv = "SELECT id FROM proveedores WHERE ruc = @ruc AND anulado = 0 LIMIT 1";
                        using (var cmdProv = new MySqlCommand(sqlProv, cn, transaction))
                        {
                            cmdProv.Parameters.AddWithValue("@ruc", factura.RucEmisor);
                            var resProv = cmdProv.ExecuteScalar();
                            if (resProv != null)
                            {
                                idProveedor = Convert.ToInt32(resProv);
                            }
                            else
                            {
                                // Crear proveedor
                                string sqlInsertProv = @"
                                    INSERT INTO proveedores (ruc, razonSocial, nombreComercial, direccion, estado, creadoPor, creadoDate, anulado)
                                    VALUES (@ruc, @razonSocial, @nombreComercial, @direccion, 1, @creadoPor, NOW(), 0);
                                    SELECT LAST_INSERT_ID();";
                                using (var cmdInsertProv = new MySqlCommand(sqlInsertProv, cn, transaction))
                                {
                                    cmdInsertProv.Parameters.AddWithValue("@ruc", factura.RucEmisor);
                                    cmdInsertProv.Parameters.AddWithValue("@razonSocial", factura.RazonSocialEmisor);
                                    cmdInsertProv.Parameters.AddWithValue("@nombreComercial", (object)factura.NombreComercialEmisor ?? factura.RazonSocialEmisor);
                                    cmdInsertProv.Parameters.AddWithValue("@direccion", (object)factura.DireccionMatriz ?? "S/D");
                                    cmdInsertProv.Parameters.AddWithValue("@creadoPor", idUsuario);
                                    idProveedor = Convert.ToInt32(cmdInsertProv.ExecuteScalar());
                                }
                            }
                        }

                        // 3. Insertar Cabecera de Factura de Compra
                        string numeroFactura = $"{factura.Establecimiento}-{factura.PuntoEmision}-{factura.Secuencial}";
                        string sqlInsertFactura = @"
                            INSERT INTO facturas_compra (
                                idProveedor, idUsuario, numeroFactura, autorizacion, fechaRecepcion,
                                subtotal, descuento, iva, total,
                                creadoPor, creadoDate, anulado, estado
                            ) VALUES (
                                @idProveedor, @idUsuario, @numeroFactura, @autorizacion, @fechaRecepcion,
                                @subtotal, @descuento, @iva, @total,
                                @creadoPor, NOW(), 0, 'PROCESADO'
                            );
                            SELECT LAST_INSERT_ID();";

                        long idFacturaCompra;
                        using (var cmdInsertFactura = new MySqlCommand(sqlInsertFactura, cn, transaction))
                        {
                            cmdInsertFactura.Parameters.AddWithValue("@idProveedor", idProveedor);
                            cmdInsertFactura.Parameters.AddWithValue("@idUsuario", idUsuario);
                            cmdInsertFactura.Parameters.AddWithValue("@numeroFactura", numeroFactura);
                            cmdInsertFactura.Parameters.AddWithValue("@autorizacion", factura.ClaveAcceso);
                            cmdInsertFactura.Parameters.AddWithValue("@fechaRecepcion", factura.FechaEmision);
                            cmdInsertFactura.Parameters.AddWithValue("@subtotal", factura.TotalSinImpuestos);
                            cmdInsertFactura.Parameters.AddWithValue("@descuento", factura.TotalDescuento);
                            cmdInsertFactura.Parameters.AddWithValue("@iva", factura.TotalImpuestos);
                            cmdInsertFactura.Parameters.AddWithValue("@total", factura.ImporteTotal);
                            cmdInsertFactura.Parameters.AddWithValue("@creadoPor", idUsuario);
                            idFacturaCompra = Convert.ToInt64(cmdInsertFactura.ExecuteScalar());
                        }

                        // 4. Recorrer los detalles
                        foreach (var det in detalles)
                        {
                            int idProducto = 0;

                            if (det.EsProductoNuevo || !det.IdProductoEncontrado.HasValue)
                            {
                                // Insertar producto nuevo
                                string sqlInsertProd = @"
                                    INSERT INTO productos (
                                        nombre, codigoPrincipal, codigoAuxiliar, descripcion,
                                        idTipoProducto, idClaseProducto, idCategoria, idSubcategoria, idSubnivel, idMarca, idLaboratorio,
                                        stock, stockMinimo, stockMaximo,
                                        costoUnidad, costoCaja, pvpUnidad, precioVenta,
                                        esDivisible, esPsicotropico, requiereCadenaFrio, requiereSeguimiento, calculoABCManual,
                                        clasificacionABC, activo, creadoPor, creadoDate, aplicaIva, fechaCaducidad
                                    ) VALUES (
                                        @nombre, @codigoPrincipal, @codigoAuxiliar, @descripcion,
                                        1, 1, 1, 1, 1, 1, 1,
                                        0, 0, 0,
                                        @costoUnidad, 0, @pvpUnidad, @precioVenta,
                                        @esDivisible, 0, 0, 0, 0,
                                        'C', 1, @creadoPor, NOW(), @aplicaIva, @fechaCaducidad
                                    );
                                    SELECT LAST_INSERT_ID();";

                                using (var cmdInsertProd = new MySqlCommand(sqlInsertProd, cn, transaction))
                                {
                                    cmdInsertProd.Parameters.AddWithValue("@nombre", det.Descripcion);
                                    cmdInsertProd.Parameters.AddWithValue("@codigoPrincipal", det.CodigoPrincipal);
                                    cmdInsertProd.Parameters.AddWithValue("@codigoAuxiliar", det.CodigoPrincipal);
                                    cmdInsertProd.Parameters.AddWithValue("@descripcion", det.Descripcion);
                                    cmdInsertProd.Parameters.AddWithValue("@costoUnidad", det.PrecioUnitario);
                                    cmdInsertProd.Parameters.AddWithValue("@pvpUnidad", det.PrecioVenta);
                                    cmdInsertProd.Parameters.AddWithValue("@precioVenta", det.PrecioVenta);
                                    cmdInsertProd.Parameters.AddWithValue("@esDivisible", det.EsDivisible);
                                    cmdInsertProd.Parameters.AddWithValue("@creadoPor", idUsuario);
                                    cmdInsertProd.Parameters.AddWithValue("@aplicaIva", det.Tarifa > 0 ? 1 : 0);
                                    cmdInsertProd.Parameters.AddWithValue("@fechaCaducidad", (object)det.FechaCaducidad ?? DBNull.Value);
                                    idProducto = Convert.ToInt32(cmdInsertProd.ExecuteScalar());
                                }
                            }
                            else
                            {
                                // Actualizar producto existente
                                idProducto = det.IdProductoEncontrado.Value;
                                string sqlUpdateProd = @"
                                    UPDATE productos SET
                                        costoUnidad = @costo,
                                        pvpUnidad = @pvp,
                                        precioVenta = @pvp,
                                        aplicaIva = @aplicaIva,
                                        fechaCaducidad = COALESCE(@fechaCaducidad, fechaCaducidad),
                                        esDivisible = @esDivisible
                                    WHERE id = @idProduct";

                                using (var cmdUpdateProd = new MySqlCommand(sqlUpdateProd, cn, transaction))
                                {
                                    cmdUpdateProd.Parameters.AddWithValue("@costo", det.PrecioUnitario);
                                    cmdUpdateProd.Parameters.AddWithValue("@pvp", det.PrecioVenta);
                                    cmdUpdateProd.Parameters.AddWithValue("@aplicaIva", det.Tarifa > 0 ? 1 : 0);
                                    cmdUpdateProd.Parameters.AddWithValue("@fechaCaducidad", (object)det.FechaCaducidad ?? DBNull.Value);
                                    cmdUpdateProd.Parameters.AddWithValue("@esDivisible", det.EsDivisible);
                                    cmdUpdateProd.Parameters.AddWithValue("@idProduct", idProducto);
                                    cmdUpdateProd.ExecuteNonQuery();
                                }
                            }

                            // Afectar stock del producto
                            string sqlUpdateStock = "UPDATE productos SET stock = stock + @cantidad WHERE id = @idProducto";
                            using (var cmdUpdateStock = new MySqlCommand(sqlUpdateStock, cn, transaction))
                            {
                                cmdUpdateStock.Parameters.AddWithValue("@cantidad", det.Cantidad);
                                cmdUpdateStock.Parameters.AddWithValue("@idProducto", idProducto);
                                cmdUpdateStock.ExecuteNonQuery();
                            }

                            // Obtener saldo de stock resultante para el Kardex
                            decimal stockActual = 0;
                            string sqlGetStock = "SELECT stock FROM productos WHERE id = @idProducto";
                            using (var cmdGetStock = new MySqlCommand(sqlGetStock, cn, transaction))
                            {
                                cmdGetStock.Parameters.AddWithValue("@idProducto", idProducto);
                                stockActual = Convert.ToDecimal(cmdGetStock.ExecuteScalar());
                            }

                            // Registrar en Kardex
                            string sqlInsertKardex = @"
                                INSERT INTO kardex_movimientos (
                                    idProducto, fecha, tipoMovimiento, detalle,
                                    ingreso, egreso, saldo
                                ) VALUES (
                                    @idProducto, NOW(), 'INGRESO', @detalle,
                                    @ingreso, 0, @saldo
                                );";
                            using (var cmdKardex = new MySqlCommand(sqlInsertKardex, cn, transaction))
                            {
                                cmdKardex.Parameters.AddWithValue("@idProducto", idProducto);
                                cmdKardex.Parameters.AddWithValue("@detalle", $"COMPRA DE PRODUCTOS NRO. FACTURA: {numeroFactura}");
                                cmdKardex.Parameters.AddWithValue("@ingreso", det.Cantidad);
                                cmdKardex.Parameters.AddWithValue("@saldo", stockActual);
                                cmdKardex.ExecuteNonQuery();
                            }

                            // Insertar Detalle de Factura de Compra
                            string sqlInsertDetalle = @"
                                INSERT INTO facturas_compra_detalle (
                                    idFacturaCompra, idProducto, cantidad, costoUnitario, total
                                ) VALUES (
                                    @idFacturaCompra, @idProducto, @cantidad, @costoUnitario, @total
                                );";
                            using (var cmdInsertDet = new MySqlCommand(sqlInsertDetalle, cn, transaction))
                            {
                                cmdInsertDet.Parameters.AddWithValue("@idFacturaCompra", idFacturaCompra);
                                cmdInsertDet.Parameters.AddWithValue("@idProducto", idProducto);
                                cmdInsertDet.Parameters.AddWithValue("@cantidad", det.Cantidad);
                                cmdInsertDet.Parameters.AddWithValue("@costoUnitario", det.PrecioUnitario);
                                cmdInsertDet.Parameters.AddWithValue("@total", det.PrecioTotalSinImpuesto);
                                cmdInsertDet.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al procesar el ingreso XML: " + ex.Message, ex);
                    }
                }
            }
        }
    }
}
