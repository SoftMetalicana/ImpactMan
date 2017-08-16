namespace ImpactMan.Core
{
    using Constants.AccountManager;
    using Context.Db;
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
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
        }

        public bool Login(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(Constants.ExceptionMessages.UserNullException);
            }

            if (UserExists(user) && IsPasswordCorrect(user))
            {
                CurrentUser.User = user;

                return true;
            }

            return false;
        }

        public bool Register(User user, out string message)
        {
            if (user == null)
            {
                throw new ArgumentNullException(Constants.ExceptionMessages.UserNullException);
            }

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
                this.context.Users.Add(user);
                this.context.SaveChanges();
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
            if (this.context.Users.First(u => u.Name == user.Name).Password == user.Password)
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
