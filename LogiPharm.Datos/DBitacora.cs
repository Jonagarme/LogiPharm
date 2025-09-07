using System;
using System.Data;
using MySqlConnector;

namespace LogiPharm.Datos
{
    public class DBitacora
    {
        public DataTable ConsultarBitacora(DateTime fechaInicio, DateTime fechaFin, string usuario, string accion)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            using (var cmd = new MySqlCommand("sp_consultar_auditoria", cn))
            using (var da = new MySqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Normalizar filtros (coinciden con el SP)
                string usr = string.IsNullOrWhiteSpace(usuario) || usuario == "[TODOS]" ? "TODOS" : usuario;
                string acc = string.IsNullOrWhiteSpace(accion) || accion.ToUpper() == "TODAS" ? "TODAS" : accion;

                cmd.Parameters.AddWithValue("@pFechaDesde", fechaInicio);
                cmd.Parameters.AddWithValue("@pFechaHasta", fechaFin);
                cmd.Parameters.AddWithValue("@pUsuario", usr);
                cmd.Parameters.AddWithValue("@pAccion", acc);

                var tabla = new DataTable();
                cn.Open();
                da.Fill(tabla);
                return tabla;
            }
        }

        public DataTable ListarUsuariosParaFiltro()
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            using (var cmd = new MySqlCommand("sp_listar_usuarios_auditoria", cn))
            using (var da = new MySqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var tabla = new DataTable();
                cn.Open();
                da.Fill(tabla);

                // Insertar opción [TODOS] al inicio
                var fila = tabla.NewRow();
                fila["id"] = 0;
                fila["nombreUsuario"] = "[TODOS]";
                tabla.Rows.InsertAt(fila, 0);
                return tabla;
            }
        }

        // Opcional: Registrar un evento en auditoría
        public void Registrar(int idUsuario, string usuario, string modulo, string accion, string entidad = null, long? idEntidad = null, string descripcion = null, string ip = null, string host = null, string origen = "UI", string extra = null)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            using (var cmd = new MySqlCommand("sp_registrar_auditoria", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pIdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@pUsuario", usuario ?? string.Empty);
                cmd.Parameters.AddWithValue("@pModulo", modulo ?? string.Empty);
                cmd.Parameters.AddWithValue("@pAccion", accion ?? string.Empty);
                cmd.Parameters.AddWithValue("@pEntidad", (object)entidad ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@pIdEntidad", (object)idEntidad ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@pDescripcion", (object)descripcion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@pIp", (object)ip ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@pHost", (object)host ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@pOrigen", (object)origen ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@pExtra", (object)extra ?? DBNull.Value);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
