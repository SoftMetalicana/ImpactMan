namespace ImpactMan.Interfaces.Globals
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IPositionable
    {
        Texture2D Texture { get; }

        Rectangle Rectangle { get; }
    }
}
