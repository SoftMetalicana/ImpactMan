namespace ImpactMan.Interfaces.Globals
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Everything which is seen on the map inherits from this interface.
    /// You must inherit from this interface if you want to be seen on the map/console/window.
    /// </summary>
    public interface IUnit : IPositionable, IAsset
    {
        /// <summary>
        /// Loads/initializes the objects state for the game.
        /// </summary>
        /// <param name="content">Can be taken from the engine</param>
        void Load(ContentManager content);

        /// <summary>
        /// Whenever something happens the objects state is changed from here.
        /// </summary>
        /// <param name="gameTime">Info about the game time. Can be taken from the engine</param>
        /// <param name="keyboardState">Current keyboard state. Can be taken from the engine and the IInputListener</param>
        void Update(GameTime gameTime, KeyboardState keyboardState);

        /// <summary>
        /// Holds logic how the object is drawn on the console/window/map.
        /// </summary>
        /// <param name="spriteBatch">Can be taken from the engine.</param>
        void Draw(SpriteBatch spriteBatch);
    }
}
