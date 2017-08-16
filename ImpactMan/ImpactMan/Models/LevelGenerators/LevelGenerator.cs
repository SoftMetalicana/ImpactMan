namespace ImpactMan.Models.LevelGenerators
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;
    using ImpactMan.Constants.Units;
    using ImpactMan.Context;
    using ImpactMan.Interfaces.Globals;
    using ImpactMan.Interfaces.IO.Reader;
    using ImpactMan.Interfaces.Models.LevelGenerators;
    using ImpactMan.Interfaces.Models.Levels;
    using ImpactMan.Models.Levels;
    using ImpactMan.Utils;

    /// <summary>
    /// Takes care of generating a level from a source and returning it.
    /// </summary>
    public class LevelGenerator : ILevelGenerator
    {
        /// <summary>
        /// Constants for the lamda cache.
        /// </summary>
        private const string FirstParamName = "x";
        private const string SecondParamName = "y";
        private const string RowParamName = "row";
        private const string ColParamName = "col";
        private const string LevelParamName = "level";
        private const string AddMethodPrefix = "Add";

        /// <summary>
        /// Constants for the lamda cache.
        /// </summary>
        private static readonly Type LevelType = typeof(ILevel);
        private static readonly Type IntType = typeof(int);
        private static readonly Type ObjectType = typeof(object);
        private static readonly Type[] ConstructorWantedParams = new[] { IntType, IntType };

        /// <summary>
        /// Holds the separator of the different keys in the .csv level file.
        /// </summary>
        private static readonly char[] SeparatorSymbolsInFile = new char[] { ',', '\t', ' ', '"' };

        /// <summary>
        /// Reads from a file source.
        /// </summary>
        private IFileReader fileReader;
        /// <summary>
        /// Holds cache of functions that activate an object on given coordinates(X, Y).
        /// </summary>
        private static IDictionary<string, Action<int, int, ILevel, int, int>> activationCache;

        /// <summary>
        /// Instantiates the object.
        /// </summary>
        /// <param name="fileReader">The file reader that you want to use.</param>
        public LevelGenerator(IFileReader fileReader)
        {
            this.FileReader = fileReader;
            ActivationCache = new Dictionary<string, Action<int, int, ILevel, int, int>>();
        }

        /// <summary>
        /// Reads from a file source.
        /// </summary>
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

        /// <summary>
        /// Holds cache of functions that activate IConsequential objects on given coordinates(X, Y).
        /// </summary>
        private static IDictionary<string, Action<int, int, ILevel, int, int>> ActivationCache
        {
            get
            {
                return activationCache;
            }

            set
            {
                activationCache = value;
            }
        }

        /// <summary>
        /// Generates and saves in cache a lambda that activates an object.
        /// </summary>
        /// <param name="currentCsvKeyName">The key that you want to save against the new generated lambda.</param>
        private void CacheActivationLambda(string currentCsvKeyName)
        {
            Type typeToActivate = ImpactManContext.TypesByCsvKeyName[currentCsvKeyName];

            ParameterExpression xParameter = Expression.Parameter(IntType, FirstParamName);
            ParameterExpression yParameter = Expression.Parameter(IntType, SecondParamName);
            ParameterExpression rowParameter = Expression.Parameter(IntType, RowParamName);
            ParameterExpression colParameter = Expression.Parameter(IntType, ColParamName);
            ParameterExpression levelParameter = Expression.Parameter(LevelType, LevelParamName);

            ConstructorInfo ctorOfType = typeToActivate.GetConstructor(ConstructorWantedParams);

            NewExpression newTypeExpression = Expression.New(ctorOfType, xParameter, yParameter);
            UnaryExpression castedNewTypeExpression = Expression.Convert(newTypeExpression, ObjectType);

            MethodInfo method = LevelType.GetMethod(AddMethodPrefix + currentCsvKeyName, BindingFlags.IgnoreCase |
                                                                                         BindingFlags.Instance |
                                                                                         BindingFlags.Public);

            MethodCallExpression addMethodCallExpression = Expression.Call(levelParameter,
                                                                           method,
                                                                           newTypeExpression,
                                                                           rowParameter,
                                                                           colParameter);

            Action<int, int, ILevel, int, int> activatorLambda =
                        Expression.Lambda<Action<int, int, ILevel, int, int>>(addMethodCallExpression,
                                                                              xParameter,
                                                                              yParameter,
                                                                              levelParameter,
                                                                              rowParameter,
                                                                              colParameter)
                                                                              .Compile();

            ActivationCache[currentCsvKeyName] = activatorLambda;
        }

        /// <summary>
        /// Generates a whole level consisting of IConsequential objects.
        /// </summary>
        /// <returns>The generated level.</returns>
        public ILevel GenerateLevel()
        {
            ILevel level = new Level();

            using (this.fileReader)
            {
                int currentRow = 0;

                string readLine;
                while (!string.IsNullOrEmpty(readLine = this.fileReader.ReadLine()))
                {
                    string[] csvKeyNames = readLine.Split(SeparatorSymbolsInFile, StringSplitOptions.RemoveEmptyEntries);

                    level.AllUnitsOnMap.Add(new IConsequential[csvKeyNames.Length]);
                    for (int currentCol = 0; currentCol < csvKeyNames.Length; currentCol++)
                    {
                        string currentCsvKeyName = csvKeyNames[currentCol];

                        if (!ActivationCache.ContainsKey(currentCsvKeyName))
                        {
                            this.CacheActivationLambda(currentCsvKeyName);
                        }

                        RectanglePlacement calculatedRectanglePlacement =
                                                        Placement.GetRectanglePlacement(currentRow,
                                                                                        currentCol,
                                                                                        UnitConstants.Width,
                                                                                        UnitConstants.Height);

                        ActivationCache[currentCsvKeyName](calculatedRectanglePlacement.X,
                                                           calculatedRectanglePlacement.Y,
                                                           level,
                                                           currentRow,
                                                           currentCol);
                    }

                    currentRow++;
                }
            }

            return level;
        }
    }
}
