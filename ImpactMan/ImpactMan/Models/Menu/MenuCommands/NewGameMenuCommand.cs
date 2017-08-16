namespace ImpactMan.Models.Menu.MenuCommands
{
    using Attributes;
    using Context.Models;
    using Core;
    using Enumerations.Game;
    using Enumerations.Sounds;
    using Interfaces.Core;

    public class NewGameMenuCommand : MenuCommand
    {
        [Inject]
        private SoundManager soundManager;

        public NewGameMenuCommand(IEngine engine)
            : base(engine)
        {
        }

        public override void Execute(User user)
        {
            base.Execute(user);

            State.GameState = GameState.GameMode;

            if (this.soundManager.IsRunning())
            {
                this.soundManager.PlayMusic(Music.GameMusic);
            }
        }
    }
}
