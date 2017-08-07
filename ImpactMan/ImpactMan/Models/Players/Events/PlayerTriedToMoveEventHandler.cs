namespace ImpactMan.Models.Players.Events
{
    using ImpactMan.Interfaces.Models.Players;

    public delegate void PlayerTriedToMoveEventHandler(IPlayer sender, PlayerTriedToMoveEventArgs eventArgs);
}
