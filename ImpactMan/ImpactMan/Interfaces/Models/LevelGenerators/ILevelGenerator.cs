namespace ImpactMan.Interfaces.Models.LevelGenerators
{
    using ImpactMan.Interfaces.Models.Levels;

    /// <summary>
    /// Takes care of generating a level from a source and returning it.
    /// </summary>
    public interface ILevelGenerator
    {
        ILevel GenerateLevel();
    }
}
