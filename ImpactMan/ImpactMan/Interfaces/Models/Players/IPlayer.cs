namespace ImpactMan.Interfaces.Models.Players
{
    using Globals;
    using IO.InputListeners;
    using ImpactMan.IO.InputListeners.Events;

    /// <summary>
    /// If you want a new player in the game you must inherit from this interface.
    /// Holds vital info for a player.
    /// </summary>
    public interface IPlayer : IGameplayUnit
    {
        /// <summary>
        /// The current points of the player.
        /// This points are going the be used as a record in the database.
        /// </summary>
        int Points { get; }

        /// <summary>
        /// A handler of the key pressed event. Obviously the player is interested in this event.
        /// In this method usually the player understants which key is pressed and sends an event
        /// to a special Mediator which takes care of further logic.
        /// </summary>
        /// <param name="sender">The input listener itself.</param>
        /// <param name="eventArgs">Basic info for the current state of the keyboard or pressed key.</param>
        void OnKeyPressed(IInputListener sender, KeyPressedEventArgs eventArgs);
    }
}
