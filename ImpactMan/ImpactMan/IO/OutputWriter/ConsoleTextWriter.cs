using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ImpactMan.IO.OutputWriter
{
    public class ConsoleTextWriter
    {
        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;

        public ConsoleTextWriter(SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;
        }

        public SpriteFont SpriteFont
        {
            get { return this.spriteFont; }
            private set { this.spriteFont = value; }
        }

        public void WriteOnConsole(string text, Vector2 vector, Color color)
        {
            this.spriteBatch.DrawString(this.spriteFont, text, vector, color);
        }
    }
}
