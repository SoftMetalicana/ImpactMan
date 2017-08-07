namespace ImpactMan.Models.Levels
{
    using System.Collections.Generic;
    using ImpactMan.Interfaces.Globals;
    using ImpactMan.Interfaces.Models.Levels;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Holds all the static elements from the map.
    /// Each of these items is IConsequential.
    /// </summary>
    public class Level : ILevel
    {
        /// <summary>
        /// The map itself.
        /// </summary>
        private IList<IConsequential[]> allUnitsOnMap;

        /// <summary>
        /// Instantiates the map.
        /// </summary>
        /// <param name="allUnitsOnMap">The units that you want to have in the map.</param>
        public Level(IList<IConsequential[]> allUnitsOnMap)
        {
            this.AllUnitsOnMap = allUnitsOnMap;
        }

        /// <summary>
        /// The map itself.
        /// </summary>
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
        
        /// <summary>
        /// Draws all the objects on the map.
        /// </summary>
        /// <param name="spriteBatch">Can be taken from the Engine.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IConsequential[] array in this.AllUnitsOnMap)
            {
                foreach (IConsequential consequentialUnit in array)
                {
                    consequentialUnit.Draw(spriteBatch);
                }
            }
        }
    }
}
