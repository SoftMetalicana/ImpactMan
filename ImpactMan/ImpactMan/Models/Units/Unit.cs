namespace ImpactMan.Models.Units
{
    using Constants.Units;
    using Interfaces.Globals;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public abstract class Unit : IUnit
    {
        private Texture2D texture;
        private Rectangle rectangle;
        private string assetName;
        
        public Unit(int x, int y, string assetName)
            : this(x, y, UnitConstants.Width, UnitConstants.Height, assetName)
        {
        }

        public Unit(int x, int y, int width, int height, string assetName)
        {
            this.Rectangle = new Rectangle(x, y, width, height);
            this.AssetName = assetName; 
        }

        public Texture2D Texture
        {
            get
            {
                return this.texture;
            }

            private set
            {
                this.texture = value;
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                return this.rectangle;
            }

            protected set
            {
                this.rectangle = value;
            }
        }

        public string AssetName
        {
            get
            {
                return this.assetName;
            }

            private set
            {
                this.assetName = value;
            }
        }

        public virtual void Load(ContentManager content)
        {
            this.Texture = content.Load<Texture2D>(this.AssetName);
        }

        public abstract void Update(GameTime gameTime, KeyboardState keyboardState);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Rectangle, Color.White);
        }
    }
}