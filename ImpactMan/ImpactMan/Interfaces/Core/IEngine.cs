

namespace ImpactMan.Interfaces.Core
{
    using Enumerations.Game;
    using System;

    /// <summary>
    /// The engine of the game must inherit from this interface.
    /// Engine inherits from IDisposable so take care of disposing the engine after using it.
    /// </summary>
    public interface IEngine : IDisposable
    {
        /// <summary>
        /// This method runs everything in the game.
        /// </summary>
        void Run();

        void ChangeGameState(GameState gameState);

        void ChangeUserInputState();

        void ChangeErrorMessage(string message);

        void ClearCurrentUserDetails();

        void Quit();
    }
}
