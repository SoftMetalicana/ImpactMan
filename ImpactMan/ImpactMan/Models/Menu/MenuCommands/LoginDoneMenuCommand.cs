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
        [Inject]
        private AccountManager accountManager;

        [Inject]
        private MenuController menuController;

        [Inject]
        private ContentManager content;

        public LoginDoneMenuCommand(IEngine engine) 
            : base(engine)
        {
        }

        public override void Execute(User user)
        {
            if (this.accountManager.Login(user))
            {
                this.menuController.Initialize("MainMenu");
                this.menuController.Load(this.content);
                this.Engine.ClearCurrentUserDetails();
                this.Engine.ChangeGameState(GameState.MainMenuActive);
            }
            else
            {
                this.Engine.ChangeErrorMessage("Invalid username or password!");
                this.Engine.ClearCurrentUserDetails();
                this.Engine.ChangeUserInputState();
            }           
        }
    }
}
