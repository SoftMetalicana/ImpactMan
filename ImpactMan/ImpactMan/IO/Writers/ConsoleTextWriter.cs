namespace ImpactMan.IO.Writers
{
    using Interfaces.Writer;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class ConsoleTextWriter : ITextWriter
    {
        private SpriteFont spriteFont;
        private SpriteBatch spriteBatch;

        public ConsoleTextWriter(SpriteFont spriteFont, SpriteBatch spriteBatch)
        {
            this.spriteFont = spriteFont;
            this.spriteBatch = spriteBatch;
        }

        public void Write(string text, Vector2 vector, Color color)
        {
            this.spriteBatch.DrawString(this.spriteFont, text, vector, color);
        }
    }
}
