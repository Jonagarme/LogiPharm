using System;
using System.Collections.Generic;

namespace LogiPharm.Entidades
{
    /// <summary>
    /// Representa una Orden de Compra (OC) en el sistema
    /// </summary>
    public class EOrdenCompra
    {
        public long Id { get; set; }
        public int Numero { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime? FechaEntregaEsperada { get; set; }
        public int IdProveedor { get; set; }
        public string RazonSocialProveedor { get; set; }
        public string RucProveedor { get; set; }
        public string DireccionProveedor { get; set; }
        public string TelefonoProveedor { get; set; }
        public string EmailProveedor { get; set; }
        public string Observaciones { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; } // PENDIENTE / APROBADA / RECIBIDA / PARCIAL / CANCELADA
        public int CreadoPor { get; set; }
        public DateTime CreadoDate { get; set; }
        public int? AprobadoPor { get; set; }
        public DateTime? AprobadoDate { get; set; }
        public bool Anulado { get; set; }
        public int? AnuladoPor { get; set; }
        public DateTime? AnuladoDate { get; set; }

        public List<EOrdenCompraDetalle> Detalles { get; set; } = new List<EOrdenCompraDetalle>();
    }

    /// <summary>
    /// Representa el detalle de productos en una Orden de Compra
    /// </summary>
    public class EOrdenCompraDetalle
    {
        public long Id { get; set; }
        public long IdOrdenCompra { get; set; }
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string ProductoNombre { get; set; }
        public decimal CantidadSolicitada { get; set; }
        public decimal CantidadRecibida { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal DescuentoPorc { get; set; }
        public decimal DescuentoValor { get; set; }
        public decimal IVAValor { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
    }
}
