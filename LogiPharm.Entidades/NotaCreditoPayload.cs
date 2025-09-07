using System.Collections.Generic;

namespace LogiPharm.Entidades
{
    // Payload principal de Nota de Crédito (SRI Doc. 04)
    public class NotaCreditoPayload
    {
        public string empresaRuc { get; set; }
        public int ambiente { get; set; }
        public string tipoComprobante { get; set; } // "04"
        public InfoTributaria infoTributaria { get; set; }
        public InfoNotaCredito infoNotaCredito { get; set; }
        public List<DetalleNotaCredito> detalles { get; set; }
    }

    // Bloque infoNotaCredito
    public class InfoNotaCredito
    {
        public string fechaEmision { get; set; }                // dd/MM/yyyy
        public string dirEstablecimiento { get; set; }
        public string tipoIdentificacionComprador { get; set; }  // 05,04,06
        public string razonSocialComprador { get; set; }
        public string identificacionComprador { get; set; }
        public string obligadoContabilidad { get; set; }         // SI/NO

        // Documento modificado (la factura de origen)
        public string codDocModificado { get; set; }             // "01" = Factura
        public string numDocModificado { get; set; }             // 001-001-000000123
        public string fechaEmisionDocSustento { get; set; }      // dd/MM/yyyy

        public decimal totalSinImpuestos { get; set; }
        public decimal valorModificacion { get; set; }           // total con impuestos a modificar
        public string moneda { get; set; }
        public List<TotalImpuesto> totalConImpuestos { get; set; }

        public string motivo { get; set; }
    }

    // Detalle de Nota de Crédito
    public class DetalleNotaCredito
    {
        public string codigoInterno { get; set; }
        public string descripcion { get; set; }
        public decimal cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal descuento { get; set; }
        public decimal precioTotalSinImpuesto { get; set; }
        public List<ImpuestoDetalle> impuestos { get; set; }
    }
}
