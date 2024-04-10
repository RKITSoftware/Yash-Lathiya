using System;
using System.Security.Cryptography;
using System.Text;

namespace _10_Cryptography.BL
{
    /// <summary>
    /// Implementation of RSA Algorithm
    /// </summary>
    public class RsaAlgo
    {
        #region Private Members

        /// <summary>
        /// crypto service provider
        /// </summary>
        private static RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

        #endregion

        #region Public Methods

        /// <summary>
        /// Encryption of plain text to cipher text
        /// </summary>
        /// <param name="plainText"> Plain text to encrypt </param>
        /// <returns> Cipher text in base64 string </returns>
        public string Encrypt(string plainText)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

            // Use OAEP padding for security
            byte[] encryptedBytes = rsa.Encrypt(plainBytes, true);

            // Return cipher text as base64 string
            return Convert.ToBase64String(encryptedBytes);
        }

        /// <summary>
        /// Decryption of cipher text to plain text
        /// </summary>
        /// <param name="cipherText"> Cipher text in base64 string </param>
        /// <returns> Plain text </returns>
        public string Decrypt(string cipherText)
        {

            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            // Use OAEP padding for security
            byte[] decryptedBytes = rsa.Decrypt(cipherBytes, true);

            // Convert decrypted bytes to UTF-8 string
            return Encoding.UTF8.GetString(decryptedBytes);
        }

        #endregion
    }
}
