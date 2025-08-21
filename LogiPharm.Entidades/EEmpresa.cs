using System; // Necesario para DateTime

namespace LogiPharm.Entidades
{
    public class EEmpresa
    {
        public int Id { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public string DireccionMatriz { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public byte[] Logo { get; set; }

        // --- ✨ CAMPOS NUEVOS AÑADIDOS ---
        public string ContribuyenteEspecial { get; set; }
        public bool ObligadoContabilidad { get; set; }
        public string CertificadoP12Path { get; set; }
        public string CertificadoPassword { get; set; } // Guardará la contraseña encriptada
        public DateTime? CertificadoFechaExpiracion { get; set; } // Usamos '?' para permitir que sea nulo
    }
}