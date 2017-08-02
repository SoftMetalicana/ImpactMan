namespace ImpactMan
{
    using System;
    using Core;
    using ImpactMan.Interfaces.Core;

#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
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
