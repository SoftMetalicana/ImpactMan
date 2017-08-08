using System;
using System.Linq;

namespace ImpactMan.Core
{
    using System.Collections.Generic;
    using Context.Models;

    /// <summary>
    /// This class takes care of the login and signup processes and the related checks and interaction with the DB.
    /// </summary>
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
            return UserExists(user) && IsPasswordCorrect(user);
        }

        public bool Register(User user)
        {
            if (UserExists(user))
            {
                return false;
            }

            this.users.Add(user);
            return true;
        }

        private bool UserExists(User user)
        {
            return this.users.Any(u => u.Name == user.Name && user.Name != String.Empty);
        }

        private bool IsPasswordCorrect(User user)
        {
            return this.users.Any(u => u.Name == user.Name && u.Password == user.Password);
        }
    }
}
