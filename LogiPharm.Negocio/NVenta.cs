using System;
using System.Collections.Generic;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Negocio
{
    public static class NVenta
    {
        public static void GuardarFactura(ECliente cliente, List<ProductoVenta> productos, string numeroFactura, 
            int idCierreCaja, int idUsuario, string numeroAutorizacion, int idEmpresa, 
            bool esEntrega = false, string estadoFactura = "PENDIENTE", int? idUbicacion = null)
        {
            if (cliente == null) throw new ArgumentNullException(nameof(cliente));
            if (productos == null || productos.Count == 0) throw new ArgumentException("Debe agregar al menos un producto a la venta.");
            if (string.IsNullOrWhiteSpace(numeroFactura)) throw new ArgumentException("El número de factura es obligatorio.");
            if (idCierreCaja <= 0) throw new ArgumentException("Debe existir una caja abierta para guardar la factura.");
            if (idUsuario <= 0) throw new ArgumentException("El usuario cajero no es válido.");

            new DFacturaVenta().GuardarFactura(cliente, productos, numeroFactura, idCierreCaja, idUsuario, numeroAutorizacion, idEmpresa, esEntrega, estadoFactura, idUbicacion);
        }
    }
}
