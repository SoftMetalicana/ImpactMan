namespace ImpactMan.Core
{
    using System.Text;
    using Constants.Graphics;
    using Context.Db;
    using Context.Models;
    using Factories;
    using Interfaces.Core;
    using Interfaces.IO.InputListeners;
    using Interfaces.Models.Players;
    using IO.InputListeners;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Models.Players;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public enum GameState { MainMenuActive, LoginMenuActive, SignUpMenuActive, GameMode }
    public enum UserInpuState { NameInput, PasswordInput }

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Engine : Game, IEngine
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;

        private IPlayer player;
        private User user;
        private User userInputDetails;
        private string userName;
        private string userPassword;
        private string errorMessage;

        private List<Keys> pressedKeys = new List<Keys>();

        private IInitializer initializer;
        private IInputListener inputListener;
        private MenuController menuController;
/*        private MenuCommandFactory menuCommandFactory;*/
        private AccountManager accountManager;
        private GameState gameState;
        private UserInpuState userInputState;

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
            this.userInputDetails = new User();
            this.user = new User();
            this.userName = String.Empty;
            this.userPassword = String.Empty;
            this.errorMessage = String.Empty;

            this.accountManager = new AccountManager();
/*            this.menuCommandFactory = new MenuCommandFactory(this, this.Content, this.accountManager, this.user);*/
            this.menuController = new MenuController(this, this.Content, this.accountManager, this.user);


            // MUST BE DONE FROM HERE
            /*            this.context = new ImpactManContext();
                        this.context.Database.Initialize(true);*/

            this.player = new PacMan(0, 0);
            this.player.Load(this.Content);

            this.inputListener.KeyPressed += this.player.OnKeyPressed;
            this.inputListener.MouseClicked += this.menuController.OnMouseClicked;

            this.menuController.Initialize("LoginMenu");

            this.gameState = GameState.LoginMenuActive;
            this.userInputState = UserInpuState.NameInput;

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
            this.spriteFont = this.Content.Load<SpriteFont>("sprite_font");

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

            if (currentKeyboardState.IsKeyDown(Keys.Home) && this.gameState == GameState.GameMode)
            {
                ChangeGameState(GameState.MainMenuActive);
                this.menuController.Initialize("MainMenu");
                this.menuController.Load(Content);

            }

            if (gameState != GameState.GameMode)
            {
                this.inputListener.GetMouseState(currentMouseState, gameTime, this.userInputDetails);
            }

            if (gameState == GameState.LoginMenuActive || gameState == GameState.SignUpMenuActive)
            {
                GetPressedKeys();

                this.userInputDetails.Name = this.userName;
                this.userInputDetails.Password = this.userPassword;
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

            if (gameState != GameState.GameMode)
            {
                this.menuController.Draw(spriteBatch);
            }

            if (gameState == GameState.LoginMenuActive)
            {
                spriteBatch.DrawString(spriteFont, userName, new Vector2(530, 293), Color.Black);
                spriteBatch.DrawString(spriteFont, userPassword, new Vector2(530, 355), Color.Black);
                spriteBatch.DrawString(spriteFont, errorMessage, new Vector2(505, 775), Color.Black);
            }

            else if (gameState == GameState.SignUpMenuActive)
            {
                spriteBatch.DrawString(spriteFont, userName, new Vector2(542, 299), Color.Black);
                spriteBatch.DrawString(spriteFont, userPassword, new Vector2(542, 365), Color.Black);
                spriteBatch.DrawString(spriteFont, errorMessage, new Vector2(505, 775), Color.Black);
            }

            else if(this.gameState == GameState.GameMode)
            {
                this.player.Draw(this.spriteBatch);
            }

            this.spriteBatch.End();

            base.Draw(gameTime);
        }

        public void ChangeGameState(GameState gameStateToChange)
        {
            this.gameState = gameStateToChange;
        }

        public void Quit()
        {
            Exit();
        }

        public void SetWindowTitle(string title = GraphicsConstants.WindowTitle)
        {
            this.Window.Title = title;
        }

        private void GetPressedKeys()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            List<Keys> currentKeys = keyboardState.GetPressedKeys().ToList();

            foreach (Keys key in pressedKeys)
            {
                if (!currentKeys.Contains(key))
                {
                    OnReleasedKey(key);
                }
            }

            pressedKeys = currentKeys;
        }

        public void ChangeUserInputState()
        {
            this.userInputState = (UserInpuState)(((int)userInputState + 1) % 2);
        }

        private void OnReleasedKey(Keys key)
        {
            StringBuilder sb = new StringBuilder();

            if (key == Keys.Tab)
            {
                ChangeUserInputState();
            }

            if (userInputState == UserInpuState.NameInput)
            {
                sb = new StringBuilder(userName);
            }
            else
            {
                sb = new StringBuilder(userPassword);
            }

            if (IsKeyLetter(key))
            {
                sb.Append(key);
            }

            else if (IsKeyDigit(key))
            {
                sb.Append(key.ToString().Replace("NumPad", "").Replace("D", ""));
            }

            else if (key == Keys.Back)
            {
                if (sb.Length > 0)
                {
                    sb.Remove(sb.Length - 1, 1);
                }
            }

            if (userInputState == UserInpuState.NameInput)
            {
                userName = sb.ToString();
            }
            else
            {
                userPassword = sb.ToString();
            }

        }

        private bool IsKeyLetter(Keys key)
        {
            return key >= Keys.A && key <= Keys.Z;
        }

        private bool IsKeyDigit(Keys key)
        {
            return key >= Keys.D0 && key <= Keys.D9 || key >= Keys.NumPad0 && key <= Keys.NumPad9;
        }

        public void ChangeErrorMessage(string message)
        {
            this.errorMessage = message;
        }

        public void ClearCurrentUserDetails()
        {
            this.userName = String.Empty;
            this.userPassword = String.Empty;
        }
    }
}
