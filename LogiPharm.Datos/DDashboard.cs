using System;
using System.Data;

namespace LogiPharm.Datos
{
    public class DDashboard
    {
        public DataTable ObtenerKPIs()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("VentasHoy", typeof(decimal));
            dt.Columns.Add("TotalClientes", typeof(int));
            dt.Columns.Add("ProductosStock", typeof(int));
            dt.Columns.Add("TotalProveedores", typeof(int));
            dt.Rows.Add(1250.75m, 89, 1796, 15);
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
