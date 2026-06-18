
using Newtonsoft.Json;

namespace AnyDeckBuilder.Data
{
    public class Deck
    {
        public string? name;
        public string? description;
        public List<string>? cards;


        public const string DEFAULT_NAME = "Untitled Deck";
        public static Deck Empty
        {
            get
            {
                if (_empty == null)
                    _empty = new Deck(DEFAULT_NAME);
                return _empty;
            }
        }
        private static Deck? _empty;

        [JsonIgnore]
        public string exportName => exportPath == null || exportPath.Length == 0 ? "New Project" : Path.GetFileName(exportPath);
        /// <summary>
        /// The path this deck was last exported to
        /// </summary>
        public string? exportPath;
        public int exportX;
        public int exportY;
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
