namespace ImpactMan.Core
{
    using Interfaces.Models.User;

    public static class CurrentUser
    {
        private static int points;
        private static IUser user;

        public static int Points
        {
            get { return points; }
            set { points = value; }
        }

        public static IUser User
        {
            get { return user; }
            set { user = value; }
        }
    }
}
