// DKardex.cs
using CapaDatos;
using MySqlConnector;
using System;
using System.Data;

namespace LogiPharm.Datos
{
    public class DKardex
    {
        public DataTable ObtenerMovimientos(int idProducto, DateTime fechaInicio, DateTime fechaFin)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                string sql = @"
                    SELECT
                        fecha   AS Fecha,
                        tipoMovimiento AS TipoMovimiento,
                        detalle AS Detalle,
                        ingreso AS Ingreso,
                        egreso  AS Egreso,
                        saldo   AS Saldo
                    FROM kardex_movimientos
                    WHERE idProducto = @idProducto
                      AND fecha >= @inicio
                      AND fecha <  @finMasUnDia
                    ORDER BY fecha ASC;";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    // rango [00:00:00 de inicio, 00:00:00 del día siguiente a fin)
                    var inicio = fechaInicio.Date;
                    var finMasUno = fechaFin.Date.AddDays(1);

                    cmd.Parameters.Add("@idProducto", MySqlDbType.Int32).Value = idProducto;
                    cmd.Parameters.Add("@inicio", MySqlDbType.DateTime).Value = inicio;
                    cmd.Parameters.Add("@finMasUnDia", MySqlDbType.DateTime).Value = finMasUno;

                    var dt = new DataTable();
                    using (var da = new MySqlDataAdapter(cmd))
                        da.Fill(dt);

                    return dt;
                }
            }
        }
    }
}
