using System;
using System.Data;
using System.Threading.Tasks;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Negocio
{
    public static class NFacturacion
    {
        public static Task<RespuestaFacturaApi> ProcesarFacturaApiAsync(ProcesarFacturaRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            return new DFacturacion().ProcesarFacturaApiAsync(request);
        }

        public static Task<RespuestaFacturaApi> AnularFacturaApiAsync(AnularFacturaRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            return new DFacturacion().AnularFacturaApiAsync(request);
        }

        public static Task<RespuestaConsultaApi> ConsultarSriApiAsync(string claveAcceso, bool esProduccion)
        {
            if (string.IsNullOrWhiteSpace(claveAcceso))
                throw new ArgumentException("La clave de acceso no puede estar vacía.");
            return new DFacturacion().ConsultarSriApiAsync(claveAcceso, esProduccion);
        }

        public static DataTable ListarFacturas(DateTime fechaInicio, DateTime fechaFin, string textoBusqueda, 
            int? idCaja = null, string tipoDocumento = null, string estado = null, 
            string estadoSRI = null, int? idCajero = null)
        {
            return new DFacturacion().ListarFacturas(fechaInicio, fechaFin, textoBusqueda, idCaja, tipoDocumento, estado, estadoSRI, idCajero);
        }

        public static (DataRow Encabezado, DataTable Detalle) ObtenerFacturaDesdeDb(int idFactura)
        {
            return new DFacturacion().ObtenerFacturaDesdeDb(idFactura);
        }

        public static DataTable BuscarFacturasPorNumero(string termino)
        {
            return new DFacturacion().BuscarFacturasPorNumero(termino);
        }

        public static (DataRow Encabezado, DataTable Detalle) ObtenerFacturaPorNumero(string termino)
        {
            return new DFacturacion().ObtenerFacturaPorNumero(termino);
        }

        public static Task<RespuestaConsultaApi> ObtenerDetalleDesdeApi(string claveAcceso)
        {
            if (string.IsNullOrWhiteSpace(claveAcceso))
                throw new ArgumentException("La clave de acceso no puede estar vacía.");
            return new DFacturacion().ObtenerDetalleDesdeApi(claveAcceso);
        }

        public static string ObtenerUltimoNumeroFactura()
        {
            return new DFacturacion().ObtenerUltimoNumeroFactura();
        }

        public static DataTable ObtenerCajas()
        {
            return new DFacturacion().ObtenerCajas();
        }

        public static DataTable ObtenerCajeros()
        {
            return new DFacturacion().ObtenerCajeros();
        }

        public static Task<RespuestaReenvioApi> ReenviarFacturaAlSri(string claveAcceso)
        {
            if (string.IsNullOrWhiteSpace(claveAcceso))
                throw new ArgumentException("La clave de acceso no puede estar vacía.");
            return new DFacturacion().ReenviarFacturaAlSri(claveAcceso);
        }

        public static Task<RespuestaFacturaApi> EnviarNotaCreditoApiAsync(NotaCreditoPayload payload)
        {
            if (payload == null) throw new ArgumentNullException(nameof(payload));
            return new DFacturacion().EnviarNotaCreditoApiAsync(payload);
        }
    }
}
