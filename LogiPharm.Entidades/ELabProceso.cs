namespace LogiPharm.Entidades
{
    public class ELabProceso
    {
        public int Id { get; set; }
        public int LaboratorioId { get; set; }
        public string Nombre { get; set; }
        public string Metodo { get; set; }
        public bool Activo { get; set; }
    }
}
