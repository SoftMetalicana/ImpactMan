namespace ImpactMan.Models.Menu.MenuCommands
{
    using Attributes;
    using Core;
    using Enumerations.Game;
    using Microsoft.Xna.Framework.Content;
    using Context.Models;
    using Interfaces.Core;

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
            base.Execute(user);

            menuController.Initialize("HighScoresMenu");
            menuController.Load(this.content);

            State.GameState = GameState.HighScoresMenu;
        }
    }
}
