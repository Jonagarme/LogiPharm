using CapaDatos;
using LogiPharm.Entidades;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace LogiPharm.Datos
{
    public class DPerchas
    {
        /// <summary>
        /// Lista todas las perchas con información de productos asignados
        /// </summary>
        public DataTable ListarPerchas(string busqueda = "", int? seccionId = null)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                string filtroSeccion = seccionId.HasValue ? "AND p.seccion_id = @seccionId" : "";

                string sql = $@"
                    SELECT 
                        p.id AS Id,
                        p.nombre AS Nombre,
                        p.descripcion AS Descripcion,
                        p.filas AS Filas,
                        p.columnas AS Columnas,
                        p.activo AS Activo,
                        p.seccion_id AS SeccionId,
                        IFNULL(s.nombre, 'Sin sección') AS SeccionNombre,
                        (p.filas * p.columnas) AS CapacidadTotal,
                        IFNULL(COUNT(DISTINCT pu.producto_id), 0) AS ProductosAsignados,
                        ((p.filas * p.columnas) - IFNULL(COUNT(DISTINCT pu.producto_id), 0)) AS EspaciosDisponibles
                    FROM productos_percha p
                    LEFT JOIN productos_seccion s ON p.seccion_id = s.id
                    LEFT JOIN productos_ubicacionproducto pu ON p.id = pu.percha_id AND pu.activo = 1
                    WHERE 1=1
                    {filtroSeccion}
                    AND (
                        @busqueda = ''
                        OR p.nombre LIKE @busquedaLike
                        OR p.descripcion LIKE @busquedaLike
                        OR IFNULL(s.nombre, '') LIKE @busquedaLike
                    )
                    GROUP BY p.id, p.nombre, p.descripcion, p.filas, p.columnas, p.activo, p.seccion_id, s.nombre
                    ORDER BY s.nombre, p.nombre";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@busqueda", busqueda ?? "");
                    cmd.Parameters.AddWithValue("@busquedaLike", $"%{busqueda}%");
                    if (seccionId.HasValue)
                        cmd.Parameters.AddWithValue("@seccionId", seccionId.Value);

                    var dt = new DataTable();
                    new MySqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// Obtiene una percha específica
        /// </summary>
        public EPercha ObtenerPercha(int id)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                string sql = @"
                    SELECT 
                        p.id,
                        p.nombre,
                        p.descripcion,
                        p.filas,
                        p.columnas,
                        p.activo,
                        p.seccion_id,
                        s.nombre AS seccion_nombre
                    FROM productos_percha p
                    LEFT JOIN productos_seccion s ON p.seccion_id = s.id
                    WHERE p.id = @id";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new EPercha
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nombre = reader["nombre"]?.ToString() ?? "",
                                Descripcion = reader["descripcion"]?.ToString() ?? "",
                                Filas = Convert.ToInt32(reader["filas"]),
                                Columnas = Convert.ToInt32(reader["columnas"]),
                                Activo = Convert.ToBoolean(reader["activo"]),
                                SeccionId = reader["seccion_id"] != DBNull.Value ? Convert.ToInt32(reader["seccion_id"]) : 0,
                                SeccionNombre = reader["seccion_nombre"]?.ToString() ?? ""
                            };
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Guarda una nueva percha
        /// </summary>
        public int GuardarPercha(EPercha percha)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                string sql = @"
                    INSERT INTO productos_percha (nombre, descripcion, filas, columnas, activo, seccion_id)
                    VALUES (@nombre, @descripcion, @filas, @columnas, @activo, @seccionId);
                    SELECT LAST_INSERT_ID();";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", percha.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", percha.Descripcion ?? "");
                    cmd.Parameters.AddWithValue("@filas", percha.Filas);
                    cmd.Parameters.AddWithValue("@columnas", percha.Columnas);
                    cmd.Parameters.AddWithValue("@activo", percha.Activo);
                    cmd.Parameters.AddWithValue("@seccionId", percha.SeccionId > 0 ? (object)percha.SeccionId : DBNull.Value);

                    cn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        /// <summary>
        /// Actualiza una percha existente
        /// </summary>
        public bool ActualizarPercha(EPercha percha)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                string sql = @"
                    UPDATE productos_percha 
                    SET nombre = @nombre,
                        descripcion = @descripcion,
                        filas = @filas,
                        columnas = @columnas,
                        activo = @activo,
                        seccion_id = @seccionId
                    WHERE id = @id";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", percha.Id);
                    cmd.Parameters.AddWithValue("@nombre", percha.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", percha.Descripcion ?? "");
                    cmd.Parameters.AddWithValue("@filas", percha.Filas);
                    cmd.Parameters.AddWithValue("@columnas", percha.Columnas);
                    cmd.Parameters.AddWithValue("@activo", percha.Activo);
                    cmd.Parameters.AddWithValue("@seccionId", percha.SeccionId > 0 ? (object)percha.SeccionId : DBNull.Value);

                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Elimina una percha (solo si no tiene productos asignados)
        /// </summary>
        public bool EliminarPercha(int id)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                cn.Open();
                
                // Verificar si tiene productos asignados
                string checkSql = "SELECT COUNT(*) FROM productos_ubicacionproducto WHERE percha_id = @id AND activo = 1";
                using (var checkCmd = new MySqlCommand(checkSql, cn))
                {
                    checkCmd.Parameters.AddWithValue("@id", id);
                    int productosAsignados = Convert.ToInt32(checkCmd.ExecuteScalar());
                    
                    if (productosAsignados > 0)
                    {
                        throw new Exception($"No se puede eliminar la percha porque tiene {productosAsignados} producto(s) asignado(s).");
                    }
                }

                // Eliminar la percha
                string sql = "DELETE FROM productos_percha WHERE id = @id";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Lista todas las secciones disponibles para el combo
        /// </summary>
        public DataTable ListarSecciones()
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                string sql = @"
                    SELECT 
                        id AS Id,
                        nombre AS Nombre,
                        descripcion AS Descripcion
                    FROM productos_seccion
                    WHERE activo = 1
                    ORDER BY nombre";

                var dt = new DataTable();
                new MySqlDataAdapter(sql, cn).Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Obtiene los productos ubicados en una percha específica
        /// </summary>
        public DataTable ObtenerProductosEnPercha(int perchaId)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                string sql = @"
                    SELECT 
                        pu.producto_id AS ProductoId,
                        p.codigoPrincipal AS Codigo,
                        p.nombre AS Producto,
                        pu.fila AS Fila,
                        pu.columna AS Columna,
                        p.stock AS Stock,
                        p.stockMinimo AS StockMinimo
                    FROM productos_ubicacionproducto pu
                    INNER JOIN productos p ON pu.producto_id = p.id
                    WHERE pu.percha_id = @perchaId 
                    AND pu.activo = 1
                    ORDER BY pu.fila, pu.columna";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@perchaId", perchaId);

                    var dt = new DataTable();
                    new MySqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// Verifica si un nombre de percha ya existe
        /// </summary>
        public bool ExisteNombrePercha(string nombre, int? idExcluir = null)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                string sql = "SELECT COUNT(*) FROM productos_percha WHERE nombre = @nombre";
                if (idExcluir.HasValue)
                    sql += " AND id != @idExcluir";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    if (idExcluir.HasValue)
                        cmd.Parameters.AddWithValue("@idExcluir", idExcluir.Value);

                    cn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        /// <summary>
        /// Asigna un producto a una posición específica en la percha
        /// </summary>
        public bool AsignarProductoPercha(EUbicacionProducto ubicacion)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                cn.Open();
                MySqlTransaction transaction = cn.BeginTransaction();

                try
                {
                    // Verificar que la posición esté dentro de los límites de la percha
                    string queryPercha = "SELECT filas, columnas FROM productos_percha WHERE id = @perchaId";
                    MySqlCommand cmdPercha = new MySqlCommand(queryPercha, cn, transaction);
                    cmdPercha.Parameters.AddWithValue("@perchaId", ubicacion.PerchaId);
                    
                    using (var reader = cmdPercha.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int filas = Convert.ToInt32(reader["filas"]);
                            int columnas = Convert.ToInt32(reader["columnas"]);
                            
                            if (ubicacion.Fila < 1 || ubicacion.Fila > filas)
                                throw new Exception($"La fila debe estar entre 1 y {filas}");
                            
                            if (ubicacion.Columna < 1 || ubicacion.Columna > columnas)
                                throw new Exception($"La columna debe estar entre 1 y {columnas}");
                        }
                        else
                        {
                            throw new Exception("La percha especificada no existe");
                        }
                    }

                    // Verificar que la posición no esté ocupada
                    string queryOcupada = @"
                        SELECT COUNT(*) 
                        FROM productos_ubicacionproducto 
                        WHERE percha_id = @perchaId 
                        AND fila = @fila 
                        AND columna = @columna 
                        AND activo = 1";
                    
                    MySqlCommand cmdOcupada = new MySqlCommand(queryOcupada, cn, transaction);
                    cmdOcupada.Parameters.AddWithValue("@perchaId", ubicacion.PerchaId);
                    cmdOcupada.Parameters.AddWithValue("@fila", ubicacion.Fila);
                    cmdOcupada.Parameters.AddWithValue("@columna", ubicacion.Columna);
                    
                    int ocupada = Convert.ToInt32(cmdOcupada.ExecuteScalar());
                    if (ocupada > 0)
                    {
                        throw new Exception($"La posición (Fila {ubicacion.Fila}, Columna {ubicacion.Columna}) ya está ocupada");
                    }

                    // Verificar que el producto no esté ya asignado a esta percha
                    string queryProductoEnPercha = @"
                        SELECT COUNT(*) 
                        FROM productos_ubicacionproducto 
                        WHERE percha_id = @perchaId 
                        AND producto_id = @productoId 
                        AND activo = 1";
                    
                    MySqlCommand cmdProductoEnPercha = new MySqlCommand(queryProductoEnPercha, cn, transaction);
                    cmdProductoEnPercha.Parameters.AddWithValue("@perchaId", ubicacion.PerchaId);
                    cmdProductoEnPercha.Parameters.AddWithValue("@productoId", ubicacion.ProductoId);
                    
                    int yaAsignado = Convert.ToInt32(cmdProductoEnPercha.ExecuteScalar());
                    if (yaAsignado > 0)
                    {
                        throw new Exception("Este producto ya está asignado a esta percha en otra posición");
                    }

                    // Insertar la ubicación
                    string sql = @"
                        INSERT INTO productos_ubicacionproducto 
                        (percha_id, producto_id, fila, columna, observaciones, activo, fecha_ubicacion, usuario_ubicacion_id)
                        VALUES 
                        (@perchaId, @productoId, @fila, @columna, @observaciones, @activo, @fechaUbicacion, @usuarioId)";

                    MySqlCommand cmd = new MySqlCommand(sql, cn, transaction);
                    cmd.Parameters.AddWithValue("@perchaId", ubicacion.PerchaId);
                    cmd.Parameters.AddWithValue("@productoId", ubicacion.ProductoId);
                    cmd.Parameters.AddWithValue("@fila", ubicacion.Fila);
                    cmd.Parameters.AddWithValue("@columna", ubicacion.Columna);
                    cmd.Parameters.AddWithValue("@observaciones", ubicacion.Observaciones ?? "");
                    cmd.Parameters.AddWithValue("@activo", ubicacion.Activo);
                    cmd.Parameters.AddWithValue("@fechaUbicacion", ubicacion.FechaUbicacion);
                    cmd.Parameters.AddWithValue("@usuarioId", ubicacion.UsuarioUbicacionId);

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

        /// <summary>
        /// Remueve un producto de una percha
        /// </summary>
        public bool RemoverProductoPercha(int perchaId, int productoId)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                string sql = @"
                    UPDATE productos_ubicacionproducto 
                    SET activo = 0 
                    WHERE percha_id = @perchaId 
                    AND producto_id = @productoId 
                    AND activo = 1";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@perchaId", perchaId);
                    cmd.Parameters.AddWithValue("@productoId", productoId);

                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Busca productos disponibles para asignar a una percha
        /// </summary>
        public DataTable BuscarProductosDisponibles(string busqueda)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                string sql = @"
                    SELECT 
                        p.id AS Id,
                        p.codigoPrincipal AS Codigo,
                        p.nombre AS Nombre,
                        p.stock AS Stock,
                        p.stockMinimo AS StockMinimo,
                        IFNULL(c.nombre, '') AS Categoria
                    FROM productos p
                    LEFT JOIN categorias c ON p.idCategoria = c.id
                    WHERE p.activo = 1
                    AND (
                        p.codigoPrincipal LIKE @busqueda
                        OR p.nombre LIKE @busqueda
                    )
                    ORDER BY p.nombre
                    LIMIT 50";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@busqueda", $"%{busqueda}%");

                    var dt = new DataTable();
                    new MySqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// Obtiene el mapa de ocupación de una percha
        /// </summary>
        public DataTable ObtenerMapaPercha(int perchaId)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                string sql = @"
                    SELECT 
                        pu.fila AS Fila,
                        pu.columna AS Columna,
                        pu.producto_id AS ProductoId,
                        p.codigoPrincipal AS Codigo,
                        p.nombre AS Producto,
                        CASE WHEN p.stock < p.stockMinimo THEN 1 ELSE 0 END AS BajoStock
                    FROM productos_ubicacionproducto pu
                    INNER JOIN productos p ON pu.producto_id = p.id
                    WHERE pu.percha_id = @perchaId 
                    AND pu.activo = 1
                    ORDER BY pu.fila, pu.columna";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@perchaId", perchaId);

                    var dt = new DataTable();
                    new MySqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }
    }
}

