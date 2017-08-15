using System.Collections.Generic;
using ImpactMan.Enumerations.Game;
using Microsoft.Xna.Framework;

namespace ImpactMan.Constants.Utils
{
    /// <summary>
    /// Provides constants for the Utils.Movement static class.
    /// If a method from the static class wants a variable there is a high chance of finding it here.
    /// </summary>
    public static class MovementConstants
    {
        /// <summary>
        /// With this variable you can control the speed of the moving objects in the game.
        /// Higher value is for higher speed and lower value is for lower.
        /// </summary>
        public const int MovementPixelRatio = 240;

        public static readonly Dictionary<EnemyMovingDirections, Vector2> directions = new Dictionary<EnemyMovingDirections, Vector2>
        {
            {EnemyMovingDirections.Down, new Vector2(0, 1) },
            {EnemyMovingDirections.Up, new Vector2(0, -1) },
            {EnemyMovingDirections.Left, new Vector2(-1, 0) },
            {EnemyMovingDirections.Right, new Vector2(1, 0) }
        };
    }
}
