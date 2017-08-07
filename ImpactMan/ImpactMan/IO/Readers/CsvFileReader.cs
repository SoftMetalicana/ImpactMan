namespace ImpactMan.IO.Readers
{
    using System.IO;
    using ImpactMan.Constants.Levels;
    using ImpactMan.Interfaces.IO.Reader;

    /// <summary>
    /// Reads from a .csv file.
    /// </summary>
    public class CsvFileReader : IFileReader
    {
        /// <summary>
        /// The name of the file to read from.
        /// </summary>
        private string fileName;
        /// <summary>
        /// The stream for reading from the file.
        /// </summary>
        private StreamReader reader;

        /// <summary>
        /// Initializes the object.
        /// </summary>
        public CsvFileReader()
            : this(LevelConstants.StartLevel)
        {
        }

        /// <summary>
        /// Initializes the object.
        /// </summary>
        /// <param name="fileName">The name of the file that you wnt to read from.</param>
        public CsvFileReader(string fileName)
        {
            this.FileName = fileName;
            this.Reader = new StreamReader(this.FileName);
        }

        /// <summary>
        /// The name of the file to read from.
        /// </summary>
        private string FileName
        {
            get
            {
                return this.fileName;
            }

            set
            {
                this.fileName = value;
            }
        }

        /// <summary>
        /// The stream for reading from the file.
        /// </summary>
        private StreamReader Reader
        {
            get
            {
                return this.reader;
            }

            set
            {
                this.reader = value;
            }
        }

        /// <summary>
        /// Reads a single line from a source.
        /// </summary>
        /// <returns>The single line read.</returns>
        public string ReadLine()
        {
            return this.Reader.ReadLine();
        }
        
        /// <summary>
        /// Closes the stream to the file after work is done.
        /// </summary>
        public void Dispose()
        {
            this.Reader.Close();
        }
    }
}
