using ImpactMan.Utils;

namespace ImpactMan.Models.Enemies
{
    using Constants.Utils;
    using Enumerations.Game;
    using Attributes;
    using Consequences;
    using Constants.Consequential;
    using Constants.Units;
    using Interfaces.Models.Enemies;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using System;

    /// <summary>
    /// Concrete implementation of the enemy.
    /// For more info visit the classes and interfaces it inherits.
    /// </summary>
    [MapObject(UnitConstants.EnemyCsvKeyName)]
    public class Enemy : Consequential, IEnemy
    {
        private EnemyMovingDirections currentDirection;

        /// <summary>
        /// Instantiates the enemy.
        /// </summary>
        /// <param name="x">The x coordinates of the object on the console/map/window.</param>
        /// <param name="y">The y coordinates of the object on the console/map/window.</param>
        public Enemy(int x, int y)
            : this(x, y, UnitConstants.EnemyAssetName)
        {
        }

        /// <summary>
        /// Instantiates the enemy.
        /// </summary>
        /// <param name="x">The x coordinates of the object on the console/map/window.</param>
        /// <param name="y">The y coordinates of the object on the console/map/window.</param>
        /// <param name="assetName">The name of the picure that is loaded from the pipeline.</param>
        public Enemy(int x, int y, string assetName)
            : this(x, y, assetName, ConsequentialConstants.EnemyBonusPoints)
        {
        }

        /// <summary>
        /// Instantiates the enemy.
        /// </summary>
        /// <param name="x">The x coordinates of the object on the console/map/window.</param>
        /// <param name="y">The y coordinates of the object on the console/map/window.</param>
        /// <param name="assetName">The name of the picure that is loaded from the pipeline.</param>
        /// <param name="bonusPoints">he bonus points that you want to give to the player.</param>
        public Enemy(int x, int y, string assetName, int bonusPoints)
            : base(x, y, assetName, bonusPoints)
        {
            this.currentDirection = EnemyMovingDirections.Down;
        }

        /// <summary>
        /// Encapsulates logic for the state change of the object before it is drawn.
        /// </summary>
        /// <param name="gameTime">Can be taken from the engine.</param>
        /// <param name="keyboardState">Can be taken from the engine.</param>
        public override void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            //bool directionShouldChange = true;

            //if (directionShouldChange)
            //{
            //    currentDirection = (EnemyMovingDirections) (rnd.Next() % 3);
            //}

            //int calculatedDistance = Movement.CalculateDistanceToAdd(MovementConstants.MovementPixelRatio, gameTime);

            //Vector2 displacement = MovementConstants.directions[currentDirection];
            //Rectangle rect = this.Rectangle;

            //this.Rectangle = new Rectangle(
            //    (int) (rect.X + displacement.X * calculatedDistance), 
            //    (int) (rect.Y + displacement.Y * calculatedDistance), rect.Width,
            //    rect.Height);
        }
    }
}