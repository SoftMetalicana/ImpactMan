using System.Linq;

namespace ImpactMan.Core
{
    using System.Collections.Generic;
    using Context.Models;

    public class AccountManager
    {
        private IList<User> users;

        public AccountManager()
        {
            this.users = new List<User>();
            users.Add(new User()
            {
                Name = "MARIAN",
                Password = "123",    
                Level = 0,
                Id = 0
            });
        }

        public bool Login(User user)
        {
            return users.Any(u => u.Name == user.Name && u.Password == user.Password);
        }

        public bool Register(User user)
        {
            if (users.Any(u => u.Name == user.Name && u.Password == user.Password))
            {
                return false;
            }

            users.Add(user);
            return true;
        }
    }
}
