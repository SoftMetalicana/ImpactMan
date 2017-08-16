namespace ImpactMan.Models.Enemies
{
    using Consequences;
    using Constants.Consequential;
    using ImpactMan.Attributes;
    using ImpactMan.Constants.Units;
    using Interfaces.Models.Enemies;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Concrete implementation of the enemy.
    /// For more info visit the classes and interfaces it inherits.
    /// </summary>
    [MapObject(UnitConstants.EnemyCsvKeyName)]
    public class Enemy : Consequential, IEnemy
    {
        private Random rnd = new Random();

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
        }

        /// <summary>
        /// Encapsulates logic for the state change of the object before it is drawn.
        /// </summary>
        /// <param name="gameTime">Can be taken from the engine.</param>
        /// <param name="keyboardState">Can be taken from the engine.</param>
        public override void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            var dic = new Dictionary<int, Vector2>()
            {
                { 0, new Vector2(0, -5) },
                { 1, new Vector2(0, 5) },
                { 2, new Vector2(-5, 0) },
                { 3, new Vector2(5, 5) },
            };
            var newPosition = this.rnd.Next(0, 3);
            var rec = new Rectangle(this.Rectangle.X + (int)dic[newPosition].X, this.Rectangle.Y + (int)dic[newPosition].Y, this.Texture.Width, this.Texture.Height);
            
            this.Rectangle = rec;
        }
    }
}
