using System;

namespace LogiPharm.Entidades
{
    public class EPercha
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Filas { get; set; }
        public int Columnas { get; set; }
        public bool Activo { get; set; }
        public int SeccionId { get; set; }
        public string SeccionNombre { get; set; }
        public int CapacidadTotal { get; set; }
        public int ProductosAsignados { get; set; }
        public int EspaciosDisponibles { get; set; }

        public EPercha()
        {
            Activo = true;
            Filas = 5;
            Columnas = 8;
        }
    }
}
