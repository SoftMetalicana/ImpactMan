namespace ImpactMan.Models.Menu.MenuCommands
{
    using Attributes;
    using Context.Models;
    using Core;
    using Enumerations.Game;
    using Interfaces.Core;
    using Microsoft.Xna.Framework.Content;

    public class LoginDoneMenuCommand : MenuCommand
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
            this.userCanBeLoggedIn = this.accountManager.Login(user);

            if (this.userCanBeLoggedIn)
            {
                this.menuController.Initialize("MainMenu");
                this.menuController.Load(this.content);
            }
        }

        public override void ChangeGamestate(User user)
        {
            if (this.userCanBeLoggedIn)
            {
                State.GameState = GameState.MainMenu;
            }
        }

        public override void ChangeUserInputState(User user)
        {
            if (!this.userCanBeLoggedIn)
            {
                base.ChangeUserInputState(user);
            }
        }

        public override void ChangeErrorMessage(User user)
        {
            if (!this.userCanBeLoggedIn)
            {
                this.Engine.ChangeErrorMessage("Invalid username or password!");
            }
        }
    }
}
