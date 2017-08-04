namespace ImpactMan.Interfaces.Models.Menu
{
    using Globals;

    public interface IMenuItem : IGameControlUnit
    {
        IMenuCommand MenuCommand { get; }
    }
}
