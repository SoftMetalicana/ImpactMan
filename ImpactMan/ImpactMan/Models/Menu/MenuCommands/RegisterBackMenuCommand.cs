using System;

namespace ImpactMan.Models.Menu.MenuCommands
{
    using Context.Models;
    using Core;
    using Interfaces.Core;
    using Microsoft.Xna.Framework.Content;

    public class RegisterBackMenuCommand : MenuCommand
    {
        public RegisterBackMenuCommand(IEngine engine, MenuController menuController, ContentManager content, AccountManager accountManager, User user) : base(engine, menuController, content, accountManager, user)
        {
        }

        public override void Execute(User user)
        {
            this.MenuController.Initialize("LoginMenu");
            this.MenuController.Load(this.Content);
            this.Engine.ChangeGameState(GameState.LoginMenuActive);
            this.Engine.ClearCurrentUserDetails();
        }
    }
}
