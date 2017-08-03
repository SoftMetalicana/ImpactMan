using ImpactMan.Interfaces.Globals;
using ImpactMan.Interfaces.Models;
using ImpactMan.Interfaces.Models.Menu;
using ImpactMan.Models.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ImpactMan.Models.Menu
{
    public class MenuItem : Unit, IMenuItem
    {
        public MenuItem(int x, int y, string assetName) 
            : base(x, y, assetName)
        {
        }

        public MenuItem(int x, int y, int width, int height, string assetName) 
            : base(x, y, width, height, assetName)
        {
        }

        public MenuItem(int x, int y, int width, int height, string assetName, IMenuCommand menuCommand) 
            : base(x, y, width, height, assetName)
        {
            this.MenuCommand = menuCommand;
        }

        public IMenuCommand MenuCommand { get; private set; }

        public override void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            throw new System.NotImplementedException();
        }
    }
}
