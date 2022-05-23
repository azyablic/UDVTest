using System;
using System.Collections.Generic;
using System.Linq;

namespace UDVTest.SortingAlgorithms
{
    public class HandShuffle:IShuffle
    {
        public const string Name = "Hand";
        public void Shuffle(CardDeck deck)
        {
            var cardsCount = deck.Cards.Count;
            for(var j = 0; j < 100; j++)
            {
                var rndCount = new Random().Next(2, cardsCount / 2);
                var deckPart = deck.Cards.GetRange(0, rndCount);
                deck.Cards.RemoveRange(0, rndCount);
                (deckPart, deck.Cards) = (Swap(deck.Cards), Swap(deckPart));
                deck.Cards.AddRange(deckPart);
            }
        }

        private List<Card> Swap(List<Card> cards)
        {
            var count = cards.Count();
            var i = new Random().Next(1, count / 2);
            var deckPart = cards.GetRange(0, i);
            cards.RemoveRange(0, i);
            cards.AddRange(deckPart);
            return cards;
        }
    }
}