namespace ImpactMan.Interfaces.Globals
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Everything which is seen on the map inherits from this interface.
    /// You must inherit from this interface if you want to be seen on the map/console/window.
    /// </summary>
    public interface IGameplayUnit : IUnit
    {
        /// <summary>
        /// Whenever something happens the objects state is changed from here.
        /// </summary>
        /// <param name="gameTime">Info about the game time. Can be taken from the engine</param>
        /// <param name="keyboardState">Current keyboard state. Can be taken from the engine and the IInputListener</param>
        void Update(GameTime gameTime, KeyboardState keyboardState);
    }
}
