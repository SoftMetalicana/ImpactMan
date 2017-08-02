namespace ImpactMan.Models.Consequences
{
    using Interfaces.Globals;

    public class Consequence : IConsequence
    {
        private int bonusPoints;

        public Consequence(int bonusPoints)
        {
            this.BonusPoints = bonusPoints;
        }

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
    }
}
