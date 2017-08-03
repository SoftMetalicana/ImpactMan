using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpactMan.Interfaces.Core;

namespace ImpactMan.Models.Menu.MenuCommands
{
    public class ResumeGameMenuCommand : MenuCommand
    {
        public ResumeGameMenuCommand(IEngine engine) : base(engine)
        {
        }

        public override void Execute()
        {
            this.Engine.ChangeGameMenuCurrentStatus();
        }
    }
}
