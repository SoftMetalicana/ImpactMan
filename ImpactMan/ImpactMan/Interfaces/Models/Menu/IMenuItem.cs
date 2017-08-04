using ImpactMan.Interfaces.Globals;

namespace ImpactMan.Interfaces.Models.Menu
{
    public interface IMenuItem : IGameControlUnit
    {
        IMenuCommand MenuCommand { get; }
    }
}
