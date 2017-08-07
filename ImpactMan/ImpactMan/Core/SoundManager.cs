namespace ImpactMan.Core
{
    using Microsoft.Xna.Framework.Media;
    using Enumerations.Sounds;
    using Microsoft.Xna.Framework.Content;

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
        }
    }
}
