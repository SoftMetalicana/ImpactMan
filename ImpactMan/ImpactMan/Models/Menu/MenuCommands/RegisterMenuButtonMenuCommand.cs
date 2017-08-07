namespace ImpactMan.Models.Menu.MenuCommands
{
    using Enumerations.Game;
    using System;
    using Attributes;
    using Context.Models;
    using Core;
    using Interfaces.Core;
    using Microsoft.Xna.Framework.Content;

    public class RegisterMenuButtonMenuCommand : MenuCommand
    {
        [Inject]
        private MenuController menuController;

        [Inject]
        private ContentManager content;

        public RegisterMenuButtonMenuCommand(IEngine engine) 
            : base(engine)
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
