namespace ImpactMan.Models.Levels
{
    using System.Collections.Generic;
    using ImpactMan.Interfaces.Globals;
    using ImpactMan.Interfaces.Models.Enemies;
    using ImpactMan.Interfaces.Models.Levels;
    using ImpactMan.Interfaces.Models.Players;
    using ImpactMan.Models.Static;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Holds all the static elements from the map.
    /// Each of these items is IConsequential.
    /// </summary>
    public class Level : ILevel
    {
        /// <summary>
        /// The player which walks over the map.
        /// </summary>
        private IPlayer player;
        /// <summary>
        /// All the enemies on the map. Also walk over the map.
        /// </summary>
        private IList<IEnemy> allEnemies;
        /// <summary>
        /// The map itself.
        /// </summary>
        private IList<IConsequential[]> allUnitsOnMap;

        public Level()
            : this(null, new List<IEnemy>(), new List<IConsequential[]>())
        {
        }

        /// <summary>
        /// Instantiates the map.
        /// </summary>
        /// <param name="allUnitsOnMap">The units that you want to have in the map.</param>
        public Level(IPlayer player, IList<IEnemy> allEnemies, IList<IConsequential[]> allUnitsOnMap)
        {
            this.AllUnitsOnMap = allUnitsOnMap;
            this.AllEnemies = allEnemies;
        }

        /// <summary>
        /// The map itself.
        /// </summary>
        public IList<IConsequential[]> AllUnitsOnMap
        {
            get
            {
                return this.allUnitsOnMap;
            }

            private set
            {
                this.allUnitsOnMap = value;
            }
        }

        /// <summary>
        /// The player which walks over the map.
        /// </summary>
        private IPlayer Player
        {
            get
            {
                return this.player;
            }

            set
            {
                this.player = value;
            }
        }

        /// <summary>
        /// All the enemies on the map. Also walk over the map.
        /// </summary>
        private IList<IEnemy> AllEnemies
        {
            get
            {
                return this.allEnemies;
            }

            set
            {
                this.allEnemies = value;
            }
        }

        private void BackupTheFieldWithGround(int x, int y, int row, int col)
        {
            this.AllUnitsOnMap[row][col] = new Ground(x, y);
        }

        private void AddConsequential(IConsequential consequential, int row, int col)
        {
            this.AllUnitsOnMap[row][col] = consequential;
        }

        public void AddPlayer(object player, int row, int col)
        {
            this.Player = (IPlayer)player;
            this.BackupTheFieldWithGround(this.Player.Rectangle.X, this.Player.Rectangle.Y, row, col);
        }

        public void AddEnemy(object enemy, int row, int col)
        {
            IEnemy toAdd = (IEnemy)enemy;
            this.AllEnemies.Add(toAdd);
            this.BackupTheFieldWithGround(toAdd.Rectangle.X, toAdd.Rectangle.Y, row, col);
        }

        public void AddFood(object food, int row, int col)
        {
            this.AddConsequential((IConsequential)food, row, col);
        }

        public void AddWall(object wall, int row, int col)
        {
            this.AddConsequential((IConsequential)wall, row, col);
        }

        public void AddGround(object ground, int row, int col)
        {
            this.AddConsequential((IConsequential)ground, row, col);
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
