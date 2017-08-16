using ImpactMan.Interfaces.Models.Levels;
using ImpactMan.Interfaces.Models.Players;

namespace ImpactMan.Interfaces.Core
{
    public interface IPlayerDeathHandler
    {
        void OnPlayerDead(ILevel sender, PlayerAffectedEnemyEventArgs eventArgs);
    }
}
