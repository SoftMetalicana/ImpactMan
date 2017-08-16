
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

        public override void Execute(User user)
        {
            base.Execute(user);

            this.menuController.Initialize("RegisterMenu");
            this.menuController.Load(this.content);

            State.GameState = GameState.SignUpMenu;

            this.Engine.ChangeErrorMessage(String.Empty);
        }
    }
}