namespace ImpactMan.Models.Menu.MenuCommands
{
    using Enumerations.Game;
    using Attributes;
    using Context.Models;
    using Core;
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

        public override void Execute(User user)
        {
            userCanBeRegistered = this.accountManager.Register(user);

            if (userCanBeRegistered)
            {
                this.menuController.Initialize("LoginMenu");
                this.menuController.Load(this.content);

                State.GameState = GameState.LoginMenu;
            }
            else
            {
                this.Engine.ChangeErrorMessage("User already registered");
            }
        }
    }
}
