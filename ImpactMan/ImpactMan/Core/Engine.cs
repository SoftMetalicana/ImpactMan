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

        private User userInputDetails;
        private string errorMessage;

        private List<Keys> pressedKeys;

        private IInitializer initializer;
        private IInputListener inputListener;
        private MenuInitializer menuInitializer;
        private AccountManager accountManager;

        ImpactManContext context;

        //This data should be in database
        private Dictionary<string, int> highScores;


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
            this.pressedKeys = new List<Keys>();
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
            this.context.Database.Initialize(true);

    
            this.highScores = new Dictionary<string, int>();
            LoadHighScores(highScores);

            this.userInputDetails = new User();
            this.userInputDetails.Name = String.Empty;
            this.userInputDetails.Password = String.Empty;
            this.errorMessage = String.Empty;

            this.accountManager = new AccountManager(context);
            this.menuInitializer = new MenuInitializer(this, this.Content, this.accountManager, this.soundManager);


            this.player = this.playerConsequenceMediator.Level.Player;
            this.player.PlayerTriedToMove += this.playerConsequenceMediator.OnPlayerTriedToMove;

            this.inputListener.KeyPressed += this.player.OnKeyPressed;
            this.inputListener.MouseClicked += this.menuInitializer.OnMouseClicked;

            this.menuInitializer.Initialize("LoginMenu");
            this.soundManager.PlayMusic(Music.LoginMusic);


            this.initializer.SetGameMouse(this, GraphicsConstants.IsMouseVisible);
            this.initializer.SetGraphicsWindowSize(this.graphics,
                                                   GraphicsConstants.PreferredBufferWidth,
                                                   GraphicsConstants.PreferredBufferHeight);
            this.initializer.SetGameStates();

            SetWindowTitle();
            base.Initialize();
        }

        // Adds the top 10 scores to the highscore dictonary
        private void LoadHighScores(Dictionary<string,int> highscores)
        {
            var users = context.Users.OrderByDescending(u => u.HighScore).Take(10).ToList();
            if (users.Count>0)
            {
                foreach (var user in users)
                {
                    highscores.Add(user.Name, user.HighScore);
                }
            }
          
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

            this.menuInitializer.Load(Content);
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

            if (currentKeyboardState.IsKeyDown(Keys.Home) && State.GameState == GameState.GameMode)
            {
                State.GameState = GameState.MainMenu;
                this.menuInitializer.Initialize("MainMenu");
                this.menuInitializer.Load(Content);
            }

            if (State.GameState != GameState.GameMode)
            {
                this.inputListener.GetMouseState(currentMouseState, gameTime, this.userInputDetails);
            }

            if (State.GameState == GameState.LoginMenu || State.GameState == GameState.SignUpMenu)
            {
                GetPressedKeys();
            }

            if (State.GameState == GameState.GameMode)
            {
                this.inputListener.GetKeyboardState(currentKeyboardState, gameTime);

                foreach (var enemy in this.allEnemies)
                {
                    enemy.Update(gameTime, currentKeyboardState);
                }
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

            if (State.GameState != GameState.GameMode)
            {
                this.menuInitializer.Draw(this.spriteBatch);
            }

            if (State.GameState == GameState.LoginMenu)
            {
                this.textWriter.WriteUserDetails(this.userInputDetails, this.errorMessage);
            }

            else if (State.GameState == GameState.SignUpMenu)
            {
                this.textWriter.WriteUserDetails(this.userInputDetails, this.errorMessage);
            }

            else if (State.GameState == GameState.HighScoresMenu)
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

            else if (State.GameState == GameState.GameMode)
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
                State.UserInputState = (UserInputState)(((int)State.UserInputState + 1) % 2);
            }

            if (State.UserInputState == UserInputState.NameInput)
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

            if (State.UserInputState == UserInputState.NameInput)
            {
                this.userInputDetails.Name = sb.ToString();
            }
            else
            {
                this.userInputDetails.Password = sb.ToString();
            }

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
