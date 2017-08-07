namespace ImpactMan.Models.Menu.MenuCommands
{
    using Context.Models;
    using Interfaces.Core;

    public class HighScoresMenuCommand : MenuCommand
    {
        public HighScoresMenuCommand(IEngine engine) 
            : base(engine)
        {
        }

        public override void Execute(User user)
        {

        }
    }
}
