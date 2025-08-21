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
        public decimal PrecioTotalSinImpuesto { get; set; }  // base de IVA (opcional si recalculas)
    }
}
