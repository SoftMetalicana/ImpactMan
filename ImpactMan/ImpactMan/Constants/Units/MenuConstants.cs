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



        //<summary>
        // All menu constants
        //</summary>

        
        //Main menu params
        public static readonly int MainMenuWidth = GraphicsConstants.PreferredBufferWidth;       
        public static readonly int MainMenuHeight = GraphicsConstants.PreferredBufferHeight - 50;
      
        public static readonly int MainMenuItemWidth = (int)(MainMenuWidth / 3.25);
        public static readonly int MainMenuItemHeight = MainMenuHeight / 14;
        
        public static readonly int MainMenuPaddingTop = MainMenuItemHeight * 4;
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



        /// <summary>
        /// Text alignment rates at different screen resolution
        /// </summary>
        private static readonly double TextPositionAlignmentWidth = (GraphicsConstants.PreferredBufferWidth / 1920.0);
        private static readonly double TextPositionAlignmentHeight = (GraphicsConstants.PreferredBufferHeight / 1080.0);


        /// <summary>
        /// Login menu text postition constants
        /// </summary>
        public static readonly int LoginMenuUsernameX = (int)(781 * TextPositionAlignmentWidth);
        public static readonly int LoginMenuUsernameY = (int)(397 * TextPositionAlignmentHeight);

        public static readonly int LoginMenuPasswordX = (int)(781 * TextPositionAlignmentWidth);
        public static readonly int LoginMenuPasswordY = (int)(483 * TextPositionAlignmentHeight);

        public static readonly int LoginMenuErrorMessageX = (int)(768 * TextPositionAlignmentWidth);
        public static readonly int LoginMenuErrorMessageY = (int)(1056 * TextPositionAlignmentHeight);

        /// <summary>
        /// Signup menu text postition constants
        /// </summary>
        public static readonly int SignupMenuUsernameX = (int)(797 * TextPositionAlignmentWidth);
        public static readonly int SignupMenuUsernameY = (int)(406 * TextPositionAlignmentHeight);

        public static readonly int SignupMenuPasswordX = (int)(797 * TextPositionAlignmentWidth);
        public static readonly int SignupMenuPasswordY = (int)(496 * TextPositionAlignmentHeight);

        public static readonly int SignupMenuErrorMessageX = (int)(820 * TextPositionAlignmentWidth);
        public static readonly int SignupMenuErrorMessageY = (int)(1056 * TextPositionAlignmentHeight);

        /// <summary>
        /// HighScores menu text postition constants
        /// </summary>
        public const int HighScoresMenuX = 60;
        public const int HighScoresMenuY = 140;

        public const string HighScoresMenuNumberFormat = "### ### ### ### ###";
        public const string HighScoresMenuPlayerFormat = "{0}. {1,-10} {2,15}";
    }
}
