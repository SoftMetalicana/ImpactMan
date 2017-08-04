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
        private Engine engine;
        private MenuCommandFactory menuCommandFacotry;
        private string query;

        public MenuController(string query, Engine engine, MenuCommandFactory menuCommandFactory)
        {
            this.query = query;
            this.engine = engine;
            this.menuCommandFacotry = menuCommandFactory;
        }

        public void Initialize()
        {
            int menuItemsCount = MenuConstants.menuItemLabels[this.query].Count;

            int menuWidth = GetEnumValue("Width");
            int menuHeight = GetEnumValue("Height");

            int menuPaddingTop = GetEnumValue("PaddingTop");
            int menuPaddingLeft = GetEnumValue("PaddingLeft");

            int menuItemHeight = GetEnumValue("ItemHeight");
            int menuItemWidth = GetEnumValue("ItemWidth");

            int menuItemsInbetweenSpace = (menuHeight - menuPaddingTop - menuItemsCount * menuItemHeight) / (menuItemsCount + 1);



            IList<IMenuItem> currentMenuItemsList = new List<IMenuItem>();
            int instantiatedMenuItemsCount = 0;

            foreach (var menuItem in MenuConstants.menuItemLabels[this.query])
            {
                currentMenuItemsList.Add(new MenuItem(menuPaddingLeft,
                    menuPaddingTop + instantiatedMenuItemsCount * menuItemHeight + (instantiatedMenuItemsCount + 1) * menuItemsInbetweenSpace,
                    menuItemWidth,
                    menuItemHeight,
                    menuItem, this.menuCommandFacotry.GetInstance(menuItem, this.engine)));

                instantiatedMenuItemsCount++;
            }

            switch (this.query)
            {
                case "MainMenu":
                    int x = (GraphicsConstants.PreferredBufferWidth - menuWidth) / 2;
                    int y = (GraphicsConstants.PreferredBufferHeight - menuHeight) / 2;

                    this.menu = new MenuHolder(x, y, menuWidth, menuHeight, this.query, currentMenuItemsList);
                    break;
            }            
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

        public int GetEnumValue(string valueType)
        {
            return (int) Enum.Parse(typeof(Menu), $"{this.query}{valueType}");
        }
    }
}
