using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpactMan.Core.Factories;
using ImpactMan.Interfaces.Globals;

namespace ImpactMan.Interfaces.Models.Menu
{
    public interface IMenuHolder : IGameControlUnit
    {
        IList<IMenuItem> MenuItems { get; }
    }
}
