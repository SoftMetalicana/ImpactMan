using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpactMan.Core;
using ImpactMan.Interfaces.Core;
using ImpactMan.Interfaces.Models.Menu;

namespace ImpactMan.Models.Menu.MenuCommands
{
    public abstract class MenuCommand : IMenuCommand
    {
        private IEngine engine;

        protected MenuCommand(IEngine engine)
        {
            this.engine = engine;
        }

        public IEngine Engine
        {
            get { return engine; }
            protected set { engine = value; }
        }

        public abstract void Execute();      
    }
}
