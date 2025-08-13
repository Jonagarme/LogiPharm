using MySqlConnector;
using System;
using System.Data;
using LogiPharm.Entidades;
using System.Collections.Generic; // Importamos la clase EProducto que creamos antes

namespace LogiPharm.Datos
{
    public class DProductos
    {
        // --- MÉTODO PARA LISTAR PRODUCTOS ---
        public DataTable ListarProductos()
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                        SELECT 
                            codigoPrincipal AS 'Código', 
                            nombre AS 'Nombre', 
                            stock AS 'Stock', 
                            precioVenta AS 'PVP',
                            stockMinimo AS 'StockMinimo',
                            activo as 'Activo',
                            id AS 'ID' 
                        FROM productos 
                        WHERE anulado = 0 
                        ORDER BY nombre ASC;";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, cn);
                    da.Fill(tabla);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar productos: " + ex.Message);
                }
            }
            return tabla;
        }

        public DataTable BuscarProductosParaKardex(string criterio)
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                        SELECT 
                            codigoPrincipal AS 'Código', 
                            nombre AS 'Nombre', 
                            stock AS 'Stock', 
                            precioVenta AS 'PVP',
                            id AS 'ID'
                        FROM productos
                        WHERE anulado = 0 AND activo = 1
                          AND (codigoPrincipal LIKE @criterio OR nombre LIKE @criterio)
                        ORDER BY nombre ASC;";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@criterio", $"%{criterio}%");

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar productos: " + ex.Message);
                }
            }
            return tabla;
        }

        public EProducto BuscarProducto(string texto)
        {
            EProducto producto = null;
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                string query = @"
            SELECT id, codigoPrincipal, nombre, precioVenta, stock, activo as 'Activo'
            FROM productos
            WHERE (codigoPrincipal = @texto OR codigoAuxiliar = @texto OR nombre LIKE CONCAT('%', @texto, '%'))
              AND anulado = 0 AND activo = 1
            LIMIT 1;";

                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@texto", texto);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        producto = new EProducto
                        {
                            Id = Convert.ToInt64(reader["id"]),
                            CodigoPrincipal = reader["codigoPrincipal"].ToString(),
                            Nombre = reader["nombre"].ToString(),
                            PrecioVenta = Convert.ToDecimal(reader["precioVenta"]),
                            Stock = Convert.ToDecimal(reader["stock"]),
                            Activo = Convert.ToBoolean(reader["activo"]),
                        };
                    }
                }
            }
            return producto;
        }

        public EProducto ObtenerPorId(long id)
        {
            EProducto prod = null;
            using (var conn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                conn.Open();
                string sql = "SELECT * FROM productos WHERE id = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            prod = new EProducto
                            {
                                Id = dr.GetInt64("id"),
                                Nombre = dr["nombre"].ToString(),
                                CodigoPrincipal = dr["codigoPrincipal"].ToString(),
                                CodigoAuxiliar = dr["codigoAuxiliar"] == DBNull.Value ? null : dr["codigoAuxiliar"].ToString(),
                                Descripcion = dr["descripcion"] == DBNull.Value ? null : dr["descripcion"].ToString(),
                                Observaciones = dr["observaciones"] == DBNull.Value ? null : dr["observaciones"].ToString(),
                                RegistroSanitario = dr["registroSanitario"] == DBNull.Value ? null : dr["registroSanitario"].ToString(),
                                IdTipoProducto = Convert.ToInt32(dr["idTipoProducto"]),
                                IdClaseProducto = Convert.ToInt32(dr["idClaseProducto"]),
                                IdCategoria = Convert.ToInt32(dr["idCategoria"]),
                                IdSubcategoria = Convert.ToInt32(dr["idSubcategoria"]),
                                IdSubnivel = dr["idSubnivel"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["idSubnivel"]),
                                IdMarca = Convert.ToInt32(dr["idMarca"]),
                                IdLaboratorio = dr["idLaboratorio"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["idLaboratorio"]),
                                Stock = Convert.ToDecimal(dr["stock"]),
                                StockMinimo = Convert.ToDecimal(dr["stockMinimo"]),
                                StockMaximo = Convert.ToDecimal(dr["stockMaximo"]),
                                PrecioVenta = Convert.ToDecimal(dr["precioVenta"]),
                                EsDivisible = Convert.ToBoolean(dr["esDivisible"]),
                                EsPsicotropico = Convert.ToBoolean(dr["esPsicotropico"]),
                                RequiereCadenaFrio = Convert.ToBoolean(dr["requiereCadenaFrio"]),
                                RequiereSeguimiento = Convert.ToBoolean(dr["requiereSeguimiento"]),
                                CalculoABCManual = Convert.ToBoolean(dr["calculoABCManual"]),
                                ClasificacionABC = dr["clasificacionABC"] == DBNull.Value ? null : dr["clasificacionABC"].ToString(),
                                Activo = Convert.ToBoolean(dr["activo"])
                                // Si quieres mapear otros campos, agrégalos aquí
                            };
                        }
                    }
                }
            }
            return prod;
        }

        public List<EProducto> BuscarProductosActivos(string criterio)
        {
            List<EProducto> lista = new List<EProducto>();
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    // Buscamos coincidencias en el código principal o en el nombre
                    string query = @"
                        SELECT id, codigoPrincipal, nombre, stock, precioVenta, activo as 'Activo' 
                        FROM productos 
                        WHERE (codigoPrincipal LIKE @criterio OR nombre LIKE @criterio) 
                          AND anulado = 0 AND activo = 1 
                        ORDER BY nombre ASC;";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@criterio", "%" + criterio + "%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new EProducto
                            {
                                Id = Convert.ToInt64(reader["id"]),
                                CodigoPrincipal = reader["codigoPrincipal"].ToString(),
                                Nombre = reader["nombre"].ToString(),
                                Stock = Convert.ToDecimal(reader["stock"]),
                                PrecioVenta = Convert.ToDecimal(reader["precioVenta"]),
                                Activo = Convert.ToBoolean(reader["activo"]),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar productos: " + ex.Message);
                }
            }
            return lista;
        }



        public EProducto BuscarProductoPorCodigoONombre(string texto)
        {
            EProducto producto = null;

            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    // Busca por código principal, auxiliar o nombre (LIKE para coincidencias parciales en nombre)
                    string query = @"SELECT * FROM productos 
                             WHERE (codigoPrincipal = @texto OR codigoAuxiliar = @texto OR nombre LIKE CONCAT('%', @texto, '%')) 
                             AND anulado = 0 AND activo = 1 LIMIT 1;";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@texto", texto);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            producto = new EProducto
                            {
                                Id = Convert.ToInt64(reader["id"]),
                                CodigoPrincipal = reader["codigoPrincipal"].ToString(),
                                Nombre = reader["nombre"].ToString(),
                                Stock = Convert.ToDecimal(reader["stock"]),
                                PrecioVenta = Convert.ToDecimal(reader["precioVenta"]),
                                Activo = Convert.ToBoolean(reader["activo"]),
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar el producto: " + ex.Message);
                }
            }
            return producto;
        }


        // --- MÉTODO PARA INSERTAR UN NUEVO PRODUCTO ---
        public bool InsertarProducto(EProducto producto)
        {
            int filasAfectadas = 0;
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                        INSERT INTO productos (
                            nombre, codigoPrincipal, codigoAuxiliar, descripcion, observaciones, registroSanitario,
                            idTipoProducto, idClaseProducto, idCategoria, idSubcategoria, idSubnivel, idMarca, idLaboratorio,
                            stock, stockMinimo, stockMaximo, precioVenta, esDivisible, esPsicotropico, requiereCadenaFrio,
                            requiereSeguimiento, calculoABCManual, clasificacionABC, activo, creadoPor, creadoDate
                        ) VALUES (
                            @nombre, @codigoPrincipal, @codigoAuxiliar, @descripcion, @observaciones, @registroSanitario,
                            @idTipoProducto, @idClaseProducto, @idCategoria, @idSubcategoria, @idSubnivel, @idMarca, @idLaboratorio,
                            @stock, @stockMinimo, @stockMaximo, @precioVenta, @esDivisible, @esPsicotropico, @requiereCadenaFrio,
                            @requiereSeguimiento, @calculoABCManual, @clasificacionABC, @activo, @creadoPor, @creadoDate
                        );";

                    MySqlCommand cmd = new MySqlCommand(query, cn);

                    // Asignar valores a los parámetros desde el objeto 'producto'
                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@codigoPrincipal", producto.CodigoPrincipal);
                    cmd.Parameters.AddWithValue("@codigoAuxiliar", (object)producto.CodigoAuxiliar ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@descripcion", (object)producto.Descripcion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@observaciones", (object)producto.Observaciones ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@registroSanitario", (object)producto.RegistroSanitario ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@idTipoProducto", producto.IdTipoProducto);
                    cmd.Parameters.AddWithValue("@idClaseProducto", producto.IdClaseProducto);
                    cmd.Parameters.AddWithValue("@idCategoria", producto.IdCategoria);
                    cmd.Parameters.AddWithValue("@idSubcategoria", producto.IdSubcategoria);
                    cmd.Parameters.AddWithValue("@idSubnivel", (object)producto.IdSubnivel ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@idMarca", producto.IdMarca);
                    cmd.Parameters.AddWithValue("@idLaboratorio", (object)producto.IdLaboratorio ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@stockMinimo", producto.StockMinimo);
                    cmd.Parameters.AddWithValue("@stockMaximo", producto.StockMaximo);
                    cmd.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);
                    cmd.Parameters.AddWithValue("@esDivisible", producto.EsDivisible);
                    cmd.Parameters.AddWithValue("@esPsicotropico", producto.EsPsicotropico);
                    cmd.Parameters.AddWithValue("@requiereCadenaFrio", producto.RequiereCadenaFrio);
                    cmd.Parameters.AddWithValue("@requiereSeguimiento", producto.RequiereSeguimiento);
                    cmd.Parameters.AddWithValue("@calculoABCManual", producto.CalculoABCManual);
                    cmd.Parameters.AddWithValue("@clasificacionABC", (object)producto.ClasificacionABC ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@activo", producto.Activo);

                    // Campos de auditoría
                    cmd.Parameters.AddWithValue("@creadoPor", producto.CreadoPor);
                    cmd.Parameters.AddWithValue("@creadoDate", DateTime.Now);

                    filasAfectadas = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar producto: " + ex.Message);
                }
            }
            return filasAfectadas > 0;
        }

        public DataTable BuscarProductos(string criterio)
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                SELECT 
                    codigoPrincipal AS 'Código', 
                    nombre AS 'Nombre', 
                    stock AS 'Stock', 
                    precioVenta AS 'PVP',
                    id AS 'ID',
                    activo as 'Activo'
                FROM productos
                WHERE anulado = 0
                  AND (codigoPrincipal LIKE @criterio OR nombre LIKE @criterio)
                ORDER BY nombre ASC;";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@criterio", $"%{criterio}%");

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar productos: " + ex.Message);
                }
            }
            return tabla;
        }



        // --- MÉTODO PARA ACTUALIZAR UN PRODUCTO EXISTENTE ---
        public bool ActualizarProducto(EProducto producto)
        {
            int filasAfectadas = 0;
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                        UPDATE productos SET
                            nombre = @nombre,
                            codigoPrincipal = @codigoPrincipal,
                            codigoAuxiliar = @codigoAuxiliar,
                            descripcion = @descripcion,
                            observaciones = @observaciones,
                            registroSanitario = @registroSanitario,
                            idTipoProducto = @idTipoProducto,
                            idClaseProducto = @idClaseProducto,
                            idCategoria = @idCategoria,
                            idSubcategoria = @idSubcategoria,
                            idSubnivel = @idSubnivel,
                            idMarca = @idMarca,
                            idLaboratorio = @idLaboratorio,
                            stock = @stock,
                            stockMinimo = @stockMinimo,
                            stockMaximo = @stockMaximo,
                            precioVenta = @precioVenta,
                            esDivisible = @esDivisible,
                            esPsicotropico = @esPsicotropico,
                            requiereCadenaFrio = @requiereCadenaFrio,
                            requiereSeguimiento = @requiereSeguimiento,
                            calculoABCManual = @calculoABCManual,
                            clasificacionABC = @clasificacionABC,
                            activo = @activo,
                            editadoPor = @editadoPor,
                            editadoDate = @editadoDate
                        WHERE id = @id;";

                    MySqlCommand cmd = new MySqlCommand(query, cn);

                    // Asignar valores a los parámetros
                    cmd.Parameters.AddWithValue("@id", producto.Id);
                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@codigoPrincipal", producto.CodigoPrincipal);
                    cmd.Parameters.AddWithValue("@codigoAuxiliar", (object)producto.CodigoAuxiliar ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@descripcion", (object)producto.Descripcion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@observaciones", (object)producto.Observaciones ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@registroSanitario", (object)producto.RegistroSanitario ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@idTipoProducto", producto.IdTipoProducto);
                    cmd.Parameters.AddWithValue("@idClaseProducto", producto.IdClaseProducto);
                    cmd.Parameters.AddWithValue("@idCategoria", producto.IdCategoria);
                    cmd.Parameters.AddWithValue("@idSubcategoria", producto.IdSubcategoria);
                    cmd.Parameters.AddWithValue("@idSubnivel", (object)producto.IdSubnivel ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@idMarca", producto.IdMarca);
                    cmd.Parameters.AddWithValue("@idLaboratorio", (object)producto.IdLaboratorio ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@stockMinimo", producto.StockMinimo);
                    cmd.Parameters.AddWithValue("@stockMaximo", producto.StockMaximo);
                    cmd.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);
                    cmd.Parameters.AddWithValue("@esDivisible", producto.EsDivisible);
                    cmd.Parameters.AddWithValue("@esPsicotropico", producto.EsPsicotropico);
                    cmd.Parameters.AddWithValue("@requiereCadenaFrio", producto.RequiereCadenaFrio);
                    cmd.Parameters.AddWithValue("@requiereSeguimiento", producto.RequiereSeguimiento);
                    cmd.Parameters.AddWithValue("@calculoABCManual", producto.CalculoABCManual);
                    cmd.Parameters.AddWithValue("@clasificacionABC", (object)producto.ClasificacionABC ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@activo", producto.Activo);

                    // Campos de auditoría
                    cmd.Parameters.AddWithValue("@editadoPor", producto.EditadoPor);
                    cmd.Parameters.AddWithValue("@editadoDate", DateTime.Now);

                    filasAfectadas = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar producto: " + ex.Message);
                }
            }
            return filasAfectadas > 0;
        }
    }
}
