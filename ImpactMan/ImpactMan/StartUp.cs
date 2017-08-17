using System.Windows.Forms;

namespace ImpactMan
{
    using System;
    using Core;
    using ImpactMan.ArtificialIntelligence;
    using ImpactMan.Interfaces.ArtificialIntelligence;
    using ImpactMan.Interfaces.IO.InputListeners;
    using ImpactMan.Interfaces.IO.Reader;
    using ImpactMan.Interfaces.Models.LevelGenerators;
    using ImpactMan.Interfaces.Models.Levels;
    using ImpactMan.Interfaces.Models.Mediators;
    using ImpactMan.IO.InputListeners;
    using ImpactMan.IO.Readers;
    using ImpactMan.Models.LevelGenerators;
    using ImpactMan.Models.Mediators;
    using Interfaces.Core;
    using Microsoft.Xna.Framework.Input;
    using ImpactMan.Context.Db;
    
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
            Start:

            ImpactManContext context = new ImpactManContext();
            AccountManager accountManager = new AccountManager(context);

            IInitializer initializer = new Initializer();
            IInputListener inputListener = new InputListener();

            IFileReader fileReader = new CsvFileReader();
            ILevelGenerator levelGenerator = new LevelGenerator(fileReader);

            ILevel generatedLevel = levelGenerator.GenerateLevel();

            IPlayerConsequenceMediator playerConsequenceMediator = new PlayerConsequenceMediator(generatedLevel);

            IArtificialIntelligence ai = new EnemyArtificialIntelligence(generatedLevel, Keys.Down, Keys.Right, Keys.Up, Keys.Left);

            using (IEngine game = new Engine(initializer,
                                             inputListener,
                                             playerConsequenceMediator,
                                             generatedLevel.Player,
                                             generatedLevel.AllEnemies,
                                             generatedLevel, 
                                             context, 
                                             accountManager, 
                                             levelGenerator,
                                             ai))
            {
                game.Run();
            }
        }
    }
#endif
}
