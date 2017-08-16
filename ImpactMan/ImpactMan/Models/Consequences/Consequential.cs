namespace ImpactMan.Models.Consequences
{
    using Interfaces.Globals;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
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
        /// Flag that tells the player if he can move or not.
        /// </summary>
        private bool playerCanMove;
        private ContentManager content;

        /// <summary>
        /// Instantiates the object.
        /// </summary>
        /// <param name="x">The x coordinate of the object in the map.</param>
        /// <param name="y">The y coordinate of the object in the map.</param>
        /// <param name="assetName">The name of the asset from the pipeline.</param>
        /// <param name="bonusPoints">The bonus points that you want to give to the player.</param>
        protected Consequential(int x, int y, string assetName, int bonusPoints, bool playerCanMove) 
            : base(x, y, assetName)
        {
            this.BonusPoints = bonusPoints;
            this.PlayerCanMove = playerCanMove;
        }

        public ContentManager Content
        {
            get
            {
                return this.content;
            }

            set
            {
                this.content = value;
            }
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

            protected set
            {
                this.bonusPoints = value;
            }
        }

        public bool PlayerCanMove
        {
            get
            {
                return this.playerCanMove;
            }

            private set
            {
                this.playerCanMove = value;
            }
        }

        /// <summary>
        /// If you step on this object you must get his consequences.
        /// </summary>
        /// <returns>The consequences that are applied to the player</returns>
        public virtual IConsequence GiveConsequence()
        {
            return new Consequence(this.BonusPoints, this.PlayerCanMove, this);
        }

        public virtual bool TryToAffect(Rectangle invaderRectangle)
        {
            return this.Rectangle.Intersects(invaderRectangle);
        }
    }
}
