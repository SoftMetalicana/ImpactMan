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
        private MenuController menuController;

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
            Engine.ChangeGameState(GameState.HighScoresMenuActive);
        }
    }
}
