using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using LogiPharm.Entidades;

namespace LogiPharm.Datos
{
    public class DOrdenesCompra
    {
        /// <summary>
        /// Sincroniza un proveedor de la tabla proveedores a proveedores_proveedor
        /// </summary>
        private void SincronizarProveedor(int idProveedor, MySqlConnection cn, MySqlTransaction transaction)
        {
            // Verificar si ya existe en proveedores_proveedor
            string queryExiste = "SELECT COUNT(*) FROM proveedores_proveedor WHERE id = @id";
            MySqlCommand cmdExiste = new MySqlCommand(queryExiste, cn, transaction);
            cmdExiste.Parameters.AddWithValue("@id", idProveedor);
            int existe = Convert.ToInt32(cmdExiste.ExecuteScalar());

            if (existe == 0)
            {
                // Obtener datos del proveedor de la tabla proveedores
                string queryProveedor = "SELECT * FROM proveedores WHERE id = @id";
                MySqlCommand cmdProveedor = new MySqlCommand(queryProveedor, cn, transaction);
                cmdProveedor.Parameters.AddWithValue("@id", idProveedor);
                
                using (MySqlDataReader reader = cmdProveedor.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string ruc = reader["ruc"]?.ToString() ?? "";
                        string razonSocial = reader["razonSocial"]?.ToString() ?? "";
                        string nombreComercial = reader["nombreComercial"]?.ToString() ?? razonSocial;
                        string direccion = reader["direccion"]?.ToString() ?? "";
                        string telefono = reader["telefono"]?.ToString() ?? "";
                        string email = reader["email"]?.ToString() ?? "";
                        
                        reader.Close();

                        // Insertar en proveedores_proveedor con la estructura correcta
                        string insertProveedor = @"
                            INSERT INTO proveedores_proveedor 
                            (id, codigo, tipo_documento, numero_documento, nombre_comercial, 
                             razon_social, contacto_principal, telefono, email, direccion, 
                             limite_credito, dias_credito, activo, fecha_creacion)
                            VALUES 
                            (@id, @codigo, 'RUC', @numeroDocumento, @nombreComercial, 
                             @razonSocial, @contacto, @telefono, @email, @direccion, 
                             0, 0, 1, NOW())";
                        
                        MySqlCommand cmdInsert = new MySqlCommand(insertProveedor, cn, transaction);
                        cmdInsert.Parameters.AddWithValue("@id", id);
                        cmdInsert.Parameters.AddWithValue("@codigo", ruc.Length > 20 ? ruc.Substring(0, 20) : ruc);
                        cmdInsert.Parameters.AddWithValue("@numeroDocumento", ruc.Length > 50 ? ruc.Substring(0, 50) : ruc);
                        cmdInsert.Parameters.AddWithValue("@nombreComercial", nombreComercial.Length > 200 ? nombreComercial.Substring(0, 200) : nombreComercial);
                        cmdInsert.Parameters.AddWithValue("@razonSocial", razonSocial.Length > 200 ? razonSocial.Substring(0, 200) : razonSocial);
                        cmdInsert.Parameters.AddWithValue("@contacto", nombreComercial.Length > 100 ? nombreComercial.Substring(0, 100) : nombreComercial);
                        cmdInsert.Parameters.AddWithValue("@telefono", telefono.Length > 15 ? telefono.Substring(0, 15) : telefono);
                        cmdInsert.Parameters.AddWithValue("@email", email.Length > 254 ? email.Substring(0, 254) : email);
                        cmdInsert.Parameters.AddWithValue("@direccion", direccion);
                        cmdInsert.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Sincroniza un producto de la tabla productos a productos_producto
        /// </summary>
        private void SincronizarProducto(int idProducto, MySqlConnection cn, MySqlTransaction transaction)
        {
            // Verificar si ya existe en productos_producto
            string queryExiste = "SELECT COUNT(*) FROM productos_producto WHERE id = @id";
            MySqlCommand cmdExiste = new MySqlCommand(queryExiste, cn, transaction);
            cmdExiste.Parameters.AddWithValue("@id", idProducto);
            int existe = Convert.ToInt32(cmdExiste.ExecuteScalar());

            if (existe == 0)
            {
                // Obtener datos del producto de la tabla productos
                string queryProducto = "SELECT * FROM productos WHERE id = @id";
                MySqlCommand cmdProducto = new MySqlCommand(queryProducto, cn, transaction);
                cmdProducto.Parameters.AddWithValue("@id", idProducto);
                
                using (MySqlDataReader reader = cmdProducto.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string codigo = reader["codigoPrincipal"]?.ToString() ?? "";
                        string nombre = reader["nombre"]?.ToString() ?? "";
                        string descripcion = reader["descripcion"]?.ToString() ?? "";
                        decimal costoUnidad = reader["costoUnidad"] != DBNull.Value ? Convert.ToDecimal(reader["costoUnidad"]) : 0;
                        decimal precioVenta = reader["precioVenta"] != DBNull.Value ? Convert.ToDecimal(reader["precioVenta"]) : 0;
                        decimal stock = reader["stock"] != DBNull.Value ? Convert.ToDecimal(reader["stock"]) : 0;
                        decimal stockMinimo = reader["stockMinimo"] != DBNull.Value ? Convert.ToDecimal(reader["stockMinimo"]) : 0;
                        decimal stockMaximo = reader["stockMaximo"] != DBNull.Value ? Convert.ToDecimal(reader["stockMaximo"]) : 0;
                        int idCategoria = reader["idCategoria"] != DBNull.Value ? Convert.ToInt32(reader["idCategoria"]) : 1;
                        int idMarca = reader["idMarca"] != DBNull.Value ? Convert.ToInt32(reader["idMarca"]) : 1;
                        
                        reader.Close();

                        // Obtener o crear IDs por defecto para las tablas relacionadas si no existen
                        int categoriaId = ObtenerOCrearCategoriaDefault(cn, transaction, idCategoria);
                        int marcaId = ObtenerOCrearMarcaDefault(cn, transaction, idMarca);
                        int unidadMedidaId = ObtenerOCrearUnidadMedidaDefault(cn, transaction);

                        // Insertar en productos_producto con todos los campos requeridos
                        string insertProducto = @"
                            INSERT INTO productos_producto 
                            (id, codigo, nombre, descripcion, tipo_producto, precio_compra, precio_venta, 
                             stock_minimo, stock_maximo, stock_actual, aplica_iva, activo, 
                             fecha_creacion, fecha_modificacion, categoria_id, marca_id, unidad_medida_id)
                            VALUES 
                            (@id, @codigo, @nombre, @descripcion, 'MEDICAMENTO', @precioCompra, @precioVenta, 
                             @stockMinimo, @stockMaximo, @stockActual, 1, 1, 
                             NOW(), NOW(), @categoriaId, @marcaId, @unidadMedidaId)";
                        
                        MySqlCommand cmdInsert = new MySqlCommand(insertProducto, cn, transaction);
                        cmdInsert.Parameters.AddWithValue("@id", id);
                        cmdInsert.Parameters.AddWithValue("@codigo", codigo.Length > 50 ? codigo.Substring(0, 50) : codigo);
                        cmdInsert.Parameters.AddWithValue("@nombre", nombre.Length > 200 ? nombre.Substring(0, 200) : nombre);
                        cmdInsert.Parameters.AddWithValue("@descripcion", descripcion ?? "");
                        cmdInsert.Parameters.AddWithValue("@precioCompra", costoUnidad);
                        cmdInsert.Parameters.AddWithValue("@precioVenta", precioVenta);
                        cmdInsert.Parameters.AddWithValue("@stockMinimo", (int)stockMinimo);
                        cmdInsert.Parameters.AddWithValue("@stockMaximo", (int)stockMaximo);
                        cmdInsert.Parameters.AddWithValue("@stockActual", (int)stock);
                        cmdInsert.Parameters.AddWithValue("@categoriaId", categoriaId);
                        cmdInsert.Parameters.AddWithValue("@marcaId", marcaId);
                        cmdInsert.Parameters.AddWithValue("@unidadMedidaId", unidadMedidaId);
                        cmdInsert.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Obtiene o crea una categoría por defecto en productos_categoria
        /// </summary>
        private int ObtenerOCrearCategoriaDefault(MySqlConnection cn, MySqlTransaction transaction, int idCategoriaOriginal)
        {
            // Verificar si existe la categoría con el ID original
            string queryExiste = "SELECT COUNT(*) FROM productos_categoria WHERE id = @id";
            MySqlCommand cmdExiste = new MySqlCommand(queryExiste, cn, transaction);
            cmdExiste.Parameters.AddWithValue("@id", idCategoriaOriginal);
            int existe = Convert.ToInt32(cmdExiste.ExecuteScalar());

            if (existe > 0)
            {
                return idCategoriaOriginal;
            }

            // Buscar si existe una categoría "General" o "Sin categoría"
            string queryGeneral = "SELECT id FROM productos_categoria WHERE nombre IN ('General', 'Sin categoría', 'GENERAL') LIMIT 1";
            MySqlCommand cmdGeneral = new MySqlCommand(queryGeneral, cn, transaction);
            object resultado = cmdGeneral.ExecuteScalar();
            
            if (resultado != null)
            {
                return Convert.ToInt32(resultado);
            }

            // Crear categoría por defecto
            string insertCategoria = @"
                INSERT INTO productos_categoria (nombre, descripcion, activo, fecha_creacion) 
                VALUES ('General', 'Categoría general para productos sincronizados', 1, NOW());
                SELECT LAST_INSERT_ID();";
            MySqlCommand cmdInsert = new MySqlCommand(insertCategoria, cn, transaction);
            return Convert.ToInt32(cmdInsert.ExecuteScalar());
        }

        /// <summary>
        /// Obtiene o crea una marca por defecto en productos_marca
        /// </summary>
        private int ObtenerOCrearMarcaDefault(MySqlConnection cn, MySqlTransaction transaction, int idMarcaOriginal)
        {
            // Verificar si existe la marca con el ID original
            string queryExiste = "SELECT COUNT(*) FROM productos_marca WHERE id = @id";
            MySqlCommand cmdExiste = new MySqlCommand(queryExiste, cn, transaction);
            cmdExiste.Parameters.AddWithValue("@id", idMarcaOriginal);
            int existe = Convert.ToInt32(cmdExiste.ExecuteScalar());

            if (existe > 0)
            {
                return idMarcaOriginal;
            }

            // Buscar si existe una marca "General" o "Sin marca"
            string queryGeneral = "SELECT id FROM productos_marca WHERE nombre IN ('General', 'Sin marca', 'GENERAL') LIMIT 1";
            MySqlCommand cmdGeneral = new MySqlCommand(queryGeneral, cn, transaction);
            object resultado = cmdGeneral.ExecuteScalar();
            
            if (resultado != null)
            {
                return Convert.ToInt32(resultado);
            }

            // Crear marca por defecto
            string insertMarca = @"
                INSERT INTO productos_marca (nombre, descripcion, activo, fecha_creacion) 
                VALUES ('General', 'Marca general para productos sincronizados', 1, NOW());
                SELECT LAST_INSERT_ID();";
            MySqlCommand cmdInsert = new MySqlCommand(insertMarca, cn, transaction);
            return Convert.ToInt32(cmdInsert.ExecuteScalar());
        }

        /// <summary>
        /// Obtiene o crea una unidad de medida por defecto en productos_unidadmedida
        /// </summary>
        private int ObtenerOCrearUnidadMedidaDefault(MySqlConnection cn, MySqlTransaction transaction)
        {
            // Buscar si existe una unidad "Unidad" o "UND"
            string queryExiste = "SELECT id FROM productos_unidadmedida WHERE nombre IN ('Unidad', 'UND', 'UNIDAD') OR abreviacion IN ('UND', 'U') LIMIT 1";
            MySqlCommand cmdExiste = new MySqlCommand(queryExiste, cn, transaction);
            object resultado = cmdExiste.ExecuteScalar();
            
            if (resultado != null)
            {
                return Convert.ToInt32(resultado);
            }

            // Crear unidad de medida por defecto
            string insertUnidad = @"
                INSERT INTO productos_unidadmedida (nombre, abreviacion, activo) 
                VALUES ('Unidad', 'UND', 1);
                SELECT LAST_INSERT_ID();";
            MySqlCommand cmdInsert = new MySqlCommand(insertUnidad, cn, transaction);
            return Convert.ToInt32(cmdInsert.ExecuteScalar());
        }

        /// <summary>
        /// Lista todas las órdenes de compra con paginación
        /// </summary>
        public DataTable ListarOrdenesPaginado(int offset, int limit)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string query = @"
                    SELECT 
                        oc.id AS Id,
                        oc.numero_orden AS Numero,
                        oc.fecha_creacion AS FechaEmision,
                        oc.fecha_entrega_esperada AS FechaEntrega,
                        p.razon_social AS Proveedor,
                        oc.total AS Total,
                        oc.estado AS Estado
                    FROM inventario_ordencompra oc
                    LEFT JOIN proveedores_proveedor p ON oc.proveedor_id = p.id
                    WHERE oc.anulado = 0
                    ORDER BY oc.fecha_creacion DESC, oc.numero_orden DESC
                    LIMIT @limit OFFSET @offset";

                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@limit", limit);
                cmd.Parameters.AddWithValue("@offset", offset);

                cn.Open();
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        /// <summary>
        /// Busca órdenes de compra por criterio
        /// </summary>
        public DataTable BuscarOrdenesPaginado(string criterio, int offset, int limit)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string query = @"
                    SELECT 
                        oc.id AS Id,
                        oc.numero_orden AS Numero,
                        oc.fecha_creacion AS FechaEmision,
                        oc.fecha_entrega_esperada AS FechaEntrega,
                        p.razon_social AS Proveedor,
                        oc.total AS Total,
                        oc.estado AS Estado
                    FROM inventario_ordencompra oc
                    LEFT JOIN proveedores_proveedor p ON oc.proveedor_id = p.id
                    WHERE oc.anulado = 0
                    AND (
                        oc.numero_orden LIKE @criterio
                        OR p.razon_social LIKE @criterio
                        OR oc.estado LIKE @criterio
                    )
                    ORDER BY oc.fecha_creacion DESC, oc.numero_orden DESC
                    LIMIT @limit OFFSET @offset";

                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@criterio", $"%{criterio}%");
                cmd.Parameters.AddWithValue("@limit", limit);
                cmd.Parameters.AddWithValue("@offset", offset);

                cn.Open();
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        /// <summary>
        /// Cuenta el total de órdenes de compra
        /// </summary>
        public int ContarOrdenes()
        {
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string query = "SELECT COUNT(*) FROM inventario_ordencompra WHERE anulado = 0";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        /// <summary>
        /// Cuenta órdenes según criterio de búsqueda
        /// </summary>
        public int ContarOrdenesBusqueda(string criterio)
        {
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string query = @"
                    SELECT COUNT(*) 
                    FROM inventario_ordencompra oc
                    LEFT JOIN proveedores_proveedor p ON oc.proveedor_id = p.id
                    WHERE oc.anulado = 0
                    AND (
                        oc.numero_orden LIKE @criterio
                        OR p.razon_social LIKE @criterio
                        OR oc.estado LIKE @criterio
                    )";

                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@criterio", $"%{criterio}%");
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        /// <summary>
        /// Obtiene una orden de compra completa con su detalle
        /// </summary>
        public EOrdenCompra ObtenerOrdenCompleta(long idOrden)
        {
            EOrdenCompra orden = null;

            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();

                // Obtener encabezado
                string queryOrden = @"
                    SELECT 
                        oc.*,
                        p.razon_social AS RazonSocialProveedor,
                        p.numero_documento AS RucProveedor,
                        p.direccion AS DireccionProveedor,
                        p.telefono AS TelefonoProveedor,
                        p.email AS EmailProveedor
                    FROM inventario_ordencompra oc
                    LEFT JOIN proveedores_proveedor p ON oc.proveedor_id = p.id
                    WHERE oc.id = @idOrden";

                MySqlCommand cmdOrden = new MySqlCommand(queryOrden, cn);
                cmdOrden.Parameters.AddWithValue("@idOrden", idOrden);

                using (MySqlDataReader reader = cmdOrden.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        orden = new EOrdenCompra
                        {
                            Id = Convert.ToInt64(reader["id"]),
                            Numero = Convert.ToInt32(reader["numero_orden"]),
                            FechaEmision = Convert.ToDateTime(reader["fecha_creacion"]),
                            FechaEntregaEsperada = reader["fecha_entrega_esperada"] != DBNull.Value
                                ? Convert.ToDateTime(reader["fecha_entrega_esperada"])
                                : (DateTime?)null,
                            IdProveedor = Convert.ToInt32(reader["proveedor_id"]),
                            RazonSocialProveedor = reader["RazonSocialProveedor"].ToString(),
                            RucProveedor = reader["RucProveedor"].ToString(),
                            DireccionProveedor = reader["DireccionProveedor"].ToString(),
                            TelefonoProveedor = reader["TelefonoProveedor"].ToString(),
                            EmailProveedor = reader["EmailProveedor"].ToString(),
                            Observaciones = reader["observaciones"].ToString(),
                            Subtotal = Convert.ToDecimal(reader["subtotal"]),
                            Descuento = Convert.ToDecimal(reader["descuento"]),
                            IVA = Convert.ToDecimal(reader["impuesto"]),
                            Total = Convert.ToDecimal(reader["total"]),
                            Estado = reader["estado"].ToString(),
                            CreadoPor = Convert.ToInt32(reader["creadoPor_id"]),
                            CreadoDate = Convert.ToDateTime(reader["creadoDate"]),
                            AprobadoPor = null,
                            AprobadoDate = null,
                            Anulado = Convert.ToBoolean(reader["anulado"]),
                            AnuladoPor = reader["editadoPor_id"] != DBNull.Value ? (int?)Convert.ToInt32(reader["editadoPor_id"]) : null,
                            AnuladoDate = reader["editadoDate"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["editadoDate"]) : null
                        };
                    }
                }

                // Obtener detalle
                if (orden != null)
                {
                    string queryDetalle = @"
                        SELECT 
                            ocd.*,
                            p.codigoPrincipal AS Codigo,
                            p.nombre AS ProductoNombre
                        FROM inventario_detalleordencompra ocd
                        INNER JOIN productos p ON ocd.producto_id = p.id
                        WHERE ocd.orden_id = @idOrden";

                    MySqlCommand cmdDetalle = new MySqlCommand(queryDetalle, cn);
                    cmdDetalle.Parameters.AddWithValue("@idOrden", idOrden);

                    using (MySqlDataReader reader = cmdDetalle.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orden.Detalles.Add(new EOrdenCompraDetalle
                            {
                                Id = Convert.ToInt64(reader["id"]),
                                IdOrdenCompra = Convert.ToInt64(reader["orden_id"]),
                                IdProducto = Convert.ToInt32(reader["producto_id"]),
                                Codigo = reader["Codigo"].ToString(),
                                ProductoNombre = reader["ProductoNombre"].ToString(),
                                CantidadSolicitada = Convert.ToDecimal(reader["cantidad_solicitada"]),
                                CantidadRecibida = Convert.ToDecimal(reader["cantidad_recibida"]),
                                PrecioUnitario = Convert.ToDecimal(reader["precio_unitario"]),
                                DescuentoPorc = Convert.ToDecimal(reader["descuento_linea"]),
                                DescuentoValor = 0,
                                IVAValor = 0,
                                Subtotal = 0,
                                Total = 0
                            });
                        }
                    }
                }
            }

            return orden;
        }

        /// <summary>
        /// Guarda una nueva orden de compra
        /// </summary>
        public long GuardarOrdenCompra(EOrdenCompra orden)
        {
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                MySqlTransaction transaction = cn.BeginTransaction();

                try
                {
                    // Obtener el ID de un usuario válido de usuarios
                    int idUsuarioAuth = 1;
                    string queryUsuario = "SELECT id FROM usuarios LIMIT 1";
                    MySqlCommand cmdUsuario = new MySqlCommand(queryUsuario, cn, transaction);
                    object resultado = cmdUsuario.ExecuteScalar();
                    if (resultado != null)
                    {
                        idUsuarioAuth = Convert.ToInt32(resultado);
                    }

                    // Sincronizar el proveedor de proveedores a proveedores_proveedor
                    SincronizarProveedor(orden.IdProveedor, cn, transaction);

                    // Obtener el siguiente número de orden
                    string queryNumero = "SELECT IFNULL(MAX(numero_orden), 0) + 1 FROM inventario_ordencompra";
                    MySqlCommand cmdNumero = new MySqlCommand(queryNumero, cn, transaction);
                    int numeroOrden = Convert.ToInt32(cmdNumero.ExecuteScalar());

                    // Insertar encabezado
                    string insertOrden = @"
                        INSERT INTO inventario_ordencompra 
                        (numero_orden, fecha_creacion, fecha_envio, fecha_entrega_esperada, 
                         prioridad, subtotal, descuento, impuesto, total, estado, 
                         observaciones, generada_automaticamente, creadoDate, creadoPor_id, 
                         proveedor_id, usuario_creacion_id, usuario_envio_id, anulado,
                         editadoDate, editadoPor_id)
                        VALUES 
                        (@numero, NOW(), NULL, @fechaEntregaEsperada, 
                         'MEDIA', @subtotal, @descuento, @impuesto, @total, @estado, 
                         @observaciones, 0, NOW(), @creadoPor, 
                         @proveedorId, @creadoPor, NULL, 0,
                         NOW(), @creadoPor);
                        SELECT LAST_INSERT_ID();";

                    MySqlCommand cmdOrden = new MySqlCommand(insertOrden, cn, transaction);
                    cmdOrden.Parameters.AddWithValue("@numero", numeroOrden);
                    cmdOrden.Parameters.AddWithValue("@fechaEntregaEsperada", orden.FechaEntregaEsperada.HasValue ? (object)orden.FechaEntregaEsperada.Value : DBNull.Value);
                    cmdOrden.Parameters.AddWithValue("@proveedorId", orden.IdProveedor);
                    cmdOrden.Parameters.AddWithValue("@observaciones", orden.Observaciones ?? "");
                    cmdOrden.Parameters.AddWithValue("@subtotal", orden.Subtotal);
                    cmdOrden.Parameters.AddWithValue("@descuento", orden.Descuento);
                    cmdOrden.Parameters.AddWithValue("@impuesto", orden.IVA);
                    cmdOrden.Parameters.AddWithValue("@total", orden.Total);
                    cmdOrden.Parameters.AddWithValue("@estado", "PENDIENTE");
                    cmdOrden.Parameters.AddWithValue("@creadoPor", idUsuarioAuth);

                    long idOrden = Convert.ToInt64(cmdOrden.ExecuteScalar());

                    // Insertar detalles
                    foreach (var detalle in orden.Detalles)
                    {
                        // Sincronizar el producto antes de insertarlo
                        SincronizarProducto(detalle.IdProducto, cn, transaction);

                        string insertDetalle = @"
                            INSERT INTO inventario_detalleordencompra 
                            (cantidad_solicitada, cantidad_recibida, precio_unitario, 
                             descuento_linea, stock_actual, stock_minimo, motivo_solicitud, 
                             producto_id, orden_id)
                            VALUES 
                            (@cantidadSolicitada, 0, @precioUnitario, 
                             @descuentoLinea, 0, 0, '', 
                             @productoId, @ordenId)";

                        MySqlCommand cmdDetalle = new MySqlCommand(insertDetalle, cn, transaction);
                        cmdDetalle.Parameters.AddWithValue("@ordenId", idOrden);
                        cmdDetalle.Parameters.AddWithValue("@productoId", detalle.IdProducto);
                        cmdDetalle.Parameters.AddWithValue("@cantidadSolicitada", detalle.CantidadSolicitada);
                        cmdDetalle.Parameters.AddWithValue("@precioUnitario", detalle.PrecioUnitario);
                        cmdDetalle.Parameters.AddWithValue("@descuentoLinea", detalle.DescuentoPorc);
                        cmdDetalle.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return idOrden;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// Actualiza una orden de compra existente
        /// </summary>
        public bool ActualizarOrdenCompra(EOrdenCompra orden)
        {
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                MySqlTransaction transaction = cn.BeginTransaction();

                try
                {
                    // Obtener el ID de un usuario válido de usuarios
                    int idUsuarioAuth = 1;
                    string queryUsuario = "SELECT id FROM usuarios LIMIT 1";
                    MySqlCommand cmdUsuario = new MySqlCommand(queryUsuario, cn, transaction);
                    object resultado = cmdUsuario.ExecuteScalar();
                    if (resultado != null)
                    {
                        idUsuarioAuth = Convert.ToInt32(resultado);
                    }

                    // Actualizar encabezado
                    string updateOrden = @"
                        UPDATE inventario_ordencompra SET
                            fecha_creacion = @fechaEmision,
                            fecha_entrega_esperada = @fechaEntregaEsperada,
                            proveedor_id = @idProveedor,
                            observaciones = @observaciones,
                            subtotal = @subtotal,
                            descuento = @descuento,
                            impuesto = @impuesto,
                            total = @total,
                            editadoDate = NOW(),
                            editadoPor_id = @editadoPor
                        WHERE id = @id";

                    MySqlCommand cmdOrden = new MySqlCommand(updateOrden, cn, transaction);
                    cmdOrden.Parameters.AddWithValue("@id", orden.Id);
                    cmdOrden.Parameters.AddWithValue("@fechaEmision", orden.FechaEmision);
                    cmdOrden.Parameters.AddWithValue("@fechaEntregaEsperada", orden.FechaEntregaEsperada.HasValue ? (object)orden.FechaEntregaEsperada.Value : DBNull.Value);
                    cmdOrden.Parameters.AddWithValue("@idProveedor", orden.IdProveedor);
                    cmdOrden.Parameters.AddWithValue("@observaciones", orden.Observaciones ?? "");
                    cmdOrden.Parameters.AddWithValue("@subtotal", orden.Subtotal);
                    cmdOrden.Parameters.AddWithValue("@descuento", orden.Descuento);
                    cmdOrden.Parameters.AddWithValue("@impuesto", orden.IVA);
                    cmdOrden.Parameters.AddWithValue("@total", orden.Total);
                    cmdOrden.Parameters.AddWithValue("@editadoPor", idUsuarioAuth);
                    cmdOrden.ExecuteNonQuery();

                    // Eliminar detalles existentes
                    string deleteDetalle = "DELETE FROM inventario_detalleordencompra WHERE orden_id = @idOrden";
                    MySqlCommand cmdDelete = new MySqlCommand(deleteDetalle, cn, transaction);
                    cmdDelete.Parameters.AddWithValue("@idOrden", orden.Id);
                    cmdDelete.ExecuteNonQuery();

                    // Insertar nuevos detalles
                    foreach (var detalle in orden.Detalles)
                    {
                        // Sincronizar el producto antes de insertarlo
                        SincronizarProducto(detalle.IdProducto, cn, transaction);

                        string insertDetalle = @"
                            INSERT INTO inventario_detalleordencompra 
                            (cantidad_solicitada, cantidad_recibida, precio_unitario, 
                             descuento_linea, stock_actual, stock_minimo, motivo_solicitud, 
                             producto_id, orden_id)
                            VALUES 
                            (@cantidadSolicitada, @cantidadRecibida, @precioUnitario, 
                             @descuentoLinea, 0, 0, '', 
                             @productoId, @ordenId)";

                        MySqlCommand cmdDetalle = new MySqlCommand(insertDetalle, cn, transaction);
                        cmdDetalle.Parameters.AddWithValue("@ordenId", orden.Id);
                        cmdDetalle.Parameters.AddWithValue("@productoId", detalle.IdProducto);
                        cmdDetalle.Parameters.AddWithValue("@cantidadSolicitada", detalle.CantidadSolicitada);
                        cmdDetalle.Parameters.AddWithValue("@cantidadRecibida", detalle.CantidadRecibida);
                        cmdDetalle.Parameters.AddWithValue("@precioUnitario", detalle.PrecioUnitario);
                        cmdDetalle.Parameters.AddWithValue("@descuentoLinea", detalle.DescuentoPorc);
                        cmdDetalle.ExecuteNonQuery();
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

        /// <summary>
        /// Anula una orden de compra
        /// </summary>
        public bool AnularOrdenCompra(long idOrden, int usuarioId)
        {
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();

                // Obtener el ID de un usuario válido de usuarios
                int idUsuarioAuth = 1;
                string queryUsuario = "SELECT id FROM usuarios LIMIT 1";
                MySqlCommand cmdUsuario = new MySqlCommand(queryUsuario, cn);
                object resultado = cmdUsuario.ExecuteScalar();
                if (resultado != null)
                {
                    idUsuarioAuth = Convert.ToInt32(resultado);
                }

                string query = @"
                    UPDATE inventario_ordencompra SET
                        anulado = 1,
                        editadoPor_id = @usuarioId,
                        editadoDate = NOW(),
                        estado = 'CANCELADA'
                    WHERE id = @idOrden";

                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@idOrden", idOrden);
                cmd.Parameters.AddWithValue("@usuarioId", idUsuarioAuth);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Cambia el estado de una orden de compra
        /// </summary>
        public bool CambiarEstado(long idOrden, string nuevoEstado)
        {
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string query = "UPDATE inventario_ordencompra SET estado = @estado WHERE id = @idOrden";

                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@idOrden", idOrden);
                cmd.Parameters.AddWithValue("@estado", nuevoEstado);

                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Aprueba una orden de compra
        /// </summary>
        public bool AprobarOrdenCompra(long idOrden, int usuarioId)
        {
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();

                // Obtener el ID de un usuario válido de usuarios
                int idUsuarioAuth = 1;
                string queryUsuario = "SELECT id FROM usuarios LIMIT 1";
                MySqlCommand cmdUsuario = new MySqlCommand(queryUsuario, cn);
                object resultado = cmdUsuario.ExecuteScalar();
                if (resultado != null)
                {
                    idUsuarioAuth = Convert.ToInt32(resultado);
                }

                string query = @"
                    UPDATE inventario_ordencompra SET
                        estado = 'APROBADA',
                        editadoPor_id = @usuarioId,
                        editadoDate = NOW()
                    WHERE id = @idOrden";

                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@idOrden", idOrden);
                cmd.Parameters.AddWithValue("@usuarioId", idUsuarioAuth);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
