namespace ImpactMan.IO.InputListeners
{
    using ImpactMan.Context.Models;
    using ImpactMan.Interfaces.IO.InputListeners;
    using ImpactMan.IO.InputListeners.Events;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Concrete implementation of the IInputListener.
    /// For more info visit the interface.
    /// </summary>
    public class InputListener : IInputListener
    {
        /// <summary>
        /// Actual event which sends info to the subscribers interested in a key press.
        /// </summary>
        public event KeyPressedEventHandler KeyPressed;
        public event MouseClickedEventHandler MouseClicked;

        /// <summary>
        /// Gets the current keyboard state from the engine.
        /// </summary>
        /// <param name="keyboardState">Keyboard state can be taken from the engine.</param>
        /// <param name="gameTime">Game time can be taken from the engine.</param>
        public void GetKeyboardState(KeyboardState keyboardState, GameTime gameTime)
        {
            this.OnKeyPressed(new KeyPressedEventArgs(keyboardState, gameTime));
        }

        /// <summary>
        /// Mouse input
        /// </summary>
        /// <param name="mouseState"></param>
        /// <param name="gameTime"></param>
        /// <param name="user"></param>
        public void GetMouseState(MouseState mouseState, GameTime gameTime, User user)
        {
            this.OnMouseClicked(new MouseClickedEventArgs(mouseState, gameTime, user));
        }

        /// <summary>
        /// Mouse clicked
        /// </summary>
        /// <param name="eventArgs"></param>
        protected virtual void OnMouseClicked(MouseClickedEventArgs eventArgs)
        {
            this.MouseClicked?.Invoke(this, eventArgs);
        }

        /// <summary>
        /// The method that takes care the invoke the event.
        /// </summary>
        /// <param name="eventArgs">Keyboard state info in the moment the event is raised.</param>
        protected virtual void OnKeyPressed(KeyPressedEventArgs eventArgs)
        {
            this.KeyPressed?.Invoke(this, eventArgs);
        }
    }
}
