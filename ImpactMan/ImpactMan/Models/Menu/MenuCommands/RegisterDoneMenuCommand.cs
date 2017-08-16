namespace ImpactMan.Models.Menu.MenuCommands
{
    using Attributes;
    using Context.Models;
    using Core;
    using Enumerations.Game;
    using Interfaces.Core;
    using Microsoft.Xna.Framework.Content;

    public class RegisterDoneMenuCommand : MenuCommand
    {
        [InjectAttribute]
        private AccountManager accountManager;

        [InjectAttribute]
        private MenuInitializer menuController;

        [InjectAttribute]
        private ContentManager content;

        private bool userCanBeRegistered;

        public RegisterDoneMenuCommand(IEngine engine) 
            : base(engine)
        {
        }

        public override void InitializeMenu(User user)
        {
            this.userCanBeRegistered = this.accountManager.Register(user);

            if (this.userCanBeRegistered)
            {
                this.menuController.Initialize("LoginMenu");
                this.menuController.Load(this.content);
            }
        }

        public override void ChangeGamestate(User user)
        {
            if (this.userCanBeRegistered)
            {
                State.GameState = GameState.LoginMenu;
            }
        }

        public override void ChangeErrorMessage(User user)
        {
            if (!this.userCanBeRegistered)
            {
                this.Engine.ChangeErrorMessage("User already registered");
            }
        }
    }
}
