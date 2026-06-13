using System;
using System.Data;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Negocio
{
    public static class NTransferencia
    {
        public static DataTable ListarTransferencias(string filtroEstado = "")
        {
            return new DTransferencias().ListarTransferencias(filtroEstado);
        }

        public static ETransferencia ObtenerPorId(long id)
        {
            if (id <= 0) throw new ArgumentException("ID de transferencia no válido.");
            return new DTransferencias().ObtenerPorId(id);
        }

        public static bool InsertarTransferencia(ETransferencia transferencia)
        {
            if (transferencia == null) throw new ArgumentNullException(nameof(transferencia));
            if (transferencia.IdUbicacionOrigen <= 0) throw new ArgumentException("Debe seleccionar una ubicación de origen válida.");
            if (transferencia.IdUbicacionDestino <= 0) throw new ArgumentException("Debe seleccionar una ubicación de destino válida.");
            if (transferencia.IdUbicacionOrigen == transferencia.IdUbicacionDestino) throw new ArgumentException("La ubicación de origen y destino no pueden ser iguales.");
            if (transferencia.Detalles == null || transferencia.Detalles.Count == 0) throw new ArgumentException("Debe incluir al menos un producto en la transferencia.");

            return new DTransferencias().InsertarTransferencia(transferencia);
        }

        public static bool RecibirTransferencia(long idTransferencia, int usuarioId)
        {
            if (idTransferencia <= 0) throw new ArgumentException("ID de transferencia no válido.");
            return new DTransferencias().RecibirTransferencia(idTransferencia, usuarioId);
        }

        public static bool AnularTransferencia(long idTransferencia, int usuarioId)
        {
            if (idTransferencia <= 0) throw new ArgumentException("ID de transferencia no válido.");
            return new DTransferencias().AnularTransferencia(idTransferencia, usuarioId);
        }

        public static DataTable ObtenerLotesDisponibles(long idProducto)
        {
            if (idProducto <= 0) throw new ArgumentException("ID de producto no válido.");
            return new DTransferencias().ObtenerLotesDisponibles(idProducto);
        }

        public static string GenerarNumeroTransferencia()
        {
            return new DTransferencias().GenerarNumeroTransferencia();
        }
    }
}
