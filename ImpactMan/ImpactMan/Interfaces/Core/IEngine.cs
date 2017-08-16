namespace ImpactMan.Interfaces.Core
{
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

        void ChangeErrorMessage(string message);

        void ClearCurrentUserDetails();

        void Quit();
    }
}
