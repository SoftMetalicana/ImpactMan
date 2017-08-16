namespace ImpactMan.Models.Menu.MenuCommands
{
    using System;
    using Enumerations.Game;
    using Attributes;
    using Context.Models;
    using Core;
    using Interfaces.Core;
    using Microsoft.Xna.Framework.Content;

    public class RegisterDoneMenuCommand : MenuCommand
    {
        [InjectAttribute]
        private AccountManager accountManager;

        [InjectAttribute]
        private MenuInitializer menuController;

        [InjectAttribute]
        private ContentManager content;

        private bool userCanBeRegistered;

        public RegisterDoneMenuCommand(IEngine engine)
            : base(engine)
        {
        }

        public override void Execute(User user)
        {
            string message = String.Empty;

            userCanBeRegistered = this.accountManager.Register(user, out message);

            if (userCanBeRegistered)
            {
                this.menuController.Initialize("LoginMenu");
                this.menuController.Load(this.content);

                State.GameState = GameState.LoginMenu;
                this.Engine.ChangeErrorMessage(Messages.UserRegisteredSuccessfullyMessage);
            }
            else
            {
                this.Engine.ChangeErrorMessage(message);
            }
        }
    }
}