using System;
using LogiPharm.Datos;

namespace LogiPharm.Presentacion.Utilidades
{
    public static class ImpuestoProvider
    {
        private static decimal? _ivaCache;
        private static DateTime _lastRead;
        private static readonly TimeSpan CacheTtl = TimeSpan.FromMinutes(10);

        public static decimal GetIVA()
        {
            if (_ivaCache.HasValue && DateTime.Now - _lastRead < CacheTtl)
                return _ivaCache.Value;

            try
            {
                var d = new DImpuestos();
                var imp = d.ObtenerImpuestoVigente("IVA");
                _ivaCache = imp?.Porcentaje ?? 0.15m; // fallback 15%
                _lastRead = DateTime.Now;
                return _ivaCache.Value;
            }
            catch
            {
                return _ivaCache ?? 0.15m;
            }
        }

        public static void Invalidate()
        {
            _ivaCache = null;
        }
    }
}
