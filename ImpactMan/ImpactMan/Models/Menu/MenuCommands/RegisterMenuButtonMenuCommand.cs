using System;
using ImpactMan.Attributes;

namespace ImpactMan.Models.Menu.MenuCommands
{
    using Context.Models;
    using Core;
    using Interfaces.Core;
    using Microsoft.Xna.Framework.Content;

    public class RegisterMenuButtonMenuCommand : MenuCommand
    {
        [InjectAttribute]
        private MenuController menuController;

        [InjectAttribute]
        private ContentManager content;

        public RegisterMenuButtonMenuCommand(IEngine engine/*, MenuController menuController, ContentManager content, AccountManager accountManager, User user*/) 
            : base(engine/*, menuController, content, accountManager, user*/)
        {
        }

        public override void Execute(User user)
        {
            this.menuController.Initialize("RegisterMenu");
            this.menuController.Load(this.content);
            this.Engine.ClearCurrentUserDetails();
            this.Engine.ChangeErrorMessage(String.Empty);
            this.Engine.ChangeGameState(GameState.SignUpMenuActive);
        }
    }
}
