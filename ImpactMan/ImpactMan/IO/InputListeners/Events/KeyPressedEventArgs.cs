namespace ImpactMan.IO.InputListeners.Events
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Holds basic info about the current state of the keyboard.
    /// </summary>
    public class KeyPressedEventArgs : EventArgs
    {
        /// <summary>
        /// Current keyboard state at the moment the event is raised.
        /// </summary>
        private KeyboardState keyboardState;
        /// <summary>
        /// The game time in the moment the event is raised..
        /// </summary>
        private GameTime gameTime;

        /// <summary>
        /// Instantiates the object with the given params.
        /// </summary>
        /// <param name="keyboardState">The keyboard state at the time the event is raised.</param>
        /// <param name="gameTime">The game time at the moment the event is raised.</param>
        public KeyPressedEventArgs(KeyboardState keyboardState, GameTime gameTime)
        {
            this.KeyboardState = keyboardState;
            this.GameTime = gameTime;
        }

        /// <summary>
        /// Current keyboard state at the moment the event is raised.
        /// </summary>
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

        /// <summary>
        /// The game time in the moment the event is raised.
        /// </summary>
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
