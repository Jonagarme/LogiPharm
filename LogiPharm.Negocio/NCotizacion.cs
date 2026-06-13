using System;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Negocio
{
    public static class NCotizacion
    {
        public static int ObtenerProximoNumeroPreview()
        {
            return new DCotizaciones().ObtenerProximoNumeroPreview();
        }

        public static long GuardarCotizacion(ECotizacion cot, int idUsuario)
        {
            if (cot == null) throw new ArgumentNullException(nameof(cot));
            if (cot.IdCliente <= 0) throw new ArgumentException("Debe seleccionar un cliente para la cotización.");
            if (cot.Detalles == null || cot.Detalles.Count == 0) throw new ArgumentException("Debe agregar al menos un producto a la cotización.");
            if (idUsuario <= 0) throw new ArgumentException("El usuario no es válido.");

            return new DCotizaciones().GuardarCotizacion(cot, idUsuario);
        }

        public static void AnularCotizacion(long idCotizacion, int idUsuario)
        {
            if (idCotizacion <= 0) throw new ArgumentException("ID de cotización no válido.");
            if (idUsuario <= 0) throw new ArgumentException("El usuario no es válido.");

            new DCotizaciones().AnularCotizacion(idCotizacion, idUsuario);
        }

        public static int ObtenerNumeroPorId(long idCotizacion)
        {
            if (idCotizacion <= 0) throw new ArgumentException("ID de cotización no válido.");
            return new DCotizaciones().ObtenerNumeroPorId(idCotizacion);
        }

        public static ECotizacion ObtenerCotizacionPorNumero(int numero)
        {
            if (numero <= 0) throw new ArgumentException("El número de cotización debe ser mayor a cero.");
            return new DCotizaciones().ObtenerCotizacionPorNumero(numero);
        }

        public static ECotizacion ObtenerUltimaCotizacion()
        {
            return new DCotizaciones().ObtenerUltimaCotizacion();
        }
    }
}
