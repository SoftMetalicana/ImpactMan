namespace ImpactMan.Models.Players
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class PacMan : Player
    {
        public PacMan(int x, int y, string assetName, string playerName) 
            : base(x, y, assetName, playerName)
        {
        }

        /// <summary>
        /// Maybe need invoke keyboartstates with Reflection.
        /// This is only test.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="keyboardState"></param>
        public override void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                this.Rectangle = new Rectangle(this.Rectangle.X + 5, this.Rectangle.Y, this.Texture.Width, this.Texture.Height);
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                this.Rectangle = new Rectangle(this.Rectangle.X - 5, this.Rectangle.Y, this.Texture.Width, this.Texture.Height);
            }

            if (keyboardState.IsKeyDown(Keys.Down))
            {
                this.Rectangle = new Rectangle(this.Rectangle.X, this.Rectangle.Y + 5, this.Texture.Width, this.Texture.Height);
            }

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                this.Rectangle = new Rectangle(this.Rectangle.X, this.Rectangle.Y - 5, this.Texture.Width, this.Texture.Height);
            }
        }
    }
}
