using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace _10_Cryptography.BL
{
    public static class TripleDes
    {
        public static string Encrypt(string plainText)
        {
            string key = "ThisIsA24ByteTripleDESKe";

            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

            using (TripleDESCryptoServiceProvider tripleDesAlg = new TripleDESCryptoServiceProvider())
            {
                tripleDesAlg.Key = keyBytes;
                tripleDesAlg.Mode = CipherMode.ECB; // ECB mode is used for simplicity, consider using other modes for security

                ICryptoTransform encryptor = tripleDesAlg.CreateEncryptor();

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(plainBytes, 0, plainBytes.Length);
                        csEncrypt.FlushFinalBlock();
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            string key = "ThisIsA24ByteTripleDESKe";

            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            using (TripleDESCryptoServiceProvider tripleDesAlg = new TripleDESCryptoServiceProvider())
            {
                tripleDesAlg.Key = keyBytes;
                tripleDesAlg.Mode = CipherMode.ECB; // ECB mode is used for simplicity, consider using other modes for security

                ICryptoTransform decryptor = tripleDesAlg.CreateDecryptor();

                using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}