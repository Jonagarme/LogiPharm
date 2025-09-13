namespace LogiPharm.Entidades
{
    public class ELabResultadoDetalle
    {
        public int Id { get; set; }
        public int ResultadoId { get; set; }
        public string ParametroNombre { get; set; }
        public string Valor { get; set; }
        public string Unidad { get; set; }
        public string RangoReferencia { get; set; }
        public bool FueraDeRango { get; set; }
    }
}
