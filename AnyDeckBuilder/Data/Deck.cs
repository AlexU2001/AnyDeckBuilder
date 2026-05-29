
namespace AnyDeckBuilder.Data
{
    public class Deck
    {
        public int id;
        public string? name;
        public string? description;
        public List<Card>? cards;

        public Deck(string? name)
        {
            this.name = name;
            cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            if (cards == null)
                cards = new List<Card>();
            cards.Add(card);
        }
    }
}
