using System;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace ExpenseTracker.Static
{
    /// <summary>
    /// consists all methods & variable which are frequently used in this project 
    /// </summary>
    public static class Static
    {

        /// <summary>
        /// Get userid from jwt token claim
        /// </summary>
        /// <returns> userid (r01f01)</returns>
        /// <exception cref="InvalidOperationException"> If issue related to find claim </exception>
        public static int GetUserIdFromClaims()
        {
            var claimsIdentity = HttpContext.Current.User.Identity as ClaimsIdentity;
            var userIdClaim = claimsIdentity?.Claims.FirstOrDefault(c => c.Type == "r01f01");

            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int r01f01))
            {
                return r01f01;
            }

            // Handle the case when the user ID is not found in claims or cannot be parsed
            throw new InvalidOperationException("User ID not found in claims or invalid.");
        }
    }
}