using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace _10_Cryptography.BL
{
    public static class RsaAlgo
    {
        private static RSACryptoServiceProvider rsa;

        static RsaAlgo()
        {
            rsa = new RSACryptoServiceProvider();
        }

        public static string Encrypt(string plainText)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedBytes = rsa.Encrypt(plainBytes, false);

            return Convert.ToBase64String(encryptedBytes);
        }

        public static string Decrypt(string cipherText)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            byte[] decryptedBytes = rsa.Decrypt(cipherBytes, false);

            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}