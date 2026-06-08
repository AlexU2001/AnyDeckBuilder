
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
        public bool isPathUrl;

        public string? templateName;
        public CardProperty[]? properties;

        public Card()
        {
            guid = Guid.NewGuid().ToString();
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
            return $"{guid},{name},{description},{imagePath},{isPathUrl}";
        }
    }
}
