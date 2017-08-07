using ImpactMan.Enumerations.Game;

namespace ImpactMan.Models.Menu.MenuCommands
{
    using Attributes;
    using Context.Models;
    using Core;
    using Interfaces.Core;
    using Microsoft.Xna.Framework.Content;
    using System;

    class HighScoresMenuBackButtonMenuCommand : MenuCommand
    {
        [Inject]
        private MenuController menuController;

        [InjectAttribute]
        private ContentManager content;

        public HighScoresMenuBackButtonMenuCommand(IEngine engine) : base(engine)
        {
        }

        public override void Execute(User user)
        {
            this.menuController.Initialize("MainMenu");
            this.menuController.Load(this.content);
            this.Engine.ChangeGameState(GameState.MainMenuActive);
            this.Engine.ClearCurrentUserDetails();
        }
    }
}
