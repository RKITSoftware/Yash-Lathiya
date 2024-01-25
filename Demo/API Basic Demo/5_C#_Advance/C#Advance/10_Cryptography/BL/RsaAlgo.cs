using System;
using System.Security.Cryptography;
using System.Text;

namespace _10_Cryptography.BL
{
    /// <summary>
    /// Implementation of RSA Algorithm
    /// </summary>
    public static class RsaAlgo
    {
        #region Static Members

        private static RSACryptoServiceProvider rsa;

        // RSA Crypto Service Provider class implements logic of RSA Algorithm
        static RsaAlgo()
        {
            rsa = new RSACryptoServiceProvider();
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

            // Here true -> represent we are using advances RSA Padding Aprroach ( OAEP ) || More Secure 
            //      false -> Will use older padding scheme ( PKCS )
            byte[] encryptedBytes = rsa.Encrypt(plainBytes, true);

            // Bytes to String
            return Convert.ToBase64String(encryptedBytes);
        }

        /// <summary>
        /// Decryption of cipher text to plain text
        /// </summary>
        /// <param name="cipherText"> Cipher text in base64 string </param>
        /// <returns> Plain text in UTF8 string </returns>
        public static string Decrypt(string cipherText)
        {
            // String to bytes
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            // Here true -> represent we are using advances RSA Padding Aprroach ( OAEP ) || More Secure 
            //      false -> Will use older padding scheme ( PKCS )
            byte[] decryptedBytes = rsa.Decrypt(cipherBytes, true);

            // Bytes to String
            return Encoding.UTF8.GetString(decryptedBytes);
        }

        #endregion
    }
}