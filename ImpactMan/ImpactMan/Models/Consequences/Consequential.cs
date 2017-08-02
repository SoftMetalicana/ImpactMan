namespace ImpactMan.Models.Consequences
{
    using Interfaces.Globals;
    using Models.Units;

    public abstract class Consequential : Unit, IConsequential
    {
        private int bonusPoints;
        
        protected Consequential(int x, int y, string assetName, int bonusPoints) 
            : base(x, y, assetName)
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

        public IConsequence GiveConsequence()
        {
            return new Consequence(this.bonusPoints);
        }
    }
}
