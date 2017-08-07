namespace ImpactMan.Context
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using ImpactMan.Attributes;

    /// <summary>
    /// Holds general info for the current program.
    /// </summary>
    public static class ImpactManContext
    {
        /// <summary>
        /// Current executing assembly.
        /// </summary>
        private static Assembly executingAssembly;
        /// <summary>
        /// All types in assembly.
        /// </summary>
        private static IEnumerable<Type> allTypesInAssembly;
        /// <summary>
        /// Holds types by CSV key name.
        /// The CSV key name is the one that is in the levels files.
        /// </summary>
        private static Dictionary<string, Type> typesByCsvKeyName;

        /// <summary>
        /// Initializes the static readonly fields.
        /// </summary>
        static ImpactManContext()
        {
            ExecutingAssembly = Assembly.GetExecutingAssembly();
            AllTypesInAssembly = executingAssembly.GetTypes();

            typesByCsvKeyName = new Dictionary<string, Type>();
            foreach (Type type in allTypesInAssembly)
            {
                IEnumerable<Attribute> customAttributes = type.GetCustomAttributes();
                foreach (Attribute attribute in customAttributes)
                {
                    if (attribute is MapObjectAttribute)
                    {
                        string csvKeyName = (attribute as MapObjectAttribute).CsvKeyName;

                        typesByCsvKeyName[csvKeyName] = type;

                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Current executing assembly.
        /// </summary>
        public static Assembly ExecutingAssembly
        {
            get
            {
                return executingAssembly;
            }

            private set
            {
                executingAssembly = value;
            }
        }

        /// <summary>
        /// All types in assembly.
        /// </summary>
        public static IEnumerable<Type> AllTypesInAssembly
        {
            get
            {
                return allTypesInAssembly;
            }

            private set
            {
                allTypesInAssembly = value;
            }
        }

        /// <summary>
        /// Holds types by CSV key name.
        /// The CSV key name is the one that is in the levels files.
        /// </summary>
        public static IReadOnlyDictionary<string, Type> TypesByCsvKeyName
        {
            get
            {
                return typesByCsvKeyName;
            }
        }
    }
}
