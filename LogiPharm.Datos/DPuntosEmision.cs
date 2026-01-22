using LogiPharm.Entidades;
using MySqlConnector;
using System;
using System.Data;

namespace LogiPharm.Datos
{
    public class DPuntosEmision
    {
        public DataTable ListarActivosConEstablecimiento()
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            using (var da = new MySqlDataAdapter(@"SELECT p.*, e.codigo as cod_est, e.nombre_comercial as est_nombre
FROM puntos_emision p
JOIN establecimientos e ON p.id_establecimiento = e.id
WHERE p.activo = 1
ORDER BY e.codigo, p.codigo", cn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public int ObtenerSecuencialFactura(int idPuntoEmision)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            using (var cmd = new MySqlCommand(@"SELECT COALESCE(secuencial_factura, 0)
FROM puntos_emision
WHERE id = @id", cn))
            {
                cmd.Parameters.AddWithValue("@id", idPuntoEmision);
                cn.Open();
                var v = cmd.ExecuteScalar();
                if (v == null || v == DBNull.Value) return 0;
                return Convert.ToInt32(v);
            }
        }

        public DataTable ListarPorEstablecimiento(int idEstablecimiento)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            using (var cmd = new MySqlCommand(@"SELECT pe.id,
       pe.id_establecimiento,
       pe.codigo,
       pe.descripcion,
       pe.id_usuario_responsable,
       pe.activo,
       pe.secuencial_factura,
       pe.secuencial_nota_credito,
       pe.secuencial_nota_debito,
       pe.secuencial_guia_remision,
       pe.secuencial_retencion,
       pe.creado_en,
       u.nombreUsuario AS usuario_responsable
FROM puntos_emision pe
LEFT JOIN usuarios u ON u.id = pe.id_usuario_responsable
WHERE pe.id_establecimiento = @id
ORDER BY pe.codigo", cn))
            using (var da = new MySqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@id", idEstablecimiento);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public int Insertar(EPuntoEmision p)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            using (var cmd = new MySqlCommand(@"INSERT INTO puntos_emision
(id_establecimiento, codigo, descripcion, id_usuario_responsable, activo,
 secuencial_factura, secuencial_nota_credito, secuencial_nota_debito,
 secuencial_guia_remision, secuencial_retencion)
VALUES
(@idEst, @codigo, @desc, @usr, @activo,
 @sf, @snc, @snd, @sgr, @sr);
SELECT LAST_INSERT_ID();", cn))
            {
                cmd.Parameters.AddWithValue("@idEst", p.IdEstablecimiento);
                cmd.Parameters.AddWithValue("@codigo", p.Codigo);
                cmd.Parameters.AddWithValue("@desc", (object)p.Descripcion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@usr", (object)p.IdUsuarioResponsable ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@activo", p.Activo ? 1 : 0);

                cmd.Parameters.AddWithValue("@sf", p.SecuencialFactura);
                cmd.Parameters.AddWithValue("@snc", p.SecuencialNotaCredito);
                cmd.Parameters.AddWithValue("@snd", p.SecuencialNotaDebito);
                cmd.Parameters.AddWithValue("@sgr", p.SecuencialGuiaRemision);
                cmd.Parameters.AddWithValue("@sr", p.SecuencialRetencion);

                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void Actualizar(EPuntoEmision p)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            using (var cmd = new MySqlCommand(@"UPDATE puntos_emision
SET codigo=@codigo,
    descripcion=@desc,
    id_usuario_responsable=@usr,
    activo=@activo,
    secuencial_factura=@sf,
    secuencial_nota_credito=@snc,
    secuencial_nota_debito=@snd,
    secuencial_guia_remision=@sgr,
    secuencial_retencion=@sr
WHERE id=@id", cn))
            {
                cmd.Parameters.AddWithValue("@id", p.Id);
                cmd.Parameters.AddWithValue("@codigo", p.Codigo);
                cmd.Parameters.AddWithValue("@desc", (object)p.Descripcion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@usr", (object)p.IdUsuarioResponsable ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@activo", p.Activo ? 1 : 0);

                cmd.Parameters.AddWithValue("@sf", p.SecuencialFactura);
                cmd.Parameters.AddWithValue("@snc", p.SecuencialNotaCredito);
                cmd.Parameters.AddWithValue("@snd", p.SecuencialNotaDebito);
                cmd.Parameters.AddWithValue("@sgr", p.SecuencialGuiaRemision);
                cmd.Parameters.AddWithValue("@sr", p.SecuencialRetencion);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            using (var cmd = new MySqlCommand("DELETE FROM puntos_emision WHERE id=@id", cn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
