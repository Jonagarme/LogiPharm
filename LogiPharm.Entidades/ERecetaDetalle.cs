using System;

namespace LogiPharm.Entidades
{
    public class ERecetaDetalle
    {
        public int Id { get; set; }
        public int IdReceta { get; set; }
        public int? IdProducto { get; set; }
        public string ProductoNombre { get; set; }
        public decimal Cantidad { get; set; }
        public string Indicaciones { get; set; }
    }
}
