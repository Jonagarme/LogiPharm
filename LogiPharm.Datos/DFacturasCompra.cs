using CapaDatos;
using MySqlConnector;
using System;
using System.Data;

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
        /// Obtiene el detalle de una factura de compra específica
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
        /// Obtiene información completa de una factura (encabezado)
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

                    // Aquí podrías revertir el stock si es necesario
                    // TODO: Implementar lógica de reversión de stock si se requiere

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
