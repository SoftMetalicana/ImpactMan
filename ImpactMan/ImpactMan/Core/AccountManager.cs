﻿using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text.RegularExpressions;
using ImpactMan.Constants.AccountManager;
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
                    AccountManagerConstants.InvalidUserName;
                return false;
            }

            if (!IsPasswordValid(user))
            {
                message =
                    AccountManagerConstants.InvalidUserPassword;
                return false;
            }

            if (UserExists(user))
            {
                message =
                    AccountManagerConstants.UserAlreadyRegistered;
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
            return Regex
                .Match(user.Name, AccountManagerConstants.UserNamePattern)
                .Success;
        }

        private bool IsPasswordValid(User user)
        {
            return Regex
                .Match(user.Password, AccountManagerConstants.UserPasswordPattern)
                .Success;
        }
    }
}
