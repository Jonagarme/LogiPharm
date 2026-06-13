using System.Data;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Negocio
{
    public static class NPuntoEmision
    {
        public static DataTable ListarActivosConEstablecimiento()
        {
            return new DPuntosEmision().ListarActivosConEstablecimiento();
        }

        public static int ObtenerSecuencialFactura(int idPuntoEmision)
        {
            return new DPuntosEmision().ObtenerSecuencialFactura(idPuntoEmision);
        }

        public static DataTable ListarPorEstablecimiento(int idEstablecimiento)
        {
            return new DPuntosEmision().ListarPorEstablecimiento(idEstablecimiento);
        }

        public static int Insertar(EPuntoEmision p)
        {
            if (p.IdEstablecimiento <= 0)
                throw new System.ArgumentException("El establecimiento asociado es obligatorio.");
            if (string.IsNullOrWhiteSpace(p.Codigo))
                throw new System.ArgumentException("El código del punto de emisión es obligatorio.");

            return new DPuntosEmision().Insertar(p);
        }

        public static void Actualizar(EPuntoEmision p)
        {
            if (p.Id <= 0)
                throw new System.ArgumentException("ID inválido para actualizar.");
            if (string.IsNullOrWhiteSpace(p.Codigo))
                throw new System.ArgumentException("El código del punto de emisión es obligatorio.");

            new DPuntosEmision().Actualizar(p);
        }

        public static void Eliminar(int id)
        {
            new DPuntosEmision().Eliminar(id);
        }
    }
}
