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

        public override void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                this.Rectangle = new Rectangle(this.Rectangle.X + 5, this.Rectangle.Y, this.Texture.Width, this.Texture.Height);
            }
        }
    }
}
