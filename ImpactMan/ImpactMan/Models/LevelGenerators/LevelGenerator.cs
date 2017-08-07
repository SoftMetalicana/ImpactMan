namespace ImpactMan.Models.LevelGenerators
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;
    using ImpactMan.Constants.Levels;
    using ImpactMan.Context;
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

        private void CacheActivationLambda(string currentCsvKeyName)
        {
            Type typeToActivate = ImpactManContext.TypesByCsvKeyName[currentCsvKeyName];

            ParameterExpression xParameter = Expression.Parameter(typeof(int), "x");
            ParameterExpression yParameter = Expression.Parameter(typeof(int), "y");

            ConstructorInfo ctorOfType = typeToActivate.GetConstructor(new[] { typeof(int), typeof(int) });

            NewExpression newTypeExpression = Expression.New(ctorOfType, xParameter, yParameter);

            Func<int, int, IConsequential> activatorLambda =
                        Expression.Lambda<Func<int, int, IConsequential>>(newTypeExpression,
                                                                          xParameter,
                                                                          yParameter)
                                                                          .Compile();

            this.activationCache[currentCsvKeyName] = activatorLambda;
        }

        public IList<IConsequential[]> GenerateLevel()
        {
            IList<IConsequential[]> generatedLevel = new List<IConsequential[]>();

            using (this.fileReader)
            {
                int currentRow = 0;

                string readLine;
                while (!string.IsNullOrEmpty(readLine = this.fileReader.ReadLine()))
                {
                    string[] csvKeyNames = readLine.Split(LevelConstants.SeparatorSymbolsInFile);

                    generatedLevel.Add(new IConsequential[csvKeyNames.Length]);
                    for (int currentCol = 0; currentCol < csvKeyNames.Length; currentCol++)
                    {
                        string currentCsvKeyName = csvKeyNames[currentCol];
                        
                        if (!this.activationCache.ContainsKey(currentCsvKeyName))
                        {
                            this.CacheActivationLambda(currentCsvKeyName);
                        }

                        generatedLevel[currentRow][currentCol] = this.activationCache[currentCsvKeyName](0, 0);
                    }

                    currentRow++;
                }
            }

            return generatedLevel;
        }
    }
}
