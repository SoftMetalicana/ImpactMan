namespace ImpactMan.Interfaces.Globals
{
    using Microsoft.Xna.Framework.Content;

    public interface IUnit : IPositionable, IAsset, IDrawable
    {
        /// <summary>
        /// Loads/initializes the objects state for the game.
        /// </summary>
        /// <param name="content">Can be taken from the engine</param>
        void Load(ContentManager content);
    }
}
