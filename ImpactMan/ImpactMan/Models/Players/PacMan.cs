namespace ImpactMan.Models.Players
{
    using ImpactMan.Attributes;
    using ImpactMan.Constants.Units;
    using ImpactMan.Constants.Utils;
    using ImpactMan.Interfaces.IO.InputListeners;
    using ImpactMan.IO.InputListeners.Events;
    using ImpactMan.Models.Players.Events;
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

            int helperX = 0;
            int helperY = 0;
            int helperWidth = 0;
            int helperHeigth = 0;

            int test = this.Points;

            Rectangle desiredRectangle = this.Rectangle;
            // done
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                helperX = this.Rectangle.Right + 1;
                helperY = this.Rectangle.Top + 5;
                helperHeigth = 50;

                desiredRectangle = new Rectangle(this.Rectangle.X + calculatedDistance, this.Rectangle.Y, this.Texture.Width, this.Texture.Height);
            }
            else if (keyboardState.IsKeyDown(Keys.Left))
            {
                helperX = this.Rectangle.Left - 1;
                helperY = this.Rectangle.Top + 5;
                helperHeigth = 50;

                desiredRectangle = new Rectangle(this.Rectangle.X - calculatedDistance, this.Rectangle.Y, this.Texture.Width, this.Texture.Height);
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                helperX = this.Rectangle.Left + 5;
                helperY = this.Rectangle.Bottom + 1;
                helperWidth = 50;

                desiredRectangle = new Rectangle(this.Rectangle.X, this.Rectangle.Y + calculatedDistance, this.Texture.Width, this.Texture.Height);
            }
            else if (keyboardState.IsKeyDown(Keys.Up))
            {
                helperX = this.Rectangle.Left + 5;
                helperY = this.Rectangle.Top - 1;
                helperWidth = 50;

                desiredRectangle = new Rectangle(this.Rectangle.X, this.Rectangle.Y - calculatedDistance, this.Texture.Width, this.Texture.Height);
            }

            Rectangle helperRectangle = new Rectangle(helperX, helperY, helperWidth, helperHeigth);

            this.OnPlayerTriedToMove(new PlayerTriedToMoveEventArgs(desiredRectangle, helperRectangle));
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
