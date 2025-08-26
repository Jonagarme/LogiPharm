using CapaDatos;
using MySqlConnector;
using System;
using System.Data;

namespace LogiPharm.Datos
{
    public class DDashboard
    {
        public DataTable ObtenerKPIs()
        {
            DataTable dt = new DataTable();

            string query = @"
            SELECT
              (SELECT IFNULL(SUM(total), 0) FROM facturas_venta WHERE DATE(fechaEmision) = CURDATE()) AS VentasHoy,
                (SELECT COUNT(*) FROM clientes) AS TotalClientes,
                (SELECT SUM(id) FROM productos) AS ProductosStock,
                (SELECT COUNT(*) FROM proveedores) AS TotalProveedores;
        ";

            using (var conn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }

            return dt;
        }

        // Simula la obtención de ventas de los últimos 30 días.
        // === Ventas por día últimos 30 días (devuelve TODOS los días, incluso los que no tienen ventas) ===
        public DataTable ObtenerVentasUltimoMes()
        {
            // 1) Traemos lo que exista en BD
            var dtRaw = new DataTable();
            string sql = @"
                SELECT DATE(fv.fechaEmision) AS Fecha, IFNULL(SUM(fv.total),0) AS TotalVentas
                  FROM facturas_venta fv
                 WHERE fv.anulado = 0
                   AND DATE(fv.fechaEmision) BETWEEN @desde AND @hasta
              GROUP BY DATE(fv.fechaEmision)
              ORDER BY Fecha;
            ";

            DateTime hasta = DateTime.Today;
            DateTime desde = hasta.AddDays(-29); // 30 días incluyendo hoy

            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            using (var cmd = new MySqlCommand(sql, cn))
            using (var da = new MySqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@desde", desde.Date);
                cmd.Parameters.AddWithValue("@hasta", hasta.Date);
                cn.Open();
                da.Fill(dtRaw);
            }

            // 2) Construimos una serie completa de 30 días (rellenando con 0 donde no haya ventas)
            var dt = new DataTable();
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("TotalVentas", typeof(decimal));

            var mapas = new System.Collections.Generic.Dictionary<DateTime, decimal>();
            foreach (DataRow r in dtRaw.Rows)
            {
                var f = Convert.ToDateTime(r["Fecha"]).Date;
                var t = Convert.ToDecimal(r["TotalVentas"]);
                mapas[f] = t;
            }

            for (var d = desde.Date; d <= hasta.Date; d = d.AddDays(1))
            {
                decimal total = mapas.TryGetValue(d, out var t) ? t : 0m;
                dt.Rows.Add(d, total);
            }

            return dt;
        }

        // === Top 5 productos por unidades vendidas (últimos 30 días) ===
        public DataTable ObtenerTopProductos()
        {
            var dt = new DataTable();

            string sql = @"
                SELECT 
                    COALESCE(NULLIF(d.productoNombre,''), p.nombre) AS Producto,
                    SUM(d.cantidad)                                 AS TotalVendido
                  FROM facturas_venta_detalle d
                  JOIN facturas_venta fv ON fv.id = d.idFacturaVenta
                  LEFT JOIN productos p ON p.id = d.idProducto
                 WHERE fv.anulado = 0
                   AND DATE(fv.fechaEmision) BETWEEN @desde AND @hasta
              GROUP BY Producto
              ORDER BY TotalVendido DESC
                 LIMIT 5;
            ";

            DateTime hasta = DateTime.Today;
            DateTime desde = hasta.AddDays(-29);

            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            using (var cmd = new MySqlCommand(sql, cn))
            using (var da = new MySqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@desde", desde.Date);
                cmd.Parameters.AddWithValue("@hasta", hasta.Date);
                cn.Open();
                da.Fill(dt);
            }

            return dt;
        }
    }
}
