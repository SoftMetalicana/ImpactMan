namespace ImpactMan.Models.LevelGenerators
{
    using System;
    using System.Collections.Generic;
    using ImpactMan.Interfaces.Globals;
    using ImpactMan.Interfaces.IO.Reader;
    using ImpactMan.Interfaces.Models.LevelGenerators;

    /// <summary>
    /// Takes care of generating a level from a source and returning it.
    /// </summary>
    public class LevelGenerator : ILevelGenerator
    {
        private IFileReader fileReader;
        private IDictionary<string, Func<int, int, IConsequential>> activationCache;

        public LevelGenerator(IFileReader fileReader)
        {
            this.FileReader = fileReader;
            this.ActivationCache = new Dictionary<string, Func<int, int, IConsequential>>();
        }

        private IFileReader FileReader
        {
            get
            {
                return this.fileReader;
            }

            set
            {
                this.fileReader = value;
            }
        }

        private IDictionary<string, Func<int, int, IConsequential>> ActivationCache
        {
            get
            {
                return this.activationCache;
            }

            set
            {
                this.activationCache = value;
            }
        }

        public IList<IConsequential[]> GenerateLevel()
        {
            IList<IConsequential[]> generatedLevel = new List<IConsequential[]>();

            return generatedLevel;
        }
    }
}
