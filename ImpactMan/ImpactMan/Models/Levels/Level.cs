namespace ImpactMan.Models.Levels
{
    using System;
    using System.Collections.Generic;
    using ImpactMan.Interfaces.Globals;
    using ImpactMan.Interfaces.Models.Enemies;
    using ImpactMan.Interfaces.Models.Levels;
    using ImpactMan.Interfaces.Models.Players;
    using ImpactMan.Models.Static;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Holds all the static elements from the map.
    /// Each of these items is IConsequential.
    /// </summary>
    public class Level : ILevel
    {
        public event PlayerAffectedEnemyEventHandler PlayerAffectedEnemy;

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
        /// <summary>
        /// This level preserves the initial state.
        /// </summary>
        private ILevel backUp;

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
            this.backUp = this;
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
        public IPlayer Player
        {
            get
            {
                return this.player;
            }

            private set
            {
                this.player = value;
            }
        }

        /// <summary>
        /// All the enemies on the map. Also walk over the map.
        /// </summary>
        public IList<IEnemy> AllEnemies
        {
            get
            {
                return this.allEnemies;
            }

            private set
            {
                this.allEnemies = value;
            }
        }

        /// <summary>
        /// When you add a player or enemy the corresponding cell of the matrix must not be null.
        /// When you add an object different from the STATIC declared ones you must call this backup method.
        /// </summary>
        /// <param name="x">X position in the console.</param>
        /// <param name="y">Y Position in the console.</param>
        /// <param name="row">Row in the matrix.</param>
        /// <param name="col">Col in the matrix.</param>
        private void BackupTheFieldWithGround(int x, int y, int row, int col)
        {
            this.AllUnitsOnMap[row][col] = new Ground(x, y);
        }

        /// <summary>
        /// Adds a static consequential object in the matrix.
        /// </summary>
        /// <param name="consequential">The object that you want to add in the matrix.</param>
        /// <param name="x">X position in the console.</param>
        /// <param name="y">Y Position in the console.</param>
        private void AddConsequential(IConsequential consequential, int row, int col)
        {
            this.AllUnitsOnMap[row][col] = consequential;
        }

        protected virtual void OnEnemyAffectedPlayer(PlayerAffectedEnemyEventArgs eventArgs)
        {
            this.PlayerAffectedEnemy?.Invoke(this, eventArgs);
        }

        /// <summary>
        /// Adds an object to the place where it belongs in the level.
        /// </summary>
        /// <param name="player">The player object.</param>
        /// <param name="row">The row in the matrix.</param>
        /// <param name="col">The col in the matrix.</param>
        public void AddPlayer(object player, int row, int col)
        {
            this.Player = (IPlayer)player;
            this.BackupTheFieldWithGround(this.Player.Rectangle.X, this.Player.Rectangle.Y, row, col);
        }

        /// <summary>
        /// Adds an object to the place where it belongs in the level.
        /// </summary>
        /// <param name="enemy">The enemy object.</param>
        /// <param name="row">The row in the matrix.</param>
        /// <param name="col">The col in the matrix.</param>
        public void AddEnemy(object enemy, int row, int col)
        {
            IEnemy toAdd = (IEnemy)enemy;
            this.AllEnemies.Add(toAdd);
            this.BackupTheFieldWithGround(toAdd.Rectangle.X, toAdd.Rectangle.Y, row, col);
        }

        /// <summary>
        /// Adds an object to the place where it belongs in the level.
        /// </summary>
        /// <param name="food">The food object.</param>
        /// <param name="row">The row in the matrix.</param>
        /// <param name="col">The col in the matrix.</param>
        public void AddFood(object food, int row, int col)
        {
            this.AddConsequential((IConsequential)food, row, col);
        }

        /// <summary>
        /// Adds an object to the place where it belongs in the level.
        /// </summary>
        /// <param name="wall">The wall object.</param>
        /// <param name="row">The row in the matrix.</param>
        /// <param name="col">The col in the matrix.</param>
        public void AddWall(object wall, int row, int col)
        {
            this.AddConsequential((IConsequential)wall, row, col);
        }

        /// <summary>
        /// Adds an object to the place where it belongs in the level.
        /// </summary>
        /// <param name="ground">The ground object.</param>
        /// <param name="row">The row in the matrix.</param>
        /// <param name="col">The col in the matrix.</param>
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

        public IConsequence GetAffectedObjectConsequence(Rectangle helperRectangle)
        {
            foreach (IEnemy enemy in this.AllEnemies)
            {
                bool objectIsAffected = enemy.TryToAffect(helperRectangle);

                if (objectIsAffected)
                {
                    this.OnEnemyAffectedPlayer(new PlayerAffectedEnemyEventArgs(this.Player));
                }
            }

            IConsequence affectedObjectConsequence = default(IConsequence);
            foreach (IConsequential[] array in this.allUnitsOnMap)
            {
                foreach (IConsequential consequentialUnit in array)
                {
                    bool objectIsAffected = consequentialUnit.TryToAffect(helperRectangle);

                    if (objectIsAffected)
                    {
                        affectedObjectConsequence = consequentialUnit.GiveConsequence();

                        if (!affectedObjectConsequence.PlayerCanMove)
                        {
                            goto ReturnResult;
                        }
                    }
                }
            }
            
            ReturnResult:
            return affectedObjectConsequence;
        }

        public void LevelReset()
        {
            this.Player = this.backUp.Player;
            this.AllEnemies = this.backUp.AllEnemies;
            this.AllUnitsOnMap = this.backUp.AllUnitsOnMap;
        }
    }
}
