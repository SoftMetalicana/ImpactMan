namespace ImpactMan.Interfaces.Models.Menu
{
    using System.Collections.Generic;
    using Globals;

    public interface IMenuHolder : IGameControlUnit
    {
        IList<IMenuItem> MenuItems { get; }
    }
}
