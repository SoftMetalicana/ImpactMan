namespace ImpactMan.Core
{
    using System.Collections.Generic;
    using Constants.Graphics;
    using Constants.Units;
    using Context.Models;
    using Factories;
    using Interfaces.Core;
    using Interfaces.IO.InputListeners;
    using Interfaces.Models.Menu;
    using IO.InputListeners.Events;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Models.Menu;

    /// <summary>
    /// This class takes care of the menus and buttons.
    /// </summary>
    public class MenuInitializer
    {
        private IEngine engine;
        private AccountManager accountManager;
        private ContentManager content;
        private MenuHolder menu;
        private MenuCommandFactory menuCommandFactory;
        private SoundManager soundManager;
        private bool isUserLoggedIn;

        public MenuInitializer(IEngine engine, ContentManager content, AccountManager accountManager, SoundManager soundManager)
        {
            this.engine = engine;
            this.content = content;
            this.accountManager = accountManager;
            this.soundManager = soundManager;
            this.menuCommandFactory = new MenuCommandFactory(this.engine, this.content, this.accountManager, this, this.soundManager);
        }

        /// <summary>
        /// Menes are initialized based on queries from other classes and methods (most of execution of MenuCommands)
        /// </summary>
        /// <param name="query">This is the name of the menu that will be loaded. 
        /// It should exactly match the name in the MenuConstants class menuItemLabels dictionary</param>
        public void Initialize(string query)
        {
            bool currentMenuContainsMenuItems = MenuConstants.MenuItemLabels.ContainsKey(query);

            int menuItemsCount = currentMenuContainsMenuItems
                ? MenuConstants.MenuItemLabels[query].Count
                : 0;

            int menuWidth = this.GetEnumValue(query, "Width");
            int menuHeight = this.GetEnumValue(query, "Height");

            int menuPaddingTop = this.GetEnumValue(query, "PaddingTop");
            int menuPaddingLeft = this.GetEnumValue(query, "PaddingLeft");

            int menuItemHeight = this.GetEnumValue(query, "ItemHeight");
            int menuItemWidth = this.GetEnumValue(query, "ItemWidth");

            int menuItemsInbetweenSpace = (menuHeight - menuPaddingTop - (menuItemsCount * menuItemHeight)) / (menuItemsCount + 1);

            IList<IMenuItem> currentMenuItemsList = new List<IMenuItem>();
            int instantiatedMenuItemsCount = 0;

            if (currentMenuContainsMenuItems)
            {
                foreach (var menuItem in MenuConstants.MenuItemLabels[query])
                {
                    currentMenuItemsList.Add(new MenuItem(menuPaddingLeft,
                        menuPaddingTop + (instantiatedMenuItemsCount * menuItemHeight) + (instantiatedMenuItemsCount + 1) * menuItemsInbetweenSpace,
                        menuItemWidth,
                        menuItemHeight,
                        menuItem, this.menuCommandFactory.GetInstance(menuItem, this)));

                    instantiatedMenuItemsCount++;
                }
            }

            int x = (GraphicsConstants.PreferredBufferWidth - menuWidth) / 2;
            int y = (GraphicsConstants.PreferredBufferHeight - menuHeight) / 2;

            this.menu = new MenuHolder(x, y, menuWidth, menuHeight, query, currentMenuItemsList);
        }

        /// <summary>
        /// When the mouse is clicked this method is invoked thru an event handler. 
        /// This method on its part then invokes the update method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public void OnMouseClicked(IInputListener sender, MouseClickedEventArgs eventArgs)
        {
            this.Update(eventArgs.GameTime, eventArgs.MouseState, eventArgs.User);
        }

        public void Load(ContentManager content)
        {
            this.menu.Load(content);
        }

        public void Update(GameTime gameTime, MouseState mouseState, User user)
        {
            this.menu.Update(gameTime, mouseState, user);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.menu.Draw(spriteBatch);
        }

        public int GetEnumValue(string query, string valueType)
        {
            var type = (int)typeof(MenuConstants).GetField($"{query}{valueType}").GetValue(null);

            return type;
        }
    }
}
