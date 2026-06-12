using System;
using System.Collections.Generic;

namespace LogiPharm.Entidades
{
    public class EReceta
    {
        public int Id { get; set; }
        public string NumeroReceta { get; set; }
        public int? IdCliente { get; set; }
        public string PacienteNombre { get; set; }
        public string MedicoNombre { get; set; }
        public string MedicoRegistro { get; set; }
        public string MedicoEspecialidad { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
        public bool Activo { get; set; }

        public List<ERecetaDetalle> Detalles { get; set; }

        public EReceta()
        {
            Detalles = new List<ERecetaDetalle>();
        }
    }
}
