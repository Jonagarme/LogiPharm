using System;
using System.Data;
using LogiPharm.Datos;

namespace LogiPharm.Negocio
{
    public static class NKardex
    {
        public static DataTable ObtenerMovimientos(int idProducto, DateTime fechaInicio, DateTime fechaFin)
        {
            if (idProducto <= 0) throw new ArgumentException("ID de producto no válido.");
            return new DKardex().ObtenerMovimientos(idProducto, fechaInicio, fechaFin);
        }
    }
}
