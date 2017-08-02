namespace ImpactMan.Interfaces.IO.InputListeners
{
    using ImpactMan.IO.InputListeners.Events;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public interface IInputListener
    {
        event KeyPressedEventHandler KeyPressed;

        void GetKeyboardState(KeyboardState keyboardState, GameTime gameTime);
    }
}
