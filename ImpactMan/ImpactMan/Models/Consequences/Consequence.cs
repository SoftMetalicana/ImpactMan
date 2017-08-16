namespace ImpactMan.Models.Consequences
{
    using Interfaces.Globals;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Concrete implementation of the IConsequence interface.
    /// For more information visit the interface.
    /// Usually this consequences are only for the player.
    /// </summary>
    public class Consequence : IConsequence
    {
        /// <summary>
        /// The bonus points this consequence will give to the player.
        /// </summary>
        private int bonusPoints;
        private bool playerCanMove;
        private IConsequential sender;

        /// <summary>
        /// Instantiates the object.
        /// </summary>
        /// <param name="bonusPoints">The bonus points you want to give to the player.</param>
        public Consequence(int bonusPoints, bool playerCanMove, IConsequential sender)
        {
            this.BonusPoints = bonusPoints;
            this.PlayerCanMove = playerCanMove;
            this.Sender = sender;
        }

        public IConsequential Sender
        {
            get
            {
                return this.sender;
            }

            private set
            {
                this.sender = value;
            }
        }

        /// <summary>
        /// The bonus points this consequence will give to the player.
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
    }
}
