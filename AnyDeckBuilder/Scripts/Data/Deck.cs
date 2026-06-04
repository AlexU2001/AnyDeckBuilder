
using Newtonsoft.Json;

namespace AnyDeckBuilder.Data
{
    public class Deck
    {
        public string? name;
        public string? description;
        public List<string>? cards;

        [JsonIgnore]
        public string exportName => exportPath == null || exportPath.Length == 0 ? "New Project" : Path.GetFileName(exportPath);
        /// <summary>
        /// The path this deck was last exported to
        /// </summary>
        public string? exportPath;
        public string? backImagePath;
        public string? defaultTemplate;

        public Deck(string? name)
        {
            this.name = name;
            cards = new List<string>();
        }

        public void AddCard(string cardGuid)
        {
            if (cards == null)
                cards = new List<string>();

            cards.Add(cardGuid);
        }
    }
}
