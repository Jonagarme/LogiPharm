using System.Collections.Generic;

namespace LogiPharm.Entidades
{
    // === PAYLOAD PRINCIPAL (coincide con tu JSON objetivo) ===
    public class FacturaPayload
    {
        public string empresaRuc { get; set; }           // "0915912604001"
        public int ambiente { get; set; }                // 1 pruebas, 2 producción
        public string tipoComprobante { get; set; }      // "01" = Factura
        public InfoTributaria infoTributaria { get; set; }
        public InfoFactura infoFactura { get; set; }
        public List<DetalleFactura> detalles { get; set; }
    }

    // === BLOQUES ===
    public class InfoTributaria
    {
        public string estab { get; set; }                // "001"
        public string ptoEmi { get; set; }               // "001"
        public string secuencial { get; set; }           // "000000128"
        public string dirMatriz { get; set; }            // "AV. AMAZONAS Y NACIONES UNIDAS"
        public string contribuyenteRimpe { get; set; }   // "CONTRIBUYENTE RÉGIMEN RIMPE"
    }

    public class InfoFactura
    {
        public string fechaEmision { get; set; }         // "dd/MM/yyyy"
        public string dirEstablecimiento { get; set; }
        public string obligadoContabilidad { get; set; } // "SI"/"NO"
        public string tipoIdentificacionComprador { get; set; } // "05","04","06"
        public string razonSocialComprador { get; set; }
        public string identificacionComprador { get; set; }
        public string direccionComprador { get; set; }
        public decimal totalSinImpuestos { get; set; }
        public decimal totalDescuento { get; set; }
        public List<TotalImpuesto> totalConImpuestos { get; set; }
        public decimal propina { get; set; }
        public decimal importeTotal { get; set; }
        public string moneda { get; set; }               // "DOLAR"
    }

    public class TotalImpuesto
    {
        public string codigo { get; set; }               // "2" = IVA
        public string codigoPorcentaje { get; set; }     // "4" = 15%
        public decimal baseImponible { get; set; }
        public decimal valor { get; set; }
    }

    public class DetalleFactura
    {
        public string codigoPrincipal { get; set; }
        public string descripcion { get; set; }
        public decimal cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal descuento { get; set; }                   // valor en dinero
        public decimal precioTotalSinImpuesto { get; set; }      // base de IVA
        public List<ImpuestoDetalle> impuestos { get; set; } 
    }

    public class ImpuestoDetalle
    {
        public string codigo { get; set; }               // "2" = IVA
        public string codigoPorcentaje { get; set; }     // "4" = 15%
        public decimal tarifa { get; set; }              // 15.00
        public decimal baseImponible { get; set; }
        public decimal valor { get; set; }
    }

    // === Modelo que ya usas en el POS para recolectar del grid ===
    public class ProductoVenta
    {
        public int Id { get; set; }
        public string CodigoPrincipal { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Descuento { get; set; }               // % si así lo manejas en el grid
        public decimal PrecioTotalSinImpuesto { get; set; }
        public bool AplicaIva { get; set; } = true;  // base de IVA (opcional si recalculas)
    }

	// ==========================================
	// API FACTURACIÓN (http://localhost:5000)
	// ==========================================
	// Payload para: POST /api/facturacion/procesar-factura
	public class ProcesarFacturaRequest
	{
		public string tipo { get; set; }
		public string ruc { get; set; }
		public int empresa_Id { get; set; }
		public ProcesarFacturaData data { get; set; }
	}

	public class ProcesarFacturaData
	{
		public string fechaEmision { get; set; }
		public string establecimiento { get; set; }
		public string puntoEmision { get; set; }
		public string secuencial { get; set; }
		public string identificacionComprador { get; set; }
		public string razonSocialComprador { get; set; }
		public string direccionComprador { get; set; }
		public decimal totalSinImpuestos { get; set; }
		public decimal totalDescuento { get; set; }
		public decimal importeTotal { get; set; }
		public List<FacturaDetalleApi> detalles { get; set; }
		public List<ImpuestoApi> impuestos { get; set; }
		public List<PagoApi> pagos { get; set; }
		public InfoAdicionalApi infoAdicional { get; set; }
	}

	public class FacturaDetalleApi
	{
		public string codigoPrincipal { get; set; }
		public string codigoAuxiliar { get; set; }
		public string descripcion { get; set; }
		public decimal cantidad { get; set; }
		public decimal precioUnitario { get; set; }
		public decimal descuento { get; set; }
		public decimal precioTotalSinImpuesto { get; set; }
		public List<ImpuestoApi> impuestos { get; set; }
	}

	public class ImpuestoApi
	{
		public string codigo { get; set; }
		public string codigoPorcentaje { get; set; }
		public decimal baseImponible { get; set; }
		public decimal tarifa { get; set; }
		public decimal valor { get; set; }
	}

	public class PagoApi
	{
		public string formaPago { get; set; }
		public decimal total { get; set; }
	}

	public class InfoAdicionalApi
	{
		public string email { get; set; }
		public string telefono { get; set; }
	}

	// Payload para: POST /api/facturacion/anular-factura
	public class AnularFacturaRequest
	{
		public string ruc { get; set; }
		public AnularFacturaData data { get; set; }
	}

	public class AnularFacturaData
	{
		public string establecimiento { get; set; }
		public string puntoEmision { get; set; }
		public string secuencial { get; set; }
		public string identificacionComprador { get; set; }
		public string razonSocialComprador { get; set; }
		public decimal totalSinImpuestos { get; set; }
		public decimal valorModificacion { get; set; }
		public string motivo { get; set; }
		public string numDocModificado { get; set; }
		public List<FacturaDetalleApi> detalles { get; set; }
		public List<ImpuestoApi> impuestos { get; set; }
	}
}

