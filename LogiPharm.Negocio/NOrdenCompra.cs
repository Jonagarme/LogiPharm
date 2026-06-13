using System;
using System.Data;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Negocio
{
    public static class NOrdenCompra
    {
        public static DataTable ListarOrdenesPaginado(int offset, int limit)
        {
            return new DOrdenesCompra().ListarOrdenesPaginado(offset, limit);
        }

        public static DataTable BuscarOrdenesPaginado(string criterio, int offset, int limit)
        {
            if (criterio == null) criterio = string.Empty;
            return new DOrdenesCompra().BuscarOrdenesPaginado(criterio, offset, limit);
        }

        public static int ContarOrdenes()
        {
            return new DOrdenesCompra().ContarOrdenes();
        }

        public static int ContarOrdenesBusqueda(string criterio)
        {
            if (criterio == null) criterio = string.Empty;
            return new DOrdenesCompra().ContarOrdenesBusqueda(criterio);
        }

        public static EOrdenCompra ObtenerOrdenCompleta(long idOrden)
        {
            if (idOrden <= 0) throw new ArgumentException("ID de orden no válido.");
            return new DOrdenesCompra().ObtenerOrdenCompleta(idOrden);
        }

        public static long GuardarOrdenCompra(EOrdenCompra orden)
        {
            if (orden == null) throw new ArgumentNullException(nameof(orden));
            if (orden.IdProveedor <= 0) throw new ArgumentException("Debe seleccionar un proveedor válido.");
            if (orden.Detalles == null || orden.Detalles.Count == 0) throw new ArgumentException("La orden debe tener al menos un detalle.");

            return new DOrdenesCompra().GuardarOrdenCompra(orden);
        }

        public static bool ActualizarOrdenCompra(EOrdenCompra orden)
        {
            if (orden == null) throw new ArgumentNullException(nameof(orden));
            if (orden.Id <= 0) throw new ArgumentException("ID de orden no válido para actualizar.");
            if (orden.IdProveedor <= 0) throw new ArgumentException("Debe seleccionar un proveedor válido.");
            if (orden.Detalles == null || orden.Detalles.Count == 0) throw new ArgumentException("La orden debe tener al menos un detalle.");

            return new DOrdenesCompra().ActualizarOrdenCompra(orden);
        }

        public static bool AnularOrdenCompra(long idOrden, int usuarioId)
        {
            if (idOrden <= 0) throw new ArgumentException("ID de orden no válido.");
            return new DOrdenesCompra().AnularOrdenCompra(idOrden, usuarioId);
        }

        public static bool CambiarEstado(long idOrden, string nuevoEstado)
        {
            if (idOrden <= 0) throw new ArgumentException("ID de orden no válido.");
            if (string.IsNullOrWhiteSpace(nuevoEstado)) throw new ArgumentException("El nuevo estado no puede estar vacío.");
            return new DOrdenesCompra().CambiarEstado(idOrden, nuevoEstado);
        }

        public static bool AprobarOrdenCompra(long idOrden, int usuarioId)
        {
            if (idOrden <= 0) throw new ArgumentException("ID de orden no válido.");
            return new DOrdenesCompra().AprobarOrdenCompra(idOrden, usuarioId);
        }
    }
}
