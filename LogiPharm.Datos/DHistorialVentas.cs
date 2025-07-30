using System;
using System.Data;
using MySqlConnector;

namespace LogiPharm.Datos
{
    public class DHistorialVentas
    {
        public DataTable ConsultarHistorial(DateTime fechaInicio, DateTime fechaFin, int idCliente, string productoCriterio)
        {
            DataTable tabla = new DataTable();

            // --- INICIO DE SIMULACIÓN CON DATOS DE PRUEBA ---
            tabla.Columns.Add("Fecha", typeof(DateTime));
            tabla.Columns.Add("Factura", typeof(string));
            tabla.Columns.Add("Cliente", typeof(string));
            tabla.Columns.Add("Producto", typeof(string));
            tabla.Columns.Add("Cantidad", typeof(int));
            tabla.Columns.Add("Precio", typeof(decimal));
            tabla.Columns.Add("Total", typeof(decimal));

            // Datos de ejemplo
            tabla.Rows.Add(DateTime.Now.AddDays(-2), "001-001-12345", "CONSUMIDOR FINAL", "PARACETAMOL 500MG", 2, 1.50, 3.00);
            tabla.Rows.Add(DateTime.Now.AddDays(-1), "001-001-12346", "JONATHAN GARCIA", "VITAMINA C 500MG", 1, 5.00, 5.00);
            tabla.Rows.Add(DateTime.Now, "001-001-12347", "JONATHAN GARCIA", "PARACETAMOL 500MG", 3, 1.50, 4.50);
            tabla.Rows.Add(DateTime.Now, "001-001-12348", "MARIA PEREZ", "COMPLEJO B JARABE", 1, 8.20, 8.20);

            // Simulación de filtro (esto se haría en la consulta SQL real)
            string filtro = $"Fecha >= #{fechaInicio:MM/dd/yyyy}# AND Fecha <= #{fechaFin:MM/dd/yyyy}#";
            if (idCliente > 0)
            {
                // En un caso real, filtrarías por el ID del cliente en la consulta
                if (idCliente == 1) // Asumimos que JONATHAN GARCIA es el ID 1
                    filtro += " AND Cliente = 'JONATHAN GARCIA'";
            }
            if (!string.IsNullOrEmpty(productoCriterio))
            {
                filtro += $" AND Producto LIKE '%{productoCriterio}%'";
            }
            tabla.DefaultView.RowFilter = filtro;
            tabla = tabla.DefaultView.ToTable();
            // --- FIN DE SIMULACIÓN ---

            /*
            // EJEMPLO DE CÓDIGO REAL CON BASE DE DATOS:
            using (MySqlConnection cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                try
                {
                    cn.Open();
                    string query = @"
                        SELECT f.fechaEmision as Fecha, f.numero as Factura, c.razonSocial as Cliente, 
                               p.nombre as Producto, d.cantidad as Cantidad, d.precio as Precio, d.total as Total
                        FROM facturas f
                        JOIN clientes c ON f.idCliente = c.id
                        JOIN detalle_factura d ON f.id = d.idFactura
                        JOIN productos p ON d.idProducto = p.id
                        WHERE f.fechaEmision BETWEEN @fechaInicio AND @fechaFin
                          AND (@idCliente = 0 OR f.idCliente = @idCliente)
                          AND (p.nombre LIKE @producto OR p.codigoPrincipal LIKE @producto)
                        ORDER BY f.fechaEmision DESC;";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio.Date);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin.Date.AddDays(1).AddSeconds(-1)); // Incluir todo el día
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    cmd.Parameters.AddWithValue("@producto", "%" + productoCriterio + "%");
                    
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al consultar el historial de ventas: " + ex.Message);
                }
            }
            */
            return tabla;
        }
    }
}
