namespace ImpactMan.Core
{
    using Interfaces.Models.User;

    public static class CurrentUser
    {
        private static IUser user;

        public static IUser User
        {
            get { return user; }
            set { user = value; }
        }
    }
}
