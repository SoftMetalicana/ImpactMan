using ImpactMan.Interfaces.Globals;
using ImpactMan.Models.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ImpactMan.Models.Menu
{
    public class Menu : Unit
    {
        public Menu(int x, int y, string assetName) : base(x, y, assetName)
        {
        }

        public Menu(int x, int y, int width, int height, string assetName) : base(x, y, width, height, assetName)
        {
        }

        public override void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            throw new System.NotImplementedException();
        }
    }
}
