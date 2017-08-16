namespace ImpactMan.Models.Menu.MenuCommands
{
    using Attributes;
    using Context.Models;
    using Core;
    using Enumerations.Game;
    using Interfaces.Core;
    using Microsoft.Xna.Framework.Content;

    public class HighScoresMenuCommand : MenuCommand
    {
        [Inject]
        private MenuInitializer menuController;

        [Inject]
        private ContentManager content;

        public HighScoresMenuCommand(IEngine engine) 
            : base(engine)
        {
        }

        public override void InitializeMenu(User user)
        {
            this.menuController.Initialize("HighScoresMenu");
            this.menuController.Load(this.content);
        }

        public override void ChangeGamestate(User user)
        {
            State.GameState = GameState.HighScoresMenu;
        }
    }
}
