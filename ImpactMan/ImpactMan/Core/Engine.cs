namespace ImpactMan.Core
{
    using Constants.Units;
    using Interfaces.Writer;
    using IO.Writers;
    using Constants.Graphics;
    using Context.Db;
    using Context.Models;
    using Enumerations.Game;
    using Enumerations.Sounds;
    using Interfaces.Models.Enemies;
    using Interfaces.Models.Levels;
    using Interfaces.Core;
    using Interfaces.IO.InputListeners;
    using Interfaces.Models.Mediators;
    using Interfaces.Models.Players;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
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
        private ITextWriter textWriter;

        private IPlayer player;
        private IList<IEnemy> allEnemies;
        private ILevel level;
        private IPlayerConsequenceMediator playerConsequenceMediator;

        private User user;
        private User userInputDetails;
        private string errorMessage;

        private List<Keys> pressedKeys = new List<Keys>();

        private IInitializer initializer;
        private IInputListener inputListener;
        private MenuInitializer menuController;
        private AccountManager accountManager;
        private GameState gameState;
        private UserInputState userInputState;

        ImpactManContext context;

        //This data should be in database
        private Dictionary<string, int> highScores = new Dictionary<string, int>()
        {
            {"Ivan", 44323424 },
            {"Petkan", 43242 },
            {"Dragan", 55 },
            {"Toni", 82 },
            {"Moni", 999575799 },
            {"Boni", 57 },
            {"Dancho", 5 },
            {"Mancho", 7575757 },
            {"Gancho", 17575729 },

        };

        public Engine(IInitializer initializer,
                      IInputListener inputListener,
                      IPlayerConsequenceMediator playerConsequenceMediator,
                      IPlayer player,
                      IList<IEnemy> allEnemies,
                      ILevel level)
        {
            this.Content.RootDirectory = "Content";

            this.graphics = new GraphicsDeviceManager(this);
            this.soundManager = new SoundManager(this.Content);

            this.initializer = initializer;
            this.inputListener = inputListener;

            this.player = player;
            this.allEnemies = allEnemies;
            this.level = level;
            this.playerConsequenceMediator = playerConsequenceMediator;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            this.context = new ImpactManContext();
            this.context.Database.Initialize(false);

            this.userInputDetails = new User();
            this.user = new User();
            this.userInputDetails.Name = String.Empty;
            this.userInputDetails.Password = String.Empty;
            this.errorMessage = String.Empty;

            this.accountManager = new AccountManager(context);
            this.menuController = new MenuInitializer(this, this.Content, this.accountManager, this.user, this.soundManager);


            this.player = this.playerConsequenceMediator.Level.Player;
            this.player.PlayerTriedToMove += this.playerConsequenceMediator.OnPlayerTriedToMove;

            this.inputListener.KeyPressed += this.player.OnKeyPressed;
            this.inputListener.MouseClicked += this.menuController.OnMouseClicked;

            this.menuController.Initialize("LoginMenu");
            this.soundManager.PlayMusic(Music.LoginMusic);

            this.gameState = GameState.LoginMenu;
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

            this.initializer.LoadLevel(this.level, this.Content);

            this.menuController.Load(Content);
            this.spriteFont = this.Content.Load<SpriteFont>("sprite_font");

            this.textWriter = new ConsoleTextWriter(this.spriteFont, this.spriteBatch);
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
                ChangeGameState(GameState.MainMenu);
                this.menuController.Initialize("MainMenu");
                this.menuController.Load(Content);

            }

            if (gameState != GameState.GameMode)
            {
                this.inputListener.GetMouseState(currentMouseState, gameTime, this.userInputDetails);
            }

            if (gameState == GameState.LoginMenu || gameState == GameState.SignUpMenu)
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

            if (this.gameState != GameState.GameMode)
            {
                this.menuController.Draw(this.spriteBatch);
            }

            if (this.gameState == GameState.LoginMenu)
            {
                this.textWriter.WriteUserDetails(this.userInputDetails, this.errorMessage, this.gameState);
            }

            else if (this.gameState == GameState.SignUpMenu)
            {
                this.textWriter.WriteUserDetails(this.userInputDetails, this.errorMessage, this.gameState);
            }

            else if (this.gameState == GameState.HighScoresMenu)
            {
                int count = 0;

                StringBuilder sb = new StringBuilder();

                this.highScores.OrderByDescending(x => x.Value).Take(10).ToList().ForEach(p =>
                {
                    string score = p.Value.ToString(MenuConstants.HighScoresMenuNumberFormat);

                    sb.AppendLine(string.Format(MenuConstants.HighScoresMenuPlayerFormat, ++count, p.Key, score));
                    sb.AppendLine();
                });

                this.textWriter.Write(sb.ToString(),
                    new Vector2(MenuConstants.HighScoresMenuX, MenuConstants.HighScoresMenuY),
                    Color.Black);
            }

            else if (this.gameState == GameState.GameMode)
            {
                this.level.Draw(this.spriteBatch);

                this.player.Draw(this.spriteBatch);

                foreach (IEnemy enemy in this.allEnemies)
                {
                    enemy.Draw(this.spriteBatch);
                }
            }

            this.spriteBatch.End();

            base.Draw(gameTime);
        }

        private void GetPressedKeys()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            List<Keys> currentKeys = keyboardState.GetPressedKeys().ToList();

            foreach (Keys key in this.pressedKeys)
            {
                if (!currentKeys.Contains(key))
                {
                    OnReleasedKey(key);
                }
            }

            this.pressedKeys = currentKeys;
        }

        private void OnReleasedKey(Keys key)
        {
            StringBuilder sb = new StringBuilder();

            if (key == Keys.Tab)
            {
                ChangeUserInputState();
            }

            if (this.userInputState == UserInputState.NameInput)
            {
                sb = new StringBuilder(this.userInputDetails.Name);
            }
            else
            {
                sb = new StringBuilder(this.userInputDetails.Password);
            }

            if (Utils.KeyValueCheck.IsKeyLetter(key))
            {
                sb.Append(key);
            }

            else if (Utils.KeyValueCheck.IsKeyDigit(key))
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

            if (this.userInputState == UserInputState.NameInput)
            {
                this.userInputDetails.Name = sb.ToString();
            }
            else
            {
                this.userInputDetails.Password = sb.ToString();
            }

        }

        public void ChangeGameState(GameState gameStateToChange)
        {
            this.gameState = gameStateToChange;
        }

        public void ChangeUserInputState()
        {
            this.userInputState = (UserInputState)(((int)this.userInputState + 1) % 2);
        }

        public void Quit()
        {
            Exit();
        }

        public void SetWindowTitle(string title = GraphicsConstants.WindowTitle)
        {
            this.Window.Title = title;
        }

        public void ChangeErrorMessage(string message)
        {
            this.errorMessage = message;
        }

        public void ClearCurrentUserDetails()
        {
            this.userInputDetails = new User();
            this.userInputDetails.Name = String.Empty;
            this.userInputDetails.Password = String.Empty;
        }

    }
}
