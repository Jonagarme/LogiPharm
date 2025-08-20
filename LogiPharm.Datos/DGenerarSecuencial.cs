using MySqlConnector;
using System;

namespace LogiPharm.Datos
{
    public class DGenerarSecuancial
    {
        public string ObtenerSiguienteSecuencial(string establecimiento, string puntoEmision)
        {
            int nuevoNumero = 0;

            // Se sigue la estructura de conexión que proporcionaste
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();

                // Es CRUCIAL usar una transacción para esta operación.
                // Esto asegura que nadie más pueda tomar el mismo número al mismo tiempo.
                using (var transaction = cn.BeginTransaction())
                {
                    try
                    {
                        // 1. OBTENER Y BLOQUEAR EL NÚMERO ACTUAL
                        // ✅ CAMBIO: Se usa 'FOR UPDATE' al final para bloquear la fila en MySQL
                        string selectQuery = @"SELECT UltimoNumero 
                                       FROM Talonario 
                                       WHERE Establecimiento = @Establecimiento 
                                       AND PuntoEmision = @PuntoEmision 
                                       FOR UPDATE";

                        int ultimoNumero;
                        using (var cmdSelect = new MySqlCommand(selectQuery, cn, transaction))
                        {
                            cmdSelect.Parameters.AddWithValue("@Establecimiento", establecimiento);
                            cmdSelect.Parameters.AddWithValue("@PuntoEmision", puntoEmision);

                            var result = cmdSelect.ExecuteScalar();
                            if (result == null || result is DBNull)
                            {
                                // Si no se encuentra, se hace rollback y se lanza error.
                                transaction.Rollback();
                                throw new Exception($"No se encontró un talonario configurado para {establecimiento}-{puntoEmision}.");
                            }
                            ultimoNumero = Convert.ToInt32(result);
                        }

                        nuevoNumero = ultimoNumero + 1;

                        // 2. ACTUALIZAR EL NÚMERO EN LA BASE DE DATOS
                        string updateQuery = @"UPDATE Talonario 
                                       SET UltimoNumero = @NuevoNumero 
                                       WHERE Establecimiento = @Establecimiento 
                                       AND PuntoEmision = @PuntoEmision";

                        using (var cmdUpdate = new MySqlCommand(updateQuery, cn, transaction))
                        {
                            cmdUpdate.Parameters.AddWithValue("@NuevoNumero", nuevoNumero);
                            cmdUpdate.Parameters.AddWithValue("@Establecimiento", establecimiento);
                            cmdUpdate.Parameters.AddWithValue("@PuntoEmision", puntoEmision);
                            cmdUpdate.ExecuteNonQuery();
                        }

                        // 3. CONFIRMAR LA TRANSACCIÓN
                        // Si todo fue exitoso, se guardan los cambios.
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Si algo falla, se revierten todos los cambios.
                        transaction.Rollback();
                        throw new Exception("Error al generar el secuencial de la factura.", ex);
                    }
                } // La conexión se cierra automáticamente al salir del bloque 'using'
            }

            // Se formatea el número secuencial según el estándar
            return $"{establecimiento}-{puntoEmision}-{nuevoNumero.ToString("D9")}";
        }

    }
}
