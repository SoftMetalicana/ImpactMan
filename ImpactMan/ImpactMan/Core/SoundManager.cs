namespace ImpactMan.Core
{
    using Enumerations.Sounds;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Media;

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
        //   this.sound = this.content.Load<Song>(music.ToString());
        //   MediaPlayer.Play(this.sound);
        //
        //   MediaPlayer.IsRepeating = true;
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
