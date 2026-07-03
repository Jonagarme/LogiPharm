using MySqlConnector;
using System;
using System.Data;

namespace LogiPharm.Datos
{
    public class DReportesInventarioCompras
    {
        public DataTable ObtenerReporteInventario(int? idCategoria, int? idLaboratorio, string estadoStock)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string filterStock = "";
                    if (estadoStock == "BAJO")
                        filterStock = "AND p.stock <= p.stockMinimo AND p.stock > 0";
                    else if (estadoStock == "SIN_STOCK")
                        filterStock = "AND p.stock <= 0";
                    else if (estadoStock == "CON_STOCK")
                        filterStock = "AND p.stock > 0";

                    string sql = $@"
                        SELECT 
                            p.codigoPrincipal AS Codigo,
                            p.nombre AS Nombre,
                            COALESCE(c.nombre, 'Sin Categoría') AS Categoria,
                            COALESCE(l.nombre, 'Sin Laboratorio') AS Laboratorio,
                            p.stock AS Stock,
                            p.costoUnidad AS CostoUnitario,
                            p.precioVenta AS PrecioVenta,
                            (p.stock * p.costoUnidad) AS CostoTotal,
                            (p.stock * p.precioVenta) AS ValorTotal,
                            p.stockMinimo AS StockMinimo
                        FROM productos p
                        LEFT JOIN categorias c ON p.idCategoria = c.id
                        LEFT JOIN laboratorios l ON p.idLaboratorio = l.id
                        WHERE p.anulado = 0
                          {filterStock}
                          AND (@idCategoria IS NULL OR p.idCategoria = @idCategoria)
                          AND (@idLaboratorio IS NULL OR p.idLaboratorio = @idLaboratorio)
                        ORDER BY p.nombre ASC;";

                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@idCategoria", (object)idCategoria ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@idLaboratorio", (object)idLaboratorio ?? DBNull.Value);

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
                    throw new Exception("Error al obtener reporte de inventario: " + ex.Message);
                }
            }
        }

        public DataTable ObtenerReporteCompras(DateTime fechaInicio, DateTime fechaFin, int? idProveedor)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string sql = @"
                        SELECT 
                            fc.fechaRecepcion AS Fecha,
                            fc.numeroFactura AS NumeroFactura,
                            p.razonSocial AS Proveedor,
                            p.ruc AS RUC,
                            fc.subtotal AS Subtotal,
                            fc.iva AS IVA,
                            fc.total AS Total,
                            fc.estado AS Estado,
                            u.nombreCompleto AS RegistradoPor
                        FROM facturas_compra fc
                        INNER JOIN proveedores p ON fc.idProveedor = p.id
                        INNER JOIN usuarios u ON fc.creadoPor = u.id
                        WHERE DATE(fc.fechaRecepcion) BETWEEN @fechaInicio AND @fechaFin
                          AND fc.anulado = 0
                          AND (@idProveedor IS NULL OR fc.idProveedor = @idProveedor)
                        ORDER BY fc.fechaRecepcion DESC;";

                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio.Date);
                        cmd.Parameters.AddWithValue("@fechaFin", fechaFin.Date);
                        cmd.Parameters.AddWithValue("@idProveedor", (object)idProveedor ?? DBNull.Value);

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
                    throw new Exception("Error al obtener reporte de compras: " + ex.Message);
                }
            }
        }
    }
}
