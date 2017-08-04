using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ImpactMan.Interfaces.Globals
{
    public interface IUnit : IPositionable, IAsset
    {
        /// <summary>
        /// Loads/initializes the objects state for the game.
        /// </summary>
        /// <param name="content">Can be taken from the engine</param>
        void Load(ContentManager content);

        /// <summary>
        /// Holds logic how the object is drawn on the console/window/map.
        /// </summary>
        /// <param name="spriteBatch">Can be taken from the engine.</param>
        void Draw(SpriteBatch spriteBatch);
    }
}
