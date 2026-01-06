using MySqlConnector;
using System;
using System.Data;
using System.Linq;
using LogiPharm.Entidades;
using System.Collections.Generic;

namespace LogiPharm.Datos
{
    public class DProductos
    {
        // ======================
        // Helpers de lectura DB
        // ======================
        private static string GetStringSafe(MySqlDataReader dr, string col)
            => dr[col] == DBNull.Value ? null : dr[col].ToString();

        private static int? GetInt32Nullable(MySqlDataReader dr, string col)
            => dr[col] == DBNull.Value ? (int?)null : Convert.ToInt32(dr[col]);

        private static decimal GetDecimalSafe(MySqlDataReader dr, string col)
            => dr[col] == DBNull.Value ? 0m : Convert.ToDecimal(dr[col]);

        private static bool GetBoolSafe(MySqlDataReader dr, string col)
            => dr[col] == DBNull.Value ? false : Convert.ToBoolean(dr[col]);

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

        // NUEVO: Listado paginado (para carga incremental)
        public DataTable ListarProductosPaginado(int offset, int limit)
        {
            DataTable tabla = new DataTable();
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
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
                        ORDER BY nombre ASC
                        LIMIT @limit OFFSET @offset;";

                    using (var cmd = new MySqlCommand(query, cn))
                    {
                        cmd.Parameters.Add("@limit", MySqlDbType.Int32).Value = limit;
                        cmd.Parameters.Add("@offset", MySqlDbType.Int32).Value = offset;
                        using (var da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(tabla);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar productos (paginado): " + ex.Message);
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
                    SELECT id, codigoPrincipal, nombre, precioVenta, stock, activo as 'activo'
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
                                Nombre = GetStringSafe(dr, "nombre"),
                                CodigoPrincipal = GetStringSafe(dr, "codigoPrincipal"),
                                CodigoAuxiliar = GetStringSafe(dr, "codigoAuxiliar"),
                                Descripcion = GetStringSafe(dr, "descripcion"),
                                Observaciones = GetStringSafe(dr, "observaciones"),
                                RegistroSanitario = GetStringSafe(dr, "registroSanitario"),
                                IdTipoProducto = Convert.ToInt32(dr["idTipoProducto"]),
                                IdClaseProducto = Convert.ToInt32(dr["idClaseProducto"]),
                                IdCategoria = Convert.ToInt32(dr["idCategoria"]),
                                IdSubcategoria = Convert.ToInt32(dr["idSubcategoria"]),
                                IdSubnivel = GetInt32Nullable(dr, "idSubnivel"),
                                IdMarca = Convert.ToInt32(dr["idMarca"]),
                                IdLaboratorio = GetInt32Nullable(dr, "idLaboratorio"),
                                Stock = GetDecimalSafe(dr, "stock"),
                                StockMinimo = GetDecimalSafe(dr, "stockMinimo"),
                                StockMaximo = GetDecimalSafe(dr, "stockMaximo"),
                                // ===== NUEVOS CAMPOS DE PRECIOS/COSTOS =====
                                CostoUnidad = GetDecimalSafe(dr, "costoUnidad"),
                                CostoCaja = GetDecimalSafe(dr, "costoCaja"),
                                PvpUnidad = GetDecimalSafe(dr, "pvpUnidad"),
                                PrecioVenta = GetDecimalSafe(dr, "precioVenta"),
                                // ===========================================
                                EsDivisible = GetBoolSafe(dr, "esDivisible"),
                                EsPsicotropico = GetBoolSafe(dr, "esPsicotropico"),
                                RequiereCadenaFrio = GetBoolSafe(dr, "requiereCadenaFrio"),
                                RequiereSeguimiento = GetBoolSafe(dr, "requiereSeguimiento"),
                                CalculoABCManual = GetBoolSafe(dr, "calculoABCManual"),
                                ClasificacionABC = GetStringSafe(dr, "clasificacionABC"),
                                Activo = GetBoolSafe(dr, "activo")
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
                    string query = @"
                        SELECT id, codigoPrincipal, nombre, stock, precioVenta, activo as 'activo' 
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
                    string query = @"
                        SELECT *
                        FROM productos 
                        WHERE (codigoPrincipal = @texto OR codigoAuxiliar = @texto OR nombre LIKE CONCAT('%', @texto, '%')) 
                          AND anulado = 0 AND activo = 1
                        LIMIT 1;";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@texto", texto);

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            producto = new EProducto
                            {
                                Id = Convert.ToInt64(dr["id"]),
                                CodigoPrincipal = dr["codigoPrincipal"].ToString(),
                                Nombre = dr["nombre"].ToString(),
                                Stock = GetDecimalSafe(dr, "stock"),
                                // ======= devolvemos también costos/precios =======
                                CostoUnidad = GetDecimalSafe(dr, "costoUnidad"),
                                CostoCaja = GetDecimalSafe(dr, "costoCaja"),
                                PvpUnidad = GetDecimalSafe(dr, "pvpUnidad"),
                                PrecioVenta = GetDecimalSafe(dr, "precioVenta"),
                                // =================================================
                                Activo = GetBoolSafe(dr, "activo"),
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

        // --- INSERTAR ---
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
                            stock, stockMinimo, stockMaximo,
                            costoUnidad, costoCaja, pvpUnidad, precioVenta,
                            esDivisible, esPsicotropico, requiereCadenaFrio, requiereSeguimiento, calculoABCManual,
                            clasificacionABC, activo, creadoPor, creadoDate
                        ) VALUES (
                            @nombre, @codigoPrincipal, @codigoAuxiliar, @descripcion, @observaciones, @registroSanitario,
                            @idTipoProducto, @idClaseProducto, @idCategoria, @idSubcategoria, @idSubnivel, @idMarca, @idLaboratorio,
                            @stock, @stockMinimo, @stockMaximo,
                            @costoUnidad, @costoCaja, @pvpUnidad, @precioVenta,
                            @esDivisible, @esPsicotropico, @requiereCadenaFrio, @requiereSeguimiento, @calculoABCManual,
                            @clasificacionABC, @activo, @creadoPor, @creadoDate
                        );";

                    MySqlCommand cmd = new MySqlCommand(query, cn);

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

                    // ===== nuevos =====
                    cmd.Parameters.AddWithValue("@costoUnidad", producto.CostoUnidad);
                    cmd.Parameters.AddWithValue("@costoCaja", producto.CostoCaja);
                    cmd.Parameters.AddWithValue("@pvpUnidad", producto.PvpUnidad);
                    cmd.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);

                    cmd.Parameters.AddWithValue("@esDivisible", producto.EsDivisible);
                    cmd.Parameters.AddWithValue("@esPsicotropico", producto.EsPsicotropico);
                    cmd.Parameters.AddWithValue("@requiereCadenaFrio", producto.RequiereCadenaFrio);
                    cmd.Parameters.AddWithValue("@requiereSeguimiento", producto.RequiereSeguimiento);
                    cmd.Parameters.AddWithValue("@calculoABCManual", producto.CalculoABCManual);
                    cmd.Parameters.AddWithValue("@clasificacionABC", (object)producto.ClasificacionABC ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@activo", producto.Activo);

                    // auditoría
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

        // NUEVO: Búsqueda paginada
        public DataTable BuscarProductosPaginado(string criterio, int offset, int limit)
        {
            DataTable tabla = new DataTable();
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
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
                        ORDER BY nombre ASC
                        LIMIT @limit OFFSET @offset;";

                    using (var cmd = new MySqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@criterio", $"%{criterio}%");
                        cmd.Parameters.Add("@limit", MySqlDbType.Int32).Value = limit;
                        cmd.Parameters.Add("@offset", MySqlDbType.Int32).Value = offset;
                        using (var da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(tabla);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar productos (paginado): " + ex.Message);
                }
            }
            return tabla;
        }

        // --- UPDATE GENERAL ---
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
                            -- ===== nuevos =====
                            costoUnidad = @costoUnidad,
                            costoCaja   = @costoCaja,
                            pvpUnidad   = @pvpUnidad,
                            precioVenta = @precioVenta,
                            -- ===================
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

                    // nuevos
                    cmd.Parameters.AddWithValue("@costoUnidad", producto.CostoUnidad);
                    cmd.Parameters.AddWithValue("@costoCaja", producto.CostoCaja);
                    cmd.Parameters.AddWithValue("@pvpUnidad", producto.PvpUnidad);
                    cmd.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);

                    cmd.Parameters.AddWithValue("@esDivisible", producto.EsDivisible);
                    cmd.Parameters.AddWithValue("@esPsicotropico", producto.EsPsicotropico);
                    cmd.Parameters.AddWithValue("@requiereCadenaFrio", producto.RequiereCadenaFrio);
                    cmd.Parameters.AddWithValue("@requiereSeguimiento", producto.RequiereSeguimiento);
                    cmd.Parameters.AddWithValue("@calculoABCManual", producto.CalculoABCManual);
                    cmd.Parameters.AddWithValue("@clasificacionABC", (object)producto.ClasificacionABC ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@activo", producto.Activo);

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

        // --- UPDATE de CostoCaja + PVP (pantalla PRECIOS)
        public bool ActualizarPrecios(int idProducto, decimal costoCaja, decimal pvp /*, opc: costoUnidad, pvpUnidad*/)
        {
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                string sql = @"
                    UPDATE productos
                    SET costoCaja   = @costoCaja,
                        precioVenta = @pvp
                    WHERE id = @id;";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@costoCaja", costoCaja);
                    cmd.Parameters.AddWithValue("@pvp", pvp);
                    cmd.Parameters.AddWithValue("@id", idProducto);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool ActualizarPreciosAutoPorId(long idProducto, decimal pvp)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                // calcula todo en SQL con ROUND a 4 decimales
                const string sql = @"
            UPDATE productos
            SET
                precioVenta = @pvp,
                pvpUnidad   = @pvp,
                costoUnidad = ROUND(@pvp * 0.7, 4),
                costoCaja   = ROUND(stock * (@pvp * 0.7), 4)
            WHERE id = @id;";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@pvp", pvp);
                    cmd.Parameters.AddWithValue("@id", idProducto);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Variante si quieres usar el código principal en lugar del ID.
        public bool ActualizarPreciosAutoPorCodigo(string codigoPrincipal, decimal pvp)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                const string sql = @"
            UPDATE productos
            SET
                precioVenta = @pvp,
                pvpUnidad   = @pvp,
                costoUnidad = ROUND(@pvp * 0.7, 4),
                costoCaja   = ROUND(stock * (@pvp * 0.7), 4)
            WHERE codigoPrincipal = @codigo;";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@pvp", pvp);
                    cmd.Parameters.AddWithValue("@codigo", codigoPrincipal);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // NUEVO: Conteo total de productos activos/no anulados
        public int ContarProductos()
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                const string sql = @"SELECT COUNT(*) FROM productos WHERE anulado = 0";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    var obj = cmd.ExecuteScalar();
                    return Convert.ToInt32(obj);
                }
            }
        }

        // NUEVO: Conteo para búsqueda
        public int ContarProductosBusqueda(string criterio)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                const string sql = @"
                    SELECT COUNT(*)
                    FROM productos
                    WHERE anulado = 0 AND (codigoPrincipal LIKE @c OR nombre LIKE @c);";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@c", $"%{criterio}%");
                    var obj = cmd.ExecuteScalar();
                    return Convert.ToInt32(obj);
                }
            }
        }

        // ===== MÉTODOS PARA BÚSQUEDA DE PRODUCTOS SIMILARES =====
        
        /// <summary>
        /// Calcula la distancia de Levenshtein entre dos cadenas (número de ediciones necesarias)
        /// </summary>
        private static int CalcularLevenshtein(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1)) return s2?.Length ?? 0;
            if (string.IsNullOrEmpty(s2)) return s1.Length;

            int[,] d = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i <= s1.Length; i++)
                d[i, 0] = i;
            for (int j = 0; j <= s2.Length; j++)
                d[0, j] = j;

            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    int cost = (s2[j - 1] == s1[i - 1]) ? 0 : 1;
                    d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + cost);
                }
            }

            return d[s1.Length, s2.Length];
        }

        /// <summary>
        /// Calcula el porcentaje de similitud entre dos cadenas (0-100%)
        /// </summary>
        public static double CalcularSimilitud(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
                return 0;

            // Normalizar: mayúsculas y quitar espacios extras
            s1 = s1.ToUpper().Trim();
            s2 = s2.ToUpper().Trim();

            if (s1 == s2) return 100;

            int distancia = CalcularLevenshtein(s1, s2);
            int longitudMaxima = Math.Max(s1.Length, s2.Length);
            
            if (longitudMaxima == 0) return 100;

            double similitud = (1.0 - (double)distancia / longitudMaxima) * 100;
            return Math.Round(similitud, 2);
        }

        /// <summary>
        /// Busca productos similares por nombre o código con un umbral de similitud mínimo
        /// </summary>
        public List<ProductoSimilar> BuscarProductosSimilares(string criterio, double umbralSimilitud = 50.0, int maxResultados = 10)
        {
            var productosSimilares = new List<ProductoSimilar>();
            
            if (string.IsNullOrWhiteSpace(criterio))
                return productosSimilares;

            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    // Buscamos productos activos que tengan alguna coincidencia parcial
                    string query = @"
                        SELECT id, codigoPrincipal, nombre, stock, precioVenta 
                        FROM productos 
                        WHERE anulado = 0 AND activo = 1
                        ORDER BY nombre ASC
                        LIMIT 500;"; // Limitamos para no sobrecargar

                    MySqlCommand cmd = new MySqlCommand(query, cn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombre = reader["nombre"].ToString();
                            string codigo = reader["codigoPrincipal"].ToString();

                            // Calculamos similitud por nombre y código
                            double similitudNombre = CalcularSimilitud(criterio, nombre);
                            double similitudCodigo = CalcularSimilitud(criterio, codigo);
                            
                            // Tomamos la mayor similitud
                            double similitudMaxima = Math.Max(similitudNombre, similitudCodigo);

                            if (similitudMaxima >= umbralSimilitud)
                            {
                                productosSimilares.Add(new ProductoSimilar
                                {
                                    Id = Convert.ToInt64(reader["id"]),
                                    CodigoPrincipal = codigo,
                                    Nombre = nombre,
                                    Stock = Convert.ToDecimal(reader["stock"]),
                                    PrecioVenta = Convert.ToDecimal(reader["precioVenta"]),
                                    PorcentajeSimilitud = similitudMaxima
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar productos similares: " + ex.Message);
                }
            }

            // Ordenar por similitud descendente y tomar los mejores resultados
            return productosSimilares
                .OrderByDescending(p => p.PorcentajeSimilitud)
                .Take(maxResultados)
                .ToList();
        }

        /// <summary>
        /// Clase auxiliar para productos similares con porcentaje de coincidencia
        /// </summary>
        public class ProductoSimilar
        {
            public long Id { get; set; }
            public string CodigoPrincipal { get; set; }
            public string Nombre { get; set; }
            public decimal Stock { get; set; }
            public decimal PrecioVenta { get; set; }
            public double PorcentajeSimilitud { get; set; }
        }
    }
}
