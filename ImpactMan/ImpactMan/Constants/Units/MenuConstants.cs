using System.Collections.Generic;

namespace ImpactMan.Constants.Units
{
    public static class MenuConstants
    {
        public static readonly List<string> menuItemLabels = new List<string>()
        {
            "NewGame",
            "ResumeGame",
            "Quit"
        };

        /// <summary>
        /// The width and height of game menu.
        /// </summary>
        public const int MenuWidth = 600;
        public const int MenuHeight = 600;

        /// <summary>
        /// Coordinates of the game menu so that it is centered.
        /// </summary>
        public const int X = (Graphics.GraphicsConstants.PreferredBufferWidth - MenuWidth) / 2;
        public const int Y = (Graphics.GraphicsConstants.PreferredBufferHeight - MenuHeight) / 2;

        /// <summary>
        /// The width and height of game menuItems.
        /// </summary>
        public const int MenuItemWidth = 150;
        public const int MenuItemHeight = 50;

        public const int MenuPaddingTop = 155;
        public const int MenuPaddingLeft = 580;
    }
}
