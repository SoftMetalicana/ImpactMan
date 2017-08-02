namespace ImpactMan.IO.InputListeners
{
    using ImpactMan.Interfaces.IO.InputListeners;
    using ImpactMan.IO.InputListeners.Events;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class InputListener : IInputListener
    {
        public event KeyPressedEventHandler KeyPressed;

        public void GetKeyboardState(KeyboardState keyboardState, GameTime gameTime)
        {
            this.OnKeyPressed(new KeyPressedEventArgs(keyboardState, gameTime));
        }

        protected virtual void OnKeyPressed(KeyPressedEventArgs eventArgs)
        {
            this.KeyPressed?.Invoke(this, eventArgs);
        }
    }
}
