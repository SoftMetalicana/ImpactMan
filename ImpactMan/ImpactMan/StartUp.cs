namespace ImpactMan
{
    using System;
    using System.Collections.Generic;
    using Core;
    using ImpactMan.Interfaces.Globals;
    using ImpactMan.Interfaces.IO.InputListeners;
    using ImpactMan.Interfaces.IO.Reader;
    using ImpactMan.Interfaces.Models.LevelGenerators;
    using ImpactMan.Interfaces.Models.Levels;
    using ImpactMan.Interfaces.Models.Mediators;
    using ImpactMan.IO.InputListeners;
    using ImpactMan.IO.Readers;
    using ImpactMan.Models.LevelGenerators;
    using ImpactMan.Models.Levels;
    using ImpactMan.Models.Mediators;
    using Interfaces.Core;

#if WINDOWS || LINUX
    /// <summary>
    /// The class which the games start from.
    /// Holds the Main method which is the start point of the program.
    /// </summary>
    public static class StartUp
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            IInitializer initializer = new Initializer();
            IInputListener inputListener = new InputListener();

            IFileReader fileReader = new CsvFileReader();
            ILevelGenerator levelGenerator = new LevelGenerator(fileReader);

            ILevel generatedLevel = levelGenerator.GenerateLevel();

            IPlayerConsequenceMediator playerConsequenceMediator = new PlayerConsequenceMediator(generatedLevel);

            using (IEngine game = new Engine(initializer,
                                             inputListener,
                                             playerConsequenceMediator))
            {
                game.Run();
            }
        }
    }
#endif
}
