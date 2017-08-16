﻿namespace ImpactMan.Utils
{
    using Microsoft.Xna.Framework.Input;

    public static class KeyValueCheck
    {
        public static bool IsKeyLetter(Keys key)
        {
            return key >= Keys.A && key <= Keys.Z;
        }

        public static bool IsKeyDigit(Keys key)
        {
            return (key >= Keys.D0 && key <= Keys.D9) || (key >= Keys.NumPad0 && key <= Keys.NumPad9);
        }
    }
}
