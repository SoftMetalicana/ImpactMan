using ImpactMan.Constants.Graphics;
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

            {"ChangePassword", new List<string>() }
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

        /// <summary>
        /// Settings menu text postition constants
        /// </summary>
        public const int SettingsMenuUsernameX = 530;
        public const int SettingsMenuUsernameY = 256;

        public const int SettingsMenuPasswordX = 530;
        public const int SettingsMenuPasswordY = 310;

        public const int SettingsMenuErrorMessageX = 500;
        public const int SettingsMenuErrorMessageY = 678;

        /// <summary>
        /// Settings menu text postition constants
        /// </summary>
        public const int ChangePasswordMenuUsernameX = 530;
        public const int ChangePasswordMenuUsernameY = 256;

        public const int ChangePasswordMenuPasswordX = 530;
        public const int ChangePasswordMenuPasswordY = 310;

        public const int ChangePasswordMenuErrorMessageX = 500;
        public const int ChangePasswordMenuErrorMessageY = 678;

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


        //Register menu params
        public static readonly int RegisterMenuWidth = MainMenuWidth;
        public static readonly int RegisterMenuHeight = MainMenuHeight;

        public static readonly int RegisterMenuItemWidth = LoginMenuItemWidth;
        public static readonly int RegisterMenuItemHeight = LoginMenuItemHeight;
        
        public static readonly int RegisterMenuPaddingTop =(int)(RegisterMenuHeight/2.3);
        public static readonly int RegisterMenuPaddingLeft = (int)(RegisterMenuWidth/2.2);


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
                                   
        public static readonly int SettingsMenuItemWidth = HighScoresMenuWidth / 13;
        public static readonly int SettingsMenuItemHeight = (int)(SettingsMenuHeight / 23.33);
                                   
        public static readonly int SettingsMenuPaddingTop = (int)(SettingsMenuHeight - 10);
        public static readonly int SettingsMenuPaddingLeft = (int)(SettingsMenuHeight / 23.33);
    }
}
