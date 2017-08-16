namespace ImpactMan.Core
{
    using System;
    using System.Linq;
    using Context.Models;
    using ImpactMan.Context.Db;

    /// <summary>
    /// This class takes care of the login and signup processes and the related checks and interaction with the DB.
    /// </summary>
    public class AccountManager
    {
        private ImpactManContext context;

        public AccountManager(ImpactManContext context)
        {
            this.context = context;

            if (context.Users.Local.Count == 0)
            {
                context.Users.Local.Add(new User()
                {
                    Name = "MARIAN",
                    Password = "123"
                });
            }
        }

        public bool Login(User user)
        {
            return this.UserExists(user) && this.IsPasswordCorrect(user);
        }

        public bool Register(User user)
        {
            if (this.UserExists(user))
            {
                return false;
            }

            try
            {
                this.context.Users.Add(user);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool UserExists(User userX)
        {
            if (this.context.Users.Select(u => u.Name).ToList().Contains(userX.Name))
            {
                return true;
            }
            return false;
        }

        private bool IsPasswordCorrect(User user)
        {
            if (this.context.Users.First(u => u.Name == user.Name).Password == user.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
