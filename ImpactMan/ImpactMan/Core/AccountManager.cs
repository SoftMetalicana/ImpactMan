using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text.RegularExpressions;
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
        }

        public bool Login(User user)
        {
            return UserExists(user) && IsPasswordCorrect(user);
        }

        public bool Register(User user, out string message)
        {
            message = String.Empty;

            if (!IsUserNameValid(user))
            {
                message =
                    "Username should contain only letters and digits and be between 4 and 8 characters long!";
                return false;
            }

            if (!IsPasswordValid(user))
            {
                message =
                    "Password should contain only letters and digits and be between 5 and 10 characters long!";
                return false;
            }

            if (UserExists(user))
            {
                message =
                    "User already registered!";
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

        private bool UserExists(User user)
        {
            if (this.context.Users.Select(u => u.Name).ToList().Contains(user.Name))
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

        private bool IsUserNameValid(User user)
        {
            string userNamePattern = @"^[A-Za-z0-1]{4,8}$";

            if (Regex.Match(user.Name, userNamePattern).Success)
            {
                return true;
            }

            return false;
        }

        private bool IsPasswordValid(User user)
        {
            string userPasswordPattern = @"^[A-Za-z0-1]{5,10}$";

            if (Regex.Match(user.Password, userPasswordPattern).Success)
            {
                return true;
            }

            return false;
        }
    }
}
