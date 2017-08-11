using Microsoft.Xna.Framework;

namespace ImpactMan.Constants.Units
{
    using System.Collections.Generic;

    public static class MenuConstants
    {
        /// <summary>
        /// This dictionary keeps information about all menus in the game as well as the buttons they hold. 
        /// It is very important that these labels are exactly the same as the names of the images in the content pipeline 
        /// as they are used as asset names when the menus are uploaded.
        /// </summary>
        public static readonly Dictionary<string, List<string>> menuItemLabels = new Dictionary<string, List<string>>()
        {
            {"MainMenu", new List<string>()
            {
                "NewGame",
                "HighScores",
                "Settings",
                "Quit"
            } },

            {"NewGameMenu", new List<string>()
            {
                "NewGame",
                "ResumeGame",
                "Quit"
            } },

            {"LoginMenu", new List<string>()
            {
                "LoginDone",
                "RegisterMenuButton"
            } },

            {"RegisterMenu", new List<string>()
            {
                "RegisterDone",
                "RegisterBackButton"
            } },
            {
                "HighScoresMenu", new List<string>()
                {
                    "HighScoresMenuBackButton"
                }
            }
        };

        /// <summary>
        /// Login menu text postition constants
        /// </summary>
        public const int LoginMenuUsernameX = 530;
        public const int LoginMenuUsernameY = 256;

        public const int LoginMenuPasswordX = 530;
        public const int LoginMenuPasswordY = 310;

        public const int LoginMenuErrorMessageX = 500;
        public const int LoginMenuErrorMessageY = 678;

        /// <summary>
        /// Signup menu text postition constants
        /// </summary>
        public const int SignupMenuUsernameX = 542;
        public const int SignupMenuUsernameY = 263;

        public const int SignupMenuPasswordX = 542;
        public const int SignupMenuPasswordY = 319;

        public const int SignupMenuErrorMessageX = 500;
        public const int SignupMenuErrorMessageY = 678;

        /// <summary>
        /// HighScores menu text postition constants
        /// </summary>
        public const int HighScoresMenuX = 60;
        public const int HighScoresMenuY = 140;

        public const string HighScoresMenuNumberFormat = "### ### ### ### ###";
        public const string HighScoresMenuPlayerFormat = "{0}. {1,-10} {2,15}";
    }
}
