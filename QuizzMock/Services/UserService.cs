using QuizzMock.Model;
using System;
using System.Collections.Generic;

namespace QuizzMock
{
    public interface IUserService
    {
        List<User> GetUsers();
        Guid CreateUser(User newUser);
    }
    public class UserService : IUserService
    {
        public List<User> GetUsers()
        {
            return new List<User>()
            {
                new User { Id = new Guid(), Firstname = "Clément", LastName = "Prudhomme", UserName = "c.prudhomme" },
                new User { Id = new Guid(), Firstname = "Hassan", LastName = "Rammach", UserName = "h.rammach" },
                new User { Id = new Guid(), Firstname = "Sebastien", LastName = "Lhutin", UserName = "s.lhutin" },
                new User { Id = new Guid(), Firstname = "Loïc", LastName = "Lemarchand", UserName = "l.lemarchand" },
            };
        }

        public Guid CreateUser(User newUser)
        {
            if (string.IsNullOrWhiteSpace(newUser.UserName))
            {
                throw new Exception("Username is mandatory !");
            }
            else
            {
                // Insert in database, return new user Id
                return new Guid();
            }
        }
    }
}
