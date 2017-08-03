namespace ImpactMan
{
    using System;
    using Core;
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
            using (IEngine game = new Engine())
            {
                game.Run();
            }
        }
    }
#endif
}
