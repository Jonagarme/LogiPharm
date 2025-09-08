using System;

namespace LogiPharm.Entidades
{
    public class EImpuesto
    {
        public int Id { get; set; }
        public string Codigo { get; set; } // p.ej. "IVA"
        public string Nombre { get; set; } // p.ej. "Impuesto al Valor Agregado"
        public decimal Porcentaje { get; set; } // 0.15 = 15%
        public DateTime? VigenteDesde { get; set; }
        public DateTime? VigenteHasta { get; set; }
        public bool Activo { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return $"{Codigo} {Porcentaje:P0}";
        }
    }
}
