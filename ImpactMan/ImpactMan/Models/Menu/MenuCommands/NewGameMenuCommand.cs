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
            this.Engine.ChangeGameState(GameState.GameMode);
        }

        public override void PlayMusic()
        {
            this.soundManager.PlayMusic(Music.GameMusic);
        }
    }
}
