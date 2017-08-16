namespace ImpactMan.Models.Menu.MenuCommands
{
    using Attributes;
    using Context.Models;
    using Core;
    using Enumerations.Game;
    using Interfaces.Core;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;

    public class SettingsMenuCommand : MenuCommand
    {
        [Inject]
        private MenuInitializer menuController;

        [InjectAttribute]
        private ContentManager content;

        public SettingsMenuCommand(IEngine engine)
            : base(engine)
        {
        }

        public override void Execute(User user)
        {
            this.menuController.Initialize("SettingsMenu");
            this.menuController.Load(this.content);

            State.GameState = GameState.SettingsMenu;
        }
    }
}
