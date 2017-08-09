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
        [InjectAttribute]
        private MenuInitializer menuController;

        [InjectAttribute]
        private ContentManager content;

        public RegisterMenuButtonMenuCommand(IEngine engine) 
            : base(engine)
        {
        }

        public override void InitializeMenu(User user)
        {
            this.menuController.Initialize("RegisterMenu");
            this.menuController.Load(this.content);
        }

        public override void ChangeGamestate(User user)
        {
            this.Engine.ChangeGameState(GameState.SignUpMenu);
        }

        public override void ChangeErrorMessage(User user)
        {
            this.Engine.ChangeErrorMessage(String.Empty);
        }

        public override void ChangeUserInputState(User user)
        {
            
        }
    }
}
