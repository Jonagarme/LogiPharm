namespace LogiPharm.Entidades
{
    public class ELabParametro
    {
        public int Id { get; set; }
        public int ProcesoId { get; set; }
        public string Nombre { get; set; }
        public string Unidad { get; set; }
        public string RefMin { get; set; }
        public string RefMax { get; set; }
        public int Orden { get; set; }
        public string Notas { get; set; }
        public bool Activo { get; set; }
    }
}
