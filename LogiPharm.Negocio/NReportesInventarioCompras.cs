using System;
using System.Data;
using LogiPharm.Datos;

namespace LogiPharm.Negocio
{
    public static class NReportesInventarioCompras
    {
        public static DataTable ObtenerReporteInventario(int? idCategoria, int? idLaboratorio, string estadoStock)
        {
            return new DReportesInventarioCompras().ObtenerReporteInventario(idCategoria, idLaboratorio, estadoStock);
        }

        public static DataTable ObtenerReporteCompras(DateTime fechaInicio, DateTime fechaFin, int? idProveedor)
        {
            if (fechaInicio > fechaFin)
                throw new ArgumentException("La fecha de inicio no puede ser posterior a la fecha de fin.");

            return new DReportesInventarioCompras().ObtenerReporteCompras(fechaInicio, fechaFin, idProveedor);
        }

        public static (decimal CostoTotal, decimal PVPValue) CalcularTotalesInventario(DataTable dt)
        {
            decimal costoTotal = 0;
            decimal pvpValue = 0;

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["CostoTotal"] != DBNull.Value)
                        costoTotal += Convert.ToDecimal(row["CostoTotal"]);
                    
                    if (row["ValorTotal"] != DBNull.Value)
                        pvpValue += Convert.ToDecimal(row["ValorTotal"]);
                }
            }

            return (costoTotal, pvpValue);
        }

        public static decimal CalcularTotalCompras(DataTable dt)
        {
            decimal total = 0;

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Total"] != DBNull.Value)
                        total += Convert.ToDecimal(row["Total"]);
                }
            }

            return total;
        }
    }
}
