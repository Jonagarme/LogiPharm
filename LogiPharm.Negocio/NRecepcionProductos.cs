using System;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Negocio
{
    public static class NRecepcionProductos
    {
        public static bool GuardarRecepcion(EFacturaCompra factura)
        {
            if (factura == null) throw new ArgumentNullException(nameof(factura));
            if (factura.Detalles == null || factura.Detalles.Count == 0) throw new ArgumentException("Debe incluir al menos un detalle en la recepción.");

            return new DRecepcionProductos().GuardarRecepcion(factura);
        }
    }
}
