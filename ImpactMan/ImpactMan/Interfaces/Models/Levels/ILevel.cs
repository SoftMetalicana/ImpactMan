namespace ImpactMan.Interfaces.Models.Levels
{
    using System.Collections.Generic;
    using ImpactMan.Interfaces.Globals;
    
    public interface ILevel : IDrawable
    {
        IList<IConsequential[]> AllUnitsOnMap { get; }

        void AddPlayer(object player, int row, int col);

        void AddEnemy(object enemy, int row, int col);

        void AddFood(object food, int row, int col);

        void AddWall(object wall, int row, int col);

        void AddGround(object ground, int row, int col);
    }
}
