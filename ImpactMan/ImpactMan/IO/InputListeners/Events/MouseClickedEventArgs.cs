using Microsoft.Xna.Framework;

namespace ImpactMan.IO.InputListeners.Events
{
    using Microsoft.Xna.Framework.Input;
    using System;

    public class MouseClickedEventArgs : EventArgs
    {
        private MouseState mouseState;
        private GameTime gameTime;

        public MouseClickedEventArgs(MouseState mouseState, GameTime gameTime)
        {
            this.mouseState = mouseState;
            this.gameTime = gameTime;
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
