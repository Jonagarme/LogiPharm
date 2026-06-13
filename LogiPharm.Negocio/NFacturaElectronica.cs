using System;
using System.Threading.Tasks;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Negocio
{
    public static class NFacturaElectronica
    {
        public static EFacturaElectronica ParsearXML(string rutaArchivoOContenido)
        {
            if (string.IsNullOrWhiteSpace(rutaArchivoOContenido))
                throw new ArgumentException("El archivo o contenido XML no puede estar vacío.");
            return new DFacturaElectronica().ParsearXML(rutaArchivoOContenido);
        }

        public static Task<EFacturaElectronica> ConsultarPorClaveAccesoAsync(string claveAcceso, bool? esProduccionOverride = null)
        {
            if (string.IsNullOrWhiteSpace(claveAcceso))
                throw new ArgumentException("La clave de acceso no puede estar vacía.");
            return new DFacturaElectronica().ConsultarPorClaveAccesoAsync(claveAcceso, esProduccionOverride);
        }

        public static EFacturaElectronica ConsultarPorClaveAcceso(string claveAcceso)
        {
            if (string.IsNullOrWhiteSpace(claveAcceso))
                throw new ArgumentException("La clave de acceso no puede estar vacía.");
            return new DFacturaElectronica().ConsultarPorClaveAcceso(claveAcceso);
        }

        public static void BuscarProductosExistentes(EFacturaElectronica factura)
        {
            if (factura == null) throw new ArgumentNullException(nameof(factura));
            new DFacturaElectronica().BuscarProductosExistentes(factura);
        }
    }
}
