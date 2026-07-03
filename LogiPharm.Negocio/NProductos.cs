using System;
using System.Collections.Generic;
using System.Data;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Negocio
{
    public static class NProductos
    {
        public static DataTable ListarProductos()
        {
            return new DProductos().ListarProductos();
        }

        public static DataTable ListarProductosPaginado(int offset, int limit)
        {
            return new DProductos().ListarProductosPaginado(offset, limit);
        }

        public static DataTable BuscarProductosParaKardex(string criterio)
        {
            return new DProductos().BuscarProductosParaKardex(criterio);
        }

        public static EProducto BuscarProducto(string texto)
        {
            return new DProductos().BuscarProducto(texto);
        }

        public static EProducto ObtenerPorId(long id)
        {
            return new DProductos().ObtenerPorId(id);
        }

        public static List<EProducto> BuscarProductosActivos(string criterio, int? idUbicacion = null)
        {
            if (criterio == null) criterio = string.Empty;
            return new DProductos().BuscarProductosActivos(criterio, idUbicacion);
        }

        public static EProducto BuscarProductoPorCodigoONombre(string texto)
        {
            return new DProductos().BuscarProductoPorCodigoONombre(texto);
        }

        public static bool InsertarProducto(EProducto producto)
        {
            if (producto == null) throw new ArgumentNullException(nameof(producto));
            if (string.IsNullOrWhiteSpace(producto.Nombre))
                throw new ArgumentException("El nombre del producto es obligatorio.");
            if (string.IsNullOrWhiteSpace(producto.CodigoPrincipal))
                throw new ArgumentException("El código principal del producto es obligatorio.");

            return new DProductos().InsertarProducto(producto);
        }

        public static bool ActualizarProducto(EProducto producto)
        {
            if (producto == null) throw new ArgumentNullException(nameof(producto));
            if (producto.Id <= 0)
                throw new ArgumentException("ID de producto no válido para actualizar.");
            if (string.IsNullOrWhiteSpace(producto.Nombre))
                throw new ArgumentException("El nombre del producto es obligatorio.");

            return new DProductos().ActualizarProducto(producto);
        }

        public static bool ActualizarPrecios(int idProducto, decimal costoCaja, decimal pvp)
        {
            return new DProductos().ActualizarPrecios(idProducto, costoCaja, pvp);
        }

        public static bool ActualizarPreciosAutoPorId(long idProducto, decimal pvp)
        {
            return new DProductos().ActualizarPreciosAutoPorId(idProducto, pvp);
        }

        public static bool ActualizarPreciosAutoPorCodigo(string codigoPrincipal, decimal pvp)
        {
            return new DProductos().ActualizarPreciosAutoPorCodigo(codigoPrincipal, pvp);
        }

        public static int ContarProductos()
        {
            return new DProductos().ContarProductos();
        }

        public static int ContarProductosBusqueda(string criterio)
        {
            return new DProductos().ContarProductosBusqueda(criterio);
        }

        public static List<DProductos.ProductoSimilar> BuscarProductosSimilares(string criterio, double umbralSimilitud = 50.0, int maxResultados = 10)
        {
            return new DProductos().BuscarProductosSimilares(criterio, umbralSimilitud, maxResultados);
        }

        public static DataTable ListarCategorias()
        {
            return new DProductos().ListarCategorias();
        }

        public static DataTable ListarTiposProducto()
        {
            return new DProductos().ListarTiposProducto();
        }

        public static DataTable ListarClasesProducto()
        {
            return new DProductos().ListarClasesProducto();
        }

        public static DataTable ListarSubcategorias()
        {
            return new DProductos().ListarSubcategorias();
        }

        public static DataTable ListarMarcas()
        {
            return new DProductos().ListarMarcas();
        }

        public static DataTable ListarProductosFiltradoPaginado(string criterio, int? idCategoria, int? idLaboratorio, int offset, int limit)
        {
            return new DProductos().ListarProductosFiltradoPaginado(criterio, idCategoria, idLaboratorio, offset, limit);
        }

        public static void ObtenerEstadisticasProductos(out int total, out int enStock, out int stockBajo, out int totalCategorias)
        {
            new DProductos().ObtenerEstadisticasProductos(out total, out enStock, out stockBajo, out totalCategorias);
        }

        public static int ContarProductosFiltrado(string criterio, int? idCategoria, int? idLaboratorio)
        {
            return new DProductos().ContarProductosFiltrado(criterio, idCategoria, idLaboratorio);
        }
    }
}
