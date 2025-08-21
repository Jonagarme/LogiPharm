using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Configuration; // Necesario para leer el App.config

namespace LogiPharm.Presentacion.Utilidades
{
    public static class Encriptador
    {
        // La clave DEBE ser de 16, 24 o 32 bytes. Usaremos 32 (256 bits) para máxima seguridad.
        // Se leerá desde el archivo de configuración App.config.
        private static readonly string claveSecreta = ConfigurationManager.AppSettings["SecretKeyForCertificates"];

        public static string Encriptar(string textoPlano)
        {
            if (string.IsNullOrEmpty(textoPlano))
                return "";

            if (string.IsNullOrEmpty(claveSecreta) || claveSecreta.Length != 32)
                throw new ArgumentException("La clave secreta no está configurada o no tiene el tamaño correcto (32 caracteres).");

            byte[] iv = new byte[16]; // Vector de inicialización
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(claveSecreta);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(textoPlano);
                        }
                        array = memoryStream.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(array);
        }

        public static string Desencriptar(string textoEncriptado)
        {
            if (string.IsNullOrEmpty(textoEncriptado))
                return "";

            if (string.IsNullOrEmpty(claveSecreta) || claveSecreta.Length != 32)
                throw new ArgumentException("La clave secreta no está configurada o no tiene el tamaño correcto (32 caracteres).");

            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(textoEncriptado);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(claveSecreta);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}