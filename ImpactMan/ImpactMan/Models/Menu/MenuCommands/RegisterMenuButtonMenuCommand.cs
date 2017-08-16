namespace ImpactMan.Models.Menu.MenuCommands
{
    using Attributes;
    using Context.Models;
    using Core;
    using Enumerations.Game;
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
            State.GameState = GameState.SignUpMenu;
        }

        public override void ChangeErrorMessage(User user)
        {
            this.Engine.ChangeErrorMessage(string.Empty);
        }
    }
}
