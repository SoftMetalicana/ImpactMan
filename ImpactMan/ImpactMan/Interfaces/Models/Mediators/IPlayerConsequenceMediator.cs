namespace ImpactMan.Interfaces.Models.Mediators
{
    using ImpactMan.Interfaces.Models.Levels;
    using ImpactMan.Interfaces.Models.Players;
    using ImpactMan.Models.Players.Events;

    public interface IPlayerConsequenceMediator
    {
        ILevel Level { get; set; }

        void OnPlayerTriedToMove(IPlayer sender, PlayerTriedToMoveEventArgs eventArgs);
    }
}
