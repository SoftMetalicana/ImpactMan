namespace ImpactMan.Utils
{
    /// <summary>
    /// Provides coordinates for the rectangle of a new object.
    /// </summary>
    public class RectanglePlacement
    {
        /// <summary>
        /// The X coordinate in the console.
        /// </summary>
        private int x;
        /// <summary>
        /// The Y coordinate in the console.
        /// </summary>
        private int y;

        /// <summary>
        /// Instantiates the object.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public RectanglePlacement(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// The X coordinate in the console.
        /// </summary>
        public int X
        {
            get
            {
                return this.x;
            }

            private set
            {
                this.x = value;
            }
        }

        /// <summary>
        /// The Y coordinate in the console.
        /// </summary>
        public int Y
        {
            get
            {
                return this.y;
            }

            private set
            {
                this.y = value;
            }
        }
    }
}
