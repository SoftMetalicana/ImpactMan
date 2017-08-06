using System;
using System.Reflection;

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
            Type type = Type.GetType("ImpactMan.Models.Menu.MenuCommands." + menuItem + "MenuCommand");
            IMenuCommand command = (MenuCommand) Activator.CreateInstance(type, this.engine, menuController, this.content,
                this.accountManager, this.user);

            return command;
        }
    }
}
