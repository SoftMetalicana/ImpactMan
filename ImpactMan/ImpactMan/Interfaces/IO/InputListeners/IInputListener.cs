namespace ImpactMan.Interfaces.IO.InputListeners
{
    using Context.Models;
    using ImpactMan.IO.InputListeners.Events;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Takes care of listening for inputs from the StandartInput/Keyboard
    /// Takes care of informing other objects in the game that a button is pressed.
    /// </summary>
    public interface IInputListener
    {
        /// <summary>
        /// Informs all objects in the game that care that key is pressed.
        /// Key event handler points to all the handler methods in the interested objects.
        /// If you want someone to be informed for a pressed key you must subscribe to this event.
        /// </summary>
        event KeyPressedEventHandler KeyPressed;
        event MouseClickedEventHandler MouseClicked;

        /// <summary>
        /// Gets information about the current state of the keyboard and the game time.
        /// </summary>
        /// <param name="keyboardState">Current keyboard state. Can be taken from the Engine.</param>
        /// <param name="gameTime">Info about the time in the game. Can be taken from the Engine.</param>
        void GetKeyboardState(KeyboardState keyboardState, GameTime gameTime);

        void GetMouseState(MouseState mouseState, GameTime gameTime, User user);
    }
}
