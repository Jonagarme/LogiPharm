using MySqlConnector;
using System;
using System.Data;

namespace LogiPharm.Datos
{
    public class DHistorialComprasCliente
    {
        public DataTable ConsultarHistorialCliente(DateTime fechaInicio, DateTime fechaFin, int? idCliente, string producto)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string sql = @"
                        SELECT 
                            fv.fechaEmision AS Fecha,
                            fv.numeroFactura AS NumeroFactura,
                            c.razonSocial AS Cliente,
                            c.cedula_ruc AS Identificacion,
                            p.codigoPrincipal AS CodigoProducto,
                            fvd.productoNombre AS Producto,
                            fvd.cantidad AS Cantidad,
                            fvd.precioUnitario AS PrecioUnitario,
                            fvd.total AS Total
                        FROM facturas_venta fv
                        INNER JOIN clientes c ON fv.idCliente = c.id
                        INNER JOIN facturas_venta_detalle fvd ON fv.id = fvd.idFacturaVenta
                        INNER JOIN productos p ON fvd.idProducto = p.id
                        WHERE DATE(fv.fechaEmision) BETWEEN @fechaInicio AND @fechaFin
                          AND fv.anulado = 0
                          AND fv.idEmpresa = @idEmpresa
                          AND (@idCliente IS NULL OR fv.idCliente = @idCliente)
                          AND (@producto = '' OR p.nombre LIKE @productoLike OR p.codigoPrincipal LIKE @productoLike)
                        ORDER BY fv.fechaEmision DESC, fv.id DESC, p.nombre ASC;";

                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio.Date);
                        cmd.Parameters.AddWithValue("@fechaFin", fechaFin.Date);
                        cmd.Parameters.AddWithValue("@idEmpresa", CapaDatos.Conexion.IdEmpresa);
                        cmd.Parameters.AddWithValue("@idCliente", (object)idCliente ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@producto", producto ?? "");
                        cmd.Parameters.AddWithValue("@productoLike", $"%{producto}%");

                        DataTable dt = new DataTable();
                        using (var da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        return dt;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al consultar el historial de compras del cliente: " + ex.Message);
                }
            }
        }
    }
}
