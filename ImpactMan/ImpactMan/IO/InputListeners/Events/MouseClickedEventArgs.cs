namespace ImpactMan.IO.InputListeners.Events
{
    using Context.Models;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using System;

    /// <summary>
    /// Holds basic info about the current state of the mouse.
    /// </summary>
    public class MouseClickedEventArgs : EventArgs
    {
        /// <summary>
        /// The mouse state at the moment the vent is raised
        /// </summary>
        private MouseState mouseState;

        /// <summary>
        /// The game time at the moment the event is raised
        /// </summary>
        private GameTime gameTime;

        /// <summary>
        /// Current user at the time the event is raised.
        /// </summary>
        private User user;

        public MouseClickedEventArgs(MouseState mouseState, GameTime gameTime, User user)
        {
            this.MouseState = mouseState;
            this.GameTime = gameTime;
            this.User = user;
        }

        public User User
        {
            get { return this.user; }
            private set { this.user = value; }
        }

        public MouseState MouseState
        {
            get { return this.mouseState; }
            private set { this.mouseState = value; }
        }

        public GameTime GameTime
        {
            get { return this.gameTime; }
            private set { this.gameTime = value; }
        }
    }
}
