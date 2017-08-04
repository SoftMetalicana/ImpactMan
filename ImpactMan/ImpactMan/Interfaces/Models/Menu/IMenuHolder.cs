namespace ImpactMan.Interfaces.Models.Menu
{
    using Globals;
    using System.Collections.Generic;

    public interface IMenuHolder : IGameControlUnit
    {
        IList<IMenuItem> MenuItems { get; }
    }
}
