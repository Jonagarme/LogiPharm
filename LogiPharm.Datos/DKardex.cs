using System;
using System.Data;

namespace LogiPharm.Datos
{
    public class DKardex
    {
        public DataTable ObtenerMovimientos(int idProducto, DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Fecha", typeof(DateTime));
            tabla.Columns.Add("TipoMovimiento", typeof(string));
            tabla.Columns.Add("Detalle", typeof(string));
            tabla.Columns.Add("Ingreso", typeof(decimal));
            tabla.Columns.Add("Egreso", typeof(decimal));
            tabla.Columns.Add("Saldo", typeof(decimal));

            // Añadir filas de ejemplo
            tabla.Rows.Add(DateTime.Now.AddDays(-10), "COMPRA", "Factura FC-001-001-12345", 100.00, 0.00, 100.00);
            tabla.Rows.Add(DateTime.Now.AddDays(-8), "VENTA", "Factura FV-001-001-487", 0.00, 10.00, 90.00);
            tabla.Rows.Add(DateTime.Now.AddDays(-5), "AJUSTE INGRESO", "Ajuste #000001", 5.00, 0.00, 95.00);
            tabla.Rows.Add(DateTime.Now.AddDays(-2), "VENTA", "Factura FV-001-001-499", 0.00, 20.00, 75.00);
            tabla.Rows.Add(DateTime.Now.AddDays(-1), "AJUSTE EGRESO", "Ajuste #000002 por producto dañado", 0.00, 1.00, 74.00);

            return tabla;
        }
    }
}
