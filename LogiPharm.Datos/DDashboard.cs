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
                (SELECT SUM(stock) FROM productos) AS ProductosStock,
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
        public DataTable ObtenerVentasUltimoMes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("TotalVentas", typeof(decimal));
            Random rand = new Random();
            for (int i = 30; i >= 1; i--)
            {
                dt.Rows.Add(DateTime.Now.AddDays(-i), rand.Next(500, 2000));
            }
            return dt;
        }

        // Simula la obtención del top 5 de productos más vendidos.
        public DataTable ObtenerTopProductos()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Producto", typeof(string));
            dt.Columns.Add("TotalVendido", typeof(int));
            dt.Rows.Add("PARACETAMOL 500MG", 150);
            dt.Rows.Add("COMPLEJO B JARABE", 120);
            dt.Rows.Add("VITAMINA C 500MG", 95);
            dt.Rows.Add("METFORMINA 850MG", 80);
            dt.Rows.Add("IBUPROFENO 400MG", 75);
            return dt;
        }
    }
}
