namespace ImpactMan.Models.Menu
{
    using Context.Models;
    using Interfaces.Models.Menu;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Units;

    /// <summary>
    /// These are the menu buttons. They perfom checks whether the mouse has clicked on them 
    /// and if so they execute the menuCommand they are in posession of.
    /// </summary>
    public class MenuItem : GameControlUnit, IMenuItem
    {
        /// <summary>
        /// This is the command which will be executed if the button is clicked on.
        /// </summary>
        private IMenuCommand menuCommand;

        /// <summary>
        /// This is the current state of the mouse.
        /// </summary>
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

        /// <summary>
        /// In this method the check for mouse click over the button is performed 
        /// and if positive the menuCommand is executed.
        /// </summary>
        /// <param name="gameTime">The current state of game time</param>
        /// <param name="mouseState">The current state of the mouse</param>
        /// <param name="user">The current user</param>
        public override void Update(GameTime gameTime, MouseState mouseState, User user)
        {
            if (mouseState.LeftButton == ButtonState.Pressed && this.oldMouseState.LeftButton == ButtonState.Released
                && this.Rectangle.Contains(mouseState.Position))
            {
                this.MenuCommand.Execute(user);
            }

            this.oldMouseState = Mouse.GetState();
        }
    }
}
