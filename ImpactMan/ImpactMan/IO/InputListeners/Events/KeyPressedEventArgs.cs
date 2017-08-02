namespace ImpactMan.IO.InputListeners.Events
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class KeyPressedEventArgs : EventArgs
    {
        private KeyboardState keyboardState;
        private GameTime gameTime;

        public KeyPressedEventArgs(KeyboardState keyboardState, GameTime gameTime)
        {
            this.KeyboardState = keyboardState;
            this.GameTime = gameTime;
        }

        public GameTime GameTime
        {
            get
            {
                return this.gameTime;
            }

            private set
            {
                this.gameTime = value;
            }
        }

        public KeyboardState KeyboardState
        {
            get
            {
                return this.keyboardState;
            }

            private set
            {
                this.keyboardState = value;
            }
        }
    }
}
