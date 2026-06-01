
namespace AnyDeckBuilder.Data
{
    public class Card : IEquatable<Card>
    {
        public string? id;
        public string? name;
        public string? description;
        public string? imagePath;
        public bool isPathUrl;
        public CardProperty[]? properties;
        public Size size;

        public bool Equals(Card? other)
        {
            if (other == null)
                return false;

            return id == other.id;
        }

        public string ToJSON()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        public override string ToString()
        {
            return $"{id},{name},{description},{imagePath},{isPathUrl}";
        }
    }

    public struct CardProperty
    {
        public string propertyName;
        public string value;
    }
}
