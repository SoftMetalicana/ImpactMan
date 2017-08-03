using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpactMan.Interfaces.Core;
using ImpactMan.Interfaces.Globals;
using ImpactMan.Interfaces.Models.Menu;
using ImpactMan.Models.Menu.MenuCommands;

namespace ImpactMan.Core.Factories
{
    public class MenuCommandFactory
    {

        public IMenuCommand GetInstance(string menuItem, Engine engine)
        {
            IMenuCommand command = null;

            if (menuItem == "NewGame")
            {
                command =  new NewGameMenuCommand(engine);
            }

            else if (menuItem == "ResumeGame")
            {
                command = new ResumeGameMenuCommand(engine);
            }

            else if (menuItem == "Quit")
            {
                command = new QuitMenuCommand(engine);
            }

            return command;
        }
    }
}
