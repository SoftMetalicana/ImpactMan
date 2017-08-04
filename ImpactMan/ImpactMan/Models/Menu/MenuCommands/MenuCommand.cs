using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpactMan.Core;
using ImpactMan.Interfaces.Core;
using ImpactMan.Interfaces.Models.Menu;
using Microsoft.Xna.Framework.Content;

namespace ImpactMan.Models.Menu.MenuCommands
{
    public abstract class MenuCommand : IMenuCommand
    {
        private IEngine engine;
        private MenuController menuController;
        private ContentManager content;

        protected MenuCommand(IEngine engine, MenuController menuController, ContentManager content)
        {
            this.Engine = engine;
            this.MenuController = menuController;
            this.Content = content;
        }

        public ContentManager Content
        {
            get { return this.content; }
            protected set { this.content = value; }
        }

        public IEngine Engine
        {
            get { return engine; }
            protected set { engine = value; }
        }

        public MenuController MenuController
        {
            get { return this.menuController; }
            protected set { this.menuController = value; }
        }

        public abstract void Execute();      
    }
}
