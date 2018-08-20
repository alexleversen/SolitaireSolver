using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SolitaireSolver
{
    public class Deck : IList<Card>
    {
        IList<Card> _cards;

        public Deck()
        {
            InitializeCards();
        }

        void InitializeCards()
        {
            _cards = new List<Card>();
            foreach (var suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (var rank in Enum.GetValues(typeof(Rank)))
                {
                    _cards.Add(new Card((Suit)suit, (Rank)rank));
                }
            }
        }

        public void Shuffle()
        {
            var random = new Random();
            for (var i = 0; i < _cards.Count; i++)
            {
                var rnd = random.Next(i, _cards.Count);
                var temp = _cards[i];
                _cards[i] = _cards[rnd];
                _cards[rnd] = temp;
            }
        }

        public Card DealCard()
        {
            var card = this[0];
            RemoveAt(0);
            return card;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            foreach(var card in _cards)
            {
                sb.Append(card.ToString());
                sb.Append(",\n");
            }
            sb.Append("}");
            return sb.ToString();
        }

        public Card this[int index] { get => _cards[index]; set => _cards[index] = value; }

        public int Count => _cards.Count;

        public bool IsReadOnly => _cards.IsReadOnly;

        public void Add(Card item)
        {
            _cards.Add(item);
        }

        public void Clear()
        {
            _cards.Clear();
        }

        public bool Contains(Card item)
        {
            return _cards.Contains(item);
        }

        public void CopyTo(Card[] array, int arrayIndex)
        {
            _cards.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return _cards.GetEnumerator();
        }

        public int IndexOf(Card item)
        {
            return _cards.IndexOf(item);
        }

        public void Insert(int index, Card item)
        {
            _cards.Insert(index, item);
        }

        public bool Remove(Card item)
        {
            return _cards.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _cards.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _cards.GetEnumerator();
        }
    }
}
