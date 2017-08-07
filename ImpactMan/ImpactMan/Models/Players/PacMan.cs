namespace ImpactMan.Models.Players
{
    using ImpactMan.Constants.Units;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Concrete implemtation of a Player.
    /// For more information visit the player class.
    /// </summary>
    public class PacMan : Player
    {
        /// <summary>
        /// Instantiates the object.
        /// </summary>
        /// <param name="x">The x coordinates of the object on the map/window/console</param>
        /// <param name="y">The y coordinates of the object on the map/window/console</param>
        public PacMan(int x, int y)
            : this(x, y, UnitConstants.PlayerAssetName)
        {
        }

        /// <summary>
        /// Instantiates the object.
        /// </summary>
        /// <param name="x">The x coordinates of the object on the map/window/console</param>
        /// <param name="y">The y coordinates of the object on the map/window/console</param>
        /// <param name="assetName">The name of the picture that is loaded from the pipeline.</param>
        public PacMan(int x, int y, string assetName) 
            : base(x, y, assetName)
        {
        }

        /// <summary>
        /// When a key is pressed this method is trigerred and you should take care of the player condition.
        /// This method raises an event for the Mediator which takes care for the player.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="keyboardState"></param>
        public override void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                this.Rectangle = new Rectangle(this.Rectangle.X + 5, this.Rectangle.Y, this.Texture.Width, this.Texture.Height);
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                this.Rectangle = new Rectangle(this.Rectangle.X - 5, this.Rectangle.Y, this.Texture.Width, this.Texture.Height);
            }

            if (keyboardState.IsKeyDown(Keys.Down))
            {
                this.Rectangle = new Rectangle(this.Rectangle.X, this.Rectangle.Y + 5, this.Texture.Width, this.Texture.Height);
            }

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                this.Rectangle = new Rectangle(this.Rectangle.X, this.Rectangle.Y - 5, this.Texture.Width, this.Texture.Height);
            }
        }
    }
}
