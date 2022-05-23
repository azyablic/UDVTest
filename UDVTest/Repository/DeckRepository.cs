using System;
using System.Collections.Generic;
using System.Linq;

namespace UDVTest.Repository
{
    public class DeckRepository : IRepository<CardDeck>
    {
        private readonly List<CardDeck> decks;

        public DeckRepository()
        {
            decks = new List<CardDeck>();
        }
        
        public CardDeck Get(string name)
        {
            return decks.Find(d => d.Name == name);
        }

        public void Delete(string name)
        {
            var index = decks.FindIndex(d => d.Name == name);
            if (index == -1)
                throw new Exception($"Колода с именем {name} не найдена");
            decks.RemoveAt(index);
        }

        public void Add(string name)
        {
            var index = decks.FindIndex(d => d.Name == name);
            if (index != -1)
                throw new Exception($"Колода с именем {name} уже существует");
            decks.Add(new CardDeck(name));
        }

        public List<string> GetNames()
        {
            return decks.Select(d => d.Name).ToList();
        }
    }
}