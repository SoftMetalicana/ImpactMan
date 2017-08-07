namespace ImpactMan.Models.Menu
{
    using Context.Models;
    using Units;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System.Linq;
    using Interfaces.Models.Menu;
    using System.Collections.Generic;

    /// <summary>
    /// This is the object that hold the menu buttons. In most cases it would be the background in menu mode.
    /// </summary>
    public class MenuHolder : GameControlUnit, IMenuHolder
    {
        /// <summary>
        /// This is a collection of the buttons in the menu.
        /// </summary>
        private IList<IMenuItem> menuItems;

        public MenuHolder(int x, int y, int width, int height, string assetName, IList<IMenuItem> menuItems) 
            : this(x, y, width, height, assetName)
        {
            this.MenuItems = menuItems;
        }

        public MenuHolder(int x, int y, int width, int height, string assetName) 
            : base(x, y, width, height, assetName)
        {
        }

        public IList<IMenuItem> MenuItems
        {
            get { return this.menuItems; }
            protected set { this.menuItems = value; }
        }

        public override void Load(ContentManager content)
        {
            this.MenuItems.ToList().ForEach(i => i.Load(content));

            base.Load(content);
        }

        public override void Update(GameTime gameTime, MouseState mouseState, User user)
        {
            this.MenuItems.ToList().ForEach(i => i.Update(gameTime, mouseState, user));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            if (this.MenuItems.Count == 0)
            {
                return;
            }

            this.MenuItems.ToList().ForEach(i => i.Draw(spriteBatch));
        }
    }
}
