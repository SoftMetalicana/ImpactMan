namespace ImpactMan.Models.Menu.MenuCommands
{
    using Context.Models;
    using Core;
    using Interfaces.Core;
    using Microsoft.Xna.Framework.Content;

    public class RegisterDoneMenuCommand : MenuCommand
    {
        public RegisterDoneMenuCommand(IEngine engine, MenuController menuController, ContentManager content, AccountManager accountManager, User user) : base(engine, menuController, content, accountManager, user)
        {
        }

        public override void Execute(User user)
        {
            if (this.AccountManager.Register(user))
            {
                this.MenuController.Initialize("LoginMenu");
                this.MenuController.Load(this.Content);
                this.Engine.ChangeGameState(GameState.LoginMenuActive);
                this.Engine.ClearCurrentUserDetails();
                this.Engine.ChangeUserInputState();
            }
            else
            {
                this.Engine.ChangeErrorMessage("User already registered");
                this.Engine.ClearCurrentUserDetails();
                this.Engine.ChangeUserInputState();
            }
        }
    }
}
