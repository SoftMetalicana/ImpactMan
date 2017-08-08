namespace ImpactMan.Models.Mediators
{
    using ImpactMan.Interfaces.Models.Levels;
    using ImpactMan.Interfaces.Models.Mediators;
    using ImpactMan.Interfaces.Models.Players;
    using ImpactMan.Models.Players.Events;

    /// <summary>
    /// Holds all the logic behind the player move.
    /// When a player tries to move this class is informed by an event.
    /// </summary>
    public class PlayerConsequenceMediator : IPlayerConsequenceMediator
    {
        private ILevel level;

        public PlayerConsequenceMediator(ILevel level)
        {
            this.level = level;
        }

        public ILevel Level
        {
            get
            {
                return this.level;
            }

            set
            {
                this.level = value;
            }
        }

        public void OnPlayerTriedToMove(IPlayer sender, PlayerTriedToMoveEventArgs eventArgs)
        {
            sender.Rectangle = eventArgs.DesiredPosition;
        }
    }
}
