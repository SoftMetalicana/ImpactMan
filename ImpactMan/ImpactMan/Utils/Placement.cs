namespace ImpactMan.Utils
{
    /// <summary>
    /// Provides methods for calculating the objects placement on the console.
    /// </summary>
    public static class Placement
    {
        /// <summary>
        /// Generates a rectangle placement class with X,Y coordinates.
        /// Calculates where the new rectangle should be placed from the current row 
        /// and the current col of reading the file.
        /// </summary>
        /// <param name="currentRowOfFile">Current row from reading the file.</param>
        /// <param name="currentColofFile">Current col from reading the file.</param>
        /// <param name="width">Usual width of objects.</param>
        /// <param name="height">Usual height of objects.</param>
        /// <returns></returns>
        public static RectanglePlacement GetRectanglePlacement(int currentRowOfFile, int currentColofFile, int width, int height)
        {
            int newX = currentRowOfFile * height;
            int newY = currentColofFile * width;

            return new RectanglePlacement(newX, newY);
        }
    }
}
