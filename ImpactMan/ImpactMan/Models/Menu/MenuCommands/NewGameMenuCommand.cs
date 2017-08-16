namespace ImpactMan.Models.Menu.MenuCommands
{
    using Enumerations.Game;
    using Enumerations.Sounds;
    using Attributes;
    using Context.Models;
    using Core;
    using Interfaces.Core;

    public class NewGameMenuCommand : MenuCommand
    {
        [Inject]
        private SoundManager soundManager;

        public NewGameMenuCommand(IEngine engine)
            : base(engine)
        {
        }

        public override void InitializeMenu(User user)
        {

        }

        public override void ChangeGamestate(User user)
        {

            State.GameState = GameState.GameMode;
        }

        public override void PlayMusic()
        {
            if (this.soundManager.IsRunning())
            {
                this.soundManager.PlayMusic(Music.GameMusic);
            }
        }

        public override void End(User user)
        {
            CurrentUser.User = user;
        }
    }
}
