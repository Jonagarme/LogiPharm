using System;
using System.Collections.Generic;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Negocio
{
    public static class NInventarioLote
    {
        public static List<EInventarioLote> ObtenerLotesPorCodigoProducto(string codigoProducto, int? idUbicacion = null, bool? soloActivos = true)
        {
            if (string.IsNullOrWhiteSpace(codigoProducto)) throw new ArgumentException("El código del producto es requerido.");
            return new DInventarioLotes().ObtenerLotesPorCodigoProducto(codigoProducto, idUbicacion, soloActivos);
        }

        public static List<EInventarioLote> ObtenerLotesDisponiblesPorProductoYUbicacion(int idProducto, int idUbicacion)
        {
            if (idProducto <= 0) throw new ArgumentException("ID de producto no válido.");
            if (idUbicacion <= 0) throw new ArgumentException("ID de ubicación no válido.");
            return new DInventarioLotes().ObtenerLotesDisponiblesPorProductoYUbicacion(idProducto, idUbicacion);
        }

        public static List<EInventarioLote> ObtenerLotesPorProducto(int idProducto)
        {
            if (idProducto <= 0) throw new ArgumentException("ID de producto no válido.");
            return new DInventarioLotes().ObtenerLotesPorProducto(idProducto);
        }

        public static decimal ObtenerStockTotalDisponible(int idProducto, int idUbicacion)
        {
            if (idProducto <= 0) throw new ArgumentException("ID de producto no válido.");
            if (idUbicacion <= 0) throw new ArgumentException("ID de ubicación no válido.");
            return new DInventarioLotes().ObtenerStockTotalDisponible(idProducto, idUbicacion);
        }

        public static bool ReservarStock(int idLote, decimal cantidad)
        {
            if (idLote <= 0) throw new ArgumentException("ID de lote no válido.");
            if (cantidad <= 0) throw new ArgumentException("La cantidad a reservar debe ser mayor que cero.");
            return new DInventarioLotes().ReservarStock(idLote, cantidad);
        }

        public static bool LiberarStockReservado(int idLote, decimal cantidad)
        {
            if (idLote <= 0) throw new ArgumentException("ID de lote no válido.");
            if (cantidad <= 0) throw new ArgumentException("La cantidad a liberar debe ser mayor que cero.");
            return new DInventarioLotes().LiberarStockReservado(idLote, cantidad);
        }

        public static List<EInventarioLote> ObtenerTodosLotes(int? idProducto = null, int? idUbicacion = null, DateTime? fechaDesde = null, DateTime? fechaHasta = null, bool? soloActivos = true)
        {
            return new DInventarioLotes().ObtenerTodosLotes(idProducto, idUbicacion, fechaDesde, fechaHasta, soloActivos);
        }

        public static EInventarioLote ObtenerLotePorId(int idLote)
        {
            if (idLote <= 0) throw new ArgumentException("ID de lote no válido.");
            return new DInventarioLotes().ObtenerLotePorId(idLote);
        }

        public static bool ActualizarLote(int idLote, string numeroLote, DateTime fechaIngreso, 
            DateTime fechaFabricacion, DateTime fechaCaducidad, decimal costoUnitario, 
            string numeroFactura, string observaciones, bool activo)
        {
            if (idLote <= 0) throw new ArgumentException("ID de lote no válido.");
            if (string.IsNullOrWhiteSpace(numeroLote)) throw new ArgumentException("El número de lote es obligatorio.");
            if (costoUnitario < 0) throw new ArgumentException("El costo unitario no puede ser negativo.");

            return new DInventarioLotes().ActualizarLote(idLote, numeroLote, fechaIngreso, fechaFabricacion, fechaCaducidad, costoUnitario, numeroFactura, observaciones, activo);
        }

        public static bool InsertarLote(int productoId, int ubicacionId, string numeroLote, DateTime fechaIngreso, 
            DateTime fechaFabricacion, DateTime fechaCaducidad, decimal cantidadInicial, decimal costoUnitario, 
            string numeroFactura, string observaciones, bool activo)
        {
            if (productoId <= 0) throw new ArgumentException("ID de producto no válido.");
            if (ubicacionId <= 0) throw new ArgumentException("ID de ubicación no válido.");
            if (string.IsNullOrWhiteSpace(numeroLote)) throw new ArgumentException("El número de lote es obligatorio.");
            if (cantidadInicial <= 0) throw new ArgumentException("La cantidad inicial debe ser mayor que cero.");
            if (costoUnitario < 0) throw new ArgumentException("El costo unitario no puede ser negativo.");

            return new DInventarioLotes().InsertarLote(productoId, ubicacionId, numeroLote, fechaIngreso, fechaFabricacion, fechaCaducidad, cantidadInicial, costoUnitario, numeroFactura, observaciones, activo);
        }
    }
}
