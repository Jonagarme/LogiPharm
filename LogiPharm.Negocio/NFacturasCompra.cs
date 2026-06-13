using System;
using System.Collections.Generic;
using System.Data;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Negocio
{
    public static class NFacturasCompra
    {
        public static DataTable ListarFacturas(DateTime fechaInicio, DateTime fechaFin, string busqueda, string estado)
        {
            if (busqueda == null) busqueda = string.Empty;
            if (estado == null) estado = "TODOS";
            return new DFacturasCompra().ListarFacturas(fechaInicio, fechaFin, busqueda, estado);
        }

        public static DataTable ObtenerDetalle(int idFactura)
        {
            if (idFactura <= 0) throw new ArgumentException("ID de factura no válido.");
            return new DFacturasCompra().ObtenerDetalle(idFactura);
        }

        public static DataRow ObtenerFactura(int idFactura)
        {
            if (idFactura <= 0) throw new ArgumentException("ID de factura no válido.");
            return new DFacturasCompra().ObtenerFactura(idFactura);
        }

        public static bool AnularFactura(int idFactura, int idUsuario)
        {
            if (idFactura <= 0) throw new ArgumentException("ID de factura no válido.");
            return new DFacturasCompra().AnularFactura(idFactura, idUsuario);
        }

        public static bool GuardarIngresoXML(EFacturaElectronica factura, List<EDetalleFacturaXML> detalles, int idUsuario)
        {
            if (factura == null) throw new ArgumentNullException(nameof(factura));
            if (detalles == null || detalles.Count == 0) throw new ArgumentException("Debe incluir al menos un detalle en la factura.");

            return new DFacturasCompra().GuardarIngresoXML(factura, detalles, idUsuario);
        }
    }
}
