namespace ImpactMan.Constants.Graphics
{
    using System.Windows.Forms;

    /// <summary>
    /// Provides constants for the graphics.
    /// </summary>
    public static class GraphicsConstants
    {
        /// <summary>
        /// Initial mouse state.
        /// </summary>
        public const bool IsMouseVisible = true;

        public const string WindowTitle =
            "ImpactMan: A new begining                                                                                                                              " +
            "Press Home for GameMenu";

        /// <summary>
        /// Initial console/window width
        /// </summary>
        public static readonly int PreferredBufferWidth = Screen.PrimaryScreen.Bounds.Width;

        /// <summary>
        /// Initial console/window width
        /// </summary>
        public static readonly int PreferredBufferHeight = Screen.PrimaryScreen.Bounds.Height;
    }
}
