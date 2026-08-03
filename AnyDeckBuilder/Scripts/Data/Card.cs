
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace AnyDeckBuilder.Data
{
    public class Card : IEquatable<Card>
    {
        /// <summary>
        /// Unique ID generated when a card is created
        /// </summary>
        public string guid { get; protected set; }
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
            string toString = $"{guid} - {name}\n{description}\n{imagePath}\nProperties {properties.Length}";
            foreach (var prop in properties)
            {
                if (prop == null)
                    continue;

                toString += $"\n{prop.Name}:{prop.Value}";
            }
            return toString;
        }

        public class Builder : Builder<Card>
        {
            [SetsRequiredMembers]
            public Builder()
            {
                instance = new Card();
            }
            public Builder SetGUID(string? GUID)
            {
                if (string.IsNullOrEmpty(GUID))
                    return this;
                instance.guid = GUID;
                return this;
            }

            public Builder SetName(string? Name)
            {
                instance.name = Name;
                return this;
            }

            public Builder SetDescription(string? Description)
            {
                instance.description = Description;
                return this;
            }

            public Builder SetImagePath(string? ImagePath)
            {
                instance.imagePath = ImagePath;
                return this;
            }

            public Builder SetTemplate(string? templateName)
            {
                instance.templateName = templateName;
                return this;
            }

            public Builder SetProperty(int index, string propertyValue)
            {
                if (instance == null)
                    return this;

                if (instance.properties == null || instance.properties.Length <= index)
                {
                    if (Utility.TryGetCardTemplate(instance.templateName, out var template))
                    {
                        if (instance.properties == null || instance.properties.Length == 0)
                            instance.properties = template.properties;
                    }
                    else
                    {
                        CardProperty[] originalProperties = instance.properties;
                        instance.properties = new CardProperty[index + 1];
                        if (originalProperties == null || originalProperties.Length == 0)
                        {
                            for (int i = 0; i < instance.properties.Length; i++)
                                instance.properties[i].Name = $"Property {i + 1}";
                        }
                        else
                        {
                            for (int i = 0; i < originalProperties.Length; i++)
                                instance.properties[i] = originalProperties[i];
                        }
                    }
                }
                instance.properties[index].SetValue(propertyValue);
                return this;
            }

            public override Card Build()
            {
                Console.WriteLine($"Built Card {instance.name}\n{instance.ToString()}");
                return base.Build();
            }
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
                    defaultTable.Columns.Add("NAME");
                    defaultTable.Columns.Add("DESCRIPTION");
                    defaultTable.Columns.Add("IMAGE PATH");
                    defaultTable.Columns.Add("TEMPLATE NAME");
                }
                return defaultTable.Clone();
            }
            public static DataTable GetTableTemplate(string templateName)
            {
                DataTable table = GetEmpty();
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
        }
    }
}
