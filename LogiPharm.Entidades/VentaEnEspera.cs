using LogiPharm.Entidades;
using System.Collections.Generic;

namespace LogiPharm.Presentacion.Utilidades
{
    public class VentaEnEspera
    {
        public string Nombre { get; set; }
        public ECliente Cliente { get; set; }
        public List<ProductoVenta> Productos { get; set; }
        public string PriceMode { get; set; }
        public decimal Descuento { get; set; }
        public bool DesactivarIva { get; set; }
        public bool EsEntrega { get; set; }

        public VentaEnEspera(string nombre)
        {
            Nombre = nombre;
            Cliente = null;
            Productos = new List<ProductoVenta>();
            PriceMode = "NORMAL";
            Descuento = 0m;
            DesactivarIva = false;
            EsEntrega = false;
        }
    }
}