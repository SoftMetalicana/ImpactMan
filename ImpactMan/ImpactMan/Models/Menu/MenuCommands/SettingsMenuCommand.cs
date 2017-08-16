namespace ImpactMan.Models.Menu.MenuCommands
{
    using Context.Models;
    using Interfaces.Core;

    public class SettingsMenuCommand : MenuCommand
    {
        public SettingsMenuCommand(IEngine engine) 
            : base(engine)
        {
        }

        public override void Execute(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
