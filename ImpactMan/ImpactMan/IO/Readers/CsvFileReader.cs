namespace ImpactMan.IO.Readers
{
    using System.IO;
    using ImpactMan.Interfaces.Reader;

    public class CsvFileReader : IFileReader
    {
        private string fileName;
        private StreamReader reader;

        public CsvFileReader(string fileName)
        {
            this.FileName = fileName;
            this.Reader = new StreamReader(this.FileName);
        }

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

        public string ReadLine()
        {
            return this.Reader.ReadLine();
        }
        
        public void Dispose()
        {
            this.Reader.Close();
        }
    }
}
