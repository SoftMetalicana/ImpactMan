namespace ImpactMan.Models.Menu.MenuCommands
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

        public override void Execute(User user)
        {
            base.Execute(user);

            this.menuController.Initialize("LoginMenu");
            this.menuController.Load(this.content);

            this.Engine.ClearCurrentUserDetails();

            State.GameState = GameState.LoginMenu;
        }
    }
}
