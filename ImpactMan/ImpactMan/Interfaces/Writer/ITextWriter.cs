using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpactMan.Context.Models;
using ImpactMan.Enumerations.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ImpactMan.Interfaces.Writer
{
    public interface ITextWriter
    {
        void Write(string text, Vector2 vector, Color color);

        void WriteUserDetails(User user, string errorMessage, GameState gameState);
    }
}
