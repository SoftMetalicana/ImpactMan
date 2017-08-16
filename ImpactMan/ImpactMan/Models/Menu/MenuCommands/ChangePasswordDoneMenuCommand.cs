using ImpactMan.Enumerations.Game;

namespace ImpactMan.Models.Menu.MenuCommands
{
    using ImpactMan.Attributes;
    using ImpactMan.Context.Models;
    using ImpactMan.Core;
    using ImpactMan.Interfaces.Core;
    using Microsoft.Xna.Framework.Content;

    public class ChangePasswordDoneMenuCommand : MenuCommand
    {
        [Inject]
        private AccountManager accountManager;

        [InjectAttribute]
        private MenuInitializer menuController;

        [InjectAttribute]
        private ContentManager content;

        private bool passwordCanBeChanged;

        public ChangePasswordDoneMenuCommand(IEngine engine) : base(engine)
        {
        }

        public override void Execute(User user)
        {
            string message = string.Empty;
            passwordCanBeChanged = accountManager.ChangePassword(user,out message);

            if (passwordCanBeChanged)
            {
                this.menuController.Initialize("MainMenu");
                this.menuController.Load(this.content);

                State.GameState = GameState.MainMenu;
                this.Engine.ChangeErrorMessage(message);
            }
            else
            {
                this.Engine.ChangeErrorMessage(message);
            }
        }
    }
}
