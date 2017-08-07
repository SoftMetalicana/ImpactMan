namespace ImpactMan.Models.Units
{
    using Context.Models;
    using Interfaces.Globals;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public abstract class GameControlUnit : IGameControlUnit
    {
        /// <summary>
        /// The way the unit looks. Usually a picture is used from the game pipeline.
        /// Holds the width and the height of the unit.
        /// </summary>
        private Texture2D texture;
        /// <summary>
        /// The position X and Y on th console and the size which is taken from the texture.
        /// </summary>
        private Rectangle rectangle;
        /// <summary>
        /// The name of the picture which is loaded from the pipeline.
        /// </summary>
        private string assetName;

        /// <summary>
        /// Instantiates the object.
        /// </summary>
        /// <param name="x">The x coordinates of the object on the console/map/window.</param>
        /// <param name="y">The y coordinates of the object on the console/map/window.</param>
        /// <param name="width">The width of the object in the map/console.</param>
        /// <param name="height">The height of the object in the map/console.</param>
        /// <param name="assetName">The name of the picure that is loaded from the pipeline.</param>
        public GameControlUnit(int x, int y, int width, int height, string assetName)
        {
            this.Rectangle = new Rectangle(x, y, width, height);
            this.AssetName = assetName;
        }

        /// <summary>
        /// The way the unit looks. Usually a picture is used from the game pipeline.
        /// Holds the width and the height of the unit.
        /// </summary>
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

        /// <summary>
        /// The position X and Y on th console and the size which is taken from the texture.
        /// </summary>
        public Rectangle Rectangle
        {
            get
            {
                return this.rectangle;
            }

            set
            {
                this.rectangle = value;
            }
        }

        /// <summary>
        /// The name of the picture which is loaded from the pipeline.
        /// </summary>
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
        /// <summary>
        /// Holds logic for loading/initializing the object at the start of the game.
        /// Usually the texture is loaded with a picture from the content/pipeline.
        /// </summary>
        /// <param name="content">The content of the game. Can be taken from the engine.</param>
        public virtual void Load(ContentManager content)
        {
            this.Texture = content.Load<Texture2D>(this.AssetName);
        }

        /// <summary>
        /// When something happens in the game the objects are updated from this method.
        /// The updated stuff are for example their position, color, points and so on.
        /// </summary>
        /// <param name="gameTime">Info about the current time in game. Can be taken from the Engine.</param>
        /// <param name="mouseState">Info about the keyboard state. Can be taken from the Engine or the InputListener.</param>
        public abstract void Update(GameTime gameTime, MouseState mouseState, User user);

        /// <summary>
        /// Logic about how the object is drawn.
        /// </summary>
        /// <param name="spriteBatch">Can be taken from the Engine.</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Rectangle, Color.White);
        }
    }
}
