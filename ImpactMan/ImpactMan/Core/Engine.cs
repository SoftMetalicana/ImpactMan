using ImpactMan.Constants.Units;
using ImpactMan.IO.OutputWriter;

namespace ImpactMan.Core
{
    using Enumerations.Game;
    using Enumerations.Sounds;
    using Constants.Graphics;
    using Context.Db;
    using Context.Models;
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
    using System.Text;

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Engine : Game, IEngine
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;
        private SoundManager soundManager;
        private ConsoleTextWriter textWriter;

        private IPlayer player;
        private User user;
        private User userInputDetails;
        private string errorMessage;

        private List<Keys> pressedKeys = new List<Keys>();

        private IInitializer initializer;
        private IInputListener inputListener;
        private MenuController menuController;
        private AccountManager accountManager;
        private GameState gameState;
        private UserInputState userInputState;

        ImpactManContext context;

        //This data should be in database
        private Dictionary<string, int> highScores = new Dictionary<string, int>()
        {
            {"Ivan", 22565 },
            {"Petkan", 5522 },
            {"Dragan", 102 },
            {"Toni", 55896 },
            {"Moni", 11255254 },
            {"Boni", 5595 },
            {"Dancho", 787 },
            {"Mancho", 14 },
            {"Gancho", 6698 },

        };

        public Engine()
            : this(new Initializer(),
                   new InputListener())
        {
        }

        public Engine(IInitializer initializer,
                      IInputListener inputListener)
        {
            this.Content.RootDirectory = "Content";

            this.graphics = new GraphicsDeviceManager(this);
            this.soundManager = new SoundManager(this.Content);

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
            this.userInputDetails.Name = String.Empty;
            this.userInputDetails.Password = String.Empty;
            this.errorMessage = String.Empty;

            this.accountManager = new AccountManager();
            this.menuController = new MenuController(this, this.Content, this.accountManager, this.user, this.soundManager);


            // MUST BE DONE FROM HERE
            /*            this.context = new ImpactManContext();
                        this.context.Database.Initialize(true);*/

            this.player = new PacMan(0, 0, "food");
            this.player.Load(this.Content);

            this.inputListener.KeyPressed += this.player.OnKeyPressed;
            this.inputListener.MouseClicked += this.menuController.OnMouseClicked;

            this.menuController.Initialize("LoginMenu");
            this.soundManager.PlayMusic(Music.LoginMusic);

            this.gameState = GameState.LoginMenuActive;
            this.userInputState = UserInputState.NameInput;

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

            this.menuController.Load(Content);
            this.spriteFont = this.Content.Load<SpriteFont>("sprite_font");

            this.textWriter = new ConsoleTextWriter(this.spriteBatch, this.spriteFont);
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
                this.textWriter.WriteOnConsole(this.userInputDetails.Name, 
                    new Vector2(MenuConstants.LoginMenuUsernameX, 
                    MenuConstants.LoginMenuUsernameY), 
                    Color.Black);

                this.textWriter.WriteOnConsole(this.userInputDetails.Password, 
                    new Vector2(MenuConstants.LoginMenuPasswordX, 
                    MenuConstants.LoginMenuPasswordY), 
                    Color.Black);

                this.textWriter.WriteOnConsole(this.errorMessage, 
                    new Vector2(MenuConstants.LoginMenuErrorMessageX, 
                    MenuConstants.LoginMenuErrorMessageY), 
                    Color.Black);
            }

            else if (gameState == GameState.SignUpMenuActive)
            {
                this.textWriter.WriteOnConsole(this.userInputDetails.Name, 
                    new Vector2(MenuConstants.SignupMenuUsernameX, 
                    MenuConstants.SignupMenuUsernameY), 
                    Color.Black);

                this.textWriter.WriteOnConsole(this.userInputDetails.Password, 
                    new Vector2(MenuConstants.SignupMenuPasswordX, 
                    MenuConstants.SignupMenuPasswordY), 
                    Color.Black);

                this.textWriter.WriteOnConsole(this.errorMessage, 
                    new Vector2(MenuConstants.SignupMenuErrorMessageX, 
                    MenuConstants.SignupMenuErrorMessageY), 
                    Color.Black);
            }

            else if (gameState == GameState.HighScoresMenuActive)
            {
                int xCoordinate = 760;
                int yCoordinate = 313;

                foreach (var player in this.highScores.OrderByDescending(x => x.Value).Take(10))
                {
                    textWriter.WriteOnConsole($"{player.Key} - {player.Value}", new Vector2(xCoordinate, yCoordinate), Color.White);

                    yCoordinate += 45;
                }
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

        public void ChangeUserInputState()
        {
            this.userInputState = (UserInputState)(((int)userInputState + 1) % 2);
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

        private void OnReleasedKey(Keys key)
        {
            StringBuilder sb = new StringBuilder();

            if (key == Keys.Tab)
            {
                ChangeUserInputState();
            }

            if (userInputState == UserInputState.NameInput)
            {
                sb = new StringBuilder(this.userInputDetails.Name);
            }
            else
            {
                sb = new StringBuilder(this.userInputDetails.Password);
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

            if (userInputState == UserInputState.NameInput)
            {
                this.userInputDetails.Name = sb.ToString();
            }
            else
            {
                this.userInputDetails.Password = sb.ToString();
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
            this.userInputDetails.Name = String.Empty;
            this.userInputDetails.Password = String.Empty;
        }
    }
}
