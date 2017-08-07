﻿namespace ImpactMan.Utils
{
    using System;
    using Microsoft.Xna.Framework;

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
            return (int)Math.Ceiling(speedRatio * (float)gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}
