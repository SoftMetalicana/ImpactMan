namespace ImpactMan.Constants.Units
{
    using System.Collections.Generic;

    public static class MenuConstants
    {
        public static readonly Dictionary<string, List<string>> menuItemLabels = new Dictionary<string, List<string>>()
        {
            {"MainMenu", new List<string>()
            {
                "NewGame",
                "ResumeGame",
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
