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
        }

        public bool Login(User user)
        {
            return users.Contains(user);
        }

        public bool Register(User user)
        {
            if (users.Contains(user))
            {
                return false;
            }

            users.Add(user);
            return true;
        }
    }
}
