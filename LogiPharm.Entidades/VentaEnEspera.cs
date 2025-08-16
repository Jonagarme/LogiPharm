using LogiPharm.Entidades;
using System.Collections.Generic;

namespace LogiPharm.Presentacion.Utilidades
{
    public class VentaEnEspera
    {
        public string Nombre { get; set; }
        public ECliente Cliente { get; set; }
        public List<ProductoVenta> Productos { get; set; }

        public VentaEnEspera(string nombre)
        {
            Nombre = nombre;
            Cliente = null;
            Productos = new List<ProductoVenta>();
        }
    }
}