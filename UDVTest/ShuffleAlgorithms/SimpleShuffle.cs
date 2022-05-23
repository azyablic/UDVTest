using System;

namespace UDVTest.SortingAlgorithms
{
    public class SimpleShuffle : IShuffle
    {
        public const string Name = "Simple";
        public void Shuffle(CardDeck deck)
        {
            var random = new Random();
            for (int n = deck.Cards.Count - 1; n > 0; --n)
            {
                int k = random.Next(n+1);
                (deck.Cards[n], deck.Cards[k]) = (deck.Cards[k], deck.Cards[n]);
            }
        }
    }
}