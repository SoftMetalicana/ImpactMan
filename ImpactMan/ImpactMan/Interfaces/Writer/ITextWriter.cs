namespace ImpactMan.Interfaces.Writer
{
    using ImpactMan.Context.Models;
    using Microsoft.Xna.Framework;

    public interface ITextWriter
    {
        void Write(string text, Vector2 vector, Color color);

        void WriteUserDetails(User user, string errorMessage);
    }
}
