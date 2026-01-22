using System;

namespace LogiPharm.Entidades
{
    public class EPuntoEmision
    {
        public int Id { get; set; }
        public int IdEstablecimiento { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int? IdUsuarioResponsable { get; set; }
        public bool Activo { get; set; }

        public int SecuencialFactura { get; set; }
        public int SecuencialNotaCredito { get; set; }
        public int SecuencialNotaDebito { get; set; }
        public int SecuencialGuiaRemision { get; set; }
        public int SecuencialRetencion { get; set; }

        public DateTime CreadoEn { get; set; }
    }
}
