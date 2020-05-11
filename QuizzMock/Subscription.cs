using QuizzMock.Model;
using System;

namespace QuizzMock
{
    public class Subscription
    {

        private IUserService _userService;

        public Subscription(IUserService userService)
        {
            _userService = userService;
        }

        public bool HasSubscribed(string username, string firstname, string lastname)
        {
            var newUser = new User()
            {
                Firstname = firstname,
                LastName = lastname,
                UserName = username,
            };

            try
            {
                var uid = _userService.CreateUser(newUser);                
            }
            catch (Exception)
            {
                return false;          
            }

            return true;
        }
    }
}
