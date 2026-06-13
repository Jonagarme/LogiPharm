using System;
using System.Data;
using LogiPharm.Datos;

namespace LogiPharm.Negocio
{
    public static class NBitacora
    {
        public static DataTable ConsultarBitacora(DateTime fechaInicio, DateTime fechaFin, string usuario, string accion)
        {
            return new DBitacora().ConsultarBitacora(fechaInicio, fechaFin, usuario, accion);
        }

        public static DataTable ListarUsuariosParaFiltro()
        {
            return new DBitacora().ListarUsuariosParaFiltro();
        }

        public static void Registrar(int idUsuario, string usuario, string modulo, string accion, string entidad = null, long? idEntidad = null, string descripcion = null, string ip = null, string host = null, string origen = "UI", string extra = null)
        {
            try
            {
                new DBitacora().Registrar(idUsuario, usuario, modulo, accion, entidad, idEntidad, descripcion, ip, host, origen, extra);
            }
            catch
            {
                // Dejamos pasar errores de auditoría para no bloquear la aplicación principal
            }
        }
    }
}
