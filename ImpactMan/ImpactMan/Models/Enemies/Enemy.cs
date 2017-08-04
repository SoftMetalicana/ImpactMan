﻿namespace ImpactMan.Models.Enemies
{
    using System;
    using Consequences;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Constants.Consequential;
    using Interfaces.Models.Enemies;

    /// <summary>
    /// Concrete implementation of the enemy.
    /// For more info visit the classes and interfaces it inherits.
    /// </summary>
    public class Enemy : Consequential, IEnemy
    {
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
        }

        /// <summary>
        /// Encapsulates logic for the state change of the object before it is drawn.
        /// </summary>
        /// <param name="gameTime">Can be taken from the engine.</param>
        /// <param name="keyboardState">Can be taken from the engine.</param>
        public override void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            throw new NotImplementedException();
        }
    }
}
