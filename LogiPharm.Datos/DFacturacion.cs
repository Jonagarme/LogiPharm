using CapaDatos;
using LogiPharm.Entidades;
using MySqlConnector;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;

namespace LogiPharm.Datos
{
    public class DFacturacion
    {
        // Método para listar las facturas desde tu base de datos
        public DataTable ListarFacturas(DateTime fechaInicio, DateTime fechaFin, string textoBusqueda)
        {
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                string sql = @"
                SELECT 
                    fv.id AS Id,
                    fv.numeroFactura AS Factura,         -- << AÑADIDO
                    fv.numeroAutorizacion AS Autorizacion,
                    c.nombres AS Cliente,
                    fv.total AS Total,
                    fv.estado AS Estado,
                    fv.numeroAutorizacion AS ClaveAcceso
                FROM facturas_venta fv
                JOIN clientes c ON fv.idCliente = c.id
                WHERE 
                    DATE(fv.fechaEmision) BETWEEN @fechaInicio AND @fechaFin
                    AND (c.nombres LIKE @busqueda 
                         OR fv.numeroFactura LIKE @busqueda 
                         OR fv.numeroAutorizacion LIKE @busqueda)
                ORDER BY fv.fechaEmision DESC;";

                using (var cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio.Date);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin.Date);
                    cmd.Parameters.AddWithValue("@busqueda", $"%{textoBusqueda}%");

                    var dt = new DataTable();
                    new MySqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }


        // ✨ NUEVO MÉTODO: Llama a tu API para obtener el detalle de una factura
        public async Task<RespuestaConsultaApi> ObtenerDetalleDesdeApi(string claveAcceso)
        {
            if (string.IsNullOrEmpty(claveAcceso))
            {
                throw new ArgumentException("La clave de acceso no puede estar vacía.");
            }

            string apiUrl = $"http://127.0.0.1:5001/api/consulta_sri/{claveAcceso}";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(apiUrl);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al consultar la API: {response.ReasonPhrase}\n{jsonResponse}");
                }

                return JsonConvert.DeserializeObject<RespuestaConsultaApi>(jsonResponse);
            }
        }
    }
}