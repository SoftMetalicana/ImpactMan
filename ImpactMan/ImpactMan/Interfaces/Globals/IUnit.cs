namespace ImpactMan.Interfaces.Globals
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public interface IUnit : IPositionable, IAsset
    {
        void Load(ContentManager content);

        void Update(GameTime gameTime, KeyboardState keyboardState);

        void Draw(SpriteBatch spriteBatch);
    }
}
