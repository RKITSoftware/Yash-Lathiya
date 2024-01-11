using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAPI.Authentication
{
    /// <summary>
    /// UserAuthentication class validates user, if user is valid or not 
    /// It will check only id & password, not the role of the user
    /// </summary>
    public class UserAuthentication
    {

        // Check User exists or not
        public static bool Login(string username, string password)
        {
            // For Basic Authentication

            //if(username == "student" && password == "student")
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            // For Role Based Authentication

            // Any method returns boolean that's why FirstOrDefault  method is not used as it returns object
            return User.GetUsers().Any(user => user.UserName == username && user.Password == password);
        }

        // Extract user details
        public static User GetDetails(string username, string password)
        {
            // FirstOrDefault Method returns the user object with its details
            return User.GetUsers().FirstOrDefault(user => user.UserName == username && user.Password == password);
        }

    }
}