namespace ImpactMan.Interfaces.Core
{
    using Microsoft.Xna.Framework;

    public interface IInitializer
    {
        void SetGraphicsWindowSize(GraphicsDeviceManager graphics, int preferredBufferWidth, int preferredBufferHeight);

        void SetGameMouse(Game game, bool isMouseVisible);
    }
}
