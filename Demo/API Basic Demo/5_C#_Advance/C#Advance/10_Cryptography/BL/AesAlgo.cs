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
        #region Private Members

        private static string HardcodedKey = "keykeykeykeykeykeykeykeykeykeyky";

        #endregion

        #region Public Methods 

        /// <summary>
        /// This method generates cipher text by hardcoded plain text and key
        /// </summary>
        /// <returns> cipher text string </returns>
        public static string GetCipher()
        {
            string plainText = "abcdefghijklmnopqrstuvwxyzabcdef";

            // Convert plaintext and hardcoded key to byte arrays
            byte[] plain = Encoding.UTF8.GetBytes(plainText);
            byte[] key = Encoding.UTF8.GetBytes(HardcodedKey);

            // Using Aes Cng class -> encryption is performed
            using (AesCng aes = new AesCng())
            {
                aes.Key = key;

                // Generate a random IV for each encryption
                aes.GenerateIV();
                byte[] iv = aes.IV;

                // IV is included in the result for later decryption
                using (ICryptoTransform encryptor = aes.CreateEncryptor())
                {
                    // Getting cipher 
                    byte[] cipherBytes = encryptor.TransformFinalBlock(plain, 0, plain.Length);

                    // Combine IV and cipher text for storage/transmission
                    byte[] result = new byte[iv.Length + cipherBytes.Length];
                    Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                    Buffer.BlockCopy(cipherBytes, 0, result, iv.Length, cipherBytes.Length);

                    // Combined result is converted to string
                    return Convert.ToBase64String(result);
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
            // Convert hardcoded key to byte array
            byte[] key = Encoding.UTF8.GetBytes(HardcodedKey);

            // Cipher is converted into byte
            byte[] resultBytes = Convert.FromBase64String(cipherText);

            // Separate IV and cipher text
            byte[] iv = resultBytes.Take(16).ToArray();
            byte[] cipherBytes = resultBytes.Skip(16).ToArray();

            // Deciphering is performed by using AesCng class
            using (AesCng aes = new AesCng())
            {
                aes.Key = key;
                aes.IV = iv;

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