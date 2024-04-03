using _10_Cryptography.BL;
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
            AesAlgo objAesAlgo = new AesAlgo();
            return Ok(objAesAlgo.Encrypt(plainText));
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
            AesAlgo objAesAlgo = new AesAlgo();
            return Ok(objAesAlgo.Decrypt(cipherText));
        }

        /// <summary>
        /// Encryption by Triple DES Algorithm
        /// </summary>
        /// <returns> Ciphertext </returns>
        [HttpGet]
        [Route("api/tripleDes/encryption")]
        public IHttpActionResult GetTripleDesCipher(string plainText)
        {
            TripleDesAlgo objTripleDesAlgo = new TripleDesAlgo();
            return Ok(objTripleDesAlgo.Encrypt(plainText));
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
            TripleDesAlgo objTripleDesAlgo = new TripleDesAlgo();
            return Ok(objTripleDesAlgo.Decrypt(cipherText));
        }


        /// <summary>
        /// Encryption by RSA Algorithm
        /// </summary>
        /// <returns> Ciphertext </returns>
        [HttpGet]
        [Route("api/Rsa/encryption")]
        public IHttpActionResult GetRsaCipher(string plainText)
        {
            RsaAlgo objRsaAlgo = new RsaAlgo();
            return Ok(objRsaAlgo.Encrypt(plainText));
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
            RsaAlgo objRsaAlgo = new RsaAlgo();
            return Ok(objRsaAlgo.Decrypt(cipherText));
        }

        #endregion
    }
}
