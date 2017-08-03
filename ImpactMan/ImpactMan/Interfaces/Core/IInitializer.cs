namespace ImpactMan.Interfaces.Core
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Takes care of initializing objects in the game.
    /// </summary>
    public interface IInitializer
    {
        /// <summary>
        /// Sets the initial size of the graphic window.
        /// </summary>
        /// <param name="graphics">The graphics of the game. The graphics is taken from the engine.</param>
        /// <param name="preferredBufferWidth">Preferred width of the window/console</param>
        /// <param name="preferredBufferHeight">Preferred height of the window/console</param>
        void SetGraphicsWindowSize(GraphicsDeviceManager graphics, int preferredBufferWidth, int preferredBufferHeight);

        /// <summary>
        /// Sets the initial state of the mouse in the game.
        /// </summary>
        /// <param name="game">The game is taken from the engine.</param>
        /// <param name="isMouseVisible">The wanted mouse state.</param>
        void SetGameMouse(Game game, bool isMouseVisible);
    }
}
