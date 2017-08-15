using ImpactMan.Constants.Graphics;


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
                "LoadGame",
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
                    "BackButton"
                }
            },

            {"SettingsMenu", new List<string>()
            {
                "ChangePassword",
                "Music",
                "ResetHighScore",
                "BackButton"
            } },

            {
                "ChangePassword", new List<string>()
                {
                    "BackButton"
                }
            }
        };

        /// <summary>

        /// <summary>
        /// Signup menu text postition constants
        /// </summary>

        public static readonly int ErrorMessageY = (int) (GraphicsConstants.PreferredBufferHeight / 1.02);

        //<summary>
        // All menu constants
        //</summary>


        //Main menu params
        public static readonly int MainMenuWidth = GraphicsConstants.PreferredBufferWidth;       
        public static readonly int MainMenuHeight = GraphicsConstants.PreferredBufferHeight - 50;
      
        public static readonly int MainMenuItemWidth = (int)(MainMenuWidth / 3.25);
        public static readonly int MainMenuItemHeight = MainMenuHeight / 14;
        
        public static readonly int MainMenuPaddingTop = MainMenuItemHeight/7;
        public static readonly int MainMenuPaddingLeft = (int)(MainMenuWidth/ 2.888888888888889);


        //Login menu params
        public static readonly int LoginMenuWidth = MainMenuWidth;
        public static readonly int LoginMenuHeight = MainMenuHeight;
        
        public static readonly int LoginMenuItemWidth = LoginMenuWidth/13;
        public static readonly int LoginMenuItemHeight = (int)(LoginMenuHeight/23.33);
        
        public static readonly int LoginMenuPaddingTop = (int)(LoginMenuHeight/2.7);
        public static readonly int LoginMenuPaddingLeft =(int)(LoginMenuWidth/2.2);

        /// Login menu text postition constants              //1300 : 700
        /// </summary>
        public static readonly int LoginMenuUsernameX = (int)(LoginMenuWidth/2.45);
        public static readonly int LoginMenuUsernameY = (int)(LoginMenuHeight / 2.6);

        public static readonly int LoginMenuPasswordX = (int)(LoginMenuWidth / 2.45);
        public static readonly int LoginMenuPasswordY = (int)(LoginMenuHeight / 2.143);

        public static readonly int LoginMenuErrorMessageX = (int)(LoginMenuWidth / 2.6);
        public static readonly int LoginMenuErrorMessageY = ErrorMessageY;


        //Register menu params
        public static readonly int RegisterMenuWidth = MainMenuWidth;
        public static readonly int RegisterMenuHeight = MainMenuHeight;

        public static readonly int RegisterMenuItemWidth = LoginMenuItemWidth;
        public static readonly int RegisterMenuItemHeight = LoginMenuItemHeight;
        
        public static readonly int RegisterMenuPaddingTop =(int)(RegisterMenuHeight/2.3);
        public static readonly int RegisterMenuPaddingLeft = (int)(RegisterMenuWidth/2.2);

        public static readonly int SignupMenuUsernameX = (int)(RegisterMenuWidth/2.4);
        public static readonly int SignupMenuUsernameY = (int)(RegisterMenuHeight/2.53);

        public static readonly int SignupMenuPasswordX = (int)(RegisterMenuWidth / 2.4);
        public static readonly int SignupMenuPasswordY = (int)(RegisterMenuHeight / 2.075);

        public static readonly int SignupMenuErrorMessageX = (int)(RegisterMenuWidth / 2.6);
        public static readonly int SignupMenuErrorMessageY = ErrorMessageY;


        //High score menu params
        public static readonly int HighScoresMenuWidth = MainMenuWidth;
        public static readonly int HighScoresMenuHeight = MainMenuHeight;
     
        public static readonly int HighScoresMenuItemWidth = HighScoresMenuWidth / 13;
        public static readonly int HighScoresMenuItemHeight = (int)(HighScoresMenuHeight / 23.33);

        public static readonly int HighScoresMenuPaddingTop = (int)(HighScoresMenuHeight-10);
        public static readonly int HighScoresMenuPaddingLeft = (int)(HighScoresMenuHeight / 23.33);

        //Settings menu params
        public static readonly int SettingsMenuWidth = MainMenuWidth;
        public static readonly int SettingsMenuHeight = MainMenuHeight;
                                   
        public static readonly int SettingsMenuItemWidth = MainMenuItemWidth;
        public static readonly int SettingsMenuItemHeight = MainMenuItemHeight;

        public static readonly int SettingsMenuPaddingTop = MainMenuPaddingTop;
        public static readonly int SettingsMenuPaddingLeft = MainMenuPaddingLeft;

        //Change Password Menu
        public static readonly int ChangePasswordMenuWidth = MainMenuWidth;
        public static readonly int ChangePasswordMenuHeight = MainMenuHeight;

        public static readonly int ChangePasswordMenuItemWidth = LoginMenuItemWidth;
        public static readonly int ChangePasswordMenuItemHeight = LoginMenuItemHeight;

        public static readonly int ChangePasswordMenuPaddingTop = RegisterMenuPaddingTop;
        public static readonly int ChangePasswordMenuPaddingLeft = RegisterMenuPaddingLeft;

        //public static readonly int SignupMenuUsernameX = (int)(RegisterMenuWidth / 2.4);
        //public static readonly int SignupMenuUsernameY = (int)(RegisterMenuHeight / 2.53);
        //
        //public static readonly int SignupMenuPasswordX = (int)(RegisterMenuWidth / 2.4);
        //public static readonly int SignupMenuPasswordY = (int)(RegisterMenuHeight / 2.075);
        //
        //public static readonly int SignupMenuErrorMessageX = (int)(RegisterMenuWidth / 2.6);
        //public static readonly int SignupMenuErrorMessageY = ErrorMessageY;

        /// <summary>
        /// HighScores menu text postition constants
        /// </summary>
        public static readonly int HighScoresMenuX =(int)(HighScoresMenuWidth/1188.33);
        public static readonly int HighScoresMenuY = (int)(HighScoresMenuHeight/5);

        public static readonly string HighScoresMenuNumberFormat = "### ### ### ### ###";
        public static readonly string HighScoresMenuPlayerFormat = "{0}. {1,-10} {2,15}";
    }
}
