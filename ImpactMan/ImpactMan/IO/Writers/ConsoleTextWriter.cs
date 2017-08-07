using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpactMan.Interfaces.Writer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ImpactMan.IO.Writers
{
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
