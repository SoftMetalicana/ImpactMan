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
        private MenuInitializer menuController;

        [InjectAttribute]
        private ContentManager content;

        public HighScoresMenuBackButtonMenuCommand(IEngine engine) : base(engine)
        {
        }

        public override void InitializeMenu(User user)
        {
            this.menuController.Initialize("MainMenu");
            this.menuController.Load(this.content);
        }

        public override void ChangeGamestate(User user)
        {
            this.Engine.ChangeGameState(GameState.MainMenu);
        }
    }
}
