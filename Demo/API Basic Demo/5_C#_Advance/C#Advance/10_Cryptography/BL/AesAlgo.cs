﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace _10_Cryptography.BL
{
    /// <summary>
    /// Implementation of AES Algorithm
    /// Plaintext & key -> 128 bits
    /// </summary>
    public static class AesAlgo
    {
        #region Static Members 

        // AES Crypto Service Provider class implements logic of AES Algorithm
        private static AesCryptoServiceProvider aes;

        /// <summary>
        /// Provide Instance to class
        /// </summary>
        static AesAlgo()
        {
            aes = new AesCryptoServiceProvider();
        }

        #endregion

        #region Public Methods 

        /// <summary>
        /// Encryption of plain text to cipher text
        /// </summary>
        /// <param name="plainText"> Plain text in base64 string </param>
        /// <returns> Cipher Text in base64 string </returns>
        public static string Encrypt(string plainText)
        {
            // String to bytes
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

            // Generate Key & Initilize Vector (IV)
            using (ICryptoTransform encryptor = aes.CreateEncryptor())
            {
                // TransformFinalBlock method encrypts or decrypts data 
                // O is offset -> Means plaintext starting from begining
                // plainBytes.Length specifies the length of the message 
                byte[] encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

                // Convert cipher text to string
                return Convert.ToBase64String(encryptedBytes);
            }
        }

        /// <summary>
        /// Decryption of cipher text to plain text
        /// </summary>
        /// <param name="cipherText"> Cipher text in base64 string </param>
        /// <returns> Plain text in UTF8 string </returns>
        public static string Decrypt(string cipherText)
        {
            // string to bytes
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            // Uses key & Initialize Vector (IV)
            using (ICryptoTransform decryptor = aes.CreateDecryptor())
            {
                // TransformFinalBlock method encrypts or decrypts data from region of the data 
                // O is offset -> Means cipherText starting from begining
                // cipherBytes.Length specifies the length of the message 
                byte[] decryptedBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                
                // Convert plain bytes to string
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }

        #endregion
    }
}