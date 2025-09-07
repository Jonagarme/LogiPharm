using System;
using System.Collections.Generic;

namespace LogiPharm.Entidades
{
    public class ECotizacion
    {
        public long Id { get; set; }
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public int ValidezDias { get; set; }
        public int IdCliente { get; set; }
        public string Observaciones { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; } // VIGENTE / ANULADA / VENCIDA
        public int CreadoPor { get; set; }
        public DateTime CreadoDate { get; set; }
        public bool Anulado { get; set; }
        public int? AnuladoPor { get; set; }
        public DateTime? AnuladoDate { get; set; }

        public List<ECotizacionDetalle> Detalles { get; set; } = new List<ECotizacionDetalle>();
    }

    public class ECotizacionDetalle
    {
        public long Id { get; set; }
        public long IdCotizacion { get; set; }
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string ProductoNombre { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioFinal { get; set; }
        public decimal DescuentoPorc { get; set; }
        public decimal DescuentoValor { get; set; }
        public decimal IVAValor { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
    }
}
