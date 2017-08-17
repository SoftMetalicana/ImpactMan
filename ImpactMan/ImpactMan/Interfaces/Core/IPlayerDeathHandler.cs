using ImpactMan.Core.Events;
using ImpactMan.Interfaces.Models.Levels;
using ImpactMan.Interfaces.Models.Players;

namespace ImpactMan.Interfaces.Core
{
    public interface IPlayerDeathHandler
    {
        event PlayerDeadEventHandler PlayerDead;

        void OnPlayerDead(ILevel sender, PlayerAffectedEnemyEventArgs eventArgs);
    }
}
