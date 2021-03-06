﻿namespace ImpactMan.Models.Players
{
    using ImpactMan.Constants.Players;
    using Interfaces.IO.InputListeners;
    using Interfaces.Models.Players;
    using IO.InputListeners.Events;
    using Models.Players.Events;
    using Units;

    /// <summary>
    /// Usually there is only one player in the game.
    /// Holds logic for the visualising, updating, drawing.
    /// </summary>
    public abstract class Player : GameplayUnit, IPlayer
    {       
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
        public Player(int x, int y, string assetName)
            : base(x, y, PlayersConstants.PlayerWidthAndHeight, PlayersConstants.PlayerWidthAndHeight, assetName)
        {
        }

        /// <summary>
        /// An event that notifice the ones that subscribed.
        /// </summary>
        public event PlayerTriedToMoveEventHandler PlayerTriedToMove;

        /// <summary>
        /// The players points that are gonna be used in the DB record.
        /// </summary>
        public int Points
        {
            get
            {
                return this.points;
            }

            set
            {
                this.points = value;
            }
        }

        /// <summary>
        /// This method is subrscribed to the KeyPressed event and it redirects to the Update method.
        /// </summary>
        /// <param name="sender">The input listener itself.</param>
        /// <param name="eventArgs">Holds basic info of the keyboard state at the moment the event was raised.</param>
        public abstract void OnKeyPressed(IInputListener sender, KeyPressedEventArgs eventArgs);

        /// <summary>
        /// This is an event trigger. Every time the player tries to move
        /// the subscibers will be notified.
        /// </summary>
        /// <param name="eventArgs"></param>
        protected virtual void OnPlayerTriedToMove(PlayerTriedToMoveEventArgs eventArgs)
        {
            this.PlayerTriedToMove?.Invoke(this, eventArgs);
        }
    }
}
