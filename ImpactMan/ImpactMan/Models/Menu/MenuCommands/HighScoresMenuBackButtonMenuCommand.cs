namespace ImpactMan.Models.Menu.MenuCommands
{
    using Enumerations.Game;
    using Attributes;
    using Context.Models;
    using Core;
    using Interfaces.Core;
    using Microsoft.Xna.Framework.Content;
    using System;

    public class HighScoresMenuBackButtonMenuCommand : MenuCommand
    {
        [Inject]
        private MenuInitializer menuController;

        [InjectAttribute]
        private ContentManager content;

        public HighScoresMenuBackButtonMenuCommand(IEngine engine) 
            : base(engine)
        {
        }

        public override void Execute(User user)
        {
            this.menuController.Initialize("MainMenu");
            this.menuController.Load(this.content);

            State.GameState = GameState.MainMenu;
        }
    }
}
