using System;
using System.Data;
using MySqlConnector;

namespace LogiPharm.Datos
{
    public class DCierreCaja
    {
        // Este método simula la obtención de datos para el cierre de caja.
        // TODO: Reemplazar con consultas reales a tus tablas de ventas, pagos, etc.
        public DataSet ObtenerDatosCierre(int idCaja, DateTime fecha)
        {
            DataSet ds = new DataSet();

            // --- Tabla 1: Resumen de Ingresos por Forma de Pago ---
            DataTable dtIngresos = new DataTable("Ingresos");
            dtIngresos.Columns.Add("FormaPago", typeof(string));
            dtIngresos.Columns.Add("Total", typeof(decimal));
            dtIngresos.Rows.Add("Efectivo", 1250.75m);
            dtIngresos.Rows.Add("Tarjeta de Crédito/Débito", 850.20m);
            dtIngresos.Rows.Add("Transferencia", 300.00m);
            ds.Tables.Add(dtIngresos);

            // --- Tabla 2: Resumen de Egresos ---
            DataTable dtEgresos = new DataTable("Egresos");
            dtEgresos.Columns.Add("Concepto", typeof(string));
            dtEgresos.Columns.Add("Total", typeof(decimal));
            dtEgresos.Rows.Add("Pago a Proveedores", 150.00m);
            dtEgresos.Rows.Add("Servicios Básicos", 55.50m);
            ds.Tables.Add(dtEgresos);

            // --- Tabla 3: Totales Generales ---
            DataTable dtTotales = new DataTable("Totales");
            dtTotales.Columns.Add("SaldoInicial", typeof(decimal));
            dtTotales.Rows.Add(200.00m); // Saldo inicial de la caja
            ds.Tables.Add(dtTotales);

            return ds;
        }
    }
}
