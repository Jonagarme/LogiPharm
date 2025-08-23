// En DHistorialVentas.cs
using CapaDatos;
using MySqlConnector;
using System;
using System.Data;

namespace LogiPharm.Datos
{
    public class DHistorialVentas
    {
        public DataTable ConsultarHistorial(DateTime fechaInicio, DateTime fechaFin, int idCliente, string textoProducto)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                // Consulta que une facturas, detalles y clientes
                string sql = @"
                    SELECT 
                        fv.fechaEmision AS Fecha,
                        fv.numeroFactura AS Factura,
                        c.nombres AS Cliente,
                        fv.total AS Total,
                        fv.estado AS Estado
                    FROM facturas_venta fv
                    JOIN clientes c ON fv.idCliente = c.id
                    JOIN facturas_venta_detalle fvd ON fv.id = fvd.idFacturaVenta
                    WHERE 
                        DATE(fv.fechaEmision) BETWEEN @fechaInicio AND @fechaFin
                        AND (@idCliente = 0 OR fv.idCliente = @idCliente)
                        AND fvd.productoNombre LIKE @producto
                    GROUP BY fv.id
                    ORDER BY fv.fechaEmision DESC;";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio.Date);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin.Date);
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    cmd.Parameters.AddWithValue("@producto", $"%{textoProducto}%"); // Búsqueda flexible

                    DataTable dt = new DataTable();
                    new MySqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }
    }
}