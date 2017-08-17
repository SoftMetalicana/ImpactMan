namespace ImpactMan.Interfaces.ArtificialIntelligence
{
    using System.Collections.Generic;
    using ImpactMan.Interfaces.Models.Enemies;
    using Microsoft.Xna.Framework;
    
    public interface IArtificialIntelligence
    {
        void MoveTheEnemies(IEnumerable<IEnemy> allEnemies, GameTime gameTime);
    }
}
