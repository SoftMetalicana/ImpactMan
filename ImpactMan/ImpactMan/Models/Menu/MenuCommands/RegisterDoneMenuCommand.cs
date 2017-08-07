﻿namespace ImpactMan.Models.Menu.MenuCommands
{
    using Enumerations.Game;
    using Attributes;
    using Context.Models;
    using Core;
    using Interfaces.Core;
    using Microsoft.Xna.Framework.Content;

    public class RegisterDoneMenuCommand : MenuCommand
    {
        [Inject]
        private AccountManager accountManager;

        [Inject]
        private MenuController menuController;

        [Inject]
        private ContentManager content;

        public RegisterDoneMenuCommand(IEngine engine) 
            : base(engine)
        {
        }

        public override void Execute(User user)
        {
            if (this.accountManager.Register(user))
            {
                this.menuController.Initialize("LoginMenu");
                this.menuController.Load(this.content);
                this.Engine.ChangeGameState(GameState.LoginMenuActive);
                this.Engine.ClearCurrentUserDetails();
                this.Engine.ChangeUserInputState();
            }
            else
            {
                this.Engine.ChangeErrorMessage("User already registered");
                this.Engine.ClearCurrentUserDetails();
                this.Engine.ChangeUserInputState();
            }
        }
    }
}
