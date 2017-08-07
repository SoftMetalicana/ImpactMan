namespace ImpactMan.Models.Players
{
    using System;
    using ImpactMan.Attributes;
    using ImpactMan.Constants.Units;
    using ImpactMan.Constants.Utils;
    using ImpactMan.Interfaces.IO.InputListeners;
    using ImpactMan.IO.InputListeners.Events;
    using ImpactMan.Utils;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Concrete implemtation of a Player.
    /// For more information visit the player class.
    /// </summary>
    [MapObject(UnitConstants.PlayerCsvKeyName)]
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
            int calculatedDistance = Movement.CalculateDistanceToAdd(MovementConstants.MovementPixelRatio, gameTime);

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                this.Rectangle = new Rectangle(this.Rectangle.X + calculatedDistance, this.Rectangle.Y, this.Texture.Width, this.Texture.Height);
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                this.Rectangle = new Rectangle(this.Rectangle.X - calculatedDistance, this.Rectangle.Y, this.Texture.Width, this.Texture.Height);
            }

            if (keyboardState.IsKeyDown(Keys.Down))
            {
                this.Rectangle = new Rectangle(this.Rectangle.X, this.Rectangle.Y + calculatedDistance, this.Texture.Width, this.Texture.Height);
            }

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                this.Rectangle = new Rectangle(this.Rectangle.X, this.Rectangle.Y - calculatedDistance, this.Texture.Width, this.Texture.Height);
            }
        }

        /// <summary>
        /// This method is subrscribed to the KeyPressed event and it redirects to the Update method.
        /// </summary>
        /// <param name="sender">The input listener itself.</param>
        /// <param name="eventArgs">Holds basic info of the keyboard state at the moment the event was raised.</param>
        public override void OnKeyPressed(IInputListener sender, KeyPressedEventArgs eventArgs)
        {
            this.Update(eventArgs.GameTime, eventArgs.KeyboardState);
        }
    }
}
