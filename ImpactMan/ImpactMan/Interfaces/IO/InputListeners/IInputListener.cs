namespace ImpactMan.Interfaces.IO.InputListeners
{
    using ImpactMan.IO.InputListeners.Events;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public interface IInputListener
    {
        event KeyPressedEventHandler KeyPressed;
        event MouseClickedEventHandler MouseClicked;

        void GetKeyboardState(KeyboardState keyboardState, GameTime gameTime);

        void GetMouseState(MouseState mouseState, GameTime gameTime);
    }
}
