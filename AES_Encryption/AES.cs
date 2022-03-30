using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace AES_Encryption
{
    internal class AES
    {
        //Encryption Key
        static byte[] Key = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16,
            17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32};
        //Initialization vector
        static byte[] IV = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        static byte[] encriptado;
        static AesManaged aes = new AesManaged();

        static string encriptadoAES(string cadena)
        {
            string salida = "";
            // Generación de la llave de encriptación y del vector de inicialización
            Key = aes.Key;
            IV = aes.IV;
            try
            {
                using (aes)
                {
                    encriptado = Encriptar(cadena);
                    salida = $"{Encoding.UTF8.GetString(encriptado)}";
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("Excepcion: " + exp.Message);
                Console.ReadKey();
            }
            return salida;
        }

        public static byte[] Encriptar(string texto)
        {
            byte[] encriptando;
            using (AesManaged aes = new AesManaged())
            {
                ICryptoTransform encriptador = aes.CreateEncryptor(Key, IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encriptador, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(texto);
                        encriptando = ms.ToArray();
                    }
                }
            }
            return encriptando;
        }
        public static string Desencripta(byte[] cifrado)
        {
            string texto = null;
            using (AesManaged aes1 = new AesManaged())
            {
                ICryptoTransform desencriptar = aes1.CreateDecryptor(Key, IV);
                using (MemoryStream ms = new MemoryStream(cifrado))
                {
                    using (CryptoStream cs = new CryptoStream(ms, desencriptar, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cs))
                            texto = reader.ReadToEnd();
                    }
                }
            }
            return texto;
        }
    }
}
