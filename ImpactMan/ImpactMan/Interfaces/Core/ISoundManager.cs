namespace ImpactMan.Interfaces.Core
{
    using ImpactMan.Enumerations.Sounds;

    /// <summary>
    /// This interface must be inheritated by the SoundManager
    /// </summary>
    public interface ISoundManager
    {
        //This method plays the selected music
        void PlayMusic(Music music);

        // Checks if the music is running
        bool IsRunning();

        //Stops the music played by the PlayMusic method
        void StopMusic(); 
    }
}
