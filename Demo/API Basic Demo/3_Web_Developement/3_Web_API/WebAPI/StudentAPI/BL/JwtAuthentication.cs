namespace StudentAPI.BL
{
    public class JwtAuthentication
    {
        #region Public Methods

        /// <summary>
        /// Checks user is valid or not
        /// </summary>
        /// <param name="username"> Username </param>
        /// <param name="password"> Password </param>
        /// <returns></returns>
        public bool IsValidUser(string username, string password)
        {
            // Hard-Code Validation Implementation
            if (username == "jwt" && password == "jwt")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}