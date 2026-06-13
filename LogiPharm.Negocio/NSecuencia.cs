using System.Data;
using LogiPharm.Datos;

namespace LogiPharm.Negocio
{
    public static class NSecuencia
    {
        public static string ObtenerSiguienteSecuencial(string establecimiento, string puntoEmision)
        {
            return new DGenerarSecuancial().ObtenerSiguienteSecuencial(establecimiento, puntoEmision);
        }

        public static DataTable ListarSecuencias()
        {
            return new DSecuencias().ListarSecuencias();
        }

        public static void GuardarSecuencia(string nombre, int valor, string prefijo, int longitud, bool activo)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new System.ArgumentException("El nombre de la secuencia es obligatorio.");
            if (longitud <= 0)
                throw new System.ArgumentException("La longitud debe ser mayor a cero.");

            new DSecuencias().GuardarSecuencia(nombre, valor, prefijo, longitud, activo);
        }

        public static void EliminarSecuencia(string nombre)
        {
            new DSecuencias().EliminarSecuencia(nombre);
        }
    }
}
