using System;
using System.Collections.Generic;
using System.Linq;

namespace UDVTest.Dtos
{
    public class DeckDto
    {
        public string Name { get; }
        public IEnumerable<CardDto> Cards { get; }

        public DeckDto(CardDeck deck)
        {
            Name = deck.Name;
            Cards = deck.Cards.Select(card => 
                new CardDto
                {
                    Rank = Enum.GetName(card.Rank), 
                    Suit = Enum.GetName(card.Suit)
                });
        }
    }
}