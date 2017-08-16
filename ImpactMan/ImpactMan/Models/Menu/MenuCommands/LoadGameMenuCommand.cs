namespace ImpactMan.Models.Menu.MenuCommands
{
    using System;
    using ImpactMan.Context.Models;
    using ImpactMan.Interfaces.Core;

    public class LoadGameMenuCommand : MenuCommand
    {
        public LoadGameMenuCommand(IEngine engine) : base(engine)
        {
        }

        public override void InitializeMenu(User user)
        {
            throw new NotImplementedException();
        }

        public override void ChangeGamestate(User user)
        {
            throw new NotImplementedException();
        }
    }
}
