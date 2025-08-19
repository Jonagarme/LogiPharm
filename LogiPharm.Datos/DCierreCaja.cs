using MySqlConnector;
using System;
using System.Data;
using LogiPharm.Presentacion.Utilidades; // Asegúrate de tener tu clase SesionActual aquí

namespace LogiPharm.Datos
{
    public class DCierreCaja
    {
        //✅ VERIFICA EN 'cierres_caja' USANDO 'estado'
        public bool VerificarCajaAbiertaHoy(int idCaja)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string sql = @"SELECT COUNT(*) 
                               FROM cierres_caja 
                               WHERE DATE(fechaApertura) = CURDATE() 
                                 AND estado = 'ABIERTA' 
                                 AND idCaja = @idCaja";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idCaja", idCaja);
                    cn.Open();
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        //✅ BUSCA LA APERTURA ACTIVA EN 'cierres_caja'
        // En DCierreCaja.cs
        public DataRow ObtenerDatosAperturaAbierta(int idCaja) // Cambiado a int
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                // La consulta ya esperaba un INT para idCaja, así que está perfecta.
                string sql = @"SELECT * FROM cierres_caja
                       WHERE estado = 'ABIERTA' AND idCaja = @idCaja
                       ORDER BY fechaApertura DESC LIMIT 1;";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idCaja", idCaja); // Ahora el tipo coincide
                    var dt = new DataTable();
                    new MySqlDataAdapter(cmd).Fill(dt);
                    return dt.Rows.Count > 0 ? dt.Rows[0] : null;
                }
            }
        }

        //✅ INSERTA UNA NUEVA APERTURA EN 'cierres_caja'
        public void RegistrarApertura(decimal montoInicial, int idUsuario, int idCaja)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string sql = @"INSERT INTO cierres_caja 
                               (idCaja, idUsuarioApertura, fechaApertura, saldoInicial, estado, creadoPor, creadoDate) 
                               VALUES 
                               (@idCaja, @idUsuario, NOW(), @saldoInicial, 'ABIERTA', @idUsuario, NOW())";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idCaja", idCaja);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@saldoInicial", montoInicial);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //✅ ESTE MÉTODO OBTIENE EL TOTAL DE VENTAS PARA UN CIERRE ESPECÍFICO
        public decimal ObtenerTotalVentas(int idCierreCaja)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string sql = @"SELECT IFNULL(SUM(total), 0) 
                               FROM facturas_venta 
                               WHERE idCierreCaja = @idCierreCaja AND anulado = 0"; // Usamos 'anulado' de tu tabla
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idCierreCaja", idCierreCaja);
                    cn.Open();
                    object resultado = cmd.ExecuteScalar();
                    return Convert.ToDecimal(resultado ?? 0);
                }
            }
        }

        //✅ ESTE MÉTODO ACTUALIZA EL REGISTRO PARA CERRAR LA CAJA
        public void CerrarCaja(int idCierre, decimal totalContado, decimal saldoTeorico, decimal diferencia, int idUsuarioCierre)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                string sql = @"UPDATE cierres_caja SET
                                fechaCierre = NOW(),
                                totalContadoFisico = @totalContado,
                                saldoTeoricoSistema = @saldoTeorico,
                                diferencia = @diferencia,
                                idUsuarioCierre = @idUsuarioCierre,
                                estado = 'CERRADA',
                                editadoPor = @idUsuarioCierre,
                                editadoDate = NOW()
                               WHERE id = @idCierre";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idCierre", idCierre);
                    cmd.Parameters.AddWithValue("@totalContado", totalContado);
                    cmd.Parameters.AddWithValue("@saldoTeorico", saldoTeorico);
                    cmd.Parameters.AddWithValue("@diferencia", diferencia);
                    cmd.Parameters.AddWithValue("@idUsuarioCierre", idUsuarioCierre);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}