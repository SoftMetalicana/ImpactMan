namespace ImpactMan.Models.Levels
{
    using System.Collections.Generic;
    using ImpactMan.Interfaces.Globals;

    public class Level
    {
        private IList<IConsequential[]> allUnitsOnMap;

        public Level(IList<IConsequential[]> allUnitsOnMap)
        {
            this.AllUnitsOnMap = allUnitsOnMap;
        }

        private IList<IConsequential[]> AllUnitsOnMap
        {
            get
            {
                return this.allUnitsOnMap;
            }

            set
            {
                this.allUnitsOnMap = value;
            }
        }
    }
}
