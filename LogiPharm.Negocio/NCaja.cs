using System;
using System.Collections.Generic;
using System.Data;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Negocio
{
    public static class NCaja
    {
        public static List<ECaja> ObtenerTodas(bool incluirAnuladas = false)
        {
            return new DCaja().ObtenerTodas(incluirAnuladas);
        }

        public static ECaja ObtenerPorId(int id)
        {
            return new DCaja().ObtenerPorId(id);
        }

        public static List<ECaja> ObtenerActivas()
        {
            return new DCaja().ObtenerActivas();
        }

        public static bool Insertar(ECaja caja)
        {
            if (string.IsNullOrWhiteSpace(caja.Codigo))
                throw new ArgumentException("El código de la caja es obligatorio.");
            if (string.IsNullOrWhiteSpace(caja.Nombre))
                throw new ArgumentException("El nombre de la caja es obligatorio.");
            if (ExisteCodigo(caja.Codigo))
                throw new ArgumentException("El código de caja ya existe en el sistema.");

            return new DCaja().Insertar(caja);
        }

        public static bool Actualizar(ECaja caja)
        {
            if (caja.Id <= 0)
                throw new ArgumentException("ID de caja inválido.");
            if (string.IsNullOrWhiteSpace(caja.Codigo))
                throw new ArgumentException("El código de la caja es obligatorio.");
            if (string.IsNullOrWhiteSpace(caja.Nombre))
                throw new ArgumentException("El nombre de la caja es obligatorio.");
            if (ExisteCodigo(caja.Codigo, caja.Id))
                throw new ArgumentException("El código de caja ya existe en otra caja registrada.");

            return new DCaja().Actualizar(caja);
        }

        public static bool Anular(int id, int usuarioId)
        {
            return new DCaja().Anular(id, usuarioId);
        }

        public static bool CambiarEstadoActiva(int id, bool activa, int usuarioId)
        {
            return new DCaja().CambiarEstadoActiva(id, activa, usuarioId);
        }

        public static bool ExisteCodigo(string codigo, int? idExcluir = null)
        {
            return new DCaja().ExisteCodigo(codigo, idExcluir);
        }

        public static Dictionary<string, object> ObtenerEstadisticas(int idCaja, DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            return new DCaja().ObtenerEstadisticas(idCaja, fechaInicio, fechaFin);
        }

        public static DataTable ObtenerParaListado(bool incluirAnuladas = false)
        {
            return new DCaja().ObtenerParaListado(incluirAnuladas);
        }
    }
}
