namespace ImpactMan.Models.Players
{
    using Interfaces.IO.InputListeners;
    using IO.InputListeners.Events;
    using Interfaces.Models.Players;
    using Models.Units;

    public abstract class Player : Unit, IPlayer
    {
        private string name;
        private int points;

        public Player(int x, int y, string assetName, string playerName)
            : base(x, y, assetName)
        {
            this.Name = playerName;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                this.name = value;
            }
        }

        public void OnKeyPressed(IInputListener sender, KeyPressedEventArgs eventArgs)
        {
            this.Update(eventArgs.GameTime, eventArgs.KeyboardState);
        }

        public int Points
        {
            get
            {
                return this.points;
            }

            private set
            {
                this.points = value;
            }
        }
    }
}
