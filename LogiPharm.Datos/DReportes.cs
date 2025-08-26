using CapaDatos;
using MySqlConnector;
using System;
using System.Data;
using System.Text;

namespace LogiPharm.Datos
{
    public class DReportes
    {
        public DataTable GenerarReporteVentas(DateTime fechaInicio, DateTime fechaFin, int idCliente, int idUsuario, string producto)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                var sql = new StringBuilder();
                sql.AppendLine(@"SELECT 
                                 fv.id AS Id,
                                 fv.fechaEmision AS Fecha,
                                 fv.numeroFactura AS Factura,
                                 c.nombres AS Cliente,
                                 u.nombreUsuario AS Cajero,
                                 fv.subtotal AS Subtotal,
                                 fv.descuento AS Descuento,
                                 fv.iva AS IVA,
                                 fv.total AS Total,
                                 fv.estado AS Estado
                               FROM facturas_venta fv
                               JOIN clientes c ON fv.idCliente = c.id
                               JOIN usuarios u ON fv.idUsuario = u.id");

                if (!string.IsNullOrEmpty(producto))
                {
                    sql.AppendLine("JOIN facturas_venta_detalle fvd ON fv.id = fvd.idFacturaVenta");
                }

                sql.AppendLine("WHERE DATE(fv.fechaEmision) BETWEEN @fechaInicio AND @fechaFin");

                if (idCliente > 0)
                {
                    sql.AppendLine("AND fv.idCliente = @idCliente");
                }
                if (idUsuario > 0)
                {
                    sql.AppendLine("AND fv.idUsuario = @idUsuario");
                }
                if (!string.IsNullOrEmpty(producto))
                {
                    sql.AppendLine("AND fvd.productoNombre LIKE @producto");
                }

                sql.AppendLine("GROUP BY fv.id ORDER BY fv.fechaEmision DESC;");

                using (var cmd = new MySqlCommand(sql.ToString(), cn))
                {
                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio.Date);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin.Date);

                    if (idCliente > 0) cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    if (idUsuario > 0) cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    if (!string.IsNullOrEmpty(producto)) cmd.Parameters.AddWithValue("@producto", $"%{producto}%");

                    DataTable dt = new DataTable();
                    new MySqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }
    }
}