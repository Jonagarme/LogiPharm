using System;
using System.Collections.Generic;
using System.Data;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Negocio
{
    public static class NCierreCaja
    {
        public static DataRow ObtenerPrimeraCajaAbierta()
        {
            return new DCierreCaja().ObtenerPrimeraCajaAbierta();
        }

        public static bool VerificarCajaAbiertaHoy(int idCaja)
        {
            return new DCierreCaja().VerificarCajaAbiertaHoy(idCaja);
        }

        public static DataRow ObtenerDatosAperturaAbierta(int idCaja)
        {
            return new DCierreCaja().ObtenerDatosAperturaAbierta(idCaja);
        }

        public static void RegistrarApertura(decimal montoInicial, int idUsuario, int idCaja)
        {
            if (montoInicial < 0)
                throw new ArgumentException("El monto inicial no puede ser negativo.");
            if (idUsuario <= 0)
                throw new ArgumentException("ID de usuario de apertura inválido.");
            if (idCaja <= 0)
                throw new ArgumentException("ID de caja inválido.");

            new DCierreCaja().RegistrarApertura(montoInicial, idUsuario, idCaja);
        }

        public static decimal ObtenerTotalVentas(int idCierreCaja)
        {
            return new DCierreCaja().ObtenerTotalVentas(idCierreCaja);
        }

        public static decimal CalcularIngresosSistema(int idCierreCaja)
        {
            return new DCierreCaja().CalcularIngresosSistema(idCierreCaja);
        }

        public static decimal CalcularEgresosSistema(int idCierreCaja)
        {
            return new DCierreCaja().CalcularEgresosSistema(idCierreCaja);
        }

        public static void ActualizarTotalesSistema(int idCierreCaja)
        {
            new DCierreCaja().ActualizarTotalesSistema(idCierreCaja);
        }

        public static void CerrarCaja(int idCierre, decimal totalContado, decimal saldoTeorico, decimal diferencia, int idUsuarioCierre)
        {
            if (idCierre <= 0)
                throw new ArgumentException("ID de cierre inválido.");
            if (idUsuarioCierre <= 0)
                throw new ArgumentException("ID de usuario de cierre inválido.");

            new DCierreCaja().CerrarCaja(idCierre, totalContado, saldoTeorico, diferencia, idUsuarioCierre);
        }

        public static List<ECierreCaja> ObtenerCierresPorRango(DateTime fechaInicio, DateTime fechaFin, int? idCaja = null)
        {
            return new DCierreCaja().ObtenerCierresPorRango(fechaInicio, fechaFin, idCaja);
        }

        public static DataTable ObtenerResumenCierresMes(int año, int mes, int? idCaja = null)
        {
            return new DCierreCaja().ObtenerResumenCierresMes(año, mes, idCaja);
        }

        public static DataTable ObtenerResumenCierresAño(int año, int? idCaja = null)
        {
            return new DCierreCaja().ObtenerResumenCierresAño(año, idCaja);
        }

        public static ECierreCaja ObtenerCierrePorId(long idCierre)
        {
            return new DCierreCaja().ObtenerCierrePorId(idCierre);
        }

        public static Dictionary<string, decimal> ObtenerEstadisticasCaja(int? idCaja = null, DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            return new DCierreCaja().ObtenerEstadisticasCaja(idCaja, fechaInicio, fechaFin);
        }
    }
}
