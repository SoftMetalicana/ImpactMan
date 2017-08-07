using System;
using System.Linq;
using System.Reflection;
using ImpactMan.Attributes;
using ImpactMan.Interfaces.Core;

namespace ImpactMan.Core.Factories
{
    using Context.Models;
    using Interfaces.Models.Menu;
    using Microsoft.Xna.Framework.Content;
    using Models.Menu.MenuCommands;

    public class MenuCommandFactory
    {
        private IEngine engine;
        private ContentManager content;
        private AccountManager accountManager;
        private MenuController menuController;
        private User user;

        public MenuCommandFactory(IEngine engine, ContentManager content, AccountManager accountManager, MenuController menuController, User user)
        {
            this.engine = engine;
            this.content = content;
            this.accountManager = accountManager;
            this.menuController = menuController;
            this.user = user;
        }

        public IMenuCommand GetInstance(string menuItem, MenuController menuController)
        {
            Type type = Type.GetType("ImpactMan.Models.Menu.MenuCommands." + menuItem + "MenuCommand");
            IMenuCommand command = (MenuCommand) Activator.CreateInstance(type, this.engine);

            command = InjectDependencies(command);

            return command;
        }

        public IMenuCommand InjectDependencies(IMenuCommand command)
        {
            FieldInfo[] commandFieldInfos = command.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo[] factoryFieldInfos = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo commandFieldInfo in commandFieldInfos)
            {
                Attribute[] attributes = commandFieldInfo.GetCustomAttributes(typeof(InjectAttribute)).ToArray();

                if (attributes.Length > 0)
                {
                    if (factoryFieldInfos.Any(f => f.FieldType == commandFieldInfo.FieldType))
                    {
                        var value = factoryFieldInfos.Where(f => f.FieldType == commandFieldInfo.FieldType).ToArray()[0]
                            .GetValue(this);

                        commandFieldInfo.SetValue(command, value);
                    }
                }

            }

            return command;
        }
    }
}
