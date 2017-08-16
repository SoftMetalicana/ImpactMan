namespace ImpactMan.IO.Writers
{
    using ImpactMan.Context;
    using ImpactMan.Context.Models;
    using ImpactMan.Core;
    using Interfaces.Writer;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Linq;
    using System.Reflection;

    public class ConsoleTextWriter : ITextWriter
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
            int userNameX = this.GetEnumValue(nameof(userNameX));
            int userNameY = this.GetEnumValue(nameof(userNameY));

            int passwordX = this.GetEnumValue(nameof(passwordX));
            int passwordY = this.GetEnumValue(nameof(passwordY));

            int errorMessageX = this.GetEnumValue(nameof(errorMessageX));
            int errorMessageY = this.GetEnumValue(nameof(errorMessageY));

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
