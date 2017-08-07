﻿namespace ImpactMan.Models.Mediators
{
    using ImpactMan.Interfaces.Models.Mediators;
    using ImpactMan.Interfaces.Models.Players;
    using ImpactMan.Models.Players.Events;

    /// <summary>
    /// Holds all the logic behind the player move.
    /// When a player tries to move this class is informed by an event.
    /// </summary>
    public class PlayerConsequenceMediator : IPlayerConsequenceMediator
    {
        public void OnPlayerTriedToMove(IPlayer sender, PlayerTriedToMoveEventArgs eventArgs)
        {
            sender.Rectangle = eventArgs.DesiredPosition;
        }
    }
}
