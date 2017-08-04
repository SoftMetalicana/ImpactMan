using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpactMan.Interfaces.Core;
using ImpactMan.Interfaces.Globals;
using ImpactMan.Interfaces.Models.Menu;
using ImpactMan.Models.Menu.MenuCommands;
using Microsoft.Xna.Framework.Content;

namespace ImpactMan.Core.Factories
{
    public class MenuCommandFactory
    {
        private Engine engine;
        private ContentManager content;

        public MenuCommandFactory(Engine engine, ContentManager content)
        {
            this.engine = engine;
            this.content = content;
        }

        public IMenuCommand GetInstance(string menuItem, MenuController menuController)
        {
            IMenuCommand command = null;

            if (menuItem == "NewGame")
            {
                command =  new NewGameMenuCommand(engine, menuController, content);
            }

            else if (menuItem == "ResumeGame")
            {
                command = new ResumeGameMenuCommand(engine, menuController, content);
            }

            else if (menuItem == "Quit")
            {
                command = new QuitMenuCommand(engine, menuController, content);
            }

            return command;
        }
    }
}
