using System;
using System.Data;
using MySqlConnector;

namespace LogiPharm.Datos
{
    public class DBitacora
    {
        // Este método simula la obtención de los registros de la bitácora.
        // TODO: Reemplazar con una consulta SQL real a tu tabla de bitácora.
        public DataTable ConsultarBitacora(DateTime fechaInicio, DateTime fechaFin, string usuario, string accion)
        {
            DataTable tabla = new DataTable();

            // --- INICIO DE SIMULACIÓN CON DATOS DE PRUEBA ---
            tabla.Columns.Add("Fecha", typeof(DateTime));
            tabla.Columns.Add("Usuario", typeof(string));
            tabla.Columns.Add("Modulo", typeof(string));
            tabla.Columns.Add("Accion", typeof(string));
            tabla.Columns.Add("Detalle", typeof(string));

            // Añadir filas de ejemplo
            tabla.Rows.Add(DateTime.Now.AddHours(-5), "admin", "Seguridad", "INICIO DE SESIÓN", "Inicio de sesión exitoso.");
            tabla.Rows.Add(DateTime.Now.AddHours(-4), "cajero01", "Ventas", "CREACIÓN", "Se creó la factura de venta Nro. 001-001-12345.");
            tabla.Rows.Add(DateTime.Now.AddHours(-3), "admin", "Inventario", "MODIFICACIÓN", "Se actualizó el producto 'PARACETAMOL 500MG'. Stock anterior: 100, Stock nuevo: 98.");
            tabla.Rows.Add(DateTime.Now.AddHours(-2), "farmaceutico", "Compras", "CREACIÓN", "Se ingresó la factura de compra Nro. FC-2025-589 del proveedor DIFARE.");
            tabla.Rows.Add(DateTime.Now.AddHours(-1), "admin", "Seguridad", "ANULACIÓN", "Se anuló el rol 'Vendedor Nocturno'.");
            tabla.Rows.Add(DateTime.Now, "cajero01", "Caja", "CIERRE", "Se realizó el cierre de la CAJA001 con una diferencia de $1.50.");

            // Aquí iría la lógica de filtrado real en la consulta SQL
            // Por ahora, devolvemos todos los datos de prueba.

            return tabla;
        }

        // Método para obtener la lista de usuarios para el filtro
        public DataTable ListarUsuariosParaFiltro()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("id", typeof(int));
            tabla.Columns.Add("nombreUsuario", typeof(string));

            tabla.Rows.Add(0, "[TODOS]");
            tabla.Rows.Add(1, "admin");
            tabla.Rows.Add(2, "cajero01");
            tabla.Rows.Add(3, "farmaceutico");

            return tabla;
        }
    }
}
