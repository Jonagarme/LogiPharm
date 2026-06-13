using MySqlConnector;
using System;
using System.Data;
using LogiPharm.Entidades;
using CapaDatos;

namespace LogiPharm.Datos
{
    public class DEmpresa
    {
        public EEmpresa ObtenerDatosEmpresa()
        {
            EEmpresa empresa = null;
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                string sql = "SELECT * FROM empresas WHERE id = @id LIMIT 1;";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", Conexion.IdEmpresa);
                    cn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            empresa = new EEmpresa
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Ruc = reader["ruc"].ToString(),
                                RazonSocial = reader["razon_social"].ToString(),
                                NombreComercial = reader["nombre_comercial"].ToString(),
                                DireccionMatriz = reader["direccion_matriz"].ToString(),
                                ContribuyenteEspecial = reader["contribuyente_especial"]?.ToString(),
                                AmbienteSRI = reader["sri_ambiente"]?.ToString() ?? "Pruebas",
                                ObligadoContabilidad = Convert.ToBoolean(reader["obligado_contabilidad"]),
                                Telefono = reader["telefono"].ToString(),
                                Email = reader["email"].ToString(),
                                Logo = reader["logo"] as byte[],
                                CertificadoP12Path = reader["certificado_p12_path"]?.ToString(),
                                CertificadoPassword = reader["certificado_password"]?.ToString(),
                                CertificadoFechaExpiracion = reader["certificado_fecha_expiracion"] as DateTime?
                            };
                        }
                    }
                }
            }
            return empresa;
        }

        // ✅ MÉTODO MEJORADO: Ahora maneja INSERT y UPDATE
        public void GuardarDatosEmpresa(EEmpresa empresa)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                cn.Open();

                // Si el ID es 0, es un registro nuevo y debemos INSERTAR.
                if (empresa.Id == 0)
                {
                    // --- LÓGICA PARA INSERTAR (NUEVO) ---
                    string sql = @"INSERT INTO empresas 
                                   (ruc, razon_social, nombre_comercial, direccion_matriz, contribuyente_especial, obligado_contabilidad, telefono, email, logo, certificado_p12_path, certificado_password, certificado_fecha_expiracion, sri_ambiente) 
                                   VALUES 
                                   (@ruc, @razonSocial, @nombreComercial, @direccionMatriz, @contribuyenteEspecial, @obligadoContabilidad, @telefono, @email, @logo, @certificadoPath, @certificadoPassword, @certificadoFechaExpiracion, @ambienteSRI)";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@ruc", empresa.Ruc);
                        cmd.Parameters.AddWithValue("@razonSocial", empresa.RazonSocial);
                        cmd.Parameters.AddWithValue("@nombreComercial", empresa.NombreComercial);
                        cmd.Parameters.AddWithValue("@direccionMatriz", empresa.DireccionMatriz);
                        cmd.Parameters.AddWithValue("@contribuyenteEspecial", empresa.ContribuyenteEspecial);
                        cmd.Parameters.AddWithValue("@obligadoContabilidad", empresa.ObligadoContabilidad);
                        cmd.Parameters.AddWithValue("@telefono", empresa.Telefono);
                        cmd.Parameters.AddWithValue("@email", empresa.Email);
                        cmd.Parameters.AddWithValue("@logo", empresa.Logo);
                        cmd.Parameters.AddWithValue("@certificadoPath", empresa.CertificadoP12Path);
                        cmd.Parameters.AddWithValue("@certificadoPassword", empresa.CertificadoPassword);
                        cmd.Parameters.AddWithValue("@certificadoFechaExpiracion", empresa.CertificadoFechaExpiracion);
                        cmd.Parameters.AddWithValue("@ambienteSRI", empresa.AmbienteSRI ?? "Pruebas");
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    // --- LÓGICA PARA ACTUALIZAR (EXISTENTE) ---
                    string sql = @"UPDATE empresas SET
                                   ruc = @ruc,
                                   razon_social = @razonSocial,
                                   nombre_comercial = @nombreComercial,
                                   direccion_matriz = @direccionMatriz,
                                   contribuyente_especial = @contribuyenteEspecial,
                                   obligado_contabilidad = @obligadoContabilidad,
                                   telefono = @telefono,
                                   email = @email,
                                   logo = @logo,
                                   certificado_p12_path = @certificadoPath,
                                   certificado_password = @certificadoPassword,
                                   certificado_fecha_expiracion = @certificadoFechaExpiracion,
                                   sri_ambiente = @ambienteSRI
                                   WHERE id = @id";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@ruc", empresa.Ruc);
                        cmd.Parameters.AddWithValue("@razonSocial", empresa.RazonSocial);
                        cmd.Parameters.AddWithValue("@nombreComercial", empresa.NombreComercial);
                        cmd.Parameters.AddWithValue("@direccionMatriz", empresa.DireccionMatriz);
                        cmd.Parameters.AddWithValue("@contribuyenteEspecial", empresa.ContribuyenteEspecial);
                        cmd.Parameters.AddWithValue("@obligadoContabilidad", empresa.ObligadoContabilidad);
                        cmd.Parameters.AddWithValue("@telefono", empresa.Telefono);
                        cmd.Parameters.AddWithValue("@email", empresa.Email);
                        cmd.Parameters.AddWithValue("@logo", empresa.Logo);
                        cmd.Parameters.AddWithValue("@certificadoPath", empresa.CertificadoP12Path);
                        cmd.Parameters.AddWithValue("@certificadoPassword", empresa.CertificadoPassword);
                        cmd.Parameters.AddWithValue("@certificadoFechaExpiracion", empresa.CertificadoFechaExpiracion);
                        cmd.Parameters.AddWithValue("@ambienteSRI", empresa.AmbienteSRI ?? "Pruebas");
                        cmd.Parameters.AddWithValue("@id", empresa.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}