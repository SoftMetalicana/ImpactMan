namespace ImpactMan.Constants.Units
{
    /// <summary>
    /// Provides constants for the units in the game.
    /// Every object on the map in the game inherits from unit.
    /// </summary>
    public static class UnitConstants
    {
        /// <summary>
        /// The width of all units.
        /// </summary>
        public const int Width = 50;
        /// <summary>
        /// The height of all units.
        /// </summary>
        public const int Height = 50;

        /// <summary>
        /// Asset names for the objects that are printed on the console/map/window.
        /// If an object is printed it should ask for an asset name in one of the constructor overloads.
        /// Usually you will find those names injected in the constructors so you don't have to pass as argument an asset name.
        /// Asset names correspond to a picture that is loaded in the Content.Content.mgcb.
        /// </summary>
        public const string EnemyAssetName = "enemy";
        public const string GroundAssetName = "ground";
        public const string WallAssetName = "wall";
        public const string PlayerAssetName = "player";
        public const string FoodAssetName = "food";

        /// <summary>
        /// All of the objects that you see in the console are loaded from a .csv file.
        /// In this file the objects have a key name which is 4 letters long and correspond to an object in the game.
        /// These names are passed to the .Attributes.MapObjectAttribute constructor.
        /// The MapObjects are than activated with reflection and stored into a Level.cs
        /// </summary>
        public const string EnemyCsvKeyName = "enemy";
        public const string GroundCsvKeyName = "ground";
        public const string WallCsvKeyName = "wall";
        public const string PlayerCsvKeyName = "player";
        public const string FoodCsvKeyName = "food";
    }   
}
