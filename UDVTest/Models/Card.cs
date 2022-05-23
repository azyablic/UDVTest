namespace UDVTest
{
    public class Card
    {
        public CardSuit Suit { get; }
        public CardRank Rank { get; }

        public Card(CardSuit suit, CardRank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public override string ToString()
        {
            return $"{Rank.ToString()} of {Suit.ToString()}";
        }
    }
}