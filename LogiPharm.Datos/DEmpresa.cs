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
                string sql = "SELECT * FROM empresas WHERE id = 1 LIMIT 1;";
                using (var cmd = new MySqlCommand(sql, cn))
                {
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
                                ContribuyenteEspecial = reader["contribuyente_especial"].ToString(),
                                ObligadoContabilidad = Convert.ToBoolean(reader["obligado_contabilidad"]),
                                Telefono = reader["telefono"].ToString(),
                                Email = reader["email"].ToString(),
                                Logo = reader["logo"] as byte[]
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
                                   (ruc, razon_social, nombre_comercial, direccion_matriz, contribuyente_especial, obligado_contabilidad, telefono, email, logo) 
                                   VALUES 
                                   (@ruc, @razonSocial, @nombreComercial, @direccionMatriz, @contribuyenteEspecial, @obligadoContabilidad, @telefono, @email, @logo)";
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
                                   logo = @logo
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
                        cmd.Parameters.AddWithValue("@id", empresa.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}