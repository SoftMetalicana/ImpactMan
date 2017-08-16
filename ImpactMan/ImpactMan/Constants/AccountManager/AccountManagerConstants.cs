namespace ImpactMan.Constants.AccountManager
{
    public static class AccountManagerConstants
    {
        public const string InvalidUserName =
            "Username should contain only letters and digits and be between 4 and 8 characters long!";

        public const string InvalidUserPassword =
            "Password should contain only letters and digits and be between 5 and 10 characters long!";

        public const string UserAlreadyRegistered = "User already registered!";

        public const string UserNamePattern = @"^[A-Za-z0-1]{4,8}$";

        public const string UserPasswordPattern = @"^[A-Za-z0-1]{5,10}$";
    }
}
