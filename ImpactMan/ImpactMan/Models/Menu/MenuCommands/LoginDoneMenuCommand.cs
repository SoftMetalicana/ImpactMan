namespace ImpactMan.Models.Menu.MenuCommands
{
    using Context.Models;
    using Core;
    using Interfaces.Core;
    using Microsoft.Xna.Framework.Content;

    class LoginDoneMenuCommand : MenuCommand
    {
        public LoginDoneMenuCommand(IEngine engine, MenuController menuController, ContentManager content, AccountManager accountManager, User user) 
            : base(engine, menuController, content, accountManager, user)
        {
        }

        public override void Execute(User user)
        {
            if (this.AccountManager.Login(user))
            {
                this.MenuController.Initialize("MainMenu");
                this.MenuController.Load(this.Content);
                this.Engine.ClearCurrentUserDetails();
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
