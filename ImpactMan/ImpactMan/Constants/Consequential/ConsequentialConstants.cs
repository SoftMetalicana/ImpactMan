namespace ImpactMan.Constants.Consequential
{
    /// <summary>
    /// Provides constants for the units that have consequence.
    /// Usually the whole map consists of such.
    /// </summary>
    public static class ConsequentialConstants
    {
        /// <summary>
        /// The bonus points given from the consequential objects.
        /// </summary>
        public const int EnemyBonusPoints = 100;
        public const int FoodBonusPoints = 10;
        public const int GroundBonusPoints = 0;
        public const int WallBonusPoints = 0;

        /// <summary>
        /// The distance from center for every object that the player can interact with
        /// to activate and get consequences from.
        /// </summary>
        public const double EnemyDistanceFromCenterToActivate = 50;
        public const double WallDistanceFromCenterToActivate = 50;
        public const double FoodDistanceFromCenterToActivate = 25;
        public const double GroundDistanceFromCenterToActivate = 25;
    }
}
