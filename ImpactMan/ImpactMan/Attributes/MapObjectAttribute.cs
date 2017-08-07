namespace ImpactMan.Attributes
{
    using System;

    public class MapObjectAttribute : Attribute
    {
        private string csvKeyName;

        public MapObjectAttribute(string csvKeyName)
        {
            this.CsvKeyName = csvKeyName;
        }

        public string CsvKeyName
        {
            get
            {
                return this.csvKeyName;
            }

            private set
            {
                this.csvKeyName = value;
            }
        }
    }
}
