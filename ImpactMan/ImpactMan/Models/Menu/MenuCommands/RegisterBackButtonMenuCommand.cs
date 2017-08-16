﻿namespace ImpactMan.Models.Menu.MenuCommands
{
    using Attributes;
    using Context.Models;
    using Core;
    using Enumerations.Game;
    using Interfaces.Core;
    using Microsoft.Xna.Framework.Content;

    public class RegisterBackButtonMenuCommand : MenuCommand
    {
        [InjectAttribute]
        private MenuInitializer menuController;

        [InjectAttribute]
        private ContentManager content;

        public RegisterBackButtonMenuCommand(IEngine engine) 
            : base(engine)
        {
        }

        public override void InitializeMenu(User user)
        {
            this.menuController.Initialize("LoginMenu");
            this.menuController.Load(this.content);
        }

        public override void ChangeGamestate(User user)
        {
            State.GameState = GameState.LoginMenu;
        }
    }
}
