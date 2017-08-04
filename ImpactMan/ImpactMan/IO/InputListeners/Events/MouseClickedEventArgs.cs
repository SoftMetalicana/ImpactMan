namespace ImpactMan.IO.InputListeners.Events
{
    using Context.Models;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using System;

    public class MouseClickedEventArgs : EventArgs
    {
        private MouseState mouseState;
        private GameTime gameTime;
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
