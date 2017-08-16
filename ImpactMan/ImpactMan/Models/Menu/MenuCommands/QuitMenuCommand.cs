namespace ImpactMan.Models.Menu.MenuCommands
{
    using Context.Models;
    using Interfaces.Core;

    public class QuitMenuCommand : MenuCommand
    {
        public QuitMenuCommand(IEngine engine) 
            : base(engine)
        {
        }

        public override void InitializeMenu(User user)
        {
            
        }

        public override void ChangeGamestate(User user)
        {
            
        }

        public override void End(User user)
        {
            this.Engine.Quit();
        }
    }
}
