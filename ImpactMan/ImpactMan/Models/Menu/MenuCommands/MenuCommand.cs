namespace ImpactMan.Models.Menu.MenuCommands
{
    using Context.Models;
    using Core;
    using Interfaces.Core;
    using Interfaces.Models.Menu;
    using Microsoft.Xna.Framework.Content;

    public abstract class MenuCommand : IMenuCommand
    {
        private IEngine engine;
/*        private MenuController menuController;
        private ContentManager content;
        private AccountManager accountManager;
        private User user;*/

        protected MenuCommand(IEngine engine/*, MenuController menuController, ContentManager content, AccountManager accountManager,User user*/)
        {
            this.Engine = engine;
/*            this.MenuController = menuController;
            this.Content = content;
            this.AccountManager = accountManager;
            this.User = user;*/
        }

/*        public AccountManager AccountManager
        {
            get { return this.accountManager; }
            protected set { this.accountManager = value; }
        }

        public User User
        {
            get { return this.user; }
            protected set { this.user = value; }
        }

        public ContentManager Content
        {
            get { return this.content; }
            protected set { this.content = value; }
        }*/

        public IEngine Engine
        {
            get { return engine; }
            protected set { engine = value; }
        }

/*        public MenuController MenuController
        {
            get { return this.menuController; }
            protected set { this.menuController = value; }
        }*/

        public abstract void Execute(User user);      
    }
}
