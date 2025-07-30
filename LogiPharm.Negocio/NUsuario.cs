using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Negocio
{
    public static class NUsuario
    {
        public static EUsuario Login(string usuario, string clave)
        {
            //return new DUsuario().Login(usuario, clave);

            // Simulación de un usuario para pruebas
            EUsuario eUsuario = new EUsuario();
            eUsuario.Usuario = usuario;
            eUsuario.Clave = clave;
            eUsuario.Rol = "Admin";
            eUsuario.NombreCompleto = "Administrador";
            return eUsuario;
        }
    }
}
