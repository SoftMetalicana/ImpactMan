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

        public override void Execute(User user)
        {
            base.Execute(user);

            this.Engine.Quit();
        }
    }
}
