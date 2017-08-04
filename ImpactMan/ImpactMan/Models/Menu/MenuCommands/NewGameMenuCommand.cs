using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpactMan.Core;
using ImpactMan.Interfaces.Core;
using Microsoft.Xna.Framework.Content;

namespace ImpactMan.Models.Menu.MenuCommands
{
    public class NewGameMenuCommand : MenuCommand
    {
        public NewGameMenuCommand(IEngine engine, MenuController menuController, ContentManager content) 
            : base(engine, menuController, content)
        {
        }

        public override void Execute()
        {
            this.MenuController.Initialize("NewGameMenu");
            this.MenuController.Load(this.Content);
        }
    }
}
