using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentAPI.JwtToken
{
    /// <summary>
    /// TokenManager class manages all operation on the jwt token 
    /// </summary>
    public class TokenManager
    {
        #region Private Variables

        // Secret key with the minimum 72 char
        private const string secretKey = "123456789012345678901234567890123456789012345678901234567890123456789012";

        #endregion

        #region Public Methods

        /// <summary>
        /// This method generates token by using appropriate algorithm & encoding
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string GenerateToken(string username)
        {
            // Key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            //Signing Credential
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Claims
            var claims = new[]
            {
                 new Claim(JwtRegisteredClaimNames.Sub, "Jwt Token"),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Jwt Token Generation with the 1 hr timeout
            var token = new JwtSecurityToken(
                issuer: "http://localhost:53929/",
                audience: "http://localhost:53929/",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credential
            );

            // return that jwt token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion
    }
}