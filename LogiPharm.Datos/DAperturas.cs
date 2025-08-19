using CapaDatos;
using MySqlConnector;
using System;
using System.Data;

namespace LogiPharm.Datos
{
    public class DAperturas
    {
        public bool VerificarCajaAbiertaHoy(string caja)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                // ✅ CAMBIO: Se reemplazó GETDATE() por CURDATE() para MySQL
                string sql = @"SELECT COUNT(*) 
                               FROM AperturasCaja 
                               WHERE DATE(FechaApertura) = CURDATE() 
                                 AND FechaCierre IS NULL 
                                 AND Caja = @Caja";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Caja", caja);
                    cn.Open();
                    // Usamos Convert.ToInt64 porque COUNT(*) en MySQL devuelve un long
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public void RegistrarApertura(decimal montoInicial, string usuario, string caja)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                // ✅ CAMBIO: Se reemplazó GETDATE() por NOW() para MySQL
                string sql = @"INSERT INTO AperturasCaja 
                               (FechaApertura, MontoInicial, UsuarioApertura, Caja) 
                               VALUES 
                               (NOW(), @MontoInicial, @Usuario, @Caja)";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@MontoInicial", montoInicial);
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Caja", caja);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}