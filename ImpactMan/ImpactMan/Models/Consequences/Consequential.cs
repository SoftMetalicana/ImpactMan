﻿namespace ImpactMan.Models.Consequences
{
    using Interfaces.Globals;
    using Microsoft.Xna.Framework;
    using Units;

    /// <summary>
    /// This is a object that when you step on it has consequences.
    /// </summary>
    public abstract class Consequential : GameplayUnit, IConsequential
    {
        /// <summary>
        /// The bonus points that you give to the player.
        /// </summary>
        private int bonusPoints;
        /// <summary>
        /// The distance from the player to the consequential object which is needed to activate
        /// the consequential object.
        /// </summary>
        private double distanceFromCenterToActivate;

        /// <summary>
        /// Instantiates the object.
        /// </summary>
        /// <param name="x">The x coordinate of the object in the map.</param>
        /// <param name="y">The y coordinate of the object in the map.</param>
        /// <param name="assetName">The name of the asset from the pipeline.</param>
        /// <param name="bonusPoints">The bonus points that you want to give to the player.</param>
        protected Consequential(int x, int y, string assetName, int bonusPoints, double distanceFromCenterToActivate) 
            : base(x, y, assetName)
        {
            this.BonusPoints = bonusPoints;
            this.DistanceFromCenterToActivate = distanceFromCenterToActivate;
        }

        /// <summary>
        /// The bonus points that you give to the player.
        /// </summary>
        public int BonusPoints
        {
            get
            {
                return this.bonusPoints;
            }

            private set
            {
                this.bonusPoints = value;
            }
        }

        public double DistanceFromCenterToActivate
        {
            get
            {
                return this.distanceFromCenterToActivate;
            }

            private set
            {
                this.distanceFromCenterToActivate = value;
            }
        }

        /// <summary>
        /// If you step on this object you must get his consequences.
        /// </summary>
        /// <returns>The consequences that are applied to the player</returns>
        public IConsequence GiveConsequence()
        {
            return new Consequence(this.bonusPoints);
        }
    }
}
