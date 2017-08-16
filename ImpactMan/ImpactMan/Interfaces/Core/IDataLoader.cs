namespace ImpactMan.Interfaces.Core
{
    using System.Collections.Generic;

    /// <summary>
    /// This interface must be inheritated by the DataLoade
    /// </summary>
    interface IDataLoader
    {
        //This method returns the users(UserName and HighScore) with best highscores from the databse
        Dictionary<string,int> LoadHighScores();

        //This method returns the log data(UserName and Password) about all users
        Dictionary<string, int> LoadLogInfo(); 
    }
}
