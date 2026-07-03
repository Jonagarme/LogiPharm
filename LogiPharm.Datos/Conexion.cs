using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CapaDatos
{
    public class Conexion
    {
        public static string cadena = ConfigurationManager.ConnectionStrings["cadena_conexion"].ToString();
        public static int IdEmpresa { get; set; } = 1;

        public static void InicializarBaseDatos()
        {
            using (var cn = new MySqlConnector.MySqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    
                    // 1. Crear tabla principios_activos
                    string sqlPrincipios = @"
                        CREATE TABLE IF NOT EXISTS `principios_activos` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `nombre` varchar(150) NOT NULL,
                          `descripcion` text DEFAULT NULL,
                          `activo` tinyint(1) DEFAULT '1',
                          `anulado` tinyint(1) DEFAULT '0',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;";
                    using (var cmd = new MySqlConnector.MySqlCommand(sqlPrincipios, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Crear tabla presentaciones
                    string sqlPresentaciones = @"
                        CREATE TABLE IF NOT EXISTS `presentaciones` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `nombre` varchar(100) NOT NULL,
                          `descripcion` text DEFAULT NULL,
                          `activo` tinyint(1) DEFAULT '1',
                          `anulado` tinyint(1) DEFAULT '0',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;";
                    using (var cmd = new MySqlConnector.MySqlCommand(sqlPresentaciones, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // 3. Agregar columnas a productos si no existen
                    bool tienePrincipio = false;
                    bool tienePresentacion = false;
                    
                    string sqlCheckCols = @"
                        SELECT COLUMN_NAME 
                        FROM INFORMATION_SCHEMA.COLUMNS 
                        WHERE TABLE_SCHEMA = DATABASE() 
                          AND TABLE_NAME = 'productos' 
                          AND COLUMN_NAME IN ('idPrincipioActivo', 'idPresentacion');";
                    using (var cmd = new MySqlConnector.MySqlCommand(sqlCheckCols, cn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string colName = reader.GetString(0);
                                if (colName.Equals("idPrincipioActivo", StringComparison.OrdinalIgnoreCase))
                                    tienePrincipio = true;
                                if (colName.Equals("idPresentacion", StringComparison.OrdinalIgnoreCase))
                                    tienePresentacion = true;
                            }
                        }
                    }

                    if (!tienePrincipio)
                    {
                        string sqlAddPrincipio = "ALTER TABLE `productos` ADD COLUMN `idPrincipioActivo` int DEFAULT NULL;";
                        using (var cmd = new MySqlConnector.MySqlCommand(sqlAddPrincipio, cn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    if (!tienePresentacion)
                    {
                        string sqlAddPresentacion = "ALTER TABLE `productos` ADD COLUMN `idPresentacion` int DEFAULT NULL;";
                        using (var cmd = new MySqlConnector.MySqlCommand(sqlAddPresentacion, cn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error al inicializar base de datos: " + ex.Message);
                }
            }
        }
    }
}

