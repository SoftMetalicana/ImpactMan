using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using ImpactMan.Constants.Units;
using ImpactMan.Context;
using ImpactMan.Context.Models;
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

        public void WriteUserDetails(User user, string errorMessage, GameState gameState)
        {
            int userNameX = GetEnumValue(nameof(userNameX), gameState);
            int userNameY = GetEnumValue(nameof(userNameY), gameState);

            int passwordX = GetEnumValue(nameof(passwordX), gameState);
            int passwordY = GetEnumValue(nameof(passwordY), gameState);

            int errorMessageX = GetEnumValue(nameof(errorMessageX), gameState);
            int errorMessageY = GetEnumValue(nameof(errorMessageY), gameState);

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

        private int GetEnumValue(string query, GameState gameState)
        {
            Type classType = ImpactManContext.AllTypesInAssembly.Where(x => x.Name.Contains("MenuConstants")).ToArray()[0];
            FieldInfo[] fieldInfos = classType.GetFields(BindingFlags.Static | BindingFlags.Public);

            return (int)fieldInfos.Where(f => f.Name.ToLower().Contains(query.ToLower()) && f.Name.ToLower().Contains(gameState.ToString().ToLower()))
                .ToList()[0].GetValue(null);
        }
    }
}
