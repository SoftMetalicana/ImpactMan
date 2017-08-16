using ImpactMan.Models.Menu.MenuCommands;

namespace ImpactMan.Core
{
    using Constants.AccountManager;
    using Context.Db;
    using Context.Models;
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

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

public bool ChangePassword(User user, out string message)
       {
           if (user == null)
           {
               throw new ArgumentNullException(Constants.ExceptionMessages.UserNullException);
           }

           var userName = CurrentUser.User.Name;
           if (context.Users.First(u=>u.Name == userName).Password!= user.Name)
           {
               message = AccountManagerConstants.InvalidOldUserPassword;
               return false;
           }

           if (!this.IsPasswordValid(user))
           {
               message = AccountManagerConstants.InvalidUserPassword;
               return false;
           }

           this.context.Users.First(u => u.Name == userName).Password = user.Password;
           this.context.SaveChanges();
           message = AccountManagerConstants.SuccessfulPasswordChange;
           return true;
       }
            private bool UserExists(User user)
        {
            if (this.context.Users.Select(u => u.Name).ToList().Contains(user.Name))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the provided password for the user matches the password from db.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Checks if username matches the pattern.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private bool IsUserNameValid(User user)
        {
            return Regex
                .Match(user.Name, AccountManagerConstants.UserNamePattern)
                .Success;
        }

        /// <summary>
        /// Check if password matches the pattern.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private bool IsPasswordValid(User user)
        {
            return Regex
                .Match(user.Password, AccountManagerConstants.UserPasswordPattern)
                .Success;
        }
    }
}
