using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using ImpactMan.Constants.Units;
using ImpactMan.Context;
using ImpactMan.Context.Models;
using ImpactMan.Core;
using ImpactMan.Enumerations.Game;

namespace ImpactMan.IO.Writers
{
    using Interfaces.Writer;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class ConsoleTextWriter : ITextWriter
    {
        private SpriteFont spriteFont;
        private SpriteBatch spriteBatch;

        public ConsoleTextWriter(SpriteFont spriteFont, SpriteBatch spriteBatch)
        {
            this.spriteFont = spriteFont;
            this.spriteBatch = spriteBatch;
        }

        public void Write(string text, Vector2 vector, Color color)
        {
            this.spriteBatch.DrawString(this.spriteFont, text, vector, color);
        }

        public void WriteUserDetails(User user, string errorMessage)
        {
            int userNameX = GetEnumValue(nameof(userNameX));
            int userNameY = GetEnumValue(nameof(userNameY));

            int passwordX = GetEnumValue(nameof(passwordX));
            int passwordY = GetEnumValue(nameof(passwordY));

            int errorMessageX = GetEnumValue(nameof(errorMessageX));
            int errorMessageY = GetEnumValue(nameof(errorMessageY));

            this.Write(user.Name,
                new Vector2(userNameX,
                    userNameY),
                Color.Black);

            this.Write(user.Password,
                new Vector2(passwordX,
                    passwordY),
                Color.Black);

            this.Write(errorMessage,
                new Vector2(errorMessageX,
                    errorMessageY),
                Color.Black);
        }

        private int GetEnumValue(string query)
        {
            Type classType = ImpactManContext.AllTypesInAssembly.Where(x => x.Name.Contains("MenuConstants")).ToArray()[0];
            FieldInfo[] fieldInfos = classType.GetFields(BindingFlags.Static | BindingFlags.Public);

            return (int)fieldInfos.Where(f => f.Name.ToLower().Contains(query.ToLower()) && f.Name.ToLower().Contains(State.GameState.ToString().ToLower()))
                .ToList()[0].GetValue(null);
        }
    }
}
