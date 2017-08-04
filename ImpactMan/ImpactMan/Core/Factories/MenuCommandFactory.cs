namespace ImpactMan.Core.Factories
{
    using Context.Models;
    using Interfaces.Models.Menu;
    using Microsoft.Xna.Framework.Content;
    using Models.Menu.MenuCommands;

    public class MenuCommandFactory
    {
        private Engine engine;
        private ContentManager content;
        private AccountManager accountManager;
        private User user;

        public MenuCommandFactory(Engine engine, ContentManager content, AccountManager accountManager, User user)
        {
            this.engine = engine;
            this.content = content;
            this.accountManager = accountManager;
            this.user = user;
        }

        public IMenuCommand GetInstance(string menuItem, MenuController menuController)
        {
            IMenuCommand command = null;

            if (menuItem == "NewGame")
            {
                command =  new NewGameMenuCommand(this.engine, menuController, this.content, this.accountManager, this.user);
            }

            else if (menuItem == "ResumeGame")
            {
                command = new ResumeGameMenuCommand(this.engine, menuController, this.content, this.accountManager, this.user);
            }

            else if (menuItem == "Quit")
            {
                command = new QuitMenuCommand(this.engine, menuController, this.content, this.accountManager, this.user);
            }

            else if (menuItem == "LoginDone")
            {
                command = new LoginDoneMenuCommand(this.engine, menuController, this.content, this.accountManager, this.user);
            }

            else if (menuItem == "RegisterMenuButton")
            {
                command = new RegisterMenuCommand(this.engine, menuController, this.content, this.accountManager, this.user);
            }

            else if (menuItem == "RegisterDone")
            {
                command = new RegisterDoneMenuCommand(this.engine, menuController, this.content, this.accountManager, this.user);
            }

            else if (menuItem == "RegisterBackButton")
            {
                command = new RegisterBackMenuCommand(this.engine, menuController, this.content, this.accountManager, this.user);
            }

            return command;
        }
    }
}
