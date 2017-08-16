namespace ImpactMan.Core
{
    using Microsoft.Xna.Framework.Media;
    using Enumerations.Sounds;
    using Microsoft.Xna.Framework.Content;

    /// <summary>
    /// This class takes care of the background music palyed during the game.
    /// </summary>
    public class SoundManager
    {
        private Song sound;
        private ContentManager content;

        public SoundManager(ContentManager content)
        {
            this.content = content;
        }

        public void PlayMusic(Music music)
        {
            sound = content.Load<Song>(music.ToString());
            MediaPlayer.Play(sound);

            MediaPlayer.IsRepeating = true;
        }

        public bool IsRunning()
        {
            MediaState playerState = MediaPlayer.State;
            return playerState.ToString() == "Playing";
        }

        public void StopMusic()
        {
            MediaPlayer.Stop();
        }
    }
}
