namespace ImpactMan.Models.Menu.MenuCommands
{
    using Enumerations.Game;
    using Attributes;
    using Context.Models;
    using Core;
    using Interfaces.Core;
    using Microsoft.Xna.Framework.Content;

    public class LoginDoneMenuCommand : MenuCommand
    {
        [InjectAttribute] private AccountManager accountManager;

        [InjectAttribute] private MenuInitializer menuController;

        [InjectAttribute] private ContentManager content;

        private bool userCanBeLoggedIn;

        public LoginDoneMenuCommand(IEngine engine)
            : base(engine)
        {
        }

        public override void Execute(User user)
        {
            userCanBeLoggedIn = this.accountManager.Login(user);

            if (userCanBeLoggedIn)
            {
                this.menuController.Initialize("MainMenu");
                this.menuController.Load(this.content);

                State.GameState = GameState.MainMenu;
            }
            else
            {
                State.UserInputState = UserInputState.NameInput;

                {
                    this.Engine.ChangeErrorMessage(Messages.InvalidUsernameOrPasswordMessage);
                }
            }
        }
    }
}
