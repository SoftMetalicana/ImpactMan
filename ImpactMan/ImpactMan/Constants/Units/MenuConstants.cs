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
            } }
        };
    }
}
