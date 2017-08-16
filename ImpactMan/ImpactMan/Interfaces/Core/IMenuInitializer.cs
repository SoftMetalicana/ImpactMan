namespace ImpactMan.Interfaces.Core
{
    using ImpactMan.Context.Models;
    using ImpactMan.Interfaces.IO.InputListeners;
    using ImpactMan.IO.InputListeners.Events;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// This interface must be inheritated by the MenuIntializer
    /// </summary>
    interface IMenuInitializer
    {
        void Initialize(string query);
        void OnMouseClicked(IInputListener sender, MouseClickedEventArgs eventArgs);
        void Load(ContentManager content);
        void Update(GameTime gameTime, MouseState mouseState, User user);
        void Draw(SpriteBatch spriteBatch);
        int GetEnumValue(string query, string valueType);
    }
}
