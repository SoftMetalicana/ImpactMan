using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpactMan.Interfaces.Core;

namespace ImpactMan.Models.Menu.MenuCommands
{
    public class QuitMenuCommand : MenuCommand
    {
        public QuitMenuCommand(IEngine engine) : base(engine)
        {
        }

        public override void Execute()
        {
            this.Engine.Quit();
        }
    }
}
