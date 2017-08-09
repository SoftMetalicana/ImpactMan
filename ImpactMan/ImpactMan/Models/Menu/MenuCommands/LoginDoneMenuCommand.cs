namespace ImpactMan.Models.Menu.MenuCommands
{
    using Enumerations.Game;
    using Attributes;
    using Context.Models;
    using Core;
    using Interfaces.Core;
    using Microsoft.Xna.Framework.Content;

    class LoginDoneMenuCommand : MenuCommand
    {
        [InjectAttribute]
        private AccountManager accountManager;

        [InjectAttribute]
        private MenuInitializer menuController;

        [InjectAttribute]
        private ContentManager content;

        private bool userCanBeLoggedIn;

        public LoginDoneMenuCommand(IEngine engine) 
            : base(engine)
        {
        }

        public override void InitializeMenu(User user)
        {
            userCanBeLoggedIn = this.accountManager.Login(user);

            if (userCanBeLoggedIn)
            {
                this.menuController.Initialize("MainMenu");
                this.menuController.Load(this.content);
            }
        }

        public override void ChangeGamestate(User user)
        {
            if (userCanBeLoggedIn)
            {
                this.Engine.ChangeGameState(GameState.MainMenu);
            }
        }

        public override void ChangeUserInputState(User user)
        {
            if (!userCanBeLoggedIn)
            {
                this.Engine.ChangeUserInputState();
            }
        }

        public override void ChangeErrorMessage(User user)
        {
            if (!userCanBeLoggedIn)
            {
                this.Engine.ChangeErrorMessage("Invalid username or password!");
            }
        }
    }
}
