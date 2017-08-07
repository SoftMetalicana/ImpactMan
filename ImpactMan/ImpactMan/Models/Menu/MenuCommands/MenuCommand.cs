namespace ImpactMan.Models.Menu.MenuCommands
{
    using Context.Models;
    using Interfaces.Core;
    using Interfaces.Models.Menu;

    public abstract class MenuCommand : IMenuCommand
    {
        private IEngine engine;

        protected MenuCommand(IEngine engine)
        {
            this.Engine = engine;
        }

        public IEngine Engine
        {
            get { return engine; }
            protected set { engine = value; }
        }

        public abstract void Execute(User user);      
    }
}
