using System;

public class ECliente
{
    public int Id { get; set; }
    public string TipoIdentificacion { get; set; }
    public string CedulaRuc { get; set; }          // Nuevo
    public string Nombres { get; set; }            // Nuevo
    public string Apellidos { get; set; }          // Nuevo
    public string RazonSocial { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Celular { get; set; }            // Nuevo
    public string Email { get; set; }
    public DateTime? FechaNacimiento { get; set; } // Nuevo
    public string TipoCliente { get; set; }        // Nuevo
    public int Estado { get; set; }                // Nuevo (1=Activo, 0=Inactivo)
    // Auditoría
    public int CreadoPor { get; set; }
    public int? EditadoPor { get; set; }
    public string Identificacion { get; set; }
}
