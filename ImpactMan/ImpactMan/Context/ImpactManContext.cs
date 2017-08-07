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
        public static readonly Assembly ExecutingAssembly;
        /// <summary>
        /// All types in assembly filtered.
        /// </summary>
        public static readonly IEnumerable<Type> AllTypesInAssembly;
        /// <summary>
        /// Query which on execution will get all the map objects in the current assembly.
        /// </summary>
        public static readonly IEnumerable<Type> MapObjectTypesInAssemblyQuery;
        /// <summary>
        /// Executet map objects query. Holds result of the query execution.
        /// </summary>
        public static readonly IEnumerable<Type> FilteredMapObjectTypesInAssembly;

        static ImpactManContext()
        {
            ExecutingAssembly = Assembly.GetExecutingAssembly();
            AllTypesInAssembly = ExecutingAssembly.GetTypes();
            MapObjectTypesInAssemblyQuery = AllTypesInAssembly
                                                .Where(t => t.GetCustomAttributes().Any(a => a is MapObjectAttribute));
            FilteredMapObjectTypesInAssembly = MapObjectTypesInAssemblyQuery.ToArray();
        }
    }
}
