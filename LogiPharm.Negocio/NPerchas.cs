using System;
using System.Data;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Negocio
{
    public static class NPerchas
    {
        public static DataTable ListarPerchas(string busqueda = "", int? seccionId = null)
        {
            if (busqueda == null) busqueda = string.Empty;
            return new DPerchas().ListarPerchas(busqueda, seccionId);
        }

        public static EPercha ObtenerPercha(int id)
        {
            if (id <= 0) throw new ArgumentException("ID de percha no válido.");
            return new DPerchas().ObtenerPercha(id);
        }

        public static int GuardarPercha(EPercha percha)
        {
            if (percha == null) throw new ArgumentNullException(nameof(percha));
            if (string.IsNullOrWhiteSpace(percha.Nombre)) throw new ArgumentException("El nombre de la percha es obligatorio.");
            if (percha.Filas <= 0) throw new ArgumentException("El número de filas debe ser mayor que cero.");
            if (percha.Columnas <= 0) throw new ArgumentException("El número de columnas debe ser mayor que cero.");

            return new DPerchas().GuardarPercha(percha);
        }

        public static bool ActualizarPercha(EPercha percha)
        {
            if (percha == null) throw new ArgumentNullException(nameof(percha));
            if (percha.Id <= 0) throw new ArgumentException("ID de percha no válido.");
            if (string.IsNullOrWhiteSpace(percha.Nombre)) throw new ArgumentException("El nombre de la percha es obligatorio.");
            if (percha.Filas <= 0) throw new ArgumentException("El número de filas debe ser mayor que cero.");
            if (percha.Columnas <= 0) throw new ArgumentException("El número de columnas debe ser mayor que cero.");

            return new DPerchas().ActualizarPercha(percha);
        }

        public static bool EliminarPercha(int id)
        {
            if (id <= 0) throw new ArgumentException("ID de percha no válido.");
            return new DPerchas().EliminarPercha(id);
        }

        public static DataTable ListarSecciones()
        {
            return new DPerchas().ListarSecciones();
        }

        public static DataTable ObtenerProductosEnPercha(int perchaId)
        {
            if (perchaId <= 0) throw new ArgumentException("ID de percha no válido.");
            return new DPerchas().ObtenerProductosEnPercha(perchaId);
        }

        public static bool ExisteNombrePercha(string nombre, int? idExcluir = null)
        {
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre no puede estar vacío.");
            return new DPerchas().ExisteNombrePercha(nombre, idExcluir);
        }

        public static bool AsignarProductoPercha(EUbicacionProducto ubicacion)
        {
            if (ubicacion == null) throw new ArgumentNullException(nameof(ubicacion));
            if (ubicacion.PerchaId <= 0) throw new ArgumentException("ID de percha no válido.");
            if (ubicacion.ProductoId <= 0) throw new ArgumentException("ID de producto no válido.");
            if (ubicacion.Fila <= 0) throw new ArgumentException("La fila debe ser mayor que cero.");
            if (ubicacion.Columna <= 0) throw new ArgumentException("La columna debe ser mayor que cero.");

            return new DPerchas().AsignarProductoPercha(ubicacion);
        }

        public static bool RemoverProductoPercha(int perchaId, int productoId)
        {
            if (perchaId <= 0) throw new ArgumentException("ID de percha no válido.");
            if (productoId <= 0) throw new ArgumentException("ID de producto no válido.");

            return new DPerchas().RemoverProductoPercha(perchaId, productoId);
        }

        public static DataTable BuscarProductosDisponibles(string busqueda)
        {
            if (busqueda == null) busqueda = string.Empty;
            return new DPerchas().BuscarProductosDisponibles(busqueda);
        }

        public static DataTable ObtenerMapaPercha(int perchaId)
        {
            if (perchaId <= 0) throw new ArgumentException("ID de percha no válido.");
            return new DPerchas().ObtenerMapaPercha(perchaId);
        }
    }
}
