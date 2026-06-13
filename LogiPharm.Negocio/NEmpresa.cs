using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Negocio
{
    public static class NEmpresa
    {
        public static EEmpresa ObtenerDatosEmpresa()
        {
            return new DEmpresa().ObtenerDatosEmpresa();
        }

        public static void GuardarDatosEmpresa(EEmpresa empresa)
        {
            // Validaciones básicas de negocio
            if (string.IsNullOrWhiteSpace(empresa.Ruc))
                throw new System.ArgumentException("El RUC es obligatorio.");
            if (string.IsNullOrWhiteSpace(empresa.RazonSocial))
                throw new System.ArgumentException("La razón social es obligatoria.");
            
            new DEmpresa().GuardarDatosEmpresa(empresa);
        }
    }
}
