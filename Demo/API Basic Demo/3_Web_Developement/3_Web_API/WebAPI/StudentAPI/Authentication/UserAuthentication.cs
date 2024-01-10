using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAPI.Authentication
{
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
            return User.GetUsers().FirstOrDefault(user => user.UserName == username && user.Password == password);
        }

    }
}