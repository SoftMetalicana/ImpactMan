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

        public override void Execute(User user)
        {
            State.GameState = GameState.GameMode;

            this.soundManager.PlayMusic(Music.GameMusic);

            CurrentUser.User = user;
        }
    }
}
