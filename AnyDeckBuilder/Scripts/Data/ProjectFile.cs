
using Newtonsoft.Json;

namespace AnyDeckBuilder.Data
{
    public class ProjectFile
    {
        public static bool isNull => m_current == null;
        public static ProjectFile Current => m_current;
        private static ProjectFile m_current = new ProjectFile();
        #region Save Data
        public List<Deck> decks = new List<Deck>();
        public Dictionary<string, Card> cardsDict = new Dictionary<string, Card>();

        [JsonIgnore]
        public string Name => FilePath == null || FilePath.Length == 0 ? "New Project" : Path.GetFileName(FilePath);
        public string FilePath = string.Empty;

        /// <summary>
        /// The size of all the cards in the deck. If auto card size is true, this value is ignored.
        /// </summary>
        public Size cardSize;
        /// <summary>
        /// X corresponds to the columns and Y to the rows. If auto export size is true, this value is ignored
        /// </summary>
        public Size exportSize;
        #endregion

        #region Preferences
        public bool autoAddCardToCurrentDeck = true;
        /// <summary>
        /// If true, the first card in the deck will be considered the size of all the cards
        /// </summary>
        public bool autoCardSize = true;
        /// <summary>
        /// If true, a default column size of 10 will be used and the rows will be added based on the number of cards
        /// </summary>
        public bool autoExportSize = true;
        #endregion
        public ProjectFile()
        {
            autoAddCardToCurrentDeck = true;
            decks = new();
            cardsDict = new();
        }

        public void AddDeck(Deck deck)
        {
            if (deck == null)
            {
                Console.WriteLine("Cannot add a null deck");
                return;
            }

            if (decks == null)
                decks = new();

            decks.Add(deck);
        }

        public void AddCard(Card card)
        {
            if (cardsDict == null)
                cardsDict = new();
            Console.WriteLine($"Added card {card.name} : {card.guid}");
            cardsDict.Add(card.guid, card);
        }

        public string ToJSON()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        public static void SetCurrent(ProjectFile file)
        {
            m_current = file;
        }

        public bool TryGetCard(string cardGuid, out Card card)
        {
            if (cardsDict.TryGetValue(cardGuid, out card))
                return true;
            return false;
        }
    }
}
