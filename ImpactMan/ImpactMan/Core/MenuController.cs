using System.Collections;
using System.Collections.Generic;
using ImpactMan.Constants.Units;
using ImpactMan.Core.Factories;
using ImpactMan.Interfaces.Globals;
using ImpactMan.Interfaces.IO.InputListeners;
using ImpactMan.IO.InputListeners.Events;
using ImpactMan.Models.Menu;
using ImpactMan.Models.Menu.MenuCommands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ImpactMan.Core
{
    public class MenuController
    {
        private IUnit menu;
        private IList<MenuItem> menuItems;
        private Engine engine;
        private MenuCommandFactory menuCommandFacotry;

        public MenuController(Engine engine, MenuCommandFactory menuCommandFactory)
        {
            this.menuItems = new List<MenuItem>();
            this.engine = engine;
            this.menuCommandFacotry = menuCommandFactory;
        }

        public void Initialize()
        {
            this.menu = new Menu(MenuConstants.X, MenuConstants.Y, MenuConstants.MenuWidth, MenuConstants.MenuHeight, nameof(menu));

            int menuItemsInbetweenSpace = (MenuConstants.MenuHeight - MenuConstants.MenuPaddingTop -
                                           MenuConstants.menuItemLabels.Count * MenuConstants.MenuItemHeight) /
                                          (MenuConstants.menuItemLabels.Count + 1);

            int instantiatedMenuItemsCount = 0;

            foreach (var menuItem in MenuConstants.menuItemLabels)
            {
                menuItems.Add(new MenuItem(MenuConstants.MenuPaddingLeft, 
                    MenuConstants.MenuPaddingTop + instantiatedMenuItemsCount * MenuConstants.MenuItemHeight + (instantiatedMenuItemsCount + 1) * menuItemsInbetweenSpace, 
                    MenuConstants.MenuItemWidth, 
                    MenuConstants.MenuItemHeight, 
                    menuItem, this.menuCommandFacotry.GetInstance(menuItem, this.engine)));

                instantiatedMenuItemsCount++;
            }
        }

        public void OnMouseClicked(IInputListener sender, MouseClickedEventArgs eventArgs)
        {
            this.Update(eventArgs.GameTime, eventArgs.MouseState);
        }

        public void Update(GameTime gameTime, MouseState mouseState)
        {
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                foreach (var menuItem in menuItems)
                {
                    if (menuItem.Rectangle.Contains(mouseState.Position))
                    {
                        menuItem.MenuCommand.Execute();
                    }
                }
            }
        }

        public void Load(ContentManager content)
        {
            this.menu.Load(content);

            foreach (var menuItem in menuItems)
            {
                menuItem.Load(content);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            menu.Draw(spriteBatch);

            foreach (var menuItem in menuItems)
            {
                menuItem.Draw(spriteBatch);
            }
        }
    }
}
