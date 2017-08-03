namespace ImpactMan.IO.InputListeners
{
    using ImpactMan.Interfaces.IO.InputListeners;
    using ImpactMan.IO.InputListeners.Events;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class InputListener : IInputListener
    {
        public event KeyPressedEventHandler KeyPressed;
        public event MouseClickedEventHandler MouseClicked;

        //Keyboard input
        public void GetKeyboardState(KeyboardState keyboardState, GameTime gameTime)
        {
            this.OnKeyPressed(new KeyPressedEventArgs(keyboardState, gameTime));
        }

        protected virtual void OnKeyPressed(KeyPressedEventArgs eventArgs)
        {
            this.KeyPressed?.Invoke(this, eventArgs);
        }


        //Mouse input
        public void GetMouseState(MouseState mouseState, GameTime gameTime)
        {
            this.OnMouseClicked(new MouseClickedEventArgs(mouseState, gameTime));
        }

        protected virtual void OnMouseClicked(MouseClickedEventArgs eventArgs)
        {
            this.MouseClicked?.Invoke(this, eventArgs);
        }
    }
}
