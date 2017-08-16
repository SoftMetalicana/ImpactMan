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

        public override void Execute(User user)
        {
            menuController.Initialize("HighScoresMenu");
            menuController.Load(this.content);

            State.GameState = GameState.HighScoresMenu;
        }
    }
}
