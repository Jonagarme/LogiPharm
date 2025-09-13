using MySqlConnector;
using System;
using LogiPharm.Entidades;

namespace LogiPharm.Datos
{
    public class DLabResultadoDetalles
    {
        public void Insertar(ELabResultadoDetalle d)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                var sql = @"INSERT INTO lab_resultado_detalles (resultado_id, parametro_nombre, valor, unidad, rango_referencia, fuera_de_rango)
                             VALUES (@res, @par, @val, @uni, @ref, @out)";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@res", d.ResultadoId);
                    cmd.Parameters.AddWithValue("@par", d.ParametroNombre);
                    cmd.Parameters.AddWithValue("@val", d.Valor);
                    cmd.Parameters.AddWithValue("@uni", (object)d.Unidad ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ref", (object)d.RangoReferencia ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@out", d.FueraDeRango);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
