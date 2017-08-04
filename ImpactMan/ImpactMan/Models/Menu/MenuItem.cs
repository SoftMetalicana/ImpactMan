namespace ImpactMan.Models.Menu
{
    using Context.Models;
    using Units;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Interfaces.Models.Menu;

    public class MenuItem : GameControlUnit, IMenuItem
    {
        private IMenuCommand menuCommand;
        private MouseState oldMouseState;

        public MenuItem(int x, int y, int width, int height, string assetName, IMenuCommand menuCommand) 
            : base(x, y, width, height, assetName)
        {
            this.MenuCommand = menuCommand;
            this.oldMouseState = Mouse.GetState();
        }

        public IMenuCommand MenuCommand
        {
            get { return this.menuCommand; }
            set { this.menuCommand = value; }
        }

        public override void Update(GameTime gameTime, MouseState mouseState, User user)
        {
            if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released
                && this.Rectangle.Contains(mouseState.Position))
            {
                this.MenuCommand.Execute(user);
            }

            this.oldMouseState = Mouse.GetState();
        }
    }
}
