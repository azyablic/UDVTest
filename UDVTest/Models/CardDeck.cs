using System;
using System.Collections.Generic;

namespace UDVTest
{
    public class CardDeck
    {
        public List<Card> Cards = new();
        public string Name { get; }

        public CardDeck(string name)
        {
            Name = name;
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
            {
                Cards.Add(new Card(suit, rank));
            }
        }
    }
}