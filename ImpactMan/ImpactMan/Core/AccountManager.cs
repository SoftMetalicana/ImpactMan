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
            if (this.context.Users.Select(u => u.Name).ToList().Contains(userX.Name))
            {
                return true;
            }
            return false;
        }

        private bool IsPasswordCorrect(User user)
        {
            if (this.context.Users.Where(u => u.Name == user.Name).First().Password == user.Password)
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
