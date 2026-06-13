using System;
using System.Data;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Negocio
{
    public static class NProveedores
    {
        public static DataTable ListarProveedores(string criterio)
        {
            if (criterio == null) criterio = string.Empty;
            return new DProveedores().ListarProveedores(criterio);
        }

        public static bool InsertarProveedor(EProveedor proveedor)
        {
            if (proveedor == null) throw new ArgumentNullException(nameof(proveedor));
            if (string.IsNullOrWhiteSpace(proveedor.Ruc)) throw new ArgumentException("El RUC del proveedor es obligatorio.");
            if (string.IsNullOrWhiteSpace(proveedor.RazonSocial)) throw new ArgumentException("La razón social del proveedor es obligatoria.");

            return new DProveedores().InsertarProveedor(proveedor);
        }

        public static bool ActualizarProveedor(EProveedor proveedor)
        {
            if (proveedor == null) throw new ArgumentNullException(nameof(proveedor));
            if (proveedor.Id <= 0) throw new ArgumentException("ID de proveedor no válido.");
            if (string.IsNullOrWhiteSpace(proveedor.Ruc)) throw new ArgumentException("El RUC del proveedor es obligatorio.");
            if (string.IsNullOrWhiteSpace(proveedor.RazonSocial)) throw new ArgumentException("La razón social del proveedor es obligatoria.");

            return new DProveedores().ActualizarProveedor(proveedor);
        }

        public static DataTable ListarProveedoresActivos()
        {
            return new DProveedores().ListarProveedoresActivos();
        }
    }
}
