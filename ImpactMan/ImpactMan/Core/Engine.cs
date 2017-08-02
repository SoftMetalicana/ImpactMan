namespace ImpactMan.Core
{
    using Constants.Graphics;
    using ImpactMan.Interfaces.IO.InputListeners;
    using ImpactMan.Interfaces.Models.Players;
    using ImpactMan.IO.InputListeners;
    using ImpactMan.Models.Players;
    using Interfaces.Core;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Engine : Game, IEngine
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private IPlayer player;

        private IInitializer initializer;
        private IInputListener inputListener;

        public Engine()
            : this(new Initializer(),
                   new InputListener())
        {
        }

        public Engine(IInitializer initializer,
                      IInputListener inputListener)
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";

            this.initializer = initializer;
            this.inputListener = inputListener;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            // MUST BE DONE FROM HERE
            this.player = new PacMan(0, 0, "food", "goshko ot gorica");
            this.player.Load(this.Content);
            this.inputListener.KeyPressed += this.player.OnKeyPressed;
            // TO HERE

            this.initializer.SetGameMouse(this, GraphicsConstants.IsMouseVisible);
            this.initializer.SetGraphicsWindowSize(this.graphics,
                                                   GraphicsConstants.PreferredBufferWidth,
                                                   GraphicsConstants.PreferredBufferHeight);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();
            this.inputListener.GetKeyboardState(currentKeyboardState, gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || currentKeyboardState.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            this.player.Update(gameTime, currentKeyboardState);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.WhiteSmoke);

            // TODO: Add your drawing code here
            this.spriteBatch.Begin();
            this.player.Draw(this.spriteBatch);
            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
