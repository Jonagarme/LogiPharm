using System;
using System.Collections.Generic;

namespace LogiPharm.Entidades
{
    public class EAjuste
    {
        public int Id { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUbicacion { get; set; } // Bodega/Ubicación
        public string TipoAjuste { get; set; } // 'INGRESO' o 'EGRESO'
        public string Observaciones { get; set; }
        public int IdUsuario { get; set; }
        public int IdEmpresa { get; set; }
        public decimal Total { get; set; }
        public List<EAjusteDetalle> Detalles { get; set; }

        public EAjuste()
        {
            Detalles = new List<EAjusteDetalle>();
        }
    }

    public class EAjusteDetalle
    {
        public int IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Total { get; set; }
    }
}
