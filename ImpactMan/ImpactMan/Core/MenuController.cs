using ImpactMan.Constants.Graphics;
using ImpactMan.Constants.Units;
using ImpactMan.Core.Factories;
using ImpactMan.Enumerations.Menu;
using ImpactMan.Interfaces.IO.InputListeners;
using ImpactMan.Interfaces.Models.Menu;
using ImpactMan.IO.InputListeners.Events;
using ImpactMan.Models.Menu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace ImpactMan.Core
{
    public class MenuController
    {
        private MenuHolder menu;
        private MenuCommandFactory menuCommandFactory;

        public MenuController(MenuCommandFactory menuCommandFactory)
        {
            this.menuCommandFactory = menuCommandFactory;
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
            this.Update(eventArgs.GameTime, eventArgs.MouseState);
        }

        public void Load(ContentManager content)
        {
            this.menu.Load(content);
        }

        public void Update(GameTime gameTime, MouseState mouseState)
        {

            this.menu.Update(gameTime, mouseState);


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
