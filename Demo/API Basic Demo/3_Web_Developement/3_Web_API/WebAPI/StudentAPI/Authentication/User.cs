using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAPI.Authentication
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public string Email { get; set; }

        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();

            users.Add(new User() { Id = 1, UserName = "student", Password = "student", Role = "student", Email = "student@gmail.com" });
            users.Add(new User() { Id = 2, UserName = "teacher", Password = "teacher", Role = "teacher", Email = "teacher@gmail.com" });
            users.Add(new User() { Id = 3, UserName = "hod", Password = "hod", Role = "hod", Email = "hod@gmail.com" });

            return users;
        }
    }
}