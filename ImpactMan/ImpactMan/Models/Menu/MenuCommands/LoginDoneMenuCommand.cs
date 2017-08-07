

namespace ImpactMan.Models.Menu.MenuCommands
{
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
        private MenuController menuController;

        [InjectAttribute]
        private ContentManager content;

        public LoginDoneMenuCommand(IEngine engine/*, MenuController menuController, ContentManager content, AccountManager accountManager, User user*/) 
            : base(engine/*, menuController, content, accountManager, user*/)
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
