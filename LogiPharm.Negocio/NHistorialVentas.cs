using System;
using System.Data;
using LogiPharm.Datos;

namespace LogiPharm.Negocio
{
    public static class NHistorialVentas
    {
        public static DataTable ConsultarHistorial(DateTime fechaInicio, DateTime fechaFin, int idCliente, string textoProducto)
        {
            if (textoProducto == null) textoProducto = string.Empty;
            return new DHistorialVentas().ConsultarHistorial(fechaInicio, fechaFin, idCliente, textoProducto);
        }
    }
}
