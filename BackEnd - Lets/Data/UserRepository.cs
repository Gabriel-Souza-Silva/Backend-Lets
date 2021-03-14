using BackEnd___Lets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd___Lets.Data
{
    public class UserRepository
    {

        public static IList<User> Users = new List<User>
        {

            new User
            {
                Type = 1,
                login = "gabriel@teste.com",
                Name = "Gabriel",
                senha = "123"
            },

            new User
            {
                Type = 2,
                login = "letscode",
                Name = "Let's Code",
                senha = "lets@123"
            }
        };


        public User GetByEmail(string email)
        {
            return Users.Where(x => x.login.ToLower() == email.ToLower())
                .FirstOrDefault();
        }
    }
}
