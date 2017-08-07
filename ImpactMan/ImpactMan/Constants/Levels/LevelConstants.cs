namespace ImpactMan.Constants.Levels
{
    /// <summary>
    /// Provides constants for the classes which are dealing with the loading and holding the level.
    /// </summary>
    public static class LevelConstants
    {
        /// <summary>
        /// The name of the starting map.
        /// </summary>
        public const string StartLevel = "level.csv";

        /// <summary>
        /// Holds the separator of the different keys in the .csv level file.
        /// </summary>
        public static readonly char[] SeparatorSymbolsInFile = new char[] { ',' };
    }
}
