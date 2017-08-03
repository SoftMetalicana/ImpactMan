namespace ImpactMan.Models.Players
{
    using Interfaces.IO.InputListeners;
    using IO.InputListeners.Events;
    using Interfaces.Models.Players;
    using Models.Units;

    /// <summary>
    /// Usually there is only one player in the game.
    /// Holds logic for the visualising, updating, drawing.
    /// </summary>
    public abstract class Player : Unit, IPlayer
    {
        /// <summary>
        /// The player name that is gonna be used in the DB record.
        /// </summary>
        private string name;
        /// <summary>
        /// The players points that are gonna be used in the DB record.
        /// </summary>
        private int points;

        /// <summary>
        /// Instantiates the object.
        /// </summary>
        /// <param name="x">The x coordinates of the object on the map/window/console</param>
        /// <param name="y">The y coordinates of the object on the map/window/console</param>
        /// <param name="assetName">The name of the picture that is loaded from the pipeline.</param>
        /// <param name="playerName">The name of the player.</param>
        public Player(int x, int y, string assetName, string playerName)
            : base(x, y, assetName)
        {
            this.Name = playerName;
        }

        /// <summary>
        /// The player name that is gonna be used in the DB record.
        /// </summary>
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

        /// <summary>
        /// The players points that are gonna be used in the DB record.
        /// </summary>
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

        /// <summary>
        /// This method is subrscribed to the KeyPressed event and it redirects to the Update method.
        /// </summary>
        /// <param name="sender">The input listener itself.</param>
        /// <param name="eventArgs">Holds basic info of the keyboard state at the moment the event was raised.</param>
        public void OnKeyPressed(IInputListener sender, KeyPressedEventArgs eventArgs)
        {
            this.Update(eventArgs.GameTime, eventArgs.KeyboardState);
        }
    }
}
