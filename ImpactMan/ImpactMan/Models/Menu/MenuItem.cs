using System.ComponentModel.DataAnnotations;
using ImpactMan.Models.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ImpactMan.Models.Menu
{
    using Interfaces.Models.Menu;

    public class MenuItem : GameControlUnit, IMenuItem
    {
        private IMenuCommand menuCommand;

        public MenuItem(int x, int y, int width, int height, string assetName, IMenuCommand menuCommand) 
            : base(x, y, width, height, assetName)
        {
            this.MenuCommand = menuCommand;
        }

        public IMenuCommand MenuCommand
        {
            get { return this.menuCommand; }
            set { this.menuCommand = value; }
        }

        public override void Update(GameTime gameTime, MouseState mouseState)
        {
            if (mouseState.LeftButton == ButtonState.Pressed 
                && this.Rectangle.Contains(mouseState.Position))
            {
                this.MenuCommand.Execute();
            }
        }
    }
}
