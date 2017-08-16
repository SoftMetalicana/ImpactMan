namespace ImpactMan.Interfaces.Models.Levels
{
    using ImpactMan.Interfaces.Models.Players;

    public class PlayerAffectedEnemyEventArgs
    {
        private IPlayer player;

        public PlayerAffectedEnemyEventArgs(IPlayer player)
        {
            this.Player = player;
        }

        public IPlayer Player
        {
            get
            {
                return this.player;
            }

            private set
            {
                this.player = value;
            }
        }
    }
}
