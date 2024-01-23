using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace _10_Cryptography.BL
{
    /// <summary>
    /// Implementation of AES Algorithm
    /// Plaintext & key -> 128 bits
    /// </summary>
    public static class AesAlgo
    {
        #region Public Methods 

        /// <summary>
        /// This method generates cipher text by hardcoded plain text and key
        /// </summary>
        /// <returns> cipher text string </returns>
        public static string GetCipher()
         {
            // 128 bit plain text and key
            string plainText = "abcdefghijklmnopqrstuvwxyzabcdef";
            string keyValue = "keykeykeykeykeykeykeykeykeykeyky";

            // That are converted in byte array
            byte[] plain = Encoding.UTF8.GetBytes(plainText);
            byte[] key = Encoding.UTF8.GetBytes(keyValue);

            // Using Aes Cng class -> encryption is performed
            using (AesCng aes = new AesCng())
            {
                aes.Key = key;

                using (ICryptoTransform encryptor = aes.CreateEncryptor())
                {
                    // Getting cipher 
                    byte[] cipherBytes = encryptor.TransformFinalBlock(plain, 0, plain.Length);

                    // Cipher is converted to string
                    return Convert.ToBase64String(cipherBytes);
                }
            }
        }

        /// <summary>
        /// Decipher method uses key in previous method
        /// </summary>
        /// <param name="cipherText"> Cipher text in string format </param>
        /// <returns> plaintext in string </returns>
        public static string DecryptCipherText(string cipherText)
        {
            // Key 
            string keyValue = "keykeykeykeykeykeykeykeykeykeyky";
            byte[] key = Encoding.UTF8.GetBytes(keyValue);

            // Cipher is converted into byte
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            // Deciphering is performed by suing AesCng class
            using (AesCng aes = new AesCng())
            {
                aes.Key = key;

                using (ICryptoTransform decryptor = aes.CreateDecryptor())
                {
                    // getting plain text 
                    byte[] plain = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                    
                    // Plain text in string format
                    return Encoding.UTF8.GetString(plain);
                }
            }
        }

        #endregion
    }
}