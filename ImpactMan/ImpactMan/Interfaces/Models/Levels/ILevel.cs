namespace ImpactMan.Interfaces.Models.Levels
{
    using System.Collections.Generic;
    using ImpactMan.Interfaces.Globals;
    using ImpactMan.Interfaces.Models.Enemies;
    using ImpactMan.Interfaces.Models.Players;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Holds all the static elements from the map.
    /// Each of these items is IConsequential.
    /// </summary>
    public interface ILevel : Globals.IDrawable
    {
        /// <summary>
        /// All the enemies on the map. Also walk over the map.
        /// </summary>
        IList<IEnemy> AllEnemies { get; }

        /// <summary>
        /// The player which walks over the map.
        /// </summary>
        IPlayer Player { get; }

        /// <summary>
        /// Representation of the map itself.
        /// </summary>
        IList<IConsequential[]> AllUnitsOnMap { get; }

        /// <summary>
        /// Adds an object to the place where it belongs in the level.
        /// </summary>
        /// <param name="player">The player object.</param>
        /// <param name="row">The row in the matrix.</param>
        /// <param name="col">The col in the matrix.</param>
        void AddPlayer(object player, int row, int col);

        /// <summary>
        /// Adds an object to the place where it belongs in the level.
        /// </summary>
        /// <param name="enemy">The enemy object.</param>
        /// <param name="row">The row in the matrix.</param>
        /// <param name="col">The col in the matrix.</param>
        void AddEnemy(object enemy, int row, int col);

        /// <summary>
        /// Adds an object to the place where it belongs in the level.
        /// </summary>
        /// <param name="food">The food object.</param>
        /// <param name="row">The row in the matrix.</param>
        /// <param name="col">The col in the matrix.</param>
        void AddFood(object food, int row, int col);

        /// <summary>
        /// Adds an object to the place where it belongs in the level.
        /// </summary>
        /// <param name="wall">The wall object.</param>
        /// <param name="row">The row in the matrix.</param>
        /// <param name="col">The col in the matrix.</param>
        void AddWall(object wall, int row, int col);

        /// <summary>
        /// Adds an object to the place where it belongs in the level.
        /// </summary>
        /// <param name="ground">The ground object.</param>
        /// <param name="row">The row in the matrix.</param>
        /// <param name="col">The col in the matrix.</param>
        void AddGround(object ground, int row, int col);

        IConsequence GetAffectedObjectConsequence(Rectangle rectangle);
    }
}
