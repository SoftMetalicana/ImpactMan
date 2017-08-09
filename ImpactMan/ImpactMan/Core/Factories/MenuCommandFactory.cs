namespace ImpactMan.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Attributes;
    using Interfaces.Core;
    using Context.Models;
    using Interfaces.Models.Menu;
    using Microsoft.Xna.Framework.Content;
    using Models.Menu.MenuCommands;

    /// <summary>
    /// This factory is used when menus are instantiated by MenuController class. Each menuItem keeps an IMenuCommand as a field 
    /// which command is executed if/when the button is clicked on.
    /// </summary>
    public class MenuCommandFactory
    {
        private IEngine engine;
        private ContentManager content;
        private AccountManager accountManager;
        private MenuInitializer menuController;
        private SoundManager soundManager;

        public MenuCommandFactory(IEngine engine, ContentManager content, AccountManager accountManager, MenuInitializer menuController, SoundManager soundManager)
        {
            this.engine = engine;
            this.content = content;
            this.accountManager = accountManager;
            this.menuController = menuController;
            this.soundManager = soundManager;
        }

        /// <summary>
        /// An instance of IMenuCommand is created depending on the type of menuItem.
        /// </summary>
        /// <param name="menuItem">Menu button</param>
        /// <param name="menuController">This is the class that loads and manages the menus</param>
        /// <returns></returns>
        public IMenuCommand GetInstance(string menuItem, MenuInitializer menuController)
        {
            Type type = Type.GetType("ImpactMan.Models.Menu.MenuCommands." + menuItem + "MenuCommand");
            IMenuCommand command = (MenuCommand) Activator.CreateInstance(type, this.engine);

            command = InjectDependencies(command);

            return command;
        }

        /// <summary>
        /// IMenuCommands are passed to this method so that private fields are injected.
        /// </summary>
        /// <param name="command">IMenuCommand type</param>
        /// <returns></returns>
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
