﻿using _10_Cryptography.BL;
using System.Web.Http;

namespace _10_Cryptography.Controllers
{
    /// <summary>
    /// This controller provides methods to cryptography techniques
    /// Encryption & Decryption techniques
    /// </summary>
    public class CLApiController : ApiController
    {
        #region Public Methods 

        /// <summary>
        /// Encryption by AES Algorithm
        /// </summary>
        /// <returns> Ciphertext </returns>
        [HttpGet]
        [Route("api/Aes/encryption")]
        public IHttpActionResult GetAesCipher(string plainText)
        {
            return Ok(AesAlgo.Encrypt(plainText));
        }

        /// <summary>
        /// Decryption by AES Algorithm
        /// </summary>
        /// <param name="cipherText"> Generated ciphertext in previous method </param>
        /// <returns> Plain text </returns>
        [HttpGet]
        [Route("api/Aes/decryption")]
        public IHttpActionResult GetAesPlain(string cipherText)
        {
            return Ok(AesAlgo.Decrypt(cipherText));
        }

        /// <summary>
        /// Encryption by Triple DES Algorithm
        /// </summary>
        /// <returns> Ciphertext </returns>
        [HttpGet]
        [Route("api/tripleDes/encryption")]
        public IHttpActionResult GetTripleDesCipher(string plainText)
        {
            return Ok(TripleDesAlgo.Encrypt(plainText));
        }

        /// <summary>
        /// Decryption by Triple DES Algorithm
        /// </summary>
        /// <param name="cipherText"> Generated ciphertext in previous method </param>
        /// <returns> Plain text </returns>
        [HttpGet]
        [Route("api/TripleDes/decryption")]
        public IHttpActionResult GetTripleDesPlain(string cipherText)
        {
            return Ok(TripleDesAlgo.Decrypt(cipherText));
        }


        /// <summary>
        /// Encryption by RSA Algorithm
        /// </summary>
        /// <returns> Ciphertext </returns>
        [HttpGet]
        [Route("api/Rsa/encryption")]
        public IHttpActionResult GetRsaCipher(string plainText)
        {
            return Ok(RsaAlgo.Encrypt(plainText));
        }

        /// <summary>
        /// Decryption by RSA Algorithm
        /// </summary>
        /// <param name="cipherText"> Generated ciphertext in previous method </param>
        /// <returns> Plain text </returns>
        [HttpGet]
        [Route("api/Rsa/decryption")]
        public IHttpActionResult GetRsaPlain(string cipherText)
        {
            return Ok(RsaAlgo.Decrypt(cipherText));
        }

        #endregion
    }
}