﻿namespace ImpactMan.Constants.Consequential
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
        /// Flags that tell the player if he can move or not
        /// </summary>
        public const bool EnemyPlayerCanMove = false;
        public const bool WallPlayerVanMove = false;
        public const bool FoodPlayerCanMove = true;
        public const bool GroundPlayerCanMove = true;
    }
}
