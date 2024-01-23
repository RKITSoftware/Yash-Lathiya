using _10_Cryptography.BL;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public IHttpActionResult GetAesCipher()
        {
            return Ok(AesAlgo.GetCipher());
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
            return Ok(AesAlgo.DecryptCipherText(cipherText));
        }

        /// <summary>
        /// Encryption by Triple DES Algorithm
        /// </summary>
        /// <returns> Ciphertext </returns>
        [HttpGet]
        [Route("api/tripleDes/encryption")]
        public IHttpActionResult GetTripleDesCipher(string plainText)
        {
            return Ok(TripleDes.Encrypt(plainText));
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
            return Ok(TripleDes.Decrypt(cipherText));
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
