using System;
using ImpactMan.Attributes;

namespace ImpactMan.Models.Menu.MenuCommands
{
    using Context.Models;
    using Core;
    using Interfaces.Core;
    using Microsoft.Xna.Framework.Content;

    public class RegisterBackButtonMenuCommand : MenuCommand
    {
        [Inject]
        private MenuController menuController;

        [Inject]
        private ContentManager content;

        public RegisterBackButtonMenuCommand(IEngine engine/*, MenuController menuController, ContentManager content, AccountManager accountManager, User user*/) 
            : base(engine/*, menuController, content, accountManager, user*/)
        {
        }

        public override void Execute(User user)
        {
            this.menuController.Initialize("LoginMenu");
            this.menuController.Load(this.content);
            this.Engine.ChangeGameState(GameState.LoginMenuActive);
            this.Engine.ClearCurrentUserDetails();
        }
    }
}
