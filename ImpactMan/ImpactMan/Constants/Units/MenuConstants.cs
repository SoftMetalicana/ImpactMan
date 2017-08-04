using System.Collections.Generic;

namespace ImpactMan.Constants.Units
{
    public static class MenuConstants
    {
        public static readonly Dictionary<string, List<string>> menuItemLabels = new Dictionary<string, List<string>>()
        {
            {"MainMenu", new List<string>()
                {
                    "NewGame",
                    "ResumeGame",
                    "Quit"
                } }
        };
    }
}
