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

        public static readonly string WindowTitle = $"ImpactMan: A new beginning                   Points:{0}";

        /// <summary>
        /// Initial console/window width
        /// </summary>
        public static readonly int PreferredBufferWidth = Screen.PrimaryScreen.Bounds.Width;
        
        /// <summary>
        /// Initial console/window width
        /// </summary>
        public static readonly int PreferredBufferHeight = Screen.PrimaryScreen.Bounds.Height - 70;
    }
}
