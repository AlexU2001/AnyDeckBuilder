namespace AnyDeckBuilder.Data
{
    public class ProjectFile
    {
        public static ProjectFile Current => m_current;
        private static ProjectFile m_current = new ProjectFile();
        public List<Deck> decks = new List<Deck>();
        public List<Card> cards = new List<Card>();

        #region Preferences
        public bool autoAddCardToCurrentDeck;
        #endregion
        public ProjectFile()
        {
            autoAddCardToCurrentDeck = true;
            decks = new List<Deck>();
            cards = new List<Card>();
        }

        public void AddDeck(Deck deck)
        {
            decks.Add(deck);
        }

        public void AddCard(Card card)
        {
            Console.WriteLine("Added card");
            cards.Add(card);
        }

        public string ToJSON()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        public static void SetCurrent(ProjectFile file)
        {
            m_current = file;
        }
    }
}
