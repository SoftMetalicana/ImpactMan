namespace ImpactMan.Interfaces.Core
{
    using ImpactMan.Context.Models;

    /// <summary>
    /// This interface must be inheritated by the AccountManager
    /// </summary>
    public interface IAccountManager
    {
        /// This method is responsible for loging in the gameplay
        bool Login(User context);

        // This method register the user in the database
        bool Register(User user, out string message); 
    }
}
