using MySqlConnector;
using System;
using System.Data;

namespace LogiPharm.Datos
{
    public class DFacturacion
    {
        // Método para listar las facturas según los filtros
        public DataTable ListarFacturas(DateTime fechaInicio, DateTime fechaFin)
        {
            // Por ahora, este método devuelve datos de ejemplo.
            // TODO: Reemplazar con una consulta real a tu tabla de facturas.
            DataTable tabla = new DataTable();
            tabla.Columns.Add("No.Doc", typeof(int));
            tabla.Columns.Add("Preimpreso", typeof(string));
            tabla.Columns.Add("Check", typeof(bool));
            tabla.Columns.Add("Ride", typeof(string)); // Podría ser un booleano o un string con la URL

            // Añadir filas de ejemplo
            tabla.Rows.Add(804, "002011000000487", false, "PDF");
            tabla.Rows.Add(803, "002011000000486", true, "PDF");
            tabla.Rows.Add(802, "002011000000485", false, "PDF");
            tabla.Rows.Add(801, "002011000000484", false, "PDF");

            return tabla;
        }

        // Método para obtener el detalle completo de UNA factura
        public DataSet ObtenerDetalleFactura(int idDocumento)
        {
            // Este método devuelve un DataSet con dos tablas:
            // 1. Info de la factura (para los campos de texto)
            // 2. Detalle de productos (para la grilla anidada)

            DataSet ds = new DataSet();

            // --- Tabla 1: Datos de la Factura ---
            DataTable tblFactura = new DataTable("FacturaInfo");
            tblFactura.Columns.Add("NumeroFactura", typeof(string));
            tblFactura.Columns.Add("NoInterno", typeof(string));
            tblFactura.Columns.Add("FechaAutorizacion", typeof(string));
            tblFactura.Columns.Add("SriEstado", typeof(string));
            tblFactura.Columns.Add("Cedula", typeof(string));
            tblFactura.Columns.Add("Cliente", typeof(string));
            tblFactura.Columns.Add("Telefono", typeof(string));
            tblFactura.Columns.Add("Direccion", typeof(string));
            tblFactura.Columns.Add("Fecha", typeof(string));
            tblFactura.Columns.Add("Ambiente", typeof(string));
            tblFactura.Columns.Add("TipoDocumento", typeof(string));
            tblFactura.Columns.Add("Cajero", typeof(string));
            tblFactura.Columns.Add("Caja", typeof(string));
            tblFactura.Columns.Add("Autorizacion", typeof(string));
            tblFactura.Rows.Add("002-011-000000487", "804", "2025-04-25T17:54:02-05:00", "AUTORIZADO",
                               "0933742426001", "JHIRE EZEQUIEL S.A.S", "0998821625", "ANTEPARA Y PRIMERA DE MAYO",
                               "25/04/2025 17:54:03", "PRODUCCIÓN", "FACTURA", "dloor", "CAJA001",
                               "2504202501131027159600120020110000004871234567811");
            ds.Tables.Add(tblFactura);

            // --- Tabla 2: Detalle de Productos ---
            DataTable tblDetalle = new DataTable("FacturaDetalle");
            tblDetalle.Columns.Add("Codigo", typeof(string));
            tblDetalle.Columns.Add("Producto", typeof(string));
            tblDetalle.Columns.Add("Cant", typeof(int));
            tblDetalle.Columns.Add("Precio", typeof(decimal));
            tblDetalle.Columns.Add("PFinal", typeof(decimal));
            tblDetalle.Columns.Add("Dscto", typeof(decimal));
            tblDetalle.Columns.Add("IVA", typeof(decimal));
            tblDetalle.Columns.Add("Subtotal", typeof(decimal));
            tblDetalle.Columns.Add("Total", typeof(decimal));
            tblDetalle.Rows.Add("7861097200475", "CEMIN 500MG/5ML CJX10 AMPOLLAS IM-IV", 20, 0.490, 0.480, 0.000, 0.000, 9.60, 9.60);
            tblDetalle.Rows.Add("8904159404011", "PARACETAMOL 500MG CJX100 TAB - ECUAQ", 100, 0.050, 0.050, 0.000, 0.000, 5.00, 5.00);
            tblDetalle.Rows.Add("7862104590336", "COMPLEJO B JARABE FCO X100ML - LABOVIDA", 15, 1.500, 1.500, 0.000, 0.000, 22.50, 22.50);
            ds.Tables.Add(tblDetalle);

            return ds;
        }
    }
}
