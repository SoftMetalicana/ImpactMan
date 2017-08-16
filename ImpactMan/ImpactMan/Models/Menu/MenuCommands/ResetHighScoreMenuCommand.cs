namespace ImpactMan.Models.Menu.MenuCommands
{
    using Context.Models;
    using Core;
    using Enumerations.Game;
    using Interfaces.Core;

    public class ResetHighScoreMenuCommand : MenuCommand
    {
        public ResetHighScoreMenuCommand(IEngine engine) : base(engine)
        {
        }

        public override void InitializeMenu(User user)
        {
            user.HighScore = 0;
        }

        public override void ChangeGamestate(User user)
        {
            State.GameState = GameState.SettingsMenu;
        }
    }
}