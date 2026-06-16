
using System.Data;

namespace AnyDeckBuilder.Data
{
    public class Card : IEquatable<Card>
    {
        /// <summary>
        /// Unique ID generated when a card is created
        /// </summary>
        public string guid { get; private set; }
        public string? name;
        public string? description;
        public string? imagePath;

        public string? templateName;
        public CardProperty[]? properties;

        public Card()
        {
            guid = Guid.NewGuid().ToString();
            name = $"Unnamed Card {ProjectFile.Current.cardsDict.Count}";
        }

        public Card(Card other)
        {
            this.guid = other.guid;
            this.name = other.name;
            this.description = other.description;
            this.imagePath = other.imagePath;
            this.templateName = other.templateName;
            this.properties = other.properties;
        }
        public bool Equals(Card? other)
        {
            if (other == null)
                return false;

            return guid == other.guid;
        }

        public string ToJSON()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        public override string ToString()
        {
            return $"{guid},{name},{description},{imagePath}";
        }

        public class Table
        {
            public const int COLUMNS_LENGTH = 5;

            private static DataTable? defaultTable;
            public static DataTable GetEmpty()
            {
                if (defaultTable == null)
                {
                    defaultTable = new DataTable();
                    defaultTable.Columns.Add("GUID");
                    defaultTable.Columns.Add("Name");
                    defaultTable.Columns.Add("Description");
                    defaultTable.Columns.Add("Image Path");
                    defaultTable.Columns.Add("Template Name");
                }
                return defaultTable;
            }
            public static DataTable GetTableTemplate(string templateName)
            {
                DataTable table = new DataTable();
                table.Columns.Add("GUID");
                table.Columns.Add("Name");
                table.Columns.Add("Description");
                table.Columns.Add("Image Path");
                table.Columns.Add("Template Name");
                if (Utility.TryGetCardTemplate(templateName, out var cardTemplate))
                {
                    if (cardTemplate.properties == null)
                        return table;

                    foreach (var prop in cardTemplate.properties)
                    {
                        table.Columns.Add(prop.Name);
                    }
                }
                return table;
            }

            private static DataColumn CreateColumn(string name)
            {
                DataColumn column = new DataColumn();
                column.ColumnName = name;
                column.DataType = typeof(string);
                return column;
            }
        }
    }
}
