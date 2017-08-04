using System;
using System.Linq;
using ImpactMan.Models.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ImpactMan.Models.Menu
{
    using System.Collections.Generic;
    using Interfaces.Models.Menu;

    public class MenuHolder : GameControlUnit, IMenuHolder
    {
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

        public override void Update(GameTime gameTime, MouseState mouseState)
        {
            this.MenuItems.ToList().ForEach(i => i.Update(gameTime, mouseState));
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
