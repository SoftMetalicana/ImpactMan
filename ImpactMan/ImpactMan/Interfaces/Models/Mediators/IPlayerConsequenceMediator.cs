namespace ImpactMan.Interfaces.Models.Mediators
{
    using ImpactMan.Interfaces.Models.Players;
    using ImpactMan.Models.Players.Events;

    public interface IPlayerConsequenceMediator
    {
        void OnPlayerTriedToMove(IPlayer sender, PlayerTriedToMoveEventArgs eventArgs);
    }
}
