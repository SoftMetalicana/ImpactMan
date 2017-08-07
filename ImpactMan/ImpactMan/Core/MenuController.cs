using ImpactMan.Interfaces.Core;

namespace ImpactMan.Core
{
    using Constants.Graphics;
    using Constants.Units;
    using Context.Models;
    using Factories;
    using Enumerations.Menu;
    using Interfaces.IO.InputListeners;
    using Interfaces.Models.Menu;
    using IO.InputListeners.Events;
    using Models.Menu;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System;
    using System.Collections.Generic;

    public class MenuController
    {
        private IEngine engine;
        private AccountManager accountManager;
        private ContentManager content;
        private User user;
        private MenuHolder menu;
        private MenuCommandFactory menuCommandFactory;
        private bool isUserLoggedIn;

        public MenuController(IEngine engine, ContentManager content, AccountManager accountManager, User user)
        {
            this.engine = engine;
            this.content = content;
            this.accountManager = accountManager;
            this.user = user;
            this.menuCommandFactory = new MenuCommandFactory(this.engine, this.content, this.accountManager, this, this.user);
        }

        public void Initialize(string query)
        {
            bool currentMenuContainsMenuItems = MenuConstants.menuItemLabels.ContainsKey(query);

            int menuItemsCount = currentMenuContainsMenuItems
                ? MenuConstants.menuItemLabels[query].Count 
                : 0;

            int menuWidth = GetEnumValue(query, "Width");
            int menuHeight = GetEnumValue(query, "Height");

            int menuPaddingTop = GetEnumValue(query, "PaddingTop");
            int menuPaddingLeft = GetEnumValue(query, "PaddingLeft");

            int menuItemHeight = GetEnumValue(query, "ItemHeight");
            int menuItemWidth = GetEnumValue(query, "ItemWidth");

            int menuItemsInbetweenSpace = (menuHeight - menuPaddingTop - menuItemsCount * menuItemHeight) / (menuItemsCount + 1);

            IList<IMenuItem> currentMenuItemsList = new List<IMenuItem>();
            int instantiatedMenuItemsCount = 0;

            if (currentMenuContainsMenuItems)
            {
                foreach (var menuItem in MenuConstants.menuItemLabels[query])
                {
                    currentMenuItemsList.Add(new MenuItem(menuPaddingLeft,
                        menuPaddingTop + instantiatedMenuItemsCount * menuItemHeight + (instantiatedMenuItemsCount + 1) * menuItemsInbetweenSpace,
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
            menu.Draw(spriteBatch);
        }

        public int GetEnumValue(string query, string valueType)
        {
            return (int)Enum.Parse(typeof(Menu), $"{query}{valueType}");
        }
    }
}
