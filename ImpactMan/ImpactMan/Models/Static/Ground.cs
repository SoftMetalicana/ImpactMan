namespace ImpactMan.Models.Static
{
    using System;
    using ImpactMan.Constants.Consequential;
    using ImpactMan.Constants.Units;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Models.Consequences;

    public class Ground : Consequential
    {
        /// <summary>
        /// Instantiates the enemy.
        /// </summary>
        /// <param name="x">The x coordinates of the object on the console/map/window.</param>
        /// <param name="y">The y coordinates of the object on the console/map/window.</param>
        public Ground(int x, int y)
            : this(x, y, UnitConstants.GroundAssetName, ConsequentialConstants.GroundBonusPoints)
        {
        }

        /// <summary>
        /// Instantiates the enemy.
        /// </summary>
        /// <param name="x">The x coordinates of the object on the console/map/window.</param>
        /// <param name="y">The y coordinates of the object on the console/map/window.</param>
        /// <param name="assetName">The name of the picure that is loaded from the pipeline.</param>
        /// <param name="bonusPoints">he bonus points that you want to give to the player.</param>
        public Ground(int x, int y, string assetName, int bonusPoints) 
            : base(x, y, assetName, bonusPoints)
        {
        }

        /// <summary>
        /// From this method you manipulate the ground object when it is stepped over.
        /// Changing the picture, bonus points and so on.
        /// </summary>
        /// <param name="gameTime"> Can be taken from the engine.</param>
        /// <param name="keyboardState">Can be taken from the inputListener.</param>
        public override void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            throw new NotImplementedException();
        }
    }
}
