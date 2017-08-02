using ImpactMan.Interfaces.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ImpactMan.Core
{
    class Class1 : IUnit
    {
        private Texture2D texture;
        private Rectangle rectangle;

        public Class1(int x, int y, Texture2D texture)
        {
            this.texture = texture;
            this.rectangle = new Rectangle(x, y, this.texture.Width, this.texture.Height);
        }

        public void Upload(ContentManager content)
        {
            this.texture = content.Load<Texture2D>("wall");
        }

        public void Update(GameTime gameTime)
        {
            this.rectangle.X++;
            this.rectangle.Y++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.rectangle, Color.White);
        }
    }
}
