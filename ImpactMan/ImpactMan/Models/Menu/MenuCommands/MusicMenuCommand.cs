namespace ImpactMan.Models.Menu.MenuCommands
{
    using Attributes;
    using Context.Models;
    using Core;
    using Enumerations.Game;
    using Enumerations.Sounds;
    using Interfaces.Core;

    public class MusicMenuCommand : MenuCommand
    {
        [Inject]
        private SoundManager soundManager;

        public MusicMenuCommand(IEngine engine) : base(engine)
        {
        }

        public override void Execute(User user)
        {
            this.PlayMusic();
            State.GameState = GameState.SettingsMenu;
        }

        private void PlayMusic()
        {
            if (this.soundManager.IsRunning())
            {
                this.soundManager.StopMusic();
            }
            else
            {
                this.soundManager.PlayMusic(Music.LoginMusic);
            }
        }
    }
}