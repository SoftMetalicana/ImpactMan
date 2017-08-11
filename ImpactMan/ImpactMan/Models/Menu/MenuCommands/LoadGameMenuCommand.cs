using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpactMan.Context.Models;
using ImpactMan.Interfaces.Core;

namespace ImpactMan.Models.Menu.MenuCommands
{
    class LoadGameMenuCommand : MenuCommand
    {
        public LoadGameMenuCommand(IEngine engine) : base(engine)
        {
        }

        public override void InitializeMenu(User user)
        {
            throw new NotImplementedException();
        }

        public override void ChangeGamestate(User user)
        {
            throw new NotImplementedException();
        }
    }
}
