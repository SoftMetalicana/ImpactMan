using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using ImpactMan.Context.Db;

namespace ImpactMan.Core
{
    using System.Collections.Generic;
    using Context.Models;

    /// <summary>
    /// This class takes care of the login and signup processes and the related checks and interaction with the DB.
    /// </summary>
    public class AccountManager
    {
        private ImpactManContext context;

        public AccountManager(ImpactManContext context)
        {
            this.context = context;
            this.context.Users.Add(new User()
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

            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }

            catch (Exception)
            {
                return false;
            }

        }

        private bool UserExists(User userX)
        {
            return this.context.Users.Local.Any(u => u.Name == userX.Name && userX.Name != String.Empty);
        }

        private bool IsPasswordCorrect(User user)
        {
            return this.context.Users.Local.Any(u => u.Name == user.Name && u.Password == user.Password);
        }
    }
}
