using AnyDeckBuilder.Data;

namespace AnyDeckBuilder
{
    public class CardChangeArgs : EventArgs
    {
        public Card? PreEditCard;
        public Card Card;

        public CardChangeArgs(Card preEditCard, Card card)
        {
            PreEditCard = preEditCard;
            Card = card;
        }
    }
}
