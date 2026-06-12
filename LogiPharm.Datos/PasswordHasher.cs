using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LogiPharm.Datos
{
    /// <summary>
    /// Clase para validar contraseñas hasheadas con Django PBKDF2_SHA256
    /// </summary>
    public class DjangoPasswordHasher
    {
        /// <summary>
        /// Verifica si una contraseña coincide con un hash de Django
        /// </summary>
        /// <param name="password">Contraseña en texto plano</param>
        /// <param name="hashedPassword">Hash completo de Django (ej: pbkdf2_sha256$720000$salt$hash)</param>
        /// <returns>True si la contraseña es correcta</returns>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            try
            {
                // Separar las partes del hash de Django
                var parts = hashedPassword.Split('$');
                
                if (parts.Length != 4)
                    return false;

                string algorithm = parts[0]; // pbkdf2_sha256
                int iterations = int.Parse(parts[1]); // 720000
                string salt = parts[2];
                string hash = parts[3];

                // Generar el hash con los mismos parámetros
                string computedHash = GenerateHash(password, salt, iterations);

                // Comparar hashes
                return hash == computedHash;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Genera un hash PBKDF2 compatible con Django
        /// </summary>
        private static string GenerateHash(string password, string salt, int iterations)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(
                password, 
                Encoding.UTF8.GetBytes(salt), 
                iterations, 
                HashAlgorithmName.SHA256))
            {
                byte[] hash = deriveBytes.GetBytes(32); // Django usa 32 bytes
                return Convert.ToBase64String(hash);
            }
        }

        /// <summary>
        /// Crea un nuevo hash de contraseña compatible con Django
        /// </summary>
        /// <param name="password">Contraseña en texto plano</param>
        /// <returns>Hash completo en formato Django</returns>
        public static string CreateHash(string password)
        {
            const int iterations = 720000;
            
            // Generar un salt aleatorio
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            string salt = Convert.ToBase64String(saltBytes).Replace("+", "").Replace("/", "").Replace("=", "").Substring(0, 22);

            // Generar el hash
            string hash = GenerateHash(password, salt, iterations);

            // Retornar en formato Django
            return $"pbkdf2_sha256${iterations}${salt}${hash}";
        }
    }
}
