using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace ImpactMan.Utils
{
    public static class KeyValueCheck
    {
        public static bool IsKeyLetter(Keys key)
        {
            return key >= Keys.A && key <= Keys.Z;
        }

        public static bool IsKeyDigit(Keys key)
        {
            return key >= Keys.D0 && key <= Keys.D9 || key >= Keys.NumPad0 && key <= Keys.NumPad9;
        }
    }
}
