namespace ImpactMan.Models.Menu.MenuCommands
{
    using Attributes;
    using Context.Models;
    using Core;
    using Enumerations.Game;
    using Interfaces.Core;
    using Microsoft.Xna.Framework.Content;

    public class ChangePasswordMenuCommand : MenuCommand
    {
        [Inject]
        private MenuInitializer menuController;

        [InjectAttribute]
        private ContentManager content;

        public ChangePasswordMenuCommand(IEngine engine) : base(engine)
        {
        }

        public override void Execute(User user)
        {
            user.Password = string.Empty;
            user.Name = string.Empty;
            this.menuController.Initialize("ChangePasswordMenu");
            this.menuController.Load(this.content);

            State.GameState = GameState.ChangePasswordMenu;
        }
    }
}