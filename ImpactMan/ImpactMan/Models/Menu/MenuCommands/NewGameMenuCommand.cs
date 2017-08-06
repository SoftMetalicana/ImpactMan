namespace ImpactMan.Models.Menu.MenuCommands
{
    using Context.Models;
    using Core;
    using Interfaces.Core;
    using Microsoft.Xna.Framework.Content;

    public class NewGameMenuCommand : MenuCommand
    {
        public NewGameMenuCommand(IEngine engine, MenuController menuController, ContentManager content, AccountManager accountManager, User user) 
            : base(engine, menuController, content, accountManager, user)
        {
        }

        public override void Execute(User user)
        {
            this.Engine.ChangeGameState(GameState.GameMode);
        }
    }
}
