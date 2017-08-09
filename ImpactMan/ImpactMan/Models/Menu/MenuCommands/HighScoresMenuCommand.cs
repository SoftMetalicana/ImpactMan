using ImpactMan.Attributes;
using ImpactMan.Core;
using ImpactMan.Enumerations.Game;
using Microsoft.Xna.Framework.Content;

namespace ImpactMan.Models.Menu.MenuCommands
{
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

        public override void InitializeMenu(User user)
        {
            menuController.Initialize("HighScoresMenu");
            menuController.Load(this.content);
        }

        public override void ChangeGamestate(User user)
        {
            Engine.ChangeGameState(GameState.HighScoresMenu);
        }
    }
}
