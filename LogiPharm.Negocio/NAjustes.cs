using LogiPharm.Datos;
using LogiPharm.Entidades;
using System;

namespace LogiPharm.Negocio
{
    public static class NAjustes
    {
        public static bool GuardarAjuste(EAjuste ajuste)
        {
            // Validaciones de negocio
            if (ajuste == null)
                throw new ArgumentNullException(nameof(ajuste));

            if (ajuste.Detalles == null || ajuste.Detalles.Count == 0)
                throw new Exception("El ajuste debe contener al menos un detalle.");

            if (ajuste.IdUbicacion <= 0)
                throw new Exception("Debe seleccionar una bodega o ubicación.");

            if (string.IsNullOrEmpty(ajuste.TipoAjuste))
                throw new Exception("Debe seleccionar el tipo de ajuste.");

            foreach (var det in ajuste.Detalles)
            {
                if (det.IdProducto <= 0)
                    throw new Exception("Uno de los productos especificados en el detalle no es válido.");
                if (det.Cantidad < 0)
                    throw new Exception("La cantidad del producto ajustado no puede ser negativa.");
                if (det.Costo < 0)
                    throw new Exception("El costo del producto no puede ser negativo.");
            }

            return new DAjustes().GuardarAjuste(ajuste);
        }
    }
}
