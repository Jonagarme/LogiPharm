namespace LogiPharm.Entidades
{
    public class ELabResultado
    {
        public int Id { get; set; }
        public int ProcesoId { get; set; }
        public System.DateTime FechaEmision { get; set; }
        public string PacienteNombre { get; set; }
        public string PacienteId { get; set; }
        public string MedicoSolicitante { get; set; }
        public string Observaciones { get; set; }
    }
}
