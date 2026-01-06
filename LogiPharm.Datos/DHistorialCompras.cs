using CapaDatos;
using MySqlConnector;
using System;
using System.Data;

namespace LogiPharm.Datos
{
    public class DHistorialCompras
    {
        /// <summary>
        /// Consulta el historial de compras con filtros de proveedor, producto y fechas
        /// </summary>
        public DataTable ConsultarHistorial(DateTime fechaInicio, DateTime fechaFin, string proveedor, string producto)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                string sql = @"
                    SELECT 
                        fc.fechaRecepcion AS Fecha,
                        fc.numeroFactura AS NumeroFactura,
                        p.razonSocial AS Proveedor,
                        p.ruc AS RUC,
                        prod.codigoPrincipal AS CodigoProducto,
                        prod.nombre AS Producto,
                        fcd.cantidad AS Cantidad,
                        fcd.costoUnitario AS CostoUnitario,
                        fcd.total AS Total
                    FROM facturas_compra fc
                    INNER JOIN proveedores p ON fc.idProveedor = p.id
                    INNER JOIN facturas_compra_detalle fcd ON fc.id = fcd.idFacturaCompra
                    INNER JOIN productos prod ON fcd.idProducto = prod.id
                    WHERE DATE(fc.fechaRecepcion) BETWEEN @fechaInicio AND @fechaFin
                    AND (fc.anulado = 0)
                    AND (
                        @proveedor = '' 
                        OR p.razonSocial LIKE @proveedorLike
                        OR p.ruc LIKE @proveedorLike
                    )
                    AND (
                        @producto = ''
                        OR prod.nombre LIKE @productoLike
                        OR prod.codigoPrincipal LIKE @productoLike
                    )
                    ORDER BY fc.fechaRecepcion DESC, fc.id DESC, prod.nombre ASC";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio.Date);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin.Date);
                    cmd.Parameters.AddWithValue("@proveedor", proveedor ?? "");
                    cmd.Parameters.AddWithValue("@proveedorLike", $"%{proveedor}%");
                    cmd.Parameters.AddWithValue("@producto", producto ?? "");
                    cmd.Parameters.AddWithValue("@productoLike", $"%{producto}%");

                    var dt = new DataTable();
                    new MySqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// Calcula los totales del historial (unidades y costo)
        /// </summary>
        public (decimal TotalUnidades, decimal TotalCosto) CalcularTotales(DataTable dt)
        {
            decimal totalUnidades = 0;
            decimal totalCosto = 0;

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Cantidad"] != DBNull.Value)
                        totalUnidades += Convert.ToDecimal(row["Cantidad"]);
                    
                    if (row["Total"] != DBNull.Value)
                        totalCosto += Convert.ToDecimal(row["Total"]);
                }
            }

            return (totalUnidades, totalCosto);
        }
    }
}
