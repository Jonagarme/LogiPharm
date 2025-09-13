using MySqlConnector;
using System;
using System.Data;
using LogiPharm.Entidades;

namespace LogiPharm.Datos
{
    public class DLabResultados
    {
        public int Insertar(ELabResultado r)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                var sql = @"INSERT INTO lab_resultados (proceso_id, fecha_emision, paciente_nombre, paciente_id, medico_solicitante, observaciones)
                             VALUES (@proc, @fecha, @pac, @pid, @med, @obs);
                             SELECT LAST_INSERT_ID();";
                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@proc", r.ProcesoId);
                    cmd.Parameters.AddWithValue("@fecha", r.FechaEmision);
                    cmd.Parameters.AddWithValue("@pac", r.PacienteNombre);
                    cmd.Parameters.AddWithValue("@pid", (object)r.PacienteId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@med", (object)r.MedicoSolicitante ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@obs", (object)r.Observaciones ?? DBNull.Value);
                    var id = Convert.ToInt32(cmd.ExecuteScalar());
                    return id;
                }
            }
        }
    }
}
