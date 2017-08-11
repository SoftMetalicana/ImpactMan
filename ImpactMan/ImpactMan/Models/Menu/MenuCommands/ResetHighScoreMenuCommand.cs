namespace ImpactMan.Models.Menu.MenuCommands
{
    using Context.Models;
    using Interfaces.Core;

    public class ResetHighScoreMenuCommand : MenuCommand
    {
        public ResetHighScoreMenuCommand(IEngine engine) : base(engine)
        {
        }

        public override void InitializeMenu(User user)
        {
            throw new System.NotImplementedException();
        }

        public override void ChangeGamestate(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}