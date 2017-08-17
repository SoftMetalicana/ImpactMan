namespace ImpactMan.Utils
{
    using System;
    using ImpactMan.Constants.Utils;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Utils class that provides needed formulas for fluid movement of the objects.
    /// Make sure that if you want to move an object you use this class so everything in the game
    /// moves with the same speed and in the same motion.
    /// </summary>
    public static class Movement
    {
        /// <summary>
        /// Formula that calculates the distance to add to the current position of the object.
        /// When you get the result you just add it to object.Rectangle.X 
        /// if you want to move to the right or subtract it for moving to the left.
        /// If you want to move up or down you should add or subtract from object.Rectangle.Y
        /// </summary>
        /// <param name="speedRatio">Can be taken from the Constants.Utils.MovementConstants class.</param>
        /// <param name="gameTime">Can be taken from the Engine.</param>
        /// <returns>The value that you must add to obj.Rectangle.X or obj.Rectangle.Y</returns>
        public static int CalculateDistanceToAdd(int speedRatio, GameTime gameTime)
        {
            return (int)Math.Ceiling(speedRatio * gameTime.ElapsedGameTime.TotalSeconds);
        }

        public static (Rectangle desiredPosition, Rectangle helperRectangle) CalculateDesiredAndHelperRectangle(Rectangle currentRec,
                                                                                                                Texture2D currentTex,
                                                                                                                GameTime gameTime,
                                                                                                                KeyboardState keyboardState)
        {
            int calculatedDistance = Movement.CalculateDistanceToAdd(MovementConstants.MovementPixelRatio, gameTime);

            int helperX = 0;
            int helperY = 0;
            int helperWidth = 0;
            int helperHeigth = 0;

            Rectangle desiredRectangle = currentRec;
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                helperX = currentRec.Right + 1;
                helperY = currentRec.Top + 5;
                helperHeigth = 50;

                desiredRectangle = new Rectangle(currentRec.X + calculatedDistance, currentRec.Y, currentTex.Width, currentTex.Height);
            }
            else if (keyboardState.IsKeyDown(Keys.Left))
            {
                helperX = currentRec.Left - 1;
                helperY = currentRec.Top + 5;
                helperHeigth = 50;

                desiredRectangle = new Rectangle(currentRec.X - calculatedDistance, currentRec.Y, currentTex.Width, currentTex.Height);
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                helperX = currentRec.Left + 5;
                helperY = currentRec.Bottom + 1;
                helperWidth = 50;

                desiredRectangle = new Rectangle(currentRec.X, currentRec.Y + calculatedDistance, currentTex.Width, currentTex.Height);
            }
            else if (keyboardState.IsKeyDown(Keys.Up))
            {
                helperX = currentRec.Left + 5;
                helperY = currentRec.Top - 1;
                helperWidth = 50;

                desiredRectangle = new Rectangle(currentRec.X, currentRec.Y - calculatedDistance, currentTex.Width, currentTex.Height);
            }

            Rectangle helperRectangle = new Rectangle(helperX, helperY, helperWidth, helperHeigth);

            return (desiredRectangle, helperRectangle);
        }
    }
}
