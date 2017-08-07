namespace ImpactMan.Interfaces.Models.LevelGenerators
{
    using System.Collections.Generic;
    using ImpactMan.Interfaces.Globals;
    
    /// <summary>
    /// Takes care of generating a level from a source and returning it.
    /// </summary>
    public interface ILevelGenerator
    {
        IList<IConsequential[]> GenerateLevel();
    }
}
