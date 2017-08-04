using ImpactMan.Core.Factories;

namespace ImpactMan.Core
{
    using Constants.Graphics;
    using Context.Db;
    using Interfaces.IO.InputListeners;
    using Interfaces.Models.Players;
    using IO.InputListeners;
    using Models.Players;
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
        private MenuController menuController;
        private MenuCommandFactory menuCommandFactory;
        private bool isGameMenuActive;

        ImpactManContext context;

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
            this.menuCommandFactory = new MenuCommandFactory(this, this.Content);
            this.menuController = new MenuController(this.menuCommandFactory);

            // MUST BE DONE FROM HERE
            this.context = new ImpactManContext();
            this.context.Database.Initialize(true);
            this.player = new PacMan(0, 0, "food", "goshko ot gorica");
            this.player.Load(this.Content);
            this.inputListener.KeyPressed += this.player.OnKeyPressed;
            this.inputListener.MouseClicked += this.menuController.OnMouseClicked;

            this.menuController.Initialize("MainMenu");

            this.isGameMenuActive = true;
            // TO HERE

            this.initializer.SetGameMouse(this, GraphicsConstants.IsMouseVisible);
            this.initializer.SetGraphicsWindowSize(this.graphics,
                                                   GraphicsConstants.PreferredBufferWidth,
                                                   GraphicsConstants.PreferredBufferHeight);
            SetWindowTitle();
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

            this.menuController.Load(Content);

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
            MouseState currentMouseState = Mouse.GetState();

            if (currentKeyboardState.IsKeyDown(Keys.Home) && !this.isGameMenuActive)
            {
                ChangeGameMenuCurrentStatus();

            }

            if (isGameMenuActive)
            {
                this.inputListener.GetMouseState(currentMouseState, gameTime);
            }

            else
            {

                this.inputListener.GetKeyboardState(currentKeyboardState, gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.WhiteSmoke);

            this.spriteBatch.Begin();

            if (isGameMenuActive)
            {
                this.menuController.Draw(spriteBatch);
            }
            else
            {
                this.player.Draw(this.spriteBatch);
            }

            this.spriteBatch.End();

            base.Draw(gameTime);
        }

        public void ChangeGameMenuCurrentStatus()
        {
            this.isGameMenuActive = !isGameMenuActive;
        }

        public void Quit()
        {
            Exit();
        }

        public void SetWindowTitle(string title = GraphicsConstants.WindowTitle)
        {
            this.Window.Title = title;
        }
    }
}
