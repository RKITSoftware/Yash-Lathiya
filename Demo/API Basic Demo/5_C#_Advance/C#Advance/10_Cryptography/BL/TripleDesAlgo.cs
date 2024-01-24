using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace _10_Cryptography.BL
{
    /// <summary>
    /// Implementation of Triple DES Algorithm
    /// </summary>
    public static class TripleDesAlgo
    {
        #region Static Members

        private static TripleDESCryptoServiceProvider tripleDes;

        // Triple DES Crypto Service Provider class implements logic of RSA Algorithm
        static TripleDesAlgo()
        {
            tripleDes = new TripleDESCryptoServiceProvider();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Encryption of plain text to cipher text
        /// </summary>
        /// <param name="plainText"> Plain text in base64 string </param>
        /// <returns> Cipher Text in base64 string </returns>
        public static string Encrypt(string plainText)
        {
            // String to bytes 
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

            // Uses key & Initialize Vector (IV)
            using (ICryptoTransform encryptor = tripleDes.CreateEncryptor())
            {
                // TransformFinalBlock method encrypts or decrypts data from region of the data 
                // O is offset -> Means plaintext starting from begining
                // plainBytes.Length specifies the length of the message 
                byte[] encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

                // Bytes to string 
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
            using (ICryptoTransform decryptor = tripleDes.CreateDecryptor())
            {
                // TransformFinalBlock method encrypts or decrypts data from region of the data 
                // O is offset -> Means cipherText starting from begining
                // cipherBytes.Length specifies the length of the message 
                byte[] decryptedBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                
                // Bytes to String 
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }

        #endregion

    }
}