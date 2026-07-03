using System;
using System.Data;
using LogiPharm.Datos;

namespace LogiPharm.Negocio
{
    public static class NHistorialComprasCliente
    {
        public static DataTable ConsultarHistorialCliente(DateTime fechaInicio, DateTime fechaFin, int? idCliente, string producto)
        {
            if (fechaInicio > fechaFin)
                throw new ArgumentException("La fecha de inicio no puede ser posterior a la fecha de fin.");

            return new DHistorialComprasCliente().ConsultarHistorialCliente(fechaInicio, fechaFin, idCliente, producto);
        }

        public static (decimal TotalUnidades, decimal TotalVendido) CalcularTotales(DataTable dt)
        {
            decimal totalUnidades = 0;
            decimal totalVendido = 0;

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Cantidad"] != DBNull.Value)
                        totalUnidades += Convert.ToDecimal(row["Cantidad"]);
                    
                    if (row["Total"] != DBNull.Value)
                        totalVendido += Convert.ToDecimal(row["Total"]);
                }
            }

            return (totalUnidades, totalVendido);
        }
    }
}
