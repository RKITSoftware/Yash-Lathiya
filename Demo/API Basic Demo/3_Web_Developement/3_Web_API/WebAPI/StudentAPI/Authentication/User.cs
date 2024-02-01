using System.Collections.Generic;

namespace StudentAPI.Authentication
{
    /// <summary>
    /// User class defines role of all user which is used for authentication & authorization purpose
    /// </summary>
    public class User
    {

        #region Public Methods

        /// <summary>
        /// Id of User
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// UserName of User - which will use for Authentication 
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Password of User - which will use for Authentication 
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Role of User - which will use for Authorizarion
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// List of all user is divided into - student, teacher, hod
        /// </summary>
        /// <returns> List of users with their details </returns>
        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();

            users.Add(new User() { Id = 1, UserName = "student", Password = "student", Role = "student" });
            users.Add(new User() { Id = 2, UserName = "teacher", Password = "teacher", Role = "student,teacher" });
            users.Add(new User() { Id = 3, UserName = "hod", Password = "hod", Role = "student,teacher,hod" });

            return users;
        }

        #endregion
    }
}