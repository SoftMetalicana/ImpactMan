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

        public override void InitializeMenu(User user)
        {

        }

        public override void ChangeGamestate(User user)
        {

        }
    }
}
