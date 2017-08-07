namespace ImpactMan.Interfaces.Globals
{
    using Microsoft.Xna.Framework.Graphics;

    public interface IDrawable
    {
        /// <summary>
        /// Holds logic how the object is drawn on the console/window/map.
        /// </summary>
        /// <param name="spriteBatch">Can be taken from the engine.</param>
        void Draw(SpriteBatch spriteBatch);
    }
}
