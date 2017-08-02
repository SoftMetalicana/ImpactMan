namespace ImpactMan.Core
{
    using ImpactMan.Interfaces.Core;
    using Microsoft.Xna.Framework;

    public class Initializer : IInitializer
    {
        public void SetGraphicsWindowSize(GraphicsDeviceManager graphics, int preferredBufferWidth, int preferredBufferHeight)
        {
            graphics.PreferredBackBufferWidth = preferredBufferWidth;
            graphics.PreferredBackBufferHeight = preferredBufferHeight;
            graphics.ApplyChanges();
        }

        public void SetGameMouse(Game game, bool isMouseVisible)
        {
            game.IsMouseVisible = isMouseVisible;
        }
    }
}
