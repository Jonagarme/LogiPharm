using System.Data.SqlClient;
using LogiPharm.Entidades;
using System.Configuration;
using System;

namespace LogiPharm.Datos
{
    public class DUsuario
    {
        public EUsuario Login(string usuario, string clave)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena_conexion"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios WHERE Usuario = @usuario AND Clave = @clave", cn);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@clave", clave);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return new EUsuario
                    {
                        IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                        Usuario = dr["Usuario"].ToString(),
                        Clave = dr["Clave"].ToString(),
                        Rol = dr["Rol"].ToString(),
                        NombreCompleto = dr["NombreCompleto"].ToString()
                    };
                }
                return null;
            }
        }
    }
}
