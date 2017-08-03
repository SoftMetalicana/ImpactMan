namespace ImpactMan.Interfaces.Globals
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Everything that is on the map is positionable and inherits this interface.
    /// </summary>
    public interface IPositionable
    {
        /// <summary>
        /// Holds the view and the size of an object in the game.
        /// </summary>
        Texture2D Texture { get; }

        /// <summary>
        /// Holds the position and the size of an object in the game.
        /// The size is usually taken from the texture.
        /// </summary>
        Rectangle Rectangle { get; }
    }
}
