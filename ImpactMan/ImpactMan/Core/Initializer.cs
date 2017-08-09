namespace ImpactMan.Core
{
    using ImpactMan.Interfaces.Globals;
    using ImpactMan.Interfaces.Models.Enemies;
    using ImpactMan.Interfaces.Models.Levels;
    using Interfaces.Core;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;

    /// <summary>
    /// This object takes care of initializing other objects like GraphicWindow.
    /// Be careful when using the initializer. 
    /// Always check if constants are provided in the corresponding consant class.
    /// Dare to pass values to the constants only if constants aren't provided.
    /// </summary>
    public class Initializer : IInitializer
    {
        /// <summary>
        /// Sets the initial size of the graphic window.
        /// </summary>
        /// <param name="graphics">The graphics of the game. The graphics is taken from the engine.</param>
        /// <param name="preferredBufferWidth">Preferred width of the window/console</param>
        /// <param name="preferredBufferHeight">Preferred height of the window/console</param>
        public void SetGraphicsWindowSize(GraphicsDeviceManager graphics, int preferredBufferWidth, int preferredBufferHeight)
        {
            graphics.PreferredBackBufferWidth = preferredBufferWidth;
            graphics.PreferredBackBufferHeight = preferredBufferHeight;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Sets the initial state of the mouse in the game.
        /// </summary>
        /// <param name="game">The game is taken from the engine.</param>
        /// <param name="isMouseVisible">The wanted mouse state.</param>
        public void SetGameMouse(Game game, bool isMouseVisible)
        {
            game.IsMouseVisible = isMouseVisible;
        }

        /// <summary>
        /// Loads all the elements from the level.
        /// Sets texture and graphic content.
        /// </summary>
        /// <param name="level">The level that you want to set.</param>
        /// <param name="content">Can be taken from the Engine.</param>
        public void LoadLevel(ILevel level, ContentManager content)
        {
            level.Player.Load(content);

            foreach (IEnemy enemy in level.AllEnemies)
            {
                enemy.Load(content);
            }

            foreach (IConsequential[] array in level.AllUnitsOnMap)
            {
                foreach (IConsequential consequential in array)
                {
                    consequential.Load(content);
                }
            }
        }
    }
}
