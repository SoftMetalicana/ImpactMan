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

        public override void Execute(User user)
        {
            user.HighScore = 0;
            State.GameState = GameState.SettingsMenu;

            string formatedMessage = string.Format(Messages.ResetHighScoreSuccessfullyMessage, user.Name);
            this.Engine.ChangeErrorMessage(formatedMessage);
        }
    }
}